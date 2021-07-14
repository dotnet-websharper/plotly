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

module ParCatsModule =

    let ParCatsNullValue = Pattern.EnumInlines "ParCatsNullValue" ["null", "null"]

    let ParCatsColor = T<string> + (T<float> + T<int>) + (!| (!? (ParCatsNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (ParCatsNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let ParCatsColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let ParCatsVisibleString = Pattern.EnumStrings "ParCatsVisibleString" ["legendonly"]

    let ParCatsFont =
        Pattern.Config "ParCatsFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", ParCatsColor
            ]
        }

    let ParCatsLegendGroupTitle =
        Pattern.Config "ParCatsLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ParCatsFont.Type
            ]
        }

    let ParCatsDimensionCatOrd =
        Pattern.Enuminlines "ParCatsDimensionCatOrd" [
            "trace", "'trace'"
            "categoryAscending", "'category ascending'"
            "categoryDescending", "'category descending'"
            "array", "'array'"
        ]

    let ParCatsDimensions =
        Pattern.Config "ParCatsDimensions" {
            Required = []
            Optional = [
                "displayindex", T<int>
                "categoryorder", ParCatsDimensionCatOrd.Type
                "categoryarray", !| T<string> + !| T<int> + !| T<float>///
                "ticktext", !| T<string> + !| T<int> + !| T<float>//
                "visible", T<bool>//
                "label", T<string>//
                "values", !| T<string> + !| T<int> + !| T<float>//
            ]
        }

    let ParCatsColorBarMode =
        Pattern.EnumStrings "ParCatsThicknessMode" [
            "fraction"
            "pixels"
        ]

    let ParCatsXAnchor =
        Pattern.EnumStrings "ParCatsXAnchor" [
            "left"
            "center"
            "right"
        ]

    let ParCatsYAnchor =
        Pattern.EnumStrings "ParCatsYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let ParCatsTickMode =
        Pattern.EnumStrings "ParCatsTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let ParCatsTicks =
        Pattern.EnumInlines "ParCatsTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let ParCatsTickLabelOverflow =
        Pattern.EnumInlines "ParCatsTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let ParCatsTickLabelPosition =
        Pattern.EnumInlines "ParCatsTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let ParCatsTickFormatStops =
        Pattern.Config "ParCatsTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + ParCatsNullValue.Type) * (DTickValue + ParCatsNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let ParCatsShowTickFix =
        Pattern.EnumStrings "ParCatsShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = ParCatsShowTickFix

    let ParCatsExponentFormat =
        Pattern.EnumInlines "ParCatsExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let ParCatsSide =
        Pattern.EnumStrings "ParCatsSide" [
            "right"
            "top"
            "bottom"
        ]

    let ParCatsTitle =
        Pattern.Config "ParCatsTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ParCatsFont.Type
                "side", ParCatsSide.Type
            ]
        }

    let ParCatsColorBar =
        Pattern.Config "ParCatsColorBar" {
            Required = []
            Optional = [
                "thicknessmode", ParCatsColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", ParCatsColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", ParCatsXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", ParCatsYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", ParCatsColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", ParCatsColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", ParCatsColor
                "tickmode", ParCatsTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", ParCatsTicks.Type
                "ticklabeloverflow", ParCatsTickLabelOverflow.Type
                "ticklabelposition", ParCatsTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", ParCatsColor
                "showticklabels", T<bool>
                "tickfont", ParCatsFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", ParCatsTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", ParCatsShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", ParCatsShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", ParCatsExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", ParCatsTitle.Type
            ]
        }

    let ParCatsLineShape =
        Pattern.EnumStrings "ParCatsLineShape" [
            "linear"
            "hspline"
        ]

    let ParCatsLine =
        Pattern.Config "ParCatsLine" {
            Required = []
            Optional = [
                "color", ParCatsColor + !| ParCatsColor //data array//
                "cauto", T<bool>//
                "cmin", (T<float> + T<int>)//
                "cmax", (T<float> + T<int>)//
                "cmid", (T<float> + T<int>)//
                "colorscale", ParCatsColorScale//
                "autocolorscale", T<bool>//
                "reverscale", T<bool>//
                "showscale", T<bool>//
                "colorbar", ParCatsColorBar.Type//
                "coloraxis", T<string> // type: subplotid//
                "shape", ParCatsLineShape.Type
                "hovertemplate", T<string>
            ]
        }

    let ParCatsDomain =
        Pattern.Config "ParCatsDomain" {
            Required = []
            Optional = [
                "x", !| T<int> + !| T<float>
                "y", !| T<int> + !| T<float>
                "row", T<int>
                "column", T<int>
            ]
        }

    let ParCatsHoverInfo =
        Pattern.EnumStrings "ParCatsHoverInfo" [
            "count"
            "probability"
            "count+probability"
            "probability+count"
            "all"
            "none"
            "skip"
        ]

    let ParCatsArrangement =
        Pattern.EnumStrings "ParCatsArrangement" [
            "perpendicular"
            "freeform"
            "fixed"
        ]

    let ParCatsSortPath =
        Pattern.EnumStrings "ParCatsSortPath" [
            "forward"
            "backfard"
        ]

    let ParCatsHoveron =
        Pattern.EnumStrings "ParCatsHoveron" [
            "category"
            "color"
            "dimension"
        ]

    let ParCatsOptions =
        Class "ParCatsOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'parcats'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + ParCatsVisibleString.Type
            "legendgrouptitle", ParCatsLegendGroupTitle.Type
            "counts", T<int> + T<float> + !| T<int> + !| T<float>
            "dimensions", ParCatsDimensions.Type
            "hoverinfo", ParCatsHoverInfo.Type
            "hovertemplate"
            "meta", (T<float> + T<int>) + T<string>
            "domain", ParCatsDomain.Type
            "line", ParCatsLine.Type
            "arrangement", ParCatsArrangement.Type
            "bundlecolors", T<bool>
            "sortpaths", ParCatsSortPath.Type
            "hoveron", ParCatsHoveron.Type
            "labelfont", ParCatsFont.Type
            "tickfont", ParCatsFont.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ParCatsTraceNamespaces : CodeModel.NamespaceEntity list = [
        ParCatsNullValue
        ParCatsVisibleString
        ParCatsFont
        ParCatsLegendGroupTitle
        ParCatsDimensionCatOrd
        ParCatsDimensions
        ParCatsColorBarMode
        ParCatsXAnchor
        ParCatsYAnchor
        ParCatsTickMode
        ParCatsTicks
        ParCatsTickLabelOverflow
        ParCatsTickLabelPosition
        ParCatsTickFormatStops
        ParCatsShowTickFix
        ShowExponent
        ParCatsExponentFormat
        ParCatsSide
        ParCatsTitle
        ParCatsColorBar
        ParCatsLineShape
        ParCatsLine
        ParCatsDomain
        ParCatsHoverInfo
        ParCatsArrangement
        ParCatsSortPath
        ParCatsHoveron
        ParCatsOptions
    ]