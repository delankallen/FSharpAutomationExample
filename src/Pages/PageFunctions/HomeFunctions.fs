namespace Pages

open System

open canopy.parallell.functions

open Framework.Sync
open Framework.CanopyExtensions

module HomeFunctions =
    open HomeMaps
    let getHomeHeading browser = read homeHeading browser
