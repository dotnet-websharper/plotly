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

module ScatterCarpetModule =

    let ScatterCarpetNullValue = Pattern.EnumInlines "ScatterCarpetNullValue" ["null", "null"]

    let ScatterCarpetColor = T<string> + (T<float> + T<int>) + (!| (!? (ScatterCarpetNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (ScatterCarpetNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let ScatterCarpetColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let ScatterCarpetVisibleString = Pattern.EnumStrings "ScatterCarpetVisibleString" ["legendonly"]

    let ScatterCarpetFont =
        Pattern.Config "ScatterCarpetFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", ScatterCarpetColor
            ]
        }

    let ScatterCarpetLegendGroupTitle =
        Pattern.Config "ScatterCarpetLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ScatterCarpetFont.Type
            ]
        }

    let ScatterCarpetModes =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["lines"; "markers"; "text"] '+')
            let seq2 = seq{"none"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ScatterCarpetModes" generatedEnum

    let ScatterCarpetTextPosition =
        Pattern.EnumInlines "ScatterCarpetTextPosition" [
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

    let ScatterCarpetHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["a"; "b"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ScatterCarpetHoverInfo" generatedEnum

    let ScatterCarpetSizeMode =
        Pattern.EnumStrings "ScatterCarpetSizeMode" [
            "diameter"
            "area"
        ]

    let ScatterCarpetMarkerLine =
        Pattern.Config "ScatterCarpetMarkerLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
                "color", ScatterCarpetColor
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", ScatterCarpetColorScale
                "autocolorscale", T<bool>
                "reversescale", T<bool>
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let ScatterCarpetGradientType =
        Pattern.EnumStrings "ScatterCarpetGradientType" [
            "radial"
            "horizontal"
            "vertical"
            "none"
        ]

    let ScatterCarpetGradient =
        Pattern.Config "ScatterCarpetGradient" {
            Required = []
            Optional = [
                "type", ScatterCarpetGradientType.Type
                "color", ScatterCarpetColor + !| ScatterCarpetColor
            ]
        }

    let ScatterCarpetColorBarMode =
        Pattern.EnumStrings "ScatterCarpetColorBarMode" [
            "fraction"
            "pixels"
        ]

    let ScatterCarpetXAnchor =
        Pattern.EnumStrings "ScatterCarpetXAnchor" [
            "left"
            "center"
            "right"
        ]

    let ScatterCarpetYAnchor =
        Pattern.EnumStrings "ScatterCarpetYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let ScatterCarpetTickMode =
        Pattern.EnumStrings "ScatterCarpetTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let ScatterCarpetTicks =
        Pattern.EnumInlines "ScatterCarpetTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let ScatterCarpetTickLabelOverflow =
        Pattern.EnumInlines "ScatterCarpetTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let ScatterCarpetTickLabelPosition =
        Pattern.EnumInlines "ScatterCarpetTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let ScatterCarpetTickFormatStops =
        Pattern.Config "ScatterCarpetTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + ScatterCarpetNullValue.Type) * (DTickValue + ScatterCarpetNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let ScatterCarpetShowTickFix =
        Pattern.EnumStrings "ScatterCarpetShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = ScatterCarpetShowTickFix

    let ScatterCarpetExponentFormat =
        Pattern.EnumInlines "ScatterCarpetExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let ScatterCarpetSide =
        Pattern.EnumStrings "ScatterCarpetSide" [
            "right"
            "top"
            "bottom"
        ]

    let ScatterCarpetTitle =
        Pattern.Config "ScatterCarpetTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ScatterCarpetFont.Type
                "side", ScatterCarpetSide.Type
            ]
        }

    let ScatterCarpetColorBar =
        Pattern.Config "ScatterCarpetColorBar" {
            Required = []
            Optional = [
                "thicknessmode", ScatterCarpetColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", ScatterCarpetColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", ScatterCarpetXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", ScatterCarpetYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", ScatterCarpetColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", ScatterCarpetColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", ScatterCarpetColor
                "tickmode", ScatterCarpetTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", ScatterCarpetTicks.Type
                "ticklabeloverflow", ScatterCarpetTickLabelOverflow.Type
                "ticklabelposition", ScatterCarpetTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", ScatterCarpetColor
                "showticklabels", T<bool>
                "tickfont", ScatterCarpetFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", ScatterCarpetTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", ScatterCarpetShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", ScatterCarpetShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", ScatterCarpetExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", ScatterCarpetTitle.Type
            ]
        }

    let ScatterCarpetSymbol =
        Pattern.EnumStrings "ScatterCarpetSymbol" [
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

    let ScatterCarpetMarker =
        Pattern.Config "ScatterCarpetMarker" {
            Required = []
            Optional = [
                "symbol", ScatterCarpetSymbol.Type
                "opacity", T<float> + !| T<float>
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "maxdisplayed", (T<float> + T<int>)
                "sizeref", (T<float> + T<int>)
                "sizemin", (T<float> + T<int>)
                "sizemode", ScatterCarpetSizeMode.Type
                "line", ScatterCarpetMarkerLine.Type
                "gradient", ScatterCarpetGradient.Type
                "color", ScatterCarpetColor + !| ScatterCarpetColor
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", ScatterCarpetColorScale
                "autocolorscale", T<bool>
                "reverscale", T<bool>
                "showscale", T<bool>
                "colorbar", ScatterCarpetColorBar.Type
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let ScatterCarpetShape =
        Pattern.EnumStrings "ScatterCarpetShape" [
            "linear"
            "spline"
            "hv"
            "vh"
            "hvh"
            "vhv"
        ]

    let ScatterCarpetLine =
        Pattern.Config "ScatterCarpetLine" {
            Required = []
            Optional = [
                "color", ScatterCarpetColor
                "width", (T<float> + T<int>)
                "shape", ScatterCarpetShape.Type
                "smoothing", (T<float> + T<int>)
                "dash", T<string>
            ]
        }

    let ScatterCarpetSelectedMarker =
        Pattern.Config "ScatterCarpetSelectedMarker" {
            Required = []
            Optional = [
                "opacity", (T<float> + T<int>)
                "color", ScatterCarpetColor
                "size", (T<float> + T<int>)
            ]
        }

    let ScatterCarpetSelectedTextFont =
        Pattern.Config "ScatterCarpetSelectedTextFont" {
            Required = []
            Optional = ["color", ScatterCarpetColor]
        }

    let ScatterCarpetSelectedOption =
        Pattern.Config "ScatterCarpetSelectedOption" {
            Required = []
            Optional = [
                "marker", ScatterCarpetSelectedMarker.Type
                "textfont", ScatterCarpetSelectedTextFont.Type
            ]
        }

    let ScatterCarpetFill =
        Pattern.EnumStrings "ScatterCarpetFill" [
            "none"
            "tozeroy"
            "tozerox"
            "tonexty"
            "tonextx"
            "toself"
            "tonext"
        ]

    let ScatterCarpetAlign =
        Pattern.EnumStrings "ScatterCarpetAlign" [
            "left"
            "right"
            "auto"
        ]

    let ScatterCarpetHoverLabel =
        Pattern.Config "ScatterCarpetHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", ScatterCarpetColor + !| ScatterCarpetColor
                "bordercolor", ScatterCarpetColor + !| ScatterCarpetColor
                "fonts", ScatterCarpetFont.Type
                "align", ScatterCarpetAlign.Type
                "namelength", T<int>
            ]
        }

    let ScatterCarpetHoverOn =
        let generatedEnum = GenerateOptions.allPermutations ["points"; "fills"] '+'
        Pattern.EnumStrings "ScatterCarpetHoverOn" generatedEnum

    let ScatterCarpetOptions =
        Class "ScatterCarpetOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'ScatterCarpet'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + ScatterCarpetVisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", ScatterCarpetLegendGroupTitle.Type
            "opacity", T<float>
            "mode", ScatterCarpetModes.Type
            "ids", !| T<string>
            "a", !| T<int> + !| T<float>
            "b", !| T<int> + !| T<float>
            "text", T<string> + !| T<string>
            "textposition", ScatterCarpetTextPosition.Type
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", ScatterCarpetHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "xaxis", T<string> //type is 'subplotid'
            "yaxis", T<string> //type is 'subplotid'
            "marker", ScatterCarpetMarker.Type
            "line", ScatterCarpetLine.Type
            "textfont", ScatterCarpetFont.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", ScatterCarpetSelectedOption.Type
            "unselected", ScatterCarpetSelectedOption.Type // change name later
            "carpet", T<string>
            "connectgaps", T<bool>
            "fill", ScatterCarpetFill.Type
            "fillcolor", ScatterCarpetColor
            "hoverlabel", ScatterCarpetHoverLabel.Type
            "hoveron", ScatterCarpetHoverOn.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ScatterCarpetTraceNamespaces : CodeModel.NamespaceEntity list = [
        ScatterCarpetNullValue
        ScatterCarpetVisibleString
        ScatterCarpetFont
        ScatterCarpetLegendGroupTitle
        ScatterCarpetModes
        ScatterCarpetTextPosition
        ScatterCarpetHoverInfo
        ScatterCarpetSizeMode
        ScatterCarpetMarkerLine
        ScatterCarpetColorBarMode
        ScatterCarpetXAnchor
        ScatterCarpetYAnchor
        ScatterCarpetTickMode
        ScatterCarpetTicks
        ScatterCarpetTickLabelOverflow
        ScatterCarpetTickLabelPosition
        ScatterCarpetTickFormatStops
        ScatterCarpetShowTickFix
        ShowExponent
        ScatterCarpetExponentFormat
        ScatterCarpetSide
        ScatterCarpetTitle
        ScatterCarpetColorBar
        ScatterCarpetSymbol
        ScatterCarpetMarker
        ScatterCarpetShape
        ScatterCarpetLine
        ScatterCarpetSelectedMarker
        ScatterCarpetSelectedTextFont
        ScatterCarpetSelectedOption
        ScatterCarpetFill
        ScatterCarpetAlign
        ScatterCarpetHoverLabel
        ScatterCarpetHoverOn
        ScatterCarpetOptions
    ]