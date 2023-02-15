int stop_light = 13;
int warning_light = 12;
int go_light = 11;

String command;
int powered;
int red_duration;
int yellow_duration;
int green_duration;

void setup() {
Serial.begin(4800);
pinMode(stop_light, OUTPUT);
pinMode(warning_light, OUTPUT);
pinMode(go_light, OUTPUT);
powered = 1;
red_duration = 1 * 1000;
yellow_duration = 1 * 1000;
green_duration = 1 * 1000;
}

void loop() {
    while(Serial.available()){
    command = Serial.readString();
    if(command.length() > 0){
      if(command.equals("off")){
        powered = 0;
      }else if(command.equals("on")){
        powered = 1;
      }
      else if(command.substring(0, 6).equals("setred")){
        int new_duration = command.substring(6, command.length()).toInt();
        red_duration = new_duration * 1000;
        command = "";
      }else if(command.substring(0, 6) == "setylw"){
        int new_duration = command.substring(6, command.length()).toInt();
        yellow_duration = new_duration * 1000;
      }else if(command.substring(0, 6) == "setgrn"){
        int new_duration = command.substring(6, command.length()).toInt();
        green_duration = new_duration * 1000;
      }
    }
     command = "";
  }
  
    if(powered == 1){
    digitalWrite(stop_light, HIGH);
    delay(red_duration);
    digitalWrite(stop_light, LOW);
    digitalWrite(go_light, HIGH);
    delay(green_duration);
    digitalWrite(go_light, LOW);
    digitalWrite(warning_light, HIGH);
    delay(yellow_duration);
    digitalWrite(warning_light, LOW);
    }else if(powered == 0){
      digitalWrite(stop_light, LOW);
      digitalWrite(warning_light, LOW);
      digitalWrite(go_light, LOW);
    }
}
