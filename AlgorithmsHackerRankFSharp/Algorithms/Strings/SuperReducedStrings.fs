namespace Algorithms.Strings

open System
open System.Collections.Generic

module SuperReducedStrings = 
    let chars = Console.ReadLine().ToCharArray()
    // let reduced =
    //     chars
    //     |> Array.groupBy (id)
    //     |> Array.map (fun (single, seqOfChars) -> 
    //         if seqOfChars.Length % 2 <> 0 then single
    //         else ' ')
    //     |> String
    //     |> String.filter (fun c -> c <> ' ')

    // let reduceFunc chars =
    //     let rec loop chars accumulative =
    //         match chars with
    //         | head::el::tail when head = el -> loop tail accumulative
    //         | head::el::tail when head <> el -> loop (el::tail) (head::accumulative)
    //         | [x] -> loop [] (x::accumulative)
    //         | [] -> accumulative |> List.rev |> Array.ofList
    //     loop chars []

    // let reduceFunc chars =
    //     chars
    //     |> Seq.pairwise
    //     |> Seq.filter (fun (p, q) -> p <> q)
    //     |> Array.ofSeq
    //     |> Array.collect (fun (p, q) -> [| p; q|])
    //     |> String

    // let validateStack value (stack: Stack<char>) func =
    //     if stack.Count = 0 then
    //         stack.Push(value)
    //         func
    //     else
    //         let peek = stack.Peek()
    //         if peek = value then
    //             stack.Pop() |> ignore
    //             func
    //         else 
    //             stack.Push(value)
    //             func

    let reduceFunc chars =
        let rec loop chars (accumulative: Stack<char>) =
            match chars with
            | head::el::tail when head = el -> 
                loop (tail) accumulative
            | head::el::tail when head <> el -> 
                if accumulative.Count = 0 then
                    accumulative.Push(head)
                    loop (el::tail) (accumulative)
                else
                    let peek = accumulative.Peek()
                    if peek = head then
                        accumulative.Pop() |> ignore
                        loop (el::tail) (accumulative)
                    else 
                        accumulative.Push(head)
                        loop (el::tail) (accumulative)
            | [x] -> 
                let peek = accumulative.Peek()
                if peek = x then
                    accumulative.Pop() |> ignore
                    loop [] (accumulative)
                else 
                    accumulative.Push(x)
                    loop [] (accumulative)
            | [] -> accumulative.ToArray() |> Array.rev |> String
        loop chars (Stack<char>())

    let mainf =
        let reduced = reduceFunc (chars |> List.ofArray)
        printfn "%s" (if reduced.Length > 0 then reduced else "Empty String")