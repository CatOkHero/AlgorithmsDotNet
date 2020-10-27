namespace FunctionalProgramming.Recursion

open System

module StringOPermute = 
    let permuteString (stringSeq: String) =
        // stringSeq
        // |> Seq.permute (fun i -> 
        //                     if ((i % 2) = 0) then 
        //                         ((i + 1) % stringSeq.Length)
        //                     else 
        //                         ((i - 1) % stringSeq.Length)
        //                 )
        // |> Seq.iter (fun c -> printf "%c" c)

        // let rec loop str = 
        //     match str with
        //     | p::q::tail -> 
        //         printf "%c%c" q p
        //         loop tail
        //     | p::q::[] -> 
        //         printf "%c%c" q p
        //         loop []
        //     | [] -> ()
        // loop (stringSeq |> List.ofSeq)

        // stringSeq
        // |> Seq.chunkBySize 2
        // |> Seq.iter (fun arr -> printf "%c%c" arr.[1] arr.[0])

        let rec loop (str: char list) (accumulative: char list)= 
            match str with
            | p::q::tail -> 
                loop tail (p::q::accumulative)
            | [] -> accumulative |> List.rev |> Array.ofList
        loop (stringSeq |> List.ofSeq) []

    let t = Console.ReadLine() |> int

    let mainf = 
        (List.map ((fun _ -> Console.ReadLine()) >> permuteString) [1..t])
        |> List.iter (fun str -> printfn "%s" (String(str)))
