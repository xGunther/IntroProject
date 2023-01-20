# Ziggurat: A Catan Reskin
**Ziggurat** is a 3D-reskin of the popular board game Catan. 
For the unfamiliar, Catan is a game where players must build and acquire resources in order to gain enough victory points to win. For more info, go to [How to Play](#play).  
We used Godot for this project. Since we wanted the game to be 3D, a game engine was a must. 
The reason we chose Godot over other game engines such as Unity is because Godot is more beginner friendly.
Learning Godot was certainly a challenge. If we were all more familiar with Godot, it would have given us time to include more features such as trading and random boards.

## Installation and Usage
To play the game, simply download the .exe file (Ziggurat.exe) and run it. As for opening the project itself: 

1. Download the entire project.
2. Download the latest **Mono version** of Godot from [here](https://godotengine.org/). 64-bit and 32-bit both work.
3. Open the program. This can differ between operating systems. On Windows, simply run the .exe within the folder. Follow the instructions on the download page if needed.
4. Open the project in the project list. Continue to step 5 if opened.
     - If the project is not in the project list, click Import on the right hand side
     - Locate the IntroProject folder
     - Open the project.godot file within the project folder
5. Enjoy! In order to view different scenes, double click .tscn files in the file explorer in the bottom left. Refer to the [Project Hierarchy](#proj) for a quick overview of the project.

<a name ="play"></a>
## How to Play
*waarschijnlijk het beste om dit uit te leggen wanneer het spel echt speelbaar is*

## Controls

##### Making your turn
Click on the dice in the bottom left to throw two dice. The dice in the bottom left will show what you ended up rolling.  
Use WASD to move around in the game in order to get a better look at the board.  
*hier uitgelegd hoe je dingen bouwt*  
Clicking `Build Cost` shows you the resources needed for each building and how many victory points you get per building.  
After you have finished your turn, click on `End Turn` in the bottom right to end your turn.




<a name ="proj"></a>
## Project Hierarchy
* `All Materials` stores .materials that are used to generate tiles
* `All Roads, Cities and Numbers` contains the scenes for the tile numbers, settlements, and roads
* `All Sprites` stores all the sprites (images) that need to be accessed within the project
* `All_Hexa_Tiles` contains all of the tile scenes
* `Main` contains most of the scenes and scripts that are used in the actual game
* `Menu Scenes` contains all of the scenes and scripts used for menus 

**Extra Information**: .tscn are scene files, .gd are scripts written in GDScript, and .cs are scripts written in C#. They can be opened within Godot.

## Credits
- Niels van den Oever    [GitHub](https://github.com/n1eles)
- Gun Chen          [GitHub](https://github.com/xGunther)
- Jonathan van Dijk      [GitHub](https://github.com/ThannerJonna)
- Floris Dinkelberg       [GitHub](https://github.com/florisyours)
