module BlockQuote

open Xunit
open FsUnit.Xunit
open FuncyDown.Element
open FuncyDown.Document

let quote = "Some quote"

[<Fact>]
let ``addBlockQuote appends a given block quote to the document`` () =
    let expected = 
        {
            Elements = [BlockQuote(quote)]
        }

    let actual = addBlockQuote quote emptyDocument

    actual |> should equal expected

[<Fact>]
let ``asString returns a formatted block quote given a block quote`` () =
    let expected = "> Some quote" + System.Environment.NewLine + System.Environment.NewLine
    let document = addBlockQuote quote emptyDocument
    
    let actual = document |> asString

    actual |> should equal expected

