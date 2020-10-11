namespace HackFest2020

open System

module GameOfMaximization = 
    let n = Console.ReadLine() |> int
    let array = 
        Console.ReadLine().Split(' ')
        |> Array.map (fun c -> Convert.ToInt32(c))

    let isEven x = x % 2 = 0

    let even =
        array
        |> Array.mapi (fun i v -> (i, v))
        |> Array.partition (fun (i, v) -> isEven i)
        |> fst
        |> Array.map (fun (i, v) -> v)

    let odd =
        array
        |> Array.mapi (fun i v -> (i, v))
        |> Array.partition (fun (i, v) -> not (isEven i))
        |> fst
        |> Array.map (fun (i, v) -> v)

    let rule (even : int[]) (odd : int[]) =
        (Array.sum even) = (Array.sum odd)
    
    let isEvenBigger =
        (Array.sum even) > (Array.sum odd)

    let mainf = 
        let a = even
        let b = odd
        while not (rule even odd) do
            if isEvenBigger then
                let maxIndex = 
                        even
                        |> Array.mapi (fun i v -> (i, v))
                        |> Array.maxBy snd
                        |> fst
                
                let evenMax = 
                    match (even.[maxIndex] - 1) with
                    | x when x >= 0 -> x
                    | _ -> 0

                even.[maxIndex] <- evenMax
            else
                let maxIndex = 
                        odd
                        |> Array.mapi (fun i v -> (i, v))
                        |> Array.maxBy snd
                        |> fst

                let oddMax = 
                    match (odd.[maxIndex] - 1) with
                    | x when x >= 0 -> x
                    | _ -> 0

                odd.[maxIndex] <- oddMax

        printfn "%i" ((Array.sum even) + (Array.sum odd))   


                

     
