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

module BarModule =

    open CommonModule  
            
    let BarHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "BarHoverInfo" generatedEnum

    let BarMarkerLine =
        Pattern.Config "BarMarkerLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
                "BarColor", Color
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

    let BarMarker =
        Pattern.Config "BarMarker" {
            Required = []
            Optional = [
                "line", BarMarkerLine.Type
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
                "opacity", (T<float> + T<int>)
                "pattern", MarkerPattern.Type
            ]
        }

    let BarErrorType =
        Pattern.EnumStrings "BarErrorType" [
            "percent"
            "constant"
            "sqrt"
            "data"
        ]

    let BarErrorX = 
        Pattern.Config "BarErrorX" {
            Required = []
            Optional = [
                "visible", T<bool>
                "type", BarErrorType.Type
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

    let BarErrorY = 
        Pattern.Config "BarErrorY" {
            Required = []
            Optional = [
                "visible", T<bool>
                "type", BarErrorType.Type
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

    let BarSelectedMarker =
        Pattern.Config "BarSelectedMarker" {
            Required = []
            Optional = [
                "opacity", (T<float> + T<int>)
                "color", Color
            ]
        }

    let BarSelectedTextFont =
        Pattern.Config "BarSelectedTextFont" {
            Required = []
            Optional = [
                "color", Color
            ]
        }

    let BarSelectedOption =
        Pattern.Config "Selected" {
            Required = []
            Optional = [
                "marker",  BarSelectedMarker.Type
                "textfont",  BarSelectedTextFont.Type
            ]
        }

    let BarConstrainText = 
        Pattern.EnumStrings "BarConstrainText" [
            "inside"
            "outside"
            "both"
            "none"
        ]

    let BarTextAnchor =
        Pattern.EnumStrings "BarTextAnchor" [
            "end"
            "middle"
            "start"
        ]

    let BarOptions =
        Class "BarOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type: 'bar'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", (T<float> + T<int>)
            "ids", !| T<string> //data array
            "x", !| T<float> + !| T<int> + !| T<string> //data array
            "x0", (T<float> + T<int>) + T<string>
            "dx", (T<float> + T<int>)
            "y", !| T<float> + !| T<int> //data array
            "y0", (T<float> + T<int>) + T<string>
            "dy", (T<float> + T<int>)
            "base", (T<float> + T<int>) + T<string>
            "width", (T<float> + T<int>) + !| T<float> + !| T<int>
            "offset", (T<float> + T<int>) + (T<float> + T<int>)
            "text", T<string> + !| T<string>
            "textposition", TextPositionEnum.Type
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", BarHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", !| T<string> //data array
            "xaxis", T<string> //subplotid
            "yaxis", T<string> //subplotid
            "orientation", Orientation.Type
            "alignmentgroup", T<string>
            "offsetgroup", T<string>
            "xperiod", (T<float> + T<int>) + T<string>
            "xperiodalignment", PeriodAlignment.Type
            "xperiod0", (T<float> + T<int>) + T<string>
            "yperiod", (T<float> + T<int>) + T<string>
            "yperiodalignment", PeriodAlignment.Type
            "yperiod0", (T<float> + T<int>) + T<string>
            "marker", BarMarker.Type
            "textangle", (T<float> + T<int>) //angle
            "textfont", Font.Type
            "error_x",  BarErrorX.Type
            "error_y",  BarErrorY.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", BarSelectedOption.Type
            "unselected", BarSelectedOption.Type
            "cliponaxis", T<bool>
            "constraintext",  BarConstrainText.Type
            "hoverlabel",  HoverLabel.Type
            "insidetextanchor",  BarTextAnchor.Type
            "insidetextfont", Font.Type
            "outsidetextfont", Font.Type
            "xcalendar",  Calendar.Type
            "ycalendar",  Calendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let BarTraceNamespaces : CodeModel.NamespaceEntity list = [
        BarHoverInfo
        BarMarkerLine
        BarMarker
        BarErrorType
        BarErrorX
        BarErrorY
        BarSelectedMarker
        BarSelectedTextFont
        BarSelectedOption
        BarConstrainText
        BarTextAnchor
        BarOptions
    ]
