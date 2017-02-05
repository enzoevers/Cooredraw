String message = "";
char messageStarter = '#';
char messageEnder = '%';
bool reading = false;

bool doneReading = false;

void serial() {
  if (Serial.available() > 0) {
    readIncommingMessage();
  }
}

bool done(){
  return doneReading;
}

void readIncommingMessage() {
  byte receivedByte =  Serial.read();
  char receivedChar = (char)receivedByte;

  if (receivedChar == messageEnder && reading) {
    reading = false;
    doneReading = true;
    //Serial.println(message);
  }

  if (reading) {
    message += receivedChar;
  }

  if (receivedChar == messageStarter) {
    message = "";
    reading = true;
  }
}

int returnWidth() {
  if (message.indexOf("CANVAS_WIDTH") != -1) {
    doneReading = false;
    String value = message.substring(message.indexOf(':')+1);
  
    /*char valueArray[size(value)];
      value.toCharArray(valueArray, size(value));
      for(int i = 0; i < value.length(); i++){
      valueArray[i] = (char)value.substring(i, 1);
      }
      long maxWidth = atol(valueArray);*/
    int maxWidth = value.toInt();
    return maxWidth;
  }
}

int returnHieght() {
  if (message.indexOf("CANVAS_HEIGHT") != -1) {
    doneReading = false;
    String value = message.substring(message.indexOf(':')+1);
    /*char valueArray[size(value)];
      value.toCharArray(valueArray, size(value));
      for(int i = 0; i < value.length(); i++){
      valueArray[i] = (char)value.substring(i, 1);
      }
      long maxHeight = atol(valueArray);*/
    int maxHeight = value.toInt();
    return maxHeight;
  }
}

String receivedPieceOfMessage(){
  return message;
}

