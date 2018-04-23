//JOYSTICKS
// name the pins where the joysticks will be connected
const int joystickOneLeft = 2;
const int joystickOneRight = 3;
const int joystickOneDown = 4;
const int joystickOneUp = 5;

const int joystickTwoLeft = 6;
const int joystickTwoRight = 7;
const int joystickTwoDown = 8;
const int joystickTwoUp = 9;
//

/*//ROTARY ENCODER
// name the pins where the rotary encoder will be connected
const int  outputA = 10;
const int  outputB = 11;

//varibles used for rotary encoder
int counter1 = 0; 
int aState;
int aLastState; 
//*/

//JOYSTICK states
int joystickOneLeftState = LOW;
int joystickOneRightState = LOW;
int joystickOneDownState = LOW;
int joystickOneUpState = LOW;

int joystickTwoLeftState = LOW;
int joystickTwoRightState = LOW;
int joystickTwoDownState = LOW;
int joystickTwoUpState = LOW;
//

// the joystick value that will be sent to arduino. 
int joystickOneOutput = 0;
int joystickTwoOutput = 0;
//


// The array which will contain the values from the objects. this array will be sent to unity.
int data[2] = {}; // empty array, 2 slots
//


void setup() {
  //JOYSTICKS
  //declare the pins as input.
  pinMode(joystickOneLeft, INPUT);
  pinMode(joystickOneRight, INPUT);
  pinMode(joystickOneDown, INPUT);
  pinMode(joystickOneUp, INPUT);

  pinMode(joystickTwoLeft, INPUT);
  pinMode(joystickTwoRight, INPUT);
  pinMode(joystickTwoDown, INPUT);
  pinMode(joystickTwoUp, INPUT);
  //
  
 /* //ROTARY ENCODER
  pinMode (outputA,INPUT);
  pinMode (outputB,INPUT);

  // Reads the initial state of the outputA
  aLastState = digitalRead(outputA);*/

  Serial.begin(115200);
}

void loop() {
// read from the pins
  joystickOneLeftState = digitalRead(joystickOneLeft);
  delay(10);
  joystickOneRightState = digitalRead(joystickOneRight);
  delay(10);
  joystickOneDownState = digitalRead(joystickOneDown);
  delay(10);
  joystickOneUpState = digitalRead(joystickOneUp);
  delay(10);

  joystickTwoLeftState = digitalRead(joystickTwoLeft);
  delay(10);
  joystickTwoRightState = digitalRead(joystickTwoRight);
  delay(10);
  joystickTwoDownState = digitalRead(joystickTwoDown);
  delay(10);
  joystickTwoUpState = digitalRead(joystickTwoUp);
  delay(10);


  // Joystick ONE 
  // check where in which direction the joystick is moved
  if (joystickOneLeftState == LOW && joystickOneRightState == LOW && joystickOneDownState == LOW && joystickOneUpState == LOW )
  { 
    joystickOneOutput = 0; 
  }
  else if (joystickOneLeftState == LOW && joystickOneRightState == LOW && joystickOneDownState == LOW && joystickOneUpState == HIGH)
  { 
    joystickOneOutput = 1;
  }
  else if (joystickOneLeftState == LOW && joystickOneRightState == HIGH && joystickOneDownState == LOW && joystickOneUpState == HIGH )   
  {
    joystickOneOutput = 2;
  }
  else if (joystickOneLeftState == LOW && joystickOneRightState == HIGH && joystickOneDownState == LOW && joystickOneUpState == LOW )
  {
    joystickOneOutput = 3;
  }
  else if (joystickOneLeftState == LOW && joystickOneRightState == HIGH && joystickOneDownState == HIGH && joystickOneUpState == LOW )
  {
    joystickOneOutput = 4;
  }
  else if (joystickOneLeftState == LOW && joystickOneRightState == LOW && joystickOneDownState == HIGH && joystickOneUpState == LOW )
  {
    joystickOneOutput = 5;
  }
  else if (joystickOneLeftState == HIGH && joystickOneRightState == LOW && joystickOneDownState == HIGH && joystickOneUpState == LOW )
  {
    joystickOneOutput = 6;
  }
  else if (joystickOneLeftState == HIGH && joystickOneRightState == LOW && joystickOneDownState == LOW && joystickOneUpState == LOW )
  {
    joystickOneOutput = 7;
  }
  else if (joystickOneLeftState == HIGH && joystickOneRightState == LOW && joystickOneDownState == LOW && joystickOneUpState == HIGH )
  {
    joystickOneOutput = 8;
  }

  
  //Joystick TWO
  
  if (joystickTwoLeftState == LOW && joystickTwoRightState == LOW && joystickTwoDownState == LOW && joystickTwoUpState == LOW )
  { 
    joystickTwoOutput = 0; 
  }
  else if (joystickTwoLeftState == LOW && joystickTwoRightState == LOW && joystickTwoDownState == LOW && joystickTwoUpState == HIGH)
  { 
    joystickTwoOutput = 1;
  }
  else if (joystickTwoLeftState == LOW && joystickTwoRightState == HIGH && joystickTwoDownState == LOW && joystickTwoUpState == HIGH )   
  {
    joystickTwoOutput = 2;
  }
  else if (joystickTwoLeftState == LOW && joystickTwoRightState == HIGH && joystickTwoDownState == LOW && joystickTwoUpState == LOW )
  {
    joystickTwoOutput = 3;
  }
  else if (joystickTwoLeftState == LOW && joystickTwoRightState == HIGH && joystickTwoDownState == HIGH && joystickTwoUpState == LOW )
  {
    joystickTwoOutput = 4;
  }
  else if (joystickTwoLeftState == LOW && joystickTwoRightState == LOW && joystickTwoDownState == HIGH && joystickTwoUpState == LOW )
  {
    joystickTwoOutput = 5;
  }
  else if (joystickTwoLeftState == HIGH && joystickTwoRightState == LOW && joystickTwoDownState == HIGH && joystickTwoUpState == LOW )
  {
    joystickTwoOutput = 6;
  }
  else if (joystickTwoLeftState == HIGH && joystickTwoRightState == LOW && joystickTwoDownState == LOW && joystickTwoUpState == LOW )
  {
    joystickTwoOutput = 7;
  }
  else if (joystickTwoLeftState == HIGH && joystickTwoRightState == LOW && joystickTwoDownState == LOW && joystickTwoUpState == HIGH )
  {
    joystickTwoOutput = 8;
  }


/*   aState = digitalRead(outputA); // Reads the "current" state of the outputA
   // If the previous and the current state of the outputA are different, that means a Pulse has occured
   if (aState != aLastState){     
     // If the outputB state is different to the outputA state, that means the encoder is rotating clockwise
     if (digitalRead(outputB) != aState) { 
       counter1 ++;
     } else {
       counter1 --;
     }
        } 
   aLastState = aState; // Updates the previous state of the outputA with the current state

*/



  data[0] = joystickOneOutput;
  data[1] = joystickTwoOutput;
/*  data[2] = 0;//counter1; 
  data[3] = 0;//counter2;
  data[4] = 0;//soundDetectorOutput;*/
 

  for (int i = 0; i < 2; ++i)
    {
      Serial.print(data[i]);
    }
    
  Serial.println(" ");




}
