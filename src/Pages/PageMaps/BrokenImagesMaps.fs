namespace Pages

open Framework.XpathQuery
open canopy.parallell.functions

module BrokenImagesMaps =
    let exampleDiv = select "div" |> where (Class "example")
    let brokenImgs = select "img" |> from exampleDiv

    //Example: 
    //let newTaskBtn = select "button" |> where (Class "btn-primary") |> from topBtnDiv