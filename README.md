# Technical Test Submittion
Signed by: Eugene Ordeniza 
Project Started on 26/September/2025

## Project Overview
A .NET 8 Blazor application that provides a user interface for translating numerical values into their corresponding English words. 
The application consists of a front-end component for user interaction and a back-end C# logic for processing the numerical translation.

IO example: Input: 123 -> Output: "one hundred and twenty-three"


## Project Structure

- `Components/` - Reusable Blazor components
- `Pages/` - Blazor components and pages, including the main solution for C# technical test: Such as `NumericalTranslator.razor` which is the frontend and `NumericalTranslator.razor.cs` which is the backend logic.
- `wwwroot/` - Static files (CSS, JS, images)
- `Program.cs` - Application entry point

Solution Location: `TechOneTechnicalTest/Components/Pages/NumericalTranslator.razor.cs`

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed

## Running and Building the Application

To get started, clone the repository and navigate to the project directory.
Git:
```bash
git clone https://github.com/GeneWasHere/TechOneTechnicalTest
```

Navigate to the project directory:
```bash
cd TechOneTechnicalTest
```
To build the dependencies, run:
```bash
dotnet restore
```

Then, To build the application, run:
```bash
dotnet build
```
To run the web application locally, use:
```bash
dotnet run
```
After running, navigate to `https://localhost:7117; http://localhost:5268` (or the URL shown in the console) to view the app.

## Run Test Suite

To execute the test suite, navigate to the test project directory from the parent directory "TechOneTechnicalTest":
```bash
cd "Technical Interview Tests"
```
Then run `dotnet.restore` and `dotnet.build` if the project has not been initialised, then run the following:
```bash
dotnet test --logger:"console;verbosity=detailed"
```
Test results will be displayed in the console.

This is a Blazor application targeting .NET 8.


