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

module ScatterModule =

    let ScatterNullValue = Pattern.EnumInlines "ScatterNullValue" ["null", "null"]

    let ScatterColor = T<string> + (T<float> + T<int>) + (!| (!? (ScatterNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (ScatterNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let ScatterColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let ScatterVisibleString = Pattern.EnumStrings "ScatterVisibleString" ["legendonly"]

    let ScatterFontConfig =
        Pattern.Config "ScatterFontConfig" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", ScatterColor
            ]
        }

    let ScatterLegendGroupScatterTitle =
        Pattern.Config "ScatterLegendGroupScatterTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ScatterFontConfig.Type
            ]
        }

    let ScatterModes =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["lines"; "markers"; "text"] '+')
            let seq2 = seq{"none"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ScatterModes" generatedEnum

    let ScatterTextPosition =
        Pattern.EnumInlines "ScatterTextPosition" [
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

    let ScatterHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ScatterHoverInfo" generatedEnum

    let ScatterOrientation =
        Pattern.EnumStrings "ScatterOrientation" [
            "v"
            "h"
        ]

    let ScatterGroupNorm =
        Pattern.EnumInlines "ScatterGroupNorm" [
            "empty", "''"
            "fraction", "'fraction'"
            "percent", "'percent'"
        ]

    let ScatterPeriodScatterAlignment =
        Pattern.EnumStrings "XScatterPeriodScatterAlignment" [
            "start"
            "middle"
            "end"
        ]

    let ScatterSizeMode =
        Pattern.EnumStrings "ScatterSizeMode" [
            "diameter"
            "area"
        ]

    let ScatterMarkerScatterLine =
        Pattern.Config "ScatterMarkerScatterLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
                "color", ScatterColor
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", ScatterColorScale
                "autocolorscale", T<bool>
                "reversescale", T<bool>
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let ScatterGradientType =
        Pattern.EnumStrings "ScatterGradientType" [
            "radial"
            "horizontal"
            "vertical"
            "none"
        ]

    let ScatterGradient =
        Pattern.Config "ScatterGradient" {
            Required = []
            Optional = [
                "type", ScatterGradientType.Type
                "color", ScatterColor + !| ScatterColor
            ]
        }

    let ScatterColorBarMode =
        Pattern.EnumStrings "ScatterThicknessMode" [
            "fraction"
            "pixels"
        ]

    let ScatterXAnchor =
        Pattern.EnumStrings "ScatterXAnchor" [
            "left"
            "center"
            "right"
        ]

    let ScatterYAnchor =
        Pattern.EnumStrings "ScatterYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let ScatterTickMode =
        Pattern.EnumStrings "ScatterTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let ScatterTicks =
        Pattern.EnumInlines "ScatterTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let ScatterTickLabelOverflow =
        Pattern.EnumInlines "ScatterTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let ScatterTickLabelPosition =
        Pattern.EnumInlines "ScatterTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let ScatterTickFormatStops =
        Pattern.Config "ScatterTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + ScatterNullValue.Type) * (DTickValue + ScatterNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let ScatterShowTickFix =
        Pattern.EnumStrings "ScatterShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = ScatterShowTickFix

    let ScatterExponentFormat =
        Pattern.EnumInlines "ScatterExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let ScatterSide =
        Pattern.EnumStrings "ScatterSide" [
            "right"
            "top"
            "bottom"
        ]

    let ScatterTitle =
        Pattern.Config "ScatterTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ScatterFontConfig.Type
                "side", ScatterSide.Type
            ]
        }

    let ScatterColorBar =
        Pattern.Config "ScatterColorBar" {
            Required = []
            Optional = [
                "thicknessmode", ScatterColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", ScatterColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", ScatterXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", ScatterYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", ScatterColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", ScatterColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", ScatterColor
                "tickmode", ScatterTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", ScatterTicks.Type
                "ticklabeloverflow", ScatterTickLabelOverflow.Type
                "ticklabelposition", ScatterTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", ScatterColor
                "showticklabels", T<bool>
                "tickfont", ScatterFontConfig.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", ScatterTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", ScatterShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", ScatterShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", ScatterExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", ScatterTitle.Type
            ]
        }

    let ScatterSymbol =
        Pattern.EnumStrings "ScatterSymbol" [
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
                "symbol", ScatterSymbol.Type
                "opacity", T<float> + !| T<float>
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "maxdisplayed", (T<float> + T<int>)
                "sizeref", (T<float> + T<int>)
                "sizemin", (T<float> + T<int>)
                "sizemode", ScatterSizeMode.Type
                "line", ScatterMarkerScatterLine.Type
                "ScatterGradient", ScatterGradient.Type
                "color", ScatterColor + !| ScatterColor
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", ScatterColorScale
                "autocolorscale", T<bool>
                "reverscale", T<bool>
                "showscale", T<bool>
                "colorbar", ScatterColorBar.Type
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let ScatterShape =
        Pattern.EnumStrings "ScatterShape" [
            "linear"
            "spline"
            "hv"
            "vh"
            "hvh"
            "vhv"
        ]

    let ScatterLine =
        Pattern.Config "ScatterLine" {
            Required = []
            Optional = [
                "color", ScatterColor
                "width", (T<float> + T<int>)
                "shape", ScatterShape.Type
                "smoothing", (T<float> + T<int>)
                "dash", T<string>
                "simplify", T<bool>
            ]
        }

    let ScatterErrorType =
        Pattern.EnumStrings "ScatterErrorType" [
            "percent"
            "constant"
            "sqrt"
            "data"
        ]

    let ScatterErrorX = 
        Pattern.Config "ScatterErrorX" {
            Required = []
            Optional = [
                "visible", T<bool>
                "type", ScatterErrorType.Type
                "symmetric", T<bool>
                "array", !| T<obj> // data array
                "arrayminus", !| T<obj> // data array
                "value", (T<float> + T<int>)
                "valueminus", (T<float> + T<int>)
                "traceref", T<int>
                "tracerefminus", T<int>
                "copy_ystyle", T<bool>
                "color", ScatterColor
                "thickness", (T<float> + T<int>)
                "width", (T<float> + T<int>)
            ]
        }

    let ScatterErrorY = 
        Pattern.Config "ScatterErrorY" {
            Required = []
            Optional = [
                "visible", T<bool>
                "type", ScatterErrorType.Type
                "symmetric", T<bool>
                "array", !| T<obj> // data array
                "arrayminus", !| T<obj> // data array
                "value", (T<float> + T<int>)
                "valueminus", (T<float> + T<int>)
                "traceref", T<int>
                "tracerefminus", T<int>
                "color", ScatterColor
                "thickness", (T<float> + T<int>)
                "width", (T<float> + T<int>)
            ]
        }

    let ScatterSelectedMarker =
        Pattern.Config "ScatterSelectedMarker" {
            Required = []
            Optional = [
                "opacity", (T<float> + T<int>)
                "color", ScatterColor
                "size", (T<float> + T<int>)
            ]
        }

    let ScatterSelectedTextFont =
        Pattern.Config "ScatterSelectedTextFont" {
            Required = []
            Optional = ["color", ScatterColor]
        }

    let ScatterSelectedOption =
        Pattern.Config "ScatterSelectedOption" {
            Required = []
            Optional = [
                "marker", ScatterSelectedMarker.Type
                "textfont", ScatterSelectedTextFont.Type
            ]
        }

    let ScatterFill =
        Pattern.EnumStrings "ScatterFill" [
            "none"
            "tozeroy"
            "tozerox"
            "tonexty"
            "tonextx"
            "toself"
            "tonext"
        ]

    let ScatterAlign =
        Pattern.EnumStrings "ScatterAlign" [
            "left"
            "right"
            "auto"
        ]

    let ScatterHoverLabel =
        Pattern.Config "ScatterHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", ScatterColor + !| ScatterColor
                "bordercolor", ScatterColor + !| ScatterColor
                "fonts", ScatterFontConfig.Type
                "align", ScatterAlign.Type
                "namelength", T<int>
            ]
        }

    let ScatterHoverOn =
        let generatedEnum = GenerateOptions.allPermutations ["points"; "fills"] '+'
        Pattern.EnumStrings "ScatterHoverOn" generatedEnum

    let ScatterStackGaps =
        Pattern.EnumInlines "ScatterStackGaps" [
            "inferZero", "'infer zero'"
            "interpolate", "'interpolate'"
        ]

    let ScatterCalendar =
        Pattern.EnumStrings "ScatterCalendar" [
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
            "visible", T<bool> + ScatterVisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", ScatterLegendGroupScatterTitle.Type
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
            "textposition", ScatterTextPosition.Type
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", ScatterHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "yaxis", T<string> //type is 'subplotid'
            "orientation", ScatterOrientation.Type
            "groupnorm", ScatterGroupNorm.Type
            "stackgroup", T<string>
            "xperiod", (T<float> + T<int>) + T<string>
            "xperiodalignment", ScatterPeriodScatterAlignment.Type
            "xperiod0", (T<float> + T<int>) + T<string>
            "yperiod", (T<float> + T<int>) + T<string>
            "yperiodalignment", ScatterPeriodScatterAlignment.Type
            "yperiod0", (T<float> + T<int>) + T<string>
            "marker", Marker.Type
            "line", ScatterLine.Type
            "textfont", ScatterFontConfig.Type
            "error_x", ScatterErrorX.Type
            "error_y", ScatterErrorY.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", ScatterSelectedOption.Type
            "unselected", ScatterSelectedOption.Type // change name later
            "cliponaxis", T<bool>
            "connectgaps", T<bool>
            "fill", ScatterFill.Type
            "fillcolor", ScatterColor
            "hoverlabel", ScatterHoverLabel.Type
            "hoveron", ScatterHoverOn.Type
            "stackgaps", ScatterStackGaps.Type
            "xcalendar", ScatterCalendar.Type
            "ycalendar", ScatterCalendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ScatterTraceNamespaces : CodeModel.NamespaceEntity list = [
        ScatterVisibleString
        ScatterFontConfig
        ScatterLegendGroupScatterTitle
        ScatterModes
        ScatterTextPosition
        ScatterHoverInfo
        ScatterOrientation
        ScatterGroupNorm
        ScatterPeriodScatterAlignment
        ScatterSizeMode
        ScatterMarkerScatterLine
        ScatterGradientType
        ScatterGradient
        ScatterColorBarMode
        ScatterXAnchor
        ScatterYAnchor
        ScatterTickMode
        ScatterTicks
        ScatterTickLabelOverflow
        ScatterTickLabelPosition
        ScatterTickFormatStops
        ScatterShowTickFix
        ScatterExponentFormat
        ScatterSide
        ScatterTitle
        ScatterColorBar
        ScatterSymbol
        Marker
        ScatterShape
        ScatterLine
        ScatterErrorType
        ScatterErrorX
        ScatterErrorY
        ScatterSelectedMarker
        ScatterSelectedTextFont
        ScatterSelectedOption
        ScatterFill
        ScatterAlign
        ScatterHoverLabel
        ScatterHoverOn
        ScatterStackGaps
        ScatterCalendar
        ScatterOptions
    ]