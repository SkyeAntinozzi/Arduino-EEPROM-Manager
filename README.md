# Arduino-EEPROM-Manager


The Arudino EEPROM Manager was created for the Research Enrichment for Undergraduates program at the University of North Dakota during the summer of 2016. The software was created in order to simplify the collection and post-processing of cube satellite temprature data collected during a high altitude balloon flight. The C# interface works in conjunction with the Launch.ino file, which is loaded onto an Arudino compatible chipset using a temperature sensor. 

The main form provides most functions for interfacing with a connected Arduino device. A protocol is established between the Arduino chipset and the EEPROM Manager over a COM serial port in order to synchronize data transmission. 

![EEPROM Main Form](/Git_Images/EEPROM_Main.png?raw=true "EEPROM Main Form")

![EEPROM About Form](/Git_Images/EEPROM_About.png?raw=true "EEPROM About Form")
