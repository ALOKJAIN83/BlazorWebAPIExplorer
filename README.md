# BlazorWebApiExplorer Solution

## Overview

BlazorWebApiExplorer is a Blazor Server application designed to interact with multiple web APIs for fetching and posting data. The application communicates with a FrontEnd API, which in turn asynchronously calls two back-end APIs. These back-end APIs use artificial delays to simulate longer-running operations. The solution is modular and testable, with unit tests implemented using xUnit, bunit, and Moq.

The solution includes multiple projects:
- `BlazorServerUI`: The main Blazor Server application.
- `BlazorServerUI.Services`: Contains service classes, including `ApiService`, which interacts with the FrontEnd API to fetch and post data.
- `FrontEndApi`: An API that supports GET and POST operations and calls two back-end APIs asynchronously.
- `BackEndApi1`: A back-end API with GET and POST operations that simulates longer-running operations using artificial delays.
- `BackEndApi2`: Another back-end API with GET and POST operations that simulates longer-running operations using artificial delays.
- `UnitTests`: Contains unit tests for controllers, services, APIs, and Blazor components using xUnit, bunit, and Moq.

## Features

- Fetch data from back-end APIs using the FrontEnd API.
- Post data to back-end APIs using the FrontEnd API.
- Comprehensive unit tests for controllers, services, APIs, and Blazor components using xUnit, bunit, and Moq.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

## Getting Started

### Build and Run the Solution

1. Open the solution in Visual Studio 2022.
2. Restore the NuGet packages.
3. Build the solution.
4. Set `BlazorServerUI`,`FrontEndApi`,`BackEndApi1`, and `BackEndApi2` as the startup projects.
5. Run the application.

### Running Unit Tests

1. Open the Test Explorer in Visual Studio.
2. Run all tests to ensure everything is working correctly.

### Clone the Repository