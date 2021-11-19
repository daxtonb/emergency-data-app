# Emergency Data App

## Instructions

**NOTE: .NET Core version 5.0 or greater must be installed on your machine**

**NOTE: This application was built and tested on Ubuntu 21.10 only**

### **Step 1: Running the program**
There are two methods for running this program.

Method 1:
* From your operating system's terminal, navigate to this project's root directory run the following command:
```
dotnet run --project EmergencyDataApp.Server/EmergencyDataApp.Server.csproj
```
Method 2:
* From your operating system's terminal, navigate to this project's root directory and run the following command:
```
dotnet publish EmergencyDataApp.Server/EmergencyDataApp.Server.csproj --output bin
```
* Navigate to the `bin/` directory and run the `EmergencyDataApp.Server` executable.

### **Step 2: Enter RapidAPI key**
The console will prompt you for the Rapid API key. This is to get access to weather data from the Meteostat API. This was not included in the source code for security reasons.

### **Step 3: Get data**
From a web browser, visit [http://localhost:5000/api/EnhancedEmergency/2017-05-15/2017-05-15](http://localhost:5000/api/EnhancedEmergency/2017-05-15/2017-05-15). Change the `from` and `to` date parameters to query different date ranges.

## Testing with new sample data
- If running using Method 1, copy JSON data files into the `EmergencyDataApp.Data/SampleData` directory. 

- If running using Method 2, copy JSON data files into the `bin/SampleData` directory.
## Unit Testing:
* From your operating system's terminal, navigate to this project's root directory and run the following command:
```
dotnet test
```

## Other deliverables
- Had I had more time, I would have implemented a logging system and implemented a database management system of sorts. In addition to logging, I would also implement better error handling with Try/Catch blocks. I would have also included more sophisticated testing that tested for more than just the requriements of the application.
- I spent approximately 8 hours on this project.