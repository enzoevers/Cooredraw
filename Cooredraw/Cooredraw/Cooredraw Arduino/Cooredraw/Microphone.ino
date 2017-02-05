int state = 0;
int timesOfSoundDetected = 0;
bool stateIsSelected = false;

int soundLevel = 0;

long lastMillis = 0;

bool selectMode;
int detectSound(int micPin) {
  /*
     Variables
  */
  const long inBetweenTime = 1500;
  int threshold = 400;

  bool inSelectMode = false;

  soundLevel = analogRead(micPin);

  /*
     Detects if incomming sound is above a certain level.
  */
  if (soundLevel >= threshold) {
    fontColorLed(255, 0, 0);
    delay(175); // A delay that ensures that one and only one sound is detected.
    fontColorLed(0, 0, 0);
    inSelectMode = true;
    selectMode = inSelectMode;
  }

  /*
     Increments timesOfSoundDetected(helper for determining the program state) by one.
  */
  if (inSelectMode) {
    //Serial.println(soundLevel);

    if (millis() - lastMillis <= inBetweenTime) { // Checks if the time between sound detection is less then 1.5 seconds.
      lastMillis = millis();
      //Serial.println("In select mode.");

      timesOfSoundDetected++;
      if (timesOfSoundDetected > 3) { // Ensures that the state can only be 1, 2 or 3.
        timesOfSoundDetected = 3;
      }

      //Serial.println(timesOfSoundDetected);
      stateIsSelected = false;
    }
  }

  /*
     If more time has passed than 1.5 seconds timesOfSoundDetected is assigned to state.
  */
  if (millis() - lastMillis > inBetweenTime) { // If no sound was detected for more than 2 seconds state is given the value of timesOfSoundDetected.
    lastMillis = millis();
    if (!stateIsSelected) {
      state = timesOfSoundDetected;
      timesOfSoundDetected = 0;
      stateIsSelected = true;
    }

    Serial.print("#STATE:");
    Serial.print(state);
    Serial.println('%');
    inSelectMode = false;
    selectMode = inSelectMode;
  }

  return state;
}


bool returnInSelectMode() {
  return selectMode;
}

int returnState() {
  return state;
}

