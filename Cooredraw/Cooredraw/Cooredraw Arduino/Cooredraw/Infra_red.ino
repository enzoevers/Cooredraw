// The library for the infra red receiver.
#include <IRremote.h>

long lastRemoteMilliseconds = 0;

void remoteInput(IRrecv receiver) {
  decode_results input;
  int remoteCommand = 0;

  if (receiver.decode(&input) && millis() -  lastRemoteMilliseconds > 200) {
    lastRemoteMilliseconds = millis();
    remoteCommand = input.value;
    getUsableInput(remoteCommand);
    receiver.resume();
  }
}



char usableInputValue;
void getUsableInput(int input) {
  String next;

  if (input == 26775) {
    usableInputValue = '0';
  }
  else if (input == 12495) {
    usableInputValue = '1';
  }
  else if (input == 6375) {
    usableInputValue = '2';
  }
  else if (input == 31365) {
    usableInputValue = '3';
  }
  else if (input == 4335) {
    usableInputValue = '4';
  }
  else if (input == 14535) {
    usableInputValue = '5';
  }
  else if (input == 23205) {
    usableInputValue = '6';
  }
  else if (input == 17085) {
    usableInputValue = '7';
  }
  else if (input == 19125) {
    usableInputValue = '8';
  }
  else if (input == 21165) {
    usableInputValue = '9';
  }
  else if (input == 8925) {
    next = "10";
  }
  else if (input == 765) {
    next = "11";
  }
  else {
    next = "999";
  }

  printCommand(usableInputValue, next);
  //Serial.println();
}


String valueRGB;
long intValueRGB;
int RGBValues[3];
int i = 0;

void printCommand(char usableInput, String Next) {
  if (String(usableInput).toInt() <= 9 && Next == "") {

    Serial.print("usableInput: ");
    Serial.println(usableInput);
    valueRGB += usableInput;
    intValueRGB = valueRGB.toInt();
    /*Serial.print("valueRGB before: ");
      Serial.println(valueRGB);
      Serial.print("intValueRGB before: ");
      Serial.println(intValueRGB);
      Serial.println();*/

    if (intValueRGB <= 255) {
      RGBValues[i] = intValueRGB;
      /*Serial.print("valueRGB: ");
        Serial.println(valueRGB);
        Serial.print("intValueRGB: ");
        Serial.println(intValueRGB);
        Serial.println();
        Serial.println();*/
    }
    else if (intValueRGB > 255) {
      valueRGB = "";
      intValueRGB = valueRGB.toInt();
      RGBValues[i] = intValueRGB;
      /*Serial.print("restart ");
        Serial.println(valueRGB);
        Serial.print("restart ");
        Serial.println(intValueRGB);
        Serial.println();
        Serial.println();*/
    }
    usableInput = ' ';
  }
  else if (Next == "10") {
    //Serial.print("Previous: ");
    i--;
    if (i < 0) {
      i = 2;
    }
    indecateSelectedColor(i);
  }
  else if (Next == "11") {
    //Serial.print("Next: ");
    i++;
    if (i > 2) {
      i = 0;
    }
    indecateSelectedColor(i);
  }
  else if (Next = "999") {
  }

  fontColorLed(RGBValues[0], RGBValues[1], RGBValues[2]);

  Serial.print("#RED_VALUE:");
  Serial.print(RGBValues[0]);
  Serial.print('%');
  Serial.print("#GREEN_VALUE:");
  Serial.print(RGBValues[1]);
  Serial.print('%');
  Serial.print("#BLUE_VALUE:");
  Serial.print(RGBValues[2]);
  Serial.print('%');
}

void indecateSelectedColor(int i) {
  int flickerDelay = 125;
  if (i == 0) {
    statusLedHelper(255, 0, 0);
    delay(flickerDelay);
    statusLedHelper(0, 0, 0);
    delay(flickerDelay);
    statusLedHelper(255, 0, 0);
    delay(flickerDelay);
    statusLedHelper(0, 0, 0);
    delay(flickerDelay);
  }
  else if (i == 1) {
    statusLedHelper(0, 255, 0);
    delay(flickerDelay);
    statusLedHelper(0, 0, 0);
    delay(flickerDelay);
    statusLedHelper(0, 255, 0);
    delay(flickerDelay);
    statusLedHelper(0, 0, 0);
    delay(flickerDelay);
  }
  else if (i == 2) {
    statusLedHelper(0, 0, true);
    delay(flickerDelay);
    statusLedHelper(0, 0, 0);
    delay(flickerDelay);
    statusLedHelper(0, 0, true);
    delay(flickerDelay);
    statusLedHelper(0, 0, 0);
    delay(flickerDelay);
  }
}

