![FuncyDown Logo](https://github.com/GDATASoftwareAG/FuncyDown/blob/master/resource/linkedin_banner_image_1.png?raw=true "Markdown - FuncyDown")

[![license](https://img.shields.io/github/license/GDATASoftwareAG/FuncyDown.svg)](https://raw.githubusercontent.com/GDATASoftwareAG/FuncyDown/master/LICENSE)
[![NuGet](https://img.shields.io/nuget/v/FuncyDown.svg)](https://www.nuget.org/packages/FuncyDown/)
[![NuGet](https://img.shields.io/nuget/dt/FuncyDown.svg)](https://www.nuget.org/packages/FuncyDown/)
[![Build](https://img.shields.io/azure-devops/build/gdatasoftware/FuncyDown/4.svg)](https://dev.azure.com/gdatasoftware/FuncyDown/_build?definitionId=4)
[![Test](https://img.shields.io/azure-devops/tests/gdatasoftware/FuncyDown/4.svg)](https://dev.azure.com/gdatasoftware/FuncyDown/_build?definitionId=4)
        

FuncyDown is a very simple library to create Markdown files written in F#. The readme you are currently reading is generated with FuncyDown.

## How to use

These examples show how to use FuncyDown in your application to create a Markdown file.

### Headers

You can easily add headers of different size to your Markdown document.

```fsharp

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
        
```
### Working with text

There are several option to work with text.

```fsharp

emptyDocument
|> addParagraph "Text to put into an paragraph." 
|> addEmphasis "Text to emphasize (italic)."
|> addStrongEmphasis "Text to strongly emphasize (bold)"
|> addStrikeThrough "Text to strike through."
        
```
### Tables

Adding a table is also very easy.

```fsharp

let headers = ["Header 1"; "Header 2"; "Header 3"]
let rows =
    [
        ["Content"; "Content"; "Content"]
        ["Content"; "Content"; "Content"]
        ["Content"; "Content"; "Content"]
    ]
           
        
emptyDocument
|> addTable headers rows
        
```
### Lists

You can create ordered and unordered list with sub-items.

```fsharp

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
        
```
### Links and Images

You can add a link to an internal or external reference and to images which will be displayed in the Markdown document.

```fsharp

emptyDocument
|> addLink {Text = "Some link text"; Target = "https://.../index.html"; Title = Some("Optional title")}
|> addImage {AltText = "Some link text"; Target = "https://.../image.png"; Title = Some("Optional title")}
        
```
### Code

To add code, you have two option. Either as in-line code or as a code block.

```fsharp

emptyDocument
|> addInlineCode {Code = "Inline code"; Language = None}
|> addBlockCode {Code = "Inline code"; Language = Some("fsharp")}
        
```
### Block Quote

Sometimes it's useful to have a block quote to highlight some text or quote a source.

```fsharp

emptyDocument
|> addBlockQuote "Text to quote."
        
```
### Horizontal Rule

To add a simple horizontal rule use the code below.

```fsharp

emptyDocument
|> addHorizontalRule
        
```
### Create Document from elements

As an alternative to the pipe operator, the `toDoc` function can be used to construct a Markdown document.

```fsharp

let document = Document.toDoc [
    addH1 "FuncyDown is fancy!"
    addParagraph "Lemonade was a popular drink, and it still is!"
]
        
```
### Render Document

The render function writes directly to a Markdown string.

```fsharp

let markdown = Document.render [
  addH1 "FuncyDown is fancy!"
  addParagraph "Lemonade was a popular drink, and it still is!"
]
        
```
### Export to string

To save the generated Markdown document on disk or use it otherwise, you can export the document to a formatted Markdown string.

```fsharp

...
markdownDocument |> asString
        
```
