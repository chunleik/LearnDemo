import sys
from tkinter import *

Widget = Button(None, text='Click Me', command=sys.exit)
Widget.pack()
Widget.mainloop()