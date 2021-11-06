namespace Algorithms.Implementation

open System

module DayOfProgrammer = 
    let n = Console.ReadLine() |> int
    let isLeep =
        if n % 4 = 0 then
            printfn "12.09.%i" n
        else 
            printfn "13.09.%i" n
