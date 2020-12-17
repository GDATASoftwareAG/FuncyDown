module HorizontalRule

open Xunit
open FsUnit.Xunit
open FuncyDown.Element
open FuncyDown.Document
open System

[<Fact>]
let ``addHorizontalRule appends a horizontal rule to the document`` () =
    let expected = 
        {
            Elements = [HorizontalRule]
        }

    let actual = addHorizontalRule emptyDocument

    actual |> should equal expected

[<Fact>]
let ``asString returns a formatted horizontal rule.`` () =
    let expected = sprintf $"---{Environment.NewLine}" 
    let document = addHorizontalRule emptyDocument
    
    let actual = document |> asString

    actual |> should equal expected



