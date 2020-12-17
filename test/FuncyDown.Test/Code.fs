module Code

open Xunit
open FsUnit.Xunit
open FuncyDown.Element
open FuncyDown.Document
open System

let code = {Code = "Some code"; Language = Some("language"); }

[<Fact>]
let ``addInlineCode appends a given inline code to the document`` () =
    let expected = 
        {
            Elements = [InlineCode(code)]
        }

    let actual = addInlineCode code emptyDocument

    actual |> should equal expected

[<Fact>]
let ``asString returns a formatted inline code given some inline code`` () =
    let expected = "`Some code`"
    let document = addInlineCode code emptyDocument
    
    let actual = document |> asString

    actual |> should equal expected

[<Fact>]
let ``addBlockCode appends a given code block to the document`` () =
    let expected = 
        {
            Elements = [BlockCode(code)]
        }

    let actual = addBlockCode code emptyDocument

    actual |> should equal expected

[<Fact>]
let ``asString returns a formatted code block given some code block`` () =
    let expected = sprintf $"```language{Environment.NewLine}Some code{Environment.NewLine}```{Environment.NewLine}"   
    let document = addBlockCode code emptyDocument
    
    let actual = document |> asString

    actual |> should equal expected