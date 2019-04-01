module Links

open Xunit
open FsUnit.Xunit
open FuncyDown.Element
open FuncyDown.Document

let link = {Text = "Link text"; Target = "https://link.org"; Title = Some("Title text")}

[<Fact>]
let ``addLink appends a given link to the document`` () =
    let expected = 
        {
            Elements = [Link(link)]
        }

    let actual = addLink link emptyDocument

    actual |> should equal expected

[<Fact>]
let ``asString returns a formatted link given a link`` () =
    let expected = "[Link text](https://link.org \"Title text\")"
    let document = addLink link emptyDocument
    
    let actual = document |> asString

    actual |> should equal expected