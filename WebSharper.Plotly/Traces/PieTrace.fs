namespace WebSharper.Plotly.Extension.Traces

// $begin{copyright}
//
// This file is part of WebSharper
//
// Copyright (c) 2008-2018 IntelliFactory
//
// Licensed under the Apache License, Version 2.0 (the "License"); you
// may not use this file except in compliance with the License.  You may
// obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
// implied.  See the License for the specific language governing
// permissions and limitations under the License.
//
// $end{copyright}

open WebSharper
open WebSharper.JavaScript
open WebSharper.InterfaceGenerator

module PieModule =

    let Color = T<string> + T<Number> + (!| (!? (NullValue.Type + T<string> + T<Number>))) + (!| (!| ((!? (NullValue.Type + T<string> + T<Number>))))) 


    let Font =
        Pattern.Config "Font" {
            Required = []
            Optional = [
                "family", T<string> + !| T<string>
                "size", T<Number> + !| T<Number>
                "color", Color + !| Color
            ]
        }

    let TitlePosition =
        Pattern.EnumInlines "TitlePosition" [
            "topLeft", "'top left'"
            "topCenter", "'top center'"
            "topRight", "'top right'"
            "middleCenter", "'middle center'"
            "bottomLeft", "'bottom left'"
            "bottomCenter", "'bottom center'"
            "bottomRight", "'bottom right'"
        ]

    let Title =
        Pattern.Config "Title" {
            Required= []
            Optional = [
                "text", T<string>
                "font", Font.Type
                "position", TitlePosition.Type
            ]
        }

    let VisibleString = Pattern.EnumStrings "VisibleString" ["legendonly"]

    let LegendGroupTitle =
        Pattern.Config "LegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", Font.Type
            ]
        }

    let TextPosition =
        Pattern.EnumInline "TextPosition" [
            "inside"
            "outside"
            "auto"
            "none"
        ]

    let HoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["label"; "text"; "value"; "percent"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "HoverInfo" generatedEnum

    let Domain = 
        Pattern.Config "Domain" {
            Required = []
            Optional = [
                "x", !| ((T<Number> + NullValue.Type) * (T<Number> + NullValue.Type)) //array
                "y", !| ((T<Number> + NullValue.Type) * (T<Number> + NullValue.Type)) //array
                "row", T<int>
                "column", T<int>
            ]
        }

    let MarkerLine =
        Pattern.Config "MarkerLine" {
            Required = []
            Optional = [
                "color", Color
                "width", T<Number> + !| T<Number>
            ]
        }

    let Marker =
        Pattern.Config "Marker" {
            Required = []
            Optional = [
                "colors", !| Color //data array
                "line", MarkerLine.Type

            ]
        }

    let TextInfo = 
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["label"; "text"; "value"; "percent"; "name"] '+')
            let seq2 = seq{"none"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "HoverInfo" generatedEnum    

    let Direction = 
        Pattern.EnumStrings "Direction" [
            "clockwise"
            "counterclockwise"
        ]

    let Align = 
        Pattern.EnumStrings "Align" [
            "left"
            "right"
            "auto"
        ]

    let HoverLabel =
        Pattern.Config "HoverLabel"  {
            Required = []
            Optional = [
                "bgcolor", Color + !| Color
                "bordercolor", Color + !| Color
                "font", Font.Type
                "align", Align.Type
                "namelength", T<int> + !| T<int>
            ]
        }  

    let TextOrientation = 
        Pattern.EnumStrings "TextOrientation" [
            "horizontal"
            "radial"
            "tangential"
            "auto"
        ]

    let PieOptions = 
        Class "PieOptions"
        |+> Static [
            Constructor T <unit>
            |> WithInline "{type:"pie"}"
        ]
        Pattern.OptionalFields [
            "name", T<string>
            "title", Title.Type
            "visible", T<bool> + VisibleString.Type
            "showlegend", T<bool>
            "legendrank", T<Number>
            "legendgroup", T<string>
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", T<Number>
            "ids", T<string>
            "values", T<string> //data array
            "labels", T<string> //data array
            "dlabel", T<Number>
            "label0", T<Number>
            "pull", T<Number> + !| T<Number>
            "text", T<string>
            "textposition", TextPosition.Type
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", HoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "meta", T<Number> + T<string>
            "customdata", T<string> //data
            "domain", Domain.Type
            "automargin", T<bool>
            "marker", Marker.Type
            "textFont", Font.Type
            "textinfo", TextInfo.Type
            "direction", Direction.Type
            "hole", T<Number>
            "hoverlabel", HoverLabel.Type
            "insidetextfont", Font.Type
            "insidetextorientation", TextOrientation.Type
            "outsidetextfont", Font.Type
            "rotation", T<Number>
            "scalegroup", T<string>
            "sort", T<bool>
            "uirevision", T<Number> + T<string>
        ]

    let PieTraceNamespaces : CodeModel.NamespaceEntity list = [
        Color
        Font
        TitlePosition
        Title
        VisibleString
        LegendGroupTitle
        TextPosition
        HoverInfo
        Domain
        MarkerLine
        Marker
        TextInfo
        Direction
        Align
        HoverLabel
        TextOrientation
        PieOptions
    ]