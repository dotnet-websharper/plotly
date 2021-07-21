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

module FunnelAreaModule =

    open CommonModule

    let FunnelAreaHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "text"; "initial"; "delta"; "final"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "FunnelAreaHoverInfo" generatedEnum

    let FunnelAreaTextInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["label"; "text"; "initial"; "delta"; "final"] '+')
            let seq2 = seq{"none"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "FunnelAreaTextInfo" generatedEnum

    let FunnelAreaMarkerLine =
        Pattern.Config "FunnelAreaMarkerLine" {
            Required = []
            Optional = [
                "color", Color + !| Color
                "width", T<float> + T<int> + !| T<float> + !| T<int>
            ]
        }

    let FunnelAreaMarker =
        Pattern.Config "FunnelAreaMarker" {
            Required = []
            Optional = [
                "colors", Color + !| Color
                "line", FunnelAreaMarkerLine.Type
            ]
        }

    let FunnelAreaTitlePosition =
        Pattern.EnumInlines "FunnelAreaTitlePosition" [
            "topLeft", "'top left'"
            "topCenter", "'top center'"
            "topRight", "'top right'"
        ]

    let FunnelAreaTitle =
        Pattern.Config "FunnelAreaTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", Font.Type
                "position", FunnelAreaTitlePosition.Type
            ]
        }

    let FunnelAreaOptions =
        Class "FunnelAreaOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'funnelarea'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "title", FunnelAreaTitle.Type
            "visible", T<bool> + VisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", T<float>
            "ids", !| T<string>
            "values", !| T<string> + !| T<int> + !| T<float>
            "labels", !| T<string> + !| T<int> + !| T<float>
            "dlabel", T<int> + T<float>
            "label0", T<int> + T<float>
            "text", T<string> + !| T<string>
            "textposition", TextPositionEnum.Type
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", FunnelAreaHoverInfo.Type //TODO
            "hovertemplate", T<string> + !| T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "domain", Domain.Type
            "marker", FunnelAreaMarker.Type
            "textfont", Font.Type
            "textinfo", FunnelAreaTextInfo.Type
            "aspectratio", T<int> + T<float>
            "baseratio", T<int> + T<float>
            "hoverlabel", HoverLabel.Type
            "insidetextfont", Font.Type
            "scalegroup", T<string>
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let FunnelAreaTraceNamespaces : CodeModel.NamespaceEntity list = [
        FunnelAreaHoverInfo
        FunnelAreaTextInfo
        FunnelAreaMarkerLine
        FunnelAreaMarker
        FunnelAreaTitlePosition
        FunnelAreaTitle
        FunnelAreaOptions
    ]