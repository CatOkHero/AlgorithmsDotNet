module Recursion

// fibonacci
let rec fibonacci = function
    | 0 | 1 -> 1
    | x -> fibonacci(x - 1) + fibonacci(x - 2)

let pow x n = 
    let rec powrec x n =  
        if n = 0 then 1
        else 
            let nDiv2 = n / 2
            let ret = powrec x nDiv2
            if n % 2 = 0 then ret * ret
            else ret * ret * x

    if n = 0 then 1
    elif n = 1 then x
    elif n > 0 then powrec x n
    else 1 / powrec x n

type treenode =
    {
        left : treenode;
        right : treenode;
        value : int;
    }

let rec maxdepth (x : treenode) = 
    let left = maxdepth x.left
    let right = maxdepth x.right
    max (left + 1) (right + 1)

let f n =
    for i = 1 to n do
        printfn "Hello World"