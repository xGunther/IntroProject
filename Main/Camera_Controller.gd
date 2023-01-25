extends Spatial

export(float, 0, 1000) var movement_speed = 10
export (float, 0, 1000, 0.1) var speed_of_movement = 20

func _process(delta: float) -> void:
	_moving(delta)
	#_mouse_moving (delta)

func _moving(delta: float) -> void:
	var velocity = Vector3()
	if Input.is_action_pressed("camera_forward"):
		velocity -= transform.basis.z
	if Input.is_action_pressed("camera_backwards"):
		velocity += transform.basis.z
	if Input.is_action_pressed("camera_left"):
		velocity -= transform.basis.x
	if Input.is_action_pressed("camera_right"):
		velocity += transform.basis.x
		velocity = velocity.normalized()
	translation += velocity * delta * movement_speed
	
func _on_Die_Grid_visibility_changed():
	var Grid = $"/root/Main/Die_Grid"
	var ElevationCam = $"Elevation"
	if Grid.visible: # Camera when the dice are being thrown
		translation = Vector3(14.5, 14, 8.5)
		ElevationCam.rotation_degrees = Vector3(-90, 0, 0)
	else: 
		translation = Vector3(-13.5, 0, 3)
		ElevationCam.rotation_degrees = Vector3(-50, 0, 0)
		
	
	
	

	
	


