namespace Algorithms.Strings

open System
open System.Text.RegularExpressions

module CamelCase = 
    let s = Console.ReadLine()

    let regexp = Regex("[A-Z]")
    let matches = regexp.Matches(s)

    let mainf = 
        printfn "%i" (matches.Count + 1)