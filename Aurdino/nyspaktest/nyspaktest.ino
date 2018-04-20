// vilken pin som knapparna sitter på 
const int b1 = 2;
const int b2 = 3;
const int b3 = 4;
const int b4 = 5;
const int b5 = 6;
const int b6 = 7;

int const declaration_length = 14;
int declaration[declaration_length];

// varibler som kommer representera in signal till arduinon 
int b1s = 0;
//int b2s = 0;
int b3s = 0;
int b4s = 0;
int b5s = 0;
int b6s = 0;
void setup() {
// sätter alla pins till att ta in signaler  
 pinMode(b1, INPUT);
 pinMode(b2, OUTPUT);
 pinMode(b3, INPUT);
 pinMode(b4, INPUT);
 pinMode(b5, INPUT);
 pinMode(b6, INPUT);
 Serial.begin(9600);
}

void loop() {
  // läser av varje switch/knapp 
    b1s = digitalRead(b1);
    //b2s = digitalRead(b2);
    b3s = digitalRead(b3);
    b4s = digitalRead(b4);
    b5s = digitalRead(b5);
    b6s = digitalRead(b6);
    delay(5);
  //om en knapp blir tryckt.
    if (b1s == HIGH)
    {
      declaration[0] =1;
      digitalWrite(b2, HIGH);
    }else 
    {
      declaration[0] =0;
      //digitalWrite(b2, LOW);
    }
    //Down
    if (b3s == HIGH)
    {
        declaration[11] =2;
    }else if(b6s == HIGH)
    {
      declaration[11] =1;
    }else
    {
      declaration[11] =0;
    }
    //Up
    if (b4s == HIGH)
    {
        declaration[10] =1;
    }else if(b5s == HIGH){
      declaration[10] =2;
    }else{
      declaration[10] =0;
    }
  
    declaration[1] =0;  
    declaration[2] =0;
    declaration[3] =0;
    declaration[4] =0;
    declaration[5] =0;
    declaration[6] =0;
    declaration[7] =0;
    declaration[8] =0;
    declaration[9] =0;
    //declaration[10] =0;//Horizontal   //Left
    //declaration[11] =0;//Vertical
    declaration[12] =0;              //Right
    declaration[13] =0;
    
  
    for(int i = 0; i < declaration_length; i++){
      Serial.print(declaration[i]);
    }
    Serial.println(' ');
    Serial.flush();
    if(Serial.available() > 0)
    {
       char ltr = Serial.read();
       if(ltr == '1')
       {
          digitalWrite(b2, HIGH);
       }
       else if(ltr = '0'){
          digitalWrite(b2, LOW);
       }
    }
    
}
