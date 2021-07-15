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

module ViolinModule =

    let ViolinNullValue = Pattern.EnumInlines "ViolinNullValue" ["null", "null"]

    let ViolinColor = T<string> + (T<float> + T<int>) + (!| (!? (ViolinNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (ViolinNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let ViolinColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let ViolinVisibleString = Pattern.EnumStrings "ViolinVisibleString" ["legendonly"]

    let ViolinFont =
        Pattern.Config "ViolinFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", ViolinColor
            ]
        }

    let ViolinLegendGroupTitle =
        Pattern.Config "ViolinLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ViolinFont.Type
            ]
        }

    let ViolinHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ViolinHoverInfo" generatedEnum

    let ViolinOrientation =
        Pattern.EnumStrings "ViolinOrientation" [
            "v"
            "h"
        ]

    let ViolinSizeMode =
        Pattern.EnumStrings "ViolinSizeMode" [
            "diameter"
            "area"
        ]

    let ViolinMarkerLine =
        Pattern.Config "ViolinMarkerLine" {
            Required = []
            Optional = [
                "color", ViolinColor
                "width", T<float> + T<int>
                "outliercolor", ViolinColor
                "outlierwidth", T<float> + T<int>
            ]
        }

    let ViolinGradientType =
        Pattern.EnumStrings "ViolinGradientType" [
            "radial"
            "horizontal"
            "vertical"
            "none"
        ]

    let ViolinGradient =
        Pattern.Config "ViolinGradient" {
            Required = []
            Optional = [
                "type", ViolinGradientType.Type
                "color", ViolinColor + !| ViolinColor
            ]
        }

    let ViolinSymbol =
        Pattern.EnumStrings "ViolinSymbol" [
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

    let ViolinMarker =
        Pattern.Config "ViolinMarker" {
            Required = []
            Optional = [
                "outliercolor", ViolinColor
                "symbol", ViolinSymbol.Type
                "opacity", T<float> + !| T<float>
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "color", ViolinColor
                "line", ViolinMarkerLine.Type
            ]
        }

    let ViolinShape =
        Pattern.EnumStrings "ViolinShape" [
            "linear"
            "spline"
            "hv"
            "vh"
            "hvh"
            "vhv"
        ]

    let ViolinSelectedMarker =
        Pattern.Config "ViolinSelectedMarker" {
            Required = []
            Optional = [
                "opacity", (T<float> + T<int>)
                "color", ViolinColor
                "size", (T<float> + T<int>)
            ]
        }

    let ViolinSelectedTextFont =
        Pattern.Config "ViolinSelectedTextFont" {
            Required = []
            Optional = ["color", ViolinColor]
        }

    let ViolinSelectedOption =
        Pattern.Config "ViolinSelectedOption" {
            Required = []
            Optional = [
                "marker", ViolinSelectedMarker.Type
                "textfont", ViolinSelectedTextFont.Type
            ]
        }

    let ViolinAlign =
        Pattern.EnumStrings "ViolinAlign" [
            "left"
            "right"
            "auto"
        ]

    let ViolinHoverLabel =
        Pattern.Config "ViolinHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", ViolinColor + !| ViolinColor
                "bordercolor", ViolinColor + !| ViolinColor
                "fonts", ViolinFont.Type
                "align", ViolinAlign.Type
                "namelength", T<int>
            ]
        }

    let ViolinHoverOn =
        let generatedEnum = 
            let seq1 = GenerateOptions.allPermutations ["violins"; "points"; "kde"] '+'
            let seq2 = seq{"all"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ViolinHoverOn" generatedEnum

    let ViolinBoxLine =
        Pattern.Config "ViolinBoxLine" {
            Required = []
            Optional = [
                "color", ViolinColor
                "width", T<int> + T<float>
            ]
        }

    let ViolinBox =
        Pattern.Config "ViolinBox" {
            Required = []
            Optional = [
                "visible", T<bool>
                "width", T<float>
                "fillcolor", ViolinColor
                "line", ViolinBoxLine.Type
            ]
        }

    let ViolinMeanLine =
        Pattern.Config "ViolinMeanLine" {
            Required = []
            Optional = [
                "visible", T<bool>
                "color", ViolinColor
                "width", T<int> + T<float>
            ]
        }

    let ViolinPoints =
        Pattern.EnumStrings "ViolinPoints" [
            "all"
            "outliers"
            "suspectedoutliers"
            "none"
        ]

    let ViolinScaleMode =
        Pattern.EnumStrings "ViolinScaleMode" [
            "width"
            "count"
        ]

    let ViolinSide =
        Pattern.EnumStrings "ViolinSide" [
            "both"
            "positive"
            "negative"
        ]

    let ViolinSpanMode =
        Pattern.EnumStrings "ViolinSpanMode" [
            "soft"
            "hard"
            "manual"
        ]
 
    let ViolinLine =
        Pattern.Config "ViolinLine" {
            Required = []
            Optional = [
                "color", ViolinColor
                "width", T<int> + T<float>
            ]
        }

    let ViolinOptions =
        Class "ViolinOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'violin'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + ViolinVisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", ViolinLegendGroupTitle.Type
            "opacity", T<float>
            "ids", !| T<string>
            "x", !| T<int> + !| T<float>
            "x0", (T<float> + T<int>) + T<string>
            "y", !| T<int> + !| T<float>
            "y0", (T<float> + T<int>) + T<string>
            "width", T<float> + T<int>
            "text", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", ViolinHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "xaxis", T<string> //type is 'subplotid'
            "yaxis", T<string> //type is 'subplotid'
            "orientation", ViolinOrientation.Type
            "alignmentgroup", T<string>
            "offsetgroup", T<string>
            "marker", ViolinMarker.Type
            "line", ViolinLine.Type
            "textfont", ViolinFont.Type
            "box", ViolinBox.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", ViolinSelectedOption.Type
            "unselected", ViolinSelectedOption.Type // change name later
            "bandwidth", T<int> + T<float>
            "fillcolor", ViolinColor
            "hoverlabel", ViolinHoverLabel.Type
            "hoveron", ViolinHoverOn.Type
            "pointpos", T<int> + T<float>
            "jitter", T<float>
            "meanline", ViolinMeanLine.Type
            "points", ViolinPoints.Type + T<bool>
            "scalegroup", T<string>
            "scalemode", ViolinScaleMode.Type
            "side", ViolinSide.Type
            "span", !| T<float> + !| T<int> + !| T<string>
            "spanmode", ViolinSpanMode.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ViolinTraceNamespaces : CodeModel.NamespaceEntity list = [
        ViolinVisibleString
        ViolinFont
        ViolinLegendGroupTitle
        ViolinHoverInfo
        ViolinOrientation
        ViolinSizeMode
        ViolinMarkerLine
        ViolinGradientType
        ViolinGradient
        ViolinSymbol
        ViolinMarker
        ViolinShape
        ViolinBoxLine
        ViolinSelectedMarker
        ViolinSelectedTextFont
        ViolinSelectedOption
        ViolinAlign
        ViolinHoverLabel
        ViolinHoverOn
        ViolinOptions
        ViolinBox
        ViolinMeanLine
        ViolinPoints
        ViolinScaleMode
        ViolinSide
        ViolinSpanMode
        ViolinLine
    ]