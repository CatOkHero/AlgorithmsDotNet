namespace ThirtyDaysOfCode

open System

module SixthDayOfCode = 
    let split lst = 
        let splitFolder (l1, l2) (i, x) =
            match i % 2 = 0 with
            | true -> x :: l1, l2 // return list 1 with x prepended and list2
            | false -> l1, x :: l2 // return list 1 and list 2 with x prepended
        lst
        |> List.mapi (fun i x -> i, x) // map list of values to list of index*values
        |> List.fold (splitFolder) ([], []) 

    let mainf =
        let t = Console.ReadLine() |> int
        for i in [0..t] do
            let list = 
                (Console.ReadLine() |> string).ToCharArray()
                |> List.ofArray

            let result = split list
            fst result
            |> List.rev
            |> List.iter (fun v -> printf "%c" v)
            printf " "
            snd result
            |> List.rev
            |> List.iter (fun v -> printf "%c" v)
            printfn ""