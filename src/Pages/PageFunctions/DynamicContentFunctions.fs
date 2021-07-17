namespace Pages

open System

open canopy.parallell.functions

open Framework

open Framework.Sync
open Framework.CanopyExtensions

module DynamicContentFunctions =
    open DynamicContentMaps
    open GetRequest
    let getContentRows browser = elements contentRows browser
    let verifyContentImg browser =
        getContentRows browser
        |> List.map (fun rowEle -> elementWithin "img" rowEle browser)
        |> List.map (fun img -> img.GetAttribute("src") |> fun x -> (x, verifyImg x))
        |> List.filter (fun (imgSrc, success) -> success = false )
        |> List.fold (fun acc (imgSrc, _) -> acc + $"\nImgSrc: {imgSrc}, Failed" ) ""


