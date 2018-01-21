## Synopsis

An application which exposes race and customer details via APIs, with a web page that can display race details.

## Installation

As this is a .NET Core 2 application, it can be published and hosted in compatible web servers on Windows and Linux, please see the following link for details: https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/?tabs=aspnetcore2x

A published version of the application has been included in the root of the repository in PublishOutput.zip.

Alternatively the solution can be opened in Visual Studio 2017+ and run/debugged in the normal way using IIS Express.

## API Reference

There are two APIs:

1. /api/races - this displays race details.
2. /api/customers - this displays customer details.

## Tests

The tests can be run from the command line: 

>dotnet test techchallenge_jphilip\RaceDay\RaceDay.Tests\RaceDay.Tests.csproj

Alternatively the solution can be loaded in Visual Studio 2017+ and run via the Test Explorer.

## License

The William Hill Tech Challenge evaluation license.