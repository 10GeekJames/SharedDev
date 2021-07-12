Misc Videos as we go

https://www.youtube.com/watch?v=xR9SX1Xp--E
Chapter Two - The Journey of a one tiny-robot that only wants to help the world add numbers together.  
Join as we go from knowing nothing, to watching the story un-fold, to participating, to getting-it and perhaps entering the professional industry as a highly favored, and enjoyed, software development team-member.


```
Concerns we are covering
Net5 Calcualtor Service Library 
Net5 Calcualtor Service Provider Standard Library 
Net5 Calcualtor Service Provider Goofy Library 
Net5 Console App with IOC DI and late bound discovery of calculator service provider, +Identity
Net5 WebAPI using WebApi2, IOC DI, +Identity
Net5 Angular 11 App with Security using Material + SCSS, +Identity
Net5 Blazor WASM App with Security and lazy loaded/secure module/component/service/language/imagry/scss architecture, +Identity
Net5 Discord Bot App, +Identity
Net5 SignalR Core PubSub Server for realtime socket io, +Identity
Net5 Identity Server4 to extend corporate, social, and email-pwd authentication to perform the +Identity for all of the above

Net5
EF Core 5
EF Migrations
Multi-project architecture
DI (Dependency Injection) and IOC (Inversion of Control)
Late dependency discovery using StructureMap
T4 Code Automation using T4 Templates
TDD xUnit Theories with inline-data
BDD Gherkin SpecFlow with Feature Files, SpecFiles, and PageFiles (Page Object Models) where appropraite
Fluent Assertions
Localization using RESX embeded language files with help from Langwish https://github.com/10GeekJames/rdy1b/tree/main/src/Utilities/Langwish
Docker
Dockerfile
Docker-Compose
Dockercompose File
Jenkins
Windows/Mac/Linux Deployment
```


```
VS Code
https://code.visualstudio.com/download#

Net5 Fx Framework
https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.301-windows-x64-installer

Git Hub
https://git-scm.com/download/win
+ Create account: https://github.com/

NPM/Node
https://nodejs.org/dist/v14.17.1/node-v14.17.1-x64.msi

Angular CLI
npm install -g @angular/cli

Dotnet EF CLI
dotnet tool install --global dotnet-ef --version 5.0.7

Scss compiler
npm install -g sass
```

# Shared Dev

A collection of workspaces to see if the kids can gain some interest and learn some marketable skillz

## Calculator Project

### Chapter One - Setting up the Plumbing, checking for leaks.

- [x] Just getting Calculator Add up and working across all the places we want

* CalculatorProject (.dll)
* CalculatorProject.UnitTest (.dll)

### Chapter Two - Unpacking a bit of noisey plumbing

- [x] Refactored out the Calculator Service
- [x] Created two Calculator Service Providers
- [x] Added several xUnit Unit Tests to see the calculator working
- [x] Created a Console app and injected the standard calculator service provider to interact with the calculator
- [x] Created a Blazor app and injected the standard calculator service provider to create an on-screen experience for the calculator
- [x] Created a few BDD Gherkin SpecFlow Selenium automated UI tests to stimulate the Blazor Calculator
- [x] Chisled out a bit more project architecture, thinking outloud
- [x] Cut a video; https://www.youtube.com/watch?v=xR9SX1Xp--E

* CalculatorProject.Console (.exe)

### Chapter Three - ?
