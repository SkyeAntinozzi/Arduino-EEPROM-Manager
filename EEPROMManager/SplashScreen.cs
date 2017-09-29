using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace EEPROMManager {
     public partial class SplashScreen : Form {
         
          public SplashScreen() {
               InitializeComponent();   
          }//end SplashScreen

          private void SplashScreen_Shown(object sender, EventArgs e) {

               // Create a new timer
               timer = new Timer();

               // Set the timer interval to 3 seconds
               timer.Interval = 3000;

               // Start the timer
               timer.Start();

               // Bind a method to call once the timer is up
               timer.Tick += Timer_Tick;

          }//end SplashScreen_Shown

          private void Timer_Tick(object sender, EventArgs e) {
               // Stop the timer
               timer.Stop();

               // Create a new Main form 
               Main mainForm = new Main();

               // And show it
               mainForm.Show();

               // Then hide the splash screen
               this.Hide();
          }//end Timer_Tick
     }//end public partial class SplashScreen : Form
}//end namespace EEPROMManager
