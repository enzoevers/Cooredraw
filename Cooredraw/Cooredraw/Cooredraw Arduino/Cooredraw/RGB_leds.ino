/*
   Regarding the state parameter:
                                  1 = start
                                  2 = pauzse
                                  3 = stop
*/
long ledDelayLastMillis = 0;

void statusLed(int state) {
  if (state == 1) {
    statusLedHelper(0, 255, 0);
  }
  else if (state == 2) {
    statusLedHelper(255, 40, 0);
  }
  else if (state == 3) {
    statusLedHelper(255, 0, 0);
  }
}

void statusLedHelper(int R, int G, bool B) {
  analogWrite(ledStatusR, R);
  analogWrite(ledStatusG, G);
  digitalWrite(ledStatusB, B);
}

void fontColorLed(int R, int G, int B) {
  analogWrite(ledFontColorR, R);
  analogWrite(ledFontColorG, G);
  analogWrite(ledFontColorB, B);
}

