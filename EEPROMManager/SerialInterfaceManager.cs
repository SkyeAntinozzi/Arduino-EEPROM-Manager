/* Author: Skye Antinozzi
 * Description: Provides all interfacing logic with an Arduino board connected through a COM serial port. 
 * The Arduino board should have a connected temperature sensor to populate the EEPROM memory with.
 * The UI provides many self-explanatory functions for interacting with stored data on the arduino.
 */
using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Collections.Generic;

namespace EEPROMManager {
     class SerialInterfaceManager {

          #region Constants

          // Received to start contact with device
          public static readonly String HANDSHAKE = "HANDSHAKE\r";

          // Received when contact with device should end
          public static readonly String END_HANDSHAKE = "END_HANDSHAKE\r";

          // Received when device is sending
          public static readonly String SENDING_DATA = "SENDING_DATA\r";

          // Received when device is done sending data
          public static readonly String DATA_SENT = "DATA_SENT\r";

          // Received when the sampling reate is being sent
          public static readonly String SAMPLING_RATE = "SAMPLING_RATE\r";

          // Sent to request for data
          public static readonly String REQUEST_DATA = "1";

          // Sent to request for data erase
          public static readonly String ERASE_DATA = "2";

          // Sent to request for an exit of menu
          public static readonly String EXIT_MENU = "3";

          // The beta value for a sensor running at 5 volts
          public static readonly int FIVE_VOLT_BETA = 3950;

          // The beta value for a sensor running at 3.3 volts
          public static readonly int THREE_VOLT_BETA = 33000;

          #endregion Constants


          #region Instance Variables

          // The active serial port
          private SerialPort port;

          // The parent form this interface manager is linked to
          private Main parentForm;

          // Should data be written to a file?
          private bool saveToFile;

          // Is the current COM device available?
          private bool deviceAvailable;

          // The sampling rate of the device
          private double deviceSamplingRate = -1;

          #endregion Instance Variables


          #region Constructor

          /// <summary>
          /// Constructor.
          /// Constructs a new SerialInterfaceManager that is linked to the specified parent form.
          /// </summary>
          /// <param name="parentForm"></param>
          public SerialInterfaceManager(Main parentForm) {

               // Link this manager to the parent form
               this.parentForm = parentForm;

          }//end SerialInterfaceManager

          #endregion Constructor


          #region Action Methods

          /// <summary>
          /// Connects to and opens the COM port represented by portString and
          /// enables an EventHandler to listen for incoming data. If the COM port cannot be opened this
          /// method will throw an exception.
          /// </summary>
          /// <param name="portString">The COM port to connect to (i.e. "COM1")</param>
          /// <throws>Exception if COM port cannot be opened</throws>
          public void connectToSerialPort(String portString) {

               // Create a new SerialPort on the COM port designated by portString
               port = new SerialPort(portString);

               // Bind a method to be called when data is within the Serial buffer
               port.DataReceived += new SerialDataReceivedEventHandler(serialPortDataReceived);

               // Open the communication port
               port.Open();

          }//end connectToSerialPort

          /// <summary>
          /// Closes the Serial Port and abandones the SerialPort instance. Throws an exception
          /// if the port cannot be closed
          /// </summary>
          /// <throws>Exception if port cannot be opened</throws>
          public void terminateSerialPort() {
               // Close the port
               port.Close();

               // Abandon the object
               port = null;

               // Reset the sampling rate
               deviceSamplingRate = -1;

               // Set the device available status to false
               parentForm.setAvailableStatus(false);

               // Notify of port termination
               parentForm.printToStatus("Serial port terminated.");
          }//end terminateSerialPort

          /// <summary>
          /// Requests that data stored in EEPROM should be sent from the device to
          /// the open serial connection. Throws an exception if request fails.
          /// </summary>
          /// <throws>An exception if request fails</throws>
          public void requestData() {
               // Nofity that a request is being attempted
               parentForm.printToStatus("Requesting data from " + port.PortName + ".");

               // Tell device that we are ready for the data
               port.Write(REQUEST_DATA);               
          }//end requestData

          /// <summary>
          /// Requests that the data stored in EEPROM be erased from the device.
          /// If successful, all values within EEPROM will be set to 255.
          /// Throws an exception if request fails.
          /// </summary>
          /// <throws>An exception if request fails</throws>
          public void eraseData() {
               // Notify that a request is being attempted
               parentForm.printToStatus("Erasing data from " + port.PortName + ".");

               // Tell the device that it should erase
               port.Write(ERASE_DATA);
          }//end eraseData

          /// <summary>
          /// Requests that the device exit the options menu and continue with data collection.
          /// Throws an exception if request fails.
          /// </summary>
          /// <throws>An exception if request fails</throws>
          public void exitMenu() {
               // Notify that a request is being attempted
               parentForm.printToStatus("Collecting new data from " + port.PortName + ".");

               // Tell the device that it should exit the menu
               port.Write(EXIT_MENU);
          }//end exitMenu

          #endregion Action Methods


          #region Getter Methods

          /// <summary>
          /// Returns the data sampling rate of the connected device.
          /// For instance, a value of 3 means the device records a data
          /// point every 3 seconds.
          /// </summary>
          /// <returns>The sampling rate of the device in seconds.</returns>
          public double getDeviceSamplingRate() {
               return deviceSamplingRate;
          }//end getDeviceSamplingRate


          /// <summary>
          /// Determines whether the current SerialPort is active or not.
          /// </summary>
          /// <returns>
          /// true - if active
          /// false - if inactive
          /// </returns>
          public bool serialPortIsActive() {
               // If the port is null then it is not active so return false
               return (port == null ? false : true);
          }//end serialPortIsActive

          /// <summary>
          /// Reports whether the current serial port is open or not.
          /// </summary>
          /// <returns>
          /// true - if the serial port is open
          /// false - if the serial port is not open
          /// </returns>
          public bool serialPortIsOpen() {
               // If the port is null then it cannot possibly be open otherwise it may be open
               return (port == null ? false : port.IsOpen);
          }//end serialPortIsOpen

          /// <summary>
          /// Returns a reference to the current Serial Port.
          /// </summary>
          /// <returns>
          /// The current serial port.
          /// </returns>
          public SerialPort getSerialPort() {
               return port;
          }//end getSerialPort

          /// <summary>
          /// Determines whether the device is ready to receive commands.
          /// </summary>
          /// <returns>
          /// true - if the device is ready for commands
          /// false - if the device is not ready for commands
          /// </returns>
          public bool deviceIsAvailable() {
               return deviceAvailable;
          }//end deviceIsAvailable

          #endregion Getter Methods


          #region Setter Methods

          /// <summary>
          /// Controls whether the data should be saved to a file or not.
          /// </summary>
          /// <param name="shouldSaveToFile">
          /// true - should be saved to file
          /// false - should not be saved to file
          /// </param>
          public void shouldSaveToFile(bool shouldSaveToFile) {
               // Assign the should print flag
               saveToFile = shouldSaveToFile;
          }//end shouldPrint

          
          #endregion Setter Methods

          private void startHandshake() {
               // Then send an acknowledgement
               port.Write(HANDSHAKE);

               // Change font color and set available status to true
               parentForm.setAvailableStatus(true);

               // The device is now available
               deviceAvailable = true;
          }//end startHandshake

          private void endHandshake() {
               // Set available label to false
               parentForm.setAvailableStatus(false);

             
               // Set available status to false
               deviceAvailable = false;
          }//end endHandshake

          private void receiveAndSaveData(String input) {
               // Store the data to save in a list
               List<String> list = new List<String>();

               // Print out SENDING_DATA to serial monitor
               parentForm.printToSerialMonitor(input);

               // While there is still data to save
               while (!(input = port.ReadLine()).Equals(DATA_SENT)) {
                    // Add the data to the list
                    list.Add(input);

                    parentForm.printToSerialMonitor(input);
               }

               // Print out DATA_SENT to serial monitor
               parentForm.printToSerialMonitor(input);

               String voltage = parentForm.getOperatingVoltage();

               String unit = parentForm.getUnit();

               String header = parentForm.getHeader();

               if (header.Equals(Main.TIME_STAMP)) {
                    removeAddresses(ref list);
                    addTimeStamps(ref list);
               }

               if (!unit.Equals(Main.OHMS)) {
                    convertResistanceToTemperature(ref list, unit, voltage);
               }

               // Write the data to a file
               System.IO.File.WriteAllLines(parentForm.getSaveFile(), list);

               // Set the saveToFile flag to false since we're done writing to the file
               saveToFile = false;
          }//end receiveAndSaveData

          private void receiveSamplingRate(String input) {
               // Get the sampling rate
               input = port.ReadLine();

               // Assign the sampling rate
               deviceSamplingRate = Convert.ToDouble(input);

               parentForm.setSamplingRateLabel(input);

               parentForm.printToStatus("Sampling rate " + deviceSamplingRate);
          }//end receiveSamplingRate

          #region Event Handler Methods

          /// <summary>
          /// Continually receives data from the connected COM port.
          /// </summary>
          public void serialPortDataReceived(object sender, SerialDataReceivedEventArgs e) {

               // Enable cross-thread GUI manipulation
               parentForm.serialMonitorView.Invoke((MethodInvoker)delegate {

                    // Read the current line within the Serial buffer
                    String input = port.ReadLine();

                    // If the device is ready to handshake
                    if (input.Equals(HANDSHAKE))
                         startHandshake();

                    // If the device is leaving and won't be available
                    else if (input.Equals(END_HANDSHAKE))
                         endHandshake();

                    // If the device is sending data and the data should be saved
                    else if (input.Equals(SENDING_DATA) && saveToFile)
                         receiveAndSaveData(input);

                    // If the device is about to send the sampling rate
                    else if (input.Equals(SAMPLING_RATE))
                         try {
                              receiveSamplingRate(input);
                         } catch(Exception ex) {
                              parentForm.printToStatus("Could not retrieve device sampling rate.");
                         }

                    // If the device output is standard so just output it to the serial monitor
                    else
                         // Otherwise, print the serial buffer contents
                         parentForm.printToSerialMonitor(input);

               });//end enable cross-thread GUI manipulation

          }//end serialPortDataReceived

          #endregion Event Handler Methods


          #region Event Handler Helper Methods

          /// <summary>
          /// Helper function.
          /// Removes the memory address headers from each line of text for a new data file.
          /// </summary>
          /// <param name="list">The list containing the data with memory address headers</param>
          private void removeAddresses(ref List<String> list) {
               for (int i = 0; i < list.Count; i++)
                    // Remove the address header from the line
                    list[i] = list[i].Substring(list[i].LastIndexOf(']') + 2);

          }//end removeAddresses

          /// <summary>
          /// Helper function.
          /// Adds time stamps to a list containing only collected data with no memory headers.
          /// </summary>
          /// <param name="list">The list containing the data with no memory address headers
          /// requiring time stamps to be added.
          /// </param>
          private void addTimeStamps(ref List<String> list) {

               // Iterate through the list
               for (int i = 0; i < list.Count; i++) {
                    // Get the time from seconds since sampling rate is in seconds
                    TimeSpan time = TimeSpan.FromSeconds(i * deviceSamplingRate);

                    // Conver the seconds to an hour\minute\seconds format
                    String timeFormat = time.ToString(@"hh\:mm\:ss");

                    // Add that formatted String to the list
                    list[i] = "[" + timeFormat + "] " + list[i];
               }
               
          }//end addTimeStamps

          /// <summary>
          /// Converts all values collected at the specified voltage in the list to a specified unit.
          /// </summary>
          /// <param name="list"></param>
          /// <param name="unit"></param>
          /// <param name="voltage"></param>
          private void convertResistanceToTemperature(ref List<String> list, String unit, String voltage) {

               // Determine the beta value based on the operating voltage
               int beta = voltage.Equals(Main.FIVE_VOLTS) ? FIVE_VOLT_BETA : THREE_VOLT_BETA;

               // Store the pulled resistance string from the file
               String resistanceString = "";

               // The header for the current line
               String headerString = "";

               // Store the converted resistanceString
               int resistanceValue = -999;

               // Store the celsius conversion
               double celsius = -999;

               // Store the farenheit conversion
               double farenheit = -999;

               // Store the index of the resistance value
               int index;

               // Iterate through the entire list and convert each resistance value
               for (int i = 0; i < list.Count; i++) {

                    // Get the resistance value index from the line
                    index = list[i].LastIndexOf(']') + 2;

                    // Get the header
                    headerString = list[i].Substring(0, index);

                    // Get the resistance value substring from the line
                    resistanceString = list[i].Substring(index);

                    // Convert the substring to a number
                    resistanceValue = Int32.Parse(resistanceString);

                    // Scale the value backup (in the Arduino code this resistance value is divided by 4 to fit into 1 byte)
                    resistanceValue *= 4;

                    // Scale the resistance value for the converting formula
                    resistanceValue = 1023 - resistanceValue;

                    // Convert the resistance value to celsius
                    celsius = beta / (Math.Log(1025.0 / resistanceValue - 1) + beta / 298.0) - 273.0;

                    // If the requested units are in farenheit
                    if (unit.Equals(Main.FARENHEIT)) {
                         // The convert to farenheit
                         farenheit = 1.8 * celsius + 32.0;

                         // Round to two decimal places
                         farenheit = Math.Round(farenheit, 2);

                         // And add the farenheit temperature to the list
                         list[i] = headerString + " " + farenheit.ToString();
                    }
                    else {
                         // Round to two decimal places
                         celsius = Math.Round(celsius, 2);
                         parentForm.printToStatus(celsius.ToString());

                         // Otherwise, add the celsius temperature to the list
                         list[i] = headerString + " " + celsius.ToString();
                    }

               }//end convert each resistance value

          }//end convertResistanceToTemperature

          #endregion Event Handler Helper Methods

     }//end class SerialInterfaceManager

}//end namespace EEPROMManager 
