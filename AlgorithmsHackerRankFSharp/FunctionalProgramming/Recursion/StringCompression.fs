namespace FunctionalProgramming.Recursion

open System

module StringCompression = 
    // Parcially works
    // I don't like toooo much of match cases
    // Probably should rethink an approach
    // 10 of 15 test cases passes
    let message = Console.ReadLine().ToCharArray() |> List.ofArray

    let compression (charArray : char list) = 
        let rec loop (charArray : char list) counter lastValue (accumulative: char list) =
            match charArray, counter with 
            | [], 0 -> accumulative |> List.rev |> Array.ofList
            | [], x -> (accumulative) |> List.rev |> Array.ofList
            | x::y::tl, counter when x = y -> loop (y::tl) (counter+1) x accumulative 
            | x::y::tl, counter when ((x <> y) && (counter > 0) && (x = lastValue)) -> loop (y::tl) (0) ' ' (Char.Parse((counter + 1).ToString())::[x] @ accumulative)
            | x::y::tl, counter when ((x <> y) && (counter > 0)) -> loop (y::tl) (0) ' ' (Char.Parse(counter.ToString())::[x] @ accumulative)
            | x::y::tl, counter when ((x <> y) && (counter = 0)) -> loop (y::tl) 0 ' ' ([x] @ accumulative)
            | hd::[x], counter when (hd = x) -> loop [] (counter + 1) x (x::accumulative)
            | x::[y], counter when (x <> y) -> loop [] 0 ' ' (x::y::accumulative)
            | [x], y when x = lastValue -> (Char.Parse((counter + 1).ToString())::[x] @ accumulative) |> List.rev |> Array.ofList
            | [x], y -> ([x] @ accumulative) |> List.rev |> Array.ofList
            | _ -> accumulative |> List.rev |> Array.ofList

        loop charArray 0 ' ' [] 

    let mainf = 
        let compressedCharList = compression message
        let stringValue = new string(compressedCharList)
        printfn "%s" (stringValue)