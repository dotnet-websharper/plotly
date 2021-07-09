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

module TracesModule =

    //let generateEnum words isolator =
    //    result =? T<seq<string>> |> (GenerateOptions.allPermutations words isolator)

    let NullValue = Pattern.EnumInlines "NullValue" ["null", "null"]

    let Color = T<string> + (T<float> + T<int>) + (!| (!? (NullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (NullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let ColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let VisibleString = Pattern.EnumStrings "VisibleString" ["legendonly"]

    let FontConfig =
        Pattern.Config "FontConfig" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", Color
            ]
        }

    let LegendGroupTitle =
        Pattern.Config "LegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", FontConfig.Type
            ]
        }

    let Modes =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["lines"; "markers"; "text"] '+')
            let seq2 = seq{"none"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "Modes" generatedEnum

    let TextPosition =
        Pattern.EnumInlines "TextPosition" [
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

    let GroupNorm =
        Pattern.EnumInlines "GroupNorm" [
            "empty", "''"
            "fraction", "'fraction'"
            "percent", "'percent'"
        ]

    let PeriodAlignment =
        Pattern.EnumStrings "XPeriodAlignment" [
            "start"
            "middle"
            "end"
        ]

    let SizeMode =
        Pattern.EnumStrings "SizeMode" [
            "diameter"
            "area"
        ]

    let MarkerLine =
        Pattern.Config "MarkerLine" {
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
            ]
        }

    let GradientType =
        Pattern.EnumStrings "GradientType" [
            "radial"
            "horizontal"
            "vertical"
            "none"
        ]

    let Gradient =
        Pattern.Config "Gradient" {
            Required = []
            Optional = [
                "type", GradientType.Type
                "color", Color + !| Color
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

    let DTickValue = (T<float> + T<int>) + T<string>

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

    let Side =
        Pattern.EnumStrings "Side" [
            "right"
            "top"
            "bottom"
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
                "thickness", (T<float> + T<int>)
                "lenmode", ColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", XAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", YAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", Color
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", Color
                "borderwidth", (T<float> + T<int>)
                "bgcolor", Color
                "tickmode", TickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", Ticks.Type
                "ticklabeloverflow", TickLabelOverflow.Type
                "ticklabelposition", TickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", Color
                "showticklabels", T<bool>
                "tickfont", FontConfig.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", TickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", ShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", ShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", ExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", Title.Type
            ]
        }

    let Symbol =
        Pattern.EnumStrings "Symbol" [
            "0"
            "circle"
            "100"
            "circle-open"
            "200"
            "circle-dot"
            "300"
            "circle-open-dot"
            "1"
            "square"
            "101"
            "square-open"
            "201"
            "square-dot"
            "301"
            "square-open-dot"
            "2"
            "diamond"
            "102"
            "diamond-open"
            "202"
            "diamond-dot"
            "302"
            "diamond-open-dot"
            "3"
            "cross"
            "103"
            "cross-open"
            "203"
            "cross-dot"
            "303"
            "cross-open-dot"
            "4"
            "x"
            "104"
            "x-open"
            "204"
            "x-dot"
            "304"
            "x-open-dot"
            "5"
            "triangle-up"
            "105"
            "triangle-up-open"
            "205"
            "triangle-up-dot"
            "305"
            "triangle-up-open-dot"
            "6"
            "triangle-down"
            "106"
            "triangle-down-open"
            "206"
            "triangle-down-dot"
            "306"
            "triangle-down-open-dot"
            "7"
            "triangle-left"
            "107"
            "triangle-left-open"
            "207"
            "triangle-left-dot"
            "307"
            "triangle-left-open-dot"
            "8"
            "triangle-right"
            "108"
            "triangle-right-open"
            "208"
            "triangle-right-dot"
            "308"
            "triangle-right-open-dot"
            "9"
            "triangle-ne"
            "109"
            "triangle-ne-open"
            "209"
            "triangle-ne-dot"
            "309"
            "triangle-ne-open-dot"
            "10"
            "triangle-se"
            "110"
            "triangle-se-open"
            "210"
            "triangle-se-dot"
            "310"
            "triangle-se-open-dot"
            "11"
            "triangle-sw"
            "111"
            "triangle-sw-open"
            "211"
            "triangle-sw-dot"
            "311"
            "triangle-sw-open-dot"
            "12"
            "triangle-nw"
            "112"
            "triangle-nw-open"
            "212"
            "triangle-nw-dot"
            "312"
            "triangle-nw-open-dot"
            "13"
            "pentagon"
            "113"
            "pentagon-open"
            "213"
            "pentagon-dot"
            "313"
            "pentagon-open-dot"
            "14"
            "hexagon"
            "114"
            "hexagon-open"
            "214"
            "hexagon-dot"
            "314"
            "hexagon-open-dot"
            "15"
            "hexagon2"
            "115"
            "hexagon2-open"
            "215"
            "hexagon2-dot"
            "315"
            "hexagon2-open-dot"
            "16"
            "octagon"
            "116"
            "octagon-open"
            "216"
            "octagon-dot"
            "316"
            "octagon-open-dot"
            "17"
            "star"
            "117"
            "star-open"
            "217"
            "star-dot"
            "317"
            "star-open-dot"
            "18"
            "hexagram"
            "118"
            "hexagram-open"
            "218"
            "hexagram-dot"
            "318"
            "hexagram-open-dot"
            "19"
            "star-triangle-up"
            "119"
            "star-triangle-up-open"
            "219"
            "star-triangle-up-dot"
            "319"
            "star-triangle-up-open-dot"
            "20"
            "star-triangle-down"
            "120"
            "star-triangle-down-open"
            "220"
            "star-triangle-down-dot"
            "320"
            "star-triangle-down-open-dot"
            "21"
            "star-square"
            "121"
            "star-square-open"
            "221"
            "star-square-dot"
            "321"
            "star-square-open-dot"
            "22"
            "star-diamond"
            "122"
            "star-diamond-open"
            "222"
            "star-diamond-dot"
            "322"
            "star-diamond-open-dot"
            "23"
            "diamond-tall"
            "123"
            "diamond-tall-open"
            "223"
            "diamond-tall-dot"
            "323"
            "diamond-tall-open-dot"
            "24"
            "diamond-wide"
            "124"
            "diamond-wide-open"
            "224"
            "diamond-wide-dot"
            "324"
            "diamond-wide-open-dot"
            "25"
            "hourglass"
            "125"
            "hourglass-open"
            "26"
            "bowtie"
            "126"
            "bowtie-open"
            "27"
            "circle-cross"
            "127"
            "circle-cross-open"
            "28"
            "circle-x"
            "128"
            "circle-x-open"
            "29"
            "square-cross"
            "129"
            "square-cross-open"
            "30"
            "square-x"
            "130"
            "square-x-open"
            "31"
            "diamond-cross"
            "131"
            "diamond-cross-open"
            "32"
            "diamond-x"
            "132"
            "diamond-x-open"
            "33"
            "cross-thin"
            "133"
            "cross-thin-open"
            "34"
            "x-thin"
            "134"
            "x-thin-open"
            "35"
            "asterisk"
            "135"
            "asterisk-open"
            "36"
            "hash"
            "136"
            "hash-open"
            "236"
            "hash-dot"
            "336"
            "hash-open-dot"
            "37"
            "y-up"
            "137"
            "y-up-open"
            "38"
            "y-down"
            "138"
            "y-down-open"
            "39"
            "y-left"
            "139"
            "y-left-open"
            "40"
            "y-right"
            "140"
            "y-right-open"
            "41"
            "line-ew"
            "141"
            "line-ew-open"
            "42"
            "line-ns"
            "142"
            "line-ns-open"
            "43"
            "line-ne"
            "143"
            "line-ne-open"
            "44"
            "line-nw"
            "144"
            "line-nw-open"
            "45"
            "arrow-up"
            "145"
            "arrow-up-open"
            "46"
            "arrow-down"
            "146"
            "arrow-down-open"
            "47"
            "arrow-left"
            "147"
            "arrow-left-open"
            "48"
            "arrow-right"
            "148"
            "arrow-right-open"
            "49"
            "arrow-bar-up"
            "149"
            "arrow-bar-up-open"
            "50"
            "arrow-bar-down"
            "150"
            "arrow-bar-down-open"
            "51"
            "arrow-bar-left"
            "151"
            "arrow-bar-left-open"
            "52"
            "arrow-bar-right"
            "152"
            "arrow-bar-right-open"
        ]

    let Marker =
        Pattern.Config "Marker" {
            Required = []
            Optional = [
                "symbol", Symbol.Type
                "opacity", T<float> + !| T<float>
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "maxdisplayed", (T<float> + T<int>)
                "sizeref", (T<float> + T<int>)
                "sizemin", (T<float> + T<int>)
                "sizemode", SizeMode.Type
                "line", MarkerLine.Type
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
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let Shape =
        Pattern.EnumStrings "Shape" [
            "linear"
            "spline"
            "hv"
            "vh"
            "hvh"
            "vhv"
        ]

    let Line =
        Pattern.Config "Line" {
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

    let ErrorY = 
        Pattern.Config "ErrorY" {
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

    let SelectedMarker =
        Pattern.Config "SelectedMarker" {
            Required = []
            Optional = [
                "opacity", (T<float> + T<int>)
                "color", Color
                "size", (T<float> + T<int>)
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

    let Fill =
        Pattern.EnumStrings "Fill" [
            "none"
            "tozeroy"
            "tozerox"
            "tonexty"
            "tonextx"
            "toself"
            "tonext"
        ]

    let Align =
        Pattern.EnumStrings "Align" [
            "left"
            "right"
            "auto"
        ]

    let HoverLabel =
        Pattern.Config "HoverLabel" {
            Required = []
            Optional = [
                "bgcolor", Color + !| Color
                "bordercolor", Color + !| Color
                "fonts", FontConfig.Type
                "line", Align.Type
                "namelength", T<int>
            ]
        }

    let HoverOn =
        let generatedEnum = GenerateOptions.allPermutations ["points"; "fills"] '+'
        Pattern.EnumStrings "HoverOn" generatedEnum

    let StackGaps =
        Pattern.EnumInlines "StackGaps" [
            "inferZero", "'infer zero'"
            "interpolate", "'interpolate'"
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

    let ScatterOptions =
        Class "ScatterOptions"
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
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", T<float>
            "mode", Modes.Type
            "ids", !| T<string>
            "x", !| T<int> + !| T<float>
            "x0", (T<float> + T<int>) + T<string>
            "dx", (T<float> + T<int>)
            "y", !| T<int> + !| T<float>
            "y0", (T<float> + T<int>) + T<string>
            "dy", (T<float> + T<int>)
            "text", T<string> + !| T<string>
            "textposition", TextPosition.Type
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", HoverInfo.Type
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
            "marker", Marker.Type
            "line", Line.Type
            "textfont", FontConfig.Type
            "error_x", ErrorX.Type
            "error_y", ErrorY.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", SelectedOption.Type
            "unselected", SelectedOption.Type // change name later
            "cliponaxis", T<bool>
            "connectgaps", T<bool>
            "fill", Fill.Type
            "fillcolor", Color
            "hoverlabel", HoverLabel.Type
            "hoveron", HoverOn.Type
            "stackgaps", StackGaps.Type
            "xcalendar", Calendar.Type
            "ycalendar", Calendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ScatterTraceNamespaces : CodeModel.NamespaceEntity list = [
        VisibleString
        FontConfig
        LegendGroupTitle
        Modes
        TextPosition
        HoverInfo
        Orientation
        GroupNorm
        PeriodAlignment
        SizeMode
        MarkerLine
        GradientType
        Gradient
        ColorBarMode
        XAnchor
        YAnchor
        TickMode
        Ticks
        TickLabelOverflow
        TickLabelPosition
        TickFormatStops
        ShowTickFix
        ExponentFormat
        Side
        Title
        ColorBar
        Symbol
        Marker
        Shape
        Line
        ErrorType
        ErrorX
        ErrorY
        SelectedMarker
        SelectedTextFont
        SelectedOption
        Fill
        Align
        HoverLabel
        HoverOn
        StackGaps
        Calendar
        ScatterOptions
    ]