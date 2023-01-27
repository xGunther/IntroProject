extends Button

#If the mouse enters or the a button is pressed it gives a signal that the mouse has entered or a button is pressed, then it goes to the function that is connected to the signal.
func _ready():
	connect("Mouse_Entered", self, "Mouse_Entered")
	connect("pressed", self, "Button_Pressed")

#If the mouse enters the button, the button grabs focus. 
func Mouse_Entered():
	grab_focus()
		
#If the button is pressed it hides the options menu
func Button_Pressed():
	$"../..".hide()
