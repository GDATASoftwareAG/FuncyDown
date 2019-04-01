module Header

open Xunit
open FsUnit.Xunit
open FuncyDown.Element
open FuncyDown.Document
open System

[<Fact>]
let ``addH1 appends H1 header with text to the document`` () =
    let expected = 
        {
            Elements = [Header({Size = H1; Text = "H1 Header"})]
        }
    
    let actual = addH1 "H1 Header" emptyDocument

    actual |> should equal expected

[<Fact>]
let ``addH2 appends H2 header with text to the document`` () =
    let expected = 
        {
            Elements = [Header({Size = H2; Text = "H2 Header"})]
        }
    
    let actual = addH2 "H2 Header" emptyDocument

    actual |> should equal expected

[<Fact>]
let ``addH3 appends H3 header with text to the document`` () =
    let expected = 
        {
            Elements = [Header({Size = H3; Text = "H3 Header"})]
        }
    
    let actual = addH3 "H3 Header" emptyDocument

    actual |> should equal expected

[<Fact>]
let ``addH4 appends H4 header with text to the document`` () =
    let expected = 
        {
            Elements = [Header({Size = H4; Text = "H4 Header"})]
        }
    
    let actual = addH4 "H4 Header" emptyDocument

    actual |> should equal expected


[<Fact>]
let ``addH5 appends H5 header with text to the document`` () =
    let expected = 
        {
            Elements = [Header({Size = H5; Text = "H5 Header"})]
        }
    
    let actual = addH5 "H5 Header" emptyDocument

    actual |> should equal expected

[<Fact>]
let ``addH6 appends H6 header with text to the document`` () =
    let expected = 
        {
            Elements = [Header({Size = H6; Text = "H6 Header"})]
        }
    
    let actual = addH6 "H6 Header" emptyDocument

    actual |> should equal expected

[<Fact>]
let ``asString returns formatted headers given H1-H6`` () =
    let document = 
        emptyDocument
        |> addH1 "H1"
        |> addH2 "H2"
        |> addH3 "H3"
        |> addH4 "H4"
        |> addH5 "H5"
        |> addH6 "H6"
    let expected = 
        let nl = Environment.NewLine
        sprintf "%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s" "# H1" nl nl "## H2" nl nl "### H3" nl nl "#### H4" nl nl "##### H5" nl nl "###### H6" nl nl
        
    let actual = document |> asString

    actual |> should equal expected