namespace Pages

open Framework.XpathQuery
open canopy.parallell.functions

module LoginMaps =
    let exampleDiv = select "div" |> where (Class "example")
    let brokenImgs = select "img" |> from exampleDiv