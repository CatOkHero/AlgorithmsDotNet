import Foundation

// https://www.hackerrank.com/challenges/apple-and-orange/problem

/*
 * Complete the 'countApplesAndOranges' function below.
 *
 * The function accepts following parameters:
 *  1. INTEGER s
 *  2. INTEGER t
 *  3. INTEGER a
 *  4. INTEGER b
 *  5. INTEGER_ARRAY apples
 *  6. INTEGER_ARRAY oranges
 */

func countApplesAndOranges(s: Int, t: Int, a: Int, b: Int, apples: [Int], oranges: [Int]) -> Void {
    // Write your code here
    var applesInRange = 0
    for apple in apples {
        let appleDistance = apple + a
        if (appleDistance >= s && appleDistance <= t) {
            applesInRange += 1
        }
    }

    var orangesInRange = 0
    for orange in oranges {
        let orangeDistance = orange + b
        if (orangeDistance >= s && orangeDistance <= t) {
            orangesInRange += 1
        }
    }
    
    print(applesInRange)
    print(orangesInRange)   
}

guard let firstMultipleInputTemp = readLine()?.replacingOccurrences(of: "\\s+$", with: "", options: .regularExpression) else { fatalError("Bad input") }
let firstMultipleInput = firstMultipleInputTemp.split(separator: " ").map{ String($0) }

guard let s = Int(firstMultipleInput[0])
else { fatalError("Bad input") }

guard let t = Int(firstMultipleInput[1])
else { fatalError("Bad input") }

guard let secondMultipleInputTemp = readLine()?.replacingOccurrences(of: "\\s+$", with: "", options: .regularExpression) else { fatalError("Bad input") }
let secondMultipleInput = secondMultipleInputTemp.split(separator: " ").map{ String($0) }

guard let a = Int(secondMultipleInput[0])
else { fatalError("Bad input") }

guard let b = Int(secondMultipleInput[1])
else { fatalError("Bad input") }

guard let thirdMultipleInputTemp = readLine()?.replacingOccurrences(of: "\\s+$", with: "", options: .regularExpression) else { fatalError("Bad input") }
let thirdMultipleInput = thirdMultipleInputTemp.split(separator: " ").map{ String($0) }

guard let m = Int(thirdMultipleInput[0])
else { fatalError("Bad input") }

guard let n = Int(thirdMultipleInput[1])
else { fatalError("Bad input") }

guard let applesTemp = readLine()?.replacingOccurrences(of: "\\s+$", with: "", options: .regularExpression) else { fatalError("Bad input") }

let apples: [Int] = applesTemp.split(separator: " ").map {
    if let applesItem = Int($0) {
        return applesItem
    } else { fatalError("Bad input") }
}

guard apples.count == m else { fatalError("Bad input") }

guard let orangesTemp = readLine()?.replacingOccurrences(of: "\\s+$", with: "", options: .regularExpression) else { fatalError("Bad input") }

let oranges: [Int] = orangesTemp.split(separator: " ").map {
    if let orangesItem = Int($0) {
        return orangesItem
    } else { fatalError("Bad input") }
}

guard oranges.count == n else { fatalError("Bad input") }

countApplesAndOranges(s: s, t: t, a: a, b: b, apples: apples, oranges: oranges)
