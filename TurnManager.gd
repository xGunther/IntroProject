extends Node
var CurrentTurn = 1
var TurnCount = 0

func _ready():
	pass
	
#Updates the label to the current player and it will display their name on the top of the screen
func updateLabel():
	if($"../DiceValueManager".currentTurn == 1):	
		$"../UI_Rect_Turn/Players_Turn".text =  $"../UI_Rect_Players_4/Player_Name1".text + "'s Turn" 
	elif($"../DiceValueManager".currentTurn == 2):
		$"../UI_Rect_Turn/Players_Turn".text =  $"../UI_Rect_Players_4/Player_Name2".text + "'s Turn" 
	elif($"../DiceValueManager".currentTurn == 3):	
		$"../UI_Rect_Turn/Players_Turn".text =  $"../UI_Rect_Players_4/Player_Name3".text + "'s Turn"
	elif($"../DiceValueManager".currentTurn == 4):	
		$"../UI_Rect_Turn/Players_Turn".text =  $"../UI_Rect_Players_4/Player_Name4".text + "'s Turn"
	CurrentTurn = $"../DiceValueManager".currentTurn
	TurnCount = $"../DiceValueManager".TurnCount
		
#If the End Turn button is pressed it will go through the EndTurn function and it will update the turn label with the function aboven
func _on_End_Turn_Button_pressed():
	$"../DiceValueManager".EndTurn()
	updateLabel()

#Sets the first player's name to the current turn in the turn label
func _on_LineEdit_text_changed(new_text):
	$"../UI_Rect_Turn/Players_Turn".text =  new_text + "'s Turn"
