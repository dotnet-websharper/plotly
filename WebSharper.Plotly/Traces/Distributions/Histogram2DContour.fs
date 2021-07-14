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

module HG2DContModule =

    let HG2DContNullValue = Pattern.EnumInlines "HG2DContNullValue" ["null", "null"]

    let HG2DContColor = T<string> + (T<float> + T<int>) + (!| (!? (HG2DContNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (HG2DContNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let HG2DContColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let HG2DContVisibleString = Pattern.EnumStrings "HG2DContVisibleString" ["legendonly"]

    let HG2DContFont =
        Pattern.Config "HG2DContFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", HG2DContColor
            ]
        }

    let HG2DContLegendGroupTitle =
        Pattern.Config "HG2DContLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", HG2DContFont.Type
            ]
        }

    let HG2DContHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "HG2DContHoverInfo" generatedEnum

    let HG2DContGradientType =
        Pattern.EnumStrings "HG2DContGradientType" [
            "radial"
            "horizontal"
            "vertical"
            "none"
        ]

    let HG2DContGradient =
        Pattern.Config "HG2DContGradient" {
            Required = []
            Optional = [
                "type", HG2DContGradientType.Type
                "color", HG2DContColor + !| HG2DContColor
            ]
        }

    let HG2DContThicknessMode =
        Pattern.EnumStrings "HG2DContThicknessMode" [
            "fraction"
            "pixels"
        ]

    let HG2DContXAnchor =
        Pattern.EnumStrings "HG2DContXAnchor" [
            "left"
            "center"
            "right"
        ]

    let HG2DContYAnchor =
        Pattern.EnumStrings "HG2DContYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let HG2DContTickMode =
        Pattern.EnumStrings "HG2DContTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let HG2DContTicks =
        Pattern.EnumInlines "HG2DContTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let HG2DContTickLabelOverflow =
        Pattern.EnumInlines "HG2DContTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let HG2DContTickLabelPosition =
        Pattern.EnumInlines "HG2DContTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let HG2DContTickFormatStops =
        Pattern.Config "HG2DContTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + HG2DContNullValue.Type) * (DTickValue + HG2DContNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let HG2DContShowTickFix =
        Pattern.EnumStrings "HG2DContShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = HG2DContShowTickFix

    let HG2DContExponentFormat =
        Pattern.EnumInlines "HG2DContExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let HG2DContSide =
        Pattern.EnumStrings "HG2DContSide" [
            "right"
            "top"
            "bottom"
        ]

    let HG2DContTitle =
        Pattern.Config "HG2DContTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", HG2DContFont.Type
                "side", HG2DContSide.Type
            ]
        }

    let HG2DContColorBar =
        Pattern.Config "HG2DContColorBar" {
            Required = []
            Optional = [
                "thicknessmode", HG2DContThicknessMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", HG2DContThicknessMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", HG2DContXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", HG2DContYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", HG2DContColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", HG2DContColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", HG2DContColor
                "tickmode", HG2DContTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", HG2DContTicks.Type
                "ticklabeloverflow", HG2DContTickLabelOverflow.Type
                "ticklabelposition", HG2DContTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", HG2DContColor
                "showticklabels", T<bool>
                "tickfont", HG2DContFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", HG2DContTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", HG2DContShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", HG2DContShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", HG2DContExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", HG2DContTitle.Type
            ]
        }

    let HG2DContMarkerPatternShape =
        Pattern.EnumInlines "HG2DContMarkerPatternShape" [
            "empty", "''"
            "slash", "'/'"
            "backslash", """'\\'"""
            "x", "'x'"
            "minus", "'-'"
            "pipeline", "'|'"
            "plus", "'+'"
            "dot", "'.'"
        ]

    let HG2DContFillMode =
        Pattern.EnumStrings "HG2DContFillMode" [
            "replace"
            "overlay"
        ]

    let HG2DContMarkerPattern =
        Pattern.Config "HG2DContMarkerPattern" {
            Required = []
            Optional = [
                "shape", HG2DContMarkerPatternShape.Type
                "fillmode", HG2DContFillMode.Type
                "bgcolor", HG2DContColor + !| HG2DContColor
                "fgcolor", HG2DContColor + !| HG2DContColor
                "fgopacity", (T<float> + T<int>)
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "solidity", (T<float> + T<int>) + !| T<float> + !| T<int>               
            ]
        }

    let HG2DContMarker =
        Pattern.Config "HG2DContMarker" {
            Required = []
            Optional = [
                "color", HG2DContColor + !| HG2DContColor //data array
            ]
        }

    let HG2DContAlign =
        Pattern.EnumStrings "HG2DContAlign" [
            "left"
            "right"
            "auto"
        ]

    let HG2DContHoverLabel =
        Pattern.Config "HG2DContHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", HG2DContColor + !| HG2DContColor
                "bordercolor", HG2DContColor + !| HG2DContColor
                "fonts", HG2DContFont.Type
                "align", HG2DContAlign.Type
                "namelength", T<int>
            ]
        }

    let HG2DContCalendar =
        Pattern.EnumStrings "HG2DContCalendar" [
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

    let HG2DContHistFunc =
        Pattern.EnumStrings "HG2DContHistFunc" [
            "count"
            "sum"
            "avg"
            "min"
            "max"
        ]

    let HG2DContHistNorm =
        Pattern.EnumInlines "HG2DContHistNorm" [
            "empty", "''"
            "percent", "'percent'"
            "probability", "'probability'"
            "density", "'density'"
            "probabilityDensity", "'probability density'"
        ]

    let HG2DContXYBins =
        Pattern.Config "HG2DContXYBins" {
            Required = []
            Optional = [
                "start", T<int> + T<float> + T<string>
                "end", T<int> + T<float> + T<string>
                "size", T<int> + T<float> + T<string>
            ]
        }

    let HG2DContLine =
        Pattern.Config "HG2DContLine" {
            Required = []
            Optional = [
                "color", HG2DContColor
                "width", T<int> + T<float>
                "dash", T<string>
                "smoothing", T<int> + T<float>
            ]
        }

    let HG2DContContoursType =
        Pattern.EnumStrings "HG2DContContoursType" [
            "levels"
            "constraint"
        ]

    let HG2DContContoursColoring =
        Pattern.EnumStrings "HG2DContContoursColoring" [
            "fill"
            "heatmap"
            "lines"
            "none"
        ]

    let HG2DContOperation =
        Pattern.EnumInlines "HG2DContOperation" [
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

    let HG2DContContours =
        Pattern.Config "HG2DContContours" {
            Required = []
            Optional = [
                "type", HG2DContContoursType.Type
                "start", T<int> + T<float>
                "end", T<int> + T<float>
                "size", T<int> + T<float>
                "coloring", HG2DContContoursColoring.Type
                "showlines", T<bool>
                "showlabels", T<bool>
                "labelfont", HG2DContFont.Type
                "labelformat", T<string>
                "operation", HG2DContOperation.Type
                "value", T<int> + T<float> + T<string>
            ]
        }

    let HG2DContOptions =
        Class "HG2DContOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'histogram2dcontour'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + HG2DContVisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", HG2DContLegendGroupTitle.Type
            "opacity", T<float>
            "ids", !| T<string>
            "x", !| T<int> + !| T<float>
            "y", !| T<int> + !| T<float>
            "z", !| T<int> + !| T<float> + !| T<string>
            "hoverinfo", HG2DContHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "xaxis", T<string> //type is 'subplotid'
            "yaxis", T<string> //type is 'subplotid'
            "coloraxis", T<string> //type is 'subplotid'
            "histfunc", HG2DContHistFunc.Type
            "histnorm", HG2DContHistNorm.Type
            "nbinsx", T<int>
            "ybinsx", T<int>
            "autobinx", T<bool>
            "autobiny", T<bool>
            "bingroup", T<string>
            "xbingroup", T<string>
            "xbins", HG2DContXYBins.Type
            "ybingroup", T<string>
            "ybins", HG2DContXYBins.Type
            "marker", HG2DContMarker.Type
            "line", HG2DContLine.Type
            "colorbar", HG2DContColorBar.Type
            "autocolorscale", T<bool>
            "colorscale", HG2DContColorScale
            "showscale", T<bool>
            "reversescale", T<bool>
            "zauto", T<bool>
            "zhoverformat", T<string>
            "zmax", T<int> + T<float>
            "zmid", T<int> + T<float>
            "zmin", T<int> + T<float>
            "autocontour", T<bool>
            "contours", HG2DContContours.Type
            "hoverlabel", HG2DContHoverLabel.Type
            "ncontours", T<int>
            "xcalendar", HG2DContCalendar.Type
            "ycalendar", HG2DContCalendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let HG2DContTraceNamespaces : CodeModel.NamespaceEntity list = [       
        HG2DContNullValue
        HG2DContVisibleString
        HG2DContFont
        HG2DContLegendGroupTitle
        HG2DContHoverInfo
        HG2DContGradientType
        HG2DContGradient
        HG2DContThicknessMode
        HG2DContXAnchor
        HG2DContYAnchor
        HG2DContTickMode
        HG2DContTicks
        HG2DContTickLabelOverflow
        HG2DContTickLabelPosition
        HG2DContTickFormatStops
        HG2DContShowTickFix
        HG2DContExponentFormat
        HG2DContSide
        HG2DContTitle
        HG2DContColorBar
        HG2DContMarkerPatternShape
        HG2DContFillMode
        HG2DContMarkerPattern
        HG2DContMarker
        HG2DContAlign
        HG2DContHoverLabel
        HG2DContCalendar
        HG2DContHistFunc
        HG2DContHistNorm
        HG2DContXYBins
        HG2DContLine
        HG2DContContoursType
        HG2DContContoursColoring
        HG2DContOperation
        HG2DContContours
        HG2DContOptions
    ]