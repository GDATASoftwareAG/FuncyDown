namespace FuncyDown

open Element
open System.Text
open System

module Document =

    type Document =
        {
            Elements: Element list
        }

    let emptyDocument = {Elements = []}

    let append element document =
        {document with Elements = (List.append document.Elements [element]) }

    let asString document =
        let sb = StringBuilder()

        let elementAsString (sb: StringBuilder) element =
            sb.Append(asString element)

        let rec elementsAsOneString (sb: StringBuilder) elements =
            match elements with
            | [] -> sb.ToString()
            | [_] -> sb.Append(asString elements.[0]).ToString()
            | head::tail -> elementsAsOneString (elementAsString sb head) tail

        elementsAsOneString sb document.Elements

    let addHeader header text document =
        let header = Header({Size = header; Text = text})
        append header document

    let addH1 text document =
        addHeader H1 text document

    let addH2 text document =
        addHeader H2 text document
        
    let addH3 text document =
        addHeader H3 text document

    let addH4 text document =
        addHeader H4 text document

    let addH5 text document =
        addHeader H5 text document

    let addH6 text document =
        addHeader H6 text document

    let addTable headers rows document =
        let table = Table({Headers = headers; Rows = rows})
        append table document

    let addParagraph paragraph document =
        let p = Paragraph(paragraph)
        append p document
    
    let addText text document =
        let t = Text(text)
        append t document

    let addEmphasis text document =
        let e = Emphasis(text)
        append e document

    let addStrongEmphasis text document =
        let e = StrongEmphasis(text)
        append e document

    let addStrikeThrough text document =
        let s = StrikeThrough(text)
        append s document

    let addOrderedList items document =
        let l = OrderedList(items)
        append l document

    let addUnorderedList items document =
        let l = UnorderedList(items)
        append l document

    let addLink link document =
        let l = Link(link)
        append l document

    let addImage image document =
        let i = Image(image)
        append i document

    let addInlineCode code document =
        let c = InlineCode(code)
        append c document

    let addBlockCode code document =
        let c = BlockCode(code)
        append c document

    let addBlockQuote quote document =
        let c = BlockQuote(quote)
        append c document

    let addHorizontalRule document =
        append HorizontalRule document

    let addNewline document =
        let nl = Text(Environment.NewLine)
        append nl document