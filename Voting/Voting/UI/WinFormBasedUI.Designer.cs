namespace Voting
{
    partial class WinFormBasedUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lsConstituency = new System.Windows.Forms.ListBox();
            this.btnProcessData = new System.Windows.Forms.Button();
            this.grpProcessing = new System.Windows.Forms.GroupBox();
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.lblStatusLabel = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.MainMenu = new System.Windows.Forms.TabPage();
            this.lblTitle = new System.Windows.Forms.Label();
            this.ConstituencyData = new System.Windows.Forms.TabPage();
            this.grpChoose = new System.Windows.Forms.GroupBox();
            this.btnShowElected = new System.Windows.Forms.Button();
            this.cboConstituencys = new System.Windows.Forms.ComboBox();
            this.lblCandidates = new System.Windows.Forms.Label();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.btnShowDetails = new System.Windows.Forms.Button();
            this.PartyData = new System.Windows.Forms.TabPage();
            this.grpPartyOptions = new System.Windows.Forms.GroupBox();
            this.btnPartyAlpha = new System.Windows.Forms.Button();
            this.btnPartyVotes = new System.Windows.Forms.Button();
            this.btnShowWinner = new System.Windows.Forms.Button();
            this.btnPartyDetails = new System.Windows.Forms.Button();
            this.lsPartyDetails = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.lsFileList = new System.Windows.Forms.ListBox();
            this.btnRemoveFile = new System.Windows.Forms.Button();
            this.grpProcessing.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.ConstituencyData.SuspendLayout();
            this.grpChoose.SuspendLayout();
            this.PartyData.SuspendLayout();
            this.grpPartyOptions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsConstituency
            // 
            this.lsConstituency.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsConstituency.FormattingEnabled = true;
            this.lsConstituency.ItemHeight = 14;
            this.lsConstituency.Location = new System.Drawing.Point(57, 162);
            this.lsConstituency.Name = "lsConstituency";
            this.lsConstituency.Size = new System.Drawing.Size(267, 144);
            this.lsConstituency.TabIndex = 1;
            // 
            // btnProcessData
            // 
            this.btnProcessData.Enabled = false;
            this.btnProcessData.Location = new System.Drawing.Point(117, 19);
            this.btnProcessData.Name = "btnProcessData";
            this.btnProcessData.Size = new System.Drawing.Size(97, 59);
            this.btnProcessData.TabIndex = 2;
            this.btnProcessData.Text = "Generate Political Data";
            this.btnProcessData.UseVisualStyleBackColor = true;
            this.btnProcessData.Click += new System.EventHandler(this.btnProcessData_Click);
            // 
            // grpProcessing
            // 
            this.grpProcessing.Controls.Add(this.txtProgress);
            this.grpProcessing.Controls.Add(this.lblStatusLabel);
            this.grpProcessing.Controls.Add(this.btnProcessData);
            this.grpProcessing.Location = new System.Drawing.Point(68, 192);
            this.grpProcessing.Name = "grpProcessing";
            this.grpProcessing.Size = new System.Drawing.Size(346, 118);
            this.grpProcessing.TabIndex = 3;
            this.grpProcessing.TabStop = false;
            this.grpProcessing.Text = "Processing Data";
            // 
            // txtProgress
            // 
            this.txtProgress.BackColor = System.Drawing.Color.White;
            this.txtProgress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProgress.Location = new System.Drawing.Point(53, 93);
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.ReadOnly = true;
            this.txtProgress.Size = new System.Drawing.Size(287, 13);
            this.txtProgress.TabIndex = 4;
            this.txtProgress.Text = "Not started. Press button above to start";
            // 
            // lblStatusLabel
            // 
            this.lblStatusLabel.AutoSize = true;
            this.lblStatusLabel.Location = new System.Drawing.Point(7, 93);
            this.lblStatusLabel.Name = "lblStatusLabel";
            this.lblStatusLabel.Size = new System.Drawing.Size(40, 13);
            this.lblStatusLabel.TabIndex = 3;
            this.lblStatusLabel.Text = "Status:";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.MainMenu);
            this.tabControl.Controls.Add(this.ConstituencyData);
            this.tabControl.Controls.Add(this.PartyData);
            this.tabControl.Location = new System.Drawing.Point(2, 1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(490, 353);
            this.tabControl.TabIndex = 4;
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.White;
            this.MainMenu.Controls.Add(this.groupBox1);
            this.MainMenu.Controls.Add(this.lblTitle);
            this.MainMenu.Controls.Add(this.grpProcessing);
            this.MainMenu.Location = new System.Drawing.Point(4, 22);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Padding = new System.Windows.Forms.Padding(3);
            this.MainMenu.Size = new System.Drawing.Size(482, 327);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "Main Menu";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(107, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(264, 31);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Political Party Data";
            // 
            // ConstituencyData
            // 
            this.ConstituencyData.Controls.Add(this.grpChoose);
            this.ConstituencyData.Controls.Add(this.lsConstituency);
            this.ConstituencyData.Controls.Add(this.lblListTitle);
            this.ConstituencyData.Controls.Add(this.btnShowDetails);
            this.ConstituencyData.Location = new System.Drawing.Point(4, 22);
            this.ConstituencyData.Name = "ConstituencyData";
            this.ConstituencyData.Padding = new System.Windows.Forms.Padding(3);
            this.ConstituencyData.Size = new System.Drawing.Size(482, 327);
            this.ConstituencyData.TabIndex = 1;
            this.ConstituencyData.Text = "Constituency Data";
            this.ConstituencyData.UseVisualStyleBackColor = true;
            // 
            // grpChoose
            // 
            this.grpChoose.Controls.Add(this.btnShowElected);
            this.grpChoose.Controls.Add(this.cboConstituencys);
            this.grpChoose.Controls.Add(this.lblCandidates);
            this.grpChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChoose.Location = new System.Drawing.Point(77, 27);
            this.grpChoose.Name = "grpChoose";
            this.grpChoose.Size = new System.Drawing.Size(324, 86);
            this.grpChoose.TabIndex = 5;
            this.grpChoose.TabStop = false;
            this.grpChoose.Text = "Choose A Constituency or Show Elected Candidates";
            // 
            // btnShowElected
            // 
            this.btnShowElected.Enabled = false;
            this.btnShowElected.Location = new System.Drawing.Point(203, 27);
            this.btnShowElected.Name = "btnShowElected";
            this.btnShowElected.Size = new System.Drawing.Size(95, 47);
            this.btnShowElected.TabIndex = 6;
            this.btnShowElected.Text = "Show Elected Candidates";
            this.btnShowElected.UseVisualStyleBackColor = true;
            this.btnShowElected.Click += new System.EventHandler(this.btnShowElected_Click);
            // 
            // cboConstituencys
            // 
            this.cboConstituencys.BackColor = System.Drawing.Color.White;
            this.cboConstituencys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConstituencys.Enabled = false;
            this.cboConstituencys.FormattingEnabled = true;
            this.cboConstituencys.Location = new System.Drawing.Point(26, 51);
            this.cboConstituencys.Name = "cboConstituencys";
            this.cboConstituencys.Size = new System.Drawing.Size(121, 23);
            this.cboConstituencys.TabIndex = 3;
            this.cboConstituencys.SelectedIndexChanged += new System.EventHandler(this.cboConstituencys_SelectedIndexChanged);
            // 
            // lblCandidates
            // 
            this.lblCandidates.Location = new System.Drawing.Point(26, 27);
            this.lblCandidates.Name = "lblCandidates";
            this.lblCandidates.Size = new System.Drawing.Size(121, 23);
            this.lblCandidates.TabIndex = 4;
            this.lblCandidates.Text = "Constituencys";
            this.lblCandidates.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblListTitle
            // 
            this.lblListTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListTitle.Location = new System.Drawing.Point(74, 130);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(327, 25);
            this.lblListTitle.TabIndex = 4;
            this.lblListTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnShowDetails
            // 
            this.btnShowDetails.Enabled = false;
            this.btnShowDetails.Location = new System.Drawing.Point(330, 162);
            this.btnShowDetails.Name = "btnShowDetails";
            this.btnShowDetails.Size = new System.Drawing.Size(95, 47);
            this.btnShowDetails.TabIndex = 2;
            this.btnShowDetails.Text = "Show Candidate Details";
            this.btnShowDetails.UseVisualStyleBackColor = true;
            this.btnShowDetails.Click += new System.EventHandler(this.btnShowDetails_Click);
            // 
            // PartyData
            // 
            this.PartyData.Controls.Add(this.grpPartyOptions);
            this.PartyData.Controls.Add(this.btnPartyDetails);
            this.PartyData.Controls.Add(this.lsPartyDetails);
            this.PartyData.Location = new System.Drawing.Point(4, 22);
            this.PartyData.Name = "PartyData";
            this.PartyData.Size = new System.Drawing.Size(482, 327);
            this.PartyData.TabIndex = 2;
            this.PartyData.Text = "Party Data";
            this.PartyData.UseVisualStyleBackColor = true;
            // 
            // grpPartyOptions
            // 
            this.grpPartyOptions.Controls.Add(this.btnPartyAlpha);
            this.grpPartyOptions.Controls.Add(this.btnPartyVotes);
            this.grpPartyOptions.Controls.Add(this.btnShowWinner);
            this.grpPartyOptions.Location = new System.Drawing.Point(77, 38);
            this.grpPartyOptions.Name = "grpPartyOptions";
            this.grpPartyOptions.Size = new System.Drawing.Size(324, 83);
            this.grpPartyOptions.TabIndex = 7;
            this.grpPartyOptions.TabStop = false;
            this.grpPartyOptions.Text = "Choose A Party Option";
            // 
            // btnPartyAlpha
            // 
            this.btnPartyAlpha.Enabled = false;
            this.btnPartyAlpha.Location = new System.Drawing.Point(6, 30);
            this.btnPartyAlpha.Name = "btnPartyAlpha";
            this.btnPartyAlpha.Size = new System.Drawing.Size(95, 47);
            this.btnPartyAlpha.TabIndex = 3;
            this.btnPartyAlpha.Text = "Order Party Alphabetically";
            this.btnPartyAlpha.UseVisualStyleBackColor = true;
            this.btnPartyAlpha.Click += new System.EventHandler(this.btnPartyAlpha_Click);
            // 
            // btnPartyVotes
            // 
            this.btnPartyVotes.Enabled = false;
            this.btnPartyVotes.Location = new System.Drawing.Point(115, 30);
            this.btnPartyVotes.Name = "btnPartyVotes";
            this.btnPartyVotes.Size = new System.Drawing.Size(95, 47);
            this.btnPartyVotes.TabIndex = 5;
            this.btnPartyVotes.Text = "Order Party By Votes";
            this.btnPartyVotes.UseVisualStyleBackColor = true;
            this.btnPartyVotes.Click += new System.EventHandler(this.btnPartyVotes_Click);
            // 
            // btnShowWinner
            // 
            this.btnShowWinner.Enabled = false;
            this.btnShowWinner.Location = new System.Drawing.Point(223, 30);
            this.btnShowWinner.Name = "btnShowWinner";
            this.btnShowWinner.Size = new System.Drawing.Size(95, 47);
            this.btnShowWinner.TabIndex = 4;
            this.btnShowWinner.Text = "Show Election Winner";
            this.btnShowWinner.UseVisualStyleBackColor = true;
            this.btnShowWinner.Click += new System.EventHandler(this.btnShowWinner_Click);
            // 
            // btnPartyDetails
            // 
            this.btnPartyDetails.Enabled = false;
            this.btnPartyDetails.Location = new System.Drawing.Point(328, 143);
            this.btnPartyDetails.Name = "btnPartyDetails";
            this.btnPartyDetails.Size = new System.Drawing.Size(95, 47);
            this.btnPartyDetails.TabIndex = 6;
            this.btnPartyDetails.Text = "ShowParty Details";
            this.btnPartyDetails.UseVisualStyleBackColor = true;
            this.btnPartyDetails.Click += new System.EventHandler(this.btnPartyDetails_Click);
            // 
            // lsPartyDetails
            // 
            this.lsPartyDetails.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsPartyDetails.FormattingEnabled = true;
            this.lsPartyDetails.ItemHeight = 14;
            this.lsPartyDetails.Location = new System.Drawing.Point(55, 143);
            this.lsPartyDetails.Name = "lsPartyDetails";
            this.lsPartyDetails.Size = new System.Drawing.Size(267, 144);
            this.lsPartyDetails.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemoveFile);
            this.groupBox1.Controls.Add(this.lsFileList);
            this.groupBox1.Controls.Add(this.btnAddFile);
            this.groupBox1.Location = new System.Drawing.Point(68, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 118);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loading Files";
            // 
            // btnAddFile
            // 
            this.btnAddFile.Location = new System.Drawing.Point(10, 33);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(97, 59);
            this.btnAddFile.TabIndex = 2;
            this.btnAddFile.Text = "Add File To Be Processed";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // lsFileList
            // 
            this.lsFileList.FormattingEnabled = true;
            this.lsFileList.Location = new System.Drawing.Point(220, 14);
            this.lsFileList.Name = "lsFileList";
            this.lsFileList.Size = new System.Drawing.Size(120, 95);
            this.lsFileList.TabIndex = 3;
            // 
            // btnRemoveFile
            // 
            this.btnRemoveFile.Location = new System.Drawing.Point(117, 33);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(97, 59);
            this.btnRemoveFile.TabIndex = 4;
            this.btnRemoveFile.Text = "Remove File To Be Processed";
            this.btnRemoveFile.UseVisualStyleBackColor = true;
            this.btnRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // WinFormBasedUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(495, 354);
            this.Controls.Add(this.tabControl);
            this.Name = "WinFormBasedUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Political Party Data";
            this.grpProcessing.ResumeLayout(false);
            this.grpProcessing.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ConstituencyData.ResumeLayout(false);
            this.grpChoose.ResumeLayout(false);
            this.PartyData.ResumeLayout(false);
            this.grpPartyOptions.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lsConstituency;
        private System.Windows.Forms.Button btnProcessData;
        private System.Windows.Forms.GroupBox grpProcessing;
        private System.Windows.Forms.Label lblStatusLabel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage MainMenu;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabPage ConstituencyData;
        private System.Windows.Forms.TabPage PartyData;
        private System.Windows.Forms.TextBox txtProgress;
        private System.Windows.Forms.Button btnShowDetails;
        private System.Windows.Forms.ComboBox cboConstituencys;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.GroupBox grpChoose;
        private System.Windows.Forms.Button btnShowElected;
        private System.Windows.Forms.Label lblCandidates;
        private System.Windows.Forms.Button btnPartyDetails;
        private System.Windows.Forms.Button btnPartyVotes;
        private System.Windows.Forms.Button btnShowWinner;
        private System.Windows.Forms.Button btnPartyAlpha;
        private System.Windows.Forms.ListBox lsPartyDetails;
        private System.Windows.Forms.GroupBox grpPartyOptions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lsFileList;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Button btnRemoveFile;
    }
}

