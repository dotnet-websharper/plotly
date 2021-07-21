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

module ScatterModule =

    open CommonModule

    let ScatterModes =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["lines"; "markers"; "text"] '+')
            let seq2 = seq{"none"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ScatterModes" generatedEnum

    let ScatterHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ScatterHoverInfo" generatedEnum    

    let ScatterMarkerLine =
        Pattern.Config "ScatterMarkerLine" {
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
                "coloraxis", T<string> // subplotid
            ]
        }

    let ScatterMarker =
        Pattern.Config "ScatterMarker" {
            Required = []
            Optional = [
                "symbol", Symbol.Type
                "opacity", T<float> + !| T<float>
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "maxdisplayed", (T<float> + T<int>)
                "sizeref", (T<float> + T<int>)
                "sizemin", (T<float> + T<int>)
                "sizemode", SizeMode.Type
                "line", ScatterMarkerLine.Type
                "gradient", Gradient.Type
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
                "coloraxis", T<string> // subplotid
            ]
        }

    let ScatterLine =
        Pattern.Config "ScatterLine" {
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

    let ScatterErrorX = 
        Pattern.Config "ScatterErrorX" {
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
                "color", Color
                "thickness", (T<float> + T<int>)
                "width", (T<float> + T<int>)
            ]
        }

    let ScatterErrorY = 
        Pattern.Config "ScatterErrorY" {
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

    let ScatterHoverOn =
        let generatedEnum = GenerateOptions.allPermutations ["points"; "fills"] '+'
        Pattern.EnumStrings "ScatterHoverOn" generatedEnum

    let ScatterOptions =
        Class "ScatterOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'scatter'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle",LegendGroupTitle.Type
            "opacity", T<float>
            "mode", ScatterModes.Type
            "ids", !| T<string>
            "x", !| T<int> + !| T<float>
            "x0", (T<float> + T<int>) + T<string>
            "dx", (T<float> + T<int>)
            "y", !| T<int> + !| T<float>
            "y0", (T<float> + T<int>) + T<string>
            "dy", (T<float> + T<int>)
            "text", T<string> + !| T<string>
            "textposition", TextPositionInline.Type
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", ScatterHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "yaxis", T<string> //type is 'subplotid'
            "orientation", Orientation.Type
            "groupnorm", GroupNorm.Type
            "stackgroup", T<string>
            "xperiod", (T<float> + T<int>) + T<string>
            "xperiodalignment", PeriodAlignment.Type
            "xperiod0", (T<float> + T<int>) + T<string>
            "yperiod", (T<float> + T<int>) + T<string>
            "yperiodalignment", PeriodAlignment.Type
            "yperiod0", (T<float> + T<int>) + T<string>
            "marker", ScatterMarker.Type
            "line", ScatterLine.Type
            "textfont", Font.Type
            "error_x", ScatterErrorX.Type
            "error_y", ScatterErrorY.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", SelectedOption.Type
            "unselected", SelectedOption.Type // change name later
            "cliponaxis", T<bool>
            "connectgaps", T<bool>
            "fill",Fill.Type
            "fillcolor", Color
            "hoverlabel", HoverLabel.Type
            "hoveron", ScatterHoverOn.Type
            "stackgaps", StackGaps.Type
            "xcalendar", Calendar.Type
            "ycalendar", Calendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ScatterTraceNamespaces : CodeModel.NamespaceEntity list = [
        ScatterModes
        ScatterHoverInfo
        ScatterMarkerLine
        ScatterMarker
        ScatterLine
        ScatterErrorX
        ScatterErrorY
        ScatterHoverOn
        ScatterOptions
    ]