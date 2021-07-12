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

module HGModule =

    let HGNullValue = Pattern.EnumInlines "HGNullValue" ["null", "null"]

    let HGColor = T<string> + (T<float> + T<int>) + (!| (!? (HGNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (HGNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let HGColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let HGVisibleString = Pattern.EnumStrings "HGVisibleString" ["legendonly"]

    let HGFont =
        Pattern.Config "HGFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", HGColor
            ]
        }

    let HGLegendGroupTitle =
        Pattern.Config "HGLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", HGFont.Type
            ]
        }

    let HGHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "HGHoverInfo" generatedEnum

    let HGOrientation =
        Pattern.EnumStrings "HGOrientation" [
            "v"
            "h"
        ]

    let HGPeriodAlignment =
        Pattern.EnumStrings "XHGPeriodAlignment" [
            "start"
            "middle"
            "end"
        ]

    let HGMarkerLine =
        Pattern.Config "HGMarkerLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
                "color", HGColor
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", HGColorScale
                "autocolorscale", T<bool>
                "reversescale", T<bool>
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let HGGradientType =
        Pattern.EnumStrings "HGGradientType" [
            "radial"
            "horizontal"
            "vertical"
            "none"
        ]

    let HGGradient =
        Pattern.Config "HGGradient" {
            Required = []
            Optional = [
                "type", HGGradientType.Type
                "color", HGColor + !| HGColor
            ]
        }

    let HGSymbol =
        Pattern.EnumStrings "HGSymbol" [
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
            "arrow-HG-up"
            "149"
            "arrow-HG-up-open"
            "50"
            "arrow-HG-down"
            "150"
            "arrow-HG-down-open"
            "51"
            "arrow-HG-left"
            "151"
            "arrow-HG-left-open"
            "52"
            "arrow-HG-right"
            "152"
            "arrow-HG-right-open"
        ]

let HGThicknessMode =
        Pattern.EnumStrings "HGThicknessMode" [
            "fraction"
            "pixels"
        ]

    let HGXAnchor =
        Pattern.EnumStrings "HGXAnchor" [
            "left"
            "center"
            "right"
        ]

    let HGYAnchor =
        Pattern.EnumStrings "HGYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let HGTickMode =
        Pattern.EnumStrings "HGTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let HGTicks =
        Pattern.EnumInlines "HGTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let HGTickLabelOverflow =
        Pattern.EnumInlines "HGTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let HGTickLabelPosition =
        Pattern.EnumInlines "HGTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let HGTickFormatStops =
        Pattern.Config "HGTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + HGNullValue.Type) * (DTickValue + HGNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let HGShowTickFix =
        Pattern.EnumStrings "HGShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = HGShowTickFix

    let HGExponentFormat =
        Pattern.EnumInlines "HGExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let HGSide =
        Pattern.EnumStrings "HGSide" [
            "right"
            "top"
            "bottom"
        ]

    let HGTitle =
        Pattern.Config "HGTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", HGFontConfig.Type
                "side", HGSide.Type
            ]
        }

    let HGColorHG =
        Pattern.Config "HGColorHG" {
            Required = []
            Optional = [
                "thicknessmode", HGThicknessMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", HGColorHGMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", HGXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", HGYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", HGColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", HGColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", HGColor
                "tickmode", HGTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", HGTicks.Type
                "ticklabeloverflow", HGTickLabelOverflow.Type
                "ticklabelposition", HGTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", HGColor
                "showticklabels", T<bool>
                "tickfont", HGFontConfig.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", HGTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", HGShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", HGShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", HGExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", HGTitle.Type
            ]
        }

    let HGMarkerPatternShape =
        Pattern.EnumInlines "HGMarkerPatternShape" [
            "empty", "''"
            "slash", "'/'"
            "backslash", """'\\'"""
            "x", "'x'"
            "minus", "'-'"
            "pipeline", "'|'"
            "plus", "'+'"
            "dot", "'.'"
        ]

    let HGFillMode =
        Pattern.EnumStrings "HGFillMode" [
            "replace"
            "overlay"
        ]

    let HGMarkerPattern =
        Pattern.Config "HGMarkerPattern" {
            Required = []
            Optional = [
                "shape", HGMarkerPatternShape.Type
                "fillmode", HGFillMode.Type
                "bgcolor", HGColor + !| HGColor
                "fgcolor", HGColor + !| HGColor
                "fgopacity", (T<float> + T<int>)
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "solidity", (T<float> + T<int>) + !| T<float> + !| T<int>               
            ]
        }

    let HGErrorType =
        Pattern.EnumStrings "HGErrorType" [
            "percent"
            "constant"
            "sqrt"
            "data"
        ]

    let HGErrorX = 
        Pattern.Config "HGErrorX" {
            Required = []
            Optional = [
                "visible", T<bool>
                "type", HGErrorType.Type
                "symmetric", T<bool>
                "array", !| T<obj> // data array
                "arrayminus", !| T<obj> // data array
                "value", (T<float> + T<int>)
                "valueminus", (T<float> + T<int>)
                "traceref", T<int>
                "tracerefminus", T<int>
                "copy_ystyle", T<bool>
                "color", HGColor
                "thickness", (T<float> + T<int>)
                "width", (T<float> + T<int>)
            ]
        }

    let HGErrorY = 
        Pattern.Config "HGErrorY" {
            Required = []
            Optional = [
                "visible", T<bool>
                "type", HGErrorType.Type
                "symmetric", T<bool>
                "array", !| T<obj> // data array
                "arrayminus", !| T<obj> // data array
                "value", (T<float> + T<int>)
                "valueminus", (T<float> + T<int>)
                "traceref", T<int>
                "tracerefminus", T<int>
                "color", HGColor
                "thickness", (T<float> + T<int>)
                "width", (T<float> + T<int>)
            ]
        }

    let Marker =
        Pattern.Config "Marker" {
            Required = []
            Optional = [
                "line", HGMarkerLine.Type
                "color", HGColor + !| HGColor
                "cauto", T<bool>
                "cmin", T<int> + T<float>
                "cmax", T<int> + T<float>
                "cmid", T<int> + T<float>
                "colorscale", HGColorScale
                "autocolorscale", T<bool>
                "reversescale", T<bool>
                "showscale", T<bool>
                "colorbar", HGColorHG.Type
                "coloraxis", T<float> + T<int> + T<string>
                "opacity", T<float> + !| T<float>
                "pattern", HGMarkerPattern.Type
            ]
        }

    let HGSelectedMarker =
        Pattern.Config "HGSelectedMarker" {
            Required = []
            Optional = [
                "opacity", (T<float> + T<int>)
                "color", HGColor
                "size", (T<float> + T<int>)
            ]
        }

    let HGSelectedTextFont =
        Pattern.Config "HGSelectedTextFont" {
            Required = []
            Optional = ["color", HGColor]
        }

    let HGSelectedOption =
        Pattern.Config "HGSelectedOption" {
            Required = []
            Optional = [
                "marker", HGSelectedMarker.Type
                "textfont", HGSelectedTextFont.Type
            ]
        }

    let HGAlign =
        Pattern.EnumStrings "HGAlign" [
            "left"
            "right"
            "auto"
        ]

    let HGHoverLabel =
        Pattern.Config "HGHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", HGColor + !| HGColor
                "bordercolor", HGColor + !| HGColor
                "fonts", HGFont.Type
                "align", HGAlign.Type
                "namelength", T<int>
            ]
        }

    let HGHoverOn =
        let generatedEnum = GenerateOptions.allPermutations ["hges"; "points"] '+'
        Pattern.EnumStrings "HGHoverOn" generatedEnum

    let HGCalendar =
        Pattern.EnumStrings "HGCalendar" [
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

    let HGMean =
        Pattern.EnumStrings "HGMean" [
            "sd"
        ]

    let HGPoints =
        Pattern.EnumStrings "HGPoints" [
            "all"
            "outliers"
            "suspectedoutliers"
        ]

    let HGLine =
        Pattern.Config "HGLine" {
            Required = []
            Optional = [
                "color", HGColor
                "width", T<int> + T<float>
            ]
        }

    let HGQuartileMethod =
        Pattern.EnumString "HGQuartileMethod" [
            "linear"
            "exclusive"
            "inclusive"
        ]

    let HGHistFunc =
        Pattern.EnumStrings "HGHistFunc" [
            "count"
            "sum"
            "avg"
            "min"
            "max"
        ]

    let HGHistNorm =
        Pattern.EnumInlines "HGHistNorm" [
            "empty", "''"
            "percent", "'percent'"
            "probability", "'probability'"
            "density", "'density'"
            "probabilityDensity", "'probability density'"
        ]

    let HGXYBins =
        Pattern.Config "HGXYBins" {
            Required = []
            Optional = [
                "start", T<int> + T<float> + T<string>
                "end", T<int> + T<float> + T<string>
                "size", T<int> + T<float> + T<string>
            ]
        }

    let HGDirection =
        Pattern.EnumStrings "HGDirection" [
            "increasing"
            "decreasing"
        ]

    let HGCurrentBin =
        Pattern.EnumStrings "HGCurrentBin" [
            "include"
            "exclude"
            "half"
        ]

    let HGCumulative =
        Pattern.Config "HGCumulative" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "direction", HGDirection.Type
                "currentbin", HGCurrentBin.Type              
            ]
        }

    let HGOptions =
        Class "HGOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'histogram'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + HGVisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", HGLegendGroupTitle.Type
            "opacity", T<float>
            "ids", !| T<string>
            "x", !| T<int> + !| T<float>
            "y", !| T<int> + !| T<float>
            "text", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", HGHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "xaxis", T<string> //type is 'subplotid'
            "yaxis", T<string> //type is 'subplotid'
            "orientation", HGOrientation.Type
            "histfunc", HGHistFunc.Type
            "histnorm", HGHistNorm.Type
            "alignmentgroup", T<string>
            "offsetgroup", T<string>
            "nbinsx", T<int>
            "ybinsx", T<int>
            "autobinx", T<bool>
            "autobiny", T<bool>
            "bingroup", T<string>
            "xbins", HGXYBins.Type
            "ybins", HGXYBins.Type
            "marker", Marker.Type
            "error_x", HGErrorX.Type
            "error_y", HGErrorY.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", HGSelectedOption.Type
            "unselected", HGSelectedOption.Type // change name later
            "cumulative", HGCumulative.Type
            "hoverlabel", HGHoverLabel.Type
            "xcalendar", HGCalendar.Type
            "ycalendar", HGCalendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let HGTraceNamespaces : CodeModel.NamespaceEntity list = [
        HGVisibleString
        HGFont
        HGLine
        HGLegendGroupTitle
        HGHoverInfo
        HGOrientation
        HGPeriodAlignment
        HGMarkerLine
        HGGradientType
        HGGradient
        HGSymbol
        Marker
        HGSelectedMarker
        HGSelectedTextFont
        HGSelectedOption
        HGAlign
        HGHoverLabel
        HGHoverOn
        HGCalendar
        HGMean
        HGPoints
        HGQuartileMethod
        HGOptions
    ]