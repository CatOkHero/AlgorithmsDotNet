namespace FunctionalProgramming.Recursion

open System

module StringMingling = 
    let p = Console.ReadLine().ToCharArray() |> List.ofArray
    let q = Console.ReadLine().ToCharArray() |> List.ofArray

    let merge p q =
        let rec loop p q acc = 
            match p, q with
            | [], [] -> acc |> Array.ofList |> Array.rev
            | phd::ptl, qhd::qtl -> loop ptl qtl (qhd::phd::acc)
            | _ -> [| |]
        loop p q []

    let mainf = 
        let concatinatedString = new string((merge p q))
        printfn "%s" concatinatedString