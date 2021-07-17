namespace Pages

open Framework.XpathQuery
open canopy.parallell.functions

module DynamicLoadingMaps =
    let startBtn = css "#start > button"
    let finishDiv = select "div" |> whereAnd (Id "finish") (NotContain (Attribute ("style", "display:none")))
    let finishTxt = select "h4" |> from finishDiv
    let wat = 1 + 1;

    //Example: 
    //let newTaskBtn = select "button" |> where (Class "btn-primary") |> from topBtnDiv