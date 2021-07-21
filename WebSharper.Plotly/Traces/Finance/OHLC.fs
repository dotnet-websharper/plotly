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

module OHLCModule =

    open CommonModule

    let OHLCHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "OHLCHoverInfo" generatedEnum

    let OHLCLine =
        Pattern.Config "OHLCLine" {
            Required = []
            Optional = [
                "dash", T<string>
                "width", T<int> + T<float>
                "color", Color
            ]
        }

    let OHLCCreasingLine =
        Pattern.Config "OHLCCreasingLine" {
            Required = []
            Optional = [
                "color", Color
                "width", T<int> + T<float>
                "dash", T<string>
            ]
        }

    let OHLCCreasing =
        Pattern.Config "OHLCCreasing" {
            Required = []
            Optional = [
                "line", OHLCCreasingLine.Type
            ]
        }

    let OHLCOptions =
        Class "OHLCOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'ohlc'}"
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
            "close", T<string> + T<int> + T<float>
            "open", T<string> + T<int> + T<float>
            "high", T<string> + T<int> + T<float>
            "low", T<string> + T<int> + T<float>
            "text", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", OHLCHoverInfo.Type
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "xaxis", T<string> //type is 'subplotid'
            "yaxis", T<string> //type is 'subplotid'
            "xperiod", (T<float> + T<int>) + T<string>
            "xperiodalignment", PeriodAlignment.Type
            "xperiod0", (T<float> + T<int>) + T<string>
            "line", OHLCLine.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "increasing", OHLCCreasing.Type
            "decreasing", OHLCCreasing.Type
            "hoverlabel", HoverLabel.Type
            "tickwidth", T<float>
            "xcalendar", Calendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let OHLCTraceNamespaces : CodeModel.NamespaceEntity list = [
        OHLCHoverInfo
        OHLCLine
        OHLCCreasingLine
        OHLCCreasing
        OHLCOptions
    ]