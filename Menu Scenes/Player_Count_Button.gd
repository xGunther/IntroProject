extends Button

export var reference_path = ""

func _ready():
		connect("Mouse_Entered", self, "Mouse_Enters_Button")
		connect("pressed", self, "Button_Pressed")

func Mouse_Enters_Button():
	grab_focus()
		
func Button_Pressed():
		get_tree().change_scene(reference_path)

