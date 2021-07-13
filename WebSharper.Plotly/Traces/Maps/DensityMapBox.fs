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

module DensityMBModule =

    let DensityMBNullValue = Pattern.EnumInlines "DensityMBNullValue" ["null", "null"]

    let DensityMBColor = T<string> + (T<float> + T<int>) + (!| (!? (DensityMBNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (DensityMBNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let DensityMBColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let DensityMBVisibleString = Pattern.EnumStrings "DensityMBVisibleString" ["legendonly"]

    let DensityMBFont =
        Pattern.Config "DensityMBFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", DensityMBColor
            ]
        }

    let DensityMBLegendGroupTitle =
        Pattern.Config "DensityMBLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", DensityMBFont.Type
            ]
        }

    let DensityMBHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["lon"; "lat"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "DensityMBHoverInfo" generatedEnum

    let DensityMBColorBarMode =
        Pattern.EnumStrings "DensityMBThicknessMode" [
            "fraction"
            "pixels"
        ]

    let DensityMBXAnchor =
        Pattern.EnumStrings "DensityMBXAnchor" [
            "left"
            "center"
            "right"
        ]

    let DensityMBYAnchor =
        Pattern.EnumStrings "DensityMBYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let DensityMBTickMode =
        Pattern.EnumStrings "DensityMBTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let DensityMBTicks =
        Pattern.EnumInlines "DensityMBTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let DensityMBTickLabelOverflow =
        Pattern.EnumInlines "DensityMBTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let DensityMBTickLabelPosition =
        Pattern.EnumInlines "DensityMBTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let DensityMBTickFormatStops =
        Pattern.Config "DensityMBTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + DensityMBNullValue.Type) * (DTickValue + DensityMBNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let DensityMBShowTickFix =
        Pattern.EnumStrings "DensityMBShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = DensityMBShowTickFix

    let DensityMBExponentFormat =
        Pattern.EnumInlines "DensityMBExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let DensityMBSide =
        Pattern.EnumStrings "DensityMBSide" [
            "right"
            "top"
            "bottom"
        ]

    let DensityMBTitle =
        Pattern.Config "DensityMBTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", DensityMBFont.Type
                "side", DensityMBSide.Type
            ]
        }

    let DensityMBColorBar =
        Pattern.Config "DensityMBColorBar" {
            Required = []
            Optional = [
                "thicknessmode", DensityMBColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", DensityMBColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", DensityMBXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", DensityMBYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", DensityMBColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", DensityMBColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", DensityMBColor
                "tickmode", DensityMBTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", DensityMBTicks.Type
                "ticklabeloverflow", DensityMBTickLabelOverflow.Type
                "ticklabelposition", DensityMBTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", DensityMBColor
                "showticklabels", T<bool>
                "tickfont", DensityMBFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", DensityMBTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", DensityMBShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", DensityMBShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", DensityMBExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", DensityMBTitle.Type
            ]
        }

    let DensityMBAlign =
        Pattern.EnumStrings "DensityMBAlign" [
            "left"
            "right"
            "auto"
        ]

    let DensityMBHoverLabel =
        Pattern.Config "DensityMBHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", DensityMBColor + !| DensityMBColor
                "bordercolor", DensityMBColor + !| DensityMBColor
                "font", DensityMBFont.Type
                "align", DensityMBAlign.Type
                "namelength", T<int>
            ]
        }

    let DensityMBOptions =
        Class "DensityMBOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'densitymapbox'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + DensityMBVisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", DensityMBLegendGroupTitle.Type
            "opacity", T<float>
            "ids", !| T<string>
            "z", !| T<int> + !| T<float> + !| T<string> //data array
            "radius", T<int> + !| T<int>
            "lat", !| T<int> + !| T<float> + !| T<string> //data array
            "lon", !| T<int> + !| T<float> + !| T<string> //data array
            "text", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", DensityMBHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "subplot", T<string> //subplotid
            "coloraxis", T<string> //subplotid
            "colorbar", DensityMBColorBar.Type
            "autocolorscale", T<bool>
            "colorscale", DensityMBColorScale.Type
            "showscale", T<bool>
            "reversescale", T<bool>
            "zauto", T<bool>
            "zmax", T<int> + T<float>
            "zmid", T<int> + T<float>
            "zmin", T<int> + T<float>
            "below", T<string>
            "hoverlabel", DensityMBHoverLabel.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let DensityMBTraceNamespaces : CodeModel.NamespaceEntity list = [
        DensityMBNullValue
        DensityMBVisibleString
        DensityMBFont
        DensityMBLegendGroupTitle
        DensityMBHoverInfo
        DensityMBColorBarMode
        DensityMBXAnchor
        DensityMBYAnchor
        DensityMBTickMode
        DensityMBTicks
        DensityMBTickLabelOverflow
        DensityMBTickLabelPosition
        DensityMBTickFormatStops
        DensityMBShowTickFix
        ShowExponent
        DensityMBExponentFormat
        DensityMBSide
        DensityMBTitle
        DensityMBColorBar
        DensityMBAlign
        DensityMBHoverLabel
        DensityMBOptions
    ]