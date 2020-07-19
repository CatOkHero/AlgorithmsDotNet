module EasyProblems

let nums = [4, 0, 1, 2, 3]
let index = [4, 0, 1, 2, 3]
let targetList = []

let insertAt index newEl input =
  // For each element, we generate a list of elements that should
  // replace the original one - either singleton list or two elements
  // for the specified index
  input |> List.mapi (fun i el -> if i = index then [newEl; el] else [el])
        |> List.concat

let concatinated = Seq.zip nums index
let target = 
    for n, i in concatinated do
        let resut = insertAt i n targetList
        resut

target