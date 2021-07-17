namespace Pages

module GetRequest = 
    open Hopac

    open Framework.Rest
    open FSharp.Json

    let private _getRequest queries url =
        getRequest queries url
        |> fun (x, y) -> (x, Json.deserialize<string> y)


    let verifyImg url =
        getRequest [] url
        |> fun (x, y) -> 
            match x with
            | 200 -> true
            | _ -> false
