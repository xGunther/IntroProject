extends Button

export var reference_path = ""

func Button_Pressed():
	if(reference_path !=""):
		get_tree().change_scene(reference_path)
	else:
		get_tree().quit()
