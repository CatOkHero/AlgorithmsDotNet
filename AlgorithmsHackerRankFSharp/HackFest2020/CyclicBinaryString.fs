namespace HackFest2020

open System

module CyclicBinaryString =
    let x = Console.ReadLine() |> string
    let mutable shift = x

    let isSameShift (shifted: string) =
        shifted = x

    let shiftString (s: string) =
        s.[(s.Length - 1)..(s.Length - 1)] + s.[0..(s.Length - 2)] 
        
    let isPrime (n : uint64) =
        match n with
        | _ when n > 3UL && (n % 2UL = 0UL || n % 3UL = 0UL) -> false
        | _ ->
            let maxDiv = uint64(System.Math.Sqrt(float n)) + 1UL
            let rec f (d: uint64) (i: uint64) = 
                if d > maxDiv then 
                    true
                else
                    if n % d = 0UL then 
                        false
                    else
                        f (d + i) (6UL - i)     
            f 5UL 2UL

    let convert n =
        try
            Convert.ToUInt64(n, 2)
        with _ ->
            0UL


    let mainf =
            let mutable max = 0

            while not (isSameShift (shiftString shift)) do
       
                let n = convert shift

                if not (isPrime n) then
                    let mutable incrementer = 0
                    while (n % (pown 2UL incrementer) = 0UL) do
                        incrementer <- incrementer + 1
    
                    if (incrementer - 1) > max then 
                        max <- incrementer - 1
                else 
                    ()

                shift <- (shiftString shift)

            let n = convert shift
            if not (isPrime n) then
                    let mutable incrementer = 0
                    while (n % (pown 2UL incrementer) = 0UL) do
                        incrementer <- incrementer + 1
    
                    if (incrementer - 1) > max then 
                        max <- incrementer - 1
            else 
                    ()

            printfn "%i" (max)
