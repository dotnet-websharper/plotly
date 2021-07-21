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

module SunBurstModule =

    open CommonModule

    let SunBurstMarkerLine =
        Pattern.Config "SunBurstMarkerLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
                "color", Color
            ]
        }

    let SunBurstMarker =
        Pattern.Config "SunBurstMarker" {
            Required = []
            Optional = [
                "line", SunBurstMarkerLine.Type
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

    let SunBurstBranchValues =
        Pattern.EnumStrings "SunBurstBranchValues" [
            "remainder"
            "total"
        ]

    let SunBurstCount =
        Pattern.EnumStrings "SunBurstCount" [
            "branches"
            "leaves"
            "branches+leaves"
            "leaves+branches"
        ]    

    let SunBurstLeaf =
        Pattern.Config "SunBurstLeaf" {
            Required = []
            Optional = [
                "opacity", T<float>
            ]
        }

    let SunBurstOptions =
        Class "SunBurstOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'sunburst'}"
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
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", !| T<string> //TODO
            "hovertemplate", T<string> + !| T<string>
            "meta", (T<float> + T<int>) + T<string>
            "domain", Domain.Type
            "marker", SunBurstMarker.Type
            "textfont", Font.Type
            "textinfo", !| T<string> //TODO
            "branchvalues", SunBurstBranchValues.Type
            "count", SunBurstCount.Type
            "hoverlabel", HoverLabel.Type
            "insidetextfont", Font.Type
            "insidetextorientation", TextOrientation.Type
            "outsidetextfont", Font.Type
            "root", Root.Type
            "leaf", SunBurstLeaf.Type
            "level", T<int> + T<float> + T<string>
            "maxdepth", T<int>
            "rotation", T<int> + T<float>
            "sort", T<bool>
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let SunBurstTraceNamespaces : CodeModel.NamespaceEntity list = [
        SunBurstMarkerLine
        SunBurstMarker
        SunBurstBranchValues
        SunBurstCount
        SunBurstLeaf
        SunBurstOptions
    ]