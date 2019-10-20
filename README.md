# DungeonSeeker
ConsoleGame

WARNING!!! BAD CODE!!! If you just want watch the code i warned you. All new and unstable updates will be in unstable branch.

This is opensource console game with RPG elements. This is personal project for education and not for commertion on anything alse. Developer just studing C# and exploring VS Code. If someone want to help developer he will be very pleasant, but he can't do anything alse in reply but just say "Thank you". Nice to meet you!

# Game specification
This is bad working "game" in where i do experiments with Windows 10 console and programming language C#. This game can be build in almost every platforms(besides linus and macos i think?). In this game you will shound explore dungeon and collect items and on the way killing enemies.

# Control
Game control is case-sensitive! Use "wasd" buttons for character moving. Press "esc" for quit from game, "c" for open command line. Your character looks "@". On your way you can meet dotted line. It is a door. Just walk at door to open it.

# Console commands
**Print text**
```
print <text> or &<text>
```
Writes in output line, text after command. If you want get value of some one field, type "&" before field name.
Field's value which you can get:
```
dungeonH - dungH
dungeonW - dungW
```
**Teleportation**
```
tp <x> <y>
```
Teleports player to x y coordinates. If in that coordinate player can't be stay, it do nothing.


# Building
Download .NET Core Clone or download master banch. Open terminal in VS Code or new console window. Type:
```
dotnet build -r win10-x64 /proj dir/
```
It is build game for Windows 10 x64. Go in
```
/your dir/bin/Debug/netcoreapp2.2/win10-x64
```
and here you game files. For play open .exe file.
