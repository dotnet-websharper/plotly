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

module ScatterGLModule =

    open CommonModule

    let ScatterGLModes =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["lines"; "markers"; "text"] '+')
            let seq2 = seq{"none"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ScatterGLModes" generatedEnum

    let ScatterGLHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ScatterGLHoverInfo" generatedEnum

    let ScatterGLMarkerLine =
        Pattern.Config "ScatterGLMarkerLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
                "ScatterGLColor", Color
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "ScatterGLColorscale", ColorScale
                "autoScatterGLColorscale", T<bool>
                "reversescale", T<bool>
                "ScatterGLColoraxis", T<string> // subplotid
            ]
        }

    let ScatterGLMarker =
        Pattern.Config "ScatterGLMarker" {
            Required = []
            Optional = [
                "symbol", Symbol.Type
                "opacity", T<float> + !| T<float>
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "sizeref", (T<float> + T<int>)
                "sizemin", (T<float> + T<int>)
                "sizemode", SizeMode.Type
                "line", ScatterGLMarkerLine.Type
                "ScatterGLColor", Color + !| Color
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "ScatterGLColorscale", ColorScale
                "autoScatterGLColorscale", T<bool>
                "reverscale", T<bool>
                "showscale", T<bool>
                "ScatterGLColorbar", ColorBar.Type
                "ScatterGLColoraxis", T<string> // subplotid
            ]
        }

    let ScatterGLLine =
        Pattern.Config "ScatterGLLine" {
            Required = []
            Optional = [
                "ScatterGLColor", Color
                "width", (T<float> + T<int>)
                "shape", Shape.Type
                "smoothing", (T<float> + T<int>)
                "dash", T<string>
                "simplify", T<bool>
            ]
        }

    let ScatterGLErrorX = 
        Pattern.Config "ScatterGLErrorX" {
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
                "copy_ystyle", T<bool>
                "ScatterGLColor", Color
                "thickness", (T<float> + T<int>)
                "width", (T<float> + T<int>)
            ]
        }

    let ScatterGLErrorY = 
        Pattern.Config "ScatterGLErrorY" {
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
                "ScatterGLColor", Color
                "thickness", (T<float> + T<int>)
                "width", (T<float> + T<int>)
            ]
        }

    let ScatterGLHoverOn =
        let generatedEnum = GenerateOptions.allPermutations ["points"; "fills"] '+'
        Pattern.EnumStrings "ScatterGLHoverOn" generatedEnum


    let ScatterGLOptions =
        Class "ScatterGLOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'scattergl'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", T<float>
            "mode", ScatterGLModes.Type
            "ids", !| T<string>
            "x", !| T<float> + !| T<int>
            "x0", (T<float> + T<int>) + T<string>
            "dx", (T<float> + T<int>)
            "y", !| T<float> + !| T<int>
            "y0", (T<float> + T<int>) + T<string>
            "dy", (T<float> + T<int>)
            "text", T<string> + !| T<string>
            "textposition", TextPositionInline.Type
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", ScatterGLHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "xaxis", T<string> //type is 'subplotid'
            "yaxis", T<string> //type is 'subplotid'
            "orientation", Orientation.Type
            "groupnorm",GroupNorm.Type
            "stackgroup", T<string>
            "xperiod", (T<float> + T<int>) + T<string>
            "xperiodalignment", PeriodAlignment.Type
            "xperiod0", (T<float> + T<int>) + T<string>
            "yperiod", (T<float> + T<int>) + T<string>
            "yperiodalignment", PeriodAlignment.Type
            "yperiod0", (T<float> + T<int>) + T<string>
            "marker", ScatterGLMarker.Type
            "line", ScatterGLLine.Type
            "textfont", Font.Type
            "error_x", ScatterGLErrorX.Type
            "error_y", ScatterGLErrorY.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", SelectedOption.Type
            "unselected", SelectedOption.Type // change name later
            "cliponaxis", T<bool>
            "connectgaps", T<bool>
            "fill", Fill.Type
            "fillScatterGLColor", Color
            "hoverlabel", HoverLabel.Type
            "xcalendar", Calendar.Type
            "ycalendar", Calendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ScatterGLTraceNamespaces : CodeModel.NamespaceEntity list = [
        ScatterGLModes
        ScatterGLHoverInfo
        ScatterGLMarkerLine
        ScatterGLMarker
        ScatterGLLine
        ScatterGLErrorX
        ScatterGLErrorY
        ScatterGLOptions
    ]