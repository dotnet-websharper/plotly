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

module HGModule =

    let HGNullValue = Pattern.EnumInlines "HGNullValue" ["null", "null"]

    let HGColor = T<string> + (T<float> + T<int>) + (!| (!? (HGNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (HGNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let HGColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let HGVisibleString = Pattern.EnumStrings "HGVisibleString" ["legendonly"]

    let HGFont =
        Pattern.Config "HGFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", HGColor
            ]
        }

    let HGLegendGroupTitle =
        Pattern.Config "HGLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", HGFont.Type
            ]
        }

    let HGHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "HGHoverInfo" generatedEnum

    let HGOrientation =
        Pattern.EnumStrings "HGOrientation" [
            "v"
            "h"
        ]

    let HGPeriodAlignment =
        Pattern.EnumStrings "XHGPeriodAlignment" [
            "start"
            "middle"
            "end"
        ]

    let HGMarkerLine =
        Pattern.Config "HGMarkerLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
                "color", HGColor
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", HGColorScale
                "autocolorscale", T<bool>
                "reversescale", T<bool>
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let HGGradientType =
        Pattern.EnumStrings "HGGradientType" [
            "radial"
            "horizontal"
            "vertical"
            "none"
        ]

    let HGGradient =
        Pattern.Config "HGGradient" {
            Required = []
            Optional = [
                "type", HGGradientType.Type
                "color", HGColor + !| HGColor
            ]
        }

    let HGThicknessMode =
        Pattern.EnumStrings "HGThicknessMode" [
            "fraction"
            "pixels"
        ]

    let HGXAnchor =
        Pattern.EnumStrings "HGXAnchor" [
            "left"
            "center"
            "right"
        ]

    let HGYAnchor =
        Pattern.EnumStrings "HGYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let HGTickMode =
        Pattern.EnumStrings "HGTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let HGTicks =
        Pattern.EnumInlines "HGTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let HGTickLabelOverflow =
        Pattern.EnumInlines "HGTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let HGTickLabelPosition =
        Pattern.EnumInlines "HGTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let HGTickFormatStops =
        Pattern.Config "HGTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + HGNullValue.Type) * (DTickValue + HGNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let HGShowTickFix =
        Pattern.EnumStrings "HGShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = HGShowTickFix

    let HGExponentFormat =
        Pattern.EnumInlines "HGExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let HGSide =
        Pattern.EnumStrings "HGSide" [
            "right"
            "top"
            "bottom"
        ]

    let HGTitle =
        Pattern.Config "HGTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", HGFontConfig.Type
                "side", HGSide.Type
            ]
        }

    let HGColorBar =
        Pattern.Config "HGColorBar" {
            Required = []
            Optional = [
                "thicknessmode", HGThicknessMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", HGColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", HGXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", HGYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", HGColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", HGColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", HGColor
                "tickmode", HGTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", HGTicks.Type
                "ticklabeloverflow", HGTickLabelOverflow.Type
                "ticklabelposition", HGTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", HGColor
                "showticklabels", T<bool>
                "tickfont", HGFontConfig.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", HGTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", HGShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", HGShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", HGExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", HGTitle.Type
            ]
        }

    let HGMarkerPatternShape =
        Pattern.EnumInlines "HGMarkerPatternShape" [
            "empty", "''"
            "slash", "'/'"
            "backslash", """'\\'"""
            "x", "'x'"
            "minus", "'-'"
            "pipeline", "'|'"
            "plus", "'+'"
            "dot", "'.'"
        ]

    let HGFillMode =
        Pattern.EnumStrings "HGFillMode" [
            "replace"
            "overlay"
        ]

    let HGMarkerPattern =
        Pattern.Config "HGMarkerPattern" {
            Required = []
            Optional = [
                "shape", HGMarkerPatternShape.Type
                "fillmode", HGFillMode.Type
                "bgcolor", HGColor + !| HGColor
                "fgcolor", HGColor + !| HGColor
                "fgopacity", (T<float> + T<int>)
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "solidity", (T<float> + T<int>) + !| T<float> + !| T<int>               
            ]
        }

    let HGErrorType =
        Pattern.EnumStrings "HGErrorType" [
            "percent"
            "constant"
            "sqrt"
            "data"
        ]

    let HGErrorX = 
        Pattern.Config "HGErrorX" {
            Required = []
            Optional = [
                "visible", T<bool>
                "type", HGErrorType.Type
                "symmetric", T<bool>
                "array", !| T<obj> // data array
                "arrayminus", !| T<obj> // data array
                "value", (T<float> + T<int>)
                "valueminus", (T<float> + T<int>)
                "traceref", T<int>
                "tracerefminus", T<int>
                "copy_ystyle", T<bool>
                "color", HGColor
                "thickness", (T<float> + T<int>)
                "width", (T<float> + T<int>)
            ]
        }

    let HGErrorY = 
        Pattern.Config "HGErrorY" {
            Required = []
            Optional = [
                "visible", T<bool>
                "type", HGErrorType.Type
                "symmetric", T<bool>
                "array", !| T<obj> // data array
                "arrayminus", !| T<obj> // data array
                "value", (T<float> + T<int>)
                "valueminus", (T<float> + T<int>)
                "traceref", T<int>
                "tracerefminus", T<int>
                "color", HGColor
                "thickness", (T<float> + T<int>)
                "width", (T<float> + T<int>)
            ]
        }

    let Marker =
        Pattern.Config "Marker" {
            Required = []
            Optional = [
                "line", HGMarkerLine.Type
                "color", HGColor + !| HGColor
                "cauto", T<bool>
                "cmin", T<int> + T<float>
                "cmax", T<int> + T<float>
                "cmid", T<int> + T<float>
                "colorscale", HGColorScale
                "autocolorscale", T<bool>
                "reversescale", T<bool>
                "showscale", T<bool>
                "colorbar", HGColorBar.Type
                "coloraxis", T<float> + T<int> + T<string>
                "opacity", T<float> + !| T<float>
                "pattern", HGMarkerPattern.Type
            ]
        }

    let HGSelectedMarker =
        Pattern.Config "HGSelectedMarker" {
            Required = []
            Optional = [
                "opacity", (T<float> + T<int>)
                "color", HGColor
                "size", (T<float> + T<int>)
            ]
        }

    let HGSelectedTextFont =
        Pattern.Config "HGSelectedTextFont" {
            Required = []
            Optional = ["color", HGColor]
        }

    let HGSelectedOption =
        Pattern.Config "HGSelectedOption" {
            Required = []
            Optional = [
                "marker", HGSelectedMarker.Type
                "textfont", HGSelectedTextFont.Type
            ]
        }

    let HGAlign =
        Pattern.EnumStrings "HGAlign" [
            "left"
            "right"
            "auto"
        ]

    let HGHoverLabel =
        Pattern.Config "HGHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", HGColor + !| HGColor
                "bordercolor", HGColor + !| HGColor
                "fonts", HGFont.Type
                "align", HGAlign.Type
                "namelength", T<int>
            ]
        }

    let HGCalendar =
        Pattern.EnumStrings "HGCalendar" [
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

    let HGHistFunc =
        Pattern.EnumStrings "HGHistFunc" [
            "count"
            "sum"
            "avg"
            "min"
            "max"
        ]

    let HGHistNorm =
        Pattern.EnumInlines "HGHistNorm" [
            "empty", "''"
            "percent", "'percent'"
            "probability", "'probability'"
            "density", "'density'"
            "probabilityDensity", "'probability density'"
        ]

    let HGXYBins =
        Pattern.Config "HGXYBins" {
            Required = []
            Optional = [
                "start", T<int> + T<float> + T<string>
                "end", T<int> + T<float> + T<string>
                "size", T<int> + T<float> + T<string>
            ]
        }

    let HGDirection =
        Pattern.EnumStrings "HGDirection" [
            "increasing"
            "decreasing"
        ]

    let HGCurrentBin =
        Pattern.EnumStrings "HGCurrentBin" [
            "include"
            "exclude"
            "half"
        ]

    let HGCumulative =
        Pattern.Config "HGCumulative" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "direction", HGDirection.Type
                "currentbin", HGCurrentBin.Type              
            ]
        }

    let HGOptions =
        Class "HGOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'histogram'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + HGVisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", HGLegendGroupTitle.Type
            "opacity", T<float>
            "ids", !| T<string>
            "x", !| T<int> + !| T<float>
            "y", !| T<int> + !| T<float>
            "text", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", HGHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "xaxis", T<string> //type is 'subplotid'
            "yaxis", T<string> //type is 'subplotid'
            "orientation", HGOrientation.Type
            "histfunc", HGHistFunc.Type
            "histnorm", HGHistNorm.Type
            "alignmentgroup", T<string>
            "offsetgroup", T<string>
            "nbinsx", T<int>
            "ybinsx", T<int>
            "autobinx", T<bool>
            "autobiny", T<bool>
            "bingroup", T<string>
            "xbins", HGXYBins.Type
            "ybins", HGXYBins.Type
            "marker", Marker.Type
            "error_x", HGErrorX.Type
            "error_y", HGErrorY.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", HGSelectedOption.Type
            "unselected", HGSelectedOption.Type // change name later
            "cumulative", HGCumulative.Type
            "hoverlabel", HGHoverLabel.Type
            "xcalendar", HGCalendar.Type
            "ycalendar", HGCalendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let HGTraceNamespaces : CodeModel.NamespaceEntity list = [       
        DTickValue
        HGTickLabelPosition
        HGTickLabelOverflow
        HGTicks
        HGTickMode
        HGYAnchor
        HGXAnchor
        HGThicknessMode
        HGFontHGSide
        HGExponentFormat
        HGShowTickFix
        HGTickFormatStops
        HGVisibleString
        HGFont
        HGLegendGroupTitle
        HGHoverInfo
        HGOrientation
        HGPeriodAlignment
        HGMarkerLine
        HGGradientType
        HGMarkerPatternShape
        HGTitle
        HGGradient
        HGFillMode
        Marker
        HGSelectedMarker
        HGSelectedTextFont
        HGSelectedOption
        HGAlign
        HGHoverLabel
        HGCalendar
        HGColorBar
        HGHistFunc
        HGHistNorm
        HGXYBins
        HGDirection
        HGCurrentBin
        HGCumulative
        HGErrorX
        HGErrorY
        HGOptions
    ]