namespace ThirtyDaysOfCode


open System

module TwentyEightsDayOfCode = 
    let n = Console.ReadLine() |> int

    let mainf = 
    [1..n]
    |> Seq.map (fun _ -> 
        let strings = Console.ReadLine().Split(" ")
        (strings.[0], strings.[1]))
    |> Seq.filter (fun (id, email) -> email.EndsWith("@gmail.com"))
    |> Seq.sortBy (fun (id, email) -> id)
    |> Seq.iter (fun (id, email) -> (printfn "%s" id))