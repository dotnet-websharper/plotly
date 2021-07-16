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

module ParCoordsModule =

    let ParCoordsNullValue = Pattern.EnumInlines "ParCoordsNullValue" ["null", "null"]

    let ParCoordsColor = T<string> + (T<float> + T<int>) + (!| (!? (ParCoordsNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (ParCoordsNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let ParCoordsColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let ParCoordsVisibleString = Pattern.EnumStrings "ParCoordsVisibleString" ["legendonly"]

    let ParCoordsFont =
        Pattern.Config "ParCoordsFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", ParCoordsColor
            ]
        }

    let ParCoordsLegendGroupTitle =
        Pattern.Config "ParCoordsLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ParCoordsFont.Type
            ]
        }

    let ParCoordsDimensions =
        Pattern.Config "ParCoordsDimensions" {
            Required = []
            Optional = [
                "tickvals", !| T<string> + !| T<int> + !| T<float>
                "ticktext", !| T<string> + !| T<int> + !| T<float>
                "tickformat", T<string>
                "visible", T<bool>
                "label", T<string>
                "range", !| T<string> + !| T<int> + !| T<float>
                "constraintrange", !| T<string> + !| T<int> + !| T<float>
                "multiselect", T<bool>
                "values", !| T<string> + !| T<int> + !| T<float>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let ParCoordsColorBarMode =
        Pattern.EnumStrings "ParCoordsThicknessMode" [
            "fraction"
            "pixels"
        ]

    let ParCoordsXAnchor =
        Pattern.EnumStrings "ParCoordsXAnchor" [
            "left"
            "center"
            "right"
        ]

    let ParCoordsYAnchor =
        Pattern.EnumStrings "ParCoordsYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let ParCoordsTickMode =
        Pattern.EnumStrings "ParCoordsTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let ParCoordsTicks =
        Pattern.EnumInlines "ParCoordsTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let ParCoordsTickLabelOverflow =
        Pattern.EnumInlines "ParCoordsTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let ParCoordsTickLabelPosition =
        Pattern.EnumInlines "ParCoordsTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let ParCoordsTickFormatStops =
        Pattern.Config "ParCoordsTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + ParCoordsNullValue.Type) * (DTickValue + ParCoordsNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let ParCoordsShowTickFix =
        Pattern.EnumStrings "ParCoordsShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = ParCoordsShowTickFix

    let ParCoordsExponentFormat =
        Pattern.EnumInlines "ParCoordsExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let ParCoordsSide =
        Pattern.EnumStrings "ParCoordsSide" [
            "right"
            "top"
            "bottom"
        ]

    let ParCoordsTitle =
        Pattern.Config "ParCoordsTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ParCoordsFont.Type
                "side", ParCoordsSide.Type
            ]
        }

    let ParCoordsColorBar =
        Pattern.Config "ParCoordsColorBar" {
            Required = []
            Optional = [
                "thicknessmode", ParCoordsColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", ParCoordsColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", ParCoordsXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", ParCoordsYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", ParCoordsColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", ParCoordsColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", ParCoordsColor
                "tickmode", ParCoordsTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", ParCoordsTicks.Type
                "ticklabeloverflow", ParCoordsTickLabelOverflow.Type
                "ticklabelposition", ParCoordsTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", ParCoordsColor
                "showticklabels", T<bool>
                "tickfont", ParCoordsFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", ParCoordsTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", ParCoordsShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", ParCoordsShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", ParCoordsExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", ParCoordsTitle.Type
            ]
        }

    let ParCoordsLine =
        Pattern.Config "ParCoordsLine" {
            Required = []
            Optional = [
                "color", ParCoordsColor + !| ParCoordsColor //data array
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", ParCoordsColorScale
                "autocolorscale", T<bool>
                "reverscale", T<bool>
                "showscale", T<bool>
                "colorbar", ParCoordsColorBar.Type
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let ParCoordsDomain =
        Pattern.Config "ParCoordsDomain" {
            Required = []
            Optional = [
                "x", !| T<int> + !| T<float>
                "y", !| T<int> + !| T<float>
                "row", T<int>
                "column", T<int>
            ]
        }

    let ParCoordsLabelSide =
        Pattern.EnumStrings "ParCoordsLabelSide" [
            "top"
            "bottom"
        ]

    let ParCoordsOptions =
        Class "ParCoordsOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'parcoords'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + ParCoordsVisibleString.Type
            "legendrank", (T<float> + T<int>)
            "legendgrouptitle", ParCoordsLegendGroupTitle.Type
            "ids", !| T<string>
            "dimensions", !| ParCoordsDimensions.Type
            "meta", (T<float> + T<int>) + T<string>
            "customdata", !| T<string> + !| T<int> + !| T<float>
            "domain", ParCoordsDomain.Type
            "line", ParCoordsLine.Type
            "labelangle", T<int> + T<float>
            "labelfont", ParCoordsFont.Type
            "labelside", ParCoordsLabelSide.Type
            "rangefont", ParCoordsFont.Type
            "tickfont", ParCoordsFont.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ParCoordsTraceNamespaces : CodeModel.NamespaceEntity list = [
        ParCoordsNullValue
        ParCoordsVisibleString
        ParCoordsFont
        ParCoordsLegendGroupTitle
        ParCoordsDimensions
        ParCoordsColorBarMode
        ParCoordsXAnchor
        ParCoordsYAnchor
        ParCoordsTickMode
        ParCoordsTicks
        ParCoordsTickLabelOverflow
        ParCoordsTickLabelPosition
        ParCoordsTickFormatStops
        ParCoordsShowTickFix
        ParCoordsExponentFormat
        ParCoordsSide
        ParCoordsTitle
        ParCoordsColorBar
        ParCoordsLine
        ParCoordsDomain
        ParCoordsLabelSide
        ParCoordsOptions
    ]