namespace Pages

open System

open canopy.parallell.functions

open Framework.Sync
open Framework.CanopyExtensions

module IframeEditorFunctions =
    open IframeEditorMaps
    let editTxtArea browser txt =
        switchToFrame browser editorFrameId
        write editorTxtArea txt browser
        let actualTxt = read editorTxtArea browser
        switchToParentFrame browser
        actualTxt


    //Example: 
    // let enterTaskText browser txt = write bodyTxt txt browser
