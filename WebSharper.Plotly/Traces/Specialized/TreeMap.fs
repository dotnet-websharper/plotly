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

module TreeMapModule =

    open CommonModule

    let TreeMapMarkerLine =
        Pattern.Config "TreeMapMarkerLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
                "color", Color
            ]
        }

    let TreeMapMarkerDepthFade =
        Pattern.EnumStrings "TreeMapMarkerDepthFade" [
            "reversed"
        ]

    let TreeMapMarker =
        Pattern.Config "TreeMapMarker" {
            Required = []
            Optional = [
                "pad", Pad.Type
                "colors", Color + !| Color //data array
                "depthfade", T<bool> + TreeMapMarkerDepthFade.Type
                "line", TreeMapMarkerLine.Type
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", ColorScale
                "autocolorscale", T<bool>
                "reverscale", T<bool>
                "showscale", T<bool>
                "colorbar", ColorBar.Type
                "coloraxis", T<string> // subplotid
            ]
        }

    let TreeMapTilingPacking =
        Pattern.EnumStrings "TreeMapTilingPacking" [
            "squarify"
            "binary"
            "dice"
            "slice"
            "slice-dice"
            "dice-slice"
        ]

    let TreeMapTilingFlip =
        Pattern.EnumStrings "TreeMapTilingFlip" [
            "x"
            "y"
            "x+y"
            "y+x"
        ]

    let TreeMapTiling =
        Pattern.Config "TreeMapTiling" {
            Required = []
            Optional = [
                "packing", TreeMapTilingPacking.Type
                "squarifyratio", T<int> + T<float>
                "flip", TreeMapTilingFlip.Type
                "pad", T<int> + T<float>
            ]
        }

    let TreeMapPathBarSide =
        Pattern.EnumStrings "TreeMapPathBarSide" [
            "top"
            "bottom"
        ]

    let TreeMapPathBar =
        Pattern.Config "TreeMapPathBar" {
            Required = []
            Optional = [
                "visible", T<bool>
                "side", TreeMapPathBarSide.Type
                "edgeshape", EdgeShape.Type
                "thickness", T<int> + T<float>
                "textfont", Font.Type
            ]
        }

    let TreeMapOptions =
        Class "TreeMapOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'treemap'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", T<float>
            "ids", !| T<string>
            "parents", !| T<string> + !| T<int> + !| T<float>
            "values", !| T<string> + !| T<int> + !| T<float>
            "labels", !| T<string> + !| T<int> + !| T<float>
            "text", T<string> + !| T<string>
            "textposition", TextPositionInline.Type
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", !| T<string> //TODO
            "hovertemplate", T<string> + !| T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", !| T<string> + !| T<int> + !| T<float>
            "domain", Domain.Type
            "marker", TreeMapMarker.Type
            "textfont", Font.Type
            "textinfo", !| T<string> //TODO
            "branchvalues", BranchValues.Type
            "count", Count.Type
            "tiling", TreeMapTiling.Type
            "pathbar", TreeMapPathBar.Type
            "hoverlabel", HoverLabel.Type
            "insidetextfont", Font.Type
            "outsidetextfont", Font.Type
            "root", Root.Type
            "level", T<int> + T<float> + T<string>
            "maxdepth", T<int>
            "sort", T<bool>
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let TreeMapTraceNamespaces : CodeModel.NamespaceEntity list = [
        TreeMapMarkerLine
        TreeMapMarkerDepthFade
        TreeMapMarker
        TreeMapTilingPacking
        TreeMapTilingFlip
        TreeMapTiling
        TreeMapPathBarSide
        TreeMapPathBar
        TreeMapOptions
    ]