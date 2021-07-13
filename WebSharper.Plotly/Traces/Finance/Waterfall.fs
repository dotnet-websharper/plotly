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

module WaterfallModule =

    let WaterfallNullValue = Pattern.EnumInlines "WaterfallNullValue" ["null", "null"]

    let WaterfallColor = T<string> + (T<float> + T<int>) + (!| (!? (WaterfallNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (WaterfallNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let WaterfallVisibleString = Pattern.EnumStrings "WaterfallVisibleString" ["legendonly"]

    let WaterfallFont =
        Pattern.Config "WaterfallFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", WaterfallColor
            ]
        }

    let WaterfallLegendGroupTitle =
        Pattern.Config "WaterfallLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", WaterfallFont.Type
            ]
        }

    let WaterfallHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "text"; "initial"; "delta";"final"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "WaterfallHoverInfo" generatedEnum

    let WaterfallTextInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["label"; "text"; "initial"; "delta"; "final"] '+')
            let seq2 = seq{"none"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "WaterfallTextInfo" generatedEnum

    let WaterfallPeriodAlignment =
        Pattern.EnumStrings "XWaterfallPeriodAlignment" [
            "start"
            "middle"
            "end"
        ]

    let WaterfallGradientType =
        Pattern.EnumStrings "WaterfallGradientType" [
            "radial"
            "horizontal"
            "vertical"
            "none"
        ]

    let WaterfallGradient =
        Pattern.Config "WaterfallGradient" {
            Required = []
            Optional = [
                "type", WaterfallGradientType.Type
                "color", WaterfallColor + !| WaterfallColor
            ]
        }

    let WaterfallAlign =
        Pattern.EnumStrings "WaterfallAlign" [
            "left"
            "right"
            "auto"
        ]

    let WaterfallHoverLabel =
        Pattern.Config "WaterfallHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", WaterfallColor + !| WaterfallColor
                "bordercolor", WaterfallColor + !| WaterfallColor
                "font", WaterfallFont.Type
                "align", WaterfallAlign.Type
                "namelength", T<int>
            ]
        }

    let WaterfallLine =
        Pattern.Config "WaterfallLine" {
            Required = []
            Optional = [
                "color", WaterfallColor
                "width", T<int> + T<float>
                "dash", T<string>
            ]
        }

    let WaterfallMarkerLine =
        Pattern.Config "WaterfallMarkerLine" {
                "color", WaterfallColor
                "width", T<int> + T<float>            
        }

    let WaterfallCreasingLine =
        Pattern.Config "WaterfallCreasingLine" {
            Required = []
            Optional = [
                "color", WaterfallColor
                "width", T<int> + T<float>
            ]
        }

    let WaterfallCreasing =
        Pattern.Config "WaterfallCreasing" {
            Required = []
            Optional = [
                "line", WaterfallCreasingLine.Type
                "fillcolor", WaterfallColor
            ]
        }

    let WaterfallTextPosition =
        Pattern.EnumStrings "WaterfallTextPosition" [
            "inside"
            "outside"
            "auto"
            "none"
        ]

    let WaterfallOrientation =
        Pattern.EnumStrings "WaterfallOrientation" [
            "v"
            "h"
        ]

    let WaterfallConnectorMode =
        Pattern.EnumStrings "WaterfallConnectorMode" [
            "spanning"
            "between"
        ]

    let WaterfallConnector =
        Pattern.Config "WaterfallConnector" {
            Required = []
            Optional = [
                "line". WaterfallLine.Type
                "mode", WaterfallConnectorMode.Type
                "visible", T<bool>
            ]
        }

    let WaterfallConstrainText =
        Pattern.EnumStrings "WaterfallConstrainText" [
            "inside"
            "outside"
            "both"
            "none"
        ]

    let WaterfallInsideTextAnchor =
        Pattern.EnumStrings "WaterfallInsideTextAnchor" [
            "end"
            "middle"
            "start"
        ]

    let WaterfallMarker =
        Pattern.Config "WaterfallMarker" {
            Required = []
            Optional = [
                "color", WaterfallColor
                "line", WaterfallMarkerLine.Type
            ]
        }

    let WaterfallTotals =
        Pattern.Config "WaterfallTotals" {
            Required = []
            Optional = [
                "marker", WaterfallMarker.Type
            ]
        }

    let WaterfallOptions =
        Class "WaterfallOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'waterfall'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + WaterfallVisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", WaterfallLegendGroupTitle.Type
            "opacity", T<float>
            "ids", !| T<string>
            "x", !| T<int> + !| T<float>
            "x0", T<int> + T<float> + T<string>
            "dx", T<int> + T<float>
            "y", !| T<int> + !| T<float>
            "y0", T<int> + T<float> + T<string>
            "dy", T<int> + T<float>
            "base", T<int> + T<float>
            "width", T<int> + T<float> + !| T<int> + !| T<float>
            "measure", !| T<int> + !| T<float> + T<string>
            "offset", T<int> + T<float> + !| T<int> + !| T<float>
            "text", T<string> + !| T<string>
            "textposition", WaterfallTextPosition.Type
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", WaterfallHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "xaxis", T<string> //type is 'subplotid'
            "yaxis", T<string> //type is 'subplotid'
            "orientation", WaterfallOrientation.Type
            "alignmentgroup", T<string>
            "offsetgroup", T<string>
            "xperiod", (T<float> + T<int>) + T<string>
            "xperiodalignment", WaterfallPeriodAlignment.Type
            "xperiod0", (T<float> + T<int>) + T<string>
            "yperiod", (T<float> + T<int>) + T<string>
            "yperiodalignment", WaterfallPeriodAlignment.Type
            "yperiod0", (T<float> + T<int>) + T<string>
            "textangle", T<int> + T<float> //angle
            "textfont", WaterfallFont.Type
            "textinfo", WaterfallTextInfo.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "cliponaxis", T<bool>
            "connector", WaterfallConnector.Type
            "constraintext", WaterfallConstrainText.Type
            "increasing", WaterfallCreasing.Type
            "decreasing", WaterfallCreasing.Type
            "hoverlabel", WaterfallHoverLabel.Type
            "insidetextanchor", WaterfallInsideTextAnchor.Type
            "insidetextfont", WaterfallFont.Type
            "outsidetextfont", WaterfallFont.Type
            "totals", WaterfallTotals.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let WaterfallTraceNamespaces : CodeModel.NamespaceEntity list = [
        WaterfallNullValue
        WaterfallVisibleString
        WaterfallFont
        WaterfallLegendGroupTitle
        WaterfallHoverInfo
        WaterfallTextInfo
        WaterfallPeriodAlignment
        WaterfallGradientType
        WaterfallGradient
        WaterfallAlign
        WaterfallHoverLabel
        WaterfallLine
        WaterfallMarkerLine
        WaterfallCreasingLine
        WaterfallCreasing
        WaterfallTextPosition
        WaterfallOrientation
        WaterfallConnectorMode
        WaterfallConnector
        WaterfallConstrainText
        WaterfallInsideTextAnchor
        WaterfallMarker
        WaterfallTotals
        WaterfallOptions
    ]