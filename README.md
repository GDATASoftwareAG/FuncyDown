# FuncyDown

FuncyDown is a very simple library to create Markdown files written in F#. The readme you currently read is generated with FuncyDown.

## How to use

These examples show how to use FuncyDown in your application to create a Markdown file.

### Headers

You can easily add headers of different size to your Markdown document.

```fsharp

emptyDocument
|> addH1 "Header size 1"
|> addH2 "Header size 2"
|> addH3 "Header size 3"
|> addH4 "Header size 4"
|> addH5 "Header size 5"
|> addH6 "Header size 6"
|> addHeader 3 "Header of specific size (example 3)"
        
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
### Export to string

To save the generated Markdown document on disk or use it otherwise, you can export the document to a formatted Markdown string.

```fsharp

...
markdownDocument |> asString
        
```
