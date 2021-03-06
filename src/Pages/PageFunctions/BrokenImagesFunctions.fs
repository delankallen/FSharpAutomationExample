namespace Pages

open System

open canopy.parallell.functions

open Framework

open Framework.Sync
open Framework.CanopyExtensions

module BrokenImagesFunctions =
    open BrokenImagesMaps
    open GetRequest
    let verifyBrokenImgs browser =
        elements brokenImgs browser
        |> List.map (fun img -> img.GetAttribute("src") |> fun x -> (x, verifyImg x))
        |> List.filter (fun (_, success) -> not success )
        |> List.fold (fun acc (imgSrc, _) -> acc + $"\nImgSrc: {imgSrc}, Failed" ) ""


