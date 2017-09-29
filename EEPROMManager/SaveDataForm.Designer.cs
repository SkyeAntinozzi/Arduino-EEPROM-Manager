namespace EEPROMManager {
     partial class SaveDataForm {
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
               System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveDataForm));
               this.createFileButton = new System.Windows.Forms.Button();
               this.groupBox7 = new System.Windows.Forms.GroupBox();
               this.resistanceRadio = new System.Windows.Forms.RadioButton();
               this.celsiusRadio = new System.Windows.Forms.RadioButton();
               this.farenheitRadio = new System.Windows.Forms.RadioButton();
               this.groupBox8 = new System.Windows.Forms.GroupBox();
               this.timeStampRadio = new System.Windows.Forms.RadioButton();
               this.memoryAddressRadio = new System.Windows.Forms.RadioButton();
               this.cancelButton = new System.Windows.Forms.Button();
               this.groupBox9 = new System.Windows.Forms.GroupBox();
               this.radio3Volt = new System.Windows.Forms.RadioButton();
               this.radio5Volt = new System.Windows.Forms.RadioButton();
               this.groupBox7.SuspendLayout();
               this.groupBox8.SuspendLayout();
               this.groupBox9.SuspendLayout();
               this.SuspendLayout();
               // 
               // createFileButton
               // 
               this.createFileButton.Location = new System.Drawing.Point(193, 113);
               this.createFileButton.Name = "createFileButton";
               this.createFileButton.Size = new System.Drawing.Size(100, 30);
               this.createFileButton.TabIndex = 0;
               this.createFileButton.Text = "Create File";
               this.createFileButton.UseVisualStyleBackColor = true;
               this.createFileButton.Click += new System.EventHandler(this.createFileButton_Click);
               // 
               // groupBox7
               // 
               this.groupBox7.Controls.Add(this.resistanceRadio);
               this.groupBox7.Controls.Add(this.celsiusRadio);
               this.groupBox7.Controls.Add(this.farenheitRadio);
               this.groupBox7.Location = new System.Drawing.Point(161, 12);
               this.groupBox7.Name = "groupBox7";
               this.groupBox7.Size = new System.Drawing.Size(98, 95);
               this.groupBox7.TabIndex = 12;
               this.groupBox7.TabStop = false;
               this.groupBox7.Text = "Units";
               // 
               // resistanceRadio
               // 
               this.resistanceRadio.AutoSize = true;
               this.resistanceRadio.Checked = true;
               this.resistanceRadio.Location = new System.Drawing.Point(15, 19);
               this.resistanceRadio.Name = "resistanceRadio";
               this.resistanceRadio.Size = new System.Drawing.Size(52, 17);
               this.resistanceRadio.TabIndex = 9;
               this.resistanceRadio.TabStop = true;
               this.resistanceRadio.Text = "Ohms";
               this.resistanceRadio.UseVisualStyleBackColor = true;
               // 
               // celsiusRadio
               // 
               this.celsiusRadio.AutoSize = true;
               this.celsiusRadio.Location = new System.Drawing.Point(15, 42);
               this.celsiusRadio.Name = "celsiusRadio";
               this.celsiusRadio.Size = new System.Drawing.Size(58, 17);
               this.celsiusRadio.TabIndex = 10;
               this.celsiusRadio.Text = "Celsius";
               this.celsiusRadio.UseVisualStyleBackColor = true;
               // 
               // farenheitRadio
               // 
               this.farenheitRadio.AutoSize = true;
               this.farenheitRadio.Location = new System.Drawing.Point(15, 65);
               this.farenheitRadio.Name = "farenheitRadio";
               this.farenheitRadio.Size = new System.Drawing.Size(69, 17);
               this.farenheitRadio.TabIndex = 11;
               this.farenheitRadio.Text = "Farenheit";
               this.farenheitRadio.UseVisualStyleBackColor = true;
               // 
               // groupBox8
               // 
               this.groupBox8.Controls.Add(this.timeStampRadio);
               this.groupBox8.Controls.Add(this.memoryAddressRadio);
               this.groupBox8.Location = new System.Drawing.Point(265, 12);
               this.groupBox8.Name = "groupBox8";
               this.groupBox8.Size = new System.Drawing.Size(134, 95);
               this.groupBox8.TabIndex = 14;
               this.groupBox8.TabStop = false;
               this.groupBox8.Text = "Line Header";
               // 
               // timeStampRadio
               // 
               this.timeStampRadio.AutoSize = true;
               this.timeStampRadio.Checked = true;
               this.timeStampRadio.Location = new System.Drawing.Point(17, 19);
               this.timeStampRadio.Name = "timeStampRadio";
               this.timeStampRadio.Size = new System.Drawing.Size(81, 17);
               this.timeStampRadio.TabIndex = 12;
               this.timeStampRadio.TabStop = true;
               this.timeStampRadio.Text = "Time Stamp";
               this.timeStampRadio.UseVisualStyleBackColor = true;
               // 
               // memoryAddressRadio
               // 
               this.memoryAddressRadio.AutoSize = true;
               this.memoryAddressRadio.Location = new System.Drawing.Point(17, 42);
               this.memoryAddressRadio.Name = "memoryAddressRadio";
               this.memoryAddressRadio.Size = new System.Drawing.Size(103, 17);
               this.memoryAddressRadio.TabIndex = 13;
               this.memoryAddressRadio.Text = "Memory Address";
               this.memoryAddressRadio.UseVisualStyleBackColor = true;
               // 
               // cancelButton
               // 
               this.cancelButton.Location = new System.Drawing.Point(299, 113);
               this.cancelButton.Name = "cancelButton";
               this.cancelButton.Size = new System.Drawing.Size(100, 30);
               this.cancelButton.TabIndex = 15;
               this.cancelButton.Text = "Cancel";
               this.cancelButton.UseVisualStyleBackColor = true;
               this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
               // 
               // groupBox9
               // 
               this.groupBox9.Controls.Add(this.radio3Volt);
               this.groupBox9.Controls.Add(this.radio5Volt);
               this.groupBox9.Location = new System.Drawing.Point(12, 12);
               this.groupBox9.Name = "groupBox9";
               this.groupBox9.Size = new System.Drawing.Size(143, 95);
               this.groupBox9.TabIndex = 16;
               this.groupBox9.TabStop = false;
               this.groupBox9.Text = "Sensor Operating Voltage";
               // 
               // radio3Volt
               // 
               this.radio3Volt.AutoSize = true;
               this.radio3Volt.Location = new System.Drawing.Point(15, 42);
               this.radio3Volt.Name = "radio3Volt";
               this.radio3Volt.Size = new System.Drawing.Size(61, 17);
               this.radio3Volt.TabIndex = 15;
               this.radio3Volt.Text = "3.3 Volt";
               this.radio3Volt.UseVisualStyleBackColor = true;
               // 
               // radio5Volt
               // 
               this.radio5Volt.AutoSize = true;
               this.radio5Volt.Checked = true;
               this.radio5Volt.Location = new System.Drawing.Point(15, 19);
               this.radio5Volt.Name = "radio5Volt";
               this.radio5Volt.Size = new System.Drawing.Size(52, 17);
               this.radio5Volt.TabIndex = 14;
               this.radio5Volt.TabStop = true;
               this.radio5Volt.Text = "5 Volt";
               this.radio5Volt.UseVisualStyleBackColor = true;
               // 
               // SaveDataForm
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(410, 150);
               this.Controls.Add(this.groupBox9);
               this.Controls.Add(this.cancelButton);
               this.Controls.Add(this.groupBox7);
               this.Controls.Add(this.groupBox8);
               this.Controls.Add(this.createFileButton);
               this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
               this.Name = "SaveDataForm";
               this.Text = "Save Data";
               this.groupBox7.ResumeLayout(false);
               this.groupBox7.PerformLayout();
               this.groupBox8.ResumeLayout(false);
               this.groupBox8.PerformLayout();
               this.groupBox9.ResumeLayout(false);
               this.groupBox9.PerformLayout();
               this.ResumeLayout(false);

          }

          #endregion

          private System.Windows.Forms.Button createFileButton;
          private System.Windows.Forms.GroupBox groupBox7;
          private System.Windows.Forms.RadioButton resistanceRadio;
          private System.Windows.Forms.RadioButton celsiusRadio;
          private System.Windows.Forms.RadioButton farenheitRadio;
          private System.Windows.Forms.GroupBox groupBox8;
          private System.Windows.Forms.RadioButton timeStampRadio;
          private System.Windows.Forms.RadioButton memoryAddressRadio;
          private System.Windows.Forms.Button cancelButton;
          private System.Windows.Forms.GroupBox groupBox9;
          private System.Windows.Forms.RadioButton radio3Volt;
          private System.Windows.Forms.RadioButton radio5Volt;
     }
}