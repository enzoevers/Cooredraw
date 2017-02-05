long X_Coordinate = 0;
long Y_Coordinate = 0;
long lastX_Coordinate = 0;
long lastY_Coordinate = 0;
const double coordinateRangeSetter = 1.75;
const int outerMargin = 100;
const int innerMargin = 10;

long lastMillisCoordinateSender = 0;

long sendXCoordiante(int XT, int XE, int maxWidth) {
  // Send a 'beam of light' of whish the time is measured to know
  // how far an object is.
  digitalWrite(XT, LOW);
  delayMicroseconds(2);
  digitalWrite(XT, HIGH);
  delayMicroseconds(2);
  digitalWrite(XT, LOW);

  long duration = pulseIn(XE, HIGH);
  long currentX_Coordinate = (duration / 2) / coordinateRangeSetter; //First devided by two to get just the streight line distance instead of the send to + receive from distance, and than devided by a variable.
  /*Serial.print("currentX_Coordinate: ");
    Serial.println(currentX_Coordinate);
    Serial.print("lastX_Coordinate; ");
    Serial.println(lastX_Coordinate);*/

  if (currentX_Coordinate >= maxWidth) {
    //Serial.println(maxWidth);
    X_Coordinate = maxWidth;
  }
  else if (currentX_Coordinate < maxWidth) {
    if ((currentX_Coordinate > (lastX_Coordinate - outerMargin) &&  currentX_Coordinate < (lastX_Coordinate - innerMargin)) || (currentX_Coordinate < (lastX_Coordinate + outerMargin) && currentX_Coordinate > (lastX_Coordinate + innerMargin))) {
      X_Coordinate = currentX_Coordinate;
      lastX_Coordinate = currentX_Coordinate;
      /*Serial.print("#X_COORDINATE:");
        Serial.print(X_Coordinate);
        Serial.print('%');*/
    }
    else {
      X_Coordinate = lastX_Coordinate;
    }
  }

  /*if(X_Coordinate > maxWidth){
    X_Coordinate = maxWidth;
    }*/

  /*Serial.print("X_Coordinate: ");
    Serial.println(X_Coordinate);*/

  return X_Coordinate;
}

long sendYCoordiante(int YT, int YE, int maxHeight) {

  // Send a 'beam of light' of whish the time is measured to know
  // how far an object is.
  digitalWrite(YT, LOW);
  delayMicroseconds(2);
  digitalWrite(YT, HIGH);
  delayMicroseconds(2);
  digitalWrite(YT, LOW);

  long duration = pulseIn(YE, HIGH);
  long currentY_Coordinate = (duration / 2) / coordinateRangeSetter; //First devided by two to get just the streight line distance instead of the send to + receive from distance, and than devided by a variable.
  /*Serial.print("currentY_Coordinate: ");
    Serial.println(currentY_Coordinate);
    Serial.print("lastY_Coordinate; ");
    Serial.println(lastY_Coordinate);*/

  if (currentY_Coordinate >= maxHeight) {
    Y_Coordinate = maxHeight;
  }
  else if (currentY_Coordinate < maxHeight) {
    if ((currentY_Coordinate > (lastY_Coordinate - outerMargin) &&  currentY_Coordinate < (lastY_Coordinate - innerMargin)) || (currentY_Coordinate < (lastY_Coordinate + outerMargin) && currentY_Coordinate > (lastY_Coordinate + innerMargin))) {
      Y_Coordinate = currentY_Coordinate;
      lastY_Coordinate = currentY_Coordinate;
      /*Serial.print("#Y_COORDINATE:");
        Serial.print(Y_Coordinate);
        Serial.print('%');*/
    }
    else {
      Y_Coordinate = lastY_Coordinate;
    }
  }

  /*Serial.print("Y_Coordinate: ");
    Serial.println(Y_Coordinate);
    Serial.println();*/

  return Y_Coordinate;
}

void sendCoordinate() {
  if (millis() - lastMillisCoordinateSender > 75) {
    Serial.print("#X_COORDINATE:");
    Serial.print(X_Coordinate);
    Serial.print('%');
    //Serial.println();
    Serial.print("#Y_COORDINATE:");
    Serial.print(Y_Coordinate);
    Serial.print('%');
    Serial.println();
    lastMillisCoordinateSender = millis();
  }
}



