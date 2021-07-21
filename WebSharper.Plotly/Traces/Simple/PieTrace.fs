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
open WebSharper.Plotly.Extension.GenerateEnum
open WebSharper.Plotly.Extension.Common

module PieModule =

    open CommonModule

    let PieTitlePosition =
        Pattern.EnumInlines "PieTitlePosition" [
            "topLeft", "'top left'"
            "topCenter", "'top center'"
            "topRight", "'top right'"
            "middleCenter", "'middle center'"
            "bottomLeft", "'bottom left'"
            "bottomCenter", "'bottom center'"
            "bottomRight", "'bottom right'"
        ]

    let PieTitle =
        Pattern.Config "PieTitle" {
            Required= []
            Optional = [
                "text", T<string>
                "font", Font.Type
                "position", PieTitlePosition.Type
            ]
        }

    let PieHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["label"; "text"; "value"; "percent"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "PieHoverInfo" generatedEnum

    let PieMarkerLine =
        Pattern.Config "PieMarkerLine" {
            Required = []
            Optional = [
                "PieColor", Color
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
            ]
        }

    let PieMarker =
        Pattern.Config "PieMarker" {
            Required = []
            Optional = [
                "PieColors", !| Color //data array
                "line", PieMarkerLine.Type

            ]
        }

    let PieTextInfo = 
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["label"; "text"; "value"; "percent"; "name"] '+')
            let seq2 = seq{"none"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "PieTextInfo" generatedEnum    

    let PieDirection = 
        Pattern.EnumStrings "PieDirection" [
            "clockwise"
            "counterclockwise"
        ]

    let PieOptions = 
        Class "PieOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'pie'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "title", PieTitle.Type
            "visible", T<bool> + VisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", (T<float> + T<int>)
            "ids", T<string>
            "values", !| T<float> + !| T<int>
            "labels", !| T<string>
            "dlabel", (T<float> + T<int>)
            "label0", (T<float> + T<int>)
            "pull", (T<float> + T<int>) + !| T<float> + !| T<int>
            "text", T<string>
            "textposition", TextPositionEnum.Type
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", PieHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> //data
            "domain", Domain.Type
            "automargin", T<bool>
            "marker", PieMarker.Type
            "textPieFont", Font.Type
            "textinfo", PieTextInfo.Type
            "direction", PieDirection.Type
            "hole", (T<float> + T<int>)
            "hoverlabel", HoverLabel.Type
            "insidetextfont", Font.Type
            "insidetextorientation", TextOrientation.Type
            "outsidetextfont", Font.Type
            "rotation", (T<float> + T<int>)
            "scalegroup", T<string>
            "sort", T<bool>
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let PieTraceNamespaces : CodeModel.NamespaceEntity list = [
        PieTitlePosition
        PieTitle
        PieHoverInfo
        PieMarkerLine
        PieMarker
        PieTextInfo
        PieDirection
        PieOptions
    ]