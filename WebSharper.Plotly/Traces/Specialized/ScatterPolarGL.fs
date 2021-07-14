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

module ScatterPolarGLModule =

    let ScatterPolarGLNullValue = Pattern.EnumInlines "ScatterPolarGLNullValue" ["null", "null"]

    let ScatterPolarGLColor = T<string> + (T<float> + T<int>) + (!| (!? (ScatterPolarGLNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (ScatterPolarGLNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let ScatterPolarGLColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let ScatterPolarGLVisibleString = Pattern.EnumStrings "ScatterPolarGLVisibleString" ["legendonly"]

    let ScatterPolarGLFont =
        Pattern.Config "ScatterPolarGLFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", ScatterPolarGLColor
            ]
        }

    let ScatterPolarGLLegendGroupTitle =
        Pattern.Config "ScatterPolarGLLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ScatterPolarGLFont.Type
            ]
        }

    let ScatterPolarGLModes =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["lines"; "markers"; "text"] '+')
            let seq2 = seq{"none"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ScatterPolarGLModes" generatedEnum

    let ScatterPolarGLTextPosition =
        Pattern.EnumInlines "ScatterPolarGLTextPosition" [
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

    let ScatterPolarGLHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["r"; "thetea"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ScatterPolarGLHoverInfo" generatedEnum

    let ScatterPolarGLSizeMode =
        Pattern.EnumStrings "ScatterPolarGLSizeMode" [
            "diameter"
            "area"
        ]

    let ScatterPolarGLMarkerLine =
        Pattern.Config "ScatterPolarGLMarkerLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
                "color", ScatterPolarGLColor
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", ScatterPolarGLColorScale
                "autocolorscale", T<bool>
                "reversescale", T<bool>
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let ScatterPolarGLColorBarMode =
        Pattern.EnumStrings "ScatterPolarGLThicknessMode" [
            "fraction"
            "pixels"
        ]

    let ScatterPolarGLXAnchor =
        Pattern.EnumStrings "ScatterPolarGLXAnchor" [
            "left"
            "center"
            "right"
        ]

    let ScatterPolarGLYAnchor =
        Pattern.EnumStrings "ScatterPolarGLYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let ScatterPolarGLTickMode =
        Pattern.EnumStrings "ScatterPolarGLTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let ScatterPolarGLTicks =
        Pattern.EnumInlines "ScatterPolarGLTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let ScatterPolarGLTickLabelOverflow =
        Pattern.EnumInlines "ScatterPolarGLTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let ScatterPolarGLTickLabelPosition =
        Pattern.EnumInlines "ScatterPolarGLTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let ScatterPolarGLTickFormatStops =
        Pattern.Config "ScatterPolarGLTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + ScatterPolarGLNullValue.Type) * (DTickValue + ScatterPolarGLNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let ScatterPolarGLShowTickFix =
        Pattern.EnumStrings "ScatterPolarGLShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = ScatterPolarGLShowTickFix

    let ScatterPolarGLExponentFormat =
        Pattern.EnumInlines "ScatterPolarGLExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let ScatterPolarGLSide =
        Pattern.EnumStrings "ScatterPolarGLSide" [
            "right"
            "top"
            "bottom"
        ]

    let ScatterPolarGLTitle =
        Pattern.Config "ScatterPolarGLTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ScatterPolarGLFont.Type
                "side", ScatterPolarGLSide.Type
            ]
        }

    let ScatterPolarGLColorBar =
        Pattern.Config "ScatterPolarGLColorBar" {
            Required = []
            Optional = [
                "thicknessmode", ScatterPolarGLColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", ScatterPolarGLColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", ScatterPolarGLXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", ScatterPolarGLYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", ScatterPolarGLColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", ScatterPolarGLColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", ScatterPolarGLColor
                "tickmode", ScatterPolarGLTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", ScatterPolarGLTicks.Type
                "ticklabeloverflow", ScatterPolarGLTickLabelOverflow.Type
                "ticklabelposition", ScatterPolarGLTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", ScatterPolarGLColor
                "showticklabels", T<bool>
                "tickfont", ScatterPolarGLFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", ScatterPolarGLTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", ScatterPolarGLShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", ScatterPolarGLShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", ScatterPolarGLExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", ScatterPolarGLTitle.Type
            ]
        }

    let ScatterPolarGLSymbol =
        Pattern.EnumStrings "ScatterPolarGLSymbol" [
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

    let ScatterPolarGLMarker =
        Pattern.Config "ScatterPolarGLMarker" {
            Required = []
            Optional = [
                "symbol", ScatterPolarGLSymbol.Type
                "opacity", T<float> + !| T<float>
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "sizeref", (T<float> + T<int>)
                "sizemin", (T<float> + T<int>)
                "sizemode", ScatterPolarGLSizeMode.Type
                "line", ScatterPolarGLMarkerLine.Type
                "color", ScatterPolarGLColor + !| ScatterPolarGLColor
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", ScatterPolarGLColorScale
                "autocolorscale", T<bool>
                "reverscale", T<bool>
                "showscale", T<bool>
                "colorbar", ScatterPolarGLColorBar.Type
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let ScatterPolarGLShape =
        Pattern.EnumStrings "ScatterPolarGLShape" [
            "linear"
            "hv"
            "vh"
            "hvh"
            "vhv"
        ]

    let ScatterPolarGLLineDash =
        Pattern.EnumStrings "ScatterPolarGLLineDash" [
            "solid"
            "dot"
            "dash"
            "longdash"
            "dashdot"
            "longdashdot"
        ]

    let ScatterPolarGLLine =
        Pattern.Config "ScatterPolarGLLine" {
            Required = []
            Optional = [
                "color", ScatterPolarGLColor
                "width", (T<float> + T<int>)
                "shape", ScatterPolarGLShape.Type
                "dash", ScatterPolarGLLineDash.Type
            ]
        }

    let ScatterPolarGLSelectedMarker =
        Pattern.Config "ScatterPolarGLSelectedMarker" {
            Required = []
            Optional = [
                "opacity", (T<float> + T<int>)
                "color", ScatterPolarGLColor
                "size", (T<float> + T<int>)
            ]
        }

    let ScatterPolarGLSelectedTextFont =
        Pattern.Config "ScatterPolarGLSelectedTextFont" {
            Required = []
            Optional = ["color", ScatterPolarGLColor]
        }

    let ScatterPolarGLSelectedOption =
        Pattern.Config "ScatterPolarGLSelectedOption" {
            Required = []
            Optional = [
                "marker", ScatterPolarGLSelectedMarker.Type
                "textfont", ScatterPolarGLSelectedTextFont.Type
            ]
        }

    let ScatterPolarGLFill =
        Pattern.EnumStrings "ScatterPolarGLFill" [
            "none"
            "tozeroy"
            "tozerox"
            "tonexty"
            "tonextx"
            "toself"
            "tonext"
        ]

    let ScatterPolarGLAlign =
        Pattern.EnumStrings "ScatterPolarGLAlign" [
            "left"
            "right"
            "auto"
        ]

    let ScatterPolarGLHoverLabel =
        Pattern.Config "ScatterPolarGLHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", ScatterPolarGLColor + !| ScatterPolarGLColor
                "bordercolor", ScatterPolarGLColor + !| ScatterPolarGLColor
                "fonts", ScatterPolarGLFont.Type
                "align", ScatterPolarGLAlign.Type
                "namelength", T<int>
            ]
        }

    let ScatterPolarGLThetaUnit =
        Pattern.EnumStrings "ScatterPolarGLThetaUnit" [
            "radians"
            "degrees"
            "gradians"
        ]

    let ScatterPolarGLOptions =
        Class "ScatterPolarGLOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'scatterpolargl'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + ScatterPolarGLVisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", ScatterPolarGLLegendGroupTitle.Type
            "opacity", T<float>
            "mode", ScatterPolarGLModes.Type
            "ids", !| T<string>
            "r", !| T<int> + !| T<float>
            "r0", (T<float> + T<int>) + T<string>
            "dr", (T<float> + T<int>)
            "theta", !| T<int> + !| T<float>
            "theta0", (T<float> + T<int>) + T<string>
            "dtheta", (T<float> + T<int>)
            "thetaunit", ScatterPolarGLThetaUnit.Type
            "text", T<string> + !| T<string>
            "textposition", ScatterPolarGLTextPosition.Type
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", ScatterPolarGLHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "subplot", T<string> //type is 'subplotid'
            "marker", ScatterPolarGLMarker.Type
            "line", ScatterPolarGLLine.Type
            "textfont", ScatterPolarGLFont.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", ScatterPolarGLSelectedOption.Type
            "unselected", ScatterPolarGLSelectedOption.Type // change name later
            "connectgaps", T<bool>
            "fill", ScatterPolarGLFill.Type
            "fillcolor", ScatterPolarGLColor
            "hoverlabel", ScatterPolarGLHoverLabel.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ScatterPolarGLTraceNamespaces : CodeModel.NamespaceEntity list = [
        ScatterPolarGLNullValue
        ScatterPolarGLVisibleString
        ScatterPolarGLFont
        ScatterPolarGLLegendGroupTitle
        ScatterPolarGLModes
        ScatterPolarGLTextPosition
        ScatterPolarGLHoverInfo
        ScatterPolarGLSizeMode
        ScatterPolarGLMarkerLine
        ScatterPolarGLColorBarMode
        ScatterPolarGLXAnchor
        ScatterPolarGLYAnchor
        ScatterPolarGLTickMode
        ScatterPolarGLTicks
        ScatterPolarGLTickLabelOverflow
        ScatterPolarGLTickLabelPosition
        ScatterPolarGLTickFormatStops
        ScatterPolarGLShowTickFix
        ScatterPolarGLExponentFormat
        ScatterPolarGLSide
        ScatterPolarGLTitle
        ScatterPolarGLColorBar
        ScatterPolarGLSymbol
        ScatterPolarGLMarker
        ScatterPolarGLShape
        ScatterPolarGLLineDash
        ScatterPolarGLLine
        ScatterPolarGLSelectedMarker
        ScatterPolarGLSelectedTextFont
        ScatterPolarGLSelectedOption
        ScatterPolarGLFill
        ScatterPolarGLAlign
        ScatterPolarGLHoverLabel
        ScatterPolarGLThetaUnit
        ScatterPolarGLOptions
    ]