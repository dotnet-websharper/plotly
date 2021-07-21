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

module SplomModule =

    open CommonModule

    let SplomHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all";"none";"skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "SplomHoverInfo" generatedEnum

    let SplomDimensionAxisType =
        Pattern.EnumStrings "SplomDimensionAxisType" [
            "linear"
            "log"
            "date"
            "category"
        ]

    let SplomDimensionAxis =
        Pattern.Config "SplomDimensionAxis" {
            Required = []
            Optional = [
                "type", SplomDimensionAxisType.Type
                "matches", T<bool>
            ]
        }

    let SplomDimensions =
        Pattern.Config "SplomDimensions" {
            Required = []
            Optional = [
                "visible", T<bool>
                "label", T<string>
                "values", !| T<string> + !| T<int> + !| T<float>
                "axis", SplomDimensionAxis.Type
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let SplomMarkerLine =
        Pattern.Config "SplomMarkerLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
                "color",Color + !| Color //data array
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", ColorScale
                "autocolorscale", T<bool>
                "reverscale", T<bool>
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let SplomMarker =
        Pattern.Config "SplomMarker" {
            Required = []
            Optional = [
                "line", SplomMarkerLine.Type
                "color", Color + !| Color //data array
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", ColorScale
                "autocolorscale", T<bool>
                "reverscale", T<bool>
                "showscale", T<bool>
                "colorbar", ColorBar.Type
                "coloraxis", T<string> // type: subplotid
                "symbol", Symbol.Type
                "size", T<int> + T<float> + !| T<int> + !| T<float>
                "sizeref", T<int> + T<float>
                "sizemin", T<int> + T<float>
                "sizemode", SizeMode.Type
                "opacity", T<float> + !| T<float>
            ]
        }


    let SplomDiagonal =
        Pattern.Config "SplomDiagonal" {
            Required = []
            Optional = [
                "visible", T<bool>
            ]
        }

    let SplomSelectedMarker =
        Pattern.Config "SplomSelectedMarker" {
            Required = []
            Optional = [
                "opacity", T<float>
                "color", Color
                "size", T<int> + T<float>
            ]
        }

    let SplomSelected =
        Pattern.Config "SplomSelected" {
            Required = []
            Optional = [
                "marker", SplomSelectedMarker.Type
            ]
        }

    let SplomOptions =
        Class "SplomOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'splom'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", T<float>
            "ids", !| T<string>
            "text", T<string> + !| T<string>
            "dimensions", SplomDimensions.Type
            "hovertext", T<string> + !| T<string>
            "hoverinfo", SplomHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", !| T<string> + !| T<int> + !| T<float>
            "marker", SplomMarker.Type
            "diagonal", SplomDiagonal.Type
            "xaxes", !| T<string> + !| T<int> + !| T<float>
            "yaxes", !| T<string> + !| T<int> + !| T<float>
            "showlowerhalf", T<bool>
            "showupperhalf", T<bool>
            "selectedpoints", T<int> + T<float> + T<string>
            "selected", SplomSelected.Type
            "unselected", SplomSelected.Type
            "hoverlabel", HoverLabel.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let SplomTraceNamespaces : CodeModel.NamespaceEntity list = [
        SplomHoverInfo
        SplomDimensionAxisType
        SplomDimensionAxis
        SplomDimensions
        SplomMarkerLine
        SplomMarker
        SplomDiagonal
        SplomSelectedMarker
        SplomSelected
        SplomOptions
    ]