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

module IcicleModule =

    open CommonModule

    let IcicleMarkerLine =
        Pattern.Config "IcicleMarkerLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
                "color", Color
            ]
        }

    let IcicleMarker =
        Pattern.Config "IcicleMarker" {
            Required = []
            Optional = [
                "line", IcicleMarkerLine.Type
                "colors", Color + !| Color //data array
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
            ]
        }

    let IcicleBranchValues =
        Pattern.EnumStrings "IcicleBranchValues" [
            "remainder"
            "total"
        ]

    let IcicleCount =
        Pattern.EnumStrings "IcicleCount" [
            "branches"
            "leaves"
            "branches+leaves"
            "leaves+branches"
        ]

    let IcicleLeaf =
        Pattern.Config "IcicleLeaf" {
            Required = []
            Optional = [
                "opacity", T<float>
            ]
        }

    let IcicleTilingFlip =
        Pattern.EnumStrings "IcicleTilingFlip" [
            "x"
            "y"
            "x+y"
            "y+x"
        ]

    let IcicleTiling =
        Pattern.Config "IcicleTiling" {
            Required = []
            Optional = [
                "orientation", Orientation.Type
                "flip", IcicleTilingFlip.Type
                "pad", T<int> + T<float>
            ]
        }

    let IciclePathBarSide =
        Pattern.EnumStrings "IciclePathBarSide" [
            "top"
            "bottom"
        ]

    let IciclePathBarES =
        Pattern.EnumInlines "IciclePathBarES" [
            "greater", "'>'"
            "lower", "'<'"
            "pipeline", "'|'"
            "slash", "'/'"
            "backslash", "'\'" //TODO
        ]

    let IciclePathBar =
        Pattern.Config "IciclePathBar" {
            Required = []
            Optional = [
                "visible", T<bool>
                "side", IciclePathBarSide.Type
                "edgeshape", IciclePathBarES.Type
                "thickness", T<int> + T<float>
                "textfont", Font.Type
            ]
        }

    let IcicleOptions =
        Class "IcicleOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'icicle'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "legendrank", (T<float> + T<int>)
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", T<float>
            "ids", !| T<string>
            "parents", !| T<string> + !| T<int> + !| T<float>
            "values", !| T<string> + !| T<int> + !| T<float>
            "labels", !| T<string> + !| T<int> + !| T<float>
            "text", T<string> + !| T<string>
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", !| T<string> //TODO
            "hovertemplate", T<string> + !| T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", !| T<string> + !| T<int> + !| T<float>
            "domain", Domain.Type
            "marker", IcicleMarker.Type
            "textfont", Font.Type
            "textinfo", !| T<string> //TODO
            "branchvalues", IcicleBranchValues.Type
            "count", IcicleCount.Type
            "tiling", IcicleTiling.Type
            "pathbar", IciclePathBar.Type
            "hoverlabel", HoverLabel.Type
            "insidetextfont", Font.Type
            "outsidetextfont", Font.Type
            "root", Root.Type
            "leaf", IcicleLeaf.Type
            "level", T<int> + T<float> + T<string>
            "maxdepth", T<int>
            "sort", T<bool>
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let IcicleTraceNamespaces : CodeModel.NamespaceEntity list = [
        IcicleMarkerLine
        IcicleMarker
        IcicleBranchValues
        IcicleCount
        IcicleLeaf
        IcicleTilingFlip
        IcicleTiling
        IciclePathBarSide
        IciclePathBarES
        IciclePathBar
        IcicleOptions
    ]