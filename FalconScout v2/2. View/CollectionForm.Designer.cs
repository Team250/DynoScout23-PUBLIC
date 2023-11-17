namespace FalconScout_v2017
{
    partial class MainScreen
    {
        ///<summary>
        ///Required designer variable.
        ///</summary>
        private System.ComponentModel.IContainer components = null;

        ///<summary>
        ///Clean up any resources being used.
        ///</summary>
        ///<param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        ///<summary>
        ///Required method for Designer support - do not modify
        ///the contents of this method with the code editor.
        ///</summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.lstLog = new System.Windows.Forms.ListBox();
            this.timerJoysticks = new System.Windows.Forms.Timer(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.btnpopulateForEvent = new System.Windows.Forms.Button();
            this.btnPreviousMatch = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btnInitialDBLoad = new System.Windows.Forms.Button();
            this.btnNextMatch = new System.Windows.Forms.Button();
            this.comboBoxSelectRegional = new System.Windows.Forms.ComboBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.btnStartMatch = new System.Windows.Forms.Button();
            this.lblMatch = new System.Windows.Forms.Label();
            this.lbl0ModeValue = new System.Windows.Forms.Label();
            this.lbl0Position3 = new System.Windows.Forms.Label();
            this.lbl0Position5 = new System.Windows.Forms.Label();
            this.lbl0Position3aValue = new System.Windows.Forms.Label();
            this.lbl0Position9bValue = new System.Windows.Forms.Label();
            this.lbl0Position10 = new System.Windows.Forms.Label();
            this.lbl0Position5Value = new System.Windows.Forms.Label();
            this.lbl0Position7 = new System.Windows.Forms.Label();
            this.lbl0ScoutName = new System.Windows.Forms.Label();
            this.lbl0TeamName = new System.Windows.Forms.Label();
            this.lbl0Position8 = new System.Windows.Forms.Label();
            this.lbl0Position8Value = new System.Windows.Forms.Label();
            this.lbl0Position7Value = new System.Windows.Forms.Label();
            this.lbl0Position9aValue = new System.Windows.Forms.Label();
            this.team1 = new System.Windows.Forms.Panel();
            this.lbl0Position10Value = new System.Windows.Forms.Label();
            this.lbl0Position1 = new System.Windows.Forms.Label();
            this.lbl0SelectColor = new System.Windows.Forms.Label();
            this.lbl0Position2 = new System.Windows.Forms.Label();
            this.lbl0Position3cValue = new System.Windows.Forms.Label();
            this.lbl0Position3bValue = new System.Windows.Forms.Label();
            this.lbl0Position9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.lblkey = new System.Windows.Forms.Label();
            this.eventSummaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelMatch = new System.Windows.Forms.Label();
            this.eventSummaryBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl0Position4 = new System.Windows.Forms.Label();
            this.lbl0Position6a = new System.Windows.Forms.Label();
            this.lbl0Position6aValue = new System.Windows.Forms.Label();
            this.lbl0Position6bValue = new System.Windows.Forms.Label();
            this.lbl0Position6b = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            this.team1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventSummaryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventSummaryBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstLog
            // 
            this.lstLog.BackColor = System.Drawing.Color.Black;
            this.lstLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstLog.ForeColor = System.Drawing.Color.White;
            this.lstLog.FormattingEnabled = true;
            this.lstLog.ItemHeight = 31;
            this.lstLog.Location = new System.Drawing.Point(8, 728);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(1010, 0);
            this.lstLog.TabIndex = 1;
            this.lstLog.SelectedIndexChanged += new System.EventHandler(this.lstLog_SelectedIndexChanged);
            // 
            // timerJoysticks
            // 
            this.timerJoysticks.Interval = 50;
            this.timerJoysticks.Tick += new System.EventHandler(this.JoyStickReader);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Black;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Crimson;
            this.btnExit.Location = new System.Drawing.Point(922, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 23);
            this.btnExit.TabIndex = 228;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnpopulateForEvent
            // 
            this.btnpopulateForEvent.BackColor = System.Drawing.Color.Black;
            this.btnpopulateForEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpopulateForEvent.ForeColor = System.Drawing.Color.Navy;
            this.btnpopulateForEvent.Location = new System.Drawing.Point(414, 6);
            this.btnpopulateForEvent.Name = "btnpopulateForEvent";
            this.btnpopulateForEvent.Size = new System.Drawing.Size(102, 23);
            this.btnpopulateForEvent.TabIndex = 232;
            this.btnpopulateForEvent.Text = "Get Matches";
            this.btnpopulateForEvent.UseVisualStyleBackColor = true;
            this.btnpopulateForEvent.Click += new System.EventHandler(this.btnpopulateForEvent_Click);
            // 
            // btnPreviousMatch
            // 
            this.btnPreviousMatch.BackColor = System.Drawing.Color.Black;
            this.btnPreviousMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreviousMatch.ForeColor = System.Drawing.Color.Navy;
            this.btnPreviousMatch.Location = new System.Drawing.Point(516, 6);
            this.btnPreviousMatch.Name = "btnPreviousMatch";
            this.btnPreviousMatch.Size = new System.Drawing.Size(36, 23);
            this.btnPreviousMatch.TabIndex = 241;
            this.btnPreviousMatch.Text = "<<";
            this.btnPreviousMatch.UseVisualStyleBackColor = true;
            this.btnPreviousMatch.Click += new System.EventHandler(this.btnPreviousMatch_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label14.Location = new System.Drawing.Point(184, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 62);
            this.label14.TabIndex = 244;
            this.label14.Text = "Event:\r\n\r\n";
            // 
            // btnInitialDBLoad
            // 
            this.btnInitialDBLoad.BackColor = System.Drawing.Color.Black;
            this.btnInitialDBLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInitialDBLoad.ForeColor = System.Drawing.Color.Navy;
            this.btnInitialDBLoad.Location = new System.Drawing.Point(103, 6);
            this.btnInitialDBLoad.Name = "btnInitialDBLoad";
            this.btnInitialDBLoad.Size = new System.Drawing.Size(83, 23);
            this.btnInitialDBLoad.TabIndex = 243;
            this.btnInitialDBLoad.Text = "Load >";
            this.btnInitialDBLoad.UseVisualStyleBackColor = true;
            this.btnInitialDBLoad.Click += new System.EventHandler(this.btnInitialDBLoad_Click);
            // 
            // btnNextMatch
            // 
            this.btnNextMatch.BackColor = System.Drawing.Color.Black;
            this.btnNextMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextMatch.ForeColor = System.Drawing.Color.Navy;
            this.btnNextMatch.Location = new System.Drawing.Point(657, 6);
            this.btnNextMatch.Name = "btnNextMatch";
            this.btnNextMatch.Size = new System.Drawing.Size(36, 23);
            this.btnNextMatch.TabIndex = 253;
            this.btnNextMatch.Text = ">>";
            this.btnNextMatch.UseVisualStyleBackColor = true;
            this.btnNextMatch.Click += new System.EventHandler(this.btnNextMatch_Click);
            // 
            // comboBoxSelectRegional
            // 
            this.comboBoxSelectRegional.DisplayMember = "event_code";
            this.comboBoxSelectRegional.FormattingEnabled = true;
            this.comboBoxSelectRegional.Location = new System.Drawing.Point(220, 7);
            this.comboBoxSelectRegional.Name = "comboBoxSelectRegional";
            this.comboBoxSelectRegional.Size = new System.Drawing.Size(191, 39);
            this.comboBoxSelectRegional.TabIndex = 254;
            this.comboBoxSelectRegional.Text = "Please press the Load Events Button...";
            this.comboBoxSelectRegional.ValueMember = "event_code";
            this.comboBoxSelectRegional.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectRegional_SelectedIndexChanged);
            // 
            // pictureBox14
            // 
            this.pictureBox14.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox14.Image")));
            this.pictureBox14.Location = new System.Drawing.Point(963, 2);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(55, 28);
            this.pictureBox14.TabIndex = 261;
            this.pictureBox14.TabStop = false;
            // 
            // btnStartMatch
            // 
            this.btnStartMatch.BackColor = System.Drawing.Color.Black;
            this.btnStartMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartMatch.ForeColor = System.Drawing.Color.Navy;
            this.btnStartMatch.Location = new System.Drawing.Point(693, 6);
            this.btnStartMatch.Name = "btnStartMatch";
            this.btnStartMatch.Size = new System.Drawing.Size(81, 23);
            this.btnStartMatch.TabIndex = 262;
            this.btnStartMatch.Text = "Set Field";
            this.btnStartMatch.UseVisualStyleBackColor = true;
            this.btnStartMatch.Click += new System.EventHandler(this.btnStartMatch_Click);
            // 
            // lblMatch
            // 
            this.lblMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblMatch.Location = new System.Drawing.Point(619, 6);
            this.lblMatch.Name = "lblMatch";
            this.lblMatch.Size = new System.Drawing.Size(36, 23);
            this.lblMatch.TabIndex = 264;
            this.lblMatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMatch.Click += new System.EventHandler(this.lblMatch_Click);
            // 
            // lbl0ModeValue
            // 
            this.lbl0ModeValue.AutoSize = true;
            this.lbl0ModeValue.BackColor = System.Drawing.Color.Black;
            this.lbl0ModeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0ModeValue.ForeColor = System.Drawing.Color.LimeGreen;
            this.lbl0ModeValue.Location = new System.Drawing.Point(0, 0);
            this.lbl0ModeValue.Name = "lbl0ModeValue";
            this.lbl0ModeValue.Size = new System.Drawing.Size(144, 31);
            this.lbl0ModeValue.TabIndex = 2;
            this.lbl0ModeValue.Text = "Auto Mode";
            this.lbl0ModeValue.Click += new System.EventHandler(this.lbl1ModeValue_Click);
            // 
            // lbl0Position3
            // 
            this.lbl0Position3.AutoSize = true;
            this.lbl0Position3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position3.ForeColor = System.Drawing.Color.White;
            this.lbl0Position3.Location = new System.Drawing.Point(2, 66);
            this.lbl0Position3.Name = "lbl0Position3";
            this.lbl0Position3.Size = new System.Drawing.Size(128, 24);
            this.lbl0Position3.TabIndex = 7;
            this.lbl0Position3.Text = "lbl0Position3";
            this.lbl0Position3.Click += new System.EventHandler(this.lbl0Position1_Click);
            // 
            // lbl0Position5
            // 
            this.lbl0Position5.AutoSize = true;
            this.lbl0Position5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position5.ForeColor = System.Drawing.Color.White;
            this.lbl0Position5.Location = new System.Drawing.Point(3, 120);
            this.lbl0Position5.Name = "lbl0Position5";
            this.lbl0Position5.Size = new System.Drawing.Size(128, 24);
            this.lbl0Position5.TabIndex = 8;
            this.lbl0Position5.Text = "lbl0Position5";
            // 
            // lbl0Position3aValue
            // 
            this.lbl0Position3aValue.AutoSize = true;
            this.lbl0Position3aValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position3aValue.ForeColor = System.Drawing.Color.Yellow;
            this.lbl0Position3aValue.Location = new System.Drawing.Point(174, 66);
            this.lbl0Position3aValue.Name = "lbl0Position3aValue";
            this.lbl0Position3aValue.Size = new System.Drawing.Size(25, 26);
            this.lbl0Position3aValue.TabIndex = 12;
            this.lbl0Position3aValue.Text = "0";
            // 
            // lbl0Position9bValue
            // 
            this.lbl0Position9bValue.AutoSize = true;
            this.lbl0Position9bValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position9bValue.ForeColor = System.Drawing.Color.Yellow;
            this.lbl0Position9bValue.Location = new System.Drawing.Point(272, 240);
            this.lbl0Position9bValue.Name = "lbl0Position9bValue";
            this.lbl0Position9bValue.Size = new System.Drawing.Size(25, 26);
            this.lbl0Position9bValue.TabIndex = 15;
            this.lbl0Position9bValue.Text = "0";
            this.lbl0Position9bValue.Click += new System.EventHandler(this.lbl1HeightValue_Click);
            // 
            // lbl0Position10
            // 
            this.lbl0Position10.AutoSize = true;
            this.lbl0Position10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position10.ForeColor = System.Drawing.Color.White;
            this.lbl0Position10.Location = new System.Drawing.Point(3, 270);
            this.lbl0Position10.Name = "lbl0Position10";
            this.lbl0Position10.Size = new System.Drawing.Size(139, 24);
            this.lbl0Position10.TabIndex = 22;
            this.lbl0Position10.Text = "lbl0Position10";
            this.lbl0Position10.Visible = false;
            this.lbl0Position10.Click += new System.EventHandler(this.lbl1Fouls_Click);
            // 
            // lbl0Position5Value
            // 
            this.lbl0Position5Value.AutoSize = true;
            this.lbl0Position5Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position5Value.ForeColor = System.Drawing.Color.Yellow;
            this.lbl0Position5Value.Location = new System.Drawing.Point(174, 120);
            this.lbl0Position5Value.Name = "lbl0Position5Value";
            this.lbl0Position5Value.Size = new System.Drawing.Size(42, 26);
            this.lbl0Position5Value.TabIndex = 30;
            this.lbl0Position5Value.Text = "No";
            this.lbl0Position5Value.Click += new System.EventHandler(this.lbl1TotesValue_Click);
            // 
            // lbl0Position7
            // 
            this.lbl0Position7.AutoSize = true;
            this.lbl0Position7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position7.ForeColor = System.Drawing.Color.White;
            this.lbl0Position7.Location = new System.Drawing.Point(3, 180);
            this.lbl0Position7.Name = "lbl0Position7";
            this.lbl0Position7.Size = new System.Drawing.Size(128, 24);
            this.lbl0Position7.TabIndex = 55;
            this.lbl0Position7.Text = "lbl0Position7";
            // 
            // lbl0ScoutName
            // 
            this.lbl0ScoutName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl0ScoutName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0ScoutName.ForeColor = System.Drawing.Color.Goldenrod;
            this.lbl0ScoutName.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl0ScoutName.Location = new System.Drawing.Point(1, 301);
            this.lbl0ScoutName.Name = "lbl0ScoutName";
            this.lbl0ScoutName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl0ScoutName.Size = new System.Drawing.Size(219, 27);
            this.lbl0ScoutName.TabIndex = 247;
            this.lbl0ScoutName.Text = "Select Name";
            this.lbl0ScoutName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl0ScoutName.Click += new System.EventHandler(this.lbl0ScoutName_Click);
            // 
            // lbl0TeamName
            // 
            this.lbl0TeamName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl0TeamName.BackColor = System.Drawing.Color.Black;
            this.lbl0TeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0TeamName.ForeColor = System.Drawing.Color.Goldenrod;
            this.lbl0TeamName.Location = new System.Drawing.Point(172, 291);
            this.lbl0TeamName.Name = "lbl0TeamName";
            this.lbl0TeamName.Size = new System.Drawing.Size(157, 37);
            this.lbl0TeamName.TabIndex = 248;
            this.lbl0TeamName.Text = "Team 1";
            this.lbl0TeamName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl0TeamName.Click += new System.EventHandler(this.lbl1TeamName_Click);
            // 
            // lbl0Position8
            // 
            this.lbl0Position8.AutoSize = true;
            this.lbl0Position8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position8.ForeColor = System.Drawing.Color.White;
            this.lbl0Position8.Location = new System.Drawing.Point(3, 210);
            this.lbl0Position8.Name = "lbl0Position8";
            this.lbl0Position8.Size = new System.Drawing.Size(127, 24);
            this.lbl0Position8.TabIndex = 249;
            this.lbl0Position8.Text = "lbl0position8";
            this.lbl0Position8.Click += new System.EventHandler(this.lbl1Zone_Click);
            // 
            // lbl0Position8Value
            // 
            this.lbl0Position8Value.AutoSize = true;
            this.lbl0Position8Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position8Value.ForeColor = System.Drawing.Color.Yellow;
            this.lbl0Position8Value.Location = new System.Drawing.Point(174, 210);
            this.lbl0Position8Value.Name = "lbl0Position8Value";
            this.lbl0Position8Value.Size = new System.Drawing.Size(25, 26);
            this.lbl0Position8Value.TabIndex = 250;
            this.lbl0Position8Value.Text = "0";
            this.lbl0Position8Value.Click += new System.EventHandler(this.lbl0Position7Value_Click);
            // 
            // lbl0Position7Value
            // 
            this.lbl0Position7Value.AutoSize = true;
            this.lbl0Position7Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position7Value.ForeColor = System.Drawing.Color.Yellow;
            this.lbl0Position7Value.Location = new System.Drawing.Point(174, 178);
            this.lbl0Position7Value.Name = "lbl0Position7Value";
            this.lbl0Position7Value.Size = new System.Drawing.Size(210, 26);
            this.lbl0Position7Value.TabIndex = 252;
            this.lbl0Position7Value.Text = "lbl0Position7Value";
            this.lbl0Position7Value.Click += new System.EventHandler(this.lbl1CoOp_or_YellowTotesValue_Click);
            // 
            // lbl0Position9aValue
            // 
            this.lbl0Position9aValue.AutoSize = true;
            this.lbl0Position9aValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position9aValue.ForeColor = System.Drawing.Color.Yellow;
            this.lbl0Position9aValue.Location = new System.Drawing.Point(174, 240);
            this.lbl0Position9aValue.Name = "lbl0Position9aValue";
            this.lbl0Position9aValue.Size = new System.Drawing.Size(68, 26);
            this.lbl0Position9aValue.TabIndex = 254;
            this.lbl0Position9aValue.Text = "None";
            // 
            // team1
            // 
            this.team1.BackColor = System.Drawing.Color.Black;
            this.team1.Controls.Add(this.lbl0Position6bValue);
            this.team1.Controls.Add(this.lbl0Position6b);
            this.team1.Controls.Add(this.lbl0Position6a);
            this.team1.Controls.Add(this.lbl0Position6aValue);
            this.team1.Controls.Add(this.lbl0Position4);
            this.team1.Controls.Add(this.lbl0Position10Value);
            this.team1.Controls.Add(this.lbl0Position1);
            this.team1.Controls.Add(this.lbl0SelectColor);
            this.team1.Controls.Add(this.lbl0Position2);
            this.team1.Controls.Add(this.lbl0Position3cValue);
            this.team1.Controls.Add(this.lbl0Position3bValue);
            this.team1.Controls.Add(this.lbl0Position9);
            this.team1.Controls.Add(this.lbl0Position9aValue);
            this.team1.Controls.Add(this.lbl0Position7Value);
            this.team1.Controls.Add(this.lbl0Position8);
            this.team1.Controls.Add(this.lbl0TeamName);
            this.team1.Controls.Add(this.lbl0ScoutName);
            this.team1.Controls.Add(this.lbl0Position7);
            this.team1.Controls.Add(this.lbl0Position5Value);
            this.team1.Controls.Add(this.lbl0Position10);
            this.team1.Controls.Add(this.lbl0Position9bValue);
            this.team1.Controls.Add(this.lbl0Position3aValue);
            this.team1.Controls.Add(this.lbl0Position5);
            this.team1.Controls.Add(this.lbl0Position3);
            this.team1.Controls.Add(this.lbl0ModeValue);
            this.team1.Controls.Add(this.lbl0Position8Value);
            this.team1.Location = new System.Drawing.Point(3, 5);
            this.team1.Name = "team1";
            this.team1.Size = new System.Drawing.Size(330, 330);
            this.team1.TabIndex = 0;
            // 
            // lbl0Position10Value
            // 
            this.lbl0Position10Value.AutoSize = true;
            this.lbl0Position10Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position10Value.ForeColor = System.Drawing.Color.Yellow;
            this.lbl0Position10Value.Location = new System.Drawing.Point(174, 270);
            this.lbl0Position10Value.Name = "lbl0Position10Value";
            this.lbl0Position10Value.Size = new System.Drawing.Size(25, 26);
            this.lbl0Position10Value.TabIndex = 266;
            this.lbl0Position10Value.Text = "0";
            // 
            // lbl0Position1
            // 
            this.lbl0Position1.AutoSize = true;
            this.lbl0Position1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position1.ForeColor = System.Drawing.Color.White;
            this.lbl0Position1.Location = new System.Drawing.Point(3, 36);
            this.lbl0Position1.Name = "lbl0Position1";
            this.lbl0Position1.Size = new System.Drawing.Size(128, 24);
            this.lbl0Position1.TabIndex = 265;
            this.lbl0Position1.Text = "lbl0Position1";
            // 
            // lbl0SelectColor
            // 
            this.lbl0SelectColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl0SelectColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0SelectColor.ForeColor = System.Drawing.Color.Black;
            this.lbl0SelectColor.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl0SelectColor.Location = new System.Drawing.Point(153, 300);
            this.lbl0SelectColor.Name = "lbl0SelectColor";
            this.lbl0SelectColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl0SelectColor.Size = new System.Drawing.Size(28, 27);
            this.lbl0SelectColor.TabIndex = 262;
            this.lbl0SelectColor.Text = "Red";
            this.lbl0SelectColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl0SelectColor.Visible = false;
            // 
            // lbl0Position2
            // 
            this.lbl0Position2.AutoSize = true;
            this.lbl0Position2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position2.ForeColor = System.Drawing.Color.White;
            this.lbl0Position2.Location = new System.Drawing.Point(165, 36);
            this.lbl0Position2.Name = "lbl0Position2";
            this.lbl0Position2.Size = new System.Drawing.Size(128, 24);
            this.lbl0Position2.TabIndex = 263;
            this.lbl0Position2.Text = "lbl0Position2";
            this.lbl0Position2.Click += new System.EventHandler(this.lbl0Position2_Click);
            // 
            // lbl0Position3cValue
            // 
            this.lbl0Position3cValue.AutoSize = true;
            this.lbl0Position3cValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position3cValue.ForeColor = System.Drawing.Color.Yellow;
            this.lbl0Position3cValue.Location = new System.Drawing.Point(272, 66);
            this.lbl0Position3cValue.Name = "lbl0Position3cValue";
            this.lbl0Position3cValue.Size = new System.Drawing.Size(25, 26);
            this.lbl0Position3cValue.TabIndex = 257;
            this.lbl0Position3cValue.Text = "0";
            // 
            // lbl0Position3bValue
            // 
            this.lbl0Position3bValue.AutoSize = true;
            this.lbl0Position3bValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position3bValue.ForeColor = System.Drawing.Color.Yellow;
            this.lbl0Position3bValue.Location = new System.Drawing.Point(228, 66);
            this.lbl0Position3bValue.Name = "lbl0Position3bValue";
            this.lbl0Position3bValue.Size = new System.Drawing.Size(25, 26);
            this.lbl0Position3bValue.TabIndex = 256;
            this.lbl0Position3bValue.Text = "0";
            // 
            // lbl0Position9
            // 
            this.lbl0Position9.AutoSize = true;
            this.lbl0Position9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position9.ForeColor = System.Drawing.Color.White;
            this.lbl0Position9.Location = new System.Drawing.Point(3, 240);
            this.lbl0Position9.Name = "lbl0Position9";
            this.lbl0Position9.Size = new System.Drawing.Size(128, 24);
            this.lbl0Position9.TabIndex = 255;
            this.lbl0Position9.Text = "lbl0Position9";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.team1);
            this.panel1.Location = new System.Drawing.Point(2, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 343);
            this.panel1.TabIndex = 246;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkBlue;
            this.panel2.Location = new System.Drawing.Point(1, 380);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1017, 342);
            this.panel2.TabIndex = 260;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Navy;
            this.button1.Location = new System.Drawing.Point(773, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 23);
            this.button1.TabIndex = 258;
            this.button1.Text = "Pit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblkey
            // 
            this.lblkey.AutoSize = true;
            this.lblkey.BackColor = System.Drawing.Color.Black;
            this.lblkey.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblkey.Location = new System.Drawing.Point(5, 722);
            this.lblkey.Name = "lblkey";
            this.lblkey.Size = new System.Drawing.Size(84, 31);
            this.lblkey.TabIndex = 265;
            this.lblkey.Text = "lblkey";
            this.lblkey.Visible = false;
            // 
            // labelMatch
            // 
            this.labelMatch.AutoSize = true;
            this.labelMatch.BackColor = System.Drawing.Color.Black;
            this.labelMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMatch.ForeColor = System.Drawing.Color.LimeGreen;
            this.labelMatch.Location = new System.Drawing.Point(553, 5);
            this.labelMatch.Name = "labelMatch";
            this.labelMatch.Size = new System.Drawing.Size(66, 24);
            this.labelMatch.TabIndex = 259;
            this.labelMatch.Text = "Match:";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Navy;
            this.button2.Location = new System.Drawing.Point(819, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 23);
            this.button2.TabIndex = 267;
            this.button2.Text = "Preview Rpt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 28);
            this.pictureBox1.TabIndex = 268;
            this.pictureBox1.TabStop = false;
            // 
            // lbl0Position4
            // 
            this.lbl0Position4.AutoSize = true;
            this.lbl0Position4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position4.ForeColor = System.Drawing.Color.White;
            this.lbl0Position4.Location = new System.Drawing.Point(2, 93);
            this.lbl0Position4.Name = "lbl0Position4";
            this.lbl0Position4.Size = new System.Drawing.Size(128, 24);
            this.lbl0Position4.TabIndex = 267;
            this.lbl0Position4.Text = "lbl0Position4";
            // 
            // lbl0Position6a
            // 
            this.lbl0Position6a.AutoSize = true;
            this.lbl0Position6a.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position6a.ForeColor = System.Drawing.Color.White;
            this.lbl0Position6a.Location = new System.Drawing.Point(4, 148);
            this.lbl0Position6a.Name = "lbl0Position6a";
            this.lbl0Position6a.Size = new System.Drawing.Size(139, 24);
            this.lbl0Position6a.TabIndex = 253;
            this.lbl0Position6a.Text = "lbl0Position6a";
            // 
            // lbl0Position6aValue
            // 
            this.lbl0Position6aValue.AutoSize = true;
            this.lbl0Position6aValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position6aValue.ForeColor = System.Drawing.Color.Yellow;
            this.lbl0Position6aValue.Location = new System.Drawing.Point(128, 148);
            this.lbl0Position6aValue.Name = "lbl0Position6aValue";
            this.lbl0Position6aValue.Size = new System.Drawing.Size(223, 26);
            this.lbl0Position6aValue.TabIndex = 252;
            this.lbl0Position6aValue.Text = "lbl0Position6aValue";
            // 
            // lbl0Position6bValue
            // 
            this.lbl0Position6bValue.AutoSize = true;
            this.lbl0Position6bValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position6bValue.ForeColor = System.Drawing.Color.Yellow;
            this.lbl0Position6bValue.Location = new System.Drawing.Point(278, 149);
            this.lbl0Position6bValue.Name = "lbl0Position6bValue";
            this.lbl0Position6bValue.Size = new System.Drawing.Size(223, 26);
            this.lbl0Position6bValue.TabIndex = 269;
            this.lbl0Position6bValue.Text = "lbl0Position6bValue";
            // 
            // lbl0Position6b
            // 
            this.lbl0Position6b.AutoSize = true;
            this.lbl0Position6b.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0Position6b.ForeColor = System.Drawing.Color.White;
            this.lbl0Position6b.Location = new System.Drawing.Point(153, 149);
            this.lbl0Position6b.Name = "lbl0Position6b";
            this.lbl0Position6b.Size = new System.Drawing.Size(139, 24);
            this.lbl0Position6b.TabIndex = 268;
            this.lbl0Position6b.Text = "lbl0Position6a";
            // 
            // MainScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1309, 740);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labelMatch);
            this.Controls.Add(this.lblkey);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnStartMatch);
            this.Controls.Add(this.btnInitialDBLoad);
            this.Controls.Add(this.pictureBox14);
            this.Controls.Add(this.comboBoxSelectRegional);
            this.Controls.Add(this.btnNextMatch);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblMatch);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.btnPreviousMatch);
            this.Controls.Add(this.btnpopulateForEvent);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainScreen";
            this.Text = "Falcon Scouting Software 2014";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.falconScoutingSystemForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            this.team1.ResumeLayout(false);
            this.team1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventSummaryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventSummaryBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //API Start
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Timer timerJoysticks;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnpopulateForEvent;
        private System.Windows.Forms.Button btnPreviousMatch;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnInitialDBLoad;
        private System.Windows.Forms.Button btnNextMatch;
        private System.Windows.Forms.ComboBox comboBoxSelectRegional;
        private System.Windows.Forms.BindingSource eventSummaryBindingSource;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.Button btnStartMatch;
        private System.Windows.Forms.BindingSource eventSummaryBindingSource1;
        private System.Windows.Forms.Label lblMatch;
        private System.Windows.Forms.Label lbl0ModeValue;
        private System.Windows.Forms.Label lbl0Position3;
        private System.Windows.Forms.Label lbl0Position5;
        private System.Windows.Forms.Label lbl0Position3aValue;
        private System.Windows.Forms.Label lbl0Position9bValue;
        private System.Windows.Forms.Label lbl0Position10;
        private System.Windows.Forms.Label lbl0Position5Value;
        private System.Windows.Forms.Label lbl0Position7;
        // private System.Windows.Forms.Label lbl1Position3Value;
        private System.Windows.Forms.Label lbl0ScoutName;
        private System.Windows.Forms.Label lbl0TeamName;
        private System.Windows.Forms.Label lbl0Position8;
        private System.Windows.Forms.Label lbl0Position8Value;
        private System.Windows.Forms.Label lbl0Position7Value;
        private System.Windows.Forms.Label lbl0Position9aValue;
        private System.Windows.Forms.Panel team1;
        private System.Windows.Forms.Label lbl0Position9;
        private System.Windows.Forms.Label lbl0Position3bValue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblkey;
        private System.Windows.Forms.Label labelMatch;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbl0SelectColor;
        private System.Windows.Forms.Label lbl0Position1;
        private System.Windows.Forms.Label lbl0Position2;
        private System.Windows.Forms.Label lbl0Position3cValue;
        private System.Windows.Forms.Label lbl0Position10Value;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl0Position4;
        private System.Windows.Forms.Label lbl0Position6a;
        private System.Windows.Forms.Label lbl0Position6aValue;
        private System.Windows.Forms.Label lbl0Position6bValue;
        private System.Windows.Forms.Label lbl0Position6b;
    }
}
