namespace FuncyDown
open System.Text
open System

module Element =
    type HeaderSize = | H1 | H2 | H3 | H4 | H5 | H6
    type Header = { Size: HeaderSize; Text: string }
    type Row = string list
    type Table = { Headers: string list; Rows: Row list }
    type Paragraph = string
    type Text = string
    type Emphasis = string
    type StrongEmphasis = string
    type StrikeThrough = string
    type ListItem = { Text: string; Intend: int }
    type OrderedList = ListItem list
    type UnorderedList = ListItem list
    type Link = {Text: string; Target: string; Title: string option}
    type Image = {AltText: string; Target: string; Title: string option}
    type Code = {Code: string; Language: string option}

    type Element =
        | Header of Header
        | Table of Table
        | Paragraph of Paragraph
        | Text of Text
        | Emphasis of Emphasis
        | StrongEmphasis of StrongEmphasis
        | StrikeThrough of StrikeThrough
        | OrderedList of OrderedList
        | UnorderedList of UnorderedList
        | Link of Link
        | Image of Image
        | InlineCode of Code
        | BlockCode of Code
        | BlockQuote of Text
        | HorizontalRule

    let headerAsString header =
        let textWithNewLines text =
            sprintf "%s%s%s" text Environment.NewLine Environment.NewLine

        match header.Size with
        | H1 -> sprintf "# %s" (textWithNewLines header.Text)
        | H2 -> sprintf "## %s" (textWithNewLines header.Text)
        | H3 -> sprintf "### %s" (textWithNewLines header.Text)
        | H4 -> sprintf "#### %s" (textWithNewLines header.Text)
        | H5 -> sprintf "##### %s" (textWithNewLines header.Text)
        | H6 -> sprintf "###### %s" (textWithNewLines header.Text)

    let tableAsString table =
        let sb = new StringBuilder()
        let formatRow columns = "|" + String.concat "|" columns + "|"
        let header = formatRow table.Headers
        let separator = formatRow (List.init table.Headers.Length (fun _ -> "---"))
        let rows = table.Rows |> List.map (fun row -> formatRow row)

        sb.AppendLine(header) |> ignore
        sb.AppendLine(separator) |> ignore
        rows |> List.iter (fun row -> sb.AppendLine(row) |> ignore)
        
        sb.ToString()

    let paragraphAsString paragraph =
        sprintf "%s%s%s" paragraph Environment.NewLine Environment.NewLine

    let emphasisAsString emphasis =
        sprintf "*%s*" emphasis

    let strongEmphasisAsString emphasis =
        sprintf "**%s**" emphasis

    let strikeThroughAsString strikeThrough =
        sprintf "~~%s~~" strikeThrough

    let listAsString list preGen =
        let rec createList items cnt (sb: StringBuilder) =
            let appendItem item prefix (sb: StringBuilder) =
                let intends = String.concat "" (List.init item.Intend (fun _ -> "\t"))
                sb.AppendLine(intends + prefix + item.Text)

            match items with 
            | [] -> sb
            | head::tail -> createList tail (cnt + 1) (appendItem head (preGen cnt) sb)

        let sb = new StringBuilder()
        let sbList = createList list 1 sb
        sbList.ToString()

    let orderedListAsString orderedList =
        let preGen cnt = string cnt + ". "
        listAsString orderedList preGen

    let unorderedListAsString unorderedList =
        let preGen _ = "* "
        listAsString unorderedList preGen

    let linkAsString (link: Link) =
        match link.Title with
        | None -> sprintf "[%s](%s)" link.Text link.Target
        | Some title -> sprintf "[%s](%s \"%s\")" link.Text link.Target title

    let imageAsString (image: Image) =
        match image.Title with
        | None -> sprintf "![%s](%s)" image.AltText image.Target
        | Some title -> sprintf "![%s](%s \"%s\")" image.AltText image.Target title
        
    let inlineCodeAsString code =
        sprintf "`%s`" code.Code

    let blockCodeAsString code =
        match code.Language with
        | None -> sprintf "```%s%s%s```%s" Environment.NewLine code.Code Environment.NewLine Environment.NewLine
        | Some lang -> sprintf "```%s%s%s%s```%s" lang Environment.NewLine code.Code Environment.NewLine Environment.NewLine

    let blockQuoteAsString quote =
        sprintf "> %s" quote

    let horizontalRuleAsString =
        sprintf "---%s" Environment.NewLine

    let asString element =
        match element with
        | Header h -> headerAsString h
        | Table t -> tableAsString t
        | Paragraph p -> paragraphAsString p
        | Text t -> t
        | Emphasis e -> emphasisAsString e
        | StrongEmphasis s -> strongEmphasisAsString s
        | StrikeThrough s -> strikeThroughAsString s
        | OrderedList l -> orderedListAsString l
        | UnorderedList l -> unorderedListAsString l
        | Link l -> linkAsString l
        | Image i -> imageAsString i
        | InlineCode i -> inlineCodeAsString i
        | BlockCode b -> blockCodeAsString b
        | BlockQuote b -> blockQuoteAsString b
        | HorizontalRule -> horizontalRuleAsString

