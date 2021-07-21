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

module BarPolarModule =

    open CommonModule

    let BarPolarModes =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["lines"; "markers"; "text"] '+')
            let seq2 = seq{"none"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "BarPolarModes" generatedEnum

    let BarPolarHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["r"; "thetea"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "BarPolarHoverInfo" generatedEnum

    let BarPolarMarkerLine =
        Pattern.Config "BarPolarMarkerLine" {
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

    let BarPolarMarkerPatternShape =
        Pattern.EnumInlines "BarPolarMarkerPatternShape" [
            "empty", "''"
            "slash", "'/'"
            "backslash", """'\\'"""
            "x", "'x'"
            "minus", "'-'"
            "pipeline", "'|'"
            "plus", "'+'"
            "dot", "'.'"
        ]

    let BarPolarFillMode =
        Pattern.EnumStrings "BarPolarFillMode" [
            "replace"
            "overlay"
        ]

    let BarPolarMarkerPattern =
        Pattern.Config "BarPolarMarkerPattern" {
            Required = []
            Optional = [
                "shape", BarPolarMarkerPatternShape.Type
                "fillmode", BarPolarFillMode.Type
                "bgcolor", Color + !| Color
                "fgcolor", Color + !| Color
                "fgopacity", (T<float> + T<int>)
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "solidity", (T<float> + T<int>) + !| T<float> + !| T<int>               
            ]
        }

    let BarPolarMarker =
        Pattern.Config "BarPolarMarker" {
            Required = []
            Optional = [
                "opacity", T<float> + !| T<float>
                "line", BarPolarMarkerLine.Type
                "color", Color + !| Color
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", ColorScale
                "autocolorscale", T<bool>
                "reverscale", T<bool>
                "showscale", T<bool>
                "colorbar", ColorBar.Type
                "coloraxis", T<string> // type: subplotid
                "pattern", BarPolarMarkerPattern.Type
            ]
        }

    let BarPolarSelectedMarker =
        Pattern.Config "BarPolarSelectedMarker" {
            Required = []
            Optional = [
                "opacity", (T<float> + T<int>)
                "color", Color
                "size", (T<float> + T<int>)
            ]
        }

    let BarPolarSelectedTextFont =
        Pattern.Config "BarPolarSelectedTextFont" {
            Required = []
            Optional = ["color", Color]
        }

    let BarPolarSelectedOption =
        Pattern.Config "BarPolarSelectedOption" {
            Required = []
            Optional = [
                "marker", BarPolarSelectedMarker.Type
                "textfont", BarPolarSelectedTextFont.Type
            ]
        }

    let BarPolarFill =
        Pattern.EnumStrings "BarPolarFill" [
            "none"
            "tozeroy"
            "tozerox"
            "tonexty"
            "tonextx"
            "toself"
            "tonext"
        ]

    let BarPolarThetaUnit =
        Pattern.EnumStrings "BarPolarThetaUnit" [
            "radians"
            "degrees"
            "gradians"
        ]

    let BarPolarOptions =
        Class "BarPolarOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'BarPolar'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", T<float>
            "mode", BarPolarModes.Type
            "ids", !| T<string>
            "base", T<int> + T<float> + T<string>
            "r", !| T<int> + !| T<float>
            "r0", (T<float> + T<int>) + T<string>
            "dr", (T<float> + T<int>)
            "theta", !| T<int> + !| T<float>
            "theta0", (T<float> + T<int>) + T<string>
            "dtheta", (T<float> + T<int>)
            "thetaunit", BarPolarThetaUnit.Type
            "width", T<int> + T<float> + !| T<int> + !| T<float>
            "offset", T<int> + T<float> + !| T<int> + !| T<float>
            "text", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", BarPolarHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "subplot", T<string> //type is 'subplotid'
            "marker", BarPolarMarker.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", BarPolarSelectedOption.Type
            "unselected", BarPolarSelectedOption.Type // change name later
            "hoverlabel", HoverLabel.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let BarPolarTraceNamespaces : CodeModel.NamespaceEntity list = [
        BarPolarModes
        BarPolarHoverInfo
        BarPolarMarkerLine
        BarPolarMarkerPatternShape
        BarPolarFillMode
        BarPolarMarkerPattern
        BarPolarMarker
        BarPolarSelectedMarker
        BarPolarSelectedTextFont
        BarPolarSelectedOption
        BarPolarFill
        BarPolarThetaUnit
        BarPolarOptions
    ]