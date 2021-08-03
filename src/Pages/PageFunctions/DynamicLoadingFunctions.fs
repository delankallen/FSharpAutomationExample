namespace Pages

open canopy.parallell.functions

open Framework.Sync

module DynamicLoadingFunctions =
    open DynamicLoadingMaps
    let startLoad browser = 
        click startBtn browser
        waitForElement finishTxt browser
        read finishTxt browser
        // syncClick browser startBtn finishTxt
        // |> fun finTxt -> read finTxt browser

    let startLoadAlt browser =
        syncClick browser startBtn finishTxt
        read finishTxt browser
