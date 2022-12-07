extends Button

export var reference_path = ""
export (bool) var start_focused = true

func _ready():
	if(start_focused):
		grab_focus()
		connect("Mouse_Entered", self, "Mouse_Entered")
		connect("pressed", self, "Button_Pressed")

func Mouse_Entered():
	grab_focus()
		
func Button_Pressed():
	if(reference_path !=""):
		get_tree().change_scene(reference_path)
	else:
		get_tree().quit()
