namespace FunctionalProgramming

open System

module MemoizationAndDp =
    // TODO: Need to fix it
    let perntagonalAndDp () =
        let numberOfItems = Console.ReadLine() |> int
        let mutable memoization = Map.empty

        Seq.init numberOfItems (fun i -> i)
        |> Seq.iter
            (fun elem ->
                let n = Console.ReadLine() |> int64

                match n with
                | 1L -> printfn "%i" 1
                | 2L -> printfn "%i" 5
                | n ->
                    let smallMultiplier = n - 3L
                    let biggerMultiplier = n - 2L

                    let rec getSum (n: int64) (sum: int64) =
                        if memoization.ContainsKey n then memoization.[n]
                        else
                            if n = 0L then
                                memoization <- memoization.Add(n, sum)
                                sum
                            elif n = 1L then
                                let sum = sum + 3L
                                memoization <- memoization.Add(n, sum)
                                sum
                            else
                                let newN = n - 1L
                                let newSum = sum + n * 3L
                                getSum newN newSum

                    let sum = getSum smallMultiplier 0L
                    let sum = sum + 7L * biggerMultiplier + 5L
                    printfn "%i" sum)

    let fibonacciRun () =    
        let mutable memo = Map.empty
        let rec fibonacci n sum = 
            if memo.ContainsKey n then
                memo.[n]
            else
                match n with
                | 0 ->
                    memo <- memo.Add(n, 0)
                    sum
                | 1 ->
                    memo <- memo.Add(n, 1)
                    sum + 1
                | n ->
                    let n2 =(fibonacci (n-2) sum) |> (fun x -> x % (( Math.Pow(10., 8.) + 7. ) |> int))
                    memo <- memo.Add((n - 2), n2)
                    let n1 = fibonacci (n-1) sum |> (fun x -> x % (( Math.Pow(10., 8.) + 7. ) |> int))
                    memo <- memo.Add((n - 1), n1)
                    let sum = n1 + n2 |> (fun x -> x % (( Math.Pow(10., 8.) + 7. ) |> int))
                    memo <- memo.Add(n, sum)
                    sum
        
    
        let n = Console.ReadLine() |> int
        Seq.init n (fun i -> i)
        |> Seq.iter (fun i ->
            let fib = Console.ReadLine() |> int
            let sum = fibonacci fib 0
            Console.WriteLine(sum)
            )