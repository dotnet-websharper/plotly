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

module HGModule =

    open CommonModule

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
                "color", Color + !| Color
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
                "bgcolor", Color + !| Color
                "fgcolor", Color + !| Color
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
                "color", Color
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
                "color", Color
                "thickness", (T<float> + T<int>)
                "width", (T<float> + T<int>)
            ]
        }

    let HGMarker =
        Pattern.Config "HGMarker" {
            Required = []
            Optional = [
                "line", HGMarkerLine.Type
                "color", Color + !| Color
                "cauto", T<bool>
                "cmin", T<int> + T<float>
                "cmax", T<int> + T<float>
                "cmid", T<int> + T<float>
                "colorscale", ColorScale
                "autocolorscale", T<bool>
                "reversescale", T<bool>
                "showscale", T<bool>
                "colorbar", ColorBar.Type
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
                "color", Color
                "size", (T<float> + T<int>)
            ]
        }

    let HGSelectedTextFont =
        Pattern.Config "HGSelectedTextFont" {
            Required = []
            Optional = ["color", Color]
        }

    let HGSelectedOption =
        Pattern.Config "HGSelectedOption" {
            Required = []
            Optional = [
                "marker", HGSelectedMarker.Type
                "textfont", HGSelectedTextFont.Type
            ]
        }

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
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'histogram'}"
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
            "marker", HGMarker.Type
            "error_x", HGErrorX.Type
            "error_y", HGErrorY.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", HGSelectedOption.Type
            "unselected", HGSelectedOption.Type // change name later
            "cumulative", HGCumulative.Type
            "hoverlabel", HoverLabel.Type
            "xcalendar", Calendar.Type
            "ycalendar", Calendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let HGTraceNamespaces : CodeModel.NamespaceEntity list = [       
        HGHoverInfo
        HGOrientation
        HGPeriodAlignment
        HGMarkerLine
        HGGradientType
        HGMarkerPatternShape
        HGMarkerPattern
        HGGradient
        HGFillMode
        HGMarker
        HGSelectedMarker
        HGSelectedTextFont
        HGSelectedOption
        HGHistFunc
        HGHistNorm
        HGXYBins
        HGDirection
        HGCurrentBin
        HGCumulative
        HGErrorType
        HGErrorX
        HGErrorY
        HGOptions
    ]