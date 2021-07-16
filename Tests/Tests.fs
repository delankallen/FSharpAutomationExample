namespace Tests

open Xunit

open canopy
open canopy.parallell.functions

open Framework.Setup
open Tools.HomeFunctions

module ``Dynamic Content Tests`` =
    let siteConfig =
        { browserType = types.Chrome
          size = types.FullScreen
          home = "https://the-internet.herokuapp.com/"
          compareTimeout = 120.0
          pageTimeout = 120.0
          chromeLocation = System.AppContext.BaseDirectory }


    [<Fact>]
    let ``My test`` () =
        let expectedHeading = "Welcome to the-internet"
        use browser = setupBrowser siteConfig
        url siteConfig.home browser

        let actualHeading = getHomeHeading browser
        Assert.True((actualHeading = expectedHeading), $"Expected: {expectedHeading}, Actual: {actualHeading}")
