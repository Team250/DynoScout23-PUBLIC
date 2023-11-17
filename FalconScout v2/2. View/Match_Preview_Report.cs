using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Diagnostics;

namespace FalconScout_v2017
{
    public partial class Match_Preview_Report : Form
    {
        string _Regional;
        private List<Match> _InMemoryMatchList;

        private Button printButton = new Button();
        private PrintDocument printDocument1 = new PrintDocument();

        public Match_Preview_Report(List<Match> InMemoryMatchList, String Regional, List<string> teamlist)
        {

        //printButton.Text = "Print Form";
        //printButton.Click += new EventHandler(printButton_Click);
        //printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
        //this.Controls.Add(printButton);

            SeasonContext seasonframework = new SeasonContext();

            _Regional = Regional;
            _InMemoryMatchList = InMemoryMatchList;

            InitializeComponent();

            this.comboBox1.DataSource = teamlist;
            this.comboBox2.DataSource = teamlist;
            this.comboBox3.DataSource = teamlist;
            this.comboBox5.DataSource = teamlist;
            this.comboBox6.DataSource = teamlist;
            this.comboBox7.DataSource = teamlist;

            //Create a List to store our KeyValuePairs
            List<string> matchlist = new List<string>();

            var query = from b in seasonframework.Matchset
                        orderby b.match_number
                        select b;

            foreach (var item in query) matchlist.Add(item.match_number.ToString());

            this.comboBox4.DataSource = matchlist;

            Regional = Regional.Substring(7, Regional.Length - 7);
            Regional = Regional.Replace("]", "");
            this.lblRegional.Text = Regional;

            //Clean the report in case it was just generated for a different match
            for (int teamnumber = 1; teamnumber <= 3; teamnumber++)
            {
                //((Label)this.Controls.Find("lblBlueTeam" + teamnumber.ToString() + "Lowbar", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblBlueTeam" + teamnumber.ToString() + "Porticullis", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblBlueTeam" + teamnumber.ToString() + "Cheval", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblBlueTeam" + teamnumber.ToString() + "SallyPort", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblBlueTeam" + teamnumber.ToString() + "Drawbridge", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblBlueTeam" + teamnumber.ToString() + "RoughTerrain", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblBlueTeam" + teamnumber.ToString() + "Rockwall", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblBlueTeam" + teamnumber.ToString() + "Ramparts", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblBlueTeam" + teamnumber.ToString() + "Moat", true)[0]).Text = "-";

                //((Label)this.Controls.Find("lblRedTeam" + teamnumber.ToString() + "Lowbar", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblRedTeam" + teamnumber.ToString() + "Porticullis", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblRedTeam" + teamnumber.ToString() + "Cheval", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblRedTeam" + teamnumber.ToString() + "SallyPort", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblRedTeam" + teamnumber.ToString() + "Drawbridge", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblRedTeam" + teamnumber.ToString() + "RoughTerrain", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblRedTeam" + teamnumber.ToString() + "Rockwall", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblRedTeam" + teamnumber.ToString() + "Ramparts", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblRedTeam" + teamnumber.ToString() + "Moat", true)[0]).Text = "-";
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int teamnumber = 1; teamnumber <= 3; teamnumber++)
            {
                //((Label)this.Controls.Find("lblBlueTeam" + teamnumber.ToString() + "Lowbar", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblBlueTeam" + teamnumber.ToString() + "Porticullis", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblBlueTeam" + teamnumber.ToString() + "Cheval", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblBlueTeam" + teamnumber.ToString() + "SallyPort", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblBlueTeam" + teamnumber.ToString() + "Drawbridge", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblBlueTeam" + teamnumber.ToString() + "RoughTerrain", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblBlueTeam" + teamnumber.ToString() + "Rockwall", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblBlueTeam" + teamnumber.ToString() + "Ramparts", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblBlueTeam" + teamnumber.ToString() + "Moat", true)[0]).Text = "-";

                //((Label)this.Controls.Find("lblRedTeam" + teamnumber.ToString() + "Lowbar", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblRedTeam" + teamnumber.ToString() + "Porticullis", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblRedTeam" + teamnumber.ToString() + "Cheval", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblRedTeam" + teamnumber.ToString() + "SallyPort", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblRedTeam" + teamnumber.ToString() + "Drawbridge", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblRedTeam" + teamnumber.ToString() + "RoughTerrain", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblRedTeam" + teamnumber.ToString() + "Rockwall", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblRedTeam" + teamnumber.ToString() + "Ramparts", true)[0]).Text = "-";
                //((Label)this.Controls.Find("lblRedTeam" + teamnumber.ToString() + "Moat", true)[0]).Text = "-";
            }
        }

        public void GenerateColumn(string teamcolor, int teamnumber, string teamname)
        {

        using (var db = new SeasonContext())
        {
            int no_of_matches = 0;
            int _match = 0;

            var teamNumber = teamname;
            var result = db.ActivitySet
                    .Where(records => records.Team == teamNumber)
                    .ToList();





                if (teamname == "frc5854")
                    MessageBox.Show("Hey!");

                if (result != null)
                {
                    // Run through all records and count number of passes for each defense

                    int _LowBar = 0;
                    int _Porticullis = 0;
                    int _Cheval = 0;
                    int _SallyPort = 0;
                    int _Drawbridge = 0;
                    int _RoughTerrain = 0;
                    int _RockWall = 0;
                    int _Moat = 0;
                    int _Ramparts = 0;

                    int _fuel_high_out_key = 0;
                    int _fuel_low_out_key = 0;
                    int _MissedHighGoals = 0;
                    int _MissedLowGoals = 0;

                    int _BatterShots = 0;
                    int _CourtyardShots = 0;
                    int _OuterworksShots = 0;

                    int _Scale = 0;
                    int _Challenge = 0;

                    double _AveLowBar = 0.0;
                    double _AvePorticullis = 0.0;
                    double _AveCheval = 0.0;
                    double _AveSallyPort = 0.0;
                    double _AveDrawbridge = 0.0;
                    double _AveRoughTerrain = 0.0;
                    double _AveRockWall = 0.0;
                    double _AveMoat = 0.0;
                    double _AveRamparts = 0.0;

                    foreach (var item in result)
                    {

                        // Defense Information
                        if (item.Match != _match)
                        {
                            _match = item.Match;
                            no_of_matches++;
                        }
                     
                    }
                    // Display Average times for all passes
                    if (_LowBar != 0) ((Label)this.Controls.Find("lbl" + teamcolor + "Team" + teamnumber + "Lowbar", true)[0]).Text = String.Format("{0:0.000}", _AveLowBar) + " for " + _LowBar.ToString();
                    if (_Porticullis != 0) ((Label)this.Controls.Find("lbl" + teamcolor + "Team" + teamnumber + "Porticullis", true)[0]).Text = String.Format("{0:0.000}", _AvePorticullis) + " for " + _Porticullis.ToString();
                    if (_Cheval != 0) ((Label)this.Controls.Find("lbl" + teamcolor + "Team" + teamnumber + "Cheval", true)[0]).Text = String.Format("{0:0.000}", _AveCheval) + " for " + _Cheval.ToString();
                    if (_SallyPort != 0) ((Label)this.Controls.Find("lbl" + teamcolor + "Team" + teamnumber + "SallyPort", true)[0]).Text = String.Format("{0:0.000}", _AveSallyPort) + " for " + _SallyPort.ToString();
                    if (_Drawbridge != 0) ((Label)this.Controls.Find("lbl" + teamcolor + "Team" + teamnumber + "Drawbridge", true)[0]).Text = String.Format("{0:0.000}", _AveDrawbridge) + " for " + _Drawbridge.ToString();
                    if (_RoughTerrain != 0) ((Label)this.Controls.Find("lbl" + teamcolor + "Team" + teamnumber + "RoughTerrain", true)[0]).Text = String.Format("{0:0.000}", _AveRoughTerrain) + " for " + _RoughTerrain.ToString();
                    if (_RockWall != 0) ((Label)this.Controls.Find("lbl" + teamcolor + "Team" + teamnumber + "Rockwall", true)[0]).Text = String.Format("{0:0.000}", _AveRockWall) + " for " + _RockWall.ToString();
                    if (_Ramparts != 0) ((Label)this.Controls.Find("lbl" + teamcolor + "Team" + teamnumber + "Ramparts", true)[0]).Text = String.Format("{0:0.000}", _AveRamparts) + " for " + _Ramparts.ToString();
                    if (_Moat != 0) ((Label)this.Controls.Find("lbl" + teamcolor + "Team" + teamnumber + "Moat", true)[0]).Text = String.Format("{0:0.000}", _AveMoat) + " for " + _Moat.ToString();

                    // Display Matches Played
                    ((Label)this.Controls.Find("lbl" + teamcolor + "Team" + teamnumber + "MatchSummary", true)[0]).Text = no_of_matches.ToString() + ":" + ((_fuel_high_out_key * 5) + (_fuel_low_out_key * 2)) + " pts.";
 
                    // Display Scored High Goal
                    ((Label)this.Controls.Find("lbl" + teamcolor + "Team" + teamnumber + "fuel_high_out_key", true)[0]).Text = _fuel_high_out_key.ToString() + "/" + (_fuel_high_out_key + _MissedHighGoals).ToString();

                    // Display Scored Low Goal
                    ((Label)this.Controls.Find("lbl" + teamcolor + "Team" + teamnumber + "fuel_low_out_key", true)[0]).Text = _fuel_low_out_key.ToString() + "/" + (_fuel_low_out_key + _MissedLowGoals).ToString();

                    // Display Accuracy
                    if (_fuel_low_out_key + _MissedLowGoals + _fuel_high_out_key + _MissedHighGoals != 0)
                        ((Label)this.Controls.Find("lbl" + teamcolor + "Team" + teamnumber + "Accuracy", true)[0]).Text = (100 * (float)(_fuel_low_out_key + _fuel_high_out_key) / (_fuel_low_out_key + _MissedLowGoals + _fuel_high_out_key + _MissedHighGoals)).ToString("#.##") + "%";
                    else ((Label)this.Controls.Find("lbl" + teamcolor + "Team" + teamnumber + "Accuracy", true)[0]).Text = "NaN";

                    // Batter Shots
                    ((Label)this.Controls.Find("lbl" + teamcolor + "Team" + teamnumber + "BatterShots", true)[0]).Text = _BatterShots.ToString() + "/" + (_fuel_low_out_key + _MissedLowGoals + _fuel_high_out_key + _MissedHighGoals).ToString();

                    // Courtyard Shots
                    ((Label)this.Controls.Find("lbl" + teamcolor + "Team" + teamnumber + "CourtyardShots", true)[0]).Text = _CourtyardShots.ToString() + "/" + (_fuel_low_out_key + _MissedLowGoals + _fuel_high_out_key + _MissedHighGoals).ToString();

                    // Outerworks Shots
                    ((Label)this.Controls.Find("lbl" + teamcolor + "Team" + teamnumber + "OuterworksShots", true)[0]).Text = _OuterworksShots.ToString() + "/" + (_fuel_low_out_key + _MissedLowGoals + _fuel_high_out_key + _MissedHighGoals).ToString();

                    // Display Scale
                    ((Label)this.Controls.Find("lbl" + teamcolor + "Team" + teamnumber + "Scale", true)[0]).Text = _Scale.ToString();

                    // Outerworks Challenge
                    ((Label)this.Controls.Find("lbl" + teamcolor + "Team" + teamnumber + "Challenge", true)[0]).Text = _Challenge.ToString();

                    //Endgame

                }
            }
        }

        private void GetTeamData_Click(object sender, EventArgs e)
        {

        }

        private void Match_Preview_Report_Load(object sender, EventArgs e)
        {

        }

        private void label15_Click_1(object sender, EventArgs e)
        {

        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPrintReport_Click_1(object sender, EventArgs e)
        {
            printForm1.Print();
        }

        private void GetTeamData_Click_1(object sender, EventArgs e)
        {

        }

        private void GetTeamData_Click_2(object sender, EventArgs e)
        {
            // Add Team Names to Report
            //this.lblRedTeam1.Text = _InMemoryMatchList[int.Parse(comboBox4.Text) - 1].redteam1.Substring(3, _InMemoryMatchList[int.Parse(comboBox4.Text) - 1].redteam1.Length - 3);
            //this.lblRedTeam2.Text = _InMemoryMatchList[int.Parse(comboBox4.Text) - 1].redteam2.Substring(3, _InMemoryMatchList[int.Parse(comboBox4.Text) - 1].redteam2.Length - 3);
            //this.lblRedTeam3.Text = _InMemoryMatchList[int.Parse(comboBox4.Text) - 1].redteam3.Substring(3, _InMemoryMatchList[int.Parse(comboBox4.Text) - 1].redteam3.Length - 3);
            //this.lblBlueTeam1.Text = _InMemoryMatchList[int.Parse(comboBox4.Text) - 1].blueteam1.Substring(3, _InMemoryMatchList[int.Parse(comboBox4.Text) - 1].blueteam1.Length - 3);
            //this.lblBlueTeam2.Text = _InMemoryMatchList[int.Parse(comboBox4.Text) - 1].blueteam2.Substring(3, _InMemoryMatchList[int.Parse(comboBox4.Text) - 1].blueteam2.Length - 3);
            //this.lblBlueTeam3.Text = _InMemoryMatchList[int.Parse(comboBox4.Text) - 1].blueteam3.Substring(3, _InMemoryMatchList[int.Parse(comboBox4.Text) - 1].blueteam3.Length - 3);

            // Generate each column of the report

            GenerateColumn("Blue", 1, _InMemoryMatchList[int.Parse(comboBox4.Text) - 1].blueteam1);
            GenerateColumn("Blue", 2, _InMemoryMatchList[int.Parse(comboBox4.Text) - 1].blueteam2);
            GenerateColumn("Blue", 3, _InMemoryMatchList[int.Parse(comboBox4.Text) - 1].blueteam3);
            GenerateColumn("Red", 1, _InMemoryMatchList[int.Parse(comboBox4.Text) - 1].redteam1);
            GenerateColumn("Red", 2, _InMemoryMatchList[int.Parse(comboBox4.Text) - 1].redteam2);
            GenerateColumn("Red", 3, _InMemoryMatchList[int.Parse(comboBox4.Text) - 1].redteam3);

            //db.SaveChanges();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblRockwall_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label145_Click(object sender, EventArgs e)
        {

        }

        private void label144_Click(object sender, EventArgs e)
        {

        }
    }
}
