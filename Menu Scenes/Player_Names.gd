extends Panel

func _ready():
	pass


func _on_LineEdit_text_changed(new_text):
	$Player_Name1.text = new_text


func _on_LineEdit2_text_changed(new_text):
	$Player_Name2.text = new_text


func _on_LineEdit3_text_changed(new_text):
	$Player_Name3.text = new_text


func _on_LineEdit4_text_changed(new_text):
	$Player_Name4.text = new_text
