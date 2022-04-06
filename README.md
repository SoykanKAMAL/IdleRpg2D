# IdleRpg2d
<h3>Made by Soykan Göksel Kamal</h3>


<h1>Gameplay Video</h1>


https://user-images.githubusercontent.com/58806238/161935531-abf6ee08-6164-4eca-bcee-7468de6700a2.mp4



<h1>Brief Information</h1>
-This is a 2D idle rpg game demo<br>
-Created in Unity 2020.3.30(LTS), designed for mobile platform target resolution = 720x1280<br>
-Main Features: Endless stage based battles, endless upgrades, endless difficulty increase based on stage, Inventory system, Merge system, Rpg stats system, Equipment system, Parallax background<br>


<h1>Design Choices</h1>

-Observer pattern: <br>
* Visual and functional code bodies are seperated. Functional code bodies work with or without the visual scripts and they are not aware if they exist or not. Visual and functional bodies comminucate only through events.<br>
* Code is easily extendible with the usage of events.<br><br>

-Singleton: <br>
* Managers implement singleton design pattern. Their static instances are reachable when needed.<br><br>

-State: <br>
* Main gameplay loop is handled by state pattern. Each state has unique code bodies executed within them.

<br><br> *All assets used are Free and their authors are credited in project folders.
