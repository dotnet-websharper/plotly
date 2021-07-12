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

module BarModule =

    let BarVisibleString = Pattern.EnumStrings "BarVisibleString" ["legendonly"]

    let BarNullValue = Pattern.EnumInlines "BarNullValue" ["null", "null"]

    let BarColor = T<string> + (T<float> + T<int>) + (!| (!? (BarNullValue.Type + T<string> + (T<float> + T<int>)))) + (!| (!| ((!? (BarNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let BarColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let BarFontConfig =
        Pattern.Config "BarFontConfig" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "BarColor", BarColor
            ]
        }

    let BarLegendGroupTitle =
        Pattern.Config "BarLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "BarFont", BarFontConfig.Type
            ]
        }

    let BarTextPosition =
        Pattern.EnumStrings "BarTextPosition" [
            "inside"
            "outside"
            "auto"
            "none"
        ]    
            
    let BarHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "BarHoverInfo" generatedEnum
    
    let BarOrientation =
        Pattern.EnumStrings "BarOrientation" [
            "v"
            "h"
        ]

    let BarPeriodAlignment =
        Pattern.EnumStrings "BarPeriodAlignment" [
            "start"
            "middle"
            "end"
        ]

    let BarMarkerLine =
        Pattern.Config "BarMarkerLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
                "BarColor", BarColor
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "BarColorscale", BarColorScale
                "autoBarColorscale", T<bool>
                "reversescale", T<bool>
                "BarColoraxis", T<string> // type: subplotid
            ]
        }

    let BarColorMode =
        Pattern.EnumStrings "ThicknessMode" [
            "fraction"
            "pixels"
        ]

    let BarXAnchor =
        Pattern.EnumStrings "BarXAnchor" [
            "left"
            "center"
            "right"
        ]

    let BarYAnchor =
        Pattern.EnumStrings "BarYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let BarTickMode =
        Pattern.EnumStrings "BarTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let BarTicks =
        Pattern.EnumInlines "BarTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let BarTickLabelOverflow =
        Pattern.EnumInlines "BarTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let BarTickLabelPosition =
        Pattern.EnumInlines "BarTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let BarTickFormatStops =
        Pattern.Config "BarTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + BarNullValue.Type) * (DTickValue + BarNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let BarShowTickFix =
        Pattern.EnumStrings "BarShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let BarShowExponent = BarShowTickFix

    let BarExponentFormat =
        Pattern.EnumInlines "BarExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let BarSide =
        Pattern.EnumStrings "BarSide" [
            "right"
            "top"
            "bottom"
        ]

    let BarTitle =
        Pattern.Config "BarTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "BarFont", BarFontConfig.Type
                "side", BarSide.Type
            ]
        }

    let BarColorBar =
        Pattern.Config "BarColorBar" {
            Required = []
            Optional = [
                "thicknessmode", BarColorMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", BarColorMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "BarXAnchor", BarXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "BarYAnchor", BarYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlineBarColor", BarColor
                "outlinewidth", (T<float> + T<int>)
                "borderBarColor", BarColor
                "borderwidth", (T<float> + T<int>)
                "bgBarColor", BarColor
                "BarTickMode", BarTickMode.Type
                "nBarTicks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "BarTicks", BarTicks.Type
                "BarTickLabelOverflow", BarTickLabelOverflow.Type
                "BarTickLabelPosition", BarTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickBarColor", BarColor
                "showticklabels", T<bool>
                "tickBarFont", BarFontConfig.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "BarTickFormatStops", BarTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", BarShowTickFix.Type
                "BarTicksuffix", T<string>
                "showBarTicksuffix", BarShowTickFix.Type
                "separatethousands", T<bool>
                "BarExponentFormat", BarExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "BarShowExponent", BarShowExponent.Type // change type name to fit
                "BarTitle", BarTitle.Type
            ]
        }

    let BarMarkerPatternShape =
        Pattern.EnumInlines "BarMarkerPatternShape" [
            "empty", "''"
            "slash", "'/'"
            "backslash", """'\\'"""
            "x", "'x'"
            "minus", "'-'"
            "pipeline", "'|'"
            "plus", "'+'"
            "dot", "'.'"
        ]

    let BarFillMode =
        Pattern.EnumStrings "BarFillMode" [
            "replace"
            "overlay"
        ]

    let BarMarkerPattern =
        Pattern.Config "BarMarkerPattern" {
            Required = []
            Optional = [
                "shape", BarMarkerPatternShape.Type
                "BarFillMode", BarFillMode.Type
                "bgBarColor", BarColor + !| BarColor
                "fgBarColor", BarColor + !| BarColor
                "fgopacity", (T<float> + T<int>)
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "solidity", (T<float> + T<int>) + !| T<float> + !| T<int>               
            ]
        }

    let BarMarker =
        Pattern.Config "BarMarker" {
            Required = []
            Optional = [
                "line", BarMarkerLine.Type
                "BarColor", BarColor + !| BarColor
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "BarColorscale", BarColorScale
                "autoBarColorscale", T<bool>
                "reverscale", T<bool>
                "showscale", T<bool>
                "BarColorbar", BarColorBar.Type
                "BarColoraxis", T<string> // type: subplotid
                "opacity", (T<float> + T<int>)
                "pattern", BarMarkerPattern.Type
            ]
        }

    let BarErrorType =
        Pattern.EnumStrings "BarErrorXType" [
            "percent"
            "constant"
            "sqrt"
            "data"
        ]

    let BarErrorX = 
        Pattern.Config "BarErrorX" {
            Required = []
            Optional = [
                "visible", T<bool>
                "type", BarErrorType.Type
                "symmetric", T<bool>
                "array", !| T<obj> // data array
                "arrayminus", !| T<obj> // data array
                "value", (T<float> + T<int>)
                "valueminus", (T<float> + T<int>)
                "traceref", T<int>
                "tracerefminus", T<int>
                "copy_ystyle", T<bool>
                "BarColor", BarColor
                "thickness", (T<float> + T<int>)
                "width", (T<float> + T<int>)
            ]
        }

    let BarErrorY = 
        Pattern.Config "BarErrorY" {
            Required = []
            Optional = [
                "visible", T<bool>
                "type", BarErrorType.Type
                "symmetric", T<bool>
                "array", !| T<obj> // data array
                "arrayminus", !| T<obj> // data array
                "value", (T<float> + T<int>)
                "valueminus", (T<float> + T<int>)
                "traceref", T<int>
                "tracerefminus", T<int>
                "BarColor", BarColor
                "thickness", (T<float> + T<int>)
                "width", (T<float> + T<int>)
            ]
        }

    let BarSelectedMarker =
        Pattern.Config "BarSelectedMarker" {
            Required = []
            Optional = [
                "opacity", (T<float> + T<int>)
                "BarColor", BarColor
                "size", (T<float> + T<int>)
            ]
        }

    let BarSelectedTextFont =
        Pattern.Config "BarSelectedTextFont" {
            Required = []
            Optional = ["BarColor", BarColor]
        }

    let BarSelectedOption =
        Pattern.Config "Selected" {
            Required = []
            Optional = [
                "BarMarker",  BarSelectedMarker.Type
                "textBarFont",  BarSelectedTextFont.Type
            ]
        }

    let BarConstrainText = 
        Pattern.EnumStrings "BarConstrainText" [
            "inside"
            "outside"
            "both"
            "none"
        ]

    let BarAlign =
        Pattern.EnumStrings "BarAlign" [
            "left"
            "right"
            "auto"
        ]

    let BarHoverLabel =
        Pattern.Config "BarHoverLabel" {
            Required = []
            Optional = [
                "bgBarColor", BarColor + !| BarColor
                "borderBarColor", BarColor + !| BarColor
                "BarFonts", BarFontConfig.Type
                "align", BarAlign.Type
                "namelength", T<int>
            ]
        }

    let BarTextAnchor =
        Pattern.EnumStrings "BarTextAnchor" [
            "end"
            "middle"
            "start"
        ]

    let BarCalendar =
        Pattern.EnumStrings "BarCalendar" [
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

    let BarOptions =
        Class "BarOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type: 'bar'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + BarVisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "BarLegendGroupTitle", BarLegendGroupTitle.Type
            "opacity", (T<float> + T<int>)
            "ids", !| T<string> //data array
            "x", !| T<float> + !| T<int> + !| T<string> //data array
            "x0", (T<float> + T<int>) + T<string>
            "dx", (T<float> + T<int>)
            "y", !| T<float> + !| T<int> //data array
            "y0", (T<float> + T<int>) + T<string>
            "dy", (T<float> + T<int>)
            "base", (T<float> + T<int>) + T<string>
            "width", (T<float> + T<int>) + !| T<float> + !| T<int>
            "offset", (T<float> + T<int>) + (T<float> + T<int>)
            "text", T<string> + !| T<string>
            "BarTextPosition", BarTextPosition.Type
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "BarHoverInfo", BarHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", !| T<string> //data array
            "xaxis", T<string> //subplotid
            "yaxis", T<string> //subplotid
            "BarOrientation", BarOrientation.Type
            "alignmentgroup", T<string>
            "offsetgroup", T<string>
            "xperiod", (T<float> + T<int>) + T<string>
            "xBarPeriodAlignment", BarPeriodAlignment.Type
            "xperiod0", (T<float> + T<int>) + T<string>
            "yperiod", (T<float> + T<int>) + T<string>
            "yBarPeriodAlignment", BarPeriodAlignment.Type
            "yperiod0", (T<float> + T<int>) + T<string>
            "BarMarker", BarMarker.Type
            "textangle", (T<float> + T<int>) //angle
            "textBarFont", BarFontConfig.Type
            "error_x",  BarErrorX.Type
            "error_y",  BarErrorY.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", BarSelectedOption.Type
            "unselected", BarSelectedOption.Type
            "cliponaxis", T<bool>
            "BarConstrainText",  BarConstrainText.Type
            "BarHoverLabel",  BarHoverLabel.Type
            "inside BarTextAnchor",  BarTextAnchor.Type
            "insidetextBarFont", BarFontConfig.Type
            "outsidetextBarFont", BarFontConfig.Type
            "x BarCalendar",  BarCalendar.Type
            "y BarCalendar",  BarCalendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let BarTraceNamespaces : CodeModel.NamespaceEntity list = [
        BarVisibleString
        BarFontConfig
        BarLegendGroupTitle
        BarTextPosition
        BarHoverInfo
        BarOrientation
        BarPeriodAlignment
        BarMarkerLine
        BarColorMode
        BarXAnchor
        BarYAnchor
        BarTickMode
        BarTicks
        BarTickLabelOverflow
        BarTickLabelPosition
        BarTickFormatStops
        BarShowTickFix
        BarExponentFormat
        BarSide
        BarTitle
        BarColorBar
        BarMarkerPatternShape
        BarFillMode
        BarMarkerPattern
        BarMarker
        BarErrorType
        BarErrorX
        BarErrorY
        BarSelectedMarker
        BarSelectedTextFont
        BarSelectedOption
        BarConstrainText
        BarAlign
        BarHoverLabel
        BarTextAnchor
        BarCalendar
        BarOptions
    ]
