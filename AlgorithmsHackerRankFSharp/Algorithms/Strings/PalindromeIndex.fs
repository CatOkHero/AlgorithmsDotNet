namespace Algorithms.Strings

open System

module PalindromeIndex = 
    let palindrome l = Array.rev l = l

    // extremely gavno
    let manualPalindromeCheck (l: _[]) =
        let mutable res = -1
        for i = 0 to l.Length - 1 do
            if l.[i] <> l.[l.Length - i - 1] then
                let removeFirst = palindrome l.[(i+1)..l.Length - i - 1]
                if removeFirst && res = -1 then
                    res <- i
                else
                    let removeLast = palindrome l.[i..l.Length - i - 2]
                    if removeLast && res = -1 then 
                        res <- l.Length - i - 1
                    else ()
            else ()
        res


    let mainf = 
        let n = Console.ReadLine() |> int
        for i = 1 to n do
            (Console.ReadLine() |> string).ToCharArray()
            |> manualPalindromeCheck
            |> printfn "%i"

