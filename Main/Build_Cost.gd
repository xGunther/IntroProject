extends Button


func _ready():
	connect("Mouse_Entered", self, "Mouse_Entered")
	connect("pressed", self, "Button_Pressed")

func Mouse_Entered():
	grab_focus()
		
func Button_Pressed():
	$"../../Build_Cost_Menu".show()
	$"../../Build_Cost_Menu/Close_Button".show()
	$"../../Build_Cost_Menu/Close_Button/CloseIcon".show()
