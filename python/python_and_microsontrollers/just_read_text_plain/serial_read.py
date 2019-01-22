# need download the pyserial
import serial

try:
    serIO = serial.Serial('COM6', 115200)
except:
        print ("Error was ocurred")

while True:
        print (serIO.readline())