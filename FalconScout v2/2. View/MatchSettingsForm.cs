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

    // The MatchSettingsForm is a large class so it's been broken up into several pieces - so we made it a partial class.
    public partial class MatchSettingsForm : Form
    {
        public MainScreen m_form = null;  // Define a new collection form, but don't do anything with it yet.

        private List<Match> _InMemoryMatchList;             //The list of all the matches at the selected event.
        int _match;                                         //This is the match we're currently in.

        public MatchSettingsForm(MainScreen f, List<Match> InMemoryMatchList)
        {
            InitializeComponent();

            _InMemoryMatchList = InMemoryMatchList;  // Make a local copy of the list of matches we store in memory.

            m_form = f;  // This is the pointer to the form.  We use this to address each individual field on the display
                         // that the Scouters are using.  By using this variable format and searching the form, we save
                         // quite a bit of code that would be required if we named them individually.  This is why we
                         // have pretty generic field names on the form.


            // This is how we define a screen field name using variables.  We find, on the form, the correct field name
            //  for the correct Scouter, by creating the field name as a concatenation of the correct text so it matches
            //  the field name on the screen.
            Control ctrl = ((Label)f.Controls.Find("lblmatch", true)[0]);
            (((Label)this.Controls.Find("match_number", true)[0]).Text) = ctrl.Text;
            _match = int.Parse(ctrl.Text);

            }
            private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }

            }
    

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MatchSettingsForm_Load(object sender, EventArgs e)
        {
         
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkedListBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }
        //Saves MatchSetting
        private void button1_Click(object sender, EventArgs e)
        {
            Match match_record = new Match();
            SeasonContext seasonframework = new SeasonContext();

            using (var db = new SeasonContext())
            {
                string _key = ((Label)m_form.Controls.Find("lblkey", true)[0]).Text.ToString();
                var result = db.Matchset.FirstOrDefault(b => b.key == _key);
                if (result != null)
                {
                    result.bluedefense2 = this.bluecomboBox2.Text;
                    result.bluedefense3 = this.bluecomboBox3.Text;
                    result.bluedefense4 = this.bluecomboBox4.Text;
                    result.bluedefense5 = this.bluecomboBox5.Text;
                    result.reddefense2 = this.redcomboBox2.Text;
                    result.reddefense3 = this.redcomboBox3.Text;
                    result.reddefense4 = this.redcomboBox4.Text;
                    result.reddefense5 = this.redcomboBox5.Text;

                    db.SaveChanges();

                    _InMemoryMatchList[_match].bluedefense2 = this.bluecomboBox2.Text;
                    _InMemoryMatchList[_match].bluedefense3 = this.bluecomboBox3.Text;
                    _InMemoryMatchList[_match].bluedefense4 = this.bluecomboBox4.Text;
                    _InMemoryMatchList[_match].bluedefense5 = this.bluecomboBox5.Text;
                    _InMemoryMatchList[_match].reddefense2 = this.redcomboBox2.Text;
                    _InMemoryMatchList[_match].reddefense3 = this.redcomboBox3.Text;
                    _InMemoryMatchList[_match].reddefense4 = this.redcomboBox4.Text;
                    _InMemoryMatchList[_match].reddefense5 = this.redcomboBox5.Text;
                }
            }

            this.Hide();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Red Defense
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void bluecomboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bluecomboBox5.SelectedItem.ToString() == "Portcullis" | bluecomboBox5.SelectedItem.ToString() == "Cheval de Frise")
            {
                bluecomboBox4.Items.Remove("Portcullis");
                bluecomboBox3.Items.Remove("Portcullis");
                bluecomboBox2.Items.Remove("Portcullis");
                bluecomboBox4.Items.Remove("Cheval de Frise");
                bluecomboBox3.Items.Remove("Cheval de Frise");
                bluecomboBox2.Items.Remove("Cheval de Frise");
            }
            if (bluecomboBox5.SelectedItem.ToString() == "Moat" | bluecomboBox5.SelectedItem.ToString() == "Ramparts")
            {
                bluecomboBox4.Items.Remove("Moat");
                bluecomboBox3.Items.Remove("Moat");
                bluecomboBox2.Items.Remove("Moat");
                bluecomboBox4.Items.Remove("Ramparts");
                bluecomboBox3.Items.Remove("Ramparts");
                bluecomboBox2.Items.Remove("Ramparts");
            }
            if (bluecomboBox5.SelectedItem.ToString() == "Drawbridge" | bluecomboBox5.SelectedItem.ToString() == "Sally Port")
            {
                bluecomboBox4.Items.Remove("Drawbridge");
                bluecomboBox3.Items.Remove("Drawbridge");
                bluecomboBox2.Items.Remove("Drawbridge");
                bluecomboBox4.Items.Remove("Sally Port");
                bluecomboBox3.Items.Remove("Sally Port");
                bluecomboBox2.Items.Remove("Sally Port");
            }
            if (bluecomboBox5.SelectedItem.ToString() == "Rock Wall" | bluecomboBox5.SelectedItem.ToString() == "Rough Terrain")
            {
                bluecomboBox4.Items.Remove("Rock Wall");
                bluecomboBox3.Items.Remove("Rock Wall");
                bluecomboBox2.Items.Remove("Rock Wall");
                bluecomboBox4.Items.Remove("Rough Terrain");
                bluecomboBox3.Items.Remove("Rough Terrain");
                bluecomboBox2.Items.Remove("Rough Terrain");
            }
        }

        private void bluecomboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bluecomboBox4.SelectedItem.ToString() == "Portcullis" | bluecomboBox4.SelectedItem.ToString() == "Cheval de Frise")
            {
                bluecomboBox3.Items.Remove("Portcullis");
                bluecomboBox2.Items.Remove("Portcullis");
                bluecomboBox3.Items.Remove("Cheval de Frise");
                bluecomboBox2.Items.Remove("Cheval de Frise");
            }
            if (bluecomboBox4.SelectedItem.ToString() == "Moat" | bluecomboBox4.SelectedItem.ToString() == "Ramparts")
            {
                bluecomboBox3.Items.Remove("Moat");
                bluecomboBox2.Items.Remove("Moat");
                bluecomboBox3.Items.Remove("Ramparts");
                bluecomboBox2.Items.Remove("Ramparts");
            }
            if (bluecomboBox4.SelectedItem.ToString() == "Drawbridge" | bluecomboBox4.SelectedItem.ToString() == "Sally Port")
            {
                bluecomboBox3.Items.Remove("Drawbridge");
                bluecomboBox2.Items.Remove("Drawbridge");
                bluecomboBox3.Items.Remove("Sally Port");
                bluecomboBox2.Items.Remove("Sally Port");
            }
            if (bluecomboBox4.SelectedItem.ToString() == "Rock Wall" | bluecomboBox4.SelectedItem.ToString() == "Rough Terrain")
            {
                bluecomboBox3.Items.Remove("Rock Wall");
                bluecomboBox2.Items.Remove("Rock Wall");
                bluecomboBox3.Items.Remove("Rough Terrain");
                bluecomboBox2.Items.Remove("Rough Terrain");
            }
        }

        private void bluecomboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bluecomboBox3.SelectedItem.ToString() == "Portcullis" | bluecomboBox3.SelectedItem.ToString() == "Cheval de Frise")
            {
                bluecomboBox2.Items.Remove("Portcullis");
                bluecomboBox2.Items.Remove("Cheval de Frise");
            }
            if (bluecomboBox3.SelectedItem.ToString() == "Moat" | bluecomboBox3.SelectedItem.ToString() == "Ramparts")
            {
                bluecomboBox2.Items.Remove("Moat");
                bluecomboBox2.Items.Remove("Ramparts");
            }
            if (bluecomboBox3.SelectedItem.ToString() == "Drawbridge" | bluecomboBox3.SelectedItem.ToString() == "Sally Port")
            {
                bluecomboBox2.Items.Remove("Drawbridge");
                bluecomboBox2.Items.Remove("Sally Port");
            }
            if (bluecomboBox3.SelectedItem.ToString() == "Rock Wall" | bluecomboBox3.SelectedItem.ToString() == "Rough Terrain")
            {
                bluecomboBox2.Items.Remove("Rock Wall");
                bluecomboBox2.Items.Remove("Rough Terrain");
            }
        }

        private void redcomboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (redcomboBox2.SelectedItem.ToString() == "Portcullis" | redcomboBox2.SelectedItem.ToString() == "Cheval de Frise")
            {
                redcomboBox3.Items.Remove("Portcullis");
                redcomboBox3.Items.Remove("Cheval de Frise");
                redcomboBox4.Items.Remove("Portcullis");
                redcomboBox4.Items.Remove("Cheval de Frise");
                redcomboBox5.Items.Remove("Portcullis");
                redcomboBox5.Items.Remove("Cheval de Frise");
            }
            if (redcomboBox2.SelectedItem.ToString() == "Moat" | redcomboBox2.SelectedItem.ToString() == "Ramparts")
            {
                redcomboBox3.Items.Remove("Moat");
                redcomboBox3.Items.Remove("Ramparts");
                redcomboBox4.Items.Remove("Moat");
                redcomboBox4.Items.Remove("Ramparts");
                redcomboBox5.Items.Remove("Moat");
                redcomboBox5.Items.Remove("Ramparts");
            }
            if (redcomboBox2.SelectedItem.ToString() == "Drawbridge" | redcomboBox2.SelectedItem.ToString() == "Sally Port")
            {
                redcomboBox3.Items.Remove("Drawbridge");
                redcomboBox3.Items.Remove("Sally Port");
                redcomboBox4.Items.Remove("Drawbridge");
                redcomboBox4.Items.Remove("Sally Port");
                redcomboBox5.Items.Remove("Drawbridge");
                redcomboBox5.Items.Remove("Sally Port");
            }
            if (redcomboBox2.SelectedItem.ToString() == "Rock Wall" | redcomboBox2.SelectedItem.ToString() == "Rough Terrain")
            {
                redcomboBox3.Items.Remove("Rock Wall");
                redcomboBox3.Items.Remove("Rough Terrain");
                redcomboBox4.Items.Remove("Rock Wall");
                redcomboBox4.Items.Remove("Rough Terrain");
                redcomboBox5.Items.Remove("Rock Wall");
                redcomboBox5.Items.Remove("Rough Terrain");
            }
        }

        private void redcomboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (redcomboBox3.SelectedItem.ToString() == "Portcullis" | redcomboBox3.SelectedItem.ToString() == "Cheval de Frise")
            {
                redcomboBox4.Items.Remove("Portcullis");
                redcomboBox4.Items.Remove("Cheval de Frise");
                redcomboBox5.Items.Remove("Portcullis");
                redcomboBox5.Items.Remove("Cheval de Frise");
            }
            if (redcomboBox3.SelectedItem.ToString() == "Moat" | redcomboBox3.SelectedItem.ToString() == "Ramparts")
            {
                redcomboBox4.Items.Remove("Moat");
                redcomboBox4.Items.Remove("Ramparts");
                redcomboBox5.Items.Remove("Moat");
                redcomboBox5.Items.Remove("Ramparts");
            }
            if (redcomboBox3.SelectedItem.ToString() == "Drawbridge" | redcomboBox3.SelectedItem.ToString() == "Sally Port")
            {
                redcomboBox4.Items.Remove("Drawbridge");
                redcomboBox4.Items.Remove("Sally Port");
                redcomboBox5.Items.Remove("Drawbridge");
                redcomboBox5.Items.Remove("Sally Port");
            }
            if (redcomboBox3.SelectedItem.ToString() == "Rock Wall" | redcomboBox3.SelectedItem.ToString() == "Rough Terrain")
            {
                redcomboBox4.Items.Remove("Rock Wall");
                redcomboBox4.Items.Remove("Rough Terrain");
                redcomboBox5.Items.Remove("Rock Wall");
                redcomboBox5.Items.Remove("Rough Terrain");
            }
        }

        private void redcomboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (redcomboBox4.SelectedItem.ToString() == "Portcullis" | redcomboBox4.SelectedItem.ToString() == "Cheval de Frise")
            {
                redcomboBox5.Items.Remove("Portcullis");
                redcomboBox5.Items.Remove("Cheval de Frise");
            }
            if (redcomboBox4.SelectedItem.ToString() == "Moat" | redcomboBox4.SelectedItem.ToString() == "Ramparts")
            {
                redcomboBox5.Items.Remove("Moat");
                redcomboBox5.Items.Remove("Ramparts");
            }
            if (redcomboBox4.SelectedItem.ToString() == "Drawbridge" | redcomboBox4.SelectedItem.ToString() == "Sally Port")
            {
                redcomboBox5.Items.Remove("Drawbridge");
                redcomboBox5.Items.Remove("Sally Port");
            }
            if (redcomboBox4.SelectedItem.ToString() == "Rock Wall" | redcomboBox4.SelectedItem.ToString() == "Rough Terrain")
            {
                redcomboBox5.Items.Remove("Rock Wall");
                redcomboBox5.Items.Remove("Rough Terrain");
            }
        }

        private void redcomboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
