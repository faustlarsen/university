# Eau Claire's Salon: 

#### _A web app that . 26/12/2020_

#### By _**Constantine Yakubovski**_ 

## Description 
_This web app will ..._

### SPECS: ###

1. SPEC: 

**Input**: 

**Output**: 
____________________________________________________________________________________

2. SPEC: 

**Input**: 

**Output**: 
____________________________________________________________________________________

3. SPEC: 

**Input**: 

**Output**: 
____________________________________________________________________________________

## Installation Requirements

- Install [MySQL Workbench](https://dev.mysql.com/downloads/file/?id=484391)
- Install [MySQl] (https://dev.mysql.com/downloads/file/?id=484914)
- Install [.Net Core](https://dotnet.microsoft.com/download/dotnet-core/2.2)
- Install [Visual Studio Code](https://code.visualstudio.com/)
- Install [Git](https://git-scm.com/downloads/)

## Setup
In the Terminal
-  `$ cd ~` - it will navigate to the user's home directory
-  `$ cd desktop`- it will navigate to the desktop
-  `$ git clone` ,then copy/paste https://github.com/faustlarsen/HairSalon , then press 'enter' - it will create the file on the desktop
-  `$ cd HairSalon.Solution` - it will enter the folder
-  `$ code .` - it will launch VSCode ( text editor ) to open the file
-  `$ touch appsettings.json` - create this file in root directory
- Copy and paste in appsettings.json file: 

```
{
  "ConnectionStrings": { "DefaultConnection": "Server=localhost;Port=3306;database=firstName-lastName;uid=root;pwd=YourPassword;"
  }
}
```
- Replace 'YourPassword' with MySQL password that was set during installation of MySQL.
- `$ dotnet restore`

## DATABASE SETUP 
Copy and Paste the following commands in the terminal. (exclude '$' and '>')
-  `$ mysql -uroot -pepicodus ` - start MySQL Server 
-  `$ cd ~` - it will navigate to the user's home directory
-  `$ cd desktop`- it will navigate to the desktop
-  `$ cd HairSalon.Solution` - it will enter the folder
-  `$ dotnet ef database update` - it will generate database
- `> exit ` - to exit MySQL
- `$ dotnet restore ` - it will complie the code
- `$ dotnet run ` - it will launch the app 
- Then in console click on (localhost:5000) to view the app in the browser

## ALTERNATIVE DATABASE SETUP
- `$ mysql -uroot -pepicodus` - start MySQL Server 
- Open MySQL Workbench
- Choose 'Administration'
- Then 'Data Import'
- Choose  'Import Self-Contained File"
- In browsing tool to select the constantine_yakubovski.sql file that is in the project
- Start Import

## Alternatively,
In your command line terminal, type cd Desktop then navigate to project folder using cd Dot.Solution
Then navigate to cd solution and type dotnet ef migrations Initial
Then type dotnet ef database update
You can confirm your the database has been created by going to the Schemas tab in your MySql Workbench and then right click and select Refresh All in the schema window.


## IMPORT DATABASE with MySQL Schema
- Open your SQL management tool, and paste in the following Schema Create Statement in order to reproduce the database and its tables.

```
CREATE DATABASE IF NOT EXISTS firstName_lastName;
USE firstName_lastName;

DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE `__efmigrationshistory` (
`MigrationId` varchar(95) NOT NULL,
`ProductVersion` varchar(32) NOT NULL,
PRIMARY KEY (`MigrationId`)
) 

DROP TABLE IF EXISTS `CoffeeCafe`;
CREATE TABLE `CoffeeCafe` (
`CoffeeCafeId` int NOT NULL AUTO_INCREMENT,
`CoffeeId` int NOT NULL,
`CafeId` int NOT NULL,
PRIMARY KEY (`CoffeeCafeId`),
KEY `FK_CoffeeCafe_Coffees_CoffeeId` (`CoffeeId`),
KEY `FK_CoffeeCafe_Cafes_CafeId` (`CafeId`),
CONSTRAINT `FK_CoffeeCafes_Coffees_CoffeeId` FOREIGN KEY (`CoffeeId`) REFERENCES `Coffees` (`CoffeeId`) ON DELETE CASCADE,
CONSTRAINT `FK_CoffeeCafes_Cafes_CafeId` FOREIGN KEY (`CafeId`) REFERENCES `Cafes` (`CafeId`) ON DELETE CASCADE
) ...

```




## Known Bugs


## Support and contact details

__faustlarsen@gmail.com__

## Technologies Used

-  _C#_

-  _ASP.NET_

-  _MVC_

-  _My SQL_

-  _HTML_

- _Entity_

-  _Written in VS Code_

### License

This software is licensed under the MIT license

Copyright (c) 2020 **_Constantine Yakubovski_**