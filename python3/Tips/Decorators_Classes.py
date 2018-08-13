
class logit(object):
    def __init__(self, logfile='out.log'):
        self.logfile = logfile
    
    def __call__(self, func):
        log_string = func.__name__ + " was called"
        print(log_string)
        #Open the logfile and append
        with open(self.logfile, 'a') as opened_file:
            # Now we log to the specified logfile
            opened_file.write(log_string + '\n')
        #Now, send a notification
        self.notify()
    
    def notify(self):
        # logit only logs, no more
        pass


@logit()
def myfunc1():
    pass


myfunc1
