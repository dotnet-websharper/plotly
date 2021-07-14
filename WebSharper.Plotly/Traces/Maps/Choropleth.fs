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

module ChoroplethModule =

    let ChoroplethNullValue = Pattern.EnumInlines "ChoroplethNullValue" ["null", "null"]

    let ChoroplethColor = T<string> + (T<float> + T<int>) + (!| (!? (ChoroplethNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (ChoroplethNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let ChoroplethColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let ChoroplethVisibleString = Pattern.EnumStrings "ChoroplethVisibleString" ["legendonly"]

    let ChoroplethFont =
        Pattern.Config "ChoroplethFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", ChoroplethColor
            ]
        }

    let ChoroplethLegendGroupTitle =
        Pattern.Config "ChoroplethLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ChoroplethFont.Type
            ]
        }

    let ChoroplethHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["location"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ChoroplethHoverInfo" generatedEnum

    let ChoroplethColorBarMode =
        Pattern.EnumStrings "ChoroplethThicknessMode" [
            "fraction"
            "pixels"
        ]

    let ChoroplethXAnchor =
        Pattern.EnumStrings "ChoroplethXAnchor" [
            "left"
            "center"
            "right"
        ]

    let ChoroplethYAnchor =
        Pattern.EnumStrings "ChoroplethYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let ChoroplethTickMode =
        Pattern.EnumStrings "ChoroplethTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let ChoroplethTicks =
        Pattern.EnumInlines "ChoroplethTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let ChoroplethTickLabelOverflow =
        Pattern.EnumInlines "ChoroplethTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let ChoroplethTickLabelPosition =
        Pattern.EnumInlines "ChoroplethTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let ChoroplethTickFormatStops =
        Pattern.Config "ChoroplethTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + ChoroplethNullValue.Type) * (DTickValue + ChoroplethNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let ChoroplethShowTickFix =
        Pattern.EnumStrings "ChoroplethShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = ChoroplethShowTickFix

    let ChoroplethExponentFormat =
        Pattern.EnumInlines "ChoroplethExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let ChoroplethSide =
        Pattern.EnumStrings "ChoroplethSide" [
            "right"
            "top"
            "bottom"
        ]

    let ChoroplethTitle =
        Pattern.Config "ChoroplethTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ChoroplethFont.Type
                "side", ChoroplethSide.Type
            ]
        }

    let ChoroplethColorBar =
        Pattern.Config "ChoroplethColorBar" {
            Required = []
            Optional = [
                "thicknessmode", ChoroplethColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", ChoroplethColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", ChoroplethXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", ChoroplethYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", ChoroplethColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", ChoroplethColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", ChoroplethColor
                "tickmode", ChoroplethTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", ChoroplethTicks.Type
                "ticklabeloverflow", ChoroplethTickLabelOverflow.Type
                "ticklabelposition", ChoroplethTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", ChoroplethColor
                "showticklabels", T<bool>
                "tickfont", ChoroplethFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", ChoroplethTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", ChoroplethShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", ChoroplethShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", ChoroplethExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", ChoroplethTitle.Type
            ]
        }

    let ChoroplethMarkerLine =
        Pattern.Config "ChoroplethMarkerLine" {
            Required = []
            Optional = [
                "color", ChoroplethColor
                "width", T<int> + T<float>
            ]
        }

    let ChoroplethMarker =
        Pattern.Config "ChoroplethMarker" {
            Required = []
            Optional = [
                "line", ChoroplethMarkerLine.Type
                "opacity", T<float>
            ]
        }

    let ChoroplethSelectedMarker =
        Pattern.Config "ChoroplethSelectedMarker" {
            Required = []
            Optional = [
                "opacity", T<float>
            ]
        }

    let ChoroplethSelectedOption =
        Pattern.Config "ChoroplethSelectedOption" {
            Required = []
            Optional = [
                "marker", ChoroplethSelectedMarker.Type
            ]
        }

    let ChoroplethAlign =
        Pattern.EnumStrings "ChoroplethAlign" [
            "left"
            "right"
            "auto"
        ]

    let ChoroplethHoverLabel =
        Pattern.Config "ChoroplethHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", ChoroplethColor + !| ChoroplethColor
                "bordercolor", ChoroplethColor + !| ChoroplethColor
                "font", ChoroplethFont.Type
                "align", ChoroplethAlign.Type
                "namelength", T<int>
            ]
        }

    let ChoroplethLocationMode =
        Pattern.EnumInlines "ChoroplethLocationMode" [
            "ISO-3", "'ISO-3'"
            "USA-states", "'USA-states'"
            "countryNames", "'country names'"
            "geojson-id", "'geojson-id'"
        ]

    let ChoroplethOptions =
        Class "ChoroplethOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'choropleth'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + ChoroplethVisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", ChoroplethLegendGroupTitle.Type
            "ids", !| T<string>
            "z", !| T<int> + !| T<float> + !| T<string> //data array
            "geojson", T<int> + T<float> + T<string>
            "featureidkey", T<string>
            "locations", !| T<int> + !| T<float> + !| T<string>
            "text", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", ChoroplethHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "geo", T<string> //subplotid
            "coloraxis", T<string> //subplotid
            "marker", ChoroplethMarker.Type
            "colorbar", ChoroplethColorBar.Type
            "autocolorscale", T<bool>
            "colorscale", ChoroplethColorScale
            "showscale", T<bool>
            "reversescale", T<bool>
            "zauto", T<bool>
            "zmax", T<int> + T<float>
            "zmid", T<int> + T<float>
            "zmin", T<int> + T<float>
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", ChoroplethSelectedOption.Type
            "unselected", ChoroplethSelectedOption.Type // change name later
            "hoverlabel", ChoroplethHoverLabel.Type
            "locationmode", ChoroplethLocationMode.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ChoroplethTraceNamespaces : CodeModel.NamespaceEntity list = [
        ChoroplethNullValue
        ChoroplethVisibleString
        ChoroplethFont
        ChoroplethLegendGroupTitle
        ChoroplethHoverInfo
        ChoroplethMarkerLine
        ChoroplethColorBarMode
        ChoroplethXAnchor
        ChoroplethYAnchor
        ChoroplethTickMode
        ChoroplethTicks
        ChoroplethTickLabelOverflow
        ChoroplethTickLabelPosition
        ChoroplethTickFormatStops
        ChoroplethShowTickFix
        ChoroplethExponentFormat
        ChoroplethSide
        ChoroplethTitle
        ChoroplethColorBar
        ChoroplethMarker
        ChoroplethSelectedMarker
        ChoroplethSelectedOption
        ChoroplethAlign
        ChoroplethHoverLabel
        ChoroplethLocationMode
        ChoroplethOptions
    ]