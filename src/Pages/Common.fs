namespace Pages

open canopy
open canopy.parallell.functions

open Framework.Setup

module Common =
    let siteConfig =
        { browserType = types.Chrome
          size = types.FullScreen
          home = "https://the-internet.herokuapp.com/"
          compareTimeout = 120.0
          pageTimeout = 120.0
          chromeLocation = System.AppContext.BaseDirectory }

    let (|Default|) onNone value =
        match value with
        | None -> onNone
        | Some e -> e

    let getBrowser (Default siteConfig altConfig)= setupBrowser altConfig

    let goToPage browser pageUrl =
        url $"{siteConfig.home}{pageUrl}" browser
