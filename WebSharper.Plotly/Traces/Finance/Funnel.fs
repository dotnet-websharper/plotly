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

module FunnelModule =

    let FunnelNullValue = Pattern.EnumInlines "FunnelNullValue" ["null", "null"]

    let FunnelColor = T<string> + (T<float> + T<int>) + (!| (!? (FunnelNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (FunnelNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let FunnelVisibleString = Pattern.EnumStrings "FunnelVisibleString" ["legendonly"]

    let FunnelFont =
        Pattern.Config "FunnelFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", FunnelColor
            ]
        }

    let FunnelLegendGroupTitle =
        Pattern.Config "FunnelLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", FunnelFont.Type
            ]
        }

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

    let FunnelPeriodAlignment =
        Pattern.EnumStrings "XFunnelPeriodAlignment" [
            "start"
            "middle"
            "end"
        ]

    let FunnelGradientType =
        Pattern.EnumStrings "FunnelGradientType" [
            "radial"
            "horizontal"
            "vertical"
            "none"
        ]

    let FunnelGradient =
        Pattern.Config "FunnelGradient" {
            Required = []
            Optional = [
                "type", FunnelGradientType.Type
                "color", FunnelColor + !| FunnelColor
            ]
        }

    let FunnelAlign =
        Pattern.EnumStrings "FunnelAlign" [
            "left"
            "right"
            "auto"
        ]

    let FunnelHoverLabel =
        Pattern.Config "FunnelHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", FunnelColor + !| FunnelColor
                "bordercolor", FunnelColor + !| FunnelColor
                "font", FunnelFont.Type
                "align", FunnelAlign.Type
                "namelength", T<int>
            ]
        }

    let FunnelLine =
        Pattern.Config "FunnelLine" {
            Required = []
            Optional = [
                "color", FunnelColor
                "width", T<int> + T<float>
                "dash", T<string>
            ]
        }

    let FunnelTotalsMarkerLine =
        Pattern.Config "FunnelTotalsMarkerLine" {
            Required = []
            Optional = [
                "color", FunnelColor
                "width", T<int> + T<float> 
            ]           
        }

    let FunnelCreasingLine =
        Pattern.Config "FunnelCreasingLine" {
            Required = []
            Optional = [
                "color", FunnelColor
                "width", T<int> + T<float>
            ]
        }

    let FunnelCreasing =
        Pattern.Config "FunnelCreasing" {
            Required = []
            Optional = [
                "line", FunnelCreasingLine.Type
                "fillcolor", FunnelColor
            ]
        }

    let FunnelTextPosition =
        Pattern.EnumStrings "FunnelTextPosition" [
            "inside"
            "outside"
            "auto"
            "none"
        ]

    let FunnelOrientation =
        Pattern.EnumStrings "FunnelOrientation" [
            "v"
            "h"
        ]

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
                "color", FunnelColor
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

    let FunnelColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let FunnelMarkerLine =
        Pattern.Config "FunnelMarkerLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
                "color", FunnelColor
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", FunnelColorScale
                "autocolorscale", T<bool>
                "reversescale", T<bool>
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let FunnelColorBarMode =
        Pattern.EnumStrings "FunnelThicknessMode" [
            "fraction"
            "pixels"
        ]

    let FunnelXAnchor =
        Pattern.EnumStrings "FunnelXAnchor" [
            "left"
            "center"
            "right"
        ]

    let FunnelYAnchor =
        Pattern.EnumStrings "FunnelYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let FunnelTickMode =
        Pattern.EnumStrings "FunnelTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let FunnelTicks =
        Pattern.EnumInlines "FunnelTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let FunnelTickLabelOverflow =
        Pattern.EnumInlines "FunnelTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let FunnelTickLabelPosition =
        Pattern.EnumInlines "FunnelTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let FunnelTickFormatStops =
        Pattern.Config "FunnelTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + FunnelNullValue.Type) * (DTickValue + FunnelNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let FunnelShowTickFix =
        Pattern.EnumStrings "FunnelShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = FunnelShowTickFix

    let FunnelExponentFormat =
        Pattern.EnumInlines "FunnelExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let FunnelSide =
        Pattern.EnumStrings "FunnelSide" [
            "right"
            "top"
            "bottom"
        ]

    let FunnelTitle =
        Pattern.Config "FunnelTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", FunnelFont.Type
                "side", FunnelSide.Type
            ]
        }

    let FunnelColorBar =
        Pattern.Config "FunnelColorBar" {
            Required = []
            Optional = [
                "thicknessmode", FunnelColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", FunnelColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", FunnelXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", FunnelYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", FunnelColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", FunnelColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", FunnelColor
                "tickmode", FunnelTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", FunnelTicks.Type
                "ticklabeloverflow", FunnelTickLabelOverflow.Type
                "ticklabelposition", FunnelTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", FunnelColor
                "showticklabels", T<bool>
                "tickfont", FunnelFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", FunnelTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", FunnelShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", FunnelShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", FunnelExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", FunnelTitle.Type
            ]
        }

    let FunnelMarker =
        Pattern.Config "FunnelMarker" {
            Required = []
            Optional = [
                "line", FunnelMarkerLine.Type //
                "color", FunnelColor + !| FunnelColor
                "cauto", T<bool>
                "cmin", T<int> + T<float>
                "cmax", T<int> + T<float>
                "cmid", T<int> + T<float>
                "colorscale", FunnelColorScale
                "autocolorscale", T<bool>
                "reversecolorscale", T<bool>
                "showscale", T<bool>
                "colorbar", FunnelColorBar.Type //
                "coloraxis", T<string>
                "opacity", T<float>
            ]
        }

    let FunnelOptions =
        Class "FunnelOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'funnel'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + FunnelVisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", FunnelLegendGroupTitle.Type
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
            "textposition", FunnelTextPosition.Type
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
            "orientation", FunnelOrientation.Type
            "alignmentgroup", T<string>
            "offsetgroup", T<string>
            "xperiod", (T<float> + T<int>) + T<string>
            "xperiodalignment", FunnelPeriodAlignment.Type
            "xperiod0", (T<float> + T<int>) + T<string>
            "yperiod", (T<float> + T<int>) + T<string>
            "yperiodalignment", FunnelPeriodAlignment.Type
            "yperiod0", (T<float> + T<int>) + T<string>
            "marker", FunnelMarker.Type
            "textangle", T<int> + T<float> //angle
            "textfont", FunnelFont.Type
            "textinfo", FunnelTextInfo.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "cliponaxis", T<bool>
            "connector", FunnelConnector.Type
            "constraintext", FunnelConstrainText.Type
            "hoverlabel", FunnelHoverLabel.Type
            "insidetextanchor", FunnelInsideTextAnchor.Type
            "insidetextfont", FunnelFont.Type
            "outsidetextfont", FunnelFont.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let FunnelTraceNamespaces : CodeModel.NamespaceEntity list = [
        FunnelNullValue
        FunnelVisibleString
        FunnelFont
        FunnelLegendGroupTitle
        FunnelHoverInfo
        FunnelTextInfo
        FunnelPeriodAlignment
        FunnelGradientType
        FunnelGradient
        FunnelAlign
        FunnelHoverLabel
        FunnelLine
        FunnelTotalsMarkerLine
        FunnelCreasingLine
        FunnelCreasing
        FunnelTextPosition
        FunnelOrientation
        FunnelConnectorMode
        FunnelConnector
        FunnelConstrainText
        FunnelInsideTextAnchor
        FunnelTotalsMarker
        FunnelTotals
        FunnelMarkerLine
        FunnelColorBarMode
        FunnelXAnchor
        FunnelYAnchor
        FunnelTickMode
        FunnelTicks
        FunnelTickLabelOverflow
        FunnelTickLabelPosition
        FunnelTickFormatStops
        FunnelShowTickFix
        FunnelExponentFormat
        FunnelSide
        FunnelTitle
        FunnelColorBar
        FunnelMarker
        FunnelOptions
    ]