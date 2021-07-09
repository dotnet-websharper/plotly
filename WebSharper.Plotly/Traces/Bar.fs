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

module BarModule =

    let VisibleString = Pattern.EnumStrings "VisibleString" ["legendonly"]

    let NullValue = Pattern.EnumInlines "NullValue" ["null", "null"]

    let Color = T<string> + T<Number> + (!| (!? (NullValue.Type + T<string> + T<Number>))) + (!| (!| ((!? (NullValue.Type + T<string> + T<Number>))))) 

    let ColorScale = T<string> + (!| T<string>) + (!| (T<Number> * T<string>))

    let Font =
        Pattern.Config "Font" {
            Required = []
            Optional = [
                "family", T<string>
                "size", T<Number>
                "color", Color
            ]
        }

    let LegendGroupTitle =
        Pattern.Config "LegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", Font.Type
            ]
        }

    let TextPosition =
        Pattern.EnumStrings "TextPosition" [
            "inside"
            "outside"
            "auto"
            "none"
        ]    
            
    let HoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "HoverInfo" generatedEnum
    
    let Orientation =
        Pattern.EnumStrings "Orientation" [
            "v"
            "h"
        ]

    let PeriodAlignment =
        Pattern.EnumStrings "PeriodAlignment" [
            "start"
            "middle"
            "end"
        ]

    let MarkerLine =
        Pattern.Config "MarkerLine" {
            Required = []
            Optional = [
                "width", T<Number> + !| T<Number>
                "color", Color
                "cauto", T<bool>
                "cmin", T<Number>
                "cmax", T<Number>
                "cmid", T<Number>
                "colorscale", ColorScale
                "autocolorscale", T<bool>
                "reversescale", T<bool>
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let ColorBarMode =
        Pattern.EnumStrings "ThicknessMode" [
            "fraction"
            "pixels"
        ]

    let XAnchor =
        Pattern.EnumStrings "XAnchor" [
            "left"
            "center"
            "right"
        ]

    let YAnchor =
        Pattern.EnumStrings "YAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let TickMode =
        Pattern.EnumStrings "Tickmode" [
            "auto"
            "linear"
            "array"
        ]

    let Ticks =
        Pattern.EnumInlines "Ticks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let TickLabelOverflow =
        Pattern.EnumInlines "TickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let TickLabelPosition =
        Pattern.EnumInlines "TickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let TickFormatStops =
        Pattern.Config "TickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + NullValue.Type) * (DTickValue + NullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let ShowTickFix =
        Pattern.EnumStrings "ShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = ShowTickFix

    let ExponentFormat =
        Pattern.EnumInlines "ExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let Title =
        Pattern.Config "Title" {
            Required = []
            Optional = [
                "text", T<string>
                "font", FontConfig.Type
                "side", Side.Type
            ]
        }

    let ColorBar =
        Pattern.Config "ColorBar" {
            Required = []
            Optional = [
                "thicknessmode", ColorBarMode.Type
                "thickness", T<Number>
                "lenmode", ColorBarMode.Type
                "len", T<Number>
                "x", T<float>
                "xanchor", XAnchor.Type
                "xpad", T<Number>
                "y", T<float>
                "yanchor", YAnchor.Type
                "ypad", T<Number>
                "outlinecolor", Color
                "outlinewidth", T<Number>
                "bordercolor", Color
                "borderwidth", T<Number>
                "bgcolor", Color
                "tickmode", TickMode.Type
                "nticks", T<int>
                "tick0", T<Number> + T<string>
                "dtick", T<Number> + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", Ticks.Type
                "ticklabeloverflow", TickLabelOverflow.Type
                "ticklabelposition", TickLabelPosition.Type
                "ticklen", T<Number>
                "tickwidth", T<Number>
                "tickcolor", Color
                "showticklabels", T<bool>
                "tickfont", Font.Type
                "tickangle", T<Number> //type: Angle
                "tickformat", T<string>
                "tickformatstops", TickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", ShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", ShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", ExponentFormat.Type
                "minexponent", T<Number>
                "showexponent", ShowExponent.Type // change type name to fit
                "title", Title.Type
            ]
        }

    let MarkerPatternShape =
        Pattern.EnumInlines "MarkerPatternShape" [
            "empty", "''"
            "/", "'/'"
            "backslash", "'\'" //TODO
            "x", "'x'"
            "-", "'-'"
            "|", "'|'"
            "+", "'+'"
            ".", "'.'"
        ]

    let FillMode =
        Pattern.EnumStrings "FillMode" [
            "replace"
            "overlay"
        ]

    let MarkerPattern =
        Pattern.Config "MarkerPattern" {
            Required = []
            Optional = [
                "shape", MarkerPatternShape.Type
                "fillmode", FillMode.Type
                "bgcolor", Color + !| Color
                "fgcolor", Color + !| Color
                "fgopacity", T<Number>
                "size", T<Number> + !| T<Number>
                "solidity", T<Number> + !| T<Number>               
            ]
        }

    let Marker =
        Pattern.Config "Marker" {
            Required = []
            Optional = [
                "line", MarkerLine.Type
                "color", Color + !| Color
                "cauto", T<bool>
                "cmin", T<Number>
                "cmax", T<Number>
                "cmid", T<Number>
                "colorscale", ColorScale
                "autocolorscale", T<bool>
                "reverscale", T<bool>
                "showscale", T<bool>
                "colorbar", ColorBar.Type
                "coloraxis", T<string> // type: subplotid
                "opacity", T<Number>
                "pattern", MarkerPattern.Type
            ]
        }

    let ErrorType =
        Pattern.EnumStrings "ErrorXType" [
            "percent"
            "constant"
            "sqrt"
            "data"
        ]

    let ErrorX = 
        Pattern.Config "ErrorX" {
            Required = []
            Optional = [
                "visible", T<bool>
                "type", ErrorType.Type
                "symmetric", T<bool>
                "array", !| T<obj> // data array
                "arrayminus", !| T<obj> // data array
                "value", T<Number>
                "valueminus", T<Number>
                "traceref", T<int>
                "tracerefminus", T<int>
                "copy_ystyle", T<bool>
                "color", Color
                "thickness", T<Number>
                "width", T<Number>
            ]
        }

    let ErrorY = 
        Pattern.Config "ErrorY" {
            Required = []
            Optional = [
                "visible", T<bool>
                "type", ErrorType.Type
                "symmetric", T<bool>
                "array", !| T<obj> // data array
                "arrayminus", !| T<obj> // data array
                "value", T<Number>
                "valueminus", T<Number>
                "traceref", T<int>
                "tracerefminus", T<int>
                "color", Color
                "thickness", T<Number>
                "width", T<Number>
            ]
        }

    let SelectedMarker =
        Pattern.Config "SelectedMarker" {
            Required = []
            Optional = [
                "opacity", T<Number>
                "color", Color
                "size", T<Number>
            ]
        }

    let SelectedTextFont =
        Pattern.Config "SelectedTextFont" {
            Required = []
            Optional = ["color", Color]
        }

    let SelectedOption =
        Pattern.Config "Selected" {
            Required = []
            Optional = [
                "marker", SelectedMarker.Type
                "textfont", SelectedTextFont.Type
            ]
        }

    let ConstrainText = 
        Pattern.EnumStrings "ConstrainText" [
            "inside"
            "outside"
            "both"
            "none"
        ]

    let HoverLabel =
        Pattern.Config "HoverLabel" {
            Required = []
            Optional = [
                "bgcolor", Color + !| Color
                "bordercolor", Color + !| Color
                "fonts", Font.Type
                "line", Align.Type
                "namelength", T<int>
            ]
        }

    let TextAnchor =
        Pattern.EnumStrings "textAnchor" [
            "end"
            "middle"
            "start"
        ]

    let Calendar =
        Pattern.EnumStrings "Calendar" [
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

    let BarOptions =
        Class "BarOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type: 'bar'}"
        ]
        |+> Pattern.OptionFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "showlegend", T<bool>
            "legendrank", T<Number>
            "legendgroup", T<string>
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", T<number>
            "ids", !| T<string> //data array
            "x", !| T<Number> //data array
            "x0", T<Number> + T<string>
            "dx", T<Number>
            "y", !| T<Number> //data array
            "y0", T<Number> + T<string>
            "dy", T<Number>
            "base", T<Number> + T<string>
            "width", T<Number> + !| T<Number>
            "offset", T<Number> + T<Number>
            "text", T<string> + !| T<string>
            "textposition", TextPosition.Type
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", HoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", T<Number> + T<string>
            "customdata", !| T<string> //data array
            "xaxis", T<string> //subplotid
            "yaxis", T<string> //subplotid
            "orientation", Orientation.Type
            "alignmentgroup", T<string>
            "offsetgroup", T<string>
            "xperiod", T<Number> + T<string>
            "xperiodalignment", PeriodAlignment.Type
            "xperiod0", T<Number> + T<string>
            "yperiod", T<Number> + T<string>
            "yperiodalignment", PeriodAlignment.Type
            "yperiod0", T<Number> + T<string>
            "marker", Marker.Type
            "textangle", T<Number> //angle
            "textfont", Font.Type
            "error_x", ErrorX.Type
            "error_y", ErrorY.Type
            "selectedpoints", T<Number> + T<string>
            "selected", Selected.Type
            "unselected", Selected.Type
            "cliponaxis", T<bool>
            "constraintext", ConstrainText.Type
            "hoverlabel", HoverLabel.Type
            "insidetextanchor", TextAnchor.Type
            "insidetextfont", Font.Type
            "outsidetextfont", Font.Type
            "xcalendar", Calendar.Type
            "ycalendar", Calendar.Type
            "uirevision", T<Number> + T<string>
        ]

    let BarTraceNamespaces : CodeModel.NamespaceEntity list = [
        VisibleString
        NullValue
        Color
        ColorScale
        Font
        LegendGroupTitle
        TextPosition
        HoverInfo
        Orientation
        PeriodAlignment
        MarkerLine
        ColorBarMode
        XAnchor
        YAnchor
        TickMode
        Ticks
        TickLabelOverflow
        TickLabelPosition
        TickFormatStops
        ShowTickFix
        ShowExponent
        ExponentFormat
        Title
        ColorBar
        MarkerPatternShape
        FillMode
        MarkerPattern
        Marker
        ErrorType
        ErrorX
        ErrorY
        SelectedMarker
        SelectedTextFont
        SelectedOption
        ConstrainText
        HoverLabel
        TextAnchor
        Calendar
        BarOptions
    ]
