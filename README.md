# FSharpAutomationExample

Everything is written in F# using the canopy library as a wrapper around the C# Selenium library.

## Getting setup 

To run the tests you will need [.Net Core 5](https://dotnet.microsoft.com/download). 

The tests are configured to run [Chrome](https://www.google.com/chrome/), but can be configured for Firefox or Edge.
This is configured in `siteConfig: BrowserConfig` in `/Pages/Common.fs`.

For writing and debugging tests I prefer [Visual Studio Code](https://code.visualstudio.com/) with the [Ionide-fsharp](https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-fsharp) extension.
This handles the F# intellisense and step through debugging.

After cloning the repository navigate to the root of the project and run:

    dotnet build

Note: FrameworkCore is a submodule. 
If you get an error about `src\FrameworkCore\Framework.fsproj` not being found run this at the run root directory: 

    git submodule init
    git submodule update
    
This will clone the framework submodule.

# Running Tests

Tests are ran with the dotnet cli. While in the root directory 

    dotnet test

Will run all the tests in the directory.

    dotnet test --filter "{Name of test}"

This will try to match all the test names.

    dotnet test --filter "Dynamically Loaded Page Elements"

Would run the "Dynamically Loaded Page Elements" test

    dotnet test --filter "Images"

This would run any test with a name containing Images, i.e. "Test for broken images" and "Images load properly"

More information on [dotnet test](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test)

## Debugging Tests

Debugging dotnet tests is a little round about.
You launch a regular dotnet console process and then launch the test from there. 

Each test suite will contain a `Program.fs`. Add whatever test you want to debug.
To debug the `Test for broken images` it would look like this.

    namespace Tests

    module Program = 
        [<EntryPoint>]
        let main _ = 
            ``Dynamic Content Tests``.``Test for broken images`` ()
            0

Once setup, vscode will hit all your test breakpoints as usual.

You'll want to configure your VSCode to launch the right program file.

For ease of setup I have supplied my own launch configuration. Add it to "configurations" in `.vscode/launch.json`

        {
            "name": "Debug Tests",
            "type": "coreclr",
            "request": "launch",
            "preLaunchTask": "build",
            "program": "${workspaceFolder}/Tests/bin/Debug/net5.0/Tests.dll",
            "args": [],
            "cwd": "${workspaceFolder}",
            "stopAtEntry": false,
            "console": "internalConsole",
        }

# Structure

The automation is made up of Framework, Tools and Tests.

## Framework

Framework is composed of all the generic back end stuff. Framework has nothing project specific. It is meant to be used for any project. 

Framework currently contains:
- CanopyExtensions.fs
- Database.fs
- Rest.fs
- Setup.fs
- Sync.fs
- XpathQuery.fs

More detail on [Framework](./docs/framework.md)

## Pages

The structure of Pages should model the site being automated.
The sample site contains a single page full of links to other pages.
Each page has a Maps and a Functions file.

More detail on [Pages](./docs/pages.md)

## Tests

Tests are contained in their own folder and project.
For the sample site there will be a single test project, but as the complexity of the site demands you would create new test suites to model the application.

More detail on [Tests](./docs/tests.md)