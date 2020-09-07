// Learn more about F# at http://fsharp.org

open System
open Recursion

[<EntryPoint>]
let main argv =
    printfn "fibo(8) = %i" (fibonacci 8)
    printfn "pow = %i" (pow 2 3)
    0 // return an integer exit code
