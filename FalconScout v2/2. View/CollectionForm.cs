using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SlimDX.DirectInput;
using System.IO;
using System.Net;

namespace FalconScout_v2017
{
    public partial class MainScreen : Form
    {
        //Definitions for Xbox Controllers
        DirectInput Input = new DirectInput();
        GamePad[] gamePads;
        
        MatchState[] matchStates = new MatchState[6];           //Contains the state of each Scout's match tracking
        Controllers controllers = new Controllers();            //Array of six Xbox controllers 
        Utilities utilities = new Utilities();                  //Instantiate the Utilities class

        //Lists for storing regional/qualifying events, teams attending and matches between teams       
        List<string> teamlist = new List<string>();             //The list of teams for the event selected
        List<KeyValuePair<string, string>> elist = new List<KeyValuePair<string, string>>();   //Contains the list of event codes and names
        public List<Match> InMemoryMatchList = new List<Match>();      //The list of all the matches at the selected event.
        List<Match> UnSortedMatchList = new List<Match>();      //This is just the list of all matches, not yet sorted
  
        Activity activity_record = new Activity();              //This is the activity for one Acquire or one Scoring mode.  We also save when an Event Activity is selected.       
        SeasonContext seasonframework = new SeasonContext();    //This is the context, meaning the entire database structure supporting this application.
        
        public string eventcode;                                       //The event code of the selected event
        int currentmatch = 0;                                   //The match number currently selected and being tracked

        IEnumerable<MatchState.TEAM_ENUM> items;

        //Name: MainScreen()
        //Purpose: Initialize the actual form with the six tracking boxes
        public MainScreen()
        {
            //Thread t = new Thread(new ThreadStart(SplashStart));
            //t.Start();
            //Thread.Sleep(50);
           
            InitializeComponent();
            //t.Abort();

            //Initializing Controllers found

            // TO USE THE PROGRAM FOR PIT SCOUTING, SIMPLY COMMENT OUT THESE THREE LINES.  THEN A CONTROLLER WON"T BE NEEDED.
            // ALSO - DON"T LOAD THE TEAMS - JUST TYPE IN THE TEAM NAME (for example "250") and press GET DATA.  You can type in any team name you need to get or store data. 
            controllers.getGamePads();
            gamePads = controllers.getGamePads();
            timerJoysticks.Enabled = true;
        }
        public void SplashStart()
        {
            Application.Run(new SplashScreenForm());
        }

        //Name: Log()
        //Purpose: This is the log method we use to write activity to the debugging log field on the screen (makes it much easier to know what's going on!)
        public void Log(string m)
        {
            //cross-thread Logging
            Func<int> del = delegate()
            {
                lstLog.TopIndex = lstLog.Items.Add(m + System.Environment.NewLine);
                return 0;
            };
            Invoke(del);
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void btnInitialDBLoad_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to reload the Blue Alliance data?", "Please Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                BuildInitialDatabase();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

            //Log("SQL start time is " + DateTime.Now.TimeOfDay);
        }

        private void btnNextMatch_Click(object sender, EventArgs e)
        {
            if (currentmatch == InMemoryMatchList.Count) 
                MessageBox.Show("You are at the last match.");
            else
            {
              currentmatch++;
              
              this.lbl0TeamName.Text = matchStates[0].TeamName = InMemoryMatchList[currentmatch].redteam1;
              //this.lbl1TeamName.Text = matchStates[1].TeamName = InMemoryMatchList[currentmatch].redteam2;
              //this.lbl2TeamName.Text = matchStates[2].TeamName = InMemoryMatchList[currentmatch].redteam3;
              //this.lbl3TeamName.Text = matchStates[3].TeamName = InMemoryMatchList[currentmatch].blueteam1;
              //this.lbl4TeamName.Text = matchStates[4].TeamName = InMemoryMatchList[currentmatch].blueteam2;
              //this.lbl5TeamName.Text = matchStates[5].TeamName = InMemoryMatchList[currentmatch].blueteam3;
              this.lblMatch.Text = (currentmatch + 1).ToString();
              this.lblkey.Text = InMemoryMatchList[currentmatch].key;

              matchStates[0].Current_Mode = matchStates[1].Current_Mode = matchStates[2].Current_Mode = matchStates[3].Current_Mode = matchStates[4].Current_Mode = matchStates[5].Current_Mode = MatchState.ROBOT_MODE.Auto;
              matchStates[0].RobotMode = matchStates[1].RobotMode = matchStates[2].RobotMode = matchStates[3].RobotMode = matchStates[4].RobotMode = matchStates[5].RobotMode = MatchState.ROBOT_MODE.Auto;

              matchStates[0].fuel_low_out_key = matchStates[1].fuel_low_out_key = matchStates[2].fuel_low_out_key = matchStates[3].fuel_low_out_key = matchStates[4].fuel_low_out_key = matchStates[5].fuel_low_out_key = 0;
              matchStates[0].fuel_high_out_key = matchStates[1].fuel_high_out_key = matchStates[2].fuel_high_out_key = matchStates[3].fuel_high_out_key = matchStates[4].fuel_high_out_key = matchStates[5].fuel_high_out_key = 0;
              matchStates[0].fuel_low_out_key = matchStates[1].fuel_low_out_key = matchStates[2].fuel_low_out_key = matchStates[3].fuel_low_out_key = matchStates[4].fuel_low_out_key = matchStates[5].fuel_low_out_key = 0;

              DialogResult dialogResult = MessageBox.Show("Do you want to use the same field configuration as the last match?", "Please Confirm", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    InMemoryMatchList[matchStates[0].Current_Match].bluedefense2 = InMemoryMatchList[matchStates[0].Current_Match-1].bluedefense2;
                    InMemoryMatchList[matchStates[0].Current_Match].bluedefense3 = InMemoryMatchList[matchStates[0].Current_Match-1].bluedefense3;
                    InMemoryMatchList[matchStates[0].Current_Match].bluedefense4 = InMemoryMatchList[matchStates[0].Current_Match-1].bluedefense4;
                    InMemoryMatchList[matchStates[0].Current_Match].bluedefense5 = InMemoryMatchList[matchStates[0].Current_Match-1].bluedefense5;

                    InMemoryMatchList[matchStates[0].Current_Match].reddefense2 = InMemoryMatchList[matchStates[0].Current_Match-1].reddefense2;
                    InMemoryMatchList[matchStates[0].Current_Match].reddefense3 = InMemoryMatchList[matchStates[0].Current_Match-1].reddefense3;
                    InMemoryMatchList[matchStates[0].Current_Match].reddefense4 = InMemoryMatchList[matchStates[0].Current_Match-1].reddefense4;
                    InMemoryMatchList[matchStates[0].Current_Match].reddefense5 = InMemoryMatchList[matchStates[0].Current_Match-1].reddefense5;
                }
                else if (dialogResult == DialogResult.No)
                {
                    MatchSettingsForm frm = new MatchSettingsForm(this, InMemoryMatchList);
                    frm.Show();
                }
            }
        }

        private void btnPreviousMatch_Click(object sender, EventArgs e)
        {
            if (currentmatch == 0)
                MessageBox.Show("You are at the first match.");
            else {
            currentmatch--;
             this.lbl0TeamName.Text = matchStates[0].TeamName = InMemoryMatchList[currentmatch].blueteam1;
             //this.lbl1TeamName.Text = matchStates[1].TeamName = InMemoryMatchList[currentmatch].blueteam2;
             //this.lbl2TeamName.Text = matchStates[2].TeamName = InMemoryMatchList[currentmatch].blueteam3;
             //this.lbl3TeamName.Text = matchStates[3].TeamName = InMemoryMatchList[currentmatch].redteam1;
             //this.lbl4TeamName.Text = matchStates[4].TeamName = InMemoryMatchList[currentmatch].redteam2;
             //this.lbl5TeamName.Text = matchStates[5].TeamName = InMemoryMatchList[currentmatch].redteam3;
             this.lblMatch.Text = (currentmatch + 1).ToString();
            }
        }

        private void btnpopulateForEvent_Click(object sender, EventArgs e)
        {

          if (this.comboBoxSelectRegional.Text == "Please press the Load Events Button...") MessageBox.Show("You must load an event first.", "Not Ready to Get Matches");
            else
            { 
                List<Match> JSONmatches;

                System.Net.WebRequest req;

                //First get the teams from the Blue Alliance API
                Log("Opening Web Connection...");

                WebClient client = new WebClient(); //one WebClient to rule them all

                Log("Event -> " + comboBoxSelectRegional.SelectedItem);

                eventcode = comboBoxSelectRegional.SelectedItem.ToString();
                eventcode = eventcode.TrimStart('[');
                int index = eventcode.IndexOf(",");
                if (index > 0) eventcode = eventcode.Substring(0, index);

                Log("Event Code -> " + eventcode);

                //eventcode = "njfla";

                string uri =   "http://www.thebluealliance.com/api/v2/event/2016" + eventcode + "/teams?X-TBA-App-Id=frc250:FalconScout_v2017:v01";

                req = WebRequest.Create(uri);

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                Stream dataStream = response.GetResponseStream();
                //Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                //Read the content. 
                string responseFromServer = reader.ReadToEnd();
                //Display the content.
                Log("Response from Server -> " + responseFromServer);
                //Cleanup the streams and the response.

                List<TeamSummary> JSONteams = (List<TeamSummary>)Newtonsoft.Json.JsonConvert.DeserializeObject(responseFromServer, typeof(List<TeamSummary>));

                Log("Received " + JSONteams.Count + " teams for " + eventcode + ".");

                reader.Close();
                dataStream.Close();
                response.Close();

                //SeasonContext seasonframework = new SeasonContext();

                var teamquery = from b in seasonframework.Teamset
                                orderby b.name
                                select b;
                teamlist.Clear();

                foreach (var item in JSONteams)
                {
                    //Log("Team -> " + item.team_number);
                    teamlist.Add(item.team_number);
                }

                items = teamlist.Select(a => (MatchState.TEAM_ENUM)Enum.Parse(typeof(MatchState.TEAM_ENUM), a));
                //Need to update UI team field now that we have the teams!

                //Get the matches from the Blue Alliance API
                uri = "http://www.thebluealliance.com/api/v2/event/2016" + eventcode + "/matches?X-TBA-App-Id=frc250:FalconScout_v2017:v01";

                try
                {
                    req = WebRequest.Create(uri);
                    response = (HttpWebResponse)req.GetResponse();

                    using (var resp = req.GetResponse())
                    {
                        using (var responseStream = response.GetResponseStream())
                        {
                            dataStream = response.GetResponseStream();
                            //Open the stream using a StreamReader for easy access.
                            reader = new StreamReader(dataStream);

                            //Read the content. 
                            responseFromServer = reader.ReadToEnd();

                            //Display the content.
                            //Log("Response from Server -> " + responseFromServer);
                            //Cleanup the streams and the response.

                            //Get root objects

                            JSONmatches = (List<Match>)Newtonsoft.Json.JsonConvert.DeserializeObject(responseFromServer, typeof(List<Match>));

                            if (JSONmatches.Count == 0)
                            {
                                MessageBox.Show("Sorry, but there is no match data currently available for the event you selected.");
                            }
                            else
                            {
                                Log("Received " + JSONmatches.Count + " matches for " + eventcode + ".");

                                //Fill the Matches Table

                                JSONmatches = (List<Match>)Newtonsoft.Json.JsonConvert.DeserializeObject(responseFromServer, typeof(List<Match>));

                                dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject(responseFromServer);

                                Log("Saving " + JSONmatches.Count + " matches to database.");

                                for (int i = 0; i < JSONmatches.Count; i++)
                                {

                                    if (obj[i].comp_level == "qm")
                                    {

                                        Match match_record = new Match();

                                        dynamic alliances = obj[i].alliances;
                                        dynamic bluealliance = alliances.blue;
                                        dynamic redalliance = alliances.red;
                                        dynamic blueteamsobj = bluealliance.teams;
                                        dynamic redteamsobj = redalliance.teams;

                                        //Record List of matches
                                        match_record.match_number = (int)obj[i].match_number;
                                        match_record.set_number = obj[i].set_number;
                                        match_record.key = obj[i].key;
                                        match_record.comp_level = obj[i].comp_level;
                                        match_record.event_key = obj[i].event_key;
                                        match_record.blueteam1 = blueteamsobj[0];
                                        match_record.blueteam2 = blueteamsobj[1];
                                        match_record.blueteam3 = blueteamsobj[2];
                                        match_record.redteam1 = redteamsobj[0];
                                        match_record.redteam2 = redteamsobj[1];
                                        match_record.redteam3 = redteamsobj[2];

                                   
                                        UnSortedMatchList.Add(match_record);
                                        seasonframework.Matchset.Add(match_record);
                                        seasonframework.SaveChanges();
                                    }
                                }

                                //try
                                //{
                                //    seasonframework.Database.Connection.Open();

                                //    if (seasonframework.Database.Connection.State == ConnectionState.Open)
                                //    {

                                //        seasonframework.Matchset.AddRange(JSONmatches);
                                //        seasonframework.Teamset.AddRange(JSONteams);

                                //        string key = JSONmatches.First().key.ToString();
                                //        int ind = key.IndexOf("_");
                                //        if (ind > 0)
                                //            key = key.Substring(ind + 1, key.Length - (ind + 1));

                                //        this.lblMatch.Text = (currentmatch + 1).ToString();

                                //        seasonframework.SaveChanges();
                                //    }
                                //}
                                //catch (Exception ex)
                                //{
                                //    Log("Connection Failed!" + ex.ToString());
                                //}

                                //Populate screen with first match

                                InMemoryMatchList = UnSortedMatchList.OrderBy(o => o.match_number).ToList();

                                this.lbl0TeamName.Text = matchStates[0].TeamName = InMemoryMatchList[currentmatch].redteam1;
                                //this.lbl1TeamName.Text = matchStates[1].TeamName = InMemoryMatchList[currentmatch].redteam2;
                                //this.lbl2TeamName.Text = matchStates[2].TeamName = InMemoryMatchList[currentmatch].redteam3;
                                //this.lbl3TeamName.Text = matchStates[3].TeamName = InMemoryMatchList[currentmatch].blueteam1;
                                //this.lbl4TeamName.Text = matchStates[4].TeamName = InMemoryMatchList[currentmatch].blueteam2;
                                //this.lbl5TeamName.Text = matchStates[5].TeamName = InMemoryMatchList[currentmatch].blueteam3;
                                matchStates[0].color = "Blue";
                                matchStates[1].color = "Blue";
                                matchStates[2].color = "Blue";
                                matchStates[3].color = "Red";
                                matchStates[4].color = "Red";
                                matchStates[5].color = "Red";
                                this.lblMatch.Text = "1";
                                this.lblkey.Text = InMemoryMatchList[currentmatch].key;

                                //seasonframework.Database.Connection.Close();
                            }

                            reader.Close();
                            dataStream.Close();
                            response.Close();
                        }
                    }
                }
                catch (WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ProtocolError &&
                        ex.Response != null)
                    {

                        var resp = (HttpWebResponse)ex.Response;
                        if ((resp.StatusCode == HttpStatusCode.NotFound))
                        {
                            MessageBox.Show("Sorry, but there is no match data currently available for the event you selected.");
                        }
                        else
                        {
                            MessageBox.Show("Sorry, something went very wrong!");
                        }
                    }

                }

               
            }
}

        private void comboBoxSelectRegional_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void falconScoutingSystemForm_Load(object sender, EventArgs e)
        {

        }

        private void lstLog_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnStartMatch_Click(object sender, EventArgs e)
        {
            // Need to check that everything is in order so the match can start.
            //if (this.lbl0SelectColor.Text == "Select Color" | this.lbl1SelectColor.Text == "Select Color" | this.lbl2SelectColor.Text == "Select Color" | this.lbl3SelectColor.Text == "Select Color" | this.lbl4SelectColor.Text == "Select Color" | this.lbl5SelectColor.Text == "Select Color")
            //    MessageBox.Show("Cannot Start Match!  Please ensure everyone selects their color.");
            //else if (this.lbl0ScoutName.Text == "Select Name" | this.lbl0ScoutName.Text == "Select Name" | this.lbl0ScoutName.Text == "Select Name" | this.lbl0ScoutName.Text == "Select Name" | this.lbl0ScoutName.Text == "Select Name" | this.lbl0ScoutName.Text == "Select Name")
            //    MessageBox.Show("Cannot Start Match!  Please ensure everyone selects their name.");
            //else {
                if (this.lblMatch.Text == "") MessageBox.Show("No matches have been loaded.  Please load matches first and then you can setup the field.", "Not Ready to Setup Field");
                else {
                    MatchSettingsForm frm = new MatchSettingsForm(this, InMemoryMatchList);
                    frm.Show();
               }
            // }
        }

        private void buttonStartEvent_Click(object sender, EventArgs e)
        {
            StartEventForm frm = new StartEventForm();
            frm.Show();
        }
        private void btnPitScouting_Click(object sender, EventArgs e)
        {

            PitScoutingForm frm = new PitScoutingForm(teamlist);
            frm.Show();
        }
        private void btnTimer_Click(object sender, EventArgs e)
        {

            TimerForm frm = new TimerForm();
            frm.Show();

         
        }

        private void lbl1TeamName_Click(object sender, EventArgs e)
        {

        }

        private void lbl1TotesValue_Click(object sender, EventArgs e)
        {

        }

        private void lbl1HeightValue_Click(object sender, EventArgs e)
        {

        }

        private void lbl1LitterValue_Click(object sender, EventArgs e)
        {

        }

        private void lbl1CoOp_or_YellowTotesValue_Click(object sender, EventArgs e)
        {

        }

        private void lbl1Zone_Click(object sender, EventArgs e)
        {

        }

        private void lbl1ModeValue_Click(object sender, EventArgs e)
        {

        }

        private void lbl3Litter_Click(object sender, EventArgs e)
        {

        }

        private void lbl1LowBarValue_Click(object sender, EventArgs e)
        {
           // lbl0LowBarValue.Text = matchStates[0].Time1;
        }

        private void lbl1Fouls_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void lbl0Position1_Click(object sender, EventArgs e)
        {

        }

        private void lblMatch_Click(object sender, EventArgs e)
        {

        }
        //Opens PitScoutingForm
        private void button1_Click(object sender, EventArgs e)
        {
            PitScoutingForm frm = new PitScoutingForm(teamlist);
            frm.Show();
        }

        private void lbl0ScoutName_Click(object sender, EventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (InMemoryMatchList.Count == 0) {
                MessageBox.Show("No teams have been loaded.  Please make you have clicked 'Load Events' and then 'Get Matches' first.", "Not Ready for Reporting");
            } 
            else {
                Match_Preview_Report frm = new Match_Preview_Report(InMemoryMatchList, this.comboBoxSelectRegional.SelectedItem.ToString(), teamlist);
                frm.Show();
            }
        }

        private void lbl0Position2_Click(object sender, EventArgs e)
        {

        }

        private void lbl0Position7Value_Click(object sender, EventArgs e)
        {

        }
    }
}