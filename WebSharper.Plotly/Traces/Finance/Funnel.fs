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

module FunnelModule =

    open CommonModule

    let FunnelHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "text"; "initial"; "delta";"final"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "FunnelHoverInfo" generatedEnum

    let FunnelTextInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["label"; "text"; "initial"; "delta"; "final"] '+')
            let seq2 = seq{"none"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "FunnelTextInfo" generatedEnum

    let FunnelLine =
        Pattern.Config "FunnelLine" {
            Required = []
            Optional = [
                "color", Color
                "width", T<int> + T<float>
                "dash", T<string>
            ]
        }

    let FunnelTotalsMarkerLine =
        Pattern.Config "FunnelTotalsMarkerLine" {
            Required = []
            Optional = [
                "color", Color
                "width", T<int> + T<float> 
            ]           
        }

    let FunnelConnectorMode =
        Pattern.EnumStrings "FunnelConnectorMode" [
            "spanning"
            "between"
        ]

    let FunnelConnector =
        Pattern.Config "FunnelConnector" {
            Required = []
            Optional = [
                "line", FunnelLine.Type
                "mode", FunnelConnectorMode.Type
                "visible", T<bool>
            ]
        }

    let FunnelConstrainText =
        Pattern.EnumStrings "FunnelConstrainText" [
            "inside"
            "outside"
            "both"
            "none"
        ]

    let FunnelInsideTextAnchor =
        Pattern.EnumStrings "FunnelInsideTextAnchor" [
            "end"
            "middle"
            "start"
        ]

    let FunnelTotalsMarker =
        Pattern.Config "FunnelTotalsMarker" {
            Required = []
            Optional = [
                "color", Color
                "line", FunnelTotalsMarkerLine.Type
            ]
        }

    let FunnelTotals =
        Pattern.Config "FunnelTotals" {
            Required = []
            Optional = [
                "marker", FunnelTotalsMarker.Type
            ]
        }

    let FunnelMarkerLine =
        Pattern.Config "FunnelMarkerLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
                "color", Color
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", ColorScale
                "autocolorscale", T<bool>
                "reversescale", T<bool>
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let FunnelMarker =
        Pattern.Config "FunnelMarker" {
            Required = []
            Optional = [
                "line", FunnelMarkerLine.Type //
                "color", Color + !| Color
                "cauto", T<bool>
                "cmin", T<int> + T<float>
                "cmax", T<int> + T<float>
                "cmid", T<int> + T<float>
                "colorscale", ColorScale
                "autocolorscale", T<bool>
                "reversecolorscale", T<bool>
                "showscale", T<bool>
                "colorbar", ColorBar.Type //
                "coloraxis", T<string>
                "opacity", T<float>
            ]
        }

    let FunnelOptions =
        Class "FunnelOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'funnel'}"
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
            "x0", T<int> + T<float> + T<string>
            "dx", T<int> + T<float>
            "y", !| T<int> + !| T<float>
            "y0", T<int> + T<float> + T<string>
            "dy", T<int> + T<float>
            "width", T<int> + T<float> + !| T<int> + !| T<float>
            "offset", T<int> + T<float> + !| T<int> + !| T<float>
            "text", T<string> + !| T<string>
            "textposition", TextPositionEnum.Type
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", T<string> //FunnelHoverInfo.Type //TODO
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
            "marker", FunnelMarker.Type
            "textangle", T<int> + T<float> //angle
            "textfont", Font.Type
            "textinfo", FunnelTextInfo.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "cliponaxis", T<bool>
            "connector", FunnelConnector.Type
            "constraintext", FunnelConstrainText.Type
            "hoverlabel", HoverLabel.Type
            "insidetextanchor", FunnelInsideTextAnchor.Type
            "insidetextfont", Font.Type
            "outsidetextfont", Font.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let FunnelTraceNamespaces : CodeModel.NamespaceEntity list = [
        FunnelHoverInfo
        FunnelTextInfo
        FunnelLine
        FunnelTotalsMarkerLine
        FunnelConnectorMode
        FunnelConnector
        FunnelConstrainText
        FunnelInsideTextAnchor
        FunnelTotalsMarker
        FunnelTotals
        FunnelMarkerLine
        FunnelMarker
        FunnelOptions
    ]