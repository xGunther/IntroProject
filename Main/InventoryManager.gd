extends Node

var ThrowDiceScript = load("res://Main/Throw_Dice_Button.cs")
var resourceIndex
#an array to keep track of the resource amounts for every player by refering to their number 
var playerInventory = {1: [0, 0, 0, 0, 0], 2: [0, 0, 0, 0, 0], 3: [0, 0, 0, 0, 0], 4: [0, 0, 0, 0, 0]}
var resourceNames = ["Gold", "Sheep", "Stone", "Wood", "Grain"]
#for every placeable there are certain resource requirements and these are put into arrays
var resourcesRequiredRoad = [0, 0, 1, 1, 0]
var resourcesRequiredSettlement = [0, 1, 1, 1, 1]
var resourcesRequiredCity = [2, 0, 0, 0, 3]
var resourcesRequiredDevCard = [1, 1, 0, 0, 1]

func _ready():
	pass 
	
#adds the resources to a players inventory when the dice rolled a number connected to their placeable
func AddResources(playerNumber, resourceName, amount):
	resourceIndex = resourceNames.find(resourceName)
	#checks if there is a city or a settlement 
	playerInventory[playerNumber][resourceIndex] += amount
	
#removes the resources of the player's inventory after placing a building
func removeResources(playerNumber, resourceIndex, amount):
	if 	playerInventory[playerNumber][resourceIndex] > 0:
		playerInventory[playerNumber][resourceIndex] -= amount
		return true
	else:
		return false
		
#checks if the player has enough resources to build a placeable or a DevCard
func checkResourcesForRoad(playerNumber, resourceName):
	for i in range (resourcesRequiredRoad):
		if playerInventory[playerNumber][i] >= resourcesRequiredRoad:
			removeResources(playerNumber, i, resourcesRequiredRoad)
			return true
		else: 
			print("You don't have enough resources to build a settlement")
			return false
			
#checks if the player has enough resources to build a placeable or a DevCard
func checkResourcesForSettlement(playerNumber, resourceName):
	for i in range(resourcesRequiredSettlement):
		if playerInventory[playerNumber][i] >= resourcesRequiredSettlement:
			removeResources(playerNumber, i, resourcesRequiredSettlement)
			return true
		else: 
			print("You don't have enough resources to build a settlement")
			return false
	
#checks if the player has enough resources to build a placeable or a DevCard
func checkResourcesForCity(playerNumber, resourceName):
	for i in range(resourcesRequiredCity):
		if playerInventory[playerNumber][i] >= resourcesRequiredCity:
			removeResources(playerNumber, i, resourcesRequiredCity)
			return true
		else: 
			print("You don't have enough resources to build a settlement")
			return false

#checks if the player has enough resources to build a placeable or a DevCard
func checkResourcesForDevCard(playerNumber, resourceName):
	for i in (resourcesRequiredDevCard):
		if playerInventory [playerNumber][i] >= resourcesRequiredDevCard:
			removeResources(playerNumber, i, resourcesRequiredDevCard)
			return true
		else: 
			print("You don't have enough resources to build a settlement")
			return false
#when the button is clicked, it will check if the player has enough resources if so, the player can build that placeable
func _on_Road_Button_pressed():
	checkResourcesForRoad($"../TurnManager".currentTurn, resourceIndex)
	#build function

#when the button is clicked, it will check if the player has enough resources if so, the player can build that placeable
func _on_Settlement_Button_pressed():
	checkResourcesForSettlement($"../TurnManager".currentTurn, resourceIndex)
	#build function
	
#when the button is clicked, it will check if the player has enough resources if so, the player can build that placeable
func _on_City_Button_pressed():
	checkResourcesForCity($"../TurnManager".currentTurn, resourceIndex)
	#build function
	
#when the button is clicked, it will check if the player has enough resources if so, the player can build that placeable
func _on_DevCard_Button_pressed():
	checkResourcesForDevCard($"../TurnManager".currentTurn, resourceIndex)
	#build function
	
#this function checks every possible die sum and checks the corresponding tiles with that particular number on the board for settlements or cities
