# DangeonSeeker
ConsoleGame

WARNING!!! BAD CODE!!! If you just want watch the code i warned you.

This is opensource console game with RPG elements. This is personal project for education and not for commertion on anything alse.
Developer just studing C# and exploring VS Code. If someone want to help developer he will be very pleasant, but he can't do anything alse in reply but just say "Thank you". Nice to meet you!

# Game specification

This is bad working "game" in where i do experiments with Windows 10 console and programming language C#.
This game can be build in almost every platforms(besides linus and macos i think?).
In this game you will shound explore dungeon and collect items and on the way killing enemies.

# Control

Use "WASD" buttons for character moving. Your character looks "@".
On your way you can meet dotted line. It is a door. Just walk at door to open it.

# Building

Download .NET Core
Clone or download master banch. Put files launch.json and tasks.json in new directory .vscode and put it directory in directory with files Program.cs and ConsoleApplication.csproj. Open terminal in VS Code or new console window. Type: 

```
dotnet build -r win10-x64 /proj dir/
```

It is build game for Windows 10 x64. Go in 

```
/proj dir/bin/Debug/netcoreapp2.2/win10-x64
```

and here you game files. For play open .exe file.
