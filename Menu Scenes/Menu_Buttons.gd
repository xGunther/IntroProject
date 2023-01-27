extends Button

export var reference_path = ""

#If the mouse enters or the a button is pressed it gives a signal that the mouse has entered or a button is pressed, then it goes to the function that is connected to the signal.
func _ready():
	connect("Mouse_Entered", self, "Mouse_Entered")
	connect("pressed", self, "Button_Pressed")

#If the mouse enters the button, the button grabs focus. 
func Mouse_Entered():
	grab_focus()
		
		
#If the button is pressed it changes the scene if the reference path of the button is not empty. If the reference path is empty it exits the program.
func Button_Pressed():
	if(reference_path !=""):
		get_tree().change_scene(reference_path)
	else:
		get_tree().quit() 
