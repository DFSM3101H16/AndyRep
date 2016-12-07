import contextlib
import sys
import tempfile
import os

from requests.exceptions import HTTPError
from gtts import gTTS

import config

@contextlib.contextmanager
def ignore_stderr():
    devnull = os.open(os.devnull, os.O_WRONLY)
    old_stderr = os.dup(2)
    sys.stderr.flush()
    os.dup2(devnull, 2)
    os.close(devnull)
    try:
        yield
    finally:
        os.dup2(old_stderr, 2)
        os.close(old_stderr)

def play_mp3(file_name, file_path=config.MEDIA_DIR):    
    with ignore_stderr():
        os.system("omxplayer -o local ./data/media/out.mp3")

def speak(phrase, cache=False, filename='default', show_text=True):
    if show_text:
        print('\n~ ' +phrase+'\n')
    if not config.USE_TTS:
        print('SPOKEN;', phrase)
        return
    try:
        phrase = phrase[:config.MAX_CHAR]
        tts = gTTS(text=phrase, lang=config.LANG)
        if not cache:
            tts.save("./data/media/out.mp3")
            play_mp3("./data/meida/out.mp3", "")
        else:
            tts.save(filename)
            print('\n~ Saved to:', filename)

    except HTTPError as e:
        print('Google TTS might not be updated:', e)
    except Exception as e:
        print('Unknown Google TTS issue:', e)


