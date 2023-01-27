extends Node

var CurrentRound : int = 1
var CurrentTurn : int = 1 
var PlayerCount : int = 4


func _ready():
	pass

func UpdateLabel():
	if(CurrentTurn == 1):	
		$"../UI_Rect_Turn/Players_Turn".text =  $"../UI_Rect_Players_4/Player_Name1".text + "'s Turn" 
	elif(CurrentTurn == 2):
		$"../UI_Rect_Turn/Players_Turn".text =  $"../UI_Rect_Players_4/Player_Name2".text + "'s Turn" 
	elif(CurrentTurn == 3):	
		$"../UI_Rect_Turn/Players_Turn".text =  $"../UI_Rect_Players_4/Player_Name3".text + "'s Turn"
	elif(CurrentTurn == 4):	
		$"../UI_Rect_Turn/Players_Turn".text =  $"../UI_Rect_Players_4/Player_Name4".text + "'s Turn"
		
func EndTurn():
	CurrentTurn += 1
	if (CurrentTurn > PlayerCount):
		CurrentTurn = 1
		CurrentRound += 1
		
func _on_End_Turn_Button_pressed():
	EndTurn()
	UpdateLabel()


func _on_LineEdit_text_changed(NewText):
	$"../UI_Rect_Turn/Players_Turn".text =  NewText + "'s Turn"
