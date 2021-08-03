namespace Pages

open canopy.parallell.functions

open Framework.CanopyExtensions

module IframeEditorFunctions =
    open IframeEditorMaps
    let editTxtArea browser txt =
        switchToFrame browser editorFrameId
        write editorTxtArea txt browser
        let actualTxt = read editorTxtArea browser
        switchToParentFrame browser
        actualTxt
