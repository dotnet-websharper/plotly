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

module CandleStickModule =

    let CandleStickNullValue = Pattern.EnumInlines "CandleStickNullValue" ["null", "null"]

    let CandleStickColor = T<string> + (T<float> + T<int>) + (!| (!? (CandleStickNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (CandleStickNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let CandleStickColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let CandleStickVisibleString = Pattern.EnumStrings "CandleStickVisibleString" ["legendonly"]

    let CandleStickFont =
        Pattern.Config "CandleStickFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", CandleStickColor
            ]
        }

    let CandleStickLegendGroupTitle =
        Pattern.Config "CandleStickLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", CandleStickFont.Type
            ]
        }

    let CandleStickHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "CandleStickHoverInfo" generatedEnum

    let CandleStickPeriodAlignment =
        Pattern.EnumStrings "XCandleStickPeriodAlignment" [
            "start"
            "middle"
            "end"
        ]

    let CandleStickGradientType =
        Pattern.EnumStrings "CandleStickGradientType" [
            "radial"
            "horizontal"
            "vertical"
            "none"
        ]

    let CandleStickGradient =
        Pattern.Config "CandleStickGradient" {
            Required = []
            Optional = [
                "type", CandleStickGradientType.Type
                "color", CandleStickColor + !| CandleStickColor
            ]
        }

    let CandleStickAlign =
        Pattern.EnumStrings "CandleStickAlign" [
            "left"
            "right"
            "auto"
        ]

    let CandleStickHoverLabel =
        Pattern.Config "CandleStickHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", CandleStickColor + !| CandleStickColor
                "bordercolor", CandleStickColor + !| CandleStickColor
                "font", CandleStickFont.Type
                "align", CandleStickAlign.Type
                "namelength", T<int>
                "split", T<bool>
            ]
        }

    let CandleStickCalendar =
        Pattern.EnumStrings "CandleStickCalendar" [
            "gregorian"
            "chinese"
            "coptic"
            "discworld"
            "ethiopian"
            "hebrew"
            "islamic"
            "julian"
            "mayan"
            "nanakshahi"
            "nepali"
            "persian"
            "jalali"
            "taiwan"
            "thai"
            "ummalqura"
        ]

    let CandleStickLine =
        Pattern.Config "CandleStickLine" {
            Required = []
            Optional = [
                "width", T<int> + T<float>
            ]
        }

    let CandleStickCreasingLine =
        Pattern.Config "CandleStickCreasingLine" {
            Required = []
            Optional = [
                "color", CandleStickColor
                "width", T<int> + T<float>
            ]
        }

    let CandleStickCreasing =
        Pattern.Config "CandleStickCreasing" {
            Required = []
            Optional = [
                "line", CandleStickCreasingLine.Type
                "fillcolor", CandleStickColor
            ]
        }

    let CandleStickOptions =
        Class "CandleStickOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'candlestick'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + CandleStickVisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", CandleStickLegendGroupTitle.Type
            "opacity", T<float>
            "ids", !| T<string>
            "x", !| T<int> + !| T<float>
            "close", T<string> + T<int> + T<float>
            "open", T<string> + T<int> + T<float>
            "high", T<string> + T<int> + T<float>
            "low", T<string> + T<int> + T<float>
            "text", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", CandleStickHoverInfo.Type
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "xaxis", T<string> //type is 'subplotid'
            "yaxis", T<string> //type is 'subplotid'
            "xperiod", (T<float> + T<int>) + T<string>
            "xperiodalignment", CandleStickPeriodAlignment.Type
            "xperiod0", (T<float> + T<int>) + T<string>
            "whiskerwidth", T<float>
            "line", CandleStickLine.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "increasing", CandleStickCreasing.Type
            "decreasing", CandleStickCreasing.Type
            "hoverlabel", CandleStickHoverLabel.Type
            "xcalendar", CandleStickCalendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let CandleStickTraceNamespaces : CodeModel.NamespaceEntity list = [
        CandleStickNullValue
        CandleStickVisibleString
        CandleStickFont
        CandleStickLegendGroupTitle
        CandleStickHoverInfo
        CandleStickPeriodAlignment
        CandleStickGradientType
        CandleStickGradient
        CandleStickAlign
        CandleStickHoverLabel
        CandleStickCalendar
        CandleStickLine
        CandleStickCreasingLine
        CandleStickCreasing
        CandleStickOptions
    ]