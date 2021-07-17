namespace Tests

open Xunit

open canopy
open canopy.parallell.functions

open Pages.Common
open Pages.HomeFunctions

open Pages.DynamicContentFunctions
open Pages.BrokenImagesFunctions
open Pages.DynamicLoadingFunctions
open Pages.IframeEditorFunctions

module ``Dynamic Content Tests`` =

    [<Fact>]
    let ``My test`` () =
        let expectedHeading = "Welcome to the-internet"
        use browser = getBrowser None //None uses the default Browser Configuration
        goToPage browser "" //empty string for home page

        let actualHeading = getHomeHeading browser
        Assert.True((actualHeading = expectedHeading), $"Expected: {expectedHeading}, Actual: {actualHeading}")

    [<Fact>]
    let ``Images load properly`` () =
        use browser = getBrowser None //None uses the default Browser Configuration
        goToPage browser "dynamic_content"

        verifyContentImg browser
        |> fun x -> Assert.True(x |> String.isEmpty, x)

    [<Fact>]
    let ``Test for broken images`` () =
        use browser = getBrowser None
        goToPage browser "broken_images"

        verifyBrokenImgs browser
        |> fun x -> Assert.True(x |> String.isEmpty, x)

    [<Theory>]
    [<InlineData("1")>]
    [<InlineData("2")>]
    let ``Dynamically Loaded Page Elements`` (exampleUrl: string) =
        let expectedText = "Hello World!"
        use browser = getBrowser None
        goToPage browser $"dynamic_loading/{exampleUrl}"

        startLoad browser
        |> fun finTxt -> 
            Assert.True((finTxt = expectedText), $"Expected: {expectedText}, Actual: {finTxt}")

    [<Fact>]
    let ``An iFrame containing the TinyMCE WYSIWYG Editor`` () =
        let expectedTxt = "Hello, this is a WYSIWYG!"
        use browser = getBrowser None
        goToPage browser "iframe"

        editTxtArea browser expectedTxt
        |> fun actualTxt -> Assert.True((actualTxt = expectedTxt), $"Expected: {expectedTxt}, Acutal: {actualTxt}")
