namespace HackFest2020

open System

// https://www.hackerrank.com/contests/hackerrank-hackfest-2020/challenges/stones-piles
module GameOfMaximization = 
    let n = Console.ReadLine() |> int
    let array = 
        Console.ReadLine().Split(' ')
        |> Array.map (fun c -> Convert.ToInt32(c))

    let isEven x = x % 2 = 0

    let partEven, partOdd = 
        array
        |> Array.mapi (fun i v -> (i, v))
        |> Array.partition (fun (i, v) -> isEven i)

    let even =
        partEven
        |> Array.map (fun (i, v) -> v)

    let odd =
        partOdd
        |> Array.map (fun (i, v) -> v)
    
    let isEvenBigger even odd=
        even > odd

    let mainf = 
        let mutable evenSum = Array.sum even
        let mutable oddSum = Array.sum odd

        while (evenSum <> oddSum) do
            if (isEvenBigger evenSum oddSum) then
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
                evenSum <- evenSum - 1
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
                oddSum <- oddSum - 1

        printfn "%i" (evenSum + oddSum)   


                

     
