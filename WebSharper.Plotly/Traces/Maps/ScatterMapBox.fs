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
            let seq1 = (GenerateOptions.allPermutations ["lon"; "lat"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ScatterGeoHoverInfo" generatedEnum

    let ScatterGeoSizeMode =
        Pattern.EnumStrings "ScatterGeoSizeMode" [
            "diameter"
            "area"
        ]

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

    let ScatterGeoMarker =
        Pattern.Config "ScatterGeoMarker" {
            Required = []
            Optional = [
                "symbol", T<string> + !| T<string>
                "angle", T<int> + T<float> + !| T<int> + !| T<float>
                "allowoverleap", T<bool>
                "opacity", T<float> + !| T<float>
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "sizeref", (T<float> + T<int>)
                "sizemin", (T<float> + T<int>)
                "sizemode", ScatterGeoSizeMode.Type
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

    let ScatterGeoSelectedOption =
        Pattern.Config "ScatterGeoSelectedOption" {
            Required = []
            Optional = [
                "marker", ScatterGeoSelectedMarker.Type
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
            "lon", !| T<int> + !| T<float> + !| T<string>
            "text", T<string> + !| T<string>
            "textposition", ScatterGeoTextPosition.Type
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", ScatterGeoHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "subplot", T<string> //subplotid
            "marker", ScatterGeoMarker.Type
            "line", ScatterGeoLine.Type
            "textfont", ScatterGeoFont.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", ScatterGeoSelectedOption.Type
            "unselected", ScatterGeoSelectedOption.Type // change name later
            "below", T<string>
            "connectgaps", T<bool>
            "fill", ScatterGeoFill.Type
            "fillcolor", ScatterGeoColor
            "hoverlabel", ScatterGeoHoverLabel.Type
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
        ScatterGeoColorBarMode
        ScatterGeoXAnchor
        ScatterGeoYAnchor
        ScatterGeoTickMode
        ScatterGeoTicks
        ScatterGeoTickLabelOverflow
        ScatterGeoTickLabelPosition
        ScatterGeoTickFormatStops
        ScatterGeoShowTickFix
        ShowExponent
        ScatterGeoExponentFormat
        ScatterGeoSide
        ScatterGeoTitle
        ScatterGeoColorBar
        ScatterGeoMarker
        ScatterGeoLine
        ScatterGeoSelectedMarker
        ScatterGeoSelectedOption
        ScatterGeoFill
        ScatterGeoAlign
        ScatterGeoHoverLabel
        ScatterGeoOptions
    ]