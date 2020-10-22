namespace ThirtyDaysOfCode

open System

module EleventhDayOfCode = 
    let array2D = [|
        for i in [0..6] do
            [| yield! Console.ReadLine().ToCharArray() |> Array.map (fun c -> Convert.ToInt32(c)) |]
    |]

    let takeFiveElements (array2D : int [] []) (i,j) (x,c) (z,a) (d, s) (v,b) = 
        [| array2D.[i].[j]; array2D.[x].[c]; array2D.[z].[a]; array2D.[d].[s]; array2D.[v].[b] |]

    // let validateArrayIndexes (array2D: int [] []) (i, j) = 
    //     if (i + 2) <= array2D.Length then
    //         (j + 2) <= array2D.[i].Length
    //     else 
    //         false

    // let array2DIter (array2D: int[] []) =
    //     let rec loop array2D i j =
    //         match i, j with
    //         | 0, 0 -> loop array2D (i+1) (j+1)

