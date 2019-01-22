const int led = 13;

void setup() {
  pinMode(led, OUTPUT);
  Serial.begin(115200);
}

void loop() {
  onLed();
  offLed();
}

//--------------------------------------------------------------

void onLed(){
  Serial.println("Led is ON");
  digitalWrite(led, HIGH);
  delay(1000);
}

void offLed(){
  Serial.println("Led is OFF");
  digitalWrite(led, LOW);
  delay(1000);
}