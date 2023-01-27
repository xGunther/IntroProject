extends Control
var reference_path = ""

var GameIsPaused = false setget SetIsPaused

func _unhandled_input(event):
	if event.is_action_pressed("pause"):
		self.GameIsPaused = !GameIsPaused

func SetIsPaused(Value):
	GameIsPaused = Value
	get_tree().paused = GameIsPaused
	visible = GameIsPaused

func _ready():
	pass 

func _on_Exit_Button_pressed():
	get_tree().change_scene(reference_path)


func _on_Resum_Button_pressed():
	self.GameIsPaused = false

