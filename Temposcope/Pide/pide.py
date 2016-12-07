import pidetts
import pidestt
import os
import usermanager
import config
import create_data
import pideweather
from time import gmtime, strftime

from user import User


currentUser = User()

def Init():
    pidestt.init()
                         
            
def LoginVoice():
    pidetts.speak(" Who are you? ")
    while True:
        username = ''
        while username == '':
            username = pidestt.active_listen()
            
        username = username.lower()
        if "exit" in username:
            return False
        
        pidetts.speak(" Your name is " +username + "? " + " Is this correct? ")
        
        userQuery = ''
        while userQuery == '':
            userQuery = pidestt.active_listen()
            
        userQuery = userQuery.lower()
        if "exit" in userQuery:
            pidetts.speak(" Exit login module ")
            return
        if "no" in userQuery or "lowe's" in userQuery or "low" in userQuery:
            pidetts.speak("Okay, one more time, who are you?")
        if "yes" in userQuery or "yeah" in userQuery or "ja" in userQuery:            
            for user in usermanager.users:
                if user.name == username:
                    ConfirmPassword(username)
                    global currentUser
                    currentUser = user
                    return False
            pidetts.speak("I don't know you")
            pidetts.speak("Do you want to create a new user?")
            answ = ''
            while answ == '':
                answ = pidestt.active_listen()
                if "yes" in answ or "yeah" in answ or "ja" in answ:
                    CreateUser()
                    GetUserRequest()
                elif "no" in answ or "Lowe's" in answ or "low" in answ or "nei" in answ or "nope" in answ or "njet" in answ:
                    pidetts.speak("Ok... Bye!")
                    return False
                elif "exit" in answ:
                    return
                
def ConfirmPassword(username):
    pidetts.speak(" What is your password? ")
    psw = ''
    while psw == '':
        psw = pidestt.active_listen()
    psw = psw.lower()
    pidetts.speak(" Checking users password ")
    for user in usermanager.users:
        if username == user.name and psw == user.password:
            LoginUser(username)
            return
    pidetts.speak(" Password did not match users password! ")
    return


def LoginUser(username):
    #usermanager.loadUsers(usermanager.users)
    os.system("omxplayer -o local ./data/media/beep.mp3")

    for user in usermanager.users:
        if username == user.name:
            print "found " + user.name
            global currentUser
            currentUser = user
    if "admin" in username:
        currentUser.name = 'admin'
    if "wake up" in username:
        LoginVoice()
        return False
    GreetUser()
    GetUserRequest()
    

def CreateUser():
    print "GENERATING USER..."
    usermanager.addUser(usermanager.users)

def PlaySong():
    pidetts.speak(" You asked for it! ")
    os.system("omxplayer -o local ./data/media/ymca.mp3")
    return
    
def Repeater(userQuery):
    pidetts.speak(" You said " + userQuery + "! ")
    

def GreetUser():
    pidetts.speak(" Hello "  + currentUser.name + "! ")

def WeatherModule():    
    pidetts.speak(" Where do you want to know the weather conditions for? ")
    location = ''
    while location == '':            
        location = pidestt.active_listen()
        location = location.lower()
        if "exit" in location or "nowhere" in location:
            pidetts.speak(" Exiting weather module. ")
            return
        elif "home" in location or "local" in location or "current" in location:
            for user in usermanager.users:
                if currentUser.name == user.name:
                    location = user.home
                    GetWeatherAtTime(location)
        else:
            Repeater(location)
            pidetts.speak(" Is that correct? ")
            answ = ''
            while answ == '':
                answ = pidestt.active_listen()
            if "yes" in answ:
                GetWeatherAtTime(location)
                return
            else:
                pidetts.speak(" Okay! I will try again. ")
                location = ''

def GetWeatherAtTime(location):
    pidetts.speak(" Today or at a number of days from now? ")
    atDay = ''
    while atDay == '':
        atDay = pidestt.active_listen()
        atDay = atDay.lower()
        if "exit" in atDay:
            return
        elif "now" in atDay or "today" in atDay or "present" in atDay:
            pidetts.speak("Getting weather for " + location + " now.")
            result = pideweather.weatherAtNow(location)
            pidetts.speak(result)
            return
        elif "tomorrow" in atDay or "1" in atDay or "one" in atDay:
            pidetts.speak(" Getting weather for tommorow at " + location +" now.")
            pideweather.weatherAtDay(location, 2)            
            return
        
        elif "2" in atDay or "two" in atDay:
            pideweather.weatherAtDay(location, 3)
            return
        elif "3" in atDay or "three" in atDay:
            pideweather.weatherAtDay(location, 4)
            return

        elif "4" in atDay or "four" in atDay:
            pideweather.weatherAtDay(location, 5)
            return
        
        elif "5" in atDay or "five" in atDay:
            pideweather.weatherAtDay(location, 6)
            return
            
        elif "help" in atDay:
            pidetts.speak(" Try today, tomorrow or a number up to five. ")
        else:
            pidetts.speak(" I am waiting ")
            atDay = ''
        
        

def GetUserRequest():
    pidetts.speak(" What can I do for you today? ")
    global currentUser
    while currentUser.name is not None:
        userQuery = pidestt.active_listen()
        userQuery = userQuery.lower()
        if "user" in userQuery or "who am i" in userQuery or "username" in userQuery:
            Repeater(userQuery)
            pidetts.speak(" You are currently logged in as " + currentUser.name + "! ")
        elif "weather" in userQuery or "show me the weather" in userQuery or "how is the weather" in userQuery:
            WeatherModule()
        elif "shutdown" in userQuery:
            print "Shutting down client..."
            pidetts.speak(" Shutting down client... ")
            os.system("sudo shutdown now &")
        elif "logout" in userQuery or "log out" in userQuery or "logoff" in userQuery or "log off" in userQuery or "change user" in userQuery or "exit" in userQuery or "quit" in userQuery:
            print "Logging out user: " + currentUser.name
            pidetts.speak(" Logging out " + currentUser.name + "! ")
            del currentUser
            username = ''
            return
        elif "pictures" in userQuery:
            create_data.takePictures(currentUser.name)
        elif "report" in userQuery:
            usermanager.userReport(usermanager.users)
        elif "delete" in userQuery:
            usermanager.deleteUser(usermanager.users)
        elif "play" in userQuery or "song" in userQuery:
            PlaySong()
        elif "time" in userQuery or "clock" in userQuery:
            pidetts.speak(" The clock is " + strftime("%H:%M:%S", gmtime()))
        elif "date" in userQuery or "day" in userQuery:
            pidetts.speak(" Today is " + strftime("%d-%m-%Y"))
        elif "help" in userQuery:
            pidetts.speak(" Hello, " + currentUser.name + ". I am Piedee. Simply ask me about the weather and I will tell and show you the weather from around the world. ")
            pidetts.speak(" If you wonder if you are logged inn with the right profile, ask who am i? and I will tell you which user you are logged inn as. ")
            pidetts.speak(" If you want to end the current session simply say: exit. If you want to shut me down. Say shutdown. ")
        else:
            print "WAITING"
    #currentUser.logOut()

                
    while currentUser.name is None:
        pidetts.speak(" Please log into an account! ")
        return
        
Init()
#LoginUser('admin')
