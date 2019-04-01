module List

open Xunit
open FsUnit.Xunit
open FuncyDown.Element
open FuncyDown.Document
open System.Text

let listElements = [
    {Text = "List Level 0"; Intend = 0}
    {Text = "List Level 1"; Intend = 1}
    {Text = "List Level 2"; Intend = 2}
    {Text = "List Level 0"; Intend = 0}
    ]

[<Fact>]
let ``addOrderedList appends a given list to the document`` () =
    let expected = 
        {
            Elements = [
                OrderedList(listElements)]
        }

    let actual = addOrderedList listElements emptyDocument

    actual |> should equal expected

[<Fact>]
let ``asString returns a formatted ordered list given an ordered list`` () =
    let document = addOrderedList listElements emptyDocument
    let sb = new StringBuilder()
    sb.AppendLine("1. List Level 0") |> ignore
    sb.AppendLine("\t2. List Level 1") |> ignore
    sb.AppendLine("\t\t3. List Level 2") |> ignore
    sb.AppendLine("4. List Level 0") |> ignore
    let expected = sb.ToString()

    let actual = document |> asString
    

    actual |> should equal expected

[<Fact>]
let ``addUnorderedList appends a given list to the document`` () =
    let expected = 
        {
            Elements = [
                UnorderedList(listElements)]
        }

    let actual = addUnorderedList listElements emptyDocument

    actual |> should equal expected

[<Fact>]
let ``asString returns a formatted unordered list given an unordered list`` () =
    let document = addUnorderedList listElements emptyDocument
    let sb = new StringBuilder()
    sb.AppendLine("* List Level 0") |> ignore
    sb.AppendLine("\t* List Level 1") |> ignore
    sb.AppendLine("\t\t* List Level 2") |> ignore
    sb.AppendLine("* List Level 0") |> ignore
    let expected = sb.ToString()

    let actual = document |> asString

    actual |> should equal expected
