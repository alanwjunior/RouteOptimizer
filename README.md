# Route Optimizer
This project consist in an implementation of Dijkstra alghorithm to calculate the best route in a graph. There are two interfaces to run the alghoritm: Console and Web API. The project was developed in .Net Core 3.1 and use CsvHelper to handle CSV read/write.

## REST API (Web API)

The Solution has 5 projects and you can find the details below.

| Project | Description |
| ------ | ------ |
| TravelRouteOptimizer.API | This is the Web API (REST) project. Here are implemented the controllers logics to allow HTTP/HTTPS request. None authentication is  required to run the endpoints |
| TravelRouteOptimizer.Utils | This project was developed thinking in provide some common features to the solution, as the CSV module |
| TravelRouteOptimizer.Console | This project is responsile for the Console Interface |
| TravelRouteOptimizer.Tests | In this project you can find the Solution Unit Testings |
| TravelRouteOptimizer | This project contains all logics and algorithms necessaries to calculate the best route given a list of routes. Each algorithm has its own implementation, allowing in the future to use the Facede pattern to provide more than one algorithm optimizer solution  |

## Build and Run Project Solution
- Prerequisites: .Net Core SDK v.3.1

To build the solution, enter in TravelRouteOptimizer.API path and run the command below:
```sh
$ cd TravelRouteOptimizer.API
$ dotnet build
```

To run the Web API project use the commands below:
```sh
$ cd TravelRouteOptimizer.API
$ dotnet run
```

To run the Console Interface use the commands below:
```sh
$ cd TravelRouteOptimizer.API
$ dotnet run
```

To tun the Unit Testings use the comannds below:
```sh
$ cd TravelRouteOptimizerTests
$ dotnet test
```
Swagger is available on http://localhost:<PORT>/swagger.


