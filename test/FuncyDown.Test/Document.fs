module DocumentTest

open Xunit
open FsUnit.Xunit
open FuncyDown.Element
open FuncyDown.Document
open System

[<Fact>]
let ``toDoc combines multiple elements to a document`` () =
    let expected =
        {
            Elements = [
                Header { Size = H1; Text = "Header"}
                Paragraph("Paragraph")
                ]
        }

    
    let actual = FuncyDown.Document.toDoc [
        addH1 "Header"
        addParagraph "Paragraph"
    ]

    actual |> should equal expected

[<Fact>]
let ``render creates a string from elements`` () =
    let expected = 
        """# Header

Paragraph

"""

    
    let actual = FuncyDown.Document.render [
        addH1 "Header"
        addParagraph "Paragraph"
    ]

    actual |> should equal expected

    