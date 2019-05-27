# P2---Pathfinding
P2 projekt - B2-28

Name: Routeoptimization for Danske Fragtmænd

Version: 1.0

Desciption: This program finds a solution to the Traveling Salesman Problem using a customized algorithm called greedy 2-opt. The algorithm finds a solution with a diviation of 0.0005% from the optimal solution, given the test set DJ_38 containing 38 destinations. The algorithm is hard-coded to only run 12 seconds, but the user is able to change this in the source code.   

Features: The program executes a interactive UI. The userinterface has the options: create new location, delete location, move location and calculate route. The algorithm to calculate the route uses an interface implementation, making it easy to replace. The program is able to read all comma seperated files, with list of locations in EUC-2D. 

System reqiurements: Able to run a .NET Framework. 

Run: go to P2---Pathfinding-GUI-OPTIMIZED\GUI_DFM\GUI_DFM\bin\Debug, and run GUI_DFM.exe 

Files: 
       
       \GUI_DFM - Contains the solution, unittest and packages

       \GUI_DFM\GUI_DFM - Contains folders for classes, and various classes
       
       \GUI_DFM\GUI_DFM\bin\Debug - Contains the .exe file for running the program
       
       \GUI_DFM\GUI_DFM\addresses.txt - Contains text file with locations and points
       
       \GUI_DFM\GUI_DFM\RouteAlgoritmh - Contains the cs files for the main algorithm including the IRouteAlgorithm interface
       


Authors: Adil Cemalovic, Anders Aaen Springborg, Anders Bønnelycke Nørgaard, Christian Blæsbjerg, Daniel Hedegaard Mortensen, Hans Bak Nielsen and Nikolai Ajstrup Justensen

License: This project is under the license of Aalborg University.
            
