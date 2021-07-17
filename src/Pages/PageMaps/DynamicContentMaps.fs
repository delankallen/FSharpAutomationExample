namespace Pages

open Framework.XpathQuery
open canopy.parallell.functions

module DynamicContentMaps =
    let contentDiv = select "div" |> where (Id "content")
    let contentRows = selectChild "div" |> where (Class "row") |> from contentDiv

    let contentImg = select "img" |> from contentRows
    let contentTxt = select "div" |> where (NodeIndex 2) |> from contentRows
