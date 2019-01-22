const int switcH = 2;
const int x = 0;
const int y = 1;

void setup() {
  pinMode(switcH, INPUT);
  digitalWrite(switcH, HIGH);
  Serial.begin(115200);
}

void loop() {
  //convert info received to "json format file"
  Serial.println("{\"x\":" +(String)analogRead(x) +", \"y\":" + (String)analogRead(y) +"}");
  delay(100);
}
