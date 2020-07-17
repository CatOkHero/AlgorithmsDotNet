// Learn more about F# at http://fsharp.org

open System
open Recursion

[<EntryPoint>]
let main argv =
    //let rnd = System.Random()

    ///// This is an infinite sequence which is a random walk.
    ///// This example uses yield! to return each element of a subsequence.
    //let rec randomWalk x =
    //    seq { yield x
    //          yield! randomWalk (x + rnd.NextDouble() - 0.5) }

    ///// This example shows the first 100 elements of the random walk.
    //let first100ValuesOfRandomWalk = 
    //    randomWalk 5.0 
    //    |> Seq.truncate 100
    //    |> Seq.toList

    //printfn "First 100 elements of a random walk: %A" first100ValuesOfRandomWalk

    /// Computes the greatest common factor of two integers.
    ///
    /// Since all of the recursive calls are tail calls,
    /// the compiler will turn the function into a loop,
    /// which improves performance and reduces memory consumption.
    let rec greatestCommonFactor a b =
        if a = 0 then b
        elif a < b then greatestCommonFactor a (b - a)
        else greatestCommonFactor (a - b) b

    printfn "The Greatest Common Factor of 300 and 620 is %d" (greatestCommonFactor 620 300)

    
    /// You can also use the shorthand function construct for pattern matching, 
    /// which is useful when you're writing functions which make use of Partial Application.
    let parseHelper (f: string -> bool * 'T) = f >> function
        | (true, item) -> Some item
        | (false, _) -> None
    
    let parseDateTimeOffset = parseHelper DateTimeOffset.TryParse
    
    let result = parseDateTimeOffset "1970-01-01"
    match result with
    | Some dto -> printfn "It parsed!"
    | None -> printfn "It didn't parse!"
    
    // Define some more functions which parse with the helper function.
    let parseInt = parseHelper Int32.TryParse
    let resultInt = parseInt "1234f"
    match resultInt with
    | Some dto -> printfn "It parsed!"
    | None -> printfn "It didn't parse!"

    let parseDouble = parseHelper Double.TryParse

    let parseTimeSpan = parseHelper TimeSpan.TryParse

    /// Tuples are normally objects, but they can also be represented as structs.
    ///
    /// These interoperate completely with structs in C# and Visual Basic.NET; however,
    /// struct tuples are not implicitly convertible with object tuples (often called reference tuples).
    ///
    /// The second line below will fail to compile because of this.  Uncomment it to see what happens.
    let sampleStructTuple = struct (1, 2)
    //let thisWillNotCompile: (int*int) = struct (1, 2)

    // Although you can
    let convertFromStructTuple (struct(a, b)) = (a, b)
    let convertToStructTuple (a, b) = struct(a, b)

    printfn "Struct Tuple: %A\nReference tuple made from the Struct Tuple: %A" sampleStructTuple (sampleStructTuple |> convertFromStructTuple)

    printfn "fibo(8) = %i" (fibonacci 8)
    0 // return an integer exit code
