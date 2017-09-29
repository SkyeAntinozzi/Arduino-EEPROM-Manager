
/**
 * Author: Skye Antinozzi
 * Affiliation: University of North Dakota Research Enrichment for Undergraduates
 * Date: 7-11-2016
 * Records temperature data into EEPROM on an Arduino device and also sets up the release
 * servo motor for the BalloonSat termination conditions. 
 * This program starts by enabling a countdown that allows the user to enter an "Operation Mode."
 * If a signal is sent to this program before the countdown finishes then the Operation Mode
 * will become active allowing the user to interact with data stored within EEPROM memory.
 * When Operation Mode is exited, the program continues to store a certain number of
 * data points (typically EEPROM.length() - 1) within EEPROM memory. The program is also checking
 * the termination condition to ensure that the terminating temperature (of about 32 F)
 * has not been reached. When the temperature has been reached or a certain amount
 * of time has passed the balloon will be released allowing the system to descend towards
 * the ground and terminate data collection.
 */
 
// Custom Class for EEPROM data management
#include "DataManager.h"

// Round
#include <math.h> 

// attach, write, read
#include <Servo.h>

#define EULER 2.718281828459045235360287471352

// Program Operation Variables

  // How many averaging samples to take
  const int SAMPLES = 5;
  
  // Store readings here
  int samples[SAMPLES];
  
  // Indicate whether a 5v (true) or 3.3v (false) power supply is being used for the thermistor
  bool usingFiveVolt = false;

  // Beta value from thermistor data sheet
  // 3950 = 5v, 33000 = 3.3v
  long beta = usingFiveVolt ? 3950 : 33000;
  
  // Flag for whether or not the EEPROM full notification has been sent
  bool eepromFullNotificationSent;
  
  // Flag for whether or not the release condition has been met
  bool balloonReleased;
  
  // The number of milliseconds that has passed for the release time
  long milliseconds = 0;

  
// Program Setup Constants

  // Temperature data is collected from this pin from the temperature sensor
  const byte ANALOG_TEMP_PIN = A0;
  
  // Release servo motor is connected to this pin
  const byte RELEASE_SERVO_PIN = 8;


// Program Operation Constants

  // How long until release for the balloon in minutes
  const float TIME_LIMIT_MINUTES = 20;

  // The time limit of the flight in milliseconds
  const unsigned long TIME_LIMIT_MILLISECONDS = TIME_LIMIT_MINUTES * 60000;

  // How often a temperature reading should be saved in seconds.
  // This value is computed to allow for all EEPROM memory to be filled during
  // the duration of the flight. If a specific sampling rate is desired,
  // comment out the current assignment to assign the desired sampling rate in seconds.
  const float SAMPLING_RATE_SECONDS = ceil(TIME_LIMIT_MINUTES * 60.0 / 1023.0);

  // How often a temperature sample should be collected in milliseconds
  const long SAMPLING_RATE_MILLISECONDS = SAMPLING_RATE_SECONDS * 1000;
 
  // The release temperature in celsius
  const int RELEASE_TEMPERATURE_CELSIUS = -18;
  
  // The resistance at which the balloon will be released
  const int RELEASE_RESISTANCE = -1025 / (pow( EULER, (beta * (25 - RELEASE_TEMPERATURE_CELSIUS))/((double) (RELEASE_TEMPERATURE_CELSIUS + 273) * 298)) + 1) + 1023;
    
  // The starting angle that the shaft of the release servo starts at
  const byte RELEASE_SERVO_STARTING_ANGLE = 85;
  
  // The final angle that the shaft of the release servo ends at
  const byte RELEASE_SERVO_FINAL_ANGLE = 25;
  
  // The amount of seconds the user has to open the menu and avoid EEPROM overwrite
  const char OVERWRITE_COUNTDOWN = 15;

  
// Data Handling Constants

  // Value for sending data from the options menu
  const char SEND_DATA = '1';
  
  // Value for erasing data from the options menu
  const char ERASE_DATA = '2';
  
  // Value for continuing with overwrite by exiting the options menu
  const char EXIT_MENU = '3';
  
  // Code indicating that this program is ready to communicate with the companion program
  const String READY_FOR_HANDSHAKE = "HANDSHAKE";
  
  // Code indicating that this program is done communicating with the companion program
  const String END_HANDSHAKE = "END_HANDSHAKE";

  // Conde indicating that this program is gonig to send the sampling rate next
  const String SAMPLING_RATE_HANDSHAKE = "SAMPLING_RATE";


// Instances

 // The servo motor controlling the release mechanism
  Servo releaseServo;
  
  // The data interface for EEPROM
  DataManager data; 


/**
 * On startup
 * setup()
 * Sets up the temperature logging by starting a EEPROM data manager and 
 * setting up the servo release motor.
 */
void setup() {

  // Initiate a Serial communication connection at 9600 bit/sec
  Serial.begin(9600);
  
  // Display the time limit of the launch in minutes
//  Serial.print("Time Limit: "); Serial.println(TIME_LIMIT_MINUTES);
//
//  Serial.print("Sampling Rate: "); Serial.println(SAMPLING_RATE_SECONDS);
//
//  Serial.print("Release Temperature: "); Serial.print(RELEASE_TEMPERATURE_CELSIUS); Serial.println(" *C");
//
//  Serial.print("Release Resistance: "); Serial.println(RELEASE_RESISTANCE);

  // Initialize led on pin 13 for output
  pinMode(13,OUTPUT);

  // If EEPROM is full then prepare to overwrite unless user states otherwise
  if(data.containsData())
    pollUserForOptionsMenu();

  // Set the EEPROM full flag to false
  data.setFull(false);
 
  // Setup the release servo motor
  setupReleaseServo();

  // The system is now setup and is ready to record new temperature data

}//end setup

/**
 * Main Loop
 * loop()
 * Repeatedly loops collecting ambient temperature data and recording the data within EEPROM.
 * When EEPROM is filled to capacity with data, the recording of data stops.
 * In addition, the terminating condition for temperature is continually checked to ensure
 * the system is operating in an appropriate temperature. When the terminating condition
 * for temperature is met, the balloon is released and temperature collection stops.
 */
void loop() {

  // The average resistance calculated from SAMPLES number of readings
  float averageResistance = 0;
  
  // Collect some samples
  for(int i = 0; i < SAMPLES; i++)
   samples[i] = analogRead(ANALOG_TEMP_PIN);
 
  // Average the samples
  for(int i = 0; i < SAMPLES; i++)
    averageResistance += samples[i];
  averageResistance /= SAMPLES;

  // Divide the resistance value by 4 to store within 1 byte
  byte storeMe = round(averageResistance / 4.0);

  // Convert and output the resistance value as temperature
  //Serial.println(getTemperature(averageResistance));
  //Serial.println(averageResistance);

  // If EEPROM is not full then record the data
  if(!data.isFull()){    
    
    //Serial.println("Write");
    
    // Set LED on high to indicate that collection is running
    digitalWrite(13,HIGH);
    
    // Write the byte temperature value to EEPROM
    data.writeData(storeMe);

    // Check if EEPROM is full
    data.ensureCapacity();
    
  }//end else EEPROM is not full so keep recording
  
  // Else if EEPROM is full and the EEPROM full flag has not been set
  else if(data.isFull() && !eepromFullNotificationSent){
    // The EEPROM full notification has been sent so set the flag
    eepromFullNotificationSent = true;
    
    // Set the EEPROM full flag
    data.setFull(true);

    // Turn LED off to indicate collection has stopped
    digitalWrite(13,LOW);
        
  }//end if EEPROM is full and the EEPROM full flag has not been set

  // If the temperature is at the release temperature or the time limit has been reached and the balloon has not been released
  if(!balloonReleased && ((averageResistance >= RELEASE_RESISTANCE) || (milliseconds >= TIME_LIMIT_MILLISECONDS)))
    releaseBalloon();
  
  // Pause for half a second
  delay(SAMPLING_RATE_MILLISECONDS);

  // Increment milliseconds
  milliseconds += SAMPLING_RATE_MILLISECONDS;

  Serial.print("Ran for : "); Serial.print(milliseconds); Serial.print("/"); Serial.println(TIME_LIMIT_MILLISECONDS);
  
}//end loop

/**
 * Helper function.
 * releaseBalloon()
 * Releases the balloon.
 */
void releaseBalloon(){
    // Set the balloon to be released
    balloonReleased = true;

    Serial.println("Balloon Released");
    
    // Rotate the servo which physically releases the balloon
    releaseServo.write(RELEASE_SERVO_FINAL_ANGLE);
}//end releaseBalloon

/**
 * Helper function.
 * flushBuffer()
 * Ensures that no data is contained within the buffer when preparing for Serial input.
 */
void flushBuffer(){

  // While there is data within the buffer
  while(Serial.available() > 0)
    // Discard that data
    char junk = Serial.read();
  
}//end flushBuffer

/**
 * Helper function.
 * showMenuTimer()
 * Begins a timer that allows the user to choose between overwriting data or opening an options menu.
 * Returns: true - the user wishes to open the options menu
 *          false - the user wishes to continue with overwrite
 */
bool showMenuTimer(){

  // Start the countdown
  for(int i = OVERWRITE_COUNTDOWN; i > 0; i--){

    // Send the ready for handshake code for the companion program
    Serial.println(READY_FOR_HANDSHAKE);
  
    // Output the currnent second the countdown is on
    Serial.print(i); Serial.println(" seconds");
    
    // If any data is sent then open menu
    if(Serial.available() > 0)
        return true;

    // Set LED to on
    digitalWrite(13, HIGH);
    
    // Pause for half a second
    delay(500);

    // Set LED to off
    digitalWrite(13, LOW);

    // Pause for half a second
    delay(500);
    
  }

  // No data has been sent so continue with overwriting EEPROM data
  return false;
  
}//end showMenuTimer

/**
 * Helper function.
 * getByteInput()
 * Collects a single byte of data from the user. If a series of bytes is entered (e.g. "123") then the first byte will
 * be used. 
 * Returns: the first byte contained within the Serial buffer
 */
byte getByteInput(){

  // Store user input here
  byte input = -1;

  // Flush the Serial buffer of any data
  flushBuffer();

  // Wait until data is in the Serial buffer
  while(Serial.available() <= 0){}

  // When data is available, extract it
  if(Serial.available() > 0)
    input = Serial.read();

  // Return the extracted Serial buffer data
  return input;
}//end getByteInput

/**
 * Helper function.
 * pollUserForOptionsMenu()
 * Starts a countdown timer at startup for a options menu if data is stored in EEPROM.
 * The user has a specified amount of time to abort the EEPROM overwrite and open an options menu for data management.
 */
void pollUserForOptionsMenu(){

    // Notify the user to enter input if they wish to open the options menu and abort the EEPROM overwrite
    Serial.println("EEPROM data segment will be overwritten. Send any character(s) to abort.");
    Serial.println("Overwriting EEPROM data in...");

    // If the user would like to open the options menu and manage the data
    if(showMenuTimer()){

      // Notify that the overwrite was aborted
      Serial.println("Overwrite Aborted. Serial Connection Established.");

      Serial.println(SAMPLING_RATE_HANDSHAKE);
      Serial.println(SAMPLING_RATE_SECONDS);

      // Store user input here
      byte input = -1;

      // Keep the options menu open until the user selected Exit Menu
      do{
        // Display the options menu
        //Serial.println("\nOptions:\n 1. Send Data\n 2. Erase Data\n 3. Exit Menu\n");

        // Send (display) the options menu over the serial connection
        sendMenu();

        // Get user input
        input = getByteInput();

        // Determine what to do based on input
        parseInput(input);

      // Continue while the user has not selected the exit option
      } while(input != EXIT_MENU);
      
    }//end show options menu

    Serial.println(END_HANDSHAKE);
    
}//end pollUserForOptionsMenu

/**
 * Helper function.
 * setupReleaseServo()
 * Sets up the servo motor by attaching it and insuring the shaft angle is at the starting position.
 */
void setupReleaseServo(){

  // Attach the release servo motor
  releaseServo.attach(RELEASE_SERVO_PIN);

  // If the servo shaft is not at the starting angle
  if(releaseServo.read() != RELEASE_SERVO_STARTING_ANGLE){
    
    // Set the release servo shaft to the starting angle
    releaseServo.write(RELEASE_SERVO_STARTING_ANGLE);
  
    // Wait for the servo to get to the starting angle
    while(releaseServo.read() != RELEASE_SERVO_STARTING_ANGLE){}
    
  }//end if servo shaft is not in initial position
  
}//end setupReleaseServo

/**
 * Helper function.
 * parseInput(byte input)
 * Determines which option to execute based on the Serial input.
 */
void parseInput(byte input){
  
  // Based on user input select the appropriate menu item
  switch(input){
  
    // Data should be sent to the Serial connection
    case SEND_DATA : data.sendData();
                     break;
  
    // All data should be erased from EEPROM
    case ERASE_DATA: data.eraseData();
                     break;
  
    // The user would like to exit the menu
    case EXIT_MENU : Serial.println("Menu Exited");
                     break;
  
    // If input is invalid notify the user
    default        : Serial.println("Unsupported Input");
   
  }//end switch
  
}//end parseInput

/**
 * Helper function.
 * sendMenu()
 * Sends the options menu over the serial connection.
 */
void sendMenu(){
  Serial.println("Options:");
  Serial.println("  1. Send Data");
  Serial.println("  2. Erase Data");
  Serial.println("  3. Exit Menu");
}//end sendMenu

/**
 * Helper function.
 * getTemperature(int resistance)
 * Converts the resistance value into a farenheit and celsius.
 * When converting to 3.3 Volts the numerator value of 33,000 is 
 * an estimate. This value was not taken from any datasheet.
 * The value of 3950 was modified until reasonable values were
 * collected for a 3.3V reading when compared to a 5V reading.
 */
String getTemperature(int resistance){
  // Scale the resistance value
  int a = 1023 - resistance;

  // Convert resistance to celsius
  float tempC = beta / (log(1025.0 / a - 1) + beta / 298.0) - 273.0;
  
  // Convert to farenheit
  float tempF = 1.8*tempC + 32.0;

  // Convert both floats to Strings
  String c = String(tempC);
  String f = String(tempF);

  // Return a formatted String
  return (c + " *C / " + f + " *F");
}//end getTemperature




