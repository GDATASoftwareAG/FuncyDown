module Image

open Xunit
open FsUnit.Xunit
open FuncyDown.Element
open FuncyDown.Document

let image = {AltText = "Alternative text"; Target = "https://image.org/foo.png"; Title = Some("Title text")}

[<Fact>]
let ``addImage appends a given image link to the document`` () =
    let expected = 
        {
            Elements = [Image(image)]
        }

    let actual = addImage image emptyDocument

    actual |> should equal expected

[<Fact>]
let ``asString returns a formatted image link given an image link`` () =
    let expected = "![Alternative text](https://image.org/foo.png \"Title text\")"
    let document = addImage image emptyDocument
    
    let actual = document |> asString

    actual |> should equal expected