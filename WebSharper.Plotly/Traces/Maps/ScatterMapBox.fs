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

module ScatterMBModule =

    let ScatterMBNullValue = Pattern.EnumInlines "ScatterMBNullValue" ["null", "null"]

    let ScatterMBColor = T<string> + (T<float> + T<int>) + (!| (!? (ScatterMBNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (ScatterMBNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let ScatterMBColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let ScatterMBVisibleString = Pattern.EnumStrings "ScatterMBVisibleString" ["legendonly"]

    let ScatterMBFont =
        Pattern.Config "ScatterMBFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", ScatterMBColor
            ]
        }

    let ScatterMBLegendGroupTitle =
        Pattern.Config "ScatterMBLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ScatterMBFont.Type
            ]
        }

    let ScatterMBModes =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["lines"; "markers"; "text"] '+')
            let seq2 = seq{"none"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ScatterMBModes" generatedEnum

    let ScatterMBTextPosition =
        Pattern.EnumInlines "ScatterMBTextPosition" [
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

    let ScatterMBHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["lon"; "lat"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ScatterMBHoverInfo" generatedEnum

    let ScatterMBSizeMode =
        Pattern.EnumStrings "ScatterMBSizeMode" [
            "diameter"
            "area"
        ]

    let ScatterMBColorBarMode =
        Pattern.EnumStrings "ScatterMBThicknessMode" [
            "fraction"
            "pixels"
        ]

    let ScatterMBXAnchor =
        Pattern.EnumStrings "ScatterMBXAnchor" [
            "left"
            "center"
            "right"
        ]

    let ScatterMBYAnchor =
        Pattern.EnumStrings "ScatterMBYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let ScatterMBTickMode =
        Pattern.EnumStrings "ScatterMBTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let ScatterMBTicks =
        Pattern.EnumInlines "ScatterMBTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let ScatterMBTickLabelOverflow =
        Pattern.EnumInlines "ScatterMBTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let ScatterMBTickLabelPosition =
        Pattern.EnumInlines "ScatterMBTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let ScatterMBTickFormatStops =
        Pattern.Config "ScatterMBTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + ScatterMBNullValue.Type) * (DTickValue + ScatterMBNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let ScatterMBShowTickFix =
        Pattern.EnumStrings "ScatterMBShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = ScatterMBShowTickFix

    let ScatterMBExponentFormat =
        Pattern.EnumInlines "ScatterMBExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let ScatterMBSide =
        Pattern.EnumStrings "ScatterMBSide" [
            "right"
            "top"
            "bottom"
        ]

    let ScatterMBTitle =
        Pattern.Config "ScatterMBTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ScatterMBFont.Type
                "side", ScatterMBSide.Type
            ]
        }

    let ScatterMBColorBar =
        Pattern.Config "ScatterMBColorBar" {
            Required = []
            Optional = [
                "thicknessmode", ScatterMBColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", ScatterMBColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", ScatterMBXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", ScatterMBYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", ScatterMBColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", ScatterMBColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", ScatterMBColor
                "tickmode", ScatterMBTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", ScatterMBTicks.Type
                "ticklabeloverflow", ScatterMBTickLabelOverflow.Type
                "ticklabelposition", ScatterMBTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", ScatterMBColor
                "showticklabels", T<bool>
                "tickfont", ScatterMBFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", ScatterMBTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", ScatterMBShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", ScatterMBShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", ScatterMBExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", ScatterMBTitle.Type
            ]
        }

    let ScatterMBMarker =
        Pattern.Config "ScatterMBMarker" {
            Required = []
            Optional = [
                "symbol", T<string> + !| T<string>
                "angle", T<int> + T<float> + !| T<int> + !| T<float>
                "allowoverleap", T<bool>
                "opacity", T<float> + !| T<float>
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "sizeref", (T<float> + T<int>)
                "sizemin", (T<float> + T<int>)
                "sizemode", ScatterMBSizeMode.Type
                "color", ScatterMBColor + !| ScatterMBColor
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", ScatterMBColorScale
                "autocolorscale", T<bool>
                "reverscale", T<bool>
                "showscale", T<bool>
                "colorbar", ScatterMBColorBar.Type
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let ScatterMBLine =
        Pattern.Config "ScatterMBLine" {
            Required = []
            Optional = [
                "color", ScatterMBColor
                "width", (T<float> + T<int>)
            ]
        }

    let ScatterMBSelectedMarker =
        Pattern.Config "ScatterMBSelectedMarker" {
            Required = []
            Optional = [
                "opacity", (T<float> + T<int>)
                "color", ScatterMBColor
                "size", (T<float> + T<int>)
            ]
        }

    let ScatterMBSelectedOption =
        Pattern.Config "ScatterMBSelectedOption" {
            Required = []
            Optional = [
                "marker", ScatterMBSelectedMarker.Type
            ]
        }

    let ScatterMBFill =
        Pattern.EnumStrings "ScatterMBFill" [
            "none"
            "tozeroy"
            "tozerox"
            "tonexty"
            "tonextx"
            "toself"
            "tonext"
        ]

    let ScatterMBAlign =
        Pattern.EnumStrings "ScatterMBAlign" [
            "left"
            "right"
            "auto"
        ]

    let ScatterMBHoverLabel =
        Pattern.Config "ScatterMBHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", ScatterMBColor + !| ScatterMBColor
                "bordercolor", ScatterMBColor + !| ScatterMBColor
                "fonts", ScatterMBFont.Type
                "align", ScatterMBAlign.Type
                "namelength", T<int>
            ]
        }

    let ScatterMBOptions =
        Class "ScatterMBOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'scattermapbox'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + ScatterMBVisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", ScatterMBLegendGroupTitle.Type
            "opacity", T<float>
            "mode", ScatterMBModes.Type
            "ids", !| T<string>
            "lat", !| T<int> + !| T<float> + !| T<string>
            "lon", !| T<int> + !| T<float> + !| T<string>
            "text", T<string> + !| T<string>
            "textposition", ScatterMBTextPosition.Type
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", ScatterMBHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "subplot", T<string> //subplotid
            "marker", ScatterMBMarker.Type
            "line", ScatterMBLine.Type
            "textfont", ScatterMBFont.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", ScatterMBSelectedOption.Type
            "unselected", ScatterMBSelectedOption.Type // change name later
            "below", T<string>
            "connectgaps", T<bool>
            "fill", ScatterMBFill.Type
            "fillcolor", ScatterMBColor
            "hoverlabel", ScatterMBHoverLabel.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ScatterMBTraceNamespaces : CodeModel.NamespaceEntity list = [
        ScatterMBNullValue
        ScatterMBVisibleString
        ScatterMBFont
        ScatterMBLegendGroupTitle
        ScatterMBModes
        ScatterMBTextPosition
        ScatterMBHoverInfo
        ScatterMBSizeMode
        ScatterMBColorBarMode
        ScatterMBXAnchor
        ScatterMBYAnchor
        ScatterMBTickMode
        ScatterMBTicks
        ScatterMBTickLabelOverflow
        ScatterMBTickLabelPosition
        ScatterMBTickFormatStops
        ScatterMBShowTickFix
        ScatterMBExponentFormat
        ScatterMBSide
        ScatterMBTitle
        ScatterMBColorBar
        ScatterMBMarker
        ScatterMBLine
        ScatterMBSelectedMarker
        ScatterMBSelectedOption
        ScatterMBFill
        ScatterMBAlign
        ScatterMBHoverLabel
        ScatterMBOptions
    ]