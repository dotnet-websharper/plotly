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

module ContourModule =

    let ContourNullValue = Pattern.EnumInlines "ContourNullValue" ["null", "null"]

    let ContourColor = T<string> + (T<float> + T<int>) + (!| (!? (ContourNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (ContourNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let ContourColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let ContourVisibleString = Pattern.EnumStrings "ContourVisibleString" ["legendonly"]

    let ContourFont =
        Pattern.Config "ContourFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", ContourColor
            ]
        }

    let ContourLegendGroupTitle =
        Pattern.Config "ContourLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ContourFont.Type
            ]
        }

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
                "color", ContourColor + !| ContourColor
            ]
        }

    let ContourColorBarMode =
        Pattern.EnumStrings "ContourThicknessMode" [
            "fraction"
            "pixels"
        ]

    let ContourXAnchor =
        Pattern.EnumStrings "ContourXAnchor" [
            "left"
            "center"
            "right"
        ]

    let ContourYAnchor =
        Pattern.EnumStrings "ContourYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let ContourTickMode =
        Pattern.EnumStrings "ContourTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let ContourTicks =
        Pattern.EnumInlines "ContourTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let ContourTickLabelOverflow =
        Pattern.EnumInlines "ContourTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let ContourTickLabelPosition =
        Pattern.EnumInlines "ContourTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let ContourTickFormatStops =
        Pattern.Config "ContourTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + ContourNullValue.Type) * (DTickValue + ContourNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let ContourShowTickFix =
        Pattern.EnumStrings "ContourShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = ContourShowTickFix

    let ContourExponentFormat =
        Pattern.EnumInlines "ContourExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let ContourSide =
        Pattern.EnumStrings "ContourSide" [
            "right"
            "top"
            "bottom"
        ]

    let ContourTitle =
        Pattern.Config "ContourTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ContourFont.Type
                "side", ContourSide.Type
            ]
        }

    let ContourColorBar =
        Pattern.Config "ContourColorBar" {
            Required = []
            Optional = [
                "thicknessmode", ContourColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", ContourColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", ContourXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", ContourYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", ContourColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", ContourColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", ContourColor
                "tickmode", ContourTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", ContourTicks.Type
                "ticklabeloverflow", ContourTickLabelOverflow.Type
                "ticklabelposition", ContourTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", ContourColor
                "showticklabels", T<bool>
                "tickfont", ContourFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", ContourTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", ContourShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", ContourShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", ContourExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", ContourTitle.Type
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
                "color", ContourColor
                "width", (T<float> + T<int>)
                "shape", ContourShape.Type
                "smoothing", (T<float> + T<int>)
                "dash", T<string>
                "simplify", T<bool>
            ]
        }

    let ContourAlign =
        Pattern.EnumStrings "ContourAlign" [
            "left"
            "right"
            "auto"
        ]

    let ContourHoverLabel =
        Pattern.Config "ContourHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", ContourColor + !| ContourColor
                "bordercolor", ContourColor + !| ContourColor
                "fonts", ContourFont.Type
                "align", ContourAlign.Type
                "namelength", T<int>
            ]
        }

    let ContourCalendar =
        Pattern.EnumStrings "ContourCalendar" [
            "gregorian"
            "chinese"
            "coptic"
            "discworld"
            "ethiopian"
            "hebrew"
            "islamic"
            "julian"
            "mayan"
            "nanakshahi"
            "nepali"
            "persian"
            "jalali"
            "taiwan"
            "thai"
            "ummalqura"
        ]

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
                "labelfont", ContourFont.Type
                "labelformat", T<string>
                "operation", ContourOperation.Type
                "value", T<int> + T<float> + T<string>
            ]
        }

    let ContourOptions =
        Class "ContourOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'contour'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + ContourVisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", ContourLegendGroupTitle.Type
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
            "z", !| T<int> + !| T<float>
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
            "colorbar", ContourColorBar.Type
            "autocolorscale", T<bool>
            "colorscale", ContourColorScale
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
            "fillcolor", ContourColor
            "hoverlabel", ContourHoverLabel.Type
            "hoverongaps", T<bool>
            "ncontours", T<int>
            "transpose", T<bool>
            "xcalendar", ContourCalendar.Type
            "ycalendar", ContourCalendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ContourTraceNamespaces : CodeModel.NamespaceEntity list = [
        ContourNullValue
        ContourVisibleString
        ContourFont
        ContourLegendGroupTitle
        ContourModes
        ContourHoverInfo
        ContourPeriodAlignment
        ContourGradientType
        ContourGradient
        ContourColorBarMode
        ContourXAnchor
        ContourYAnchor
        ContourTickMode
        ContourTicks
        ContourTickLabelOverflow
        ContourTickLabelPosition
        ContourTickFormatStops
        ContourShowTickFix
        ContourExponentFormat
        ContourSide
        ContourTitle
        ContourColorBar
        ContourShape
        ContourLine
        ContourAlign
        ContourHoverLabel
        ContourCalendar
        ContourXYType
        ContoursType
        ContourColoring
        ContourOperation
        ContourContours
        ContourOptions
    ]