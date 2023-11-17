using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace T250DynoScout_v2023
{
    public partial class MainScreen : Form
    {

        private bool initializing = true;

        private void JoyStickReader(object sender, EventArgs e)
        {
            // Loop through all connected gamepads
            for (int gamepad_ctr = 0; gamepad_ctr < gamePads.Length; gamepad_ctr++) controllers.readStick(gamePads, gamepad_ctr);   //Initialize all six controllers

            // Loop through all Scouters/Robots
            for (int robot_ctr = 0; robot_ctr < Robots.Length; robot_ctr++)
            {
                Robots[robot_ctr] = controllers.getRobotState(robot_ctr);  //Initialize all six robots

                if (initializing == true) Robots[robot_ctr].EngageTime_StopWatch = new Stopwatch();
            }

            //// Loop through all Scouters/Robots
            for (int robot_ctr = 0; robot_ctr < 1; robot_ctr++)
            {
                Robots[robot_ctr] = controllers.getRobotState(robot_ctr);  //Initialize all six robots
            }

            initializing = false;

            Robots[0].Current_Match = Robots[1].Current_Match = Robots[2].Current_Match = Robots[3].Current_Match = Robots[4].Current_Match = Robots[5].Current_Match = currentmatch + 1;

            Robots[0].color = Robots[1].color = Robots[2].color = "Red";
            Robots[3].color = Robots[4].color = Robots[5].color = "Blue";
            // Switch Mode Handlers(What to do when a Scouter / Robot is switching modes)
            //#Session0
            // Scouter 1
            if ((Robots[0].Desired_Mode == RobotState.ROBOT_MODE.Auto) && Robots[0].Current_Mode == RobotState.ROBOT_MODE.Endgame) AutoToNearMode(0);

            //Scouter 2
            if ((Robots[1].Desired_Mode == RobotState.ROBOT_MODE.Auto) && Robots[1].Current_Mode == RobotState.ROBOT_MODE.Endgame) AutoToNearMode(1);

            ////Scouter 3
            if ((Robots[2].Desired_Mode == RobotState.ROBOT_MODE.Auto) && Robots[2].Current_Mode == RobotState.ROBOT_MODE.Endgame) AutoToNearMode(2);

            //// Scouter 4
            if ((Robots[3].Desired_Mode == RobotState.ROBOT_MODE.Auto) && Robots[3].Current_Mode == RobotState.ROBOT_MODE.Endgame) AutoToNearMode(3);

            //// Scouter 5
            if ((Robots[4].Desired_Mode == RobotState.ROBOT_MODE.Auto) && Robots[4].Current_Mode == RobotState.ROBOT_MODE.Endgame) AutoToNearMode(4);

            //// Scouter 6
            if ((Robots[5].Desired_Mode == RobotState.ROBOT_MODE.Auto) && Robots[5].Current_Mode == RobotState.ROBOT_MODE.Endgame) AutoToNearMode(5);


            // In Mode Handlers (What to do when a Scouter/Robot is in a mode, not switching between modes)
            // #Session0
            // Scouter 1
            if (Robots[0].Current_Mode == RobotState.ROBOT_MODE.Auto) InAutoMode(0);  // Scouter 1
            else if (Robots[0].Current_Mode == RobotState.ROBOT_MODE.Teleop) InTeleopMode(0);
            else if (Robots[0].Current_Mode == RobotState.ROBOT_MODE.Endgame) InEndgameMode(0);
            //// Scouter 2
            if (Robots[1].Current_Mode == RobotState.ROBOT_MODE.Auto) InAutoMode(1);  // Scouter 2
            else if (Robots[1].Current_Mode == RobotState.ROBOT_MODE.Teleop) InTeleopMode(1);
            else if (Robots[1].Current_Mode == RobotState.ROBOT_MODE.Endgame) InEndgameMode(1);

            ////    // Scouter 3
            if (Robots[2].Current_Mode == RobotState.ROBOT_MODE.Auto) InAutoMode(2);  // Scouter 3
            else if (Robots[2].Current_Mode == RobotState.ROBOT_MODE.Teleop) InTeleopMode(2);
            else if (Robots[2].Current_Mode == RobotState.ROBOT_MODE.Endgame) InEndgameMode(2);

            // Scouter 4
            if (Robots[3].Current_Mode == RobotState.ROBOT_MODE.Auto) InAutoMode(3);  // Scouter 4
            else if (Robots[3].Current_Mode == RobotState.ROBOT_MODE.Teleop) InTeleopMode(3);
            else if (Robots[3].Current_Mode == RobotState.ROBOT_MODE.Endgame) InEndgameMode(3);

            // Scouter 5
            if (Robots[4].Current_Mode == RobotState.ROBOT_MODE.Auto) InAutoMode(4);  // Scouter 5
            else if (Robots[4].Current_Mode == RobotState.ROBOT_MODE.Teleop) InTeleopMode(4);
            else if (Robots[4].Current_Mode == RobotState.ROBOT_MODE.Endgame) InEndgameMode(4);

            // Scouter 6
            if (Robots[5].Current_Mode == RobotState.ROBOT_MODE.Auto) InAutoMode(5);  // Scouter 6
            else if (Robots[5].Current_Mode == RobotState.ROBOT_MODE.Teleop) InTeleopMode(5);
            else if (Robots[5].Current_Mode == RobotState.ROBOT_MODE.Endgame) InEndgameMode(5);
        }

        private void AutoToNearMode(int Robot_Number)
        {
            Robots[Robot_Number].Desired_Mode = RobotState.ROBOT_MODE.Auto;
        }

        private void InAutoMode(int Controller_Number)
        {
            ////Scouter Name
            //if (Robots[Controller_Number].Alt)
            //{
            //    ((Label)this.Controls.Find("lbl" + Controller_Number + "ScoutName", true)[0]).Text = Robots[Controller_Number].getScouterNameALT(RobotState.SCOUTER_NAME_ALT.Select_AltName).ToString();
            //}
            //else
            //{
            ((Label)this.Controls.Find("lbl" + Controller_Number + "ScoutName", true)[0]).Text = Robots[Controller_Number].getScouterName(RobotState.SCOUTER_NAME.Select_Name).ToString();
            //}

            //Mode
            ((Label)this.Controls.Find("lbl" + Controller_Number + "ModeValue", true)[0]).Text = Robots[Controller_Number].Current_Mode.ToString() + " Mode";

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position0", true)[0]).Text = "Def:";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position0", true)[0]).Visible = false;
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position0Value", true)[0]).Text = "0";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position0Value", true)[0]).Visible = false;

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position1", true)[0]).Text = "Loc:";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position1", true)[0]).Visible = true;
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position1Value", true)[0]).Text = Robots[Controller_Number].SetLoc.ToString();
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position1Value", true)[0]).Visible = true;

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position2", true)[0]).Text = "Del:";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position2", true)[0]).Visible = true;
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position2Value", true)[0]).Text = Robots[Controller_Number].Piece.ToString();
            if (Robots[Controller_Number].Piece == RobotState.PIECE.Select && Robots[Controller_Number].DPiece == RobotState.PIECE.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position2Value", true)[0]).Visible = false;
            }
            else if (Robots[Controller_Number].Piece == RobotState.PIECE.Select && Robots[Controller_Number].DPiece != RobotState.PIECE.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position2Value", true)[0]).Text = Robots[Controller_Number].DPiece.ToString();
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position2Value", true)[0]).Visible = true;
            }

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3", true)[0]).Text = Robots[Controller_Number].Nodelbl.ToString();
            if (Robots[Controller_Number].Nodelbl != RobotState.NODELBL.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3", true)[0]).Visible = true;
            }
            else if (Robots[Controller_Number].Nodelbl == RobotState.NODELBL.Select && Robots[Controller_Number].DNodelbl != RobotState.NODELBL.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3", true)[0]).Text = Robots[Controller_Number].DNodelbl.ToString();
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3", true)[0]).Visible = true;
            }
            else if (Robots[Controller_Number].Nodelbl == RobotState.NODELBL.Select && Robots[Controller_Number].DNodelbl == RobotState.NODELBL.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3", true)[0]).Visible = false;
            }
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3AValue", true)[0]).Text = Robots[Controller_Number].DelGrid.ToString();
            if (Robots[Controller_Number].DelGrid == RobotState.DELGRID.Select && Robots[Controller_Number].DDelGrid == RobotState.DELGRID.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3AValue", true)[0]).Visible = false;
            }
            else if (Robots[Controller_Number].DelGrid == RobotState.DELGRID.Select && Robots[Controller_Number].DDelGrid != RobotState.DELGRID.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3AValue", true)[0]).Text = Robots[Controller_Number].DDelGrid.ToString();
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3AValue", true)[0]).Visible = true;
            }
            else if (Robots[Controller_Number].DelGrid != RobotState.DELGRID.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3AValue", true)[0]).Visible = true;
            }
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3BValue", true)[0]).Text = Robots[Controller_Number].DelRow.ToString();
            if (Robots[Controller_Number].DelRow == RobotState.DELROW.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3BValue", true)[0]).Visible = false;
            }
            else
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3BValue", true)[0]).Visible = true;
            }

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position5", true)[0]).Text = Robots[Controller_Number].Floorlbl.ToString();
            if (Robots[Controller_Number].Floorlbl != RobotState.FLOORLBL.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position5", true)[0]).Visible = true;
            }
            else if (Robots[Controller_Number].Floorlbl == RobotState.FLOORLBL.Select && Robots[Controller_Number].DFloorlbl != RobotState.FLOORLBL.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position5", true)[0]).Text = Robots[Controller_Number].DFloorlbl.ToString();
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position5", true)[0]).Visible = true;
            }
            else if (Robots[Controller_Number].Floorlbl == RobotState.FLOORLBL.Select && Robots[Controller_Number].DFloorlbl == RobotState.FLOORLBL.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position5", true)[0]).Visible = false;
            }
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position5Value", true)[0]).Text = Robots[Controller_Number].DelFloor.ToString();
            if (Robots[Controller_Number].DelFloor == RobotState.DELFLOOR.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position5Value", true)[0]).Visible = false;
            }
            else
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position5Value", true)[0]).Visible = true;
            }

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position6", true)[0]).Text = "Acq:";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position6", true)[0]).Visible = true;
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position6Value", true)[0]).Text = Robots[Controller_Number].Acq.ToString();
            if (Robots[Controller_Number].Acq == RobotState.ACQ.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position6Value", true)[0]).Visible = false;
            }
            else
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position6Value", true)[0]).Visible = true;
            }

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position7", true)[0]).Text = "Charge:";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position7", true)[0]).Visible = true;
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position7Value", true)[0]).Text = Robots[Controller_Number].ChargeStatus.ToString();
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position7Value", true)[0]).Visible = true;

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position8", true)[0]).Text = "Fail:";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position8", true)[0]).Visible = false;
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position8Value", true)[0]).Text = "Reason";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position8Value", true)[0]).Visible = false;

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position9", true)[0]).Text = "Mob:";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position9", true)[0]).Visible = true;
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position9Value", true)[0]).Text = Robots[Controller_Number].Mob.ToString();
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position9Value", true)[0]).Visible = true;

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position10", true)[0]).Text = "Teams:";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position10", true)[0]).Visible = false;
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position10Value", true)[0]).Text = "0";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position10Value", true)[0]).Visible = false;

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position11", true)[0]).Text = Robots[Controller_Number].match_event.ToString();
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position11", true)[0]).Visible = true;

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position12", true)[0]).Text = "Strategy";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position12", true)[0]).Visible = false;

        }

        private void InTeleopMode(int Controller_Number)
        {
            //Scouter Name
            //if (Robots[Controller_Number].Alt)
            //{
            //    ((Label)this.Controls.Find("lbl" + Controller_Number + "ScoutName", true)[0]).Text = Robots[Controller_Number].getScouterNameALT(RobotState.SCOUTER_NAME_ALT.Select_AltName).ToString();
            //}
            //else
            //{
            ((Label)this.Controls.Find("lbl" + Controller_Number + "ScoutName", true)[0]).Text = Robots[Controller_Number].getScouterName(RobotState.SCOUTER_NAME.Select_Name).ToString();
            //}
            ((Label)this.Controls.Find("lbl" + Controller_Number + "ModeValue", true)[0]).Text = Robots[Controller_Number].Current_Mode.ToString() + " Mode";

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position0", true)[0]).Text = "Def:";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position0", true)[0]).Visible = false;
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position0Value", true)[0]).Text = "0";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position0Value", true)[0]).Visible = false;

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position1", true)[0]).Text = "Avo:";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position1", true)[0]).Visible = false;
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position1Value", true)[0]).Text = "0";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position1Value", true)[0]).Visible = false;

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position2", true)[0]).Text = "Del:";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position2", true)[0]).Visible = true;
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position2Value", true)[0]).Text = Robots[Controller_Number].Piece.ToString();
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position2Value", true)[0]).Visible = true;
            if (Robots[Controller_Number].Piece == RobotState.PIECE.Select && Robots[Controller_Number].DPiece == RobotState.PIECE.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position2Value", true)[0]).Visible = false;
            }
            else if (Robots[Controller_Number].Piece == RobotState.PIECE.Select && Robots[Controller_Number].DPiece != RobotState.PIECE.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position2Value", true)[0]).Text = Robots[Controller_Number].DPiece.ToString();
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position2Value", true)[0]).Visible = true;
            }

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3", true)[0]).Text = Robots[Controller_Number].Nodelbl.ToString();
            if (Robots[Controller_Number].Nodelbl != RobotState.NODELBL.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3", true)[0]).Visible = true;
            }
            else if (Robots[Controller_Number].Nodelbl == RobotState.NODELBL.Select && Robots[Controller_Number].DNodelbl != RobotState.NODELBL.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3", true)[0]).Text = Robots[Controller_Number].DNodelbl.ToString();
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3", true)[0]).Visible = true;
            }
            else if (Robots[Controller_Number].Nodelbl == RobotState.NODELBL.Select && Robots[Controller_Number].DNodelbl == RobotState.NODELBL.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3", true)[0]).Visible = false;
            }
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3AValue", true)[0]).Text = Robots[Controller_Number].DelGrid.ToString();
            if (Robots[Controller_Number].DelGrid == RobotState.DELGRID.Select && Robots[Controller_Number].DDelGrid == RobotState.DELGRID.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3AValue", true)[0]).Visible = false;
            }
            else if (Robots[Controller_Number].DelGrid == RobotState.DELGRID.Select && Robots[Controller_Number].DDelGrid != RobotState.DELGRID.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3AValue", true)[0]).Text = Robots[Controller_Number].DDelGrid.ToString();
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3AValue", true)[0]).Visible = true;
            }
            else if (Robots[Controller_Number].DelGrid != RobotState.DELGRID.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3AValue", true)[0]).Visible = true;
            }
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3BValue", true)[0]).Text = Robots[Controller_Number].DelRow.ToString();
            if (Robots[Controller_Number].DelRow == RobotState.DELROW.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3BValue", true)[0]).Visible = false;
            }
            else
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3BValue", true)[0]).Visible = true;
            }

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position5", true)[0]).Text = Robots[Controller_Number].Floorlbl.ToString();
            if (Robots[Controller_Number].Floorlbl != RobotState.FLOORLBL.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position5", true)[0]).Visible = true;
            }
            else if (Robots[Controller_Number].Floorlbl == RobotState.FLOORLBL.Select && Robots[Controller_Number].DFloorlbl != RobotState.FLOORLBL.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position5", true)[0]).Text = Robots[Controller_Number].DFloorlbl.ToString();
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position5", true)[0]).Visible = true;
            }
            else if (Robots[Controller_Number].Floorlbl == RobotState.FLOORLBL.Select && Robots[Controller_Number].DFloorlbl == RobotState.FLOORLBL.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position5", true)[0]).Visible = false;
            }
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position5Value", true)[0]).Text = Robots[Controller_Number].DelFloor.ToString();
            if (Robots[Controller_Number].DelFloor == RobotState.DELFLOOR.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position5Value", true)[0]).Visible = false;
            }
            else
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position5Value", true)[0]).Visible = true;
            }

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position6", true)[0]).Text = "Acq:";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position6", true)[0]).Visible = true;
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position6Value", true)[0]).Text = Robots[Controller_Number].Acq.ToString();
            if (Robots[Controller_Number].Acq == RobotState.ACQ.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position6Value", true)[0]).Visible = false;
            }
            else
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position6Value", true)[0]).Visible = true;
            }

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position7", true)[0]).Text = "Charge:";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position7", true)[0]).Visible = false;
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position7Value", true)[0]).Text = "DNA";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position7Value", true)[0]).Visible = false;

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position8", true)[0]).Text = "Fail:";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position8", true)[0]).Visible = false;
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position8Value", true)[0]).Text = "Reason";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position8Value", true)[0]).Visible = false;

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position9", true)[0]).Text = "Time:";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position9", true)[0]).Visible = false;
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position9Value", true)[0]).Text = "0:00.00";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position9Value", true)[0]).Visible = false;

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position10", true)[0]).Text = "Teams:";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position10", true)[0]).Visible = false;
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position10Value", true)[0]).Text = "0";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position10Value", true)[0]).Visible = false;

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position11", true)[0]).Text = Robots[Controller_Number].match_event.ToString();
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position11", true)[0]).Visible = true;

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position12", true)[0]).Text = "Strategy";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position12", true)[0]).Visible = false;
        }

        private void InEndgameMode(int Controller_Number)
        {
            //Scouter Name
            //if (Robots[Controller_Number].Alt)
            //{
            //    ((Label)this.Controls.Find("lbl" + Controller_Number + "ScoutName", true)[0]).Text = Robots[Controller_Number].getScouterNameALT(RobotState.SCOUTER_NAME_ALT.Select_AltName).ToString();
            //}
            //else
            //{
            ((Label)this.Controls.Find("lbl" + Controller_Number + "ScoutName", true)[0]).Text = Robots[Controller_Number].getScouterName(RobotState.SCOUTER_NAME.Select_Name).ToString();
            //}

        //Mode
        ((Label)this.Controls.Find("lbl" + Controller_Number + "ModeValue", true)[0]).Text = Robots[Controller_Number].Current_Mode.ToString() + " Mode";

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position0", true)[0]).Text = "Def:";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position0", true)[0]).Visible = true;
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position0Value", true)[0]).Text = Robots[Controller_Number].DefRate.ToString();
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position0Value", true)[0]).Visible = true;

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position1", true)[0]).Text = "Avo:";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position1", true)[0]).Visible = true;
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position1Value", true)[0]).Text = Robots[Controller_Number].AvoRate.ToString();
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position1Value", true)[0]).Visible = true;

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position2", true)[0]).Text = "Del:";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position2", true)[0]).Visible = true;
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position2Value", true)[0]).Text = Robots[Controller_Number].Piece.ToString();
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position2Value", true)[0]).Visible = true;
            if (Robots[Controller_Number].Piece == RobotState.PIECE.Select && Robots[Controller_Number].DPiece == RobotState.PIECE.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position2Value", true)[0]).Visible = false;
            }
            else if (Robots[Controller_Number].Piece == RobotState.PIECE.Select && Robots[Controller_Number].DPiece != RobotState.PIECE.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position2Value", true)[0]).Text = Robots[Controller_Number].DPiece.ToString();
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position2Value", true)[0]).Visible = true;
            }

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3", true)[0]).Text = Robots[Controller_Number].Nodelbl.ToString();
            if (Robots[Controller_Number].Nodelbl != RobotState.NODELBL.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3", true)[0]).Visible = true;
            }
            else if (Robots[Controller_Number].Nodelbl == RobotState.NODELBL.Select && Robots[Controller_Number].DNodelbl != RobotState.NODELBL.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3", true)[0]).Text = Robots[Controller_Number].DNodelbl.ToString();
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3", true)[0]).Visible = true;
            }
            else if (Robots[Controller_Number].Nodelbl == RobotState.NODELBL.Select && Robots[Controller_Number].DNodelbl == RobotState.NODELBL.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3", true)[0]).Visible = false;
            }
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3AValue", true)[0]).Text = Robots[Controller_Number].DelGrid.ToString();
            if (Robots[Controller_Number].DelGrid == RobotState.DELGRID.Select && Robots[Controller_Number].DDelGrid == RobotState.DELGRID.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3AValue", true)[0]).Visible = false;
            }
            else if (Robots[Controller_Number].DelGrid == RobotState.DELGRID.Select && Robots[Controller_Number].DDelGrid != RobotState.DELGRID.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3AValue", true)[0]).Text = Robots[Controller_Number].DDelGrid.ToString();
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3AValue", true)[0]).Visible = true;
            }
            else if (Robots[Controller_Number].DelGrid != RobotState.DELGRID.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3AValue", true)[0]).Visible = true;
            }
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3BValue", true)[0]).Text = Robots[Controller_Number].DelRow.ToString();
            if (Robots[Controller_Number].DelRow == RobotState.DELROW.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3BValue", true)[0]).Visible = false;
            }
            else
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position3BValue", true)[0]).Visible = true;
            }

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position5", true)[0]).Text = Robots[Controller_Number].Floorlbl.ToString();
            if (Robots[Controller_Number].Floorlbl != RobotState.FLOORLBL.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position5", true)[0]).Visible = true;
            }
            else if (Robots[Controller_Number].Floorlbl == RobotState.FLOORLBL.Select && Robots[Controller_Number].DFloorlbl != RobotState.FLOORLBL.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position5", true)[0]).Text = Robots[Controller_Number].DFloorlbl.ToString();
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position5", true)[0]).Visible = true;
            }
            else if (Robots[Controller_Number].Floorlbl == RobotState.FLOORLBL.Select && Robots[Controller_Number].DFloorlbl == RobotState.FLOORLBL.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position5", true)[0]).Visible = false;
            }
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position5Value", true)[0]).Text = Robots[Controller_Number].DelFloor.ToString();
            if (Robots[Controller_Number].DelFloor == RobotState.DELFLOOR.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position5Value", true)[0]).Visible = false;
            }
            else
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position5Value", true)[0]).Visible = true;
            }

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position6", true)[0]).Text = "Acq:";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position6", true)[0]).Visible = true;
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position6Value", true)[0]).Text = Robots[Controller_Number].Acq.ToString();
            if (Robots[Controller_Number].Acq == RobotState.ACQ.Select)
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position6Value", true)[0]).Visible = false;
            }
            else
            {
                ((Label)this.Controls.Find("lbl" + Controller_Number + "Position6Value", true)[0]).Visible = true;
            }

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position7", true)[0]).Text = "Charge:";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position7", true)[0]).Visible = true;
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position7Value", true)[0]).Text = Robots[Controller_Number].ChargeStatus.ToString();
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position7Value", true)[0]).Visible = true;

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position8", true)[0]).Text = "Fail:";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position8", true)[0]).Visible = true;
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position8Value", true)[0]).Text = Robots[Controller_Number].EngageFail.ToString();
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position8Value", true)[0]).Visible = true;

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position9", true)[0]).Text = "Time:";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position9", true)[0]).Visible = true;
            Robots[Controller_Number].EngageTimeDouble = Robots[Controller_Number].EngageTime_StopWatch.Elapsed.TotalSeconds;
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position9Value", true)[0]).Text = Robots[Controller_Number].EngageTimeDouble.ToString("0.#");
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position9Value", true)[0]).Visible = true;

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position10", true)[0]).Text = "Teams:";
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position10", true)[0]).Visible = true;
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position10Value", true)[0]).Text = Robots[Controller_Number].CSTeams.ToString();
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position10Value", true)[0]).Visible = true;

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position11", true)[0]).Text = Robots[Controller_Number].match_event.ToString();
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position11", true)[0]).Visible = true;

            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position12", true)[0]).Text = Robots[Controller_Number].Strategy.ToString();
            ((Label)this.Controls.Find("lbl" + Controller_Number + "Position12", true)[0]).Visible = true;
        }
    }
}
