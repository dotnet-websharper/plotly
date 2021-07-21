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

module SplomModule =

    open CommonModule

    let SplomHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all";"none";"skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "SplomHoverInfo" generatedEnum

    let SplomDimensionAxisType =
        Pattern.EnumStrings "SplomDimensionAxisType" [
            "linear"
            "log"
            "date"
            "category"
        ]

    let SplomDimensionAxis =
        Pattern.Config "SplomDimensionAxis" {
            Required = []
            Optional = [
                "type", SplomDimensionAxisType.Type
                "matches", T<bool>
            ]
        }

    let SplomDimensions =
        Pattern.Config "SplomDimensions" {
            Required = []
            Optional = [
                "visible", T<bool>
                "label", T<string>
                "values", !| T<string> + !| T<int> + !| T<float>
                "axis", SplomDimensionAxis.Type
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let SplomMarkerLine =
        Pattern.Config "SplomMarkerLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
                "color",Color + !| Color //data array
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", ColorScale
                "autocolorscale", T<bool>
                "reverscale", T<bool>
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let SplomMarkerSizeMode =
        Pattern.EnumStrings "SplomMarkerSizeMode" [
            "diameter"
            "area"
        ]

    let SplomMarkerSymbol =
        Pattern.EnumStrings "SplomMarkerSymbol" [
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

    let SplomMarker =
        Pattern.Config "SplomMarker" {
            Required = []
            Optional = [
                "line", SplomMarkerLine.Type
                "color", Color + !| Color //data array
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
                "symbol", SplomMarkerSymbol.Type
                "size", T<int> + T<float> + !| T<int> + !| T<float>
                "sizeref", T<int> + T<float>
                "sizemin", T<int> + T<float>
                "sizemode", SplomMarkerSizeMode.Type
                "opacity", T<float> + !| T<float>
            ]
        }


    let SplomDiagonal =
        Pattern.Config "SplomDiagonal" {
            Required = []
            Optional = [
                "visible", T<bool>
            ]
        }

    let SplomSelectedMarker =
        Pattern.Config "SplomSelectedMarker" {
            Required = []
            Optional = [
                "opacity", T<float>
                "color", Color
                "size", T<int> + T<float>
            ]
        }

    let SplomSelected =
        Pattern.Config "SplomSelected" {
            Required = []
            Optional = [
                "marker", SplomSelectedMarker.Type
            ]
        }

    let SplomOptions =
        Class "SplomOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'splom'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", T<float>
            "ids", !| T<string>
            "text", T<string> + !| T<string>
            "dimensions", SplomDimensions.Type
            "hovertext", T<string> + !| T<string>
            "hoverinfo", SplomHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", !| T<string> + !| T<int> + !| T<float>
            "marker", SplomMarker.Type
            "diagonal", SplomDiagonal.Type
            "xaxes", !| T<string> + !| T<int> + !| T<float>
            "yaxes", !| T<string> + !| T<int> + !| T<float>
            "showlowerhalf", T<bool>
            "showupperhalf", T<bool>
            "selectedpoints", T<int> + T<float> + T<string>
            "selected", SplomSelected.Type
            "unselected", SplomSelected.Type
            "hoverlabel", HoverLabel.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let SplomTraceNamespaces : CodeModel.NamespaceEntity list = [
        SplomHoverInfo
        SplomDimensionAxisType
        SplomDimensionAxis
        SplomDimensions
        SplomMarkerLine
        SplomMarkerSizeMode
        SplomMarkerSymbol
        SplomMarker
        SplomDiagonal
        SplomSelectedMarker
        SplomSelected
        SplomOptions
    ]