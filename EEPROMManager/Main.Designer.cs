namespace EEPROMManager {
     partial class Main {
          /// <summary>
          /// Required designer variable.
          /// </summary>
          private System.ComponentModel.IContainer components = null;

          /// <summary>
          /// Clean up any resources being used.
          /// </summary>
          /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
          protected override void Dispose(bool disposing) {
               if (disposing && (components != null)) {
                    components.Dispose();
               }
               base.Dispose(disposing);
          }

          #region Windows Form Designer generated code

          /// <summary>
          /// Required method for Designer support - do not modify
          /// the contents of this method with the code editor.
          /// </summary>
          private void InitializeComponent() {
               System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
               this.groupBox1 = new System.Windows.Forms.GroupBox();
               this.samplingRateLabel = new System.Windows.Forms.Label();
               this.label2 = new System.Windows.Forms.Label();
               this.label15 = new System.Windows.Forms.Label();
               this.dataConnectionLabel = new System.Windows.Forms.Label();
               this.databitsDataLabel = new System.Windows.Forms.Label();
               this.baudRateDataLabel = new System.Windows.Forms.Label();
               this.label5 = new System.Windows.Forms.Label();
               this.label4 = new System.Windows.Forms.Label();
               this.groupBox3 = new System.Windows.Forms.GroupBox();
               this.refreshPortListButton = new System.Windows.Forms.Button();
               this.disconnectButton = new System.Windows.Forms.Button();
               this.deviceManagerButton = new System.Windows.Forms.Button();
               this.connectButton = new System.Windows.Forms.Button();
               this.deviceSelectionComboBox = new System.Windows.Forms.ComboBox();
               this.groupBox4 = new System.Windows.Forms.GroupBox();
               this.collectNewDataButton = new System.Windows.Forms.Button();
               this.requestDataButton = new System.Windows.Forms.Button();
               this.saveDataButton = new System.Windows.Forms.Button();
               this.eraseDataButton = new System.Windows.Forms.Button();
               this.groupBox6 = new System.Windows.Forms.GroupBox();
               this.serialMonitorView = new System.Windows.Forms.RichTextBox();
               this.groupBox2 = new System.Windows.Forms.GroupBox();
               this.statusMonitorView = new System.Windows.Forms.RichTextBox();
               this.menuStrip1 = new System.Windows.Forms.MenuStrip();
               this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
               this.monitorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
               this.clearStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
               this.clearSerialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
               this.groupBox1.SuspendLayout();
               this.groupBox3.SuspendLayout();
               this.groupBox4.SuspendLayout();
               this.groupBox6.SuspendLayout();
               this.groupBox2.SuspendLayout();
               this.menuStrip1.SuspendLayout();
               this.SuspendLayout();
               // 
               // groupBox1
               // 
               this.groupBox1.Controls.Add(this.samplingRateLabel);
               this.groupBox1.Controls.Add(this.label2);
               this.groupBox1.Controls.Add(this.label15);
               this.groupBox1.Controls.Add(this.dataConnectionLabel);
               this.groupBox1.Controls.Add(this.databitsDataLabel);
               this.groupBox1.Controls.Add(this.baudRateDataLabel);
               this.groupBox1.Controls.Add(this.label5);
               this.groupBox1.Controls.Add(this.label4);
               this.groupBox1.Location = new System.Drawing.Point(12, 161);
               this.groupBox1.Name = "groupBox1";
               this.groupBox1.Size = new System.Drawing.Size(218, 127);
               this.groupBox1.TabIndex = 1;
               this.groupBox1.TabStop = false;
               this.groupBox1.Text = "Device Information";
               // 
               // samplingRateLabel
               // 
               this.samplingRateLabel.BackColor = System.Drawing.SystemColors.ControlLight;
               this.samplingRateLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
               this.samplingRateLabel.Location = new System.Drawing.Point(120, 97);
               this.samplingRateLabel.MinimumSize = new System.Drawing.Size(90, 2);
               this.samplingRateLabel.Name = "samplingRateLabel";
               this.samplingRateLabel.Size = new System.Drawing.Size(90, 15);
               this.samplingRateLabel.TabIndex = 13;
               // 
               // label2
               // 
               this.label2.Location = new System.Drawing.Point(9, 98);
               this.label2.MinimumSize = new System.Drawing.Size(75, 0);
               this.label2.Name = "label2";
               this.label2.Size = new System.Drawing.Size(105, 15);
               this.label2.TabIndex = 12;
               this.label2.Text = "Sampling Rate (sec)";
               // 
               // label15
               // 
               this.label15.Location = new System.Drawing.Point(9, 26);
               this.label15.MinimumSize = new System.Drawing.Size(75, 0);
               this.label15.Name = "label15";
               this.label15.Size = new System.Drawing.Size(75, 15);
               this.label15.TabIndex = 9;
               this.label15.Text = "Device Status";
               // 
               // dataConnectionLabel
               // 
               this.dataConnectionLabel.BackColor = System.Drawing.SystemColors.ControlLight;
               this.dataConnectionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
               this.dataConnectionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
               this.dataConnectionLabel.Location = new System.Drawing.Point(120, 25);
               this.dataConnectionLabel.MinimumSize = new System.Drawing.Size(90, 2);
               this.dataConnectionLabel.Name = "dataConnectionLabel";
               this.dataConnectionLabel.Size = new System.Drawing.Size(90, 15);
               this.dataConnectionLabel.TabIndex = 10;
               this.dataConnectionLabel.Text = "Unavailable";
               // 
               // databitsDataLabel
               // 
               this.databitsDataLabel.BackColor = System.Drawing.SystemColors.ControlLight;
               this.databitsDataLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
               this.databitsDataLabel.Location = new System.Drawing.Point(120, 73);
               this.databitsDataLabel.MinimumSize = new System.Drawing.Size(90, 2);
               this.databitsDataLabel.Name = "databitsDataLabel";
               this.databitsDataLabel.Size = new System.Drawing.Size(90, 15);
               this.databitsDataLabel.TabIndex = 11;
               // 
               // baudRateDataLabel
               // 
               this.baudRateDataLabel.BackColor = System.Drawing.SystemColors.ControlLight;
               this.baudRateDataLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
               this.baudRateDataLabel.Location = new System.Drawing.Point(120, 49);
               this.baudRateDataLabel.MinimumSize = new System.Drawing.Size(90, 2);
               this.baudRateDataLabel.Name = "baudRateDataLabel";
               this.baudRateDataLabel.Size = new System.Drawing.Size(90, 15);
               this.baudRateDataLabel.TabIndex = 10;
               // 
               // label5
               // 
               this.label5.Location = new System.Drawing.Point(9, 74);
               this.label5.MinimumSize = new System.Drawing.Size(75, 0);
               this.label5.Name = "label5";
               this.label5.Size = new System.Drawing.Size(75, 15);
               this.label5.TabIndex = 4;
               this.label5.Text = "Data Bits";
               // 
               // label4
               // 
               this.label4.Location = new System.Drawing.Point(9, 50);
               this.label4.MinimumSize = new System.Drawing.Size(75, 0);
               this.label4.Name = "label4";
               this.label4.Size = new System.Drawing.Size(75, 15);
               this.label4.TabIndex = 3;
               this.label4.Text = "Baud Rate (bps)";
               // 
               // groupBox3
               // 
               this.groupBox3.Controls.Add(this.refreshPortListButton);
               this.groupBox3.Controls.Add(this.disconnectButton);
               this.groupBox3.Controls.Add(this.deviceManagerButton);
               this.groupBox3.Controls.Add(this.connectButton);
               this.groupBox3.Controls.Add(this.deviceSelectionComboBox);
               this.groupBox3.Location = new System.Drawing.Point(12, 27);
               this.groupBox3.Name = "groupBox3";
               this.groupBox3.Size = new System.Drawing.Size(218, 128);
               this.groupBox3.TabIndex = 3;
               this.groupBox3.TabStop = false;
               this.groupBox3.Text = "Device Selection";
               // 
               // refreshPortListButton
               // 
               this.refreshPortListButton.Location = new System.Drawing.Point(109, 86);
               this.refreshPortListButton.Name = "refreshPortListButton";
               this.refreshPortListButton.Size = new System.Drawing.Size(100, 30);
               this.refreshPortListButton.TabIndex = 4;
               this.refreshPortListButton.Text = "Refresh Port List";
               this.refreshPortListButton.UseVisualStyleBackColor = true;
               this.refreshPortListButton.Click += new System.EventHandler(this.refreshPortListButton_Click);
               // 
               // disconnectButton
               // 
               this.disconnectButton.Location = new System.Drawing.Point(109, 50);
               this.disconnectButton.Name = "disconnectButton";
               this.disconnectButton.Size = new System.Drawing.Size(100, 30);
               this.disconnectButton.TabIndex = 3;
               this.disconnectButton.Text = "Disconnect";
               this.disconnectButton.UseVisualStyleBackColor = true;
               this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
               // 
               // deviceManagerButton
               // 
               this.deviceManagerButton.Location = new System.Drawing.Point(6, 86);
               this.deviceManagerButton.Name = "deviceManagerButton";
               this.deviceManagerButton.Size = new System.Drawing.Size(100, 30);
               this.deviceManagerButton.TabIndex = 2;
               this.deviceManagerButton.Text = "Device Manager";
               this.deviceManagerButton.UseVisualStyleBackColor = true;
               this.deviceManagerButton.Click += new System.EventHandler(this.deviceManagerButton_Click);
               // 
               // connectButton
               // 
               this.connectButton.Location = new System.Drawing.Point(6, 50);
               this.connectButton.Name = "connectButton";
               this.connectButton.Size = new System.Drawing.Size(100, 30);
               this.connectButton.TabIndex = 1;
               this.connectButton.Text = "Connect";
               this.connectButton.UseVisualStyleBackColor = true;
               this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
               // 
               // deviceSelectionComboBox
               // 
               this.deviceSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
               this.deviceSelectionComboBox.FormattingEnabled = true;
               this.deviceSelectionComboBox.Location = new System.Drawing.Point(6, 19);
               this.deviceSelectionComboBox.Name = "deviceSelectionComboBox";
               this.deviceSelectionComboBox.Size = new System.Drawing.Size(203, 21);
               this.deviceSelectionComboBox.TabIndex = 0;
               // 
               // groupBox4
               // 
               this.groupBox4.Controls.Add(this.collectNewDataButton);
               this.groupBox4.Controls.Add(this.requestDataButton);
               this.groupBox4.Controls.Add(this.saveDataButton);
               this.groupBox4.Controls.Add(this.eraseDataButton);
               this.groupBox4.Location = new System.Drawing.Point(12, 294);
               this.groupBox4.Name = "groupBox4";
               this.groupBox4.Size = new System.Drawing.Size(218, 94);
               this.groupBox4.TabIndex = 4;
               this.groupBox4.TabStop = false;
               this.groupBox4.Text = "Device Data Control";
               // 
               // collectNewDataButton
               // 
               this.collectNewDataButton.Location = new System.Drawing.Point(108, 55);
               this.collectNewDataButton.Name = "collectNewDataButton";
               this.collectNewDataButton.Size = new System.Drawing.Size(100, 30);
               this.collectNewDataButton.TabIndex = 4;
               this.collectNewDataButton.Text = "Collect New Data";
               this.collectNewDataButton.UseVisualStyleBackColor = true;
               this.collectNewDataButton.Click += new System.EventHandler(this.collectNewDataButton_Click);
               // 
               // requestDataButton
               // 
               this.requestDataButton.Location = new System.Drawing.Point(6, 19);
               this.requestDataButton.Name = "requestDataButton";
               this.requestDataButton.Size = new System.Drawing.Size(100, 30);
               this.requestDataButton.TabIndex = 1;
               this.requestDataButton.Text = "Request Data";
               this.requestDataButton.UseVisualStyleBackColor = true;
               this.requestDataButton.Click += new System.EventHandler(this.requestDataButton_Click);
               // 
               // saveDataButton
               // 
               this.saveDataButton.Location = new System.Drawing.Point(6, 55);
               this.saveDataButton.Name = "saveDataButton";
               this.saveDataButton.Size = new System.Drawing.Size(100, 30);
               this.saveDataButton.TabIndex = 0;
               this.saveDataButton.Text = "Save Data";
               this.saveDataButton.UseVisualStyleBackColor = true;
               this.saveDataButton.Click += new System.EventHandler(this.saveDataButton_Click);
               // 
               // eraseDataButton
               // 
               this.eraseDataButton.Location = new System.Drawing.Point(108, 19);
               this.eraseDataButton.Name = "eraseDataButton";
               this.eraseDataButton.Size = new System.Drawing.Size(100, 30);
               this.eraseDataButton.TabIndex = 2;
               this.eraseDataButton.Text = "Erase Data";
               this.eraseDataButton.UseVisualStyleBackColor = true;
               this.eraseDataButton.Click += new System.EventHandler(this.eraseDataButton_Click);
               // 
               // groupBox6
               // 
               this.groupBox6.Controls.Add(this.serialMonitorView);
               this.groupBox6.Location = new System.Drawing.Point(238, 161);
               this.groupBox6.Name = "groupBox6";
               this.groupBox6.Size = new System.Drawing.Size(532, 227);
               this.groupBox6.TabIndex = 5;
               this.groupBox6.TabStop = false;
               this.groupBox6.Text = "Serial Monitor";
               // 
               // serialMonitorView
               // 
               this.serialMonitorView.BackColor = System.Drawing.SystemColors.ActiveCaption;
               this.serialMonitorView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.serialMonitorView.Location = new System.Drawing.Point(6, 19);
               this.serialMonitorView.Name = "serialMonitorView";
               this.serialMonitorView.ReadOnly = true;
               this.serialMonitorView.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
               this.serialMonitorView.Size = new System.Drawing.Size(520, 199);
               this.serialMonitorView.TabIndex = 0;
               this.serialMonitorView.Text = "";
               this.serialMonitorView.TextChanged += new System.EventHandler(this.serialMonitorView_TextChanged);
               // 
               // groupBox2
               // 
               this.groupBox2.Controls.Add(this.statusMonitorView);
               this.groupBox2.Location = new System.Drawing.Point(236, 27);
               this.groupBox2.Name = "groupBox2";
               this.groupBox2.Size = new System.Drawing.Size(531, 128);
               this.groupBox2.TabIndex = 6;
               this.groupBox2.TabStop = false;
               this.groupBox2.Text = "Status Monitor";
               // 
               // statusView
               // 
               this.statusMonitorView.BackColor = System.Drawing.SystemColors.ActiveCaption;
               this.statusMonitorView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.statusMonitorView.Location = new System.Drawing.Point(8, 19);
               this.statusMonitorView.Name = "statusView";
               this.statusMonitorView.ReadOnly = true;
               this.statusMonitorView.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
               this.statusMonitorView.Size = new System.Drawing.Size(516, 103);
               this.statusMonitorView.TabIndex = 1;
               this.statusMonitorView.Text = "";
               this.statusMonitorView.TextChanged += new System.EventHandler(this.statusView_TextChanged);
               // 
               // menuStrip1
               // 
               this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
               this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.monitorsToolStripMenuItem});
               this.menuStrip1.Location = new System.Drawing.Point(0, 0);
               this.menuStrip1.Name = "menuStrip1";
               this.menuStrip1.Size = new System.Drawing.Size(779, 24);
               this.menuStrip1.TabIndex = 7;
               this.menuStrip1.Text = "menuStrip1";
               // 
               // aboutToolStripMenuItem
               // 
               this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
               this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
               this.aboutToolStripMenuItem.Text = "About";
               this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
               // 
               // monitorsToolStripMenuItem
               // 
               this.monitorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearStatusToolStripMenuItem,
            this.clearSerialToolStripMenuItem});
               this.monitorsToolStripMenuItem.Name = "monitorsToolStripMenuItem";
               this.monitorsToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
               this.monitorsToolStripMenuItem.Text = "Monitors";
               // 
               // clearStatusToolStripMenuItem
               // 
               this.clearStatusToolStripMenuItem.Name = "clearStatusToolStripMenuItem";
               this.clearStatusToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
               this.clearStatusToolStripMenuItem.Text = "Clear Status";
               this.clearStatusToolStripMenuItem.Click += new System.EventHandler(this.clearStatusToolStripMenuItem_Click);
               // 
               // clearSerialToolStripMenuItem
               // 
               this.clearSerialToolStripMenuItem.Name = "clearSerialToolStripMenuItem";
               this.clearSerialToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
               this.clearSerialToolStripMenuItem.Text = "Clear Serial";
               this.clearSerialToolStripMenuItem.Click += new System.EventHandler(this.clearSerialToolStripMenuItem_Click);
               // 
               // Main
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.AutoSize = true;
               this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
               this.ClientSize = new System.Drawing.Size(779, 396);
               this.Controls.Add(this.groupBox2);
               this.Controls.Add(this.groupBox6);
               this.Controls.Add(this.groupBox4);
               this.Controls.Add(this.groupBox3);
               this.Controls.Add(this.groupBox1);
               this.Controls.Add(this.menuStrip1);
               this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
               this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
               this.MainMenuStrip = this.menuStrip1;
               this.MaximizeBox = false;
               this.Name = "Main";
               this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
               this.Text = "EEPROM Data Manager";
               this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
               this.Load += new System.EventHandler(this.Main_Load);
               this.groupBox1.ResumeLayout(false);
               this.groupBox3.ResumeLayout(false);
               this.groupBox4.ResumeLayout(false);
               this.groupBox6.ResumeLayout(false);
               this.groupBox2.ResumeLayout(false);
               this.menuStrip1.ResumeLayout(false);
               this.menuStrip1.PerformLayout();
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.GroupBox groupBox1;
          private System.Windows.Forms.Label databitsDataLabel;
          private System.Windows.Forms.Label baudRateDataLabel;
          private System.Windows.Forms.Label label5;
          private System.Windows.Forms.Label label4;
          private System.Windows.Forms.Label label15;
          internal System.Windows.Forms.Label dataConnectionLabel;
          private System.Windows.Forms.GroupBox groupBox3;
          private System.Windows.Forms.GroupBox groupBox4;
          private System.Windows.Forms.Button saveDataButton;
          private System.Windows.Forms.Button eraseDataButton;
          private System.Windows.Forms.Button requestDataButton;
          private System.Windows.Forms.GroupBox groupBox6;
          internal System.Windows.Forms.RichTextBox serialMonitorView;
          private System.Windows.Forms.ComboBox deviceSelectionComboBox;
          private System.Windows.Forms.Button deviceManagerButton;
          private System.Windows.Forms.Button connectButton;
          private System.Windows.Forms.Button refreshPortListButton;
          private System.Windows.Forms.Button disconnectButton;
          private System.Windows.Forms.Button collectNewDataButton;
          private System.Windows.Forms.GroupBox groupBox2;
          internal System.Windows.Forms.RichTextBox statusMonitorView;
          private System.Windows.Forms.MenuStrip menuStrip1;
          private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
          private System.Windows.Forms.Label samplingRateLabel;
          private System.Windows.Forms.Label label2;
          private System.Windows.Forms.ToolStripMenuItem monitorsToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem clearStatusToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem clearSerialToolStripMenuItem;
     }
}

