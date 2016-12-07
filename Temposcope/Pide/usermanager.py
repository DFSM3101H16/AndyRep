import pickle
import shutil
import pidestt
import pidetts
import create_data

from user import User
from os import mkdir, path
#from facerec import takePictures

users = []

def saveUsers(users):
    with open('./data/users/userlist.pkl', 'wb') as file:
        pickle.dump(users, file, -1)

def loadUsers(users):
    try:
        with open('./data/users/userlist.pkl', 'rb') as file:
            temp = pickle.load(file)
            for item in temp:
                users.append(item)
                
    except IOError:
        saveUsers([])

def userReport(users):
    pidetts.speak("These are the current accounts. ")
    for user in users:
        pidetts.speak(user.name)
        print(user.name, user.directory)

def addUser(users):
    print "Name user account: \n"
    pidetts.speak("What do you want your user to be named?")
    while True:
        username = ''
        while username == '':
            username = pidestt.active_listen()
            
        username = username.lower()
        pidetts.speak("Your name is " +username + "? " + " Is this correct?")
        
        userQuery = ''
        while userQuery == '':
            userQuery = pidestt.active_listen()
            
        userQuery = userQuery.lower()
        if "yes" in userQuery or "yeah" in userQuery or "ja" in userQuery:            
            for user in users:
                if user.name == username:
                    return False   
            if path.exists('./data/users/' + username):
                print "USER: " + username + " exists!"
                return False
            if not path.exists('./data/users/' +username):
                mkdir('./data/users/' + username)
            psw = setPsw()
            homeLocation = setHomeLocation()
            userpath = './data/users/' + username + ''
            users.append(User(name=username, password=psw, directory=userpath, home=homeLocation))
            pidetts.speak("Your user account is named " + username + ". I have created a user folder for you at " + userpath + ". Have fun.")
            pidetts.speak("I will now take some pictures of you so I can recognize you next time I see you.")
            pidetts.speak("Please look at the camera. I will tell you when I am done.")
            create_data.takePictures(username)
            pidetts.speak("I have finished taking pictures and will recognize you next time I see you")
            user = users[len(users)-1]
            saveUsers(users)
            return
        elif "no" in userQuery or "nope" in userQuery:
            pidetts.speak("Okay, try to create a new user again.")
            return
        elif "exit" in userQuery:
            return 
        elif "" in userQuery:
            userQuery = pidestt.active_listen()
    return
    

def setPsw():
    pidetts.speak(" You must now create a password")
    pidetts.speak(" You use your password when logging into your useraccount by voice. ")
    pidetts.speak(" Create your password now. ")
    userpsw = ''
    while userpsw == '':
        userpsw = pidestt.active_listen()
    userpsw = userpsw.lower()
    pidetts.speak("Your password is " + userpsw + ". Is this correct?")
    answ = ''
    while answ == '':
        answ = pidestt.active_listen()
        if "yes" in answ:
            return userpsw
        elif "no" in answ:
            answ = ''
        elif "exit" in answ:
            return
        else:
            answ = ''


def setHomeLocation():
    pidetts.speak(" Where do you live? ")
    userhome = ''
    while userhome == '':
        userhome = pidestt.active_listen()
    userhome = userhome.lower()
    pidetts.speak("You live in " + userhome + ". Is this correct?")
    answ = ''
    while answ == '':
        answ = pidestt.active_listen()
        if "yes" in answ:
            return userhome
        elif "no" in answ:
            answ = ''
        elif "exit" in answ:
            return
        else:
            answ = ''

def deleteUser(users):
    userReport(users)
    #delete = raw_input('')
    pidetts.speak("Which user do you want to delete?")
    userQuery = ''
    while userQuery == '':
        userQuery = pidestt.active_listen()
    delete = userQuery.lower()
    if "noone" in delete or "none" in delete or "exit" in delete:
        return
    for user in users:
        if user.name == delete:
            users.remove(user)
            shutil.rmtree('./data/users/' +delete)
            shutil.rmtree('./data/faces/' +delete)
            pidetts.speak("User " +delete + " has been removed.")
            saveUsers(users)
            return
    pidetts.speak("Could not locate user named " + delete + ". No account has been deleted")
    return
            
            
    saveUsers(users)

    
loadUsers(users)


    
