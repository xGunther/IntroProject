extends Node

var ThrowDiceScript = load("res://Main/Throw_Dice_Button.cs")
var ResourceIndex
#an array to keep track of the resource Amounts for every player by refering to their number 
var PlayerInventory = {1: [0, 0, 0, 0, 0], 2: [0, 0, 0, 0, 0], 3: [0, 0, 0, 0, 0], 4: [0, 0, 0, 0, 0]}
var ResourceNames = ["Gold", "Sheep", "Stone", "Wood", "Grain"]
#for every placeable there are certain resource requirements and these are put into arrays
var ResourcesRequiredRoad = [0, 0, 1, 1, 0]
var ResourcesRequiredSettlement = [0, 1, 1, 1, 1]
var ResourcesRequiredCity = [3, 0, 0, 0, 2]
var ResourcesRequiredDevCard = [1, 1, 0, 0, 1]

func UpdateLabels():
	var ResourceLabels = [$"../UI_Rect_Resources/Panel_Gold/Gold_Count", $"../UI_Rect_Resources/Panel_Sheep/Sheep_Count", $"../UI_Rect_Resources/Panel_Stone/Stone_Count", $"../UI_Rect_Resources/Panel_Wood/Wood_Count", $"../UI_Rect_Resources/Panel_Grain/Grain_Count"]
	for Index in range(0, 5, 1):
		ResourceLabels[Index].text = str(PlayerInventory[$"../DiceValueManager".CurrentTurn][Index])


func _ready():
	pass 
	
#adds the resources to a players inventory when the dice rolled a number connected to their placeable
func AddResources(PlayerNumber, resourceName, Amount):
	ResourceIndex = ResourceNames.find(resourceName)
	#checks if there is a city or a settlement 
	PlayerInventory[PlayerNumber][ResourceIndex] += Amount
	
#removes the resources of the player's inventory after placing a building
func RemoveResources(PlayerNumber, PlaceableType):
	var Resources
	if PlaceableType == "settlement":
		Resources = ResourcesRequiredSettlement
	elif PlaceableType == "road":
		Resources = ResourcesRequiredRoad
	else:
		Resources = ResourcesRequiredCity
	
	
	for i in range(0, 5, 1):
		PlayerInventory[PlayerNumber][i] -= Resources[i]
	UpdateLabels()
		
#checks if the player has enough resources to build a placeable or a DevCard
func CheckResourcesForRoad(PlayerNumber):
	var EnoughResources = true
	for i in range(0, 5, 1):
		if !(PlayerInventory[PlayerNumber][i] >= ResourcesRequiredRoad[i] || $"../DiceValueManager".TurnCount <= 2):
			print("You don't have enough resources to build a settlement")
			EnoughResources = false
	return EnoughResources
#checks if the player has enough resources to build a placeable or a DevCard
func CheckResourcesForSettlement(PlayerNumber):
	var EnoughResources = true
	for i in range(0, 5, 1):
		if !(PlayerInventory[PlayerNumber][i] >= ResourcesRequiredSettlement[i] || $"../DiceValueManager".TurnCount <= 2):
			print("You don't have enough resources to build a settlement")
			EnoughResources = false
	return EnoughResources
#checks if the player has enough resources to build a placeable or a DevCard
func CheckResourcesForCity(PlayerNumber):
	var EnoughResources = true
	for i in range(0, 5, 1):
		if !(PlayerInventory[PlayerNumber][i] >= ResourcesRequiredCity[i]):
			print("You don't have enough resources to build a settlement")
			EnoughResources = false
	return EnoughResources

#when the button is clicked, it will check if the player has enough resources if so, the player can build that placeable
func _on_Road_Button_pressed():
	CheckResourcesForRoad($"../TurnManager".currentTurn)
	#build function

#when the button is clicked, it will check if the player has enough resources if so, the player can build that placeable
func _on_Settlement_Button_pressed():
	CheckResourcesForSettlement($"../TurnManager".currentTurn)
	#build function
	
#when the button is clicked, it will check if the player has enough resources if so, the player can build that placeable
func _on_City_Button_pressed():
	CheckResourcesForCity($"../TurnManager".currentTurn)
	#build function
	
