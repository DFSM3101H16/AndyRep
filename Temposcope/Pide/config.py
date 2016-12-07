import speech_recognition as sr

from os import mkdir, path
from os.path import join
from sys import platform as _platform

######HEARING
FREQUENT_ACTIVE_LISTEN = True

#DEBUG
USE_SST = True
USE_TTS = True

#Max gTTS (speaking) string length
MAX_CHAR = 200 #140

#LANGUAGE
LANG = 'en'
LANG_4CODE = 'en-US'

#RESPONSES
ERROR = "Something went wrong. Would you like to see the error message?"
NO_MIC = "I could not connect to a microphone."

#DIRECTORIES
CLIENT_DIR = path.dirname(path.abspath(__file__))
BASE_DIR = path.dirname(CLIENT_DIR)
DATA_DIR = path.join(CLIENT_DIR, 'data')
MEDIA_DIR = path.join(DATA_DIR, 'media')
USERS_DIR = path.join(DATA_DIR, 'users')


DIRS = [USERS_DIR, MEDIA_DIR]

for d in DIRS:
    if not path.exists(d):
        mkdir(d)


