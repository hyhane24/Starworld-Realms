Team: Cucco Attack
Game: Starworld Realms

Members:
Hane Yie
Vedant Shroff
Anirudh Mukherjee
Medha Puranik
Ananya Kansal

==========================================================

Scenes:
MainMenu (Entry Point)
Start 
Tutorial
lvl1
Maze
Lvl3
End (Ending scenario 1: Win) 
GameOver (Ending scenario 2: Lose)  

==========================================================

Introduction:

Baby alien ALES (or Alice in human language) has crash landed on a hostile planet. The area is inhabited by hostile enemies who are trying to get you, they do not appreciate newcomers. ALES has to find the key and get her spaceship back from enemies in order to escape the planet. Your mission is to help her get back home safely! 

Objective:

The objective of the game is to retrieve the key to the spaceship to help ALES get back home. 

How to play:

You control the alien character with the help of your keyboard. The character movement is bound to regular keyboard movement keys, W - forward, A- left, D- right. Tap the mouse on screen to shoot bullets. Use the spacebar to jump.You must navigate through a vast map full of different kinds of enemies. The enemies you might encounter include:
Flamey - Shoots at you with a breath of fire
Frosty - Throws razor sharp ice shards at you
Slimy - Regurgitates poison laden gases which can choke you to death
Robbit - Performs an earth shattering stomp which can knock you off

You have one mode of defense against the unfriendly creatures, Blasters. You can press the space key on your keyboard to shoot your super power abilities. Blasters are powerful projectiles that shoot like lasers. Your enemies don't die however, they are left encumbered for a moment before recovering, which you can see by the stun bar above their heads. Run away quickly before they wake up again!

Once the player manages to get to the end of the pathway, they are teleported to a procedurally generated maze. The player must navigate through this maze, once again laden with enemies. At the center of the maze lies the missing part of your ship which you must retrieve. This maze is different every time, so every playthrough will be a fresh challenge.

Upon retrieving the key, the player must make it back to the ship and encounter much more challenging enemies (they’re huge flying bats) which follows the player around and rains down a hailstorm of fiery rocks at them. The player cannot defend themselves, they can only hope to run to safety. When the player gets back to their ship they are able to jump start their way back home.

Known Problem Areas:
The controls are a little difficult to get used to. We tried to account for this with NPC guidance. Sometimes animations are delayed and the player has already moved past without being able to see the animation of other objects. The enemies firing only make noise sometimes, we had to account for priority of audio, so this bug remains. The camera is slightly delayed from the movement at times. And the fast animation of the character can cause the player to clip through the walls in the maze level (although rarely).

Manifest:

Work breakdown:

Anirudh Mukherjee : 
Level/Environment Design
Enemy Design
Enemy Scripts
Enemy AI
Boss projectile design, calculations and scripting
Enemy spawn in maze
Enemy disable time logic
Game Audio
Sound effects
Terrain Design
Animations
Debugging and integrating levels
Vegetation rotation with player
Tutorial level
Main Menu 

Hane Yie :
Start Scene
Health canvas
Ingame menu 
Terrain design
Respawn mechanic
Vehicle (moving platform “horizontal elevator”) animation
Game win logic
End scene
GameOver scene 
Collectable
Documentation
Visuals for submission 

Vedant Shroff :
Level/Environment design
Procedurally generated maze creation
Maze design and scripts
Enemy spawning and health pickup spawning in maze
Respawn mechanic and game win logic
Timer
Vegetation rotation with player
Scene transitions
Game over conditions
Debugging and integrating levels
Placing enemies and health pickups in the levels
Platform animation to reach portal
Pond that kills player
Tutorial level

Medha Puranik :
Camera control
Player movement and control
Life mechanics
Health pickups
Player animations
Alien prefab
Health canvas
Enemy disabled logic
NPC work
Tutorial level

Ananya Kansal :
NPC creation
NPC dialogues 
Game audio
Player model
Tutorial level
Player animations


Asset breakdown :

Alien model : Ananya, Medha
Animations :
Enemy animations : Anirudh
NPC animations : Ananya
Elevator : Vedant, Hane
Others : Everyone
Floral_Vegetation : Everyone
Fonts : Medha, Anirudh
Low-Poly-World : Everyone
Portal : Vedant
Scenes :
Tutorial : Ananya, Anirudh, Vedant
Lvl1 : Everyone
Maze : Vedant, Anirudh
Level 3 : Everyone 
MainMenu : Anirudh
Start : Hane, Medha
End: Hane 
GameOver: Hane 
SpaceShips : Vedant, Anirudh
Terrain : Vedant, Anirudh
Collectable: Hane 

Scripts
Vedant : Passage, Edge, MazeDirections, Vector2, GameManager, Wall, Maze, Cell, AlienStateScript, Elevator, KeyScript, StaticDataHolder, TimerScoreScript, EnclosingSphereContact, HealthAnim, WorldState

Anirudh : AI, EarthStomp, PoisonGasAttack, ShootIce, ShootPlayer, ShootFire, PoisonGasAttack, ShootIceBarrage, VeggieLookAtPlayer, GameStarter, GameQuitter, BossShoot, M_Fire, M_Ice, M_Earth, M_Poison

Hane: Elevator, PlateButton, EnclosingSphereContact, Spaceship, GameStarter, GameQuitter, PauseMenu

Medha : AlienRootMotionControlScript, EnclosingSphereContact, FiringScript, GroundDetection, AddHealth

Ananya : NPC, EnclosingSphereContact (audio and NPC portions), lvl1Transition 


3D Game Feel Game:
- The whole game environment, characters, and audio has a 3D feel to it.
- There are NPCs placed throughout the game that clearly map out the objective and goals for the game. The NPCs are easy to spot and expand on the story with every new encounter.
-There are numerous Ways for the player to fail at the game. There are both enemies as well as environmental challenges. There is also an overarching timer that encourages the player to move quickly and defeat the game or they lose.
- Failure communicated through game over screens when player death occurs or time runs out
- Success communicated through a win screen when the player returns to their spaceship at the end of the fame
- Start menu implemented as seen in the beginning of the game. A brief overview of the story is also given in order for the player to feel more invested in the game.
- Options to respawn after getting killed or restarting the game through the pause menu implemented in all levels.
- Different objectives for each level
- Level 1: Avoiding or Attacking enemies, collecting a coin, traveling through a portal
- Level 2: Solving a maze while defending against enemies on the way in order to successfully collect the key to the spaceship needed to complete the game.
- Level 3: Skillfully meandering through the terrain while avoiding unattackable enemies to get to the player’s spaceship and escape.

Precursors to fun gameplay:
- Goals and subgoals clearly communicated to the player via story screens, and NPC dialog scattered throughout levels.
- In Levels 1 and 3, Shorter paths have more enemies compared to longer paths through the terrain therefore making them more challenging. This allows for the player to make choices better suiting their preferred method of gameplay and allowing them to strategize on how to complete levels.
-Health pickups might lure players into taking up a longer path and the players will have to think about the trade off between recovering health and losing out on time as observed in level 1 and 3.
- they can also pick up a coin to move an animated platform to cross a river at the end of level 1, which allows for an interactive environment.
- There is a timer that counts down which the player must keep in mind at all times.
- When you die you respawn at the start of the level hence hindering all the progress you've made for a particular level.
- A tutorial level has been introduced in the beginning to give a better understanding of the gameplay mechanics and the characters to the player. As well as allowing for the player to get more comfortable with the controls and not worry about dying or a time constraint.
- The game begins with a relatively open world with enemies scattered throughout and then shifts to a more constrained area in the maze with lesser area to move around and dodge enemies. The final bosses are much harder to dodge and deal with.
- Different fun levels including a maze, crossing a river on a platform, and a level with a dust storm and flying bats.

3D character with real-time control:
- Little baby Alien is the main character. She’s got big ol eyes and ears and tiny little feet. She hops around because his legs are too stubby to walk on, she is only a baby after all.
- She’s also an alien. And aliens are much cooler than humans as we all know. So little baby (not purple yoda) can shoot laser beams out of her eyes (which is totally not just manifestations of the force)
- Controls and camera are smooth and intuitive, camera always follows the player and shows obstacles and has a limited passing through walls, WASD to move around, space to jump. Mouse to fire.
- Fluid animation, character hops when moving around.
- The baby makes a cartoon sound when getting hurt because a realistic sound is too sad. Whenever an enemy projectile comes in contact with the sphere collider for the player, health is decremented and audio is played.

3D world with physics and spatial simulation:
- Created an alien planet with rocky mountains and murky waters which is deadly to our player (and the player will die if they fall into it) as seen in the first level.
- Flora and Fauna that looks at the player when the player moves through the environment giving a significant feel to the presence of the player on the planet. They all know she is a strange creature lost on an even stranger planet.
- Players cannot fall through the map and if they climb up a mountain in level 1 then the game restarts since we have kept a death zone when the player falls below a certain height.
- Collectible coin that activates an animated platform to cross the river at the end of level 1.
- Procedurally generated maze which gives you a new maze with enemies and health prefabs each time you play the game in level 2.
- Dust storm at the final level to make it look more gloomy.
- Bridge on the final level to cross the river with bats flying above water bodies.
- Portals to travel across dimensions in level 1 and 3, level transition on walking through portal, picking up the key in level 2.

NPC and AI
- Animated NPCs guide the player through dialog boxes.
- Numerous enemies scattered throughout the map.
- Enemies in level 1 roam around freely and will attack the player if they get too close.
- Once the player is at a safe distance, the enemies stop attacking the player.
- Enemy AI states, Patrol the area (move around randomly), Follow (Follow the player if they get too close), Attack (Attack the player with their ability).
- Types of enemy:
Fire slime - Shoots fire
Ice slime - Shoots ice shards
Poison slime - Emits poisonous gas, does not patrol
Big rabbit - Stomps on the ground causing a shockwave
Fire cyclops slime - Shoots fire
Ice Turtle - Shoots multiple ice shards at once
Boss bats - Shoots multiple fireballs from the air.
- Enemies do not patrol the maze in level 2 but instead try to trap the player.
- The final bosses in level 3 will shoot multiple fireballs at the player from the air.

Polish:
- Have implemented the start menu GUI, pause menu and the ability to quit the game. Start menu present when the game begins. Pause menu can be accessed via the escape key.
- Environment acknowledges the player's presence, flowers look at the player as they move.
- Background music in the game for different levels.
- Sound effects for enemies shooting the player, player shooting the enemies, getting hit.
