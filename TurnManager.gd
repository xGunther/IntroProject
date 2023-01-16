extends Node


var currentTurn : int = 1 
var playerCount : int = 4


func _ready():
	pass

func updateLabel():
	if(currentTurn == 1):	
		$"../UI_Rect_Turn/Players_Turn".text =  $"../UI_Rect_Players_4/Player_Name1".text + "'s Turn" 
	elif(currentTurn == 2):
		$"../UI_Rect_Turn/Players_Turn".text =  $"../UI_Rect_Players_4/Player_Name2".text + "'s Turn" 
	elif(currentTurn == 3):	
		$"../UI_Rect_Turn/Players_Turn".text =  $"../UI_Rect_Players_4/Player_Name3".text + "'s Turn"
	elif(currentTurn == 4):	
		$"../UI_Rect_Turn/Players_Turn".text =  $"../UI_Rect_Players_4/Player_Name4".text + "'s Turn"
		
func endTurn():
	currentTurn += 1
	if (currentTurn > playerCount):
		currentTurn = 1
		
func _on_End_Turn_Button_pressed():
	endTurn()
	updateLabel()


func _on_LineEdit_text_changed(new_text):
	$"../UI_Rect_Turn/Players_Turn".text =  new_text + "'s Turn"
