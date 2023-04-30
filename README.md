# **The Super Legend of Pac-Bros.**


## _Game Design Document_


---


### Copyright and Authors


The game will be provided under the MIT License. The game was created as a project by:


* Joaquin Badillo Granillo


* Pablo Bolio


##
## _Index_


---


1. [Index](#index)
2. [Game Design](#game-design)
    1. [Summary](#summary)
    2. [Gameplay](#gameplay)
    3. [Mindset](#mindset)
3. [Technical](#technical)
    1. [Screens](#screens)
    2. [Controls](#controls)
    3. [Mechanics](#mechanics)
4. [Level Design](#level-design)
    1. [Themes](#themes)
    2. [Game Flow](#game-flow)
5. [Development](#development)
    1. [Abstract Classes](#abstract-classes--components)
    2. [Derived Classes](#derived-classes--component-compositions)
6. [Graphics](#graphics)
    1. [Style Attributes](#style-attributes)
    2. [Graphics Needed](#graphics-needed)
7. [Sounds/Music](#soundsmusic)
    1. [Style Attributes](#style-attributes-1)
    2. [Sounds Needed](#sounds-needed)
    3. [Music Needed](#music-needed)


## _Game Design_


---


### **Summary**


The Super Legend of Pac-Bros. is a mashup of all your favorite classics in a roguelite 2D platformer format, similar to that of Geometry Dash




### **Gameplay**


The game is a 2D top-down that focuses on you avoiding the different enemies throughout the level, these enemies are actually red ghosts form pac-man in a Mario bros. setting. Venture forth as link tries to find Ganon while moving in different settings and don&#39;t forget to pick up rupees along the way!




### **Mindset**


We want to create a game that is extremely challenging, almost to the point of frustration, which is why enemies feel as though they are moving either extremely fast or positioned perfectly to make the window so slight it almost can&#39;t be done. The player feels like a parkour artist that can avoid anything with adequate skill coming from the user, and since players are unable to hurt the ghosts it should feel like you&#39;re extremely weak but even more agile.
## _Technical_


---


### **Controls**


The only key to press is the space bar in order to jump since the player will move on its own


### **Mechanics**


* The player moves on its own.
* The enemies move sideways following a sine function.
* You can collect coins called rupees which changes your score.
* Rupees can have different values (1, 5 &amp; 20).
* If you die, rupees you collected don&#39;t respawn.
* You die if you collide with grass tiles unless you step on them, or collide in any way with lava tiles or fire tiles.


## _Level Design_


---


### **Themes**
* Our theme is deeply inspired by the Super Mario World, world 1
### **Game Flow**


1. Player starts in a plain with lava ponds and travels through it.


## _Development_


---


### **Abstract Classes / Components**


1. IEnemy
2. IScoringObject


### **Derived Classes / Component Compositions**


1. IEnemy
    1. SideEnemies
2. IScoringObject
    1. Rupees
3. GameManager
4. Link
## _Graphics_


---


### **Style Attributes**


Pixel art is the type of art to be used and will have vibrant colors


### **Graphics Needed**


1. Characters
    1. Human-like
        1. Elf (walking)
    2. Other
        1. Patrolling Ghost (walking)
2. Blocks
    1. Dirt
    2. Dirt/Grass
    3. Fire Blocks
    4. Platform Stone Blocks
    5. Lava Blocks
4. Other
    1. Crystals (coins)
## _Sounds/Music_


---


### **Style Attributes**


Flute like music is used (Saria&#39;s Song from Ocarina of time).


Cartoony and exaggerated sound effects are used for jumps, coin collection, and when hurt.


### **Sounds Needed**


1. Effects
    1. Mario&#39;s Jump
    2. Rupee Collection Sound
    3. Link&#39;s Shout
    4. Super Mario Bros.&#39;s Win Sound;
   
### **Music Needed**


1. The soothing melody of Saria&#39;s Song form Ocarina of Time