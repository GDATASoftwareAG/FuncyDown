module Table

open Xunit
open FsUnit.Xunit
open FuncyDown.Element
open FuncyDown.Document
open System.Text

let headers = ["Header1"; "Header2"]
let rows = 
    [
        ["R1C1"; "R1C2"]
        ["R2C1"; "R2C2"]
    ]

[<Fact>]
let ``addTable appends table with headers and rows to document``() =
    let document = emptyDocument
    let expected = 
        {
            Elements = [Table({Headers = headers; Rows = rows})]
        }

    let actual = document |> addTable headers rows

    actual |> should equal expected

[<Fact>]
let ``asString returns a formatted table given a table with headers and rows``() =
    let document = 
        emptyDocument
        |> addTable headers rows
    let sb = new StringBuilder()
    sb.AppendLine("|Header1|Header2|") |> ignore
    sb.AppendLine("|---|---|") |> ignore
    sb.AppendLine("|R1C1|R1C2|") |> ignore
    sb.AppendLine("|R2C1|R2C2|") |> ignore
    let expected = sb.ToString()

    let actual = document |> asString

    actual |> should equal expected