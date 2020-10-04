namespace FunctionalProgramming.Recursion

open System

module PascalsTriangle =
    let factorial n = 
        let rec loop i acc = 
            match i with 
            | 0 | 1 -> acc
            | _ -> loop (i - 1) (acc * i)
        loop n 1


    let findNthRthIndex n r =
        (factorial n) / ((factorial r) * (factorial (n - r)))

    let mainf = 
        let n = Console.ReadLine() |> int
        for i = 0 to n - 1 do
            for j = 0 to i do
                printf "%i " (findNthRthIndex i j)
            printfn ""