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

module HG2DModule =

    let HG2DNullValue = Pattern.EnumInlines "HG2DNullValue" ["null", "null"]

    let HG2DColor = T<string> + (T<float> + T<int>) + (!| (!? (HG2DNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (HG2DNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let HG2DColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let HG2DVisibleString = Pattern.EnumStrings "HG2DVisibleString" ["legendonly"]

    let HG2DFont =
        Pattern.Config "HG2DFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", HG2DColor
            ]
        }

    let HG2DLegendGroupTitle =
        Pattern.Config "HG2DLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", HG2DFont.Type
            ]
        }

    let HG2DHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "HG2DHoverInfo" generatedEnum

    let HG2DGradientType =
        Pattern.EnumStrings "HG2DGradientType" [
            "radial"
            "horizontal"
            "vertical"
            "none"
        ]

    let HG2DGradient =
        Pattern.Config "HG2DGradient" {
            Required = []
            Optional = [
                "type", HG2DGradientType.Type
                "color", HG2DColor + !| HG2DColor
            ]
        }

    let HG2DThicknessMode =
        Pattern.EnumStrings "HG2DThicknessMode" [
            "fraction"
            "pixels"
        ]

    let HG2DXAnchor =
        Pattern.EnumStrings "HG2DXAnchor" [
            "left"
            "center"
            "right"
        ]

    let HG2DYAnchor =
        Pattern.EnumStrings "HG2DYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let HG2DTickMode =
        Pattern.EnumStrings "HG2DTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let HG2DTicks =
        Pattern.EnumInlines "HG2DTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let HG2DTickLabelOverflow =
        Pattern.EnumInlines "HG2DTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let HG2DTickLabelPosition =
        Pattern.EnumInlines "HG2DTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let HG2DTickFormatStops =
        Pattern.Config "HG2DTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + HG2DNullValue.Type) * (DTickValue + HG2DNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let HG2DShowTickFix =
        Pattern.EnumStrings "HG2DShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = HG2DShowTickFix

    let HG2DExponentFormat =
        Pattern.EnumInlines "HG2DExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let HG2DSide =
        Pattern.EnumStrings "HG2DSide" [
            "right"
            "top"
            "bottom"
        ]

    let HG2DTitle =
        Pattern.Config "HG2DTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", HG2DFont.Type
                "side", HG2DSide.Type
            ]
        }

    let HG2DColorBar =
        Pattern.Config "HG2DColorBar" {
            Required = []
            Optional = [
                "thicknessmode", HG2DThicknessMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", HG2DThicknessMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", HG2DXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", HG2DYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", HG2DColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", HG2DColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", HG2DColor
                "tickmode", HG2DTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", HG2DTicks.Type
                "ticklabeloverflow", HG2DTickLabelOverflow.Type
                "ticklabelposition", HG2DTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", HG2DColor
                "showticklabels", T<bool>
                "tickfont", HG2DFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", HG2DTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", HG2DShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", HG2DShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", HG2DExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", HG2DTitle.Type
            ]
        }

    let HG2DMarkerPatternShape =
        Pattern.EnumInlines "HG2DMarkerPatternShape" [
            "empty", "''"
            "slash", "'/'"
            "backslash", """'\\'"""
            "x", "'x'"
            "minus", "'-'"
            "pipeline", "'|'"
            "plus", "'+'"
            "dot", "'.'"
        ]

    let HG2DFillMode =
        Pattern.EnumStrings "HG2DFillMode" [
            "replace"
            "overlay"
        ]

    let HG2DMarkerPattern =
        Pattern.Config "HG2DMarkerPattern" {
            Required = []
            Optional = [
                "shape", HG2DMarkerPatternShape.Type
                "fillmode", HG2DFillMode.Type
                "bgcolor", HG2DColor + !| HG2DColor
                "fgcolor", HG2DColor + !| HG2DColor
                "fgopacity", (T<float> + T<int>)
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "solidity", (T<float> + T<int>) + !| T<float> + !| T<int>               
            ]
        }

    let HG2DMarker =
        Pattern.Config "HG2DMarker" {
            Required = []
            Optional = [
                "color", HG2DColor + !| HG2DColor //data array
            ]
        }

    let HG2DAlign =
        Pattern.EnumStrings "HG2DAlign" [
            "left"
            "right"
            "auto"
        ]

    let HG2DHoverLabel =
        Pattern.Config "HG2DHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", HG2DColor + !| HG2DColor
                "bordercolor", HG2DColor + !| HG2DColor
                "fonts", HG2DFont.Type
                "align", HG2DAlign.Type
                "namelength", T<int>
            ]
        }

    let HG2DCalendar =
        Pattern.EnumStrings "HG2DCalendar" [
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

    let HG2DHistFunc =
        Pattern.EnumStrings "HG2DHistFunc" [
            "count"
            "sum"
            "avg"
            "min"
            "max"
        ]

    let HG2DHistNorm =
        Pattern.EnumInlines "HG2DHistNorm" [
            "empty", "''"
            "percent", "'percent'"
            "probability", "'probability'"
            "density", "'density'"
            "probabilityDensity", "'probability density'"
        ]

    let HG2DXYBins =
        Pattern.Config "HG2DXYBins" {
            Required = []
            Optional = [
                "start", T<int> + T<float> + T<string>
                "end", T<int> + T<float> + T<string>
                "size", T<int> + T<float> + T<string>
            ]
        }

    let HG2DZSmooth =
        Pattern.EnumStrings "HG2DZSmooth" [
            "fast"
            "best"
        ]

    let HG2DOptions =
        Class "HG2DOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'histogram2d'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + HG2DVisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", HG2DLegendGroupTitle.Type
            "opacity", T<float>
            "ids", !| T<string>
            "x", !| T<int> + !| T<float>
            "xgap", T<int> + T<float>
            "y", !| T<int> + !| T<float>
            "ygap", T<int> + T<float>
            "z", !| T<int> + !| T<float> + !| T<string>
            "hoverinfo", HG2DHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "xaxis", T<string> //type is 'subplotid'
            "yaxis", T<string> //type is 'subplotid'
            "coloraxis", T<string> //type is 'subplotid'
            "histfunc", HG2DHistFunc.Type
            "histnorm", HG2DHistNorm.Type
            "nbinsx", T<int>
            "ybinsx", T<int>
            "autobinx", T<bool>
            "autobiny", T<bool>
            "bingroup", T<string>
            "xbingroup", T<string>
            "xbins", HG2DXYBins.Type
            "ybingroup", T<string>
            "ybins", HG2DXYBins.Type
            "marker", HG2DMarker.Type
            "colorbar", HG2DColorBar.Type
            "autocolorscale", T<bool>
            "colorscale", HG2DColorScale
            "showscale", T<bool>
            "reversescale", T<bool>
            "zauto", T<bool>
            "zhoverformat", T<string>
            "zmax", T<int> + T<float>
            "zmid", T<int> + T<float>
            "zmin", T<int> + T<float>
            "zsmooth", HG2DZSmooth.Type + T<bool>
            "hoverlabel", HG2DHoverLabel.Type
            "xcalendar", HG2DCalendar.Type
            "ycalendar", HG2DCalendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let HG2DTraceNamespaces : CodeModel.NamespaceEntity list = [       
        HG2DNullValue
        HG2DVisibleString
        HG2DFont
        HG2DLegendGroupTitle
        HG2DHoverInfo
        HG2DGradientType
        HG2DGradient
        HG2DThicknessMode
        HG2DXAnchor
        HG2DYAnchor
        HG2DTickMode
        HG2DTicks
        HG2DTickLabelOverflow
        HG2DTickLabelPosition
        HG2DTickFormatStops
        HG2DShowTickFix
        HG2DExponentFormat
        HG2DSide
        HG2DTitle
        HG2DColorBar
        HG2DMarkerPatternShape
        HG2DFillMode
        HG2DMarkerPattern
        HG2DMarker
        HG2DAlign
        HG2DHoverLabel
        HG2DCalendar
        HG2DHistFunc
        HG2DHistNorm
        HG2DXYBins
        HG2DZSmooth
        HG2DOptions
    ]