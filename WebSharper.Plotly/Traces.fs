namespace WebSharper.Plotly.Extension.Traces

open WebSharper
open WebSharper.JavaScript
open WebSharper.InterfaceGenerator

module GenerateOptions =
    let rec putEverywhereInAList (word:string) (words:string list) (result:string list list) (index:int) =
        if index = words.Length+1
        then result@[words]
        else 
            let mutable listBefore = []
            let mutable listAfter = []
            for i in 0..(words.Length-1) do
                if i < index
                then listBefore <- listBefore@[words.[i]]
                else listAfter <- listAfter@[words.[i]]
            putEverywhereInAList word words (result@[(listBefore @ [word] @ listAfter)]) (index+1)   

    let rec putEverywhere (word:string) (words:string list list) (result:string list list) =
        match words with
        | [] -> result
        | w::ws -> putEverywhere word ws (result@(putEverywhereInAList word w [] 0))

    let rec permutation (words:string list) (result:string list list) =
        match words with
        | [] -> result
        | w::ws -> permutation ws (putEverywhere w result [])

    let rec converter (isolator:char) (nullValue:string) (result:string) (words:string list) =
        match words with
        | [] -> if result = "" then nullValue else result
        | w::ws -> 
            if result = ""
            then converter isolator nullValue w ws
            else converter isolator nullValue (result + "+" + w) ws

    let allPermutations (words:string list) (isolator:char) (nullValue: string)= 
        permutation words [[]]
        |> List.map (fun x-> converter isolator nullValue "" x)
        |> Seq.ofList

    //TODO: nullvalue is not needed

    let Generate (values: seq<string>, d: char) : seq<string> =
        //TODO
        seq {"TODO"}

module TracesModule =

    let ScatterType = Pattern.EnumStrings "ScatterType" ["scatter"]

    let VisibleString = Pattern.EnumStrings "VisibleString" ["legendonly"]

    let FontConfig =
        Pattern.Config "FontConfig" {
            Required = []
            Optional = [
                "family", T<string>
                "size", T<int>
                //"color", T<>
            ]
        }

    let LegendGroupTitle =
        Pattern.Config "LegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", FontConfig.Type
            ]
        }

    let Modes =
        let generatedEnum =
            let seq1 = (GenerateOptions.Generate(seq{"lines"; "markers"; "text"}, '+'))
            let seq2 = seq{"none"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "Modes" generatedEnum

    let TextPosition =
        Pattern.EnumInlines "TextPosition" [
            "TopLeft", "'top left'"
            "TopCenter", "'top center'"
            "TopRight", "'top right'"
            "MiddleLeft", "'middle left'"
            "MiddleCenter", "'middle center'"
            "MiddleRight", "'middle right'"
            "BottomLeft", "'bottom left'"
            "BottomCenter", "'bottom center'"
            "BottomRight", "'bottom right'"
        ]

    let HoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.Generate(seq{"x"; "y"; "z"; "text"; "name"}, '+'))
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "HoverInfo" generatedEnum

    let Orientation =
        Pattern.EnumStrings "Orientation" [
            "v"
            "h"
        ]

    let GroupNorm =
        Pattern.EnumInlines "GroupNorm" [
            "empty", "''"
            "fraction", "'fraction'"
            "percent", "'percent'"
        ]

    let ScatterOptions =
        Pattern.Config "ScatterOptions" {
            Required = [
                "type", ScatterType.Type
            ]
            Optional = [
                "name", T<string>
                "visible", T<bool> + VisibleString.Type
                "showlegend", T<bool>
                "legendrank", T<int>
                "legendgroup", T<string>
                "legendgrouptitle", LegendGroupTitle.Type
                "opacity", T<float>
                "mode", Modes.Type
                "ids", !| T<string>
                "x", !| T<int>
                "x0", T<int> + T<string>
                "dx", T<int>
                "y", !| T<int>
                "y0", T<int> + T<string>
                "dy", T<int>
                "text", T<string> + !| T<string>
                "textposition", TextPosition.Type
                "texttemplate", T<string> + !| T<string>
                "hovertext", T<string> + !| T<string>
                "hoverinfo", HoverInfo.Type
                "hovertemplate", T<string> + !| T<string>
                "xhoverformat", T<string>
                "yhoverformat", T<string>
                "meta", T<int> + T<string>
                "customdata", T<string> // undefined type, string is placeholder
                "yaxis", T<string> //type is 'subplotid'
                "orientation", Orientation.Type
                "groupnorm", GroupNorm.Type
            ]
        }

    let AltScatterOptions =
        Class "ScatterOptions2"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'scatter'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "showlegend", T<bool>
            "legendrank", T<int>
            "legendgroup", T<string>
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", T<float>
            "mode", Modes.Type
            "ids", !| T<string>
            "x", !| T<int>
            "x0", T<int> + T<string>
            "dx", T<int>
            "y", !| T<int>
            "y0", T<int> + T<string>
            "dy", T<int>
            "text", T<string> + !| T<string>
            "textposition", TextPosition.Type
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", HoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", T<int> + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "yaxis", T<string> //type is 'subplotid'
            "orientation", Orientation.Type
            "groupnorm", GroupNorm.Type
        ]