extends Spatial

func _ready():
	pass


func _on_LineEdit_text_changed(new_text):
	$UI_Rect_Players_4/Player_Name1.text = new_text


func _on_LineEdit2_text_changed(new_text):
	$UI_Rect_Players_4/Player_Name2.text = new_text


func _on_LineEdit3_text_changed(new_text):
	$UI_Rect_Players_4/Player_Name3.text = new_text


func _on_LineEdit4_text_changed(new_text):
	$UI_Rect_Players_4/Player_Name4.text = new_text
