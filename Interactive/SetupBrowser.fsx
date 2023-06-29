#r "nuget: canopy"
#r "nuget: dapper"
#r "nuget: FSharp.Json"
#r "nuget: Http.fs"
#r "nuget: Microsoft.Data.SqlClient"
#r "nuget: Selenium.Support"
#r "nuget: Selenium.WebDriver.ChromeDriver"
#r "../src/Pages/bin/Debug/net7.0/Framework.dll"
#r "../src/Pages/bin/Debug/net7.0/Pages.dll"

open canopy
open canopy.parallell.functions
open System.Globalization

open Framework.Setup
open Pages.Common
open OpenQA.Selenium


let siteConfig =
    { browserType = types.Chrome
      size = types.FullScreen
      home = "https://the-internet.herokuapp.com/"
      compareTimeout = 120.0
      pageTimeout = 120.0
      chromeLocation = "./" }

let altConfig = Some siteConfig
let browser = getBrowser altConfig
goToPage browser  "login"

let eleWithIds = elements "//*[@id]" browser

let wat = eleWithIds.Head.GetAttribute("id")

let upper (x:string) =
  let textInfo = CultureInfo.CurrentCulture.TextInfo
  textInfo.ToTitleCase(x)

let parseEle (ele:IWebElement) =
  (ele.GetAttribute("id"), ele.TagName) 
  |> (fun (att, tag) 
        -> $"""let {att.Replace("-", "")}{upper tag} = select "{tag}" |> where (Id "{att}")""")
  
let yoMom = List.map(fun (ele:IWebElement) -> parseEle ele) eleWithIds

let printList xList =
  List.iter(fun x -> printfn $"{x}") xList

printList yoMom