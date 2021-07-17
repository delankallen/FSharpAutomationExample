namespace Pages

open System

open canopy.parallell.functions

open Framework.Sync
open Framework.CanopyExtensions

module DynamicLoadingFunctions =
    open DynamicLoadingMaps
    let startLoad browser = 
        syncClick browser startBtn finishTxt
        |> fun finTxt -> read finTxt browser
