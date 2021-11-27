open FuncyDown.Element
open FuncyDown.Document
open System.IO

[<EntryPoint>]
let main _argv =

    let badges =
        """
[![license](https://img.shields.io/github/license/GDATASoftwareAG/FuncyDown.svg)](https://raw.githubusercontent.com/GDATASoftwareAG/FuncyDown/master/LICENSE)
[![NuGet](https://img.shields.io/nuget/v/FuncyDown.svg)](https://www.nuget.org/packages/FuncyDown/)
[![NuGet](https://img.shields.io/nuget/dt/FuncyDown.svg)](https://www.nuget.org/packages/FuncyDown/)
[![Build](https://img.shields.io/azure-devops/build/gdatasoftware/FuncyDown/4.svg)](https://dev.azure.com/gdatasoftware/FuncyDown/_build?definitionId=4)
[![Test](https://img.shields.io/azure-devops/tests/gdatasoftware/FuncyDown/4.svg)](https://dev.azure.com/gdatasoftware/FuncyDown/_build?definitionId=4)
        """

    let headerCode =
        """
open FuncyDown.Element
open FuncyDown.Document

emptyDocument
|> addH1 "Header size 1"
|> addH2 "Header size 2"
|> addH3 "Header size 3"
|> addH4 "Header size 4"
|> addH5 "Header size 5"
|> addH6 "Header size 6"
|> addHeader H3 "Header of specific size (example 3)"
        """

    let textCode = 
        """
emptyDocument
|> addParagraph "Text to put into an paragraph." 
|> addEmphasis "Text to emphasize (italic)."
|> addStrongEmphasis "Text to strongly emphasize (bold)"
|> addStrikeThrough "Text to strike through."
        """

    let tableCode =
        """
let headers = ["Header 1"; "Header 2"; "Header 3"]
let rows =
    [
        ["Content"; "Content"; "Content"]
        ["Content"; "Content"; "Content"]
        ["Content"; "Content"; "Content"]
    ]
           
        
emptyDocument
|> addTable headers rows
        """

    let listCode =
        """
let items = 
    [
        {Text = "Level 0 item."; Intend = 0}
        {Text = "Level 1 item."; Intend = 1}
        {Text = "Level 2 item."; Intend = 2}
        {Text = "Level 0 item."; Intend = 0}
    ]

emptyDocument 
|> addUnorderedList items
|> addOrderedList items
        """

    let linkImageCode =
        """
emptyDocument
|> addLink {Text = "Some link text"; Target = "https://.../index.html"; Title = Some("Optional title")}
|> addImage {AltText = "Some link text"; Target = "https://.../image.png"; Title = Some("Optional title")}
        """

    let codeCode =
        """
emptyDocument
|> addInlineCode {Code = "Inline code"; Language = None}
|> addBlockCode {Code = "Inline code"; Language = Some("fsharp")}
        """

    let blockQuoteCode =
        """
emptyDocument
|> addBlockQuote "Text to quote."
        """

    let horRuleCode =
        """
emptyDocument
|> addHorizontalRule
        """

    let asStringCode =
        """
...
markdownDocument |> asString
        """

    let mdDoc = 
        emptyDocument
        |> addImage {Target = "https://github.com/GDATASoftwareAG/FuncyDown/blob/master/resource/linkedin_banner_image_1.png?raw=true"; Title = Some("Markdown - FuncyDown"); AltText = "FuncyDown Logo"}
        |> addNewline
        |> addParagraph badges
        |> addParagraph "FuncyDown is a very simple library to create Markdown files written in F#. The readme you are currently reading is generated with FuncyDown."
        |> addH2 "How to use"
        |> addParagraph "These examples show how to use FuncyDown in your application to create a Markdown file."
        |> addH3 "Headers"
        |> addParagraph "You can easily add headers of different size to your Markdown document."
        |> addBlockCode {Code = headerCode; Language = Some("fsharp")}
        |> addH3 "Working with text"
        |> addParagraph "There are several option to work with text."
        |> addBlockCode {Code = textCode; Language = Some("fsharp")}
        |> addH3 "Tables"
        |> addParagraph "Adding a table is also very easy."
        |> addBlockCode {Code = tableCode; Language = Some("fsharp")}
        |> addH3 "Lists"
        |> addParagraph "You can create ordered and unordered list with sub-items."
        |> addBlockCode {Code = listCode; Language = Some("fsharp")}
        |> addH3 "Links and Images"
        |> addParagraph "You can add a link to an internal or external reference and to images which will be displayed in the Markdown document."
        |> addBlockCode {Code = linkImageCode; Language = Some("fsharp")}
        |> addH3 "Code"
        |> addParagraph "To add code, you have two option. Either as in-line code or as a code block."
        |> addBlockCode {Code = codeCode; Language = Some("fsharp")}
        |> addH3 "Block Quote"
        |> addParagraph "Sometimes it's useful to have a block quote to highlight some text or quote a source."
        |> addBlockCode {Code = blockQuoteCode; Language = Some("fsharp")}
        |> addH3 "Horizontal Rule"
        |> addParagraph "To add a simple horizontal rule use the code below."
        |> addBlockCode {Code = horRuleCode; Language = Some("fsharp")}
        |> addH3 "Export to string"
        |> addParagraph "To save the generated Markdown document on disk or use it otherwise, you can export the document to a formatted Markdown string."
        |> addBlockCode {Code = asStringCode; Language = Some("fsharp")}

    File.WriteAllText("../../../../../README.md", mdDoc |> asString)
    0 // return an integer exit code
