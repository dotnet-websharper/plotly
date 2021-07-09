namespace WebSharper.Plotly.Extension.GenerateEnum

module GenerateOptions =

    let rec putEverywhereInAList (word:string) (words:string list) (result:string list list) (index:int) =
        if index = words.Length+1
        then result@[words]
        else 
            let mutable listBefore = []
            let mutable listAfter = []
            for i in 0..(words.Length-1) do
                if i < index
                then listBefore <- listBefore@[words.[i]]
                else listAfter <- listAfter@[words.[i]]
            putEverywhereInAList word words (result@[(listBefore @ [word] @ listAfter)]) (index+1)   

    let rec putEverywhere (word:string) (words:string list list) (result:string list list) =
        match words with
        | [] -> result
        | w::ws -> putEverywhere word ws (result@(putEverywhereInAList word w [] 0))

    let rec permutation (words:string list) (result:string list list) =
        match words with
        | [] -> result
        | w::ws -> permutation ws (putEverywhere w result [])

    let rec converter (isolator:char) (result:string) (words:string list) =
        match words with
        | [] -> if result = "" then "" else result
        | w::ws -> 
            if result = ""
            then converter isolator w ws
            else converter isolator (result + isolator.ToString() + w) ws

    // example for usage: let example = allPermutations ["a";"b";"c"] '+'
    let allPermutations (words:string list) (isolator:char) = 
        permutation words [[]]
        |> List.map (fun x -> converter isolator "" x)
        |> List.filter ((<>)"")
        |> Seq.ofList