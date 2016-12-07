import threading, time, random

try:
    import Queue
except:
    import queue as Queue

class Vision:
    def __init__(self):
        self.hasUser = 0
 
    def run(self):
        import cv2, sys, numpy, os
        self.user = ''
        haar_file = './data/haarcascade_frontalface_default.xml'
        datasets = './data/faces'
        #create fisherrec
        print('Training...')
        #Create a list of images and a list of corresponding names
        (images, labels, names, id) = ([], [], {}, 0)
        for (subdirs, dirs, files) in os.walk(datasets):
            for subdir in dirs:
                names[id] = subdir
                subjectpath = os.path.join(datasets, subdir)
                for filename in os.listdir(subjectpath):
                    path = subjectpath + '/' + filename
                    label = id
                    images.append(cv2.imread(path, 0))
                    labels.append(int(label))
                id += 1
        (width, height) = (92, 112)

        # Create a numpy array from the two lists above
        (images, labels) = [numpy.array(lis) for lis in [images, labels]]

        #OPenCV trains a model from the images
        model = cv2.createFisherFaceRecognizer()
        model.train(images, labels)

        #Part 2: use fisherRec on camera stream
        face_cascade = cv2.CascadeClassifier(haar_file)
        webcam = cv2.VideoCapture(0)
        global q
        global ackv
        while True:
            if (q.empty()):
                username = ''
                (_, im) = webcam.read()
                gray = cv2.cvtColor(im, cv2.COLOR_BGR2GRAY)
                faces = face_cascade.detectMultiScale(gray, 1.3, 5)
                for (x,y,w,h) in faces:
                    cv2.rectangle(im,(x,y),(x+w,y+h),(255,0,0),2)
                    face = gray[y:y + h, x:x + w]
                    face_resize = cv2.resize(face, (width, height))
                    #Try recognize
                    prediction = model.predict(face_resize)
                    cv2.rectangle(im, (x, y), (x + w, y + h), (0, 255, 0), 3)

                    if prediction[1]<500:
                        cv2.putText(im, '%s - %.0f' % (names[prediction[0]],prediction[1]),(x-10,y-10), cv2.FONT_HERSHEY_PLAIN,1,(0, 255, 0))
                        username = names[prediction[0]]
                        q.put(username)
                        print ("VISION ADDING " + username)
                        #webcam.release
                        return False

                    else:
                        cv2.putText(im, 'not recognized',(x-10, y-10), cv2.FONT_HERSHEY_PLAIN,1,(0, 255, 0))
                        
                cv2.imshow('OpenCV', im)
                key = cv2.waitKey(10)
                if key == 27:
                    #webcam.release
                    return False
                
            if (not q.empty()):
                #webcam.release
                return False
            
            if (not ackv.empty()):
                print ("VISION GOT ACK!")
                finishVision = ackv.get()
                self.hasUser = 1
                if(self.hasUser == 1):
                    ackv.empty()
                    self.hasUser = 0
                webcam.release
                return False
                
            
        print ("Finished VISION")

class Brain:
    def __init__(self):
        #import pide
        self.hasUser = 0
        self.username = ''
    def run(self):
        import pide
        import config
        import pidestt
        import pidetts
        global q
        global ackv

        while True:
            if (self.hasUser == 0 and q.empty()):
                wakeup = ''
                wakeup = pidestt.passive_listen()
                if "wake up" in wakeup:
                    hasUser = 1
                    ackv.put(1)
                    vt.join()
                    pide.LoginUser(wakeup)
                    hasUser = 0
                    return False
                    
            elif (self.hasUser == 0 and not q.empty()):
                username = q.get()
                print ("removing " + username)
                self.hasUser = 1
            elif (self.hasUser == 1 and q.empty()):
                print ("Self has a user!")
                print ("USER IS NOW: " +username)
                ackv.put(1)
                vt.join()                
                pide.LoginUser(username)
                self.hasUser = 0
                return False
            


if __name__ == '__main__':
    global startup
    startup = 1

    while startup == 1:        
        q = Queue.Queue(1)
        ackv = Queue.Queue(1)

        
        v = Vision()
        b = Brain()
        
        vt = threading.Thread(target=v.run, args=())
        bt = threading.Thread(target=b.run, args=())

        vt.start()
        bt.start()
    
        vt.join()
        print ("vt has joined" + str(vt.join))
        bt.join()
        startup = 0
            
        if startup == 0:
            vt.join()
            bt.join()
            startup = 1
        
