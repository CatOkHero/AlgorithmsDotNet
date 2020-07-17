module Recursion

let rec fibonacci = function
    | 0 | 1 -> 1
    | x -> fibonacci(x - 1) + fibonacci(x - 2)


