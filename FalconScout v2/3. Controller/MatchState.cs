using System;
using System.Diagnostics;

namespace FalconScout_v2017
{
    // MatchState is just the state of the match for one of the controllers/robots/Scouters.  
    // Matchstate tracks every item of importance for one of the robots.

    public class MatchState
    {
        // These are our own defined types...
        public enum TRAITS { None, TippedOver, BrokeDown, YellowCard, RedCard };
        public enum TEAM_ENUM { };
        public enum ROBOT_MODE { Auto, TeleOp, Defense };
        public enum SCOUTER_NAME { Select_Name, Andrew, Christian, Collin, Dan, DeMarco, Jake, Jon, Luke, Parker, Peyton, Phoenix, RJ, Stephen, Sub, Vaishu, Verdi, Yuven};
        public enum CLIMBSTATUS { S, F, N };
        public enum MATCHEVENT_NAME { None, Fell_Over, Hopper_Dump, Drop_Rope }
        public enum CYCLE_DIRECTION { Up, Down }
        public enum DEFENSES { None, Reached, Got_Stuck, Crossing, Crossed }
        public enum STARTLOCATION { Not_Used }
        public enum Baseline { No, Yes}

        // These are the standard types...
        public string YEAR = "2017";
        public string InKey = "No";
        public ROBOT_MODE Current_Mode;         //Current Mode
        public int Current_Match;   //Current Match
        public int acquire_ground = 0;
        public int acquire_hopper = 0;
        public int acquire_driver = 0;
        public int AcquiredReloadStation = 0;
        public string ClimbStatus = "N";
        public string color;
        public SCOUTER_NAME ScouterName;

        public TimeSpan Time1, Time2, Time3, Time4, Time5;
        public int timer_running = 0;
        public string defensecrossingname;
        public TimeSpan defensecrossingtime;
        public int Zero = 0;

        // Define the timers
        public TimeSpan climbingtime = TimeSpan.Zero;
        public TimeSpan defensetime = TimeSpan.Zero;

        // Define the climbing stopwatch
        public Stopwatch climbing_stopwatch;
        public bool climbing_stopwatch_running;

        // Define the defense stopwatch
        public Stopwatch defense_stopwatch;
        public bool defense_stopwatch_running;

        //LOCAL VARIABLES SECTION.  All underscored variables indicate local variables for one controller/scouter

        private SCOUTER_NAME _ScouterName;      //ScouterName
        private CLIMBSTATUS _Climbstatus;       // Climb status
        private string _TeamName;               //TeamName
        private MATCHEVENT_NAME _match_event;//Match Event
        private ROBOT_MODE _RobotMode;          //Control
        private DEFENSES _Defenses;
        private STARTLOCATION _StartLocation;
        
        private Baseline _Baseline;

        private TRAITS _Traits; //traits
        private int _fuel_high_out_key; //High goal field
        private int _fuel_low_out_key;  //Low goal field
        private int _fuel_high_in_key;
        private int _fuel_low_in_key;

        private int _MissedHighGoals;
        private int _MissedLowGoals;
        private int _dump_hopper;
        private int _gears_delivered;
        private int _FuelPickup;

        //public int Traits
        //{
        //    get { return _Traits; }
        //    set { _Traits = value; }
        //}

        public int fuel_high_out_key
        {
            get {return _fuel_high_out_key;}
            set {_fuel_high_out_key = value;}
        }
        

        public int fuel_high_in_key
        {
            get { return _fuel_high_in_key; }
            set { _fuel_high_in_key = value; }
        }

        public int fuel_low_in_key
        {
            get { return _fuel_low_in_key; }
            set { _fuel_low_in_key = value; }
        }
        //Zero
        //public int Zero
        //{
        //    get { return _Zero; }
        //    set { _Zero = value; }
        //}

        ///<summary>
        ///The zone game piees were primarily acquired in
        ///</summary>    //edited Clyde 2015
        /* public EndGame _Zone
         {
             get
             { return _Zone; }
             set
             { _Zone = value; }
         }
      */

        ///<summary>
        ///Robot Activity Mode
        ///</summary>
        public ROBOT_MODE RobotMode
        {
            get { return _RobotMode; }
            set { _RobotMode = value; }
        }
        public CLIMBSTATUS Climbstatus
        {
            get { return _Climbstatus; }
            set { _Climbstatus = value; }
        }

        //public COLOR color
        //{
        //    get { return _color; }
        //    set { _color = value; }
        //}
        
        public String TeamName
        {
            get { return _TeamName; }
            set { _TeamName = value; }
        }
        public MATCHEVENT_NAME match_event
        {
            get { return _match_event; }
            set { _match_event = value; }
        }

        public int HighGoal
        {
            get { return _fuel_high_out_key; }
            set { _fuel_high_out_key = value; }
        }

        public int LowGoal
        {
            get { return _fuel_low_out_key; }
            set { _fuel_low_out_key = value; }
        }

        public int MissedHighGoals
        {
            get { return _MissedHighGoals; }
            set { _MissedHighGoals = value; }
        }

        public int MissedLowGoals
        {
            get { return _MissedLowGoals; }
            set { _MissedLowGoals = value; }
        }

        public int getLowGoal
        {
            get { return _fuel_low_out_key; }
            set { _fuel_low_out_key = value; }
        }
        public int FuelPickup
        {
            get { return _FuelPickup; }
            set {  _FuelPickup = value; }
        }

        public int fuel_low_out_key
        {
            get { return _fuel_low_out_key; }
            set { _fuel_low_out_key = value; }
        }

     

        public int dump_hopper
        {
            get { return _dump_hopper; }
            set { _dump_hopper = value; }
        }

        public int gears_delivered
        {
            get { return _gears_delivered; }
            set { _gears_delivered = value; }
        }

        //public int getFouls() { return _Fouls; }
        public STARTLOCATION getStartLocation() {return _StartLocation; }
        public Baseline getBaseline() { return _Baseline; }
        public TRAITS getTraits() { return _Traits; }
        public DEFENSES getDefenses() { return _Defenses; }
        public void setDefense(DEFENSES Defenses) { _Defenses = Defenses; }
        public void setTraits(TRAITS Traits) { _Traits = Traits; }

        public int getfuel_high_out_key()
        { return _fuel_high_out_key; }
        
        public int getfuel_low_out_key()
        { return _fuel_low_out_key; }

        //MissedHighGoals
        public int getMissedHighGoal()
        { return _MissedHighGoals; }

        public int getMissedLowGoal()
        { return _MissedLowGoals; }

        //Hit Hoppers
        public int getdump_hopper()
        { return _dump_hopper; }

        ///Scouter Name
        public SCOUTER_NAME getScouterName(SCOUTER_NAME ScouterName)
        { return ScouterName = _ScouterName; }

        ///Climb status
        public CLIMBSTATUS getClimbstatus(CLIMBSTATUS Climbstatus)
        { return Climbstatus = _Climbstatus; }


        //public COLOR getColor(COLOR Color)
        //{ return Color = _color; }

        ///Team Name
        //   public TEAM_NAME getTeamName(TEAM_NAME TeamName)
        //   { return TeamName = _TeamName; }

        ///Match Event
        ///</summary>
        //public MATCHEVENT_NAME getmatch_event(MATCHEVENT_NAME match_event)
        //{ return match_event = _match_event; }

        ///Reurns the integer value the enum of the provided
        private int getEnumIntValue(object inputEnum)
        {
            return (int)inputEnum;
        }
        
        ///<summary>
        ///Resets all values to the default
        ///</summary>

        //Scouter Name
        public void changeScouterName(CYCLE_DIRECTION CycleDirection)
        {
            if (CycleDirection == CYCLE_DIRECTION.Up)
                _ScouterName = 
                    (SCOUTER_NAME)GetNextEnum<SCOUTER_NAME>(_ScouterName);
            else
            {
                _ScouterName =
                (SCOUTER_NAME)GetPreviousEnum<SCOUTER_NAME>(_ScouterName);
            }
        }

        //Climb status
        public void changeClimbstatus (CYCLE_DIRECTION CycleDirection)
        {
            if (CycleDirection == CYCLE_DIRECTION.Up)
                _Climbstatus =
                    (CLIMBSTATUS)GetNextEnum<CLIMBSTATUS>(_Climbstatus);
            else
            {
                _Climbstatus =
                (CLIMBSTATUS)GetPreviousEnum<CLIMBSTATUS>(_Climbstatus);
            }
        }

        ////Color
        //public void changeColor(CYCLE_DIRECTION CycleDirection)
        //{
        //    if (CycleDirection == CYCLE_DIRECTION.Up)
        //        _color =
        //            (COLOR)GetNextEnum<COLOR>(_color);
        //    else
        //    {
        //        _color =
        //        (COLOR)GetPreviousEnum<COLOR>(_color);
        //    }
        //}
        //Cycle Event Name
        public void cycleEventName(CYCLE_DIRECTION CycleDirection)
        {
            if (CycleDirection == CYCLE_DIRECTION.Up)
                _match_event =
                    (MATCHEVENT_NAME)GetNextEnum<MATCHEVENT_NAME>(_match_event);
            else
            {
                _match_event =
                (MATCHEVENT_NAME)GetPreviousEnum<MATCHEVENT_NAME>(_match_event);
            }
        }

        public void changeTraits(CYCLE_DIRECTION CycleDirection)
        {
            if (CycleDirection == CYCLE_DIRECTION.Up)
                _Traits = (TRAITS)GetNextEnum<TRAITS>(_Traits);

            else {
                _Traits = (TRAITS)GetPreviousEnum<TRAITS>(_Traits);
            }
        }
        
        public void changeStartLocation(CYCLE_DIRECTION CycleDirection)
        {
            if (CycleDirection == CYCLE_DIRECTION.Up)
                _StartLocation = (STARTLOCATION)GetNextEnum<STARTLOCATION>(_StartLocation);

            else {
                _StartLocation = (STARTLOCATION)GetPreviousEnum<STARTLOCATION>(_StartLocation);
            }
        }
        
        public void changeBaseline(CYCLE_DIRECTION CycleDirection)
        {
            if(CycleDirection == CYCLE_DIRECTION.Up)
            {
                _Baseline = (Baseline)GetNextEnum<Baseline>(_Baseline);
            }


        }

        public void changeKeyLocation(CYCLE_DIRECTION CycleDirection) { }
        
        private Enum GetNextEnum<t>(object currentlySelectedEnum)
        {
            Type enumList = typeof(t);
            if (!enumList.IsEnum)
                throw new InvalidOperationException("Object is not an Enum.");

            Array enums = Enum.GetValues(enumList);
            int index = Array.IndexOf(enums, currentlySelectedEnum);
            index = (index + 1) % enums.Length;
            return (Enum)enums.GetValue(index);
        }

        private Enum GetPreviousEnum<t>(object currentlySelectedEnum)
        {
            Type enumList = typeof(t);
            if (!enumList.IsEnum) 
                throw new InvalidOperationException("Object is not an Enum.");

            Array enums = Enum.GetValues(enumList);
            int index = Array.IndexOf(enums, currentlySelectedEnum);
            index = (((index == 0) ? enums.Length : index) - 1);
            return (Enum)enums.GetValue(index);
        }
    }
} 
