
//LAMPS
// name the pins (the pin where the button/lamp is connected) 
const int buttonOne = 2; // Pin 2 is named buttonOne and the first button is connected there.  
const int lamp1 = 3;

const int buttonTwo = 4;
const int lamp2 = 5;

const int buttonThree = 6;
const int lamp3 = 7;

const int buttonFour = 8;
const int lamp4 = 9;

const int buttonFive = 10;
const int lamp5 = 11;
//

// BUTTON states 
int buttonOneState = 0; 
int buttonTwoState = 0;
int buttonThreeState = 0;
int buttonFourState = 0;
int buttonFiveState = 0;
//

// The array which will contain the values from the objects. this array will be sent to unity.
int data[10] = {}; // empty array, 18 slots.
//


//LAMP STATE and varibles for READING "BUTTON-PRESS"

int lampState1 = LOW; //the current state of the output
int reading1;         // the current reading from the input pin
int previous1 = HIGH; // the previous reading from the input pin

int lampState2 = LOW; 
int reading2;      
int previous2 = HIGH; 

int lampState3 = LOW; 
int reading3;      
int previous3 = HIGH; 

int lampState4 = LOW; 
int reading4;      
int previous4 = HIGH; 

int lampState5 = LOW; 
int reading5;      
int previous5 = HIGH; 

long time = 0;
long debounce = 200;

void setup() {

  //BUTTONS
  // declare the pins as input.
  pinMode(buttonOne, INPUT);
  pinMode(buttonTwo, INPUT);
  pinMode(buttonThree, INPUT);
  pinMode(buttonFour, INPUT);
  pinMode(buttonFive, INPUT);
  

  //LAMPS
  //declare the pins as output. arduino sends signals to these pins. 
  pinMode(lamp1, OUTPUT);
  pinMode(lamp2, OUTPUT);
  pinMode(lamp3, OUTPUT);
  pinMode(lamp4, OUTPUT);
  pinMode(lamp5, OUTPUT);
  //
  
  Serial.begin(9600);
}

void loop() {

 // read from the inputs pin (buttonstate = 1 or = 0) 
 buttonOneState = digitalRead(buttonOne);
 delay(20);
 buttonTwoState = digitalRead(buttonTwo);
 delay(20);
 buttonThreeState = digitalRead(buttonThree);
 delay(20);
 buttonFourState = digitalRead(buttonFour);
 delay(20);
 buttonFiveState = digitalRead(buttonFive);

 // check if button has been pressed

  // 1
  if (buttonOneState == HIGH && previous1 == LOW && millis() - time > debounce) {
    if (lampState1 == HIGH)
      lampState1 = LOW;
    else
      lampState1 = HIGH;
    time = millis();
  }

  digitalWrite(lamp1, lampState1);
  previous1 = buttonOneState;

// 2
  if (buttonTwoState == HIGH && previous2 == LOW && millis() - time > debounce) {
    if (lampState2 == HIGH)
      lampState2 = LOW;
    else
      lampState2 = HIGH;
    time = millis();
  }

  digitalWrite(lamp2, lampState2);
  previous2 = buttonTwoState;

  // 3
    if (buttonThreeState == HIGH && previous3 == LOW && millis() - time > debounce) {
    if (lampState3 == HIGH)
      lampState3 = LOW;
    else
      lampState3 = HIGH;
    time = millis();
  }

  digitalWrite(lamp3, lampState3);
  previous3 = buttonThreeState;

  // 4
    if (buttonFourState == HIGH && previous4 == LOW && millis() - time > debounce) {
    if (lampState4 == HIGH)
      lampState4 = LOW;
    else
      lampState4 = HIGH;
    time = millis();
  }

  digitalWrite(lamp4, lampState4);
  previous4 = buttonFourState;

  //5
    if (buttonFiveState == HIGH && previous5 == LOW && millis() - time > debounce) {
    if (lampState5 == HIGH)
      lampState5 = LOW;
    else
      lampState5 = HIGH;
    time = millis();
  }

  digitalWrite(lamp5, lampState5);
  previous5 = buttonFiveState;




  data[0] = buttonOneState;
  data[1] = lampState1;
  data[2] = buttonTwoState;
  data[3] = lampState2;
  data[4] = buttonThreeState;
  data[5] = lampState3;
  data[6] = buttonFourState;
  data[7] = lampState4;;
  data[8] = buttonFiveState;;
  data[9] = lampState5;;

 for (int i = 0; i < 10; ++i)
  {
    Serial.print(data[i]);
  }
  Serial.println(" ");

}

