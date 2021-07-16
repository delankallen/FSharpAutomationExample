namespace Tools

open Framework.XpathQuery
open canopy.parallell.functions

module HomeMaps =
    let homeHeading = css ".heading"

    //Example: 
    //let newTaskBtn = select "button" |> where (Class "btn-primary") |> from topBtnDiv