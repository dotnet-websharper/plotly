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

module ScatterGeoModule =

    let ScatterGeoNullValue = Pattern.EnumInlines "ScatterGeoNullValue" ["null", "null"]

    let ScatterGeoColor = T<string> + (T<float> + T<int>) + (!| (!? (ScatterGeoNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (ScatterGeoNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let ScatterGeoColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let ScatterGeoVisibleString = Pattern.EnumStrings "ScatterGeoVisibleString" ["legendonly"]

    let ScatterGeoFont =
        Pattern.Config "ScatterGeoFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", ScatterGeoColor
            ]
        }

    let ScatterGeoLegendGroupTitle =
        Pattern.Config "ScatterGeoLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ScatterGeoFont.Type
            ]
        }

    let ScatterGeoModes =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["lines"; "markers"; "text"] '+')
            let seq2 = seq{"none"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ScatterGeoModes" generatedEnum

    let ScatterGeoTextPosition =
        Pattern.EnumInlines "ScatterGeoTextPosition" [
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

    let ScatterGeoHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["lon"; "lat"; "location"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ScatterGeoHoverInfo" generatedEnum

    let ScatterGeoSizeMode =
        Pattern.EnumStrings "ScatterGeoSizeMode" [
            "diameter"
            "area"
        ]

    let ScatterGeoMarkerLine =
        Pattern.Config "ScatterGeoMarkerLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
                "color", ScatterGeoColor
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", ScatterGeoColorScale
                "autocolorscale", T<bool>
                "reversescale", T<bool>
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let ScatterGeoGradientType =
        Pattern.EnumStrings "ScatterGeoGradientType" [
            "radial"
            "horizontal"
            "vertical"
            "none"
        ]

    let ScatterGeoGradient =
        Pattern.Config "ScatterGeoGradient" {
            Required = []
            Optional = [
                "type", ScatterGeoGradientType.Type
                "color", ScatterGeoColor + !| ScatterGeoColor
            ]
        }

    let ScatterGeoColorBarMode =
        Pattern.EnumStrings "ScatterGeoThicknessMode" [
            "fraction"
            "pixels"
        ]

    let ScatterGeoXAnchor =
        Pattern.EnumStrings "ScatterGeoXAnchor" [
            "left"
            "center"
            "right"
        ]

    let ScatterGeoYAnchor =
        Pattern.EnumStrings "ScatterGeoYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let ScatterGeoTickMode =
        Pattern.EnumStrings "ScatterGeoTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let ScatterGeoTicks =
        Pattern.EnumInlines "ScatterGeoTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let ScatterGeoTickLabelOverflow =
        Pattern.EnumInlines "ScatterGeoTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let ScatterGeoTickLabelPosition =
        Pattern.EnumInlines "ScatterGeoTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let ScatterGeoTickFormatStops =
        Pattern.Config "ScatterGeoTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + ScatterGeoNullValue.Type) * (DTickValue + ScatterGeoNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let ScatterGeoShowTickFix =
        Pattern.EnumStrings "ScatterGeoShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = ScatterGeoShowTickFix

    let ScatterGeoExponentFormat =
        Pattern.EnumInlines "ScatterGeoExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let ScatterGeoSide =
        Pattern.EnumStrings "ScatterGeoSide" [
            "right"
            "top"
            "bottom"
        ]

    let ScatterGeoTitle =
        Pattern.Config "ScatterGeoTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ScatterGeoFont.Type
                "side", ScatterGeoSide.Type
            ]
        }

    let ScatterGeoColorBar =
        Pattern.Config "ScatterGeoColorBar" {
            Required = []
            Optional = [
                "thicknessmode", ScatterGeoColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", ScatterGeoColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", ScatterGeoXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", ScatterGeoYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", ScatterGeoColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", ScatterGeoColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", ScatterGeoColor
                "tickmode", ScatterGeoTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", ScatterGeoTicks.Type
                "ticklabeloverflow", ScatterGeoTickLabelOverflow.Type
                "ticklabelposition", ScatterGeoTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", ScatterGeoColor
                "showticklabels", T<bool>
                "tickfont", ScatterGeoFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", ScatterGeoTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", ScatterGeoShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", ScatterGeoShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", ScatterGeoExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", ScatterGeoTitle.Type
            ]
        }

    let ScatterGeoSymbol =
        Pattern.EnumStrings "ScatterGeoSymbol" [
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

    let ScatterGeoMarker =
        Pattern.Config "ScatterGeoMarker" {
            Required = []
            Optional = [
                "symbol", ScatterGeoSymbol.Type
                "opacity", T<float> + !| T<float>
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "sizeref", (T<float> + T<int>)
                "sizemin", (T<float> + T<int>)
                "sizemode", ScatterGeoSizeMode.Type
                "line", ScatterGeoMarkerLine.Type
                "gradient", ScatterGeoGradient.Type
                "color", ScatterGeoColor + !| ScatterGeoColor
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", ScatterGeoColorScale
                "autocolorscale", T<bool>
                "reverscale", T<bool>
                "showscale", T<bool>
                "colorbar", ScatterGeoColorBar.Type
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let ScatterGeoLine =
        Pattern.Config "ScatterGeoLine" {
            Required = []
            Optional = [
                "color", ScatterGeoColor
                "width", (T<float> + T<int>)
                "dash", T<string>
            ]
        }

    let ScatterGeoSelectedMarker =
        Pattern.Config "ScatterGeoSelectedMarker" {
            Required = []
            Optional = [
                "opacity", (T<float> + T<int>)
                "color", ScatterGeoColor
                "size", (T<float> + T<int>)
            ]
        }

    let ScatterGeoSelectedTextFont =
        Pattern.Config "ScatterGeoSelectedTextFont" {
            Required = []
            Optional = ["color", ScatterGeoColor]
        }

    let ScatterGeoSelectedOption =
        Pattern.Config "ScatterGeoSelectedOption" {
            Required = []
            Optional = [
                "marker", ScatterGeoSelectedMarker.Type
                "textfont", ScatterGeoSelectedTextFont.Type
            ]
        }

    let ScatterGeoFill =
        Pattern.EnumStrings "ScatterGeoFill" [
            "none"
            "tozeroy"
            "tozerox"
            "tonexty"
            "tonextx"
            "toself"
            "tonext"
        ]

    let ScatterGeoAlign =
        Pattern.EnumStrings "ScatterGeoAlign" [
            "left"
            "right"
            "auto"
        ]

    let ScatterGeoHoverLabel =
        Pattern.Config "ScatterGeoHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", ScatterGeoColor + !| ScatterGeoColor
                "bordercolor", ScatterGeoColor + !| ScatterGeoColor
                "fonts", ScatterGeoFont.Type
                "align", ScatterGeoAlign.Type
                "namelength", T<int>
            ]
        }

    let ScatterGeoLocationMode =
        Pattern.EnumInlines "ScatterGeoLocationMode" [
            "ISO-3", "'ISO-3'"
            "USA-states", "'USA-states'"
            "countryNames", "'country names'"
            "geojson-id", "'geojson-id'"
        ]

    let ScatterGeoOptions =
        Class "ScatterGeoOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'scattergeo'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + ScatterGeoVisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", ScatterGeoLegendGroupTitle.Type
            "opacity", T<float>
            "mode", ScatterGeoModes.Type
            "ids", !| T<string>
            "lat", !| T<int> + !| T<float> + !| T<string>
            "geojson", T<int> + T<float> + T<string>
            "featureidkey", T<string>
            "locations", !| T<int> + !| T<float> + !| T<string>
            "lon", !| T<int> + !| T<float> + !| T<string>
            "text", T<string> + !| T<string>
            "textposition", !| ScatterGeoTextPosition.Type
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", ScatterGeoHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "geo", T<string> //subplotid
            "marker", ScatterGeoMarker.Type
            "line", ScatterGeoLine.Type
            "textfont", ScatterGeoFont.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", ScatterGeoSelectedOption.Type
            "unselected", ScatterGeoSelectedOption.Type // change name later
            "connectgaps", T<bool>
            "fill", ScatterGeoFill.Type
            "fillcolor", ScatterGeoColor
            "hoverlabel", ScatterGeoHoverLabel.Type
            "locationmode", ScatterGeoLocationMode.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ScatterGeoTraceNamespaces : CodeModel.NamespaceEntity list = [
        ScatterGeoNullValue
        ScatterGeoVisibleString
        ScatterGeoFont
        ScatterGeoLegendGroupTitle
        ScatterGeoModes 
        ScatterGeoTextPosition
        ScatterGeoHoverInfo
        ScatterGeoSizeMode
        ScatterGeoMarkerLine
        ScatterGeoGradientType
        ScatterGeoGradient
        ScatterGeoColorBarMode
        ScatterGeoXAnchor
        ScatterGeoYAnchor
        ScatterGeoTickMode
        ScatterGeoTicks
        ScatterGeoTickLabelOverflow
        ScatterGeoTickLabelPosition
        ScatterGeoTickFormatStops
        ScatterGeoShowTickFix
        ScatterGeoExponentFormat
        ScatterGeoSide
        ScatterGeoTitle
        ScatterGeoColorBar
        ScatterGeoSymbol
        ScatterGeoMarker
        ScatterGeoLine
        ScatterGeoSelectedMarker
        ScatterGeoSelectedTextFont
        ScatterGeoSelectedOption
        ScatterGeoFill
        ScatterGeoAlign
        ScatterGeoHoverLabel
        ScatterGeoLocationMode
        ScatterGeoOptions
    ]