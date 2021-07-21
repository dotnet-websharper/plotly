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

module ViolinModule =

    open CommonModule

    let ViolinHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ViolinHoverInfo" generatedEnum

    let ViolinMarkerLine =
        Pattern.Config "ViolinMarkerLine" {
            Required = []
            Optional = [
                "color", Color
                "width", T<float> + T<int>
                "outliercolor", Color
                "outlierwidth", T<float> + T<int>
            ]
        }

    let ViolinMarker =
        Pattern.Config "ViolinMarker" {
            Required = []
            Optional = [
                "outliercolor", Color
                "symbol", Symbol.Type
                "opacity", T<float> + !| T<float>
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "color", Color
                "line", ViolinMarkerLine.Type
            ]
        }

    let ViolinSelectedMarker =
        Pattern.Config "ViolinSelectedMarker" {
            Required = []
            Optional = [
                "opacity", (T<float> + T<int>)
                "color", Color
                "size", (T<float> + T<int>)
            ]
        }

    let ViolinSelectedOption =
        Pattern.Config "ViolinSelectedOption" {
            Required = []
            Optional = [
                "marker", ViolinSelectedMarker.Type
            ]
        }

    let ViolinHoverOn =
        let generatedEnum = 
            let seq1 = GenerateOptions.allPermutations ["violins"; "points"; "kde"] '+'
            let seq2 = seq{"all"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ViolinHoverOn" generatedEnum

    let ViolinBoxLine =
        Pattern.Config "ViolinBoxLine" {
            Required = []
            Optional = [
                "color", Color
                "width", T<int> + T<float>
            ]
        }

    let ViolinBox =
        Pattern.Config "ViolinBox" {
            Required = []
            Optional = [
                "visible", T<bool>
                "width", T<float>
                "fillcolor", Color
                "line", ViolinBoxLine.Type
            ]
        }

    let ViolinMeanLine =
        Pattern.Config "ViolinMeanLine" {
            Required = []
            Optional = [
                "visible", T<bool>
                "color", Color
                "width", T<int> + T<float>
            ]
        }

    let ViolinPoints =
        Pattern.EnumStrings "ViolinPoints" [
            "all"
            "outliers"
            "suspectedoutliers"
            "none"
        ]

    let ViolinScaleMode =
        Pattern.EnumStrings "ViolinScaleMode" [
            "width"
            "count"
        ]

    let ViolinSide =
        Pattern.EnumStrings "ViolinSide" [
            "both"
            "positive"
            "negative"
        ]

    let ViolinSpanMode =
        Pattern.EnumStrings "ViolinSpanMode" [
            "soft"
            "hard"
            "manual"
        ]
 
    let ViolinLine =
        Pattern.Config "ViolinLine" {
            Required = []
            Optional = [
                "color", Color
                "width", T<int> + T<float>
            ]
        }

    let ViolinOptions =
        Class "ViolinOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'violin'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", T<float>
            "ids", !| T<string>
            "x", !| T<int> + !| T<float>
            "x0", (T<float> + T<int>) + T<string>
            "y", !| T<int> + !| T<float>
            "y0", (T<float> + T<int>) + T<string>
            "width", T<float> + T<int>
            "text", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", ViolinHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "xaxis", T<string> //type is 'subplotid'
            "yaxis", T<string> //type is 'subplotid'
            "orientation", Orientation.Type
            "alignmentgroup", T<string>
            "offsetgroup", T<string>
            "marker", ViolinMarker.Type
            "line", ViolinLine.Type
            "textfont", Font.Type
            "box", ViolinBox.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", ViolinSelectedOption.Type
            "unselected", ViolinSelectedOption.Type // change name later
            "bandwidth", T<int> + T<float>
            "fillcolor", Color
            "hoverlabel", HoverLabel.Type
            "hoveron", ViolinHoverOn.Type
            "pointpos", T<int> + T<float>
            "jitter", T<float>
            "meanline", ViolinMeanLine.Type
            "points", ViolinPoints.Type + T<bool>
            "scalegroup", T<string>
            "scalemode", ViolinScaleMode.Type
            "side", ViolinSide.Type
            "span", !| T<float> + !| T<int> + !| T<string>
            "spanmode", ViolinSpanMode.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ViolinTraceNamespaces : CodeModel.NamespaceEntity list = [
        ViolinHoverInfo
        ViolinMarkerLine
        ViolinMarker
        ViolinBoxLine
        ViolinSelectedMarker
        ViolinSelectedOption
        ViolinHoverOn
        ViolinOptions
        ViolinBox
        ViolinMeanLine
        ViolinPoints
        ViolinScaleMode
        ViolinSide
        ViolinSpanMode
        ViolinLine
    ]