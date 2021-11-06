namespace Algorithms.Implementation

open System

module NumberLineJumps =
    // x1 + y * v1 = x2 + y * v2
    // y = (x1 - x2) / (v2 - v1)
    let canMeet () =
      let line = Console.ReadLine() |> (fun x -> x.Split(" "))
      let x1 = line.[0] |> int
      let v1 = line.[1] |> int
      let x2 = line.[2] |> int
      let v2 = line.[3] |> int
      let result () =
        if (x1 - x2) % (v2 - v1) = 0 then
          printfn "YES"
        else 
          printfn "NO"
      
      if (x1 > x2 && v1 < v2) then
        result ()
      elif (x1 < x2 && v1 > v2) then 
        result ()
      else 
        printfn "NO"
