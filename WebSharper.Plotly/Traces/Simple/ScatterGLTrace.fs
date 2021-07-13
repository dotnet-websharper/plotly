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

module ScatterGLModule =

    let ScatterGLNullValue = Pattern.EnumInlines "ScatterGLNullValue" ["null", "null"]

    let ScatterGLColor = T<string> + (T<float> + T<int>) + (!| (!? (ScatterGLNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (ScatterGLNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let ScatterGLColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let ScatterGLVisibleString = Pattern.EnumStrings "ScatterGLVisibleString" ["legendonly"]

    let ScatterGLFontConfig =
        Pattern.Config "ScatterGLFontConfig" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "ScatterGLColor", ScatterGLColor
            ]
        }

    let ScatterGLLegendGroupTitle =
        Pattern.Config "ScatterGLLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ScatterGLFontConfig.Type
            ]
        }

    let ScatterGLModes =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["lines"; "markers"; "text"] '+')
            let seq2 = seq{"none"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ScatterGLModes" generatedEnum

    let ScatterGLTextPosition =
        Pattern.EnumInlines "ScatterGLTextPosition" [
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

    let ScatterGLHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ScatterGLHoverInfo" generatedEnum

    let ScatterGLOrientation =
        Pattern.EnumStrings "ScatterGLOrientation" [
            "v"
            "h"
        ]

    let ScatterGLGroupNorm =
        Pattern.EnumInlines "ScatterGLGroupNorm" [
            "empty", "''"
            "fraction", "'fraction'"
            "percent", "'percent'"
        ]

    let ScatterGLPeriodAlignment =
        Pattern.EnumStrings "XScatterGLPeriodAlignment" [
            "start"
            "middle"
            "end"
        ]

    let ScatterGLSizeMode =
        Pattern.EnumStrings "ScatterGLSizeMode" [
            "diameter"
            "area"
        ]

    let ScatterGLMarkerLine =
        Pattern.Config "ScatterGLMarkerLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
                "ScatterGLColor", ScatterGLColor
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "ScatterGLColorscale", ScatterGLColorScale
                "autoScatterGLColorscale", T<bool>
                "reversescale", T<bool>
                "ScatterGLColoraxis", T<string> // type: subplotid
            ]
        }

    let ScatterGLGradientType =
        Pattern.EnumStrings "ScatterGLGradientType" [
            "radial"
            "horizontal"
            "vertical"
            "none"
        ]

    let ScatterGLGradient =
        Pattern.Config "ScatterGLGradient" {
            Required = []
            Optional = [
                "type", ScatterGLGradientType.Type
                "ScatterGLColor", ScatterGLColor + !| ScatterGLColor
            ]
        }

    let ScatterGLScatterGLColorBarMode =
        Pattern.EnumStrings "ScatterGLThicknessMode" [
            "fraction"
            "pixels"
        ]

    let ScatterGLXAnchor =
        Pattern.EnumStrings "ScatterGLXAnchor" [
            "left"
            "center"
            "right"
        ]

    let ScatterGLYAnchor =
        Pattern.EnumStrings "ScatterGLYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let ScatterGLTickMode =
        Pattern.EnumStrings "ScatterGLTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let ScatterGLTicks =
        Pattern.EnumInlines "ScatterGLTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let ScatterGLTickLabelOverflow =
        Pattern.EnumInlines "ScatterGLTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let ScatterGLTickLabelPosition =
        Pattern.EnumInlines "ScatterGLTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let ScatterGLTickFormatStops =
        Pattern.Config "ScatterGLTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + ScatterGLNullValue.Type) * (DTickValue + ScatterGLNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let ScatterGLShowTickFix =
        Pattern.EnumStrings "ScatterGLShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ScatterGLShowExponent = ScatterGLShowTickFix

    let ScatterGLExponentFormat =
        Pattern.EnumInlines "ScatterGLExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let ScatterGLSide =
        Pattern.EnumStrings "ScatterGLSide" [
            "right"
            "top"
            "bottom"
        ]

    let ScatterGLTitle =
        Pattern.Config "ScatterGLTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ScatterGLFontConfig.Type
                "side", ScatterGLSide.Type
            ]
        }

    let ScatterGLScatterGLColorBar =
        Pattern.Config "ScatterGLScatterGLColorBar" {
            Required = []
            Optional = [
                "thicknessmode", ScatterGLScatterGLColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", ScatterGLScatterGLColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", ScatterGLXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", ScatterGLYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlineScatterGLColor", ScatterGLColor
                "outlinewidth", (T<float> + T<int>)
                "borderScatterGLColor", ScatterGLColor
                "borderwidth", (T<float> + T<int>)
                "bgScatterGLColor", ScatterGLColor
                "tickmode", ScatterGLTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", ScatterGLTicks.Type
                "ticklabeloverflow", ScatterGLTickLabelOverflow.Type
                "ticklabelposition", ScatterGLTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickScatterGLColor", ScatterGLColor
                "showticklabels", T<bool>
                "tickfont", ScatterGLFontConfig.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", ScatterGLTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", ScatterGLShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", ScatterGLShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", ScatterGLExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ScatterGLShowExponent.Type // change type name to fit
                "title", ScatterGLTitle.Type
            ]
        }

    let ScatterGLSymbol =
        Pattern.EnumStrings "ScatterGLSymbol" [
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

    let ScatterGLMarker =
        Pattern.Config "ScatterGLMarker" {
            Required = []
            Optional = [
                "symbol", ScatterGLSymbol.Type
                "opacity", T<float> + !| T<float>
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "sizeref", (T<float> + T<int>)
                "sizemin", (T<float> + T<int>)
                "sizemode", ScatterGLSizeMode.Type
                "line", ScatterGLMarkerLine.Type
                "ScatterGLColor", ScatterGLColor + !| ScatterGLColor
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "ScatterGLColorscale", ScatterGLColorScale
                "autoScatterGLColorscale", T<bool>
                "reverscale", T<bool>
                "showscale", T<bool>
                "ScatterGLColorbar", ScatterGLScatterGLColorBar.Type
                "ScatterGLColoraxis", T<string> // type: subplotid
            ]
        }

    let ScatterGLShape =
        Pattern.EnumStrings "ScatterGLShape" [
            "linear"
            "spline"
            "hv"
            "vh"
            "hvh"
            "vhv"
        ]

    let ScatterGLLine =
        Pattern.Config "ScatterGLLine" {
            Required = []
            Optional = [
                "ScatterGLColor", ScatterGLColor
                "width", (T<float> + T<int>)
                "shape", ScatterGLShape.Type
                "smoothing", (T<float> + T<int>)
                "dash", T<string>
                "simplify", T<bool>
            ]
        }

    let ScatterGLErrorType =
        Pattern.EnumStrings "ScatterGLErrorXType" [
            "percent"
            "constant"
            "sqrt"
            "data"
        ]

    let ScatterGLErrorX = 
        Pattern.Config "ScatterGLErrorX" {
            Required = []
            Optional = [
                "visible", T<bool>
                "type", ScatterGLErrorType.Type
                "symmetric", T<bool>
                "array", !| T<obj> // data array
                "arrayminus", !| T<obj> // data array
                "value", (T<float> + T<int>)
                "valueminus", (T<float> + T<int>)
                "traceref", T<int>
                "tracerefminus", T<int>
                "copy_ystyle", T<bool>
                "ScatterGLColor", ScatterGLColor
                "thickness", (T<float> + T<int>)
                "width", (T<float> + T<int>)
            ]
        }

    let ScatterGLErrorY = 
        Pattern.Config "ScatterGLErrorY" {
            Required = []
            Optional = [
                "visible", T<bool>
                "type", ScatterGLErrorType.Type
                "symmetric", T<bool>
                "array", !| T<obj> // data array
                "arrayminus", !| T<obj> // data array
                "value", (T<float> + T<int>)
                "valueminus", (T<float> + T<int>)
                "traceref", T<int>
                "tracerefminus", T<int>
                "ScatterGLColor", ScatterGLColor
                "thickness", (T<float> + T<int>)
                "width", (T<float> + T<int>)
            ]
        }

    let ScatterGLSelectedMarker =
        Pattern.Config "ScatterGLSelectedMarker" {
            Required = []
            Optional = [
                "opacity", (T<float> + T<int>)
                "ScatterGLColor", ScatterGLColor
                "size", (T<float> + T<int>)
            ]
        }

    let ScatterGLSelectedTextFont =
        Pattern.Config "ScatterGLSelectedTextFont" {
            Required = []
            Optional = ["ScatterGLColor", ScatterGLColor]
        }

    let ScatterGLSelectedOption =
        Pattern.Config "ScatterGLSelectedOption" {
            Required = []
            Optional = [
                "marker", ScatterGLSelectedMarker.Type
                "textfont", ScatterGLSelectedTextFont.Type
            ]
        }

    let ScatterGLFill =
        Pattern.EnumStrings "ScatterGLFill" [
            "none"
            "tozeroy"
            "tozerox"
            "tonexty"
            "tonextx"
            "toself"
            "tonext"
        ]

    let ScatterGLAlign =
        Pattern.EnumStrings "ScatterGLAlign" [
            "left"
            "right"
            "auto"
        ]

    let ScatterGLHoverLabel =
        Pattern.Config "ScatterGLHoverLabel" {
            Required = []
            Optional = [
                "bgScatterGLColor", ScatterGLColor + !| ScatterGLColor
                "borderScatterGLColor", ScatterGLColor + !| ScatterGLColor
                "fonts", ScatterGLFontConfig.Type
                "line", ScatterGLAlign.Type
                "namelength", T<int>
            ]
        }

    let ScatterGLHoverOn =
        let generatedEnum = GenerateOptions.allPermutations ["points"; "fills"] '+'
        Pattern.EnumStrings "ScatterGLHoverOn" generatedEnum

    let ScatterGLStackGaps =
        Pattern.EnumInlines "ScatterGLStackGaps" [
            "inferZero", "'infer zero'"
            "interpolate", "'interpolate'"
        ]

    let ScatterGLCalendar =
        Pattern.EnumStrings "ScatterGLCalendar" [
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

    let ScatterGLOptions =
        Class "ScatterGLOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'scattergl'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + ScatterGLVisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", ScatterGLLegendGroupTitle.Type
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
            "textposition", ScatterGLTextPosition.Type
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
            "orientation", ScatterGLOrientation.Type
            "groupnorm", ScatterGLGroupNorm.Type
            "stackgroup", T<string>
            "xperiod", (T<float> + T<int>) + T<string>
            "xperiodalignment", ScatterGLPeriodAlignment.Type
            "xperiod0", (T<float> + T<int>) + T<string>
            "yperiod", (T<float> + T<int>) + T<string>
            "yperiodalignment", ScatterGLPeriodAlignment.Type
            "yperiod0", (T<float> + T<int>) + T<string>
            "marker", ScatterGLMarker.Type
            "line", ScatterGLLine.Type
            "textfont", ScatterGLFontConfig.Type
            "error_x", ScatterGLErrorX.Type
            "error_y", ScatterGLErrorY.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", ScatterGLSelectedOption.Type
            "unselected", ScatterGLSelectedOption.Type // change name later
            "cliponaxis", T<bool>
            "connectgaps", T<bool>
            "fill", ScatterGLFill.Type
            "fillScatterGLColor", ScatterGLColor
            "hoverlabel", ScatterGLHoverLabel.Type
            "xcalendar", ScatterGLCalendar.Type
            "ycalendar", ScatterGLCalendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ScatterGLTraceNamespaces : CodeModel.NamespaceEntity list = [
        ScatterGLVisibleString
        ScatterGLFontConfig
        ScatterGLLegendGroupTitle
        ScatterGLModes
        ScatterGLTextPosition
        ScatterGLHoverInfo
        ScatterGLOrientation
        ScatterGLGroupNorm
        ScatterGLPeriodAlignment
        ScatterGLSizeMode
        ScatterGLMarkerLine
        ScatterGLGradientType
        ScatterGLGradient
        ScatterGLScatterGLColorBarMode
        ScatterGLXAnchor
        ScatterGLYAnchor
        ScatterGLTickMode
        ScatterGLTicks
        ScatterGLTickLabelOverflow
        ScatterGLTickLabelPosition
        ScatterGLTickFormatStops
        ScatterGLShowTickFix
        ScatterGLExponentFormat
        ScatterGLSide
        ScatterGLTitle
        ScatterGLScatterGLColorBar
        ScatterGLSymbol
        ScatterGLMarker
        ScatterGLShape
        ScatterGLLine
        ScatterGLErrorType
        ScatterGLErrorX
        ScatterGLErrorY
        ScatterGLSelectedMarker
        ScatterGLSelectedTextFont
        ScatterGLSelectedOption
        ScatterGLFill
        ScatterGLAlign
        ScatterGLHoverLabel
        ScatterGLCalendar
        ScatterGLOptions
    ]