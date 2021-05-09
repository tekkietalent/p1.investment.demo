#Introduction

For the purposes of this exercise I have implemented an N-Tier approach for the architecture with a separate Unit Tests project that has some basic tests for each layer.

I was interested in having a play with Microsofts new [Blazor] (https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) technology (think Angular but for dot net developers) therefore a very basic UI has been built using that.

Dependency Injection is used to inject the Business Logic Service into the Web API project Controller layer, and the Repository into the Service Layer, and the HttpClient access into the Repository layer, following Clean Architecture principles with the dependencies only flowing one way.

For simplicity, the domain objects are simply shared across layers.

#To Run

To run the solution locally, just clone down the repo and use the Develop branch.

Load the solution into Visual Studio 2019 and run the solution. You will get the APi project launch and a Swagger explorer window open where you can directly call the api, and the UI window which demonstrates a decoupled UI that can also be used to query the UI.

#To Do

Refine the query to the service so we don't pull back all of the portfolios each time, or cache them.

Write some more unit tests to improve coverage.