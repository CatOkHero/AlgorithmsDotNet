﻿// Learn more about F# at http://fsharp.org
open Recursion

[<EntryPoint>]
let main argv =
    printfn "fibo(8) = %i" (fibonacci 8)
    printfn "pow = %i" (pow 2 3)
    f 2
    0 // return an integer exit code
