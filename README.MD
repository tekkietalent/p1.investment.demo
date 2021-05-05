#Introduction

For the purposes of this exercise I have implemented a simple N-Tier approach for the architecture.

I was interested in having a play with Microsofts new [Blazor] (https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) technology (think Angular but for dot net developers) therefore the UI has been built using that.

Dependency Injection is used to inject the Service into the Blazor App, and the Repo into the service. The domain object are simply shared across layers.

I also put the logic underneath a Web API which can be run independently of the UI (see swagger link). 

#To Run

To run the solution locally, just clone down the repo and use the Develop branch.

Load the solution into Visual Studio 2019 and run the P1.Interview.UI project.

I've also published the website [here]()

Swagger link [here]()