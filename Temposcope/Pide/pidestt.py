import pyaudio
import speech_recognition

import config
import pidetts
import time


def init():
    global r
    r = speech_recognition.Recognizer()
    global p
    p = pyaudio.PyAudio()
    

def active_listen():
    global r
    with pidetts.ignore_stderr():        
        with speech_recognition.Microphone() as source:
            print("\n~ Active listening... ")
            audio = r.listen(source)
        msg = ''
        try:
            msg = r.recognize_google(audio)
            print('\n~ "'+msg+'"')
        except sr.UnknownValueError:
            print("GPR could not understand your audio!")
        except sr.RequestError as e:
            print("Could not request results from Google Speech Recognition service; {0}".format(e))
        except:
            pidebrain.inst.error()
        finally:
            return msg

def passive_listen():
    global r
    with pidetts.ignore_stderr():
        with speech_recognition.Microphone() as source:
            print("\n~ Passive listening... ")
            audio = r.listen(source)
        msg = ''
        t_end = time.time() + 3
        while time.time() < t_end:
            try:
                msg = r.recognize_google(audio)
                print('\n~ "'+msg+'"')
            except sr.UnknownValueError:
                print("GPR could not understand your audio!")
            except sr.RequestError as e:
                print("Could not request results from Google Speech Recognition service; {0}".format(e))
            except:
                pidebrain.inst.error()
            finally:
                t_end = 0
                return msg
            



