#r "nuget: canopy"
#r "nuget: dapper"
#r "nuget: FSharp.Json"
#r "nuget: Http.fs"
#r "nuget: Microsoft.Data.SqlClient"
#r "nuget: Selenium.Support"
#r "nuget: Selenium.WebDriver.ChromeDriver"
#r "../src/Pages/bin/Debug/net7.0/Framework.dll"
#r "../src/Pages/bin/Debug/net7.0/Pages.dll"

#load "SetupBrowser.fsx"

open canopy
open canopy.parallell.functions

open Framework.Setup
open Pages.Common

()