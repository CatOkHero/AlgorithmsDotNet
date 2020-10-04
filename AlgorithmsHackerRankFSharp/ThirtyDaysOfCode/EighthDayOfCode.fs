namespace ThirtyDaysOfCode

open System

module EithsDayOfCode =
  let createMap n =
      [|
        for i in [1..n] do
            match (Console.ReadLine() |> string).Split([|' '|]) with
            | [| d; p |]-> yield (d, p)
            | _ -> yield! [||]

      |] |> Map.ofArray

  let mainf = 
    let n = Console.ReadLine() |> int
    let phoneBookMap = createMap n

    Seq.initInfinite (fun _ -> Console.ReadLine() |> string)
    |> Seq.takeWhile (fun s -> s <> null)
    |> Seq.iter (fun s -> 
                    match phoneBookMap.ContainsKey(s) with
                    | true -> printfn "%s=%s" s phoneBookMap.[s]
                    | false -> printfn "Not found")

    //stdin.ReadToEnd().Split '\n' 
    //|> Array.map(fun x -> string(x)) 
    //|> Array.iter (fun s -> 
                    //match phoneBookMap.ContainsKey(s) with
                    //| true -> printfn "%s=%s" s phoneBookMap.[s]
                    //| false -> printfn "Not found")