# DynoScout23-PUBLIC
250DynoScout v2023
Credit to Team 842 Falcon Robotics for the original scouting system.
https://www.chiefdelphi.com/t/falcon-scouting-system-release/126808

## Software
Coded and run inside Microsoft Visual Studio

Database using SQLite and SQL Server Management Studio

Match Preview Report and data visualization using Excel

## Summary of 250's Software Development and Strategy Team
Our task is to break down the game each year and provide our team with how we think the game will be played and how we should design a robot to accomplish that goal. Once we have that strategy made it is then time to start to develop the scouting system. We start by thinking of all the different parts of the game and picking the important parts to scout and then figure out how that data will be recorded, saved, and displayed. Once this is done the process of coding the UI, followed by controllers, and lastly the database will take place. The other parts are making the match preview report and training the scouters. When making any part of the scouting system it is important who the end user will be. For team 250 the developers are the first ones to learn how to scout so having them make the controls helps ensure that the controls feel natural the those who will be using the system. The same thing is true with the match preview report, in team 250 the drive team is the ones using it at competition so was important to make sure the data being displayed was laid out in a way that made sense to them, not the ones making it. 
## Setup
To use the software, you need at least one Xbox Controller plugged into the laptop running the software, max of 6 controllers. Need SQL server installed onto the laptop for the code to connect to and Excel getting the data from the database.

To get the data from The Blue Alliance you will need to create a Read Me API Key from https://www.thebluealliance.com/account. After that, to replace all locations Ctrl + F and look for *YOUR_API_KEY_HERE* in the entire solution.
![Visual Studio Search](https://i.imgur.com/6yGt4FD.png)

## Usage
![Interface](https://i.imgur.com/jguW83j.png)
When the code starts up, the interface will be prompted.
The user will need to load the events through the **Load** button at the top. This connects to The Blue Alliance API. After the code gets the events, the user will need to find the name of the event in the list of events, sorted by event code.

After the event is selected, the user will need to press **Get Matches** to load the matches into the software. It will then ask if the red alliance is on your right[^1]. Then it will ask if you want to start from match 1. After you select your option, the interface will automatically select the teams for each scouter.

At the end of the match, when every scouter is ready to go to the next match. The user will check the box for end match at the top and click the right arrow. This will send the data for EndMatch to the database.

Incase of code exiting during an event, just re-open the code, load the event and matches, then just click the right arrow without checking the End Match box until you get to the next match.

## Controls
![Auto Mode Controls](https://i.imgur.com/7YQ1EGx.png)
![Teleop Mode Controls](https://i.imgur.com/zzm1qLV.png)
![Endgame Mode Controls](https://i.imgur.com/ZHcOxwh.png)

## Current Issues
1. The Update Database button on the interface is hard coded to our laptop and will not work for anyone elses.
1. If you have less than 6 scouters, they cannot select which box they are in inside the interface.

[^1]: This was left over from a previous year incase we needed it in the future, it does not matter if you select yes or no.
