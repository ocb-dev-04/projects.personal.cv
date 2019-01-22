# need download the pyserial and simplejson
import serial
import simplejson as simpleJson

# change COM and baudRate values
serIO = serial.Serial('COM4', 115200)

while True:
        jsonResult = serIO.readline()

        try:
                jsonObject = simpleJson.loads(jsonResult)
                print (jsonObject["x"]) # x is the parameter name what need show
        except Exception:
                print("Ups some error ocurred")