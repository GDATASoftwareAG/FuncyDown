module Text

open Xunit
open FsUnit.Xunit
open FuncyDown.Element
open FuncyDown.Document
open System

let text = "Hello I'm a text"

[<Fact>]
let ``addParagraph appends a given paragraph to the document`` () =
    let expected = 
        {
            Elements = [Paragraph(text)]
        }

    let actual = addParagraph text emptyDocument

    actual |> should equal expected

[<Fact>]
let ``asString returns a formatted paragraph given a string`` () =
    let expected = sprintf "%s%s%s" text Environment.NewLine Environment.NewLine
    let document = addParagraph text emptyDocument
    
    let actual = document |> asString

    actual |> should equal expected

[<Fact>]
let ``addText appends a given text to the document`` () =
    let expected = 
        {
            Elements = [Text(text)]
        }

    let actual = addText text emptyDocument

    actual |> should equal expected

[<Fact>]
let ``asString returns a formatted text given a string`` () =
    let expected = text
    let document = addText text emptyDocument
    
    let actual = document |> asString

    actual |> should equal expected

[<Fact>]
let ``addEmphasis appends a given string with emphasis to the document`` () =
    let expected = 
        {
            Elements = [Emphasis(text)]
        }

    let actual = addEmphasis text emptyDocument

    actual |> should equal expected

[<Fact>]
let ``asString returns a formatted text given an emphasis`` () =
    let expected = "*" + text + "*"
    let document = addEmphasis text emptyDocument
    
    let actual = document |> asString

    actual |> should equal expected

[<Fact>]
let ``addStrongEmphasis appends a given string with strong emphasis to the document`` () =
    let expected = 
        {
            Elements = [StrongEmphasis(text)]
        }

    let actual = addStrongEmphasis text emptyDocument

    actual |> should equal expected

[<Fact>]
let ``asString returns a formatted text given a strong emphasis`` () =
    let expected = "**" + text + "**"
    let document = addStrongEmphasis text emptyDocument
    
    let actual = document |> asString

    actual |> should equal expected

[<Fact>]
let ``addStrikeThrough appends a given string stroken through to the document`` () =
    let expected = 
        {
            Elements = [StrikeThrough(text)]
        }

    let actual = addStrikeThrough text emptyDocument

    actual |> should equal expected

[<Fact>]
let ``asString returns a formatted text given a strike through string`` () =
    let expected = "~~" + text + "~~"
    let document = addStrikeThrough text emptyDocument
    
    let actual = document |> asString

    actual |> should equal expected