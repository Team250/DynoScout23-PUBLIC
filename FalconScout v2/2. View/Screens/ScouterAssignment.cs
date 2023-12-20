using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using T250DynoScout_v2023;
using SlimDX.DirectInput;

namespace T250DynoScout_v2020
{
    public partial class ScouterAssignment : Form
    {

        public ScouterAssignment()
        {
            InitializeComponent();

            this.ScoutDrop0.Items.AddRange(new object[] { Controllers.ScouterNameMap[0],
                                                             Controllers.ScouterNameMap[1],
                                                             Controllers.ScouterNameMap[2],
                                                             Controllers.ScouterNameMap[3],
                                                             Controllers.ScouterNameMap[4],
                                                             Controllers.ScouterNameMap[5] });

            this.ScoutDrop1.Items.AddRange(new object[] { Controllers.ScouterNameMap[0],
                                                             Controllers.ScouterNameMap[1],
                                                             Controllers.ScouterNameMap[2],
                                                             Controllers.ScouterNameMap[3],
                                                             Controllers.ScouterNameMap[4],
                                                             Controllers.ScouterNameMap[5] });

            this.ScoutDrop2.Items.AddRange(new object[] { Controllers.ScouterNameMap[0],
                                                             Controllers.ScouterNameMap[1],
                                                             Controllers.ScouterNameMap[2],
                                                             Controllers.ScouterNameMap[3],
                                                             Controllers.ScouterNameMap[4],
                                                             Controllers.ScouterNameMap[5] });

            this.ScoutDrop3.Items.AddRange(new object[] { Controllers.ScouterNameMap[0],
                                                             Controllers.ScouterNameMap[1],
                                                             Controllers.ScouterNameMap[2],
                                                             Controllers.ScouterNameMap[3],
                                                             Controllers.ScouterNameMap[4],
                                                             Controllers.ScouterNameMap[5] });

            this.ScoutDrop4.Items.AddRange(new object[] { Controllers.ScouterNameMap[0],
                                                             Controllers.ScouterNameMap[1],
                                                             Controllers.ScouterNameMap[2],
                                                             Controllers.ScouterNameMap[3],
                                                             Controllers.ScouterNameMap[4],
                                                             Controllers.ScouterNameMap[5] });

            this.ScoutDrop5.Items.AddRange(new object[] { Controllers.ScouterNameMap[0],
                                                             Controllers.ScouterNameMap[1],
                                                             Controllers.ScouterNameMap[2],
                                                             Controllers.ScouterNameMap[3],
                                                             Controllers.ScouterNameMap[4],
                                                             Controllers.ScouterNameMap[5] });

        }

        private void ScoutDrop0_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ScoutDrop1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ScoutDrop2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ScoutDrop3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ScoutDrop4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ScoutDrop5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ScoutOK_Click(object sender, EventArgs e)
        {
            bool check = true;
            while (check)
            {
                List<string> alreadySelected = new List<string>();
                List<string> newPositions = new List<string>();
                if (this.ScoutDrop0.Text != "" && this.ScoutDrop0.Text != "Select_Name")
                {
                    alreadySelected.Add(this.ScoutDrop0.Text);
                    newPositions.Add(this.ScoutDrop0.Text);
                }
                else
                {
                    newPositions.Add(RobotState.SCOUTER_NAME.Select_Name.ToString());
                }

                if (this.ScoutDrop1.Text != "" && this.ScoutDrop1.Text != "Select_Name")
                {
                    if (alreadySelected.Contains(this.ScoutDrop1.Text))
                    {
                        DialogResult dialogResult = MessageBox.Show("Box number is in more then one spot", "OK", MessageBoxButtons.OK);
                        break;
                    }
                    else
                    {
                        alreadySelected.Add(this.ScoutDrop1.Text);
                        newPositions.Add(this.ScoutDrop1.Text);
                    }
                }
                else
                {
                    newPositions.Add(RobotState.SCOUTER_NAME.Select_Name.ToString());
                }

                if (this.ScoutDrop2.Text != "" && this.ScoutDrop2.Text != "Select_Name")
                {
                    if (alreadySelected.Contains(this.ScoutDrop2.Text))
                    {
                        DialogResult dialogResult = MessageBox.Show("Box number is in more then one spot", "OK", MessageBoxButtons.OK);
                        break;
                    }
                    else
                    {
                        alreadySelected.Add(this.ScoutDrop2.Text);
                        newPositions.Add(this.ScoutDrop2.Text);
                    }
                }
                else
                {
                    newPositions.Add(RobotState.SCOUTER_NAME.Select_Name.ToString());
                }

                if (this.ScoutDrop3.Text != "" && this.ScoutDrop3.Text != "Select_Name")
                {
                    if (alreadySelected.Contains(this.ScoutDrop3.Text))
                    {
                        DialogResult dialogResult = MessageBox.Show("Box number is in more then one spot", "OK", MessageBoxButtons.OK);
                        break;
                    }
                    else
                    {
                        alreadySelected.Add(this.ScoutDrop3.Text);
                        newPositions.Add(this.ScoutDrop3.Text);
                    }
                }
                else
                {
                    newPositions.Add(RobotState.SCOUTER_NAME.Select_Name.ToString());
                }

                if (this.ScoutDrop4.Text != "" && this.ScoutDrop4.Text != "Select_Name")
                {
                    if (alreadySelected.Contains(this.ScoutDrop4.Text))
                    {
                        DialogResult dialogResult = MessageBox.Show("Box number is in more then one spot", "OK", MessageBoxButtons.OK);
                        break;
                    }
                    else
                    {
                        alreadySelected.Add(this.ScoutDrop4.Text);
                        newPositions.Add(this.ScoutDrop4.Text);
                    }
                }
                else
                {
                    newPositions.Add(RobotState.SCOUTER_NAME.Select_Name.ToString());
                }

                if (this.ScoutDrop5.Text != "" && this.ScoutDrop5.Text != "Select_Name")
                {
                    if (alreadySelected.Contains(this.ScoutDrop5.Text))
                    {
                        DialogResult dialogResult = MessageBox.Show("Scouter is in more then one spot", "OK", MessageBoxButtons.OK);
                        break;
                    }
                    else
                    {
                        alreadySelected.Add(this.ScoutDrop5.Text);
                        newPositions.Add(this.ScoutDrop5.Text);
                    }
                }
                else
                {
                    newPositions.Add(RobotState.SCOUTER_NAME.Select_Name.ToString());
                }

                check = false;

                for (int i = 0; i < 6; i++)
                {
                    Controllers.controllerNumberMap[i] = i;
                    Controllers.rs[i]._ScouterName = RobotState.SCOUTER_NAME.Select_Name;
                }

                var locations = new List<int>() { 0, 1, 2, 3, 4, 5 };

                for (int i = 0; i < 6; i++) //for each of the new positions
                {
                    //get the key associated with the name, ignoring Select_Name
                    Enum.TryParse<RobotState.SCOUTER_NAME>(newPositions[i], true, out RobotState.SCOUTER_NAME Result);
                    if (Result != RobotState.SCOUTER_NAME.Select_Name)
                    {
                        var key = Controllers.ScouterNameMap.FirstOrDefault(x => x.Value == Result).Key;
                        Controllers.controllerNumberMap[key] = i;
                        Controllers.controllerNumberMap[i] = -1;
                        locations.Remove(i);
                        Controllers.rs[i]._ScouterName = Controllers.ScouterNameMap[key];
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (Controllers.controllerNumberMap[i] == -1)
                    {
                        Controllers.controllerNumberMap[i] = locations[0];
                        locations.RemoveAt(0);
                    }
                }

                this.Hide();
            }
        }
    }
}
