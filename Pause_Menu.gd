extends Control
var reference_path = ""

var Game_is_paused = false setget set_is_paused

func _unhandled_input(event):
	if event.is_action_pressed("pause"):
		self.Game_is_paused = !Game_is_paused

func set_is_paused(value):
	Game_is_paused = value
	get_tree().paused = Game_is_paused
	visible = Game_is_paused

func _ready():
	pass 

func _on_Exit_Button_pressed():
	get_tree().change_scene(reference_path)


func _on_Resum_Button_pressed():
	self.Game_is_paused = false

