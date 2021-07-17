## Tests

We use XUnit as the testing framework. (More on [XUnit](https://xunit.net/docs/why-did-we-build-xunit-1.0))

Tests are structured with a top level module that contains all the test functions.
Modules should be titled clearly as to the tests they contain.

    module ``Welcome To The Internet Tests`` = 

Test functions are decorated with the `[<Fact>]` attribute, this marks it as a test for XUnity to run it.

    module ``Welcome To The Internet Tests`` = 
        [<Fact>]
        let ``Home Page Test`` () =

Each test should set expected data at the start if needed.
You should `use` the browser object as we won't to make sure it is disposed on test end.

    let expectedHeading = "Welcome to the-internet"
    use browser = getBrowser None //None uses the default Browser Configuration
    goToPage browser "" //empty string for home page

From here the rest of the test steps can be added.
All tests end with an assertion. 

    let actualHeading = getHomeHeading browser
    Assert.True((actualHeading = expectedHeading), $"Expected: {expectedHeading}, Actual: {actualHeading}")

More documentation on test structure from [XUnit](https://xunit.net/docs/getting-started/netcore/cmdline)