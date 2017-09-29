namespace EEPROMManager {
     partial class AboutForm {
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
               System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
               this.pictureBox1 = new System.Windows.Forms.PictureBox();
               this.pictureBox2 = new System.Windows.Forms.PictureBox();
               this.label1 = new System.Windows.Forms.Label();
               this.groupBox1 = new System.Windows.Forms.GroupBox();
               ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
               ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
               this.groupBox1.SuspendLayout();
               this.SuspendLayout();
               // 
               // pictureBox1
               // 
               this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
               this.pictureBox1.Location = new System.Drawing.Point(17, 19);
               this.pictureBox1.Name = "pictureBox1";
               this.pictureBox1.Size = new System.Drawing.Size(402, 172);
               this.pictureBox1.TabIndex = 0;
               this.pictureBox1.TabStop = false;
               // 
               // pictureBox2
               // 
               this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
               this.pictureBox2.Location = new System.Drawing.Point(465, 30);
               this.pictureBox2.Name = "pictureBox2";
               this.pictureBox2.Size = new System.Drawing.Size(231, 143);
               this.pictureBox2.TabIndex = 1;
               this.pictureBox2.TabStop = false;
               // 
               // label1
               // 
               this.label1.AutoSize = true;
               this.label1.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label1.Location = new System.Drawing.Point(230, 257);
               this.label1.Name = "label1";
               this.label1.Size = new System.Drawing.Size(333, 88);
               this.label1.TabIndex = 2;
               this.label1.Text = "Skye Antinozzi\r\nUniversity of North Dakota\r\nResearch Enrichment for Undergraduate" +
    "s\r\nJuly 2016";
               // 
               // groupBox1
               // 
               this.groupBox1.Controls.Add(this.label1);
               this.groupBox1.Controls.Add(this.pictureBox2);
               this.groupBox1.Controls.Add(this.pictureBox1);
               this.groupBox1.Location = new System.Drawing.Point(12, 3);
               this.groupBox1.Name = "groupBox1";
               this.groupBox1.Size = new System.Drawing.Size(745, 442);
               this.groupBox1.TabIndex = 3;
               this.groupBox1.TabStop = false;
               // 
               // AboutForm
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(769, 457);
               this.Controls.Add(this.groupBox1);
               this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
               this.Name = "AboutForm";
               this.Text = "About";
               ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
               ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
               this.groupBox1.ResumeLayout(false);
               this.groupBox1.PerformLayout();
               this.ResumeLayout(false);

          }

          #endregion

          private System.Windows.Forms.PictureBox pictureBox1;
          private System.Windows.Forms.PictureBox pictureBox2;
          private System.Windows.Forms.Label label1;
          private System.Windows.Forms.GroupBox groupBox1;
     }
}