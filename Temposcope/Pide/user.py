class User(object):
    def __init__(self, name=None, password=None,directory=None, home=None):
        self.name = name
        self.password = password
        self.directory = directory
        self.home = home

    def logOut(self, name=None, password=None, directory=None):
        self.name = name
        self.password = password
        self.directory = directory





