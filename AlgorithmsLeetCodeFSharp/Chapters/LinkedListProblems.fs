module LinkedListProblems

type ListNode<'T> = 
    | Empty 
    | Val of value: 'T * Next: ListNode<'T>

let rec removeListNode ls value =
    match ls with 
    | Empty -> Empty
    | Val (nodeValue, next) as node ->
        if nodeValue = value then node
        else removeListNode next value

