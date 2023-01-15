extends Button

export var reference_path = ""

func _ready():
	connect("Mouse_Entered", self, "Mouse_Entered")
	connect("pressed", self, "Button_Pressed")

func Mouse_Entered():
	grab_focus()
		
func Button_Pressed():
	$"../Options_Game".hide()
	self.hide()
