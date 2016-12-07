import serial
import time


def sendWeather(rain):
    if(rain == 1):
        print "IT IS RAINING!"
    if(rain == 0):
        print "IT IS NOT RAINING!"
    
#ser = serial.Serial('/dev/ttyACM0', 9600)
#time.sleep(2)
#ser.write('ggggcccc4444444455554544gggggggg')

def debugLights(lights):
    ser = serial.Serial('/dev/ttyACM0', 9600)
    time.sleep(2)
    if(lights == 1):
        ser.write('s')
        print "Turn on lights"
    if (lights == 0):
        ser.write('x')
        print "Turn off lights"





