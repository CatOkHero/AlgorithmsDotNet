namespace ThirtyDaysOfCode

open System

module TwentyFifthDayOfCode = 
    let isPrime n = 
        match n with 
        | x when x = 1 -> false
        | _ when n > 3 && (n % 2 = 0 || n % 3 = 0) -> false
        | _ -> 
            let maxDiv = int(System.Math.Sqrt((float n))) + 1
            let rec loop number index =
                if number > maxDiv then
                    true
                else
                    if n % number = 0 then
                        false
                    else 
                        loop (number + index) (6 - index)
            loop 5 2

    let mainf = 
        let n = Console.ReadLine() |> int
        
        [1..n]
        |> List.map (fun el -> (isPrime (Console.ReadLine() |> int)))
        |> List.iter (fun el -> printfn "%s" (if el then "Prime" else "Not prime"))
