namespace Chapters

module LinkedListProblems =
    type ListNode<'T> = 
        | Leaf 
        | Node of value: 'T * Next: ListNode<'T>
    
    let findNode ls value =
        let rec findRec ls value =
            match ls with 
            | ListNode.Leaf -> ListNode.Leaf
            | ListNode.Node (nodeValue, next) as node ->
                if nodeValue <> value then 
                    findRec next value
                else 
                    node
        findRec ls value

    let createNode = 
        ListNode.Node(1, ListNode.Node(2, ListNode.Leaf))

    let mainf = 
        let node = createNode
        printfn "%A" node

        printfn "%A" (findNode node 2)