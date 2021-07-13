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

module SunBurstModule =

    let SunBurstNullValue = Pattern.EnumInlines "SunBurstNullValue" ["null", "null"]

    let SunBurstColor = T<string> + (T<float> + T<int>) + (!| (!? (SunBurstNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (SunBurstNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let SunBurstColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let SunBurstVisibleString = Pattern.EnumStrings "SunBurstVisibleString" ["legendonly"]

    let SunBurstFont =
        Pattern.Config "SunBurstFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", SunBurstColor
            ]
        }

    let SunBurstLegendGroupTitle =
        Pattern.Config "SunBurstLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", SunBurstFont.Type
            ]
        }

    let SunBurstMarkerLine =
        Pattern.Config "SunBurstMarkerLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
                "color", SunBurstColor
            ]
        }

    let SunBurstColorBarMode =
        Pattern.EnumStrings "SunBurstThicknessMode" [
            "fraction"
            "pixels"
        ]

    let SunBurstXAnchor =
        Pattern.EnumStrings "SunBurstXAnchor" [
            "left"
            "center"
            "right"
        ]

    let SunBurstYAnchor =
        Pattern.EnumStrings "SunBurstYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let SunBurstTickMode =
        Pattern.EnumStrings "SunBurstTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let SunBurstTicks =
        Pattern.EnumInlines "SunBurstTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let SunBurstTickLabelOverflow =
        Pattern.EnumInlines "SunBurstTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let SunBurstTickLabelPosition =
        Pattern.EnumInlines "SunBurstTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let SunBurstTickFormatStops =
        Pattern.Config "SunBurstTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + SunBurstNullValue.Type) * (DTickValue + SunBurstNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let SunBurstShowTickFix =
        Pattern.EnumStrings "SunBurstShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = SunBurstShowTickFix

    let SunBurstExponentFormat =
        Pattern.EnumInlines "SunBurstExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let SunBurstSide =
        Pattern.EnumStrings "SunBurstSide" [
            "right"
            "top"
            "bottom"
        ]

    let SunBurstTitle =
        Pattern.Config "SunBurstTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", SunBurstFont.Type
                "side", SunBurstSide.Type
            ]
        }

    let SunBurstColorBar =
        Pattern.Config "SunBurstColorBar" {
            Required = []
            Optional = [
                "thicknessmode", SunBurstColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", SunBurstColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", SunBurstXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", SunBurstYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", SunBurstColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", SunBurstColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", SunBurstColor
                "tickmode", SunBurstTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", SunBurstTicks.Type
                "ticklabeloverflow", SunBurstTickLabelOverflow.Type
                "ticklabelposition", SunBurstTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", SunBurstColor
                "showticklabels", T<bool>
                "tickfont", SunBurstFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", SunBurstTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", SunBurstShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", SunBurstShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", SunBurstExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", SunBurstTitle.Type
            ]
        }

    let SunBurstMarker =
        Pattern.Config "SunBurstMarker" {
            Required = []
            Optional = [
                "line", SunBurstMarkerLine.Type
                "colors", SunBurstColor + !| SunBurstColor //data array
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", SunBurstColorScale
                "autocolorscale", T<bool>
                "reverscale", T<bool>
                "showscale", T<bool>
                "colorbar", SunBurstColorBar.Type
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let SunBurstAlign =
        Pattern.EnumStrings "SunBurstAlign" [
            "left"
            "right"
            "auto"
        ]

    let SunBurstHoverLabel =
        Pattern.Config "SunBurstHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", SunBurstColor + !| SunBurstColor
                "bordercolor", SunBurstColor + !| SunBurstColor
                "fonts", SunBurstFont.Type
                "align", SunBurstAlign.Type
                "namelength", T<int>
            ]
        }

    let SunBurstDomain =
        Pattern.Config "SunBurstDomain" {
            Required = []
            Optional = [
                "x", !| T<int> + !| T<float>
                "y", !| T<int> + !| T<float>
                "row", T<int>
                "column", T<int>
            ]
        }

    let SunBurstBranchValues =
        Pattern.EnumStrings "SunBurstBranchValues" [
            "remainder"
            "total"
        ]

    let SunBurstCount =
        Pattern.EnumStrings "SunBurstCount" [
            "branches"
            "leaves"
            "branches+leaves"
            "leaves+branches"
        ]

    let SunBurstTextOrientation =
        Pattern.EnumStrings "SunBurstTextOrientation" [
            "horizontal"
            "radial"
            "tangential"
            "auto"
        ]

    let SunBurstRoot =
        Pattern.Config "SunBurstRoot" {
            Required = []
            Optional = [
                "color", SunBurstColor
            ]
        }

    let SunBurstLeaf =
        Pattern.Config "SunBurstLeaf" {
            Required = []
            Optional = [
                "opacity", T<float>
            ]
        }

    let SunBurstOptions =
        Class "SunBurstOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'sunburst'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + SunBurstVisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgrouptitle", SunBurstLegendGroupTitle.Type
            "opacity", T<float>
            "ids", !| T<string>
            "parents", !| T<string> + !| T<int> + !| T<float>
            "values", !| T<string> + !| T<int> + !| T<float>
            "labels", !| T<string> + !| T<int> + !| T<float>
            "text", T<string> + !| T<string>
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", !| T<string> //TODO
            "hovertemplate", T<string> + !| T<string>
            "meta", (T<float> + T<int>) + T<string>
            "domain", SunBurstDomain.Type
            "marker", SunBurstMarker.Type
            "textfont", SunBurstFont.Type
            "textinfo", !| T<string> //TODO
            "branchvalues", SunBurstBranchValues.Type
            "count", SunBurstCount.Type
            "hoverlabel", SunBurstHoverLabel.Type
            "insidetextfont", SunBurstFont.Type
            "insidetextorientation", SunBurstTextOrientation.Type
            "outsidetextfont", SunBurstFont.Type
            "root", SunBurstRoot.Type
            "leaf", SunBurstLeaf.Type
            "level", T<int> + T<float> + T<string>
            "maxdepth", T<int>
            "rotation", T<int> + T<float>
            "sort", T<bool>
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let SunBurstTraceNamespaces : CodeModel.NamespaceEntity list = [
        SunBurstNullValue
        SunBurstVisibleString
        SunBurstFont
        SunBurstLegendGroupTitle
        SunBurstMarkerLine
        SunBurstColorBarMode
        SunBurstXAnchor
        SunBurstYAnchor
        SunBurstTickMode
        SunBurstTicks
        SunBurstTickLabelOverflow
        SunBurstTickLabelPosition
        SunBurstTickFormatStops
        SunBurstShowTickFix
        ShowExponent
        SunBurstExponentFormat
        SunBurstSide
        SunBurstTitle
        SunBurstColorBar
        SunBurstMarker
        SunBurstAlign
        SunBurstHoverLabel
        SunBurstDomain
        SunBurstBranchValues
        SunBurstCount
        SunBurstTextOrientation
        SunBurstRoot
        SunBurstLeaf
        SunBurstOptions
    ]