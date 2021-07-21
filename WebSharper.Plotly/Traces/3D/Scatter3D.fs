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

module Scatter3DModule =

    open CommonModule

    let Scatter3DModes =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["lines"; "markers"; "text"] '+')
            let seq2 = seq{"none"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "Scatter3DModes" generatedEnum

    let Scatter3DTextPosition =
        Pattern.EnumInlines "Scatter3DTextPosition" [
            "TopLeft", "'top left'"
            "TopCenter", "'top center'"
            "TopRight", "'top right'"
            "MiddleLeft", "'middle left'"
            "MiddleCenter", "'middle center'"
            "MiddleRight", "'middle right'"
            "BottomLeft", "'bottom left'"
            "BottomCenter", "'bottom center'"
            "BottomRight", "'bottom right'"
        ]

    let Scatter3DHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "Scatter3DHoverInfo" generatedEnum

    let Scatter3DSizeMode =
        Pattern.EnumStrings "Scatter3DSizeMode" [
            "diameter"
            "area"
        ]

    let Scatter3DMarkerLine =
        Pattern.Config "Scatter3DMarkerLine" {
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
                "opacity", T<float>
            ]
        }

    let Scatter3DSymbol =
        Pattern.EnumStrings "Scatter3DSymbol" [
            "circle"
            "circle-open"
            "square"
            "square-open"
            "diamond"
            "diamond-open"
            "cross"
            "x"
        ]

    let Scatter3DMarker =
        Pattern.Config "Scatter3DMarker" {
            Required = []
            Optional = [
                "symbol", Scatter3DSymbol.Type
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "sizeref", (T<float> + T<int>)
                "sizemin", (T<float> + T<int>)
                "sizemode", Scatter3DSizeMode.Type
                "opacity", T<float> + !| T<float>
                "colorbar", ColorBar.Type
                "line", Scatter3DMarkerLine.Type
                "color", Color + !| Color
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", ColorScale
                "autocolorscale", T<bool>
                "reverscale", T<bool>
                "showscale", T<bool>
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let Scatter3DLine =
        Pattern.Config "Scatter3DLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>)
                "dash", T<string>
                "color", Color
                "cauto", T<bool>
                "cmin", T<int> + T<float>
                "cmax", T<int> + T<float>
                "cmid", T<int> + T<float>
                "colorscale", ColorScale
                "autocolorscale", T<bool>
                "reversescale", T<bool>
                "showscale", T<bool>
                "colorbar", ColorBar.Type
                "coloraxis", T<string> //subplotid
            ]
        }

    let Scatter3DErrorX = 
        Pattern.Config "Scatter3DErrorX" {
            Required = []
            Optional = [
                "visible", T<bool>
                "type", ErrorType.Type
                "symmetric", T<bool>
                "array", !| T<obj> // data array
                "arrayminus", !| T<obj> // data array
                "value", (T<float> + T<int>)
                "valueminus", (T<float> + T<int>)
                "traceref", T<int>
                "tracerefminus", T<int>
                "copy_zstyle", T<bool>
                "color", Color
                "thickness", (T<float> + T<int>)
                "width", (T<float> + T<int>)
            ]
        }

    let Scatter3DErrorY = 
        Pattern.Config "Scatter3DErrorY" {
            Required = []
            Optional = [
                "visible", T<bool>
                "type", ErrorType.Type
                "symmetric", T<bool>
                "array", !| T<obj> // data array
                "arrayminus", !| T<obj> // data array
                "value", (T<float> + T<int>)
                "valueminus", (T<float> + T<int>)
                "traceref", T<int>
                "tracerefminus", T<int>
                "copy_zstyle", T<bool>
                "color", Color
                "thickness", (T<float> + T<int>)
                "width", (T<float> + T<int>)
            ]
        }

    let Scatter3DErrorZ = 
        Pattern.Config "Scatter3DErrorZ" {
            Required = []
            Optional = [
                "visible", T<bool>
                "type", ErrorType.Type
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

    let Scatter3DProjectionXYZ =
        Pattern.Config "Scatter3DProjectionXYZ" {
            Required = []
            Optional = [
                "show", T<bool>
                "opacity", T<float>
                "scale", T<int> + T<float>
            ]
        }

    let Scatter3DProjection =
        Pattern.Config "Scatter3DProjection" {
            Required = []
            Optional = [
                "x", Scatter3DProjectionXYZ.Type
                "y", Scatter3DProjectionXYZ.Type
                "z", Scatter3DProjectionXYZ.Type
            ]
        }

    let Scatter3DSurfaceAxis =
        Pattern.EnumStrings "Scatter3DSurfaceAxis" [
            "-1"
            "0"
            "1"
            "2"
        ]

    let Scatter3DOptions =
        Class "Scatter3DOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'scatter3d'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", T<float>
            "mode", Scatter3DModes.Type
            "ids", !| T<string>
            "x", !| T<int> + !| T<float>
            "y", !| T<int> + !| T<float>
            "z", !| T<int> + !| T<float>
            "surfacecolor", Color
            "text", T<string> + !| T<string>
            "textposition", Scatter3DTextPosition.Type
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", Scatter3DHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "scene", T<string> //subplotid
            "marker", Scatter3DMarker.Type
            "line", Scatter3DLine.Type
            "textfont", Font.Type
            "error_x", Scatter3DErrorX.Type
            "error_y", Scatter3DErrorY.Type
            "error_z", Scatter3DErrorZ.Type
            "zhoverformat", T<string>
            "connectgaps", T<bool>
            "hoverlabel", HoverLabel.Type
            "projection", Scatter3DProjection.Type
            "surfaceaxis", Scatter3DSurfaceAxis.Type
            "xcalendar", Calendar.Type
            "ycalendar", Calendar.Type
            "zcalendar", Calendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let Scatter3DTraceNamespaces : CodeModel.NamespaceEntity list = [
        Scatter3DModes
        Scatter3DTextPosition
        Scatter3DHoverInfo
        Scatter3DSizeMode
        Scatter3DMarkerLine
        Scatter3DSymbol
        Scatter3DMarker
        Scatter3DLine
        Scatter3DErrorX
        Scatter3DErrorY
        Scatter3DErrorZ
        Scatter3DProjectionXYZ
        Scatter3DProjection
        Scatter3DSurfaceAxis
        Scatter3DOptions
    ]