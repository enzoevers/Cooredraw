// The library for the infra red receiver.
#include <IRremote.h>

// The led that represents the status of the program.
int ledStatusR = 11;
int ledStatusG = 10;
int ledStatusB = 9;

// The led that shows the color that is drawn in.
int ledFontColorR = 3;
int ledFontColorG = 5;
int ledFontColorB = 6;

// The mic that is used for controlling the status of the program.
int micAnalog = A5;

// The infra red sensor that gets the incomming remote code.
int IRreveiverPin = 4;
IRrecv IRreceiver(IRreveiverPin);

// The ultrasone sensors for contrilling the coordinates to draw.
int X_Trig = 7;
int X_Echo = 8;

int Y_Trig = 12;
int Y_Echo = 13;

int maxWidth;
int maxHeight;

void setup() {
  Serial.begin(115200);

  // Gives all the leds the pinMode OUTPUT.
  for (int i = 3; i <= 11; i++) {
    if (i != 4 || i != 7 || i != 8) {
      pinMode(i, OUTPUT);
    }
  }

  // Setup for the microphone
  pinMode(micAnalog, INPUT);

  // Setup for the ultrasone sensors.
  pinMode(X_Trig, OUTPUT);
  pinMode(Y_Trig, OUTPUT);
  pinMode(X_Echo, INPUT);
  pinMode(Y_Echo, INPUT);

  // Starts the IR reveiver.
  IRreceiver.enableIRIn();
}

void loop() {
  serial();
  if (done()) {
    if (receivedPieceOfMessage().indexOf("CANVAS_WIDTH") != -1) {
      maxWidth = returnWidth();
    }
    else {
      maxWidth = maxWidth;
    }

    if (receivedPieceOfMessage().indexOf("CANVAS_HEIGHT") != -1) {
      maxHeight = returnHieght();

    }
    else {
      maxHeight = maxHeight;
    }

    /*Serial.print("maxWidth: ");
    Serial.println(maxWidth);
    Serial.print("maxHeight: ");
    Serial.println(maxHeight);*/
  }

  statusLed(detectSound(micAnalog));
  if (!returnInSelectMode() && returnState() == 1) {
    sendXCoordiante(X_Trig, X_Echo, maxWidth);
    sendYCoordiante(Y_Trig, Y_Echo, maxHeight);
    sendCoordinate();
  }
  else if (returnState() == 2) {
    remoteInput(IRreceiver);
  }
}
