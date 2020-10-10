namespace ThirtyDaysOfCode


open System

module TenthDayOfCode = 
    let n = Console.ReadLine() |> int
    let l = Convert.ToString(n, 2).Split('0')
            |> Array.maxBy (fun s -> s.Length)
            |> String.length

    let mainf = 
        printfn "%i" l