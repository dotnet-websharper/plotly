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

module ChoroplethMBModule =

    let ChoroplethMBNullValue = Pattern.EnumInlines "ChoroplethMBNullValue" ["null", "null"]

    let ChoroplethMBColor = T<string> + (T<float> + T<int>) + (!| (!? (ChoroplethMBNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (ChoroplethMBNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let ChoroplethMBColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let ChoroplethMBVisibleString = Pattern.EnumStrings "ChoroplethMBVisibleString" ["legendonly"]

    let ChoroplethMBFont =
        Pattern.Config "ChoroplethMBFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", ChoroplethMBColor
            ]
        }

    let ChoroplethMBLegendGroupTitle =
        Pattern.Config "ChoroplethMBLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ChoroplethMBFont.Type
            ]
        }

    let ChoroplethMBHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["location"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ChoroplethMBHoverInfo" generatedEnum

    let ChoroplethMBMarkerLine =
        Pattern.Config "ChoroplethMBMarkerLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
                "color", ChoroplethMBColor
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", ChoroplethMBColorScale
                "autocolorscale", T<bool>
                "reversescale", T<bool>
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let ChoroplethMBColorBarMode =
        Pattern.EnumStrings "ChoroplethMBThicknessMode" [
            "fraction"
            "pixels"
        ]

    let ChoroplethMBXAnchor =
        Pattern.EnumStrings "ChoroplethMBXAnchor" [
            "left"
            "center"
            "right"
        ]

    let ChoroplethMBYAnchor =
        Pattern.EnumStrings "ChoroplethMBYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let ChoroplethMBTickMode =
        Pattern.EnumStrings "ChoroplethMBTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let ChoroplethMBTicks =
        Pattern.EnumInlines "ChoroplethMBTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let ChoroplethMBTickLabelOverflow =
        Pattern.EnumInlines "ChoroplethMBTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let ChoroplethMBTickLabelPosition =
        Pattern.EnumInlines "ChoroplethMBTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let ChoroplethMBTickFormatStops =
        Pattern.Config "ChoroplethMBTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + ChoroplethMBNullValue.Type) * (DTickValue + ChoroplethMBNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let ChoroplethMBShowTickFix =
        Pattern.EnumStrings "ChoroplethMBShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = ChoroplethMBShowTickFix

    let ChoroplethMBExponentFormat =
        Pattern.EnumInlines "ChoroplethMBExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let ChoroplethMBSide =
        Pattern.EnumStrings "ChoroplethMBSide" [
            "right"
            "top"
            "bottom"
        ]

    let ChoroplethMBTitle =
        Pattern.Config "ChoroplethMBTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ChoroplethMBFont.Type
                "side", ChoroplethMBSide.Type
            ]
        }

    let ChoroplethMBColorBar =
        Pattern.Config "ChoroplethMBColorBar" {
            Required = []
            Optional = [
                "thicknessmode", ChoroplethMBColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", ChoroplethMBColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", ChoroplethMBXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", ChoroplethMBYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", ChoroplethMBColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", ChoroplethMBColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", ChoroplethMBColor
                "tickmode", ChoroplethMBTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", ChoroplethMBTicks.Type
                "ticklabeloverflow", ChoroplethMBTickLabelOverflow.Type
                "ticklabelposition", ChoroplethMBTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", ChoroplethMBColor
                "showticklabels", T<bool>
                "tickfont", ChoroplethMBFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", ChoroplethMBTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", ChoroplethMBShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", ChoroplethMBShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", ChoroplethMBExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", ChoroplethMBTitle.Type
            ]
        }

let ChoroplethMBMarkerLine =
    Pattern.Config "ChoroplethMBMarkerLine" {
        Required = []
        Optional = [
            "color", ChoroplethMBColor
            "width", T<int> + T<float>
        ]
    }

    let ChoroplethMBMarker =
        Pattern.Config "ChoroplethMBMarker" {
            Required = []
            Optional = [
                "line", ChoroplethMBMarkerLine.Type
                "opacity", T<float>
            ]
        }

    let ChoroplethMBSelectedMarker =
        Pattern.Config "ChoroplethMBSelectedMarker" {
            Required = []
            Optional = [
                "opacity", T<float>
            ]
        }

    let ChoroplethMBSelectedOption =
        Pattern.Config "ChoroplethMBSelectedOption" {
            Required = []
            Optional = [
                "marker", ChoroplethMBSelectedMarker.Type
            ]
        }

    let ChoroplethMBAlign =
        Pattern.EnumStrings "ChoroplethMBAlign" [
            "left"
            "right"
            "auto"
        ]

    let ChoroplethMBHoverLabel =
        Pattern.Config "ChoroplethMBHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", ChoroplethMBColor + !| ChoroplethMBColor
                "bordercolor", ChoroplethMBColor + !| ChoroplethMBColor
                "font", ChoroplethMBFont.Type
                "align", ChoroplethMBAlign.Type
                "namelength", T<int>
            ]
        }

    let ChoroplethMBLocationMode =
        Pattern.EnumInlines "ChoroplethMBLocationMode" [
            "ISO-3", "'ISO-3'"
            "USA-states", "'USA-states'"
            "countryNames", "'country names'"
            "geojson-id", "'geojson-id'"
        ]

    let ChoroplethMBOptions =
        Class "ChoroplethMBOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'choroplethmapbox'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + ChoroplethMBVisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", ChoroplethMBLegendGroupTitle.Type
            "ids", !| T<string>
            "z", !| T<int> + !| T<float> + !| T<string> //data array
            "geojson", T<int> + T<float> + T<string>
            "featureidkey", T<string>
            "locations", !| T<int> + !| T<float> + !| T<string>
            "text", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", ChoroplethMBHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "subplot", T<string> //subplotid
            "coloraxis", T<string> //subplotid
            "marker", ChoroplethMBMarker.Type
            "colorbar", ChoroplethMBColorBar.Type
            "autocolorscale", T<bool>
            "colorscale", ChoroplethMBColorScale.Type
            "showscale", T<bool>
            "reversescale", T<bool>
            "zauto", T<bool>
            "zmax", T<int> + T<float>
            "zmid", T<int> + T<float>
            "zmin", T<int> + T<float>
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", ChoroplethMBSelectedOption.Type
            "unselected", ChoroplethMBSelectedOption.Type // change name later
            "below", T<string>
            "hoverlabel", ChoroplethMBHoverLabel.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ChoroplethMBTraceNamespaces : CodeModel.NamespaceEntity list = [
        ChoroplethMBNullValue
        ChoroplethMBVisibleString
        ChoroplethMBFont
        ChoroplethMBLegendGroupTitle
        ChoroplethMBHoverInfo
        ChoroplethMBMarkerLine
        ChoroplethMBColorBarMode
        ChoroplethMBXAnchor
        ChoroplethMBYAnchor
        ChoroplethMBTickMode
        ChoroplethMBTicks
        ChoroplethMBTickLabelOverflow
        ChoroplethMBTickLabelPosition
        ChoroplethMBTickFormatStops
        ChoroplethMBShowTickFix
        ShowExponent
        ChoroplethMBExponentFormat
        ChoroplethMBSide
        ChoroplethMBTitle
        ChoroplethMBColorBar
        ChoroplethMBMarkerLine
        ChoroplethMBMarker
        ChoroplethMBSelectedMarker
        ChoroplethMBSelectedOption
        ChoroplethMBAlign
        ChoroplethMBHoverLabel
        ChoroplethMBLocationMode
        ChoroplethMBOptions
    ]