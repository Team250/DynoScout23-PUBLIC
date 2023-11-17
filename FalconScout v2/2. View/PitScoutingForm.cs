using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FalconScout_v2017
{
    public partial class PitScoutingForm : Form
    {
        public PitScoutingForm(List<string> teamlist)
        {
            InitializeComponent();
            this.comboBox4.DataSource = teamlist;
}
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PitScouting_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //Saves PitScoutingForm
        private void btnStartMatch_Click(object sender, EventArgs e)
        {
            SeasonContext seasonframework = new SeasonContext();
            PitScouting pitscouting_record;
            bool _addingrecord = false;

            var teamNumber = ((Control)this.Controls.Find("comboBox4", true)[0]).Text.ToString();
            pitscouting_record = seasonframework.PitScoutingSet.FirstOrDefault(b => b.Team_Number == teamNumber);
            if (pitscouting_record == null)
            {
                pitscouting_record = new PitScouting();
                _addingrecord = true;
            }

            //Saves Values To Database
            pitscouting_record.Team_Number = this.comboBox4.Text;
            pitscouting_record.Regional = "N/A";
            pitscouting_record.DesignDrivetrain = this.cboDriveTrain.Text;
            pitscouting_record.ShootingMechanism = this.cboShootingMechanism.Text;
            pitscouting_record.PredictedPoints =  this.txtPredictedPoints.Text;
            pitscouting_record.StartingConfiguration = this.cboStartingConfiguration.Text;
            pitscouting_record.AutoAccomplishments = this.txtAutoAccomplishments.Text;
            //pitscouting_record.SpyboxCommunicaion = this.txtSpyboxCommunication.Text;
            pitscouting_record.Notes = this.txtNotes.Text;

            pitscouting_record.GoalTracking = this.cbxGoalTracking.Checked;
            pitscouting_record.CameraAided = this.cbxCameraAided.Checked;
            pitscouting_record.Articulated = this.cbxArticulated.Checked;
            //pitscouting_record.VariableAssistance = this.cbxVariableAssistance.Checked;
            pitscouting_record.LowGoal = this.cbxLowGoal.Checked;
            pitscouting_record.HighGoal = this.cbxHighGoal.Checked;
            pitscouting_record.Challenge = this.cbxChallenge.Checked;
            pitscouting_record.HighGoal = this.cbxScale.Checked;
            //pitscouting_record.ShotBatter = this.cbxShotBatter.Checked;
            //pitscouting_record.ShotCourtyard = this.cbxShotCourtyard.Checked;
            //pitscouting_record.ShotOuterworks = this.cbxShotOuterworks.Checked;
            //pitscouting_record.LowBar = this.cbxLowBar.Checked;
            //pitscouting_record.Porticullis = this.cbxPorticullis.Checked;
           // pitscouting_record.ChevaldeFrise = this.cbxChevaldeFrise.Checked;
           // pitscouting_record.SallyPort = this.cbxSallyPort.Checked;
            //pitscouting_record.Drawbridge = this.cbxDrawbridge.Checked;
            //pitscouting_record.RoughTerrain = this.cbxRoughTerrain.Checked;
            //pitscouting_record.RockWall = this.cbxRockWall.Checked;
            //pitscouting_record.Moat = this.cbxMoat.Checked;
            //pitscouting_record.Rampart = this.cbxRampart.Checked;

            if (_addingrecord == true) seasonframework.PitScoutingSet.Add(pitscouting_record);
            seasonframework.SaveChanges();
            MessageBox.Show("Scouting data has been saved");
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //Populates the PitScoutingForm with previous data entered in the database in order to make changes
        private void GetTeamData_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Getting data for team ");

            using (var db = new SeasonContext())
            {
                var teamNumber = ((Control)this.Controls.Find("comboBox4", true)[0]).Text.ToString();
                var result = db.PitScoutingSet.FirstOrDefault(b => b.Team_Number == teamNumber);
                if (result != null)
                {
                    cboDriveTrain.Text = result.DesignDrivetrain;
                    cboDriveTrain.Visible = true;
                    cboStartingConfiguration.Text = result.StartingConfiguration;
                    txtAutoAccomplishments.Text = result.AutoAccomplishments;
                    txtPredictedPoints.Text = result.PredictedPoints;
                    cboShootingMechanism.Text = result.ShootingMechanism;
                    //txtSpyboxCommunication.Text = result.SpyboxCommunicaion;
                    txtNotes.Text = result.Notes;
                    cbxGoalTracking.Checked = result.GoalTracking;
                    cbxCameraAided.Checked = result.CameraAided;
                    cbxArticulated.Checked = result.Articulated;
                    //cbxVariableAssistance.Checked = result.VariableAssistance;
                    cbxLowGoal.Checked = result.LowGoal;
                    cbxHighGoal.Checked = result.HighGoal;
                    cbxChallenge.Checked = result.Challenge;
                    //cbxScale.Checked = result.Scale;
                    cbxArticulated.Checked = result.Articulated;
                    //cbxShotBatter.Checked = result.ShotBatter;
                    //cbxShotCourtyard.Checked = result.ShotCourtyard;
                    //cbxShotOuterworks.Checked = result.ShotOuterworks;
                    //cbxLowBar.Checked = result.LowBar;
                    //cbxPorticullis.Checked = result.Porticullis;
                    //cbxChevaldeFrise.Checked = result.ChevaldeFrise;
                    //cbxSallyPort.Checked = result.SallyPort;
                    //cbxMoat.Checked = result.Moat;
                    //cbxDrawbridge.Checked = result.Drawbridge;
                    //cbxRoughTerrain.Checked = result.RoughTerrain;
                    //cbxRockWall.Checked = result.RockWall;
                    //cbxRampart.Checked = result.Rampart;
                    cbxArticulated.Checked = result.Articulated;
                }
                db.SaveChanges();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboDriveTrain_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void cbxScale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbxSallyPort_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbxChevaldeFrise_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cboStartingConfiguration_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
