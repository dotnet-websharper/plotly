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

    let ContourCarpetNullValue = Pattern.EnumInlines "ContourCarpetNullValue" ["null", "null"]

    let ContourCarpetColor = T<string> + (T<float> + T<int>) + (!| (!? (ContourCarpetNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (ContourCarpetNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let ContourCarpetColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let ContourCarpetVisibleString = Pattern.EnumStrings "ContourCarpetVisibleString" ["legendonly"]

    let ContourCarpetFont =
        Pattern.Config "ContourCarpetFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", ContourCarpetColor
            ]
        }

    let ContourCarpetLegendGroupTitle =
        Pattern.Config "ContourCarpetLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ContourCarpetFont.Type
            ]
        }

    let ContourCarpetColorBarMode =
        Pattern.EnumStrings "ContourCarpetThicknessMode" [
            "fraction"
            "pixels"
        ]

    let ContourCarpetXAnchor =
        Pattern.EnumStrings "ContourCarpetXAnchor" [
            "left"
            "center"
            "right"
        ]

    let ContourCarpetYAnchor =
        Pattern.EnumStrings "ContourCarpetYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let ContourCarpetTickMode =
        Pattern.EnumStrings "ContourCarpetTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let ContourCarpetTicks =
        Pattern.EnumInlines "ContourCarpetTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let ContourCarpetTickLabelOverflow =
        Pattern.EnumInlines "ContourCarpetTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let ContourCarpetTickLabelPosition =
        Pattern.EnumInlines "ContourCarpetTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let ContourCarpetTickFormatStops =
        Pattern.Config "ContourCarpetTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + ContourCarpetNullValue.Type) * (DTickValue + ContourCarpetNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let ContourCarpetShowTickFix =
        Pattern.EnumStrings "ContourCarpetShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = ContourCarpetShowTickFix

    let ContourCarpetExponentFormat =
        Pattern.EnumInlines "ContourCarpetExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let ContourCarpetSide =
        Pattern.EnumStrings "ContourCarpetSide" [
            "right"
            "top"
            "bottom"
        ]

    let ContourCarpetTitle =
        Pattern.Config "ContourCarpetTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ContourCarpetFont.Type
                "side", ContourCarpetSide.Type
            ]
        }

    let ContourCarpetColorBar =
        Pattern.Config "ContourCarpetColorBar" {
            Required = []
            Optional = [
                "thicknessmode", ContourCarpetColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", ContourCarpetColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", ContourCarpetXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", ContourCarpetYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", ContourCarpetColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", ContourCarpetColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", ContourCarpetColor
                "tickmode", ContourCarpetTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", ContourCarpetTicks.Type
                "ticklabeloverflow", ContourCarpetTickLabelOverflow.Type
                "ticklabelposition", ContourCarpetTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", ContourCarpetColor
                "showticklabels", T<bool>
                "tickfont", ContourCarpetFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", ContourCarpetTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", ContourCarpetShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", ContourCarpetShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", ContourCarpetExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", ContourCarpetTitle.Type
            ]
        }

    let ContourCarpetShape =
        Pattern.EnumStrings "ContourCarpetShape" [
            "linear"
            "spline"
            "hv"
            "vh"
            "hvh"
            "vhv"
        ]

    let ContourCarpetLine =
        Pattern.Config "ContourCarpetLine" {
            Required = []
            Optional = [
                "color", ContourCarpetColor
                "width", (T<float> + T<int>)
                "shape", ContourCarpetShape.Type
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

    let ContourCarpetOperation =
        Pattern.EnumInlines "ContourCarpetOperation" [
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
                "labelfont", ContourCarpetFont.Type
                "labelformat", T<string>
                "operation", ContourCarpetOperation.Type
                "value", T<int> + T<float> + T<string>
            ]
        }

    let ContourCarpetType =
        Pattern.EnumStrings "ContourCarpetType" [
            "array"
            "scaled"
        ]

    let ContourCarpetOptions =
        Class "ContourCarpetOptions"
        |=> Implements [CommonModule.Trace]
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'contourcarpet'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + ContourCarpetVisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", ContourCarpetLegendGroupTitle.Type
            "opacity", T<float>
            "ids", !| T<string>
            "z", !| T<string> + !| T<int> + !| T<float>
            "a", !| T<string> + !| T<int> + !| T<float>
            "atype", ContourCarpetType.Type
            "a0", T<int> + T<float> + T<string>
            "da", T<int> + T<float>
            "b", !| T<string> + !| T<int> + !| T<float>
            "btype", ContourCarpetType.Type
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
            "colorbar", ContourCarpetColorBar.Type
            "autocolorscale", T<bool>
            "colorscale", ContourCarpetColorScale
            "showscale", T<bool>
            "reversescale", T<bool>
            "zauto", T<bool>
            "zmax", T<int> + T<float>
            "zmid", T<int> + T<float>
            "zmin", T<int> + T<float>
            "autocontour", T<bool>
            "carpet", T<string>
            "contours", ContourCarpetContours.Type
            "fillcolor", ContourCarpetColor
            "ncontours", T<int>
            "transpose", T<bool>
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ContourCarpetTraceNamespaces : CodeModel.NamespaceEntity list = [
        ContourCarpetNullValue
        ContourCarpetVisibleString
        ContourCarpetFont
        ContourCarpetLegendGroupTitle
        ContourCarpetColorBarMode
        ContourCarpetXAnchor
        ContourCarpetYAnchor
        ContourCarpetTickMode
        ContourCarpetTicks
        ContourCarpetTickLabelOverflow
        ContourCarpetTickLabelPosition
        ContourCarpetTickFormatStops
        ContourCarpetShowTickFix
        ContourCarpetExponentFormat
        ContourCarpetSide
        ContourCarpetTitle
        ContourCarpetColorBar
        ContourCarpetShape
        ContourCarpetLine
        ContourCarpetsType
        ContourCarpetColoring
        ContourCarpetOperation
        ContourCarpetContours
        ContourCarpetType
        ContourCarpetOptions
    ]