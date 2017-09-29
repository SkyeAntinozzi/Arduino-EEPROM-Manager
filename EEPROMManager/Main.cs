using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;

namespace EEPROMManager {
     public partial class Main : Form {

          #region Constants
          public static readonly String FIVE_VOLTS = "FIVE_VOLTS";
          public static readonly String THREE_VOLTS = "THREE_VOLTS";

          public static readonly String OHMS = "OHMS";
          public static readonly String CELSIUS = "CELSIUS";
          public static readonly String FARENHEIT = "FARENHEIT";

          public static readonly String TIME_STAMP = "TIME_STAMP";
          public static readonly String MEMORY_ADDRESS = "MEMORY_ADDRESS";

          #endregion Constants

          #region Instance Variables __________________________________________

          // Interfaces with the serial device
          private SerialInterfaceManager serial;

          // The name of the file data may be saved to
          private String saveFile;

          // The operating voltage of the device
          private String deviceOperatingVoltage;

          // The preferred units to save device data as
          private String preferredUnit;

          // The preferred header to save device data with
          private String preferredHeader;

          #endregion Instance Variables _______________________________________


          #region Form Methods ________________________________________________

          /// <summary>
          /// Constructor.
          /// Initializes the Main form.
          /// </summary>
          public Main() {
               InitializeComponent();
          }//end Main

          /// <summary>
          /// Loads the Main form by setting up the available port list and creating
          /// a new SerialInterfaceManager to interface with a connected serial device.
          /// </summary>
          private void Main_Load(object sender, EventArgs e) {
               // Create a new data manager to interface with the serial device
               serial = new SerialInterfaceManager(this);

               // Populate the port ComboBox with the available COM ports
               loadPortList();

               // Save memory addresses by default
               //saveMemoryAddressCheckBox.Checked = true;

          }//end Main_Load

          #endregion Form Methods _____________________________________________


          #region Form Helper Methods _________________________________________

          /// <summary>
          /// Helper Method.
          /// If the SerialPort is currently active, then the connected device's information
          /// will be populated on the form. 
          /// </summary>
          private void populateDeviceInformation() {

               // Get a reference to the SerialPort connection
               SerialPort port = serial.getSerialPort();

               // Get the BaudRate
               baudRateDataLabel.Text = (serial.serialPortIsActive() ? port.BaudRate.ToString() : "");

               // Get the DataBits
               databitsDataLabel.Text = (serial.serialPortIsActive() ? port.DataBits.ToString() : "");

               // Get the sampling rate
               samplingRateLabel.Text = (serial.serialPortIsActive() ? serial.getDeviceSamplingRate().ToString() : "");

          }//end populateDeviceInformation

          /// <summary>
          /// Helper Method.
          /// Clears all text in the Status Monitor text box.
          /// </summary>
          private void clearStatusTextBox() {
               statusMonitorView.Text = String.Empty;
          }//end clearStatusTextBox

          /// <summary>
          /// Helper Method.
          /// Clears all text in the Serial Monitor text box.
          /// </summary>
          private void clearSerialTextBox() {
               serialMonitorView.Text = String.Empty;
          }//end clearSerialTextBox
          
          #endregion Form Helper Methods ______________________________________


          #region Event Handler Methods _______________________________________

          /// <summary>
          /// Event Handler. Fired when the Main form is closing.
          /// </summary>
          private void Main_FormClosing(object sender, FormClosingEventArgs e) {
               // Close up all resources
               shutdownProgram();
          }//end Main_FormClosing

          /// <summary>
          /// Event Handler. The "Connect" button fires this method.
          /// </summary>
          private void connectButton_Click(object sender, EventArgs e) {
               // Attempt to connect to the selected COM port
               connect();
          }//end connectButton_Click

          /// <summary>
          /// Event Handler. The "Disconnect" button fires this method.
          /// </summary>
          private void disconnectButton_Click(object sender, EventArgs e) {
               // Attempt to disconnect from the current COM device
               disconnect();
          }//end disconnectButton_Click

          /// <summary>
          /// Event Handler. Fired by the "Device Manager" button.
          /// </summary>
          private void deviceManagerButton_Click(object sender, EventArgs e) {
               // Open the Device Manager
               openDeviceManager();
          }//end deviceManagerButton_Click

          /// <summary>
          /// Event Handler. The "Request Data" button fires this method.
          /// </summary>
          private void requestDataButton_Click(object sender, EventArgs e) {
               // Request the data from the COM device
               requestData();
          }//end requestDataButton_Click

          /// <summary>
          /// Event Handler. The "Erase Data" button fires this method.
          /// </summary>
          /// <param name="sender"></param>
          /// <param name="e"></param>
          private void eraseDataButton_Click(object sender, EventArgs e) {
               // Request to erase data from the device
               eraseData();
          }//end eraseDataButton_Click

          /// <summary>
          /// Event Handler. The "Collect New Data" button fires this method.
          /// </summary>
          /// <param name="sender"></param>
          /// <param name="e"></param>
          private void collectNewDataButton_Click(object sender, EventArgs e) {
               // Request that the device collect new data
               collectNewData();
          }//end collectNewDataButton_Click

          /// <summary>
          /// Event Handler. The "Save Data" button fires this method.
          /// </summary>
          /// <param name="sender"></param>
          /// <param name="e"></param>
          private void saveDataButton_Click(object sender, EventArgs e) {
               // Request that the device send data and save it
               saveData();
          }//end saveDataButton_Click

          /// <summary>
          /// Event Handler. The "Refresh Port List" button fires this method.
          /// </summary>
          /// <param name="sender"></param>
          /// <param name="e"></param>
          private void refreshPortListButton_Click(object sender, EventArgs e) {
               // Update the port list
               loadPortList();

               // Notify of refresh
               printToStatus("COM Port List Refreshed.");
          }//end refreshPortListButton_Click

          /// <summary>
          /// Event Handler. Fired when the text changes within the Status view.
          /// </summary>
          private void statusView_TextChanged(object sender, EventArgs e) {
               // Set the caret location to the bottom of the text box
               statusMonitorView.SelectionStart = statusMonitorView.Text.Length;

               // And scroll to the new caret location
               statusMonitorView.ScrollToCaret();
          }//end statusView_TextChanged

          /// <summary>
          /// Event Handler. Fired when the text changes within the Serial Monitor view.
          /// </summary>
          private void serialMonitorView_TextChanged(object sender, EventArgs e) {
               // Set the caret location to the bottom of the text box
               serialMonitorView.SelectionStart = serialMonitorView.Text.Length;

               // And scroll to the new caret location
               serialMonitorView.ScrollToCaret();
          }//end serialMonitorView_TextChanged

          /// <summary>
          /// Event Handler. Fired when the "About" menu item is clicked.
          /// </summary>
          /// <param name="sender"></param>
          /// <param name="e"></param>
          private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
               AboutForm af = new AboutForm();
               af.ShowDialog();
          }//end aboutToolStripMenuItem_Click

          /// <summary>
          /// Event Handler. Fired when the "Clear Status" button is selected from the "Monitors" menu.
          /// </summary>
          private void clearStatusToolStripMenuItem_Click(object sender, EventArgs e) {
               clearStatusTextBox();
          }//end clearStatusToolStripMenuItem_Click

          /// <summary>
          /// Event Handler. Fired when the "Clear Serial" button is selected from the "Monitors" menu.
          /// </summary>
          private void clearSerialToolStripMenuItem_Click(object sender, EventArgs e) {
               clearSerialTextBox();
          }//end clearSerialToolStripMenuItem_Click

          #endregion Event Handler Methods ____________________________________


          #region Event Handler Helper Methods ________________________________

          /// <summary>
          /// Closes all resources for the program just prior to termination.
          /// </summary>
          private void shutdownProgram() {
               // If a Serial Port is currently active then close it
               if (serial.serialPortIsActive())
                    serial.terminateSerialPort();

               // And shut down the application
               Application.Exit();
          }//end shutdownProgram

          /// <summary>
          /// Helper Method.
          /// Attempts to create a serial connection to the COM port selected in the available port ComboBox.
          /// If the connection cannot be opened, an exception will be thrown inside of this method and 
          /// the user will be notified of the connection failure.
          /// </summary>
          private void connect() {

               // A String for the com port to connect to.
               String comPort = "";

               // Try to create a COM connection
               try {
                    // Get the selected COM port from the available port ComboBox
                    comPort = deviceSelectionComboBox.SelectedItem.ToString();

                    // If the a serial port connection does not exist
                    if (serial.getSerialPort() == null) {
                         // Attempt to connect to the serial device
                         serial.connectToSerialPort(comPort);

                         // Notify that the connection succeeded
                         printToStatus("Connected to " + comPort + ". The device may need to be reset.");
                    }
                    else
                         printToStatus("A connection already exists to " + serial.getSerialPort().PortName + ".");
               }
               // Catch if no port is selected
               catch (System.NullReferenceException) {
                    printToStatus("Please select a COM port to connect to.");
               }
               // Catch if the connection fails
               catch (Exception ex) {
                    // Terminate the SerialPort
                    serial.terminateSerialPort();

                    // And notify the user
                    serialMonitorView.AppendText("Trouble connecting to " + comPort + "\n");
               }// end attempt COM connection
          }//end connect

          /// <summary>
          /// Helper Method.
          /// Disconnects from the current active SerialPort.
          /// </summary>
          private void disconnect() {

               // The String for the currently selected port
               String selectedPort = "";

               // Try to disconnect from the current serial connection
               try {
                    // Get the selected port name from the combo box
                    selectedPort = deviceSelectionComboBox.SelectedItem.ToString();

                    // If the SerialPort is currently active and the correct port is selected
                    if (serial.serialPortIsActive() && connectedDeviceIsSelected()) {
                         // Then terminate the connection
                         serial.terminateSerialPort();

                         // And update the device information
                         populateDeviceInformation();

                         // Notify user of disconnect
                         printToStatus("Disconnected from " + selectedPort + ".");
                    }//end if SerialPort is currently active
                    else
                         printToStatus("There is no connection to " + selectedPort + ".");
               }
               // Catch if no port is selected
               catch (System.NullReferenceException) {
                    printToStatus("Please select a COM port to disconnect from.");
               }
               // Catch if disconnection cannot be made
               catch (Exception ex) {
                    printToStatus("Trouble disconnecting.");
               }
          }//end disconnect

          /// <summary>
          /// Helper Method.
          /// Opens the Device Manager
          /// </summary>
          private void openDeviceManager() {
               // Attempt to start a new process that opens the Device Manager
               try {
                    Process.Start("devmgmt.msc");
                    printToStatus("Device Manager Started.");
               }
               catch(Exception ex) {
                    printToStatus("Could not open the Device Manager.");
               }
          }//end openDeviceManager

          /// <summary>
          /// Requests that EEPROM data be sent from the COM device.
          /// </summary>
          private void requestData() {
               // Try to request data from the COM device
               try {
                    // If there is no SerialPort object
                    if (!serial.serialPortIsActive())
                         printToStatus("No serial port is connected.");
                    // If the connected device is not selected
                    else if (!connectedDeviceIsSelected())
                         printToStatus(getSelectedPort() == null ? "Please select the connected COM port." : "No connection to " + deviceSelectionComboBox.SelectedItem.ToString() + ".");
                    // If the device is not ready to take commands
                    else if (!serial.deviceIsAvailable())
                         printToStatus(serial.getSerialPort().PortName + " is currently unavailable.");
                    else 
                         // Then request data from the COM device
                         serial.requestData();

               } catch(Exception ex) {
                    printToStatus("Trouble requesting data.");
               }
          }//end requestData

          /// <summary>
          /// Requests that EEPROM data be erased from the COM device.
          /// </summary>
          private void eraseData() {
               // Try to request for data to be erased from the device
               try {
                    // If there is no SerialPort object
                    if (!serial.serialPortIsActive())
                         printToStatus("No serial port is connected.");
                    // If the connected device is not selected
                    else if (!connectedDeviceIsSelected())
                         printToStatus(getSelectedPort() == null ? "Please select the connected COM port." : "No connection to " + deviceSelectionComboBox.SelectedItem.ToString() + ".");
                    // If the device is not ready to take commands
                    else if (!serial.deviceIsAvailable())
                         printToStatus(serial.getSerialPort().PortName + " is currently unavailable.");
                    else
                         serial.eraseData();
               }
               catch (Exception ex) {
                    printToStatus("Trouble erasing data.");
               }
          }//end eraseData

          /// <summary>
          /// Requests that new data be collected from the COM device.
          /// </summary>
          private void collectNewData() {
               // Try to request for data collection
               try {
                    // If there is no SerialPort object
                    if (!serial.serialPortIsActive())
                         printToStatus("No serial port is connected.");
                    // If the connected device is not selected
                    else if (!connectedDeviceIsSelected())
                         printToStatus(getSelectedPort() == null ? "Please select the connected COM port." : "No connection to " + deviceSelectionComboBox.SelectedItem.ToString() + ".");
                    // If the device is not ready to take commands
                    else if (!serial.deviceIsAvailable())
                         printToStatus(serial.getSerialPort().PortName + " is currently unavailable.");
                    else
                         serial.exitMenu();
               }
               catch (Exception ex) {
                    printToStatus("Trouble requesting data.");
               }
          }//end collectNewData

          /// <summary>
          /// Requests that data be saved to a file from the COM device.
          /// </summary>
          private void saveData() {

               // Try to request for data and to save that data
               try {

                    // If there is no SerialPort object
                    if (!serial.serialPortIsActive())
                         printToStatus("No serial port is connected.");

                    // If the connected device is not selected
                    else if (!connectedDeviceIsSelected())
                         printToStatus(getSelectedPort() == null ? "Please select the connected COM port." : "No connection to " + deviceSelectionComboBox.SelectedItem.ToString() + ".");

                    // If the device is not ready to take commands
                    else if (!serial.deviceIsAvailable())
                         printToStatus(serial.getSerialPort().PortName + " is currently unavailable.");

                    // If all is well then save the data to a file
                    else {

                         SaveDataForm saveDataForm = new SaveDataForm(this);
                         saveDataForm.ShowDialog();

                         if (saveDataForm.DialogResult == DialogResult.OK) {

                              // Start a new save file dialog
                              SaveFileDialog browser = new SaveFileDialog();

                              // Set the default file type to a text file
                              browser.Filter = "Text File (*.txt)|*.txt";

                              // Format the file name as Temp-Data--2016-7-11--2-50-23
                              browser.FileName = "Temp-Data--" + deviceOperatingVoltage + "-" + preferredUnit + "--"  
                                                               + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "--"
                                                               + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
                              
                              // Record the dialog result
                              DialogResult result = browser.ShowDialog();

                              // If the user agreed to save
                              if (result == DialogResult.OK) {

                                   // Record the file's name
                                   saveFile = browser.FileName;

                                   // The data is being saved so set the print to file flag to true
                                   serial.shouldSaveToFile(true);

                                   // And request the data
                                   serial.requestData();
                              }//end if result is ok
                         }
                    }//end else should save
               }//end try to save
               catch (Exception ex) {
                    printToStatus("Cannot save data without a connection.");
               }
          }//end saveData

          /// <summary>
          /// Helper Method.
          /// Populates the port ComboBox with the available COM ports.
          /// </summary>
          private void loadPortList() {
               
               // Clear the ComboBox items
               deviceSelectionComboBox.Items.Clear();

               // Get the list of available port names
               String[] ports = SerialPort.GetPortNames();

               // Populate the port list combo box with available ports
               foreach (string s in SerialPort.GetPortNames()) 
                    deviceSelectionComboBox.Items.Add(s);
                    
          }//end loadPortList

          #endregion Event Handler Helper Methods _____________________________


          #region Setter Methods

          /// <summary>
          /// Sets the Data Status to available or unavailable and changes the font color of the available label.
          /// </summary>
          /// <param name="status">
          /// true - if "Available"
          /// false - if "Unavailable"
          /// </param>
          public void setAvailableStatus(bool status) {

               // If status is true
               if (status) {
                    // Then data is available
                    dataConnectionLabel.ForeColor = System.Drawing.Color.ForestGreen;
                    dataConnectionLabel.Text = "Available";
               }
               // Otherwise, status if false so data is unavailable
               else {
                    // Then data is unavailable
                    dataConnectionLabel.ForeColor = System.Drawing.Color.IndianRed;
                    dataConnectionLabel.Text = "Unavailable";
               }

               populateDeviceInformation();
          }//end status

          public void setSamplingRateLabel(String rate) {
               samplingRateLabel.Text = rate;
          }//end setSamplingRateLabel

          public void setDeviceOperatingVoltage(String voltage) {
               deviceOperatingVoltage = voltage;
          }//end setDeviceOperatingVoltage

          public void setUnit(String unit) {
               preferredUnit = unit;
          }//end setUnit

          public void setHeader(String header) {
               preferredHeader = header;
          }//end setHeader

          #endregion Setters Methods


          #region Getter Methods

          /// <summary>
          /// Gets the currently selected port from the available port ComboBox.
          /// </summary>
          /// <returns>The name of the selected port</returns>
          private String getSelectedPort() {
               // If no item is selected then return a null string
               if (deviceSelectionComboBox.SelectedItem == null)
                    return null;
               // Otherwise, return the selected device
               return deviceSelectionComboBox.SelectedItem.ToString();
          }//end getSelectedPort

          /// <summary>
          /// Returns the generated name of the new file to write data to.
          /// </summary>
          /// <returns>Name of file to write data to</returns>
          public String getSaveFile() {
               return saveFile;
          }//end getSaveFile

          /// <summary>
          /// Reports if memory address headers should be saved when writing to a file.
          /// </summary>
          /// <returns>
          /// true - memory addresses should be saved
          /// false - memory addresses should not be saved
          /// </returns>
          public bool shouldSaveAddresses() {
               return false;//saveMemoryAddressCheckBox.Checked;
          }//end shouldSaveAddresses

          /// <summary>
          /// Determines whether the connected device is selected from the ComboBox.
          /// </summary>
          /// <returns>
          /// true - if the connected device is selected
          /// false - if the connected device is not selected
          /// </returns>
          private bool connectedDeviceIsSelected() {
               // If an item is selected
               if (deviceSelectionComboBox.SelectedItem != null)
                    // Compare the device to see if it is the connected one 
                    return serial.getSerialPort().PortName.Equals(getSelectedPort());

               // If an item is not selected then just return false
               return false;
          }//end connectedDeviceIsSelected

          public String getHeader() {
               return preferredHeader;
          }//end getHeader

          public String getUnit() {
               return preferredUnit;
          }//end getUnit

          public String getOperatingVoltage() {
               return deviceOperatingVoltage;
          }//end getOperatingVoltage

          #endregion Getters Methods


          #region Other Helper Methods ________________________________________

          /// <summary>
          /// Appends a message to the status view and to the Debug console.
          /// </summary>
          /// <param name="message">The message to send to the status view and Debug</param>
          public void printToStatus(String message) {
               // Send the message to the Debug console
               Debug.WriteLine(message);

               // Append to the status view
               statusMonitorView.AppendText(DateTime.Now.ToString("H:mm:ss") + " - " + message + "\n");
          }//end print

          /// <summary>
          /// Appends a message to the Serial Monitor view
          /// </summary>
          /// <param name="message">The message to send to the serial monitor and Debug</param>
          public void printToSerialMonitor(String message) {
               // Send the message to the Debug console
               Debug.WriteLine(message);

               // Append to the status view
               serialMonitorView.AppendText(DateTime.Now.ToString("H:mm:ss") + " - " + message + "\n");
          }//end print

          
          #endregion Other Helper Methods _____________________________________



          
     }//end public partial class Main : Form

}//end namespace EEPROMManager
