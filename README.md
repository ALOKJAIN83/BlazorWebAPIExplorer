# BlazorWebApiExplorer Solution

## Overview

This is a Blazor Server application using web apis to fetch and post data. 
It calls FroneEnd api which in turn calls 2 back-end APIs in an Asynchronous manner. 
Thease 2 back-end APIs use artificial delays to mimic a longer running operation.
The application is designed to be modular and testable, with unit tests written using xUnit, bunit and Moq. 
 
The solution includes multiple projects:
- `BlazorServerUI`: The main Blazor Server application.
- `BlazorServerUI.Services`: Contains service classes, including `ApiService` that interacts with front-end API to fetch and post data.
- `FrontEndApi`: This API supports Get/Post verbs. It calls 2 back-end APIs in an Asynchronous manner.
- `BackEndApi1`: The API which has GET and POST opeartions and mimics a longer running operation using artificial delays.
- `BackEndApi2`: Another API which has GET and POST opeartions and mimics a longer running operation using artificial delays.
- `UnitTests`: Contains unit tests for controllers, services, APIs and Blazor components using xUnit, bunit and Moq.

## Features

- Fetch data from back-end APIs using front-end API
- Post data to back-end APIs using front-end API
- Unit tests for controllers, services, APIs and Blazor components using xUnit, bunit and Moq.

## Prerequisites

## Getting Started

### Clone the Repository