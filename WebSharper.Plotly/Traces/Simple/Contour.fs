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

module ContourModule =

    open CommonModule

    let ContourModes =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["lines"; "markers"; "text"] '+')
            let seq2 = seq{"none"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ContourModes" generatedEnum

    let ContourHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ContourHoverInfo" generatedEnum

    let ContourPeriodAlignment =
        Pattern.EnumStrings "XContourPeriodAlignment" [
            "start"
            "middle"
            "end"
        ]

    let ContourGradientType =
        Pattern.EnumStrings "ContourGradientType" [
            "radial"
            "horizontal"
            "vertical"
            "none"
        ]

    let ContourGradient =
        Pattern.Config "ContourGradient" {
            Required = []
            Optional = [
                "type", ContourGradientType.Type
                "color", Color + !| Color
            ]
        }

    let ContourShape =
        Pattern.EnumStrings "ContourShape" [
            "linear"
            "spline"
            "hv"
            "vh"
            "hvh"
            "vhv"
        ]

    let ContourLine =
        Pattern.Config "ContourLine" {
            Required = []
            Optional = [
                "color", Color
                "width", (T<float> + T<int>)
                "shape", ContourShape.Type
                "smoothing", (T<float> + T<int>)
                "dash", T<string>
                "simplify", T<bool>
            ]
        }

    let ContourXYType =
        Pattern.EnumStrings "ContourXYType" [
            "array"
            "scaled"
        ]

    let ContoursType =
        Pattern.EnumStrings "ContoursType" [
            "levels"
            "constraint"
        ]

    let ContourColoring = 
        Pattern.EnumStrings "ContourColoring" [
            "fill"
            "heatmap"
            "lines"
            "none"
        ]

    let ContourOperation =
        Pattern.EnumInlines "ContourOperation" [
            "equal", "'='"
            "less", "'<'"
            "greater", "'>'"
            "greaterEqual", "'>='"
            "lessEqual", "'<='"
            "square", "'[]'"
            "bracket", "'()'"
            "squareBracket", "'[)'"
            "bracketSquare", "'(]'"
            "reverseSquare", "']['"
            "reverseBracket", "')('"
            "reverseSquareBracket", "']('"
            "reverseBracketSquare", "')['"
        ]

    let ContourContours =
        Pattern.Config "ContourContours" {
            Required = []
            Optional = [
                "type", ContoursType.Type
                "start", T<int> + T<float>
                "end", T<int> + T<float>
                "size", T<int> + T<float>
                "coloring", ContourColoring.Type
                "showlines", T<bool>
                "labelfont", Font.Type
                "labelformat", T<string>
                "operation", ContourOperation.Type
                "value", T<int> + T<float> + T<string>
            ]
        }

    let ContourOptions =
        Class "ContourOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'contour'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", T<float>
            "mode", ContourModes.Type
            "ids", !| T<string>
            "x", !| T<int> + !| T<float>
            "x0", (T<float> + T<int>) + T<string>
            "dx", (T<float> + T<int>)
            "xtype", ContourXYType.Type
            "y", !| T<int> + !| T<float>
            "y0", (T<float> + T<int>) + T<string>
            "dy", (T<float> + T<int>)
            "ytype", ContourXYType.Type
            "z", !| (!| T<float> + !| T<int>)
            "text", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", ContourHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "xaxis", T<string> //type is 'subplotid'            
            "yaxis", T<string> //type is 'subplotid'
            "coloraxis", T<string> //type is 'subplotid'
            "xperiod", (T<float> + T<int>) + T<string>
            "xperiodalignment", ContourPeriodAlignment.Type
            "xperiod0", (T<float> + T<int>) + T<string>
            "yperiod", (T<float> + T<int>) + T<string>
            "yperiodalignment", ContourPeriodAlignment.Type
            "yperiod0", (T<float> + T<int>) + T<string>
            "line", ContourLine.Type
            "colorbar", ColorBar.Type
            "autocolorscale", T<bool>
            "colorscale", ColorScale
            "showscale", T<bool>
            "reversescale", T<bool>
            "zauto", T<bool>
            "zhoverformat", T<string>
            "zmax", T<int> + T<float>
            "zmid", T<int> + T<float>
            "zmin", T<int> + T<float>
            "autocontour", T<bool>
            "connectgaps", T<bool>
            "contours", ContourContours.Type
            "fillcolor", Color
            "hoverlabel", HoverLabel.Type
            "hoverongaps", T<bool>
            "ncontours", T<int>
            "transpose", T<bool>
            "xcalendar",Calendar.Type
            "ycalendar", Calendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ContourTraceNamespaces : CodeModel.NamespaceEntity list = [
        ContourModes
        ContourHoverInfo
        ContourPeriodAlignment
        ContourGradientType
        ContourGradient
        ContourShape
        ContourLine
        ContourXYType
        ContoursType
        ContourColoring
        ContourOperation
        ContourContours
        ContourOptions
    ]