extends Panel

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

#Changes the audio volume accordingly to the slider value
func _on_HSlider_value_changed(value):
	AudioServer.set_bus_volume_db(AudioServer.get_bus_index("Master"),value)
