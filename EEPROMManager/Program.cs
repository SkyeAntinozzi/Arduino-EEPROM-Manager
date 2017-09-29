/* Author: Skye Antinozzi
 * Description: Entry point for the EEPROM Data Manager. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace EEPROMManager {
     static class Program {
          /// <summary>
          /// The main entry point for the application.
          /// </summary>
          [STAThread]
          static void Main() {

               Application.EnableVisualStyles();
               Application.SetCompatibleTextRenderingDefault(false);

               Application.Run(new SplashScreen());
          }
     }
}
