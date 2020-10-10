namespace ThirtyDaysOfCode

open System

module NinthDayOfCode = 
    let factorial n =
        // let rec loop i acc = 
        //     match i with
        //     | 0 | 1 -> acc
        //     | _ -> loop (i - 1) (acc * i)
        // loop n 1
        [1..n] |> List.reduce (*)

    let mainf = 
        let n = Console.ReadLine() |> int
        printfn "%i" (factorial n)
