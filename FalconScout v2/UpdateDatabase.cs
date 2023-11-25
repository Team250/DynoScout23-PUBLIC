using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace T250DynoScout_v2023
{
    public partial class UpdateDatabase : Form
    {
        public UpdateDatabase(List<string> teamlist, List<int> MatchNumbers)
        {
            InitializeComponent();
            this.comboTeamNumber.DataSource = teamlist;
            this.comboMatchNumber.DataSource = MatchNumbers;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            if (checkEndAuto.Checked || checkActivities.Checked || checkEndMatch.Checked || checkMatchEvent.Checked)
            {
                using (var db = new SeasonContext())
                {
                    string cbEA = "";
                    string cbA = "";
                    string cbEM = "";
                    string cbME = "";
                    string first = "";

                    if (checkEndAuto.Checked)
                    {
                        cbEA = first + "'EndAuto'";
                        first = ",";
                    }
                    if (checkActivities.Checked)
                    {
                        cbA = first + "'Activities'";
                        first = ",";
                    }
                    if (checkEndMatch.Checked)
                    {
                        cbEM = first + "'EndMatch'";
                        first = ",";
                    }
                    if (checkMatchEvent.Checked)
                    {
                        cbME = first + "'Match_Event'";
                    }

                    string teamNumber = this.comboTeamNumber.Text;
                    string matchNumber = this.comboMatchNumber.Text;
                    string Query = "Select * INTO UpdatePreviews FROM Activities WHERE Team = 'frc" + teamNumber + "' AND Match = '" + matchNumber + "' AND RecordType IN (" + cbEA + cbA + cbEM + cbME + ")";
                    SeasonContext seasonframework = new SeasonContext();
                    seasonframework.Database.ExecuteSqlCommand("IF OBJECT_ID ('UpdatePreviews') IS NOT NULL DROP TABLE UpdatePreviews");
                    seasonframework.Database.ExecuteSqlCommand(Query);
                    this.updatePreviewsTableAdapter.Fill(this._2023seasondbDataSet1.UpdatePreviews);
                }
            }
            else
            {
                MessageBox.Show("Please select at least one record type");
            }
        }

        private void UpdateDatabase_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_2023seasondbDataSet1.UpdatePreviews' table. You can move, or remove it, as needed.
            this.updatePreviewsTableAdapter.Fill(this._2023seasondbDataSet1.UpdatePreviews);
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboStrategy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboFailReason_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboMatchEvent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboMatchNumber_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtComm_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtLoad_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFetchValues_Click(object sender, EventArgs e)
        {
            using (var db = new SeasonContext())
            {
                var IDNumber = int.Parse(txtID.Text);
                bool isNumeric = int.TryParse(txtID.Text, out _);
                if (isNumeric)
                {
                    var result = db.UpdatePreviewSet.FirstOrDefault(b => b.Id == IDNumber);
                    if (result != null)
                    {
                        txtSub1.Text = result.AcqSub1.ToString();
                        txtSub2.Text = result.AcqSub2.ToString();
                        txtComm.Text = result.AcqFComm.ToString();
                        txtLoad.Text = result.AcqFLoad.ToString();
                        txtOpps.Text = result.AcqFOpps.ToString();
                        txtOther.Text = result.AcqFOther.ToString();
                        txtTop.Text = result.DelTop.ToString();
                        txtMid.Text = result.DelMid.ToString();
                        txtHyb.Text = result.DelBot.ToString();
                        txtOut.Text = result.DelOut.ToString();
                        txtCoop.Text = result.DelCoop.ToString();
                        txtFloor.Text = result.DelFloor.ToString();
                        txtDrop.Text = result.DelDrop.ToString();
                        txtCone.Text = result.Cone.ToString();
                        txtCube.Text = result.Cube.ToString();
                        string Pa = result.Parked.ToString();
                        string Do = result.Docked.ToString();
                        string En = result.Engaged.ToString();
                        string TAF = result.Tried_And_Failed.ToString();
                        string NA = result.No_Attempt.ToString();
                        if (Pa == "1")
                        {
                            comboCSStatus.Text = "P";
                        }
                        else if (Do == "1")
                        {
                            comboCSStatus.Text = "D";
                        }
                        else if (En == "1")
                        {
                            comboCSStatus.Text = "E";
                        }
                        else if (TAF == "1")
                        {
                            comboCSStatus.Text = "T";
                        }
                        else if (NA == "1")
                        {
                            comboCSStatus.Text = "N";
                        }
                        txtPartners.Text = result.ChargePart.ToString();
                        comboFailReason.Text = result.EngageFail.ToString();
                        txtTime.Text = result.EngageT.ToString();
                        comboMode.Text = result.Mode.ToString();
                        comboMatchEvent.Text = result.match_event.ToString();
                        txtMobility.Text = result.Mobility.ToString();
                        txtSetup.Text = result.Setup.ToString();
                        txtAutoPts.Text = result.AutoPts.ToString();
                        txtGridPts.Text = result.GridPts.ToString();
                        txtChargePts.Text = result.ChargePts.ToString();
                        txtDefense.Text = result.Defense.ToString();
                        txtAvoidance.Text = result.Avoidance.ToString();
                        comboStrategy.Text = result.Strategy.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid ID");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a number for the ID");
                }
            }
        }

        private void comboMatchEvent_SelectedIndexChanged3(object sender, EventArgs e)
        {

        }

        private void btnUpdateDatabase_Click(object sender, EventArgs e)
        {
            using (var db = new SeasonContext())
            {
                SeasonContext seasonframework = new SeasonContext();
                var IDNumber = int.Parse(txtID.Text);
                bool isNumeric = int.TryParse(txtID.Text, out _);
                if (isNumeric)
                {
                    var result = db.UpdatePreviewSet.FirstOrDefault(b => b.Id == IDNumber);
                    if (result != null)
                    {
                        string query = "UPDATE Activities SET AcqSub1 = '" + txtSub1.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET AcqSub2 = '" + txtSub2.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET AcqFComm = '" + txtComm.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET AcqFLoad = '" + txtLoad.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET AcqFOpps = '" + txtOpps.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET AcqFOther = '" + txtOther.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET DelTop = '" + txtTop.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET DelMid = '" + txtMid.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET DelBot = '" + txtHyb.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET DelOut = '" + txtOut.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET DelCoop = '" + txtCoop.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET DelFloor = '" + txtFloor.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET DelDrop = '" + txtDrop.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET Cone = '" + txtCone.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET Cube = '" + txtCube.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        int Pa = 0;
                        int Do = 0;
                        int En = 0;
                        int TAF = 0;
                        int NA = 0;
                        if (comboCSStatus.Text == "P")
                        {
                            Pa = 1;
                            Do = 0;
                            En = 0;
                            TAF = 0;
                            NA = 0;
                        }
                        else if (comboCSStatus.Text == "D")
                        {
                            Pa = 0;
                            Do = 1;
                            En = 0;
                            TAF = 0;
                            NA = 0;
                        }
                        else if (comboCSStatus.Text == "E")
                        {
                            Pa = 0;
                            Do = 0;
                            En = 1;
                            TAF = 0;
                            NA = 0;
                        }
                        else if (comboCSStatus.Text == "T")
                        {
                            Pa = 0;
                            Do = 0;
                            En = 0;
                            TAF = 1;
                            NA = 0;
                        }
                        else if (comboCSStatus.Text == "N")
                        {
                            Pa = 0;
                            Do = 0;
                            En = 0;
                            TAF = 0;
                            NA = 1;
                        }

                        query = "UPDATE Activities SET Parked = '" + Pa + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET Docked = '" + Do + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET Engaged = '" + En + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET Tried_And_Failed = '" + TAF + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET No_Attempt = '" + NA + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET ChargePart = '" + txtPartners.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET EngageFail = '" + comboFailReason.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET EngageT = '" + txtTime.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET Mode = '" + comboMode.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET match_event = '" + comboMatchEvent.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET Mobility = '" + txtMobility.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET Setup = '" + txtSetup.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET AutoPts = '" + txtAutoPts.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET GridPts = '" + txtGridPts.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET ChargePts = '" + txtChargePts.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET Defense = '" + txtDefense.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET Avoidance = '" + txtAvoidance.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);

                        query = "UPDATE Activities SET Strategy = '" + comboStrategy.Text + "' WHERE Id = '" + result.Id + "';";
                        seasonframework.Database.ExecuteSqlCommand(query);
                    }
                }


                int IndexNumber = 0;
                var team = "frc" + comboTeamNumber.Text.ToString();
                var teamresult = db.Teamset.FirstOrDefault(t => t.team_key == team);
                var activityresult = db.ActivitySet.FirstOrDefault(b => b.Team == team && b.Id == IDNumber);
                var checkresult = db.UpdatePreviewSet.FirstOrDefault(b => b.Id == IDNumber);
                for (int i = 0; i < IDNumber; i++)
                {
                    var activityresult2 = db.ActivitySet.FirstOrDefault(b => b.Team == team && b.Id == i && b.RecordType == "EndMatch");
                    if (activityresult2 != null)
                    {
                        IndexNumber++;
                    }
                }

                string csauto = teamresult.trend_csauto;
                if (activityresult.RecordType == "EndAuto")
                {
                    csauto = csauto.Remove(IndexNumber, 1).Insert(IndexNumber, comboCSStatus.Text.ToString());
                }
                string query2 = "UPDATE TeamSummaries SET trend_csauto = '" + csauto + "' WHERE team_key = '" + teamresult.team_key + "';";
                seasonframework.Database.ExecuteSqlCommand(query2);

                string csend = teamresult.trend_csend;
                if (activityresult.RecordType == "EndMatch")
                {
                    csend = csend.Remove(IndexNumber, 1).Insert(IndexNumber, comboCSStatus.Text.ToString());
                }
                query2 = "UPDATE TeamSummaries SET trend_csend = '" + csend + "' WHERE team_key = '" + teamresult.team_key + "';";
                seasonframework.Database.ExecuteSqlCommand(query2);

                string defense = teamresult.trend_defense;
                defense = defense.Remove(IndexNumber, 1).Insert(IndexNumber, txtDefense.Text.ToString());
                query2 = "UPDATE TeamSummaries SET trend_defense = '" + defense + "' WHERE team_key = '" + teamresult.team_key + "';";
                seasonframework.Database.ExecuteSqlCommand(query2);

                string avoidance = teamresult.trend_avoidance;
                avoidance = avoidance.Remove(IndexNumber, 1).Insert(IndexNumber, txtAvoidance.Text.ToString());
                query2 = "UPDATE TeamSummaries SET trend_avoidance = '" + avoidance + "' WHERE team_key = '" + teamresult.team_key + "';";
                seasonframework.Database.ExecuteSqlCommand(query2);

                string setup = teamresult.trend_setup;
                setup = setup.Remove(IndexNumber, 1).Insert(IndexNumber, txtSetup.Text.ToString());
                query2 = "UPDATE TeamSummaries SET trend_setup = '" + setup + "' WHERE team_key = '" + teamresult.team_key + "';";
                seasonframework.Database.ExecuteSqlCommand(query2);

                string appstrat = teamresult.trend_appstrat;
                appstrat = appstrat.Remove(IndexNumber, 1).Insert(IndexNumber, comboStrategy.Text.ToString());
                query2 = "UPDATE TeamSummaries SET trend_appstrat = '" + appstrat + "' WHERE team_key = '" + teamresult.team_key + "';";
                seasonframework.Database.ExecuteSqlCommand(query2);

                string csfails = teamresult.trend_csfails;
                csfails = csfails.Remove(IndexNumber, 1).Insert(IndexNumber, comboFailReason.Text.ToString());
                query2 = "UPDATE TeamSummaries SET trend_csfails = '" + csfails + "' WHERE team_key = '" + teamresult.team_key + "';";
                seasonframework.Database.ExecuteSqlCommand(query2);

                string partner = teamresult.trend_cspartner;
                partner = partner.Remove(IndexNumber, 1).Insert(IndexNumber, txtPartners.Text.ToString());
                query2 = "UPDATE TeamSummaries SET trend_cspartner = '" + partner + "' WHERE team_key = '" + teamresult.team_key + "';";
                seasonframework.Database.ExecuteSqlCommand(query2);

                string cone_top = teamresult.cone_top;
                string cone_mid = teamresult.cone_mid;
                string cone_hyb = teamresult.cone_hyb;
                string cube_top = teamresult.cube_top;
                string cube_mid = teamresult.cube_mid;
                string cube_hyb = teamresult.cube_hyb;
                string grid_coop = teamresult.grid_coop;
                string grid_out = teamresult.grid_out;
                string auto_cones = teamresult.auto_cones;
                string auto_cubes = teamresult.auto_cubes;

                int cone_topint = int.Parse(teamresult.cone_top[IndexNumber].ToString());
                int cone_midint = int.Parse(teamresult.cone_mid[IndexNumber].ToString());
                int cone_hybint = int.Parse(teamresult.cone_hyb[IndexNumber].ToString());
                int cube_topint = int.Parse(teamresult.cube_top[IndexNumber].ToString());
                int cube_midint = int.Parse(teamresult.cube_mid[IndexNumber].ToString());
                int cube_hybint = int.Parse(teamresult.cube_hyb[IndexNumber].ToString());
                int grid_coopint = int.Parse(teamresult.grid_coop[IndexNumber].ToString());
                int auto_conesint = int.Parse(teamresult.auto_cones[IndexNumber].ToString());
                int auto_cubesint = int.Parse(teamresult.auto_cubes[IndexNumber].ToString());

                string grid_outchar = teamresult.grid_out[IndexNumber].ToString();
                string[] enneadecimal = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "J" };
                grid_outchar = Array.IndexOf(enneadecimal, grid_outchar).ToString();
                int grid_outint = int.Parse(grid_outchar);

                if (checkresult.Cone == 1)
                {
                    if (checkresult.DelTop == 1)
                    {
                        cone_topint--;
                    }
                    if (checkresult.DelMid == 1)
                    {
                        cone_midint--;
                    }
                    if (checkresult.DelBot == 1)
                    {
                        cone_hybint--;
                    }
                    if (checkresult.Mode == "Auto")
                    {
                        auto_conesint--;
                    }
                }
                if (checkresult.Cube == 1)
                {
                    if (checkresult.DelTop == 1)
                    {
                        cube_topint--;
                    }
                    if (checkresult.DelMid == 1)
                    {
                        cube_midint--;
                    }
                    if (checkresult.DelBot == 1)
                    {
                        cube_hybint--;
                    }
                    if (checkresult.Mode == "Auto")
                    {
                        auto_cubesint--;
                    }
                }
                if (checkresult.DelCoop == 1)
                {
                    grid_coopint--;
                }
                if (checkresult.DelOut == 1)
                {
                    grid_outint--;
                }

                if (txtCone.Text == "1")
                {
                    if (txtTop.Text == "1")
                    {
                        cone_topint++;
                    }
                    if (txtMid.Text == "1")
                    {
                        cone_midint++;
                    }
                    if (txtHyb.Text == "1")
                    {
                        cone_hybint++;
                    }
                    if (comboMode.Text == "Auto")
                    {
                        auto_conesint++;
                    }
                }
                if (txtCube.Text == "1")
                {
                    if (txtTop.Text == "1")
                    {
                        cube_topint++;
                    }
                    if (txtMid.Text == "1")
                    {
                        cube_midint++;
                    }
                    if (txtHyb.Text == "1")
                    {
                        cube_hybint++;
                    }
                    if (comboMode.Text == "Auto")
                    {
                        auto_cubesint++;
                    }
                }
                if (txtCoop.Text == "1")
                {
                    grid_coopint++;
                }
                if (txtOut.Text == "1")
                {
                    grid_outint++;
                }

                cube_top = cube_top.Remove(IndexNumber, 1).Insert(IndexNumber, cube_topint.ToString());
                cube_mid = cube_mid.Remove(IndexNumber, 1).Insert(IndexNumber, cube_midint.ToString());
                cube_hyb = cube_hyb.Remove(IndexNumber, 1).Insert(IndexNumber, cube_hybint.ToString());
                cone_top = cone_top.Remove(IndexNumber, 1).Insert(IndexNumber, cone_topint.ToString());
                cone_mid = cone_mid.Remove(IndexNumber, 1).Insert(IndexNumber, cone_midint.ToString());
                cone_hyb = cone_hyb.Remove(IndexNumber, 1).Insert(IndexNumber, cone_hybint.ToString());
                grid_coop = grid_coop.Remove(IndexNumber, 1).Insert(IndexNumber, grid_coopint.ToString());
                grid_out = grid_out.Remove(IndexNumber, 1).Insert(IndexNumber, enneadecimal[grid_outint].ToString());
                auto_cones = auto_cones.Remove(IndexNumber, 1).Insert(IndexNumber, auto_conesint.ToString());
                auto_cubes = auto_cubes.Remove(IndexNumber, 1).Insert(IndexNumber, auto_cubesint.ToString());

                query2 = "UPDATE TeamSummaries SET cone_top = '" + cone_top + "' WHERE team_key = '" + teamresult.team_key + "';";
                seasonframework.Database.ExecuteSqlCommand(query2);
                query2 = "UPDATE TeamSummaries SET cone_mid = '" + cone_mid + "' WHERE team_key = '" + teamresult.team_key + "';";
                seasonframework.Database.ExecuteSqlCommand(query2);
                query2 = "UPDATE TeamSummaries SET cone_hyb = '" + cone_hyb + "' WHERE team_key = '" + teamresult.team_key + "';";
                seasonframework.Database.ExecuteSqlCommand(query2);
                query2 = "UPDATE TeamSummaries SET cube_top = '" + cube_top + "' WHERE team_key = '" + teamresult.team_key + "';";
                seasonframework.Database.ExecuteSqlCommand(query2);
                query2 = "UPDATE TeamSummaries SET cube_mid = '" + cube_mid + "' WHERE team_key = '" + teamresult.team_key + "';";
                seasonframework.Database.ExecuteSqlCommand(query2);
                query2 = "UPDATE TeamSummaries SET cube_hyb = '" + cube_hyb + "' WHERE team_key = '" + teamresult.team_key + "';";
                seasonframework.Database.ExecuteSqlCommand(query2);
                query2 = "UPDATE TeamSummaries SET grid_coop = '" + grid_coop + "' WHERE team_key = '" + teamresult.team_key + "';";
                seasonframework.Database.ExecuteSqlCommand(query2);
                query2 = "UPDATE TeamSummaries SET auto_cones = '" + auto_cones + "' WHERE team_key = '" + teamresult.team_key + "';";
                seasonframework.Database.ExecuteSqlCommand(query2);
                query2 = "UPDATE TeamSummaries SET auto_cubes = '" + auto_cubes + "' WHERE team_key = '" + teamresult.team_key + "';";
                seasonframework.Database.ExecuteSqlCommand(query2);

                int auto_pts = teamresult.auto_pts - checkresult.AutoPts + int.Parse(txtAutoPts.Text);
                int grid_pts = teamresult.grid_pts - checkresult.GridPts + int.Parse(txtGridPts.Text);
                int charge_pts = teamresult.charge_pts - checkresult.ChargePts + int.Parse(txtChargePts.Text);

                query2 = "UPDATE TeamSummaries SET auto_pts = '" + auto_pts + "' WHERE team_key = '" + teamresult.team_key + "';";
                seasonframework.Database.ExecuteSqlCommand(query2);
                query2 = "UPDATE TeamSummaries SET grid_pts = '" + grid_pts + "' WHERE team_key = '" + teamresult.team_key + "';";
                seasonframework.Database.ExecuteSqlCommand(query2);
                query2 = "UPDATE TeamSummaries SET charge_pts = '" + charge_pts + "' WHERE team_key = '" + teamresult.team_key + "';";
                seasonframework.Database.ExecuteSqlCommand(query2);
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void comboCSStatus_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void txtDrop_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridUpdatePreview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
