namespace ThirtyDaysOfCode

open System

module TwentyNinthDayOfCode = 
    let i = Console.ReadLine() |> int

    // Don't like this approach, but it works
    // Probably there could be something else, like dp
    let moveToRestOfArray arr valueToCompare k = 
        let rec loop arr valueToCompare k max =
            match arr with
            | head::tail ->
                let bitwise = (valueToCompare &&& head)
                if bitwise < k && bitwise > max then
                    loop (tail) valueToCompare k bitwise
                else 
                    loop (tail) valueToCompare k max
            | [] -> max
        loop arr valueToCompare k 0

    let checkBitwise k arrayOfValue =
        let rec loop k arr compared max = 
            match arr with
            | head::tail -> 
                let result = moveToRestOfArray tail head k
                if (result > max && result < k) then
                    loop k (tail) compared result
                else 
                    loop k (tail) compared max
            | [] -> 
                max
        loop k arrayOfValue 0 0

    let mainf = 
        (Seq.map ((fun _ -> 
            let arr = Console.ReadLine().Split(" ")
            let n = arr.[0] |> int
            let k = arr.[1] |> int
            (
                n, 
                k, 
                seq 
                    { 
                        for x in [1..n] do
                            yield x
                    }
            )) >> (fun (n, k, arr) -> (checkBitwise k (arr |> List.ofSeq)))) [1..i])
        |> Seq.iter (fun max -> printfn "%i" max)