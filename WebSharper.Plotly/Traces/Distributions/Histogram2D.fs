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

module HG2DModule =

    open CommonModule

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
                "color", Color + !| Color
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
                "bgcolor", Color + !| Color
                "fgcolor", Color + !| Color
                "fgopacity", (T<float> + T<int>)
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "solidity", (T<float> + T<int>) + !| T<float> + !| T<int>               
            ]
        }

    let HG2DMarker =
        Pattern.Config "HG2DMarker" {
            Required = []
            Optional = [
                "color", Color + !| Color //data array
            ]
        }

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
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'histogram2d'}"
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
            "colorbar", ColorBar.Type
            "autocolorscale", T<bool>
            "colorscale",ColorScale
            "showscale", T<bool>
            "reversescale", T<bool>
            "zauto", T<bool>
            "zhoverformat", T<string>
            "zmax", T<int> + T<float>
            "zmid", T<int> + T<float>
            "zmin", T<int> + T<float>
            "zsmooth", HG2DZSmooth.Type + T<bool>
            "hoverlabel", HoverLabel.Type
            "xcalendar", Calendar.Type
            "ycalendar",Calendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let HG2DTraceNamespaces : CodeModel.NamespaceEntity list = [       
        HG2DHoverInfo
        HG2DGradientType
        HG2DGradient
        HG2DMarkerPatternShape
        HG2DFillMode
        HG2DMarkerPattern
        HG2DMarker
        HG2DHistFunc
        HG2DHistNorm
        HG2DXYBins
        HG2DZSmooth
        HG2DOptions
    ]