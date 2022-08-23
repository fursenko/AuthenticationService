# Cadet.Service

To generate the solution file and run the service pease do the following steps:
    0. Install VS2019 with following components:
		- WPF 
		- ASP.NET
		- VC++ desktop
   
    1. Install script tool
        ```
        dotnet tool install --global dotnet-script
        ```      
    3. Add ea nuget source
        ```
        dotnet nuget add source https://artifactory.ea.com/artifactory/api/nuget/v3/gdw-nuget-virtual --name GDW
        ```
    
    4. Check read access to frostbite resource at http://uap.ea.com/
   
    5. Run the command
        ```
        dotnet script cadet.service\.crucible\gensln.csx
        ```


## Web Interface 

The documentation website is built using docusaurus.io and can be run locally by doing the following.

* `cd ./website/cadet`
* `npm install`
* `npm run-script start` 
