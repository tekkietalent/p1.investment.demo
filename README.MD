#Introduction

For the purposes of this exercise I have implemented an N-Tier approach for the architecture with a Unit Tests project that has some basic tests for each layer.

I was interested in having a play with Microsofts new [Blazor] (https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) technology (think Angular but for dot net developers) therefore a basic UI has been built using that.

Dependency Injection is used to inject the Business Logic Service into the Web API project Controller layer, and the Repository into the Service Layer, and the HttpClient access into the Repository layer, following Clean Architecture principles with the dependencies only flowing one way.

For simplicity, the domain objects are shared across layers.

#To Run

To run the solution locally, just clone down the repo and use the 'develop' branch.

Load the solution into Visual Studio 2019 and run the solution. 

You will get two browser windows:
	- the API project with a Swagger window where you can execute the api;
	- the UI window which demonstrates a decoupled UI that can be used to query the API above.

#To Do

Refine the query to the service so we don't pull back all of the portfolios each time; alternatively cache them.

Write some more unit tests to improve coverage. Implement Integration Tests / System Tests etc [more complex project]

#For Prodution ready / UAT Cloud [Azure]

-> Secure WebAPI and UI with Microsoft Managed Identity using Azure Active Directory to prevent unauthorised access.

Add App Insights

Inject Logging into each layer [ILogger] so we can log errors / info etc

Look at Containerising the API [Docker] so when we look at pipeline deployment to Azure AKS / Container Registry

Set up Infra - Azure Repository, Aure Devops [Azure Pipelines] to run build and tests

Setup with Azure Boards for task management including agile sprint management for Team
