namespace EEPROMManager {
     partial class SplashScreen {
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
               this.components = new System.ComponentModel.Container();
               System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
               this.pictureBox1 = new System.Windows.Forms.PictureBox();
               this.timer = new System.Windows.Forms.Timer(this.components);
               this.pictureBox2 = new System.Windows.Forms.PictureBox();
               ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
               ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
               this.SuspendLayout();
               // 
               // pictureBox1
               // 
               this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
               this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
               this.pictureBox1.Name = "pictureBox1";
               this.pictureBox1.Size = new System.Drawing.Size(406, 171);
               this.pictureBox1.TabIndex = 0;
               this.pictureBox1.TabStop = false;
               // 
               // pictureBox2
               // 
               this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
               this.pictureBox2.Location = new System.Drawing.Point(452, 12);
               this.pictureBox2.Name = "pictureBox2";
               this.pictureBox2.Size = new System.Drawing.Size(231, 142);
               this.pictureBox2.TabIndex = 1;
               this.pictureBox2.TabStop = false;
               // 
               // SplashScreen
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.BackColor = System.Drawing.Color.White;
               this.ClientSize = new System.Drawing.Size(738, 167);
               this.Controls.Add(this.pictureBox2);
               this.Controls.Add(this.pictureBox1);
               this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
               this.Name = "SplashScreen";
               this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
               this.Text = "SplashScreen";
               this.Shown += new System.EventHandler(this.SplashScreen_Shown);
               ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
               ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
               this.ResumeLayout(false);

          }

          #endregion

          private System.Windows.Forms.PictureBox pictureBox1;
          private System.Windows.Forms.Timer timer;
          private System.Windows.Forms.PictureBox pictureBox2;
     }
}