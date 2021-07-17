## Pages

Pages is broken into Maps and Functions.
Generic functions and helpers for the site can be placed in `Common.fs` or added as there own `.fs`, i.e. `GetRequest.fs`

    Pages
    -- PageMaps
        -- HomeMaps.fs
    -- PageFunctions
        -- HomeFunctions.fs
    Common.fs
    GetRequest.fs

Maps contain element locators. 
Functions consume the locators to perform actions.

## Maps

A map contains a top level module, the tool being mapped, with sub modules of the different sections of the tool.

The Xpath Query DSL should be used to find complex or hard to reach elements.
A simple css selector worked for the start button, but getting the dynamic div is a little harder.

I used the XPathQuery here to find a div that contained the Id `finsih`, but not `styele='display:none'`

    module DynamicLoadingMaps =
        let startBtn = css "#start > button"
        let finishDiv = select "div" |> whereAnd (Id "finish") (NotContain (Attribute ("style", "display:none")))

Best practice is to find a top level element node to use as the base for the query.
In the case of the finish div, the top is a div, `finishDiv`. We can find the `h4` inside the `finishDiv`.

    let finishTxt = select "h4" |> from finishDiv

This workflow will help keep xpath queries focused as some UI elements are generic, with no ID to single them out.

Chrome's developer tools have a search bar which accepts Xpath if you need to test that your xpath is correct.

Pass an argument when you need to find an element with specific data from the test

    let userTableRow username = select "div" |> where (Id $"{username}")

I chose XPath over CSS Selectors to be able to find elements by "contains text" and to find a parent by the child. CSS currently can not find parent elements or contains text. 

## Functions

This is where we call the maps to click and input data.
These are the functions that are actually called from tests so they should be clear in what they will do. Tests are written to be human readable.

General workflow is to combine base actions, i.e. clicks/writes, into larger actions.

Here is the first few steps of `DynamicLoadingFunctions` module:

    module DynamicLoadingFunctions =
        open DynamicLoadingMaps
        let startLoad browser = 
            syncClick browser startBtn finishTxt
            |> fun finTxt -> read finTxt browser

You open the `DynamicLoadingMaps`, create a base function with the browser object.
From here you would add the actions for the test step.
