open System

let moves = ["F"; "U"; "R"; "L"; "B"; "D"]
let directions = [ ""; "'"; "2"]

let random = Random(DateTime.Now.Millisecond)

let rec generateMoves lastMove = seq {
        let takeRandom l =
            let length = List.length l
            let i = random.Next(0, length)
            List.item i l

        let move = takeRandom moves
        let direction = takeRandom directions

        if move <> lastMove then yield move + direction
        yield! generateMoves move
    }

[<EntryPoint>]
let main argv =
    let moves = generateMoves "" |> Seq.take 20
    printfn "%s" <| String.Join(" ", moves)
    0
