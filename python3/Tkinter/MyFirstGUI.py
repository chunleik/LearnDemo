import tkinter
from tkinter import *

# Widget = Label(None, text='This is my first Gui!!')
# Widget.pack()
# Widget.mainloop()

# Label(text='My first GUI!').pack(expand=YES, fill=BOTH)
# mainloop()

root = Tk()

widget = Label(root)
widget.config(text='My first GUI!')
widget.pack(side=TOP, expand=YES, fill=BOTH)
root.mainloop()