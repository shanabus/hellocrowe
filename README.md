# Hello Crowe
A sample .NET 5 app stack

## Getting Started
Clone repository and make sure you have [.NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0) installed

## Console App
Navigate to the Console App and run:

```
dotnet run
```

## API
Navigate to the Api folder and run:

```
dotnet run
```

Then open a browser or point a rest client to http://localhost:5000/api/messages

~ or ~

Open http://localhost:5000/swagger/index.html and use the Swagger UI to test the Messages API

To try out an alternate configuration where the service layer injects the file-based repository, run the command with the launch profile "Api-Filebased". This works because the environment-specific `Configure...` methods respect the configuration mapped in the launchSettings.json file.

```
dotnet run --launch-profile "Api-FileBased"
```


## Tests

Navigate to the Test folder and run:

```
dotnet test
```

For more verbosity use a switch like `-v n`