namespace ThirtyDaysOfCode

module TwentySixthDayOfCode = 
    let n = (stdout |> string).Split(" ")
    let dayOfReturned = int(n.[0])
    let monthOfReturned = int(n.[1])
    let yearOfReturned = int(n.[2])

    let y = (stdout |> string).Split(" ")
    let dayOfReturn = int(y.[0])
    let monthOfReturn = int(y.[1])
    let yearOfReturn = int(y.[2])

    let mainf = 
     // beee
     match yearOfReturn <= yearOfReturned with
     | false -> printf "%i" 100000
     | true -> 
        if yearOfReturned < yearOfReturn then 
         printf "%i" 0
        else
         match monthOfReturn <= monthOfReturned with
         | false -> printf "%i" (500 * (monthOfReturned - monthOfReturn))
         | true ->
            if monthOfReturned < monthOfReturn then 
             printf "%i" 0
            else
             match dayOfReturn <= dayOfReturned with
             | false -> printf "%i" (15 * (dayOfReturned - dayOfReturn))
             | true -> printf "%i" 0