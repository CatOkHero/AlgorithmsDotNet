namespace HackFest2020

open System

module CyclicBinaryString =
    let x = Console.ReadLine() |> string
    let mutable shift = x

    let isSameShift (shifted: string) =
        shifted = x

    let shiftString (s: string) =
        let chars = s.ToCharArray()
        let charArray = Array.concat [ chars.[1..]; chars.[0..0] ]
        new string(charArray)
        
    let isPrime n =
        match n with
        | _ when n > 3 && (n % 2 = 0 || n % 3 = 0) -> false
        | _ ->
            let maxDiv = int(System.Math.Sqrt(float n)) + 1
            let rec f d i = 
                if d > maxDiv then 
                    true
                else
                    if n % d = 0 then 
                        false
                    else
                        f (d + i) (6 - i)     
            f 5 2

    let res =
        [|
            while not (isSameShift (shiftString shift)) do
         
                let n = Convert.ToInt32(shift, 2)

                if not (isPrime n) then
                    let mutable incrementer = 0
                    while (n % (pown 2 incrementer) = 0) do
                        incrementer <- incrementer + 1
    
                    yield incrementer - 1
                else 
                    yield 0

                shift <- (shiftString shift)

            let n = Convert.ToInt32(shift, 2)
            if not (isPrime n) then
                    let mutable incrementer = 0
                    while (n % (pown 2 incrementer) = 0) do
                        incrementer <- incrementer + 1
    
                    yield incrementer - 1
            else 
                    yield 0
        |]

    let mainf =
        printfn "%i" (Array.max res)
