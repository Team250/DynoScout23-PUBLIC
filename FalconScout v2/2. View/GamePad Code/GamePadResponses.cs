﻿using System;
using System.Collections.Generic;
using SlimDX.DirectInput;
using System.Diagnostics;
using SharpDX.XInput;

namespace T250DynoScout_v2023
{
    class Controllers
    {
        public void setScore()
        {
            RobotState.Red_Score = 0;

            RobotState.Blue_Score = 0;
        }

        RobotState[] rs;   //Objects for storing Match State

        // #Rumble

        //Controller rumble0 = new Controller((UserIndex)0);
        //Controller rumble1 = new Controller((UserIndex)1);
        //Controller rumble2 = new Controller((UserIndex)2);
        //Controller rumble3 = new Controller((UserIndex)3);
        //Controller rumble4 = new Controller((UserIndex)4);
        //Controller rumble5 = new Controller((UserIndex)5);



        Vibration vibration = new Vibration { LeftMotorSpeed = 65535, RightMotorSpeed = 65535 };
        Vibration vibration2 = new Vibration { LeftMotorSpeed = 0, RightMotorSpeed = 0 };

        Activity activity_record = new Activity();              //This is the activity for one Acquire and Scoring cycle.  We also save when an Event Activity is selected.       
        SeasonContext seasonframework = new SeasonContext();    //This is the context, meaning the entire database structure supporting this application.

        Utilities utilities = new Utilities();
        public Stopwatch stopwatch = new Stopwatch();

        public TimeSpan Zero { get; private set; }

        //getScoreZone to getScoreZone all the joysticks connected to the computer
        public Joystick[] GetSticks(DirectInput Input, SlimDX.DirectInput.Joystick stick, Joystick[] Sticks, Joystick stick1)
        {
            List<SlimDX.DirectInput.Joystick> sticks = new List<SlimDX.DirectInput.Joystick>(); //Creates the list of joysticks connected to the computer via USB.
            foreach (DeviceInstance device in Input.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly))
            {
                //Creates a joystick for each game device in USB Ports
                try
                {
                    stick = new SlimDX.DirectInput.Joystick(Input, device.InstanceGuid);
                    stick.Acquire();

                    //Gets the joysticks properties and sets the range for them.
                    foreach (DeviceObjectInstance deviceObject in stick.GetObjects())
                    {
                        if ((deviceObject.ObjectType & ObjectDeviceType.Axis) != 0)
                            stick.GetObjectPropertiesById((int)deviceObject.ObjectType).SetRange(-100, 100);
                    }

                    //Adds how ever many joysticks are connected to the computer into the sticks list.
                    sticks.Add(stick);
                }
                catch (DirectInputException) { }
            }
            return sticks.ToArray();
        }

        public RobotState getRobotState(int state)
        {
            state = Math.Max(0, state);
            state = Math.Min(5, state);
            return rs[state]; //If you crash here, you do not have a controller connected
        }

        public GamePad[] getGamePads()
        {
            //Connect to DirectInput and setup Joystick Objects
            DirectInput Input = new DirectInput();
            Joystick stick;
            GamePad gamepad;

            //Creates the list of joysticks connected to the computer via USB.
            List<SlimDX.DirectInput.Joystick> sticks = new List<SlimDX.DirectInput.Joystick>();
            List<GamePad> gamepads = new List<GamePad>();
            foreach (DeviceInstance device in Input.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly))
            {
                //Creates a joystick object for each game device in USB Ports
                try
                {
                    stick = new SlimDX.DirectInput.Joystick(Input, device.InstanceGuid);
                    stick.Acquire();

                    //Gets the joysticks properties and sets the range for them.
                    foreach (DeviceObjectInstance deviceObject in stick.GetObjects())
                    {
                        if ((deviceObject.ObjectType & ObjectDeviceType.Axis) != 0)
                            stick.GetObjectPropertiesById((int)deviceObject.ObjectType).SetRange(-100, 100);
                    }

                    gamepad = new GamePad(stick);

                    //Adds how ever many joysticks are connected to the computer into the sticks list.
                    sticks.Add(stick);
                    gamepads.Add(gamepad);
                    Console.WriteLine(stick.Information.InstanceName);
                }
                catch (DirectInputException) { }

                //Initiate Match State objects
                rs = new RobotState[6];
                rs[0] = new RobotState();
                rs[1] = new RobotState();
                rs[2] = new RobotState();
                rs[3] = new RobotState();
                rs[4] = new RobotState();
                rs[5] = new RobotState();
                rs[0].color = "Red";
                rs[1].color = "Red";
                rs[2].color = "Red";
                rs[3].color = "Blue";
                rs[4].color = "Blue";
                rs[5].color = "Blue";
            }
            return gamepads.ToArray();  //return sticks.ToArray();
        }
        public void readStick(GamePad[] gpArray, int controllerNumber)
        {

            GamePad gamepad = gpArray[controllerNumber];
            gamepad.Update();

            if (gamepad.RTHRight_Press && !rs[controllerNumber].NoSho)
            {
                rs[controllerNumber].cycleEventName(RobotState.CYCLE_DIRECTION.Up);
            }
            if (gamepad.RTHLeft_Press && !rs[controllerNumber].NoSho)
            {
                rs[controllerNumber].cycleEventName(RobotState.CYCLE_DIRECTION.Down);
            }

            if (gamepad.R3_Press)
            {
                if (rs[controllerNumber].match_event != RobotState.MATCHEVENT_NAME.Match_Event && !rs[controllerNumber].NoSho && rs[controllerNumber]._ScouterName != RobotState.SCOUTER_NAME.Select_Name)
                {

                    if (rs[controllerNumber].match_event == RobotState.MATCHEVENT_NAME.No_Show)
                    {
                        activity_record.match_event = (rs[controllerNumber].match_event.ToString())[0].ToString();
                        rs[controllerNumber].NoSho = true;
                    }
                    else
                    {
                        activity_record.match_event = (rs[controllerNumber].match_event.ToString())[0].ToString(); //If you crash here, you didn't load matches Boomer
                    }
                    activity_record.Team = rs[controllerNumber].TeamName;
                    activity_record.Match = rs[controllerNumber].Current_Match;
                    activity_record.Time = DateTime.Now;
                    activity_record.Mode = rs[controllerNumber].Current_Mode.ToString();
                    activity_record.ScouterName = rs[controllerNumber].getScouterName(RobotState.SCOUTER_NAME.Select_Name).ToString();
                    //activity_record.ScouterNameAlt = rs[controllerNumber].getScouterNameALT(RobotState.SCOUTER_NAME_ALT.Select_AltName).ToString();
                    activity_record.RecordType = "Match_Event";
                    activity_record.Mobility = 0;
                    activity_record.AcqSub1 = 0;
                    activity_record.AcqSub2 = 0;
                    activity_record.AcqFComm = 0;
                    activity_record.AcqFLoad = 0;
                    activity_record.AcqFOther = 0;
                    activity_record.AcqFOpps = 0;
                    activity_record.DelTop = 0;
                    activity_record.DelMid = 0;
                    activity_record.DelBot = 0;
                    activity_record.DelFloor = 0;
                    activity_record.DelOut = 0;
                    activity_record.DelCoop = 0;
                    activity_record.DelDrop = 0;
                    activity_record.Cone = 0;
                    activity_record.Cube = 0;
                    activity_record.Parked = 0;
                    activity_record.Docked = 0;
                    activity_record.Engaged = 0;
                    activity_record.Tried_And_Failed = 0;
                    activity_record.No_Attempt = 0;
                    activity_record.ChargePart = 0;
                    activity_record.EngageT = 0;
                    activity_record.EngageFail = "-";
                    activity_record.Setup = 0;
                    activity_record.AutoPts = 0;
                    activity_record.GridPts = 0;
                    activity_record.ChargePts = 0;
                    activity_record.ScouterError = 0;
                    activity_record.Defense = 0;
                    activity_record.Avoidance = 0;
                    activity_record.Strategy = "-";

                    //Save Record to the database
                    seasonframework.ActivitySet.Add(activity_record);
                    seasonframework.SaveChanges(); // If you crash here migration isn't working

                    rs[controllerNumber].match_event = RobotState.MATCHEVENT_NAME.Match_Event;

                    //Reset Match Event
                    rs[controllerNumber].match_event = 0;
                }
                else if (rs[controllerNumber].match_event == RobotState.MATCHEVENT_NAME.Match_Event)
                {
                    rs[controllerNumber].ScouterError++;
                }
            }

            // #Auto
            // **************************************************************
            // *** Auto MODE ***
            // **************************************************************
            if (rs[controllerNumber].Current_Mode == RobotState.ROBOT_MODE.Auto && !rs[controllerNumber].NoSho)
            {
                //2023 Scouter Names
                if (gamepad.XButton_Down)
                {
                    if (gamepad.LTHRight_Press)
                    {
                        rs[controllerNumber].changeScouterName(RobotState.CYCLE_DIRECTION.Up);
                    }
                    if (gamepad.LTHLeft_Press)
                    {
                        rs[controllerNumber].changeScouterName(RobotState.CYCLE_DIRECTION.Down);
                    }
                    //if (gamepad.LTHUp_Press)
                    //{
                    //    rs[controllerNumber].changeScouterNameALT(RobotState.CYCLE_DIRECTION.Up);
                    //}
                    //if (gamepad.LTHDown_Press)
                    //{
                    //    rs[controllerNumber].changeScouterNameALT(RobotState.CYCLE_DIRECTION.Down);
                    //}
                }

                //2023 Setup Location and Mobility Auto
                if (gamepad.StartButton_Press)
                {
                    if (gamepad.XButton_Down)
                    {
                        rs[controllerNumber].changeSetLoc(RobotState.CYCLE_DIRECTION.Up);
                    }
                    else
                    {
                        rs[controllerNumber].changeMob(RobotState.CYCLE_DIRECTION.Up);
                    }
                }

                //2023 Acquire Auto
                if (gamepad.LeftTrigger_Down && gamepad.AButton_Down && gamepad.DpadUp_Press)
                {
                    rs[controllerNumber].Acq = RobotState.ACQ.Floor_Comm;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Piece = RobotState.PIECE.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftTrigger_Down && gamepad.AButton_Down && gamepad.DpadLeft_Press)
                {
                    rs[controllerNumber].Acq = RobotState.ACQ.Other;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Piece = RobotState.PIECE.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftTrigger_Down && gamepad.AButton_Down && gamepad.DpadDown_Press)
                {
                    rs[controllerNumber].Acq = RobotState.ACQ.Floor_Neut;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Piece = RobotState.PIECE.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftTrigger_Down && gamepad.AButton_Down && gamepad.DpadRight_Press)
                {
                    rs[controllerNumber].Acq = RobotState.ACQ.Floor_Load;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Piece = RobotState.PIECE.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }

                //2023 Deliver Coop Node Auto
                if (gamepad.LeftButton_Down && gamepad.YButton_Down && gamepad.DpadUp_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Coop;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Top;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftButton_Down && gamepad.YButton_Down && gamepad.DpadDown_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Coop;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Bot;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftButton_Down && gamepad.YButton_Down && gamepad.DpadRight_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Coop;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Mid;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.RightButton_Down && gamepad.YButton_Down && gamepad.DpadUp_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Coop;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Top;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.RightButton_Down && gamepad.YButton_Down && gamepad.DpadDown_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Coop;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Bot;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.RightButton_Down && gamepad.YButton_Down && gamepad.DpadRight_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Coop;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Mid;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }

                //2023 Deliver Outer Node Auto
                if (gamepad.LeftButton_Down && gamepad.BButton_Down && gamepad.DpadUp_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Outer;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Top;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftButton_Down && gamepad.BButton_Down && gamepad.DpadDown_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Outer;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Bot;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftButton_Down && gamepad.BButton_Down && gamepad.DpadRight_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Outer;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Mid;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftButton_Down && gamepad.BButton_Down && gamepad.DpadLeft_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Select;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.RightButton_Down && gamepad.BButton_Down && gamepad.DpadUp_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Outer;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Top;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.RightButton_Down && gamepad.BButton_Down && gamepad.DpadDown_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Outer;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Bot;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.RightButton_Down && gamepad.BButton_Down && gamepad.DpadRight_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Outer;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Mid;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.RightButton_Down && gamepad.BButton_Down && gamepad.DpadLeft_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Select;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }

                //2023 Deliver Floor Auto
                if (gamepad.LeftButton_Down && gamepad.AButton_Down && gamepad.DpadUp_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Success;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Floor;
                }
                if (gamepad.LeftButton_Down && gamepad.AButton_Down && gamepad.DpadRight_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Success;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Floor;
                }
                if (gamepad.LeftButton_Down && gamepad.AButton_Down && gamepad.DpadLeft_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Success;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Floor;
                }
                if (gamepad.LeftButton_Down && gamepad.AButton_Down && gamepad.DpadDown_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Drop;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Floor;
                }
                if (gamepad.RightButton_Down && gamepad.AButton_Down && gamepad.DpadUp_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Success;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Floor;
                }
                if (gamepad.RightButton_Down && gamepad.AButton_Down && gamepad.DpadRight_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Success;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Floor;
                }
                if (gamepad.RightButton_Down && gamepad.AButton_Down && gamepad.DpadLeft_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Success;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Floor;
                }
                if (gamepad.RightButton_Down && gamepad.AButton_Down && gamepad.DpadDown_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Drop;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Floor;
                }

                //2023 Charging Auto
                if (gamepad.LTHRight_Press && !gamepad.XButton_Down)
                {
                    rs[controllerNumber].changeChargeStatus(RobotState.CYCLE_DIRECTION.Up);
                    rs[controllerNumber].changeChargeStatusAuto(RobotState.CYCLE_DIRECTION.Up);
                    if (rs[controllerNumber].ChargeStatus == RobotState.CHARGESTATUS.Parked)
                    {
                        rs[controllerNumber].changeChargeStatus(RobotState.CYCLE_DIRECTION.Up);
                        rs[controllerNumber].changeChargeStatusAuto(RobotState.CYCLE_DIRECTION.Up);
                    }
                }
                if (gamepad.LTHLeft_Press && !gamepad.XButton_Down)
                {
                    rs[controllerNumber].changeChargeStatus(RobotState.CYCLE_DIRECTION.Down);
                    rs[controllerNumber].changeChargeStatusAuto(RobotState.CYCLE_DIRECTION.Down);
                    if (rs[controllerNumber].ChargeStatus == RobotState.CHARGESTATUS.Parked)
                    {
                        rs[controllerNumber].changeChargeStatus(RobotState.CYCLE_DIRECTION.Down);
                        rs[controllerNumber].changeChargeStatusAuto(RobotState.CYCLE_DIRECTION.Down);
                    }
                }

                //2023 Set Piece w/o Other Buttons Auto
                if (gamepad.LeftButton_Down)
                {
                    rs[controllerNumber].DPiece = RobotState.PIECE.Cube;
                }
                else if (gamepad.RightButton_Down)
                {
                    rs[controllerNumber].DPiece = RobotState.PIECE.Cone;
                }
                else if (!gamepad.LeftButton_Down && !gamepad.RightButton_Down)
                {
                    rs[controllerNumber].DPiece = RobotState.PIECE.Select;
                }

                //2023 Set Grid w/o Other Buttons Auto
                if (gamepad.YButton_Down)
                {
                    rs[controllerNumber].DDelGrid = RobotState.DELGRID.Coop;
                }
                else if (gamepad.BButton_Down)
                {
                    rs[controllerNumber].DDelGrid = RobotState.DELGRID.Outer;
                }
                else if (!gamepad.YButton_Down && !gamepad.BButton_Down)
                {
                    rs[controllerNumber].DDelGrid = RobotState.DELGRID.Select;
                }

                //2023 Floor and Node lbls Auto
                if (gamepad.YButton_Down || gamepad.BButton_Down)
                {
                    rs[controllerNumber].DNodelbl = RobotState.NODELBL.Node;
                }
                else if (!gamepad.YButton_Down && !gamepad.BButton_Down)
                {
                    rs[controllerNumber].DNodelbl = RobotState.NODELBL.Select;
                }
                if (gamepad.AButton_Down && !gamepad.LeftTrigger_Down)
                {
                    rs[controllerNumber].DFloorlbl = RobotState.FLOORLBL.Floor;
                }
                else if (!gamepad.AButton_Down && !gamepad.LeftTrigger_Down)
                {
                    rs[controllerNumber].DFloorlbl = RobotState.FLOORLBL.Select;
                }
            }

            // #Teleop
            // **************************************************************
            // *** Teleop MODE ***
            // **************************************************************
            if (rs[controllerNumber].Current_Mode == RobotState.ROBOT_MODE.Teleop && !rs[controllerNumber].NoSho)
            {
                //2023 Acquire Teleop
                if (gamepad.LeftTrigger_Down && gamepad.AButton_Down && gamepad.DpadUp_Press)
                {
                    rs[controllerNumber].Acq = RobotState.ACQ.Floor_Comm;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Piece = RobotState.PIECE.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftTrigger_Down && gamepad.AButton_Down && gamepad.DpadLeft_Press)
                {
                    rs[controllerNumber].Acq = RobotState.ACQ.Other;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Piece = RobotState.PIECE.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftTrigger_Down && gamepad.AButton_Down && gamepad.DpadDown_Press)
                {
                    rs[controllerNumber].Acq = RobotState.ACQ.Floor_Neut;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Piece = RobotState.PIECE.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftTrigger_Down && gamepad.AButton_Down && gamepad.DpadRight_Press)
                {
                    rs[controllerNumber].Acq = RobotState.ACQ.Floor_Load;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Piece = RobotState.PIECE.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftTrigger_Down && gamepad.XButton_Down && gamepad.DpadUp_Press)
                {
                    rs[controllerNumber].Acq = RobotState.ACQ.Shelf;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Piece = RobotState.PIECE.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftTrigger_Down && gamepad.XButton_Down && gamepad.DpadDown_Press)
                {
                    rs[controllerNumber].Acq = RobotState.ACQ.Chute;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Piece = RobotState.PIECE.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftTrigger_Down && gamepad.XButton_Down && gamepad.DpadRight_Press)
                {
                    rs[controllerNumber].Acq = RobotState.ACQ.Opp;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Piece = RobotState.PIECE.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }

                //2023 Deliver Coop Node Teleop
                if (gamepad.LeftButton_Down && gamepad.YButton_Down && gamepad.DpadUp_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Coop;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Top;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftButton_Down && gamepad.YButton_Down && gamepad.DpadDown_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Coop;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Bot;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftButton_Down && gamepad.YButton_Down && gamepad.DpadRight_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Coop;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Mid;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.RightButton_Down && gamepad.YButton_Down && gamepad.DpadUp_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Coop;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Top;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.RightButton_Down && gamepad.YButton_Down && gamepad.DpadDown_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Coop;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Bot;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.RightButton_Down && gamepad.YButton_Down && gamepad.DpadRight_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Coop;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Mid;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }

                //2023 Deliver Outer Node Teleop
                if (gamepad.LeftButton_Down && gamepad.BButton_Down && gamepad.DpadUp_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Outer;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Top;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftButton_Down && gamepad.BButton_Down && gamepad.DpadDown_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Outer;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Bot;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftButton_Down && gamepad.BButton_Down && gamepad.DpadRight_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Outer;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Mid;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftButton_Down && gamepad.BButton_Down && gamepad.DpadLeft_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Select;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.RightButton_Down && gamepad.BButton_Down && gamepad.DpadUp_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Outer;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Top;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.RightButton_Down && gamepad.BButton_Down && gamepad.DpadDown_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Outer;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Bot;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.RightButton_Down && gamepad.BButton_Down && gamepad.DpadRight_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Outer;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Mid;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.RightButton_Down && gamepad.BButton_Down && gamepad.DpadLeft_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Select;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }

                //2023 Deliver Floor Teleop
                if (gamepad.LeftButton_Down && gamepad.AButton_Down && gamepad.DpadUp_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Success;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Floor;
                }
                if (gamepad.LeftButton_Down && gamepad.AButton_Down && gamepad.DpadRight_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Success;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Floor;
                }
                if (gamepad.LeftButton_Down && gamepad.AButton_Down && gamepad.DpadLeft_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Success;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Floor;
                }
                if (gamepad.LeftButton_Down && gamepad.AButton_Down && gamepad.DpadDown_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Drop;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Floor;
                }
                if (gamepad.RightButton_Down && gamepad.AButton_Down && gamepad.DpadUp_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Success;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Floor;
                }
                if (gamepad.RightButton_Down && gamepad.AButton_Down && gamepad.DpadRight_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Success;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Floor;
                }
                if (gamepad.RightButton_Down && gamepad.AButton_Down && gamepad.DpadLeft_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Success;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Floor;
                }
                if (gamepad.RightButton_Down && gamepad.AButton_Down && gamepad.DpadDown_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Drop;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Floor;
                }

                //2023 Engage Timer Reset Teleop
                if (gamepad.StartButton_Press)
                {
                    rs[controllerNumber].EngageTime_StopWatch_running = false;
                    rs[controllerNumber].EngageTime_StopWatch.Reset();
                    rs[controllerNumber].EngageTime = rs[controllerNumber].EngageTime_StopWatch.Elapsed;
                }

                //2023 Set Piece w/o Other Buttons Teleop
                if (gamepad.LeftButton_Down)
                {
                    rs[controllerNumber].DPiece = RobotState.PIECE.Cube;
                }
                else if (gamepad.RightButton_Down)
                {
                    rs[controllerNumber].DPiece = RobotState.PIECE.Cone;
                }
                else if (!gamepad.LeftButton_Down && !gamepad.RightButton_Down)
                {
                    rs[controllerNumber].DPiece = RobotState.PIECE.Select;
                }

                //2023 Set Grid w/o Other Buttons Teleop
                if (gamepad.YButton_Down)
                {
                    rs[controllerNumber].DDelGrid = RobotState.DELGRID.Coop;
                }
                else if (gamepad.BButton_Down)
                {
                    rs[controllerNumber].DDelGrid = RobotState.DELGRID.Outer;
                }
                else if (!gamepad.YButton_Down && !gamepad.BButton_Down)
                {
                    rs[controllerNumber].DDelGrid = RobotState.DELGRID.Select;
                }

                //2023 Floor and Node lbls Telop
                if (gamepad.YButton_Down || gamepad.BButton_Down)
                {
                    rs[controllerNumber].DNodelbl = RobotState.NODELBL.Node;
                }
                else if (!gamepad.YButton_Down && !gamepad.BButton_Down)
                {
                    rs[controllerNumber].DNodelbl = RobotState.NODELBL.Select;
                }
                if (gamepad.AButton_Down && !gamepad.LeftTrigger_Down)
                {
                    rs[controllerNumber].DFloorlbl = RobotState.FLOORLBL.Floor;
                }
                else if (!gamepad.AButton_Down && !gamepad.LeftTrigger_Down)
                {
                    rs[controllerNumber].DFloorlbl = RobotState.FLOORLBL.Select;
                }
            }

            // #Endgame 
            // **************************************************************
            // *** ENDGAME MODE ***
            // **************************************************************
            if (rs[controllerNumber].Current_Mode == RobotState.ROBOT_MODE.Endgame && !rs[controllerNumber].NoSho)
            {
                //2023 Acquire Endgame
                if (gamepad.LeftTrigger_Down && gamepad.AButton_Down && gamepad.DpadUp_Press)
                {
                    rs[controllerNumber].Acq = RobotState.ACQ.Floor_Comm;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Piece = RobotState.PIECE.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftTrigger_Down && gamepad.AButton_Down && gamepad.DpadLeft_Press)
                {
                    rs[controllerNumber].Acq = RobotState.ACQ.Other;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Piece = RobotState.PIECE.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftTrigger_Down && gamepad.AButton_Down && gamepad.DpadDown_Press)
                {
                    rs[controllerNumber].Acq = RobotState.ACQ.Floor_Neut;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Piece = RobotState.PIECE.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftTrigger_Down && gamepad.AButton_Down && gamepad.DpadRight_Press)
                {
                    rs[controllerNumber].Acq = RobotState.ACQ.Floor_Load;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Piece = RobotState.PIECE.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }

                //2023 Deliver Coop Node Endgame
                if (gamepad.LeftButton_Down && gamepad.YButton_Down && gamepad.DpadUp_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Coop;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Top;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftButton_Down && gamepad.YButton_Down && gamepad.DpadDown_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Coop;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Bot;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftButton_Down && gamepad.YButton_Down && gamepad.DpadRight_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Coop;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Mid;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.RightButton_Down && gamepad.YButton_Down && gamepad.DpadUp_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Coop;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Top;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.RightButton_Down && gamepad.YButton_Down && gamepad.DpadDown_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Coop;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Bot;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.RightButton_Down && gamepad.YButton_Down && gamepad.DpadRight_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Coop;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Mid;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }

                //2023 Deliver Outer Node Endgame
                if (gamepad.LeftButton_Down && gamepad.BButton_Down && gamepad.DpadUp_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Outer;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Top;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftButton_Down && gamepad.BButton_Down && gamepad.DpadDown_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Outer;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Bot;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftButton_Down && gamepad.BButton_Down && gamepad.DpadRight_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Outer;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Mid;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.LeftButton_Down && gamepad.BButton_Down && gamepad.DpadLeft_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Select;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.RightButton_Down && gamepad.BButton_Down && gamepad.DpadUp_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Outer;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Top;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.RightButton_Down && gamepad.BButton_Down && gamepad.DpadDown_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Outer;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Bot;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.RightButton_Down && gamepad.BButton_Down && gamepad.DpadRight_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Outer;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Mid;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }
                if (gamepad.RightButton_Down && gamepad.BButton_Down && gamepad.DpadLeft_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Select;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Node;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                }

                //2023 Deliver Floor Endgame
                if (gamepad.LeftButton_Down && gamepad.AButton_Down && gamepad.DpadUp_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Success;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Floor;
                }
                if (gamepad.LeftButton_Down && gamepad.AButton_Down && gamepad.DpadRight_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Success;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Floor;
                }
                if (gamepad.LeftButton_Down && gamepad.AButton_Down && gamepad.DpadLeft_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Success;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Floor;
                }
                if (gamepad.LeftButton_Down && gamepad.AButton_Down && gamepad.DpadDown_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cube;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Drop;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Floor;
                }
                if (gamepad.RightButton_Down && gamepad.AButton_Down && gamepad.DpadUp_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Success;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Floor;
                }
                if (gamepad.RightButton_Down && gamepad.AButton_Down && gamepad.DpadRight_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Success;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Floor;
                }
                if (gamepad.RightButton_Down && gamepad.AButton_Down && gamepad.DpadLeft_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Success;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Floor;
                }
                if (gamepad.RightButton_Down && gamepad.AButton_Down && gamepad.DpadDown_Press)
                {
                    rs[controllerNumber].Piece = RobotState.PIECE.Cone;
                    rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Drop;
                    rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                    rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                    rs[controllerNumber].Acq = RobotState.ACQ.Select;
                    rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                    rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Floor;
                }

                //2023 Teams on Charging Station Endgame
                if (gamepad.XButton_Down && gamepad.StartButton_Press)
                {
                    rs[controllerNumber].changeCSTeams(RobotState.CYCLE_DIRECTION.Up);
                }

                //2023 End Status and Fail Endgame
                if (gamepad.LTHRight_Press && !gamepad.XButton_Down)
                {
                    rs[controllerNumber].changeChargeStatus(RobotState.CYCLE_DIRECTION.Up);
                }
                if (gamepad.LTHLeft_Press && !gamepad.XButton_Down)
                {
                    rs[controllerNumber].changeChargeStatus(RobotState.CYCLE_DIRECTION.Down);
                }
                if (gamepad.LTHUp_Press && !gamepad.XButton_Down)
                {
                    rs[controllerNumber].changeFailReason(RobotState.CYCLE_DIRECTION.Up);
                }
                if (gamepad.LTHDown_Press && !gamepad.XButton_Down)
                {
                    rs[controllerNumber].changeFailReason(RobotState.CYCLE_DIRECTION.Down);
                }

                //2023 Strategy 
                if (gamepad.LTHRight_Press && gamepad.XButton_Down)
                {
                    rs[controllerNumber].changeStrategy(RobotState.CYCLE_DIRECTION.Up);
                }
                if (gamepad.LTHLeft_Press && gamepad.XButton_Down)
                {
                    rs[controllerNumber].changeStrategy(RobotState.CYCLE_DIRECTION.Down);
                }

                //2023 Def and Avo Ratings
                if (gamepad.XButton_Down && gamepad.DpadRight_Press)
                {
                    rs[controllerNumber].changeAvoRate(RobotState.CYCLE_DIRECTION.Up);
                }
                if (gamepad.XButton_Down && gamepad.DpadLeft_Press)
                {
                    rs[controllerNumber].changeAvoRate(RobotState.CYCLE_DIRECTION.Down);
                }
                if (gamepad.XButton_Down && gamepad.DpadUp_Press)
                {
                    rs[controllerNumber].changeDefRate(RobotState.CYCLE_DIRECTION.Up);
                }
                if (gamepad.XButton_Down && gamepad.DpadDown_Press)
                {
                    rs[controllerNumber].changeDefRate(RobotState.CYCLE_DIRECTION.Down);
                }

                //2023 Engage Timer
                if (gamepad.StartButton_Press && !gamepad.XButton_Down && rs[controllerNumber].EngageTime_StopWatch_running == true)
                {
                    rs[controllerNumber].EngageTime_StopWatch.Stop();
                    rs[controllerNumber].EngageTime = rs[controllerNumber].EngageTime_StopWatch.Elapsed;
                    rs[controllerNumber].EngageTime_StopWatch_running = false;
                }
                else if (gamepad.StartButton_Press && !gamepad.XButton_Down && rs[controllerNumber].EngageTime_StopWatch_running == false)
                {
                    rs[controllerNumber].EngageTime_StopWatch.Start();
                    rs[controllerNumber].EngageTime = rs[controllerNumber].EngageTime_StopWatch.Elapsed;
                    rs[controllerNumber].EngageTime_StopWatch_running = true;
                }

                //2023 Set Piece w/o Other Buttons Endgame
                if (gamepad.LeftButton_Down)
                {
                    rs[controllerNumber].DPiece = RobotState.PIECE.Cube;
                }
                else if (gamepad.RightButton_Down)
                {
                    rs[controllerNumber].DPiece = RobotState.PIECE.Cone;
                }
                else if (!gamepad.LeftButton_Down && !gamepad.RightButton_Down)
                {
                    rs[controllerNumber].DPiece = RobotState.PIECE.Select;
                }

                //2023 Set Grid w/o Other Buttons Endgame
                if (gamepad.YButton_Down)
                {
                    rs[controllerNumber].DDelGrid = RobotState.DELGRID.Coop;
                }
                else if (gamepad.BButton_Down)
                {
                    rs[controllerNumber].DDelGrid = RobotState.DELGRID.Outer;
                }
                else if (!gamepad.YButton_Down && !gamepad.BButton_Down)
                {
                    rs[controllerNumber].DDelGrid = RobotState.DELGRID.Select;
                }

                //2023 Floor and Node lbls Endgame
                if (gamepad.YButton_Down || gamepad.BButton_Down)
                {
                    rs[controllerNumber].DNodelbl = RobotState.NODELBL.Node;
                }
                else if (!gamepad.YButton_Down && !gamepad.BButton_Down)
                {
                    rs[controllerNumber].DNodelbl = RobotState.NODELBL.Select;
                }
                if (gamepad.AButton_Down && !gamepad.LeftTrigger_Down)
                {
                    rs[controllerNumber].DFloorlbl = RobotState.FLOORLBL.Floor;
                }
                else if (!gamepad.AButton_Down && !gamepad.LeftTrigger_Down)
                {
                    rs[controllerNumber].DFloorlbl = RobotState.FLOORLBL.Select;
                }
            }


            // #Transact
            // **************************************************************
            // ***  TRANSACT TO DATABASE  ***
            // **************************************************************
            if (rs[controllerNumber]._ScouterName != RobotState.SCOUTER_NAME.Select_Name)
            {
                if (rs[controllerNumber].Acq != RobotState.ACQ.Select || rs[controllerNumber].DelRow != RobotState.DELROW.Select || rs[controllerNumber].DelFloor != RobotState.DELFLOOR.Select)
                {
                    rs[controllerNumber].TransactionCheck = true;
                }
            }

            //2023 EndAuto End of Autonomous transaction
            if (rs[controllerNumber].AUTO && gamepad.BackButton_Press && !rs[controllerNumber].NoSho && rs[controllerNumber]._ScouterName != RobotState.SCOUTER_NAME.Select_Name)
            {
                activity_record.Team = rs[controllerNumber].TeamName;
                activity_record.Match = rs[controllerNumber].Current_Match;
                activity_record.Time = DateTime.Now;
                activity_record.Mode = rs[controllerNumber].Current_Mode.ToString();
                activity_record.ScouterName = rs[controllerNumber].getScouterName(RobotState.SCOUTER_NAME.Select_Name).ToString();
                //activity_record.ScouterNameAlt = rs[controllerNumber].getScouterNameALT(RobotState.SCOUTER_NAME_ALT.Select_AltName).ToString();
                activity_record.RecordType = "EndAuto";

                activity_record.match_event = "-";

                activity_record.Defense = 0;
                activity_record.Avoidance = 0;

                activity_record.ScouterError = rs[controllerNumber].ScouterError;

                activity_record.AcqSub1 = 0;
                activity_record.AcqSub2 = 0;
                activity_record.AcqFComm = 0;
                activity_record.AcqFLoad = 0;
                activity_record.AcqFOther = 0;
                activity_record.AcqFOpps = 0;
                activity_record.DelTop = 0;
                activity_record.DelMid = 0;
                activity_record.DelBot = 0;
                activity_record.DelOut = 0;
                activity_record.DelCoop = 0;
                activity_record.DelDrop = 0;
                activity_record.Cone = 0;
                activity_record.Cube = 0;
                activity_record.Parked = 0;
                activity_record.ChargePart = 0;
                activity_record.EngageT = 0;
                activity_record.EngageFail = "-";
                activity_record.GridPts = 0;
                activity_record.ChargePts = 0;
                activity_record.Strategy = "-";

                //2023 Scoring
                if (rs[controllerNumber].Mob == RobotState.MOB.Y)
                {
                    rs[controllerNumber].APoints = rs[controllerNumber].APoints + 3;
                    activity_record.Mobility = 1;
                }
                else if (rs[controllerNumber].Mob == RobotState.MOB.N)
                {
                    activity_record.Mobility = 0;
                }

                if (rs[controllerNumber].ChargeStatus == RobotState.CHARGESTATUS.Engaged)
                {
                    rs[controllerNumber].CPoints = rs[controllerNumber].CPoints + 12;
                    activity_record.Engaged = 1;
                    activity_record.Docked = 0;
                    activity_record.Tried_And_Failed = 0;
                    activity_record.No_Attempt = 0;
                }
                else if (rs[controllerNumber].ChargeStatus == RobotState.CHARGESTATUS.Docked)
                {
                    rs[controllerNumber].CPoints = rs[controllerNumber].CPoints + 8;
                    activity_record.Engaged = 0;
                    activity_record.Docked = 1;
                    activity_record.Tried_And_Failed = 0;
                    activity_record.No_Attempt = 0;
                }
                else if (rs[controllerNumber].ChargeStatus == RobotState.CHARGESTATUS.No_Attempt)
                {
                    activity_record.Engaged = 0;
                    activity_record.Docked = 0;
                    activity_record.Tried_And_Failed = 0;
                    activity_record.No_Attempt = 1;
                }
                else if (rs[controllerNumber].ChargeStatus == RobotState.CHARGESTATUS.Tried_And_Failed)
                {
                    activity_record.Engaged = 0;
                    activity_record.Docked = 0;
                    activity_record.Tried_And_Failed = 1;
                    activity_record.No_Attempt = 0;
                }
                else
                {
                    activity_record.Engaged = 0;
                    activity_record.Docked = 0;
                    activity_record.Tried_And_Failed = 0;
                    activity_record.No_Attempt = 0;
                    rs[controllerNumber].ScouterError++;
                }

                if (rs[controllerNumber].SetLoc == RobotState.SETLOC.Q_)
                {
                    activity_record.Setup = 0;
                    rs[controllerNumber].ScouterError++;
                }
                else if (rs[controllerNumber].SetLoc == RobotState.SETLOC.Q1)
                {
                    activity_record.Setup = 1;
                }
                else if (rs[controllerNumber].SetLoc == RobotState.SETLOC.Q2)
                {
                    activity_record.Setup = 2;
                }
                else if (rs[controllerNumber].SetLoc == RobotState.SETLOC.Q3)
                {
                    activity_record.Setup = 3;
                }
                else if (rs[controllerNumber].SetLoc == RobotState.SETLOC.Q4)
                {
                    activity_record.Setup = 4;
                }

                rs[controllerNumber].AUTO = false;

                //Save Record to the database
                seasonframework.ActivitySet.Add(activity_record);
                seasonframework.SaveChanges();

                //Reset Values
                rs[controllerNumber].Mob = RobotState.MOB.N;
                rs[controllerNumber].ChargeStatus = RobotState.CHARGESTATUS.Select;
            }
            else if (gamepad.RightTrigger_Press && !rs[controllerNumber].NoSho && rs[controllerNumber].TransactionCheck == true)
            {
                activity_record.Team = rs[controllerNumber].TeamName;
                activity_record.Match = rs[controllerNumber].Current_Match;
                activity_record.Time = DateTime.Now;
                activity_record.Mode = rs[controllerNumber].Current_Mode.ToString();
                activity_record.ScouterName = rs[controllerNumber].getScouterName(RobotState.SCOUTER_NAME.Select_Name).ToString();
                //activity_record.ScouterNameAlt = rs[controllerNumber].getScouterNameALT(RobotState.SCOUTER_NAME_ALT.Select_AltName).ToString();
                activity_record.RecordType = "Activities";

                activity_record.match_event = "-";

                activity_record.Mobility = 0;
                activity_record.Parked = 0;
                activity_record.Docked = 0;
                activity_record.Engaged = 0;
                activity_record.Tried_And_Failed = 0;
                activity_record.No_Attempt = 0;
                activity_record.ChargePart = 0;
                activity_record.EngageT = 0;
                activity_record.EngageFail = "-";
                activity_record.Setup = 0;
                activity_record.AutoPts = 0;
                activity_record.ChargePts = 0;
                activity_record.Strategy = "-";

                activity_record.Defense = 0;
                activity_record.Avoidance = 0;

                activity_record.ScouterError = 0;

                if (rs[controllerNumber].AUTO == true)
                {
                    if (rs[controllerNumber].DelRow == RobotState.DELROW.Bot)
                    {
                        rs[controllerNumber].APoints = rs[controllerNumber].APoints + 3;
                        rs[controllerNumber].GPoints = rs[controllerNumber].GPoints + 3;
                        activity_record.DelTop = 0;
                        activity_record.DelMid = 0;
                        activity_record.DelBot = 1;
                        if (rs[controllerNumber].Piece == RobotState.PIECE.Cone)
                        {
                            activity_record.Cone = 1;
                            activity_record.Cube = 0;
                            rs[controllerNumber].TotDelConeHyb = rs[controllerNumber].TotDelConeHyb + 1;
                            rs[controllerNumber].TotAutoCone = rs[controllerNumber].TotAutoCone + 1;
                        }
                        else if (rs[controllerNumber].Piece == RobotState.PIECE.Cube)
                        {
                            activity_record.Cone = 0;
                            activity_record.Cube = 1;
                            rs[controllerNumber].TotDelCubeHyb = rs[controllerNumber].TotDelCubeHyb + 1;
                            rs[controllerNumber].TotAutoCube = rs[controllerNumber].TotAutoCube + 1;
                        }
                    }
                    else if (rs[controllerNumber].DelRow == RobotState.DELROW.Mid)
                    {
                        rs[controllerNumber].APoints = rs[controllerNumber].APoints + 4;
                        rs[controllerNumber].GPoints = rs[controllerNumber].GPoints + 4;
                        activity_record.DelTop = 0;
                        activity_record.DelMid = 1;
                        activity_record.DelBot = 0;
                        if (rs[controllerNumber].Piece == RobotState.PIECE.Cone)
                        {
                            activity_record.Cone = 1;
                            activity_record.Cube = 0;
                            rs[controllerNumber].TotDelConeMid = rs[controllerNumber].TotDelConeMid + 1;
                            rs[controllerNumber].TotAutoCone = rs[controllerNumber].TotAutoCone + 1;
                        }
                        else if (rs[controllerNumber].Piece == RobotState.PIECE.Cube)
                        {
                            activity_record.Cone = 0;
                            activity_record.Cube = 1;
                            rs[controllerNumber].TotDelCubeMid = rs[controllerNumber].TotDelCubeMid + 1;
                            rs[controllerNumber].TotAutoCube = rs[controllerNumber].TotAutoCube + 1;
                        }
                    }
                    else if (rs[controllerNumber].DelRow == RobotState.DELROW.Top)
                    {
                        rs[controllerNumber].APoints = rs[controllerNumber].APoints + 6;
                        rs[controllerNumber].GPoints = rs[controllerNumber].GPoints + 6;
                        activity_record.DelTop = 1;
                        activity_record.DelMid = 0;
                        activity_record.DelBot = 0;
                        if (rs[controllerNumber].Piece == RobotState.PIECE.Cone)
                        {
                            activity_record.Cone = 1;
                            activity_record.Cube = 0;
                            rs[controllerNumber].TotDelConeTop = rs[controllerNumber].TotDelConeTop + 1;
                            rs[controllerNumber].TotAutoCone = rs[controllerNumber].TotAutoCone + 1;
                        }
                        else if (rs[controllerNumber].Piece == RobotState.PIECE.Cube)
                        {
                            activity_record.Cone = 0;
                            activity_record.Cube = 1;
                            rs[controllerNumber].TotDelCubeTop = rs[controllerNumber].TotDelCubeTop + 1;
                            rs[controllerNumber].TotAutoCube = rs[controllerNumber].TotAutoCube + 1;
                        }
                    }
                }
                else if (rs[controllerNumber].AUTO == false)
                {
                    if (rs[controllerNumber].DelRow == RobotState.DELROW.Bot)
                    {
                        rs[controllerNumber].GPoints = rs[controllerNumber].GPoints + 2;
                        activity_record.DelTop = 0;
                        activity_record.DelMid = 0;
                        activity_record.DelBot = 1;
                        if (rs[controllerNumber].Piece == RobotState.PIECE.Cone)
                        {
                            activity_record.Cone = 1;
                            activity_record.Cube = 0;
                            rs[controllerNumber].TotDelConeHyb = rs[controllerNumber].TotDelConeHyb + 1;
                        }
                        else if (rs[controllerNumber].Piece == RobotState.PIECE.Cube)
                        {
                            activity_record.Cone = 0;
                            activity_record.Cube = 1;
                            rs[controllerNumber].TotDelCubeHyb = rs[controllerNumber].TotDelCubeHyb + 1;
                        }
                    }
                    else if (rs[controllerNumber].DelRow == RobotState.DELROW.Mid)
                    {
                        rs[controllerNumber].GPoints = rs[controllerNumber].GPoints + 3;
                        activity_record.DelTop = 0;
                        activity_record.DelMid = 1;
                        activity_record.DelBot = 0;
                        if (rs[controllerNumber].Piece == RobotState.PIECE.Cone)
                        {
                            activity_record.Cone = 1;
                            activity_record.Cube = 0;
                            rs[controllerNumber].TotDelConeMid = rs[controllerNumber].TotDelConeMid + 1;
                        }
                        else if (rs[controllerNumber].Piece == RobotState.PIECE.Cube)
                        {
                            activity_record.Cone = 0;
                            activity_record.Cube = 1;
                            rs[controllerNumber].TotDelCubeMid = rs[controllerNumber].TotDelCubeMid + 1;
                        }
                    }
                    else if (rs[controllerNumber].DelRow == RobotState.DELROW.Top)
                    {
                        rs[controllerNumber].GPoints = rs[controllerNumber].GPoints + 5;
                        activity_record.DelTop = 1;
                        activity_record.DelMid = 0;
                        activity_record.DelBot = 0;
                        if (rs[controllerNumber].Piece == RobotState.PIECE.Cone)
                        {
                            activity_record.Cone = 1;
                            activity_record.Cube = 0;
                            rs[controllerNumber].TotDelConeTop = rs[controllerNumber].TotDelConeTop + 1;
                        }
                        else if (rs[controllerNumber].Piece == RobotState.PIECE.Cube)
                        {
                            activity_record.Cone = 0;
                            activity_record.Cube = 1;
                            rs[controllerNumber].TotDelCubeTop = rs[controllerNumber].TotDelCubeTop + 1;
                        }
                    }
                }

                if (rs[controllerNumber].DelGrid == RobotState.DELGRID.Outer)
                {
                    activity_record.DelOut = 1;
                    activity_record.DelCoop = 0;
                    rs[controllerNumber].TotDelOut = rs[controllerNumber].TotDelOut + 1;
                }
                else if (rs[controllerNumber].DelGrid == RobotState.DELGRID.Coop)
                {
                    activity_record.DelOut = 0;
                    activity_record.DelCoop = 1;
                    rs[controllerNumber].TotDelCoop = rs[controllerNumber].TotDelCoop + 1;
                }
                else if (rs[controllerNumber].DelGrid == RobotState.DELGRID.Select)
                {
                    activity_record.DelOut = 0;
                    activity_record.DelCoop = 0;
                }

                if (rs[controllerNumber].Piece == RobotState.PIECE.Select)
                {
                    activity_record.Cone = 0;
                    activity_record.Cube = 0;
                }

                if (rs[controllerNumber].DelFloor == RobotState.DELFLOOR.Success)
                {
                    activity_record.DelFloor = 1;
                    activity_record.DelDrop = 0;
                    if (rs[controllerNumber].Piece == RobotState.PIECE.Cone)
                    {
                        activity_record.Cone = 1;
                        activity_record.Cube = 0;
                    }
                    else if (rs[controllerNumber].Piece == RobotState.PIECE.Cube)
                    {
                        activity_record.Cone = 0;
                        activity_record.Cube = 1;
                    }
                }
                else if (rs[controllerNumber].DelFloor == RobotState.DELFLOOR.Drop)
                {
                    activity_record.DelFloor = 0;
                    activity_record.DelDrop = 1;
                    if (rs[controllerNumber].Piece == RobotState.PIECE.Cone)
                    {
                        activity_record.Cone = 1;
                        activity_record.Cube = 0;
                    }
                    else if (rs[controllerNumber].Piece == RobotState.PIECE.Cube)
                    {
                        activity_record.Cone = 0;
                        activity_record.Cube = 1;
                    }
                }
                else if (rs[controllerNumber].DelFloor == RobotState.DELFLOOR.Select)
                {
                    activity_record.DelFloor = 0;
                    activity_record.DelDrop = 0;
                }

                if (rs[controllerNumber].Acq == RobotState.ACQ.Chute)
                {
                    activity_record.AcqSub1 = 1;
                    activity_record.AcqSub2 = 0;
                    activity_record.AcqFComm = 0;
                    activity_record.AcqFLoad = 0;
                    activity_record.AcqFOpps = 0;
                    activity_record.AcqFOther = 0;
                }
                else if (rs[controllerNumber].Acq == RobotState.ACQ.Shelf)
                {
                    activity_record.AcqSub1 = 0;
                    activity_record.AcqSub2 = 1;
                    activity_record.AcqFComm = 0;
                    activity_record.AcqFLoad = 0;
                    activity_record.AcqFOpps = 0;
                    activity_record.AcqFOther = 0;
                }
                else if (rs[controllerNumber].Acq == RobotState.ACQ.Opp)
                {
                    activity_record.AcqSub1 = 0;
                    activity_record.AcqSub2 = 0;
                    activity_record.AcqFComm = 0;
                    activity_record.AcqFLoad = 0;
                    activity_record.AcqFOpps = 1;
                    activity_record.AcqFOther = 0;
                }
                else if (rs[controllerNumber].Acq == RobotState.ACQ.Other)
                {
                    activity_record.AcqSub1 = 0;
                    activity_record.AcqSub2 = 0;
                    activity_record.AcqFComm = 0;
                    activity_record.AcqFLoad = 0;
                    activity_record.AcqFOpps = 0;
                    activity_record.AcqFOther = 1;
                }
                else if (rs[controllerNumber].Acq == RobotState.ACQ.Floor_Comm)
                {
                    activity_record.AcqSub1 = 0;
                    activity_record.AcqSub2 = 0;
                    activity_record.AcqFComm = 1;
                    activity_record.AcqFLoad = 0;
                    activity_record.AcqFOpps = 0;
                    activity_record.AcqFOther = 0;
                }
                else if (rs[controllerNumber].Acq == RobotState.ACQ.Floor_Load)
                {
                    activity_record.AcqSub1 = 0;
                    activity_record.AcqSub2 = 0;
                    activity_record.AcqFComm = 0;
                    activity_record.AcqFLoad = 1;
                    activity_record.AcqFOpps = 0;
                    activity_record.AcqFOther = 0;
                }
                else if (rs[controllerNumber].Acq == RobotState.ACQ.Floor_Load)
                {
                    activity_record.AcqSub1 = 0;
                    activity_record.AcqSub2 = 0;
                    activity_record.AcqFComm = 0;
                    activity_record.AcqFLoad = 1;
                    activity_record.AcqFOpps = 0;
                    activity_record.AcqFOther = 0;
                }
                else if (rs[controllerNumber].Acq == RobotState.ACQ.Floor_Neut)
                {
                    activity_record.AcqSub1 = 0;
                    activity_record.AcqSub2 = 0;
                    activity_record.AcqFComm = 0;
                    activity_record.AcqFLoad = 0;
                    activity_record.AcqFOpps = 0;
                    activity_record.AcqFOther = 1;
                }
                else if (rs[controllerNumber].Acq == RobotState.ACQ.Select)
                {
                    activity_record.AcqSub1 = 0;
                    activity_record.AcqSub2 = 0;
                    activity_record.AcqFComm = 0;
                    activity_record.AcqFLoad = 0;
                    activity_record.AcqFOpps = 0;
                    activity_record.AcqFOther = 0;
                }

                if (rs[controllerNumber].DelRow == RobotState.DELROW.Select)
                {
                    activity_record.DelTop = 0;
                    activity_record.DelMid = 0;
                    activity_record.DelBot = 0;
                }

                //Save Record to the database
                seasonframework.ActivitySet.Add(activity_record);
                seasonframework.SaveChanges();

                //Reset Values
                rs[controllerNumber].DelRow = RobotState.DELROW.Select;
                rs[controllerNumber].DelGrid = RobotState.DELGRID.Select;
                rs[controllerNumber].DelFloor = RobotState.DELFLOOR.Select;
                rs[controllerNumber].Piece = RobotState.PIECE.Select;
                rs[controllerNumber].Acq = RobotState.ACQ.Select;
                rs[controllerNumber].Nodelbl = RobotState.NODELBL.Select;
                rs[controllerNumber].Floorlbl = RobotState.FLOORLBL.Select;
                rs[controllerNumber].TransactionCheck = false;
            }
            else if (gamepad.RightTrigger_Press && !rs[controllerNumber].NoSho && rs[controllerNumber].TransactionCheck == false)
            {
                rs[controllerNumber].ScouterError = rs[controllerNumber].ScouterError + 100;
            }

            // 2023 Changing modes
            if (gamepad.BackButton_Press && rs[controllerNumber].Current_Mode == RobotState.ROBOT_MODE.Auto && !rs[controllerNumber].AUTO && !rs[controllerNumber].NoSho)
            {
                rs[controllerNumber].Desired_Mode = RobotState.ROBOT_MODE.Endgame;
                rs[controllerNumber].Current_Mode = RobotState.ROBOT_MODE.Teleop;
            }
            else if (gamepad.BackButton_Press && rs[controllerNumber].Current_Mode == RobotState.ROBOT_MODE.Teleop && !rs[controllerNumber].NoSho)

            {
                rs[controllerNumber].Desired_Mode = RobotState.ROBOT_MODE.Teleop;
                rs[controllerNumber].Current_Mode = RobotState.ROBOT_MODE.Endgame;
                rs[controllerNumber].EngageTime_StopWatch.Start();
                rs[controllerNumber].EngageTime = rs[controllerNumber].EngageTime_StopWatch.Elapsed;
                rs[controllerNumber].EngageTime_StopWatch_running = true;
            }
            else if (gamepad.BackButton_Press && rs[controllerNumber].Current_Mode == RobotState.ROBOT_MODE.Endgame && !rs[controllerNumber].NoSho)
            {
                rs[controllerNumber].Desired_Mode = RobotState.ROBOT_MODE.Endgame;
                rs[controllerNumber].Current_Mode = RobotState.ROBOT_MODE.Teleop;
            }
        }
    }
}