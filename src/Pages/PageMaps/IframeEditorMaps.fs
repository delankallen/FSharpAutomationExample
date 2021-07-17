namespace Pages

open Framework.XpathQuery
open canopy.parallell.functions

module IframeEditorMaps =
    let editorFrameId = "mce_0_ifr"
    let editorTxtArea = "#tinymce > p"

    //Example: 
    //let newTaskBtn = select "button" |> where (Class "btn-primary") |> from topBtnDiv