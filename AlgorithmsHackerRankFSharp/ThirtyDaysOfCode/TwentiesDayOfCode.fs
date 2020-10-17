namespace ThirthyDaysOfCode

open System

module TwentiesDayOfCode = 
    let n = Console.ReadLine() |> int
    let array = Console.ReadLine().Split(" ") 
                |> Array.map (fun s -> Convert.ToInt32(s)) 
                |> List.ofArray

    let bubbleSort array numberOfSwaps =
        let rec loop numberOfSwaps accumulate reverse array  =
            match array, reverse with
            | [], true -> accumulate |> List.rev, numberOfSwaps
            | [], false -> accumulate |> List.rev |> loop numberOfSwaps [] true 
            | x::y::tl, _ when x > y -> loop (numberOfSwaps + 1) (y::accumulate) false (x::tl) 
            | hd::tl, _ -> loop numberOfSwaps (hd::accumulate) reverse tl 
        loop 0 [] false array
        
    let sorted, swaps = bubbleSort array 0

    printfn "Array is sorted in %i swaps." swaps
    printfn "First Element: %i" array.Head
    printfn "Last Element: %i" (array |> List.rev |> List.head)
    