namespace Tests

open Xunit

open canopy
open canopy.parallell.functions

open Pages.Common
open Pages.HomeFunctions

open Pages.DynamicContentFunctions
open Pages.BrokenImagesFunctions

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
