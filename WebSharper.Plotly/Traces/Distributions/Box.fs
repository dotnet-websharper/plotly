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

module BoxModule =

    open CommonModule

    let BoxHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "BoxHoverInfo" generatedEnum    

    let BoxMarkerLine =
        Pattern.Config "BoxMarkerLine" {
            Required = []
            Optional = [
                "color", Color
                "width", T<float> + T<int>
                "outliercolor", Color
                "outlierwidth", T<float> + T<int>
            ]
        }

    let BoxMarker =
        Pattern.Config "BoxMarker" {
            Required = []
            Optional = [
                "outliercolor", Color
                "symbol", Symbol.Type
                "opacity", T<float> + !| T<float>
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "color", Color
                "line", BoxMarkerLine.Type
            ]
        }

    let BoxSelectedMarker =
        Pattern.Config "BoxSelectedMarker" {
            Required = []
            Optional = [
                "opacity", (T<float> + T<int>)
                "color", Color
                "size", (T<float> + T<int>)
            ]
        }

    let BoxSelectedOption =
        Pattern.Config "BoxSelectedOption" {
            Required = []
            Optional = [
                "marker", BoxSelectedMarker.Type
            ]
        }

    let BoxHoverOn =
        let generatedEnum = GenerateOptions.allPermutations ["boxes"; "points"] '+'
        Pattern.EnumStrings "BoxHoverOn" generatedEnum

    let BoxMean =
        Pattern.EnumStrings "BoxMean" [
            "sd"
        ]

    let BoxPoints =
        Pattern.EnumStrings "BoxPoints" [
            "all"
            "outliers"
            "suspectedoutliers"
        ]

    let BoxLine =
        Pattern.Config "BoxLine" {
            Required = []
            Optional = [
                "color", Color
                "width", T<int> + T<float>
            ]
        }

    let BoxQuartileMethod =
        Pattern.EnumStrings "BoxQuartileMethod" [
            "linear"
            "exclusive"
            "inclusive"
        ]

    let BoxOptions =
        Class "BoxOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'box'}"
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
            "dx", (T<float> + T<int>)
            "y", !| T<int> + !| T<float>
            "y0", (T<float> + T<int>) + T<string>
            "dy", (T<float> + T<int>)
            "width", T<int> + T<float>
            "text", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", BoxHoverInfo.Type
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
            "xperiod", (T<float> + T<int>) + T<string>
            "xperiodalignment", PeriodAlignment.Type
            "xperiod0", (T<float> + T<int>) + T<string>
            "yperiod", (T<float> + T<int>) + T<string>
            "yperiodalignment", PeriodAlignment.Type
            "yperiod0", (T<float> + T<int>) + T<string>
            "marker", BoxMarker.Type
            "line", BoxLine.Type
            "boxmean", BoxMean.Type + T<bool>
            "boxpoints", BoxPoints.Type + T<bool>
            "notched", T<bool>
            "notchwidth", T<float>
            "whiskerwidth", T<float>
            "q1", !| T<float> + !| T<int> + !| T<string>
            "median", !| T<float> + !| T<int> + !| T<string>
            "q3", !| T<float> + !| T<int> + !| T<string>
            "lowerfence", !| T<float> + !| T<int> + !| T<string>
            "upperfence", !| T<float> + !| T<int> + !| T<string>
            "notchspan", !| T<float> + !| T<int> + !| T<string>
            "mean", !| T<float> + !| T<int> + !| T<string>
            "sd", !| T<float> + !| T<int> + !| T<string>
            "quartilemethod", BoxQuartileMethod.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", BoxSelectedOption.Type
            "unselected", BoxSelectedOption.Type // change name later
            "fillcolor", Color
            "hoverlabel", HoverLabel.Type
            "hoveron", BoxHoverOn.Type
            "pointpos", T<float> + T<int>
            "jitter", T<float> + T<int>
            "xcalendar", Calendar.Type
            "ycalendar", Calendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let BoxTraceNamespaces : CodeModel.NamespaceEntity list = [
        BoxLine
        BoxHoverInfo
        BoxMarkerLine
        BoxMarker
        BoxSelectedMarker
        BoxSelectedOption
        BoxHoverOn
        BoxMean
        BoxPoints
        BoxQuartileMethod
        BoxOptions
    ]