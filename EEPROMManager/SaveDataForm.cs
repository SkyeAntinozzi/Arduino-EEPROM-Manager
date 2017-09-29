using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EEPROMManager {
     public partial class SaveDataForm : Form {

          private Main parent;

          public SaveDataForm(Main mainForm) {
               parent = mainForm;
               InitializeComponent();
          }//end SaveDataForm

          private void createFileButton_Click(object sender, EventArgs e) {

               String voltage = "";
               String unit = "";
               String header = "";

               if (radio5Volt.Checked)
                    voltage = Main.FIVE_VOLTS;
               else if (radio3Volt.Checked)
                    voltage = Main.THREE_VOLTS;

               if (resistanceRadio.Checked)
                    unit = Main.OHMS;
               else if (celsiusRadio.Checked)
                    unit = Main.CELSIUS;
               else if (farenheitRadio.Checked)
                    unit = Main.FARENHEIT;

               if (timeStampRadio.Checked)
                    header = Main.TIME_STAMP;
               else if (memoryAddressRadio.Checked)
                    header = Main.MEMORY_ADDRESS;

               parent.setDeviceOperatingVoltage(voltage);
               parent.setUnit(unit);
               parent.setHeader(header);

               DialogResult = DialogResult.OK;
               this.Close();
          }//end createFileButton_Click

          private void cancelButton_Click(object sender, EventArgs e) {
               DialogResult = DialogResult.No;
               this.Close();
          }//end cancelButton_Click

     }//end SaveDataForm

}//end namespace EEPROMManager
