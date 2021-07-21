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

module ContourCarpetModule =

    open CommonModule

    let ContourCarpetLine =
        Pattern.Config "ContourCarpetLine" {
            Required = []
            Optional = [
                "color", Color
                "width", (T<float> + T<int>)
                "shape", Shape.Type
                "smoothing", (T<float> + T<int>)
                "dash", T<string>
                "simplify", T<bool>
            ]
        }

    let ContourCarpetsType =
        Pattern.EnumStrings "ContourCarpetsType" [
            "levels"
            "constraint"
        ]

    let ContourCarpetColoring = 
        Pattern.EnumStrings "ContourCarpetColoring" [
            "fill"
            "heatmap"
            "lines"
            "none"
        ]

    let ContourCarpetContours =
        Pattern.Config "ContourCarpetContours" {
            Required = []
            Optional = [
                "type", ContourCarpetsType.Type
                "start", T<int> + T<float>
                "end", T<int> + T<float>
                "size", T<int> + T<float>
                "coloring", ContourCarpetColoring.Type
                "showlines", T<bool>
                "labelfont", Font.Type
                "labelformat", T<string>
                "operation", Operation.Type
                "value", T<int> + T<float> + T<string>
            ]
        }

    let ContourCarpetOptions =
        Class "ContourCarpetOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'contourcarpet'}"
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
            "z", !| T<string> + !| T<int> + !| T<float>
            "a", !| T<string> + !| T<int> + !| T<float>
            "atype", XYType.Type
            "a0", T<int> + T<float> + T<string>
            "da", T<int> + T<float>
            "b", !| T<string> + !| T<int> + !| T<float>
            "btype", XYType.Type
            "b0", T<int> + T<float> + T<string>
            "db", T<int> + T<float>
            "text", !| T<string> + !| T<int> + !| T<float>
            "hovertext", !| T<string> + !| T<int> + !| T<float>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "xaxis", T<string> //type is 'subplotid'            
            "yaxis", T<string> //type is 'subplotid'
            "coloraxis", T<string> //type is 'subplotid'
            "line", ContourCarpetLine.Type
            "colorbar", ColorBar.Type
            "autocolorscale", T<bool>
            "colorscale", ColorScale
            "showscale", T<bool>
            "reversescale", T<bool>
            "zauto", T<bool>
            "zmax", T<int> + T<float>
            "zmid", T<int> + T<float>
            "zmin", T<int> + T<float>
            "autocontour", T<bool>
            "carpet", T<string>
            "contours", ContourCarpetContours.Type
            "fillcolor", Color
            "ncontours", T<int>
            "transpose", T<bool>
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ContourCarpetTraceNamespaces : CodeModel.NamespaceEntity list = [
        ContourCarpetLine
        ContourCarpetsType
        ContourCarpetColoring
        ContourCarpetContours
        ContourCarpetOptions
    ]