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

module TreeMapModule =

    let TreeMapNullValue = Pattern.EnumInlines "TreeMapNullValue" ["null", "null"]

    let TreeMapColor = T<string> + (T<float> + T<int>) + (!| (!? (TreeMapNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (TreeMapNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let TreeMapColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let TreeMapVisibleString = Pattern.EnumStrings "TreeMapVisibleString" ["legendonly"]

    let TreeMapFont =
        Pattern.Config "TreeMapFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", TreeMapColor
            ]
        }

    let TreeMapLegendGroupTitle =
        Pattern.Config "TreeMapLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", TreeMapFont.Type
            ]
        }

    let TreeMapMarkerLine =
        Pattern.Config "TreeMapMarkerLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
                "color", TreeMapColor
            ]
        }

    let TreeMapColorBarMode =
        Pattern.EnumStrings "TreeMapThicknessMode" [
            "fraction"
            "pixels"
        ]

    let TreeMapXAnchor =
        Pattern.EnumStrings "TreeMapXAnchor" [
            "left"
            "center"
            "right"
        ]

    let TreeMapYAnchor =
        Pattern.EnumStrings "TreeMapYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let TreeMapTickMode =
        Pattern.EnumStrings "TreeMapTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let TreeMapTicks =
        Pattern.EnumInlines "TreeMapTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let TreeMapTickLabelOverflow =
        Pattern.EnumInlines "TreeMapTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let TreeMapTickLabelPosition =
        Pattern.EnumInlines "TreeMapTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let TreeMapTickFormatStops =
        Pattern.Config "TreeMapTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + TreeMapNullValue.Type) * (DTickValue + TreeMapNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let TreeMapShowTickFix =
        Pattern.EnumStrings "TreeMapShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = TreeMapShowTickFix

    let TreeMapExponentFormat =
        Pattern.EnumInlines "TreeMapExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let TreeMapSide =
        Pattern.EnumStrings "TreeMapSide" [
            "right"
            "top"
            "bottom"
        ]

    let TreeMapTitle =
        Pattern.Config "TreeMapTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", TreeMapFont.Type
                "side", TreeMapSide.Type
            ]
        }

    let TreeMapColorBar =
        Pattern.Config "TreeMapColorBar" {
            Required = []
            Optional = [
                "thicknessmode", TreeMapColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", TreeMapColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", TreeMapXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", TreeMapYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", TreeMapColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", TreeMapColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", TreeMapColor
                "tickmode", TreeMapTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", TreeMapTicks.Type
                "ticklabeloverflow", TreeMapTickLabelOverflow.Type
                "ticklabelposition", TreeMapTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", TreeMapColor
                "showticklabels", T<bool>
                "tickfont", TreeMapFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", TreeMapTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", TreeMapShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", TreeMapShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", TreeMapExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", TreeMapTitle.Type
            ]
        }

    let TreeMapMarkerPad =
        Pattern.Config "TreeMapMarkerPad" {
            Required = []
            Optional = [
                "t", T<int> + T<float>
                "l", T<int> + T<float>
                "r", T<int> + T<float>
                "b", T<int> + T<float>
            ]
        }

    let TreeMapMarkerDepthFade =
        Pattern.EnumStrings "TreeMapMarkerDepthFade" [
            "reversed"
        ]

    let TreeMapMarker =
        Pattern.Config "TreeMapMarker" {
            Required = []
            Optional = [
                "pad", TreeMapMarkerPad.Type
                "colors", TreeMapColor + !| TreeMapColor //data array
                "depthfade", T<bool> + TreeMapMarkerDepthFade.Type
                "line", TreeMapMarkerLine.Type
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", TreeMapColorScale
                "autocolorscale", T<bool>
                "reverscale", T<bool>
                "showscale", T<bool>
                "colorbar", TreeMapColorBar.Type
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let TreeMapAlign =
        Pattern.EnumStrings "TreeMapAlign" [
            "left"
            "right"
            "auto"
        ]

    let TreeMapHoverLabel =
        Pattern.Config "TreeMapHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", TreeMapColor + !| TreeMapColor
                "bordercolor", TreeMapColor + !| TreeMapColor
                "fonts", TreeMapFont.Type
                "align", TreeMapAlign.Type
                "namelength", T<int>
            ]
        }

    let TreeMapDomain =
        Pattern.Config "TreeMapDomain" {
            Required = []
            Optional = [
                "x", !| T<int> + !| T<float>
                "y", !| T<int> + !| T<float>
                "row", T<int>
                "column", T<int>
            ]
        }

    let TreeMapBranchValues =
        Pattern.EnumStrings "TreeMapBranchValues" [
            "remainder"
            "total"
        ]

    let TreeMapCount =
        Pattern.EnumStrings "TreeMapCount" [
            "branches"
            "leaves"
            "branches+leaves"
            "leaves+branches"
        ]

    let TreeMapRoot =
        Pattern.Config "TreeMapRoot" {
            Required = []
            Optional = [
                "color", TreeMapColor
            ]
        }

    let TreeMapTextPosition =
        Pattern.EnumInlines "TreeMapTextPosition" [
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

    let TreeMapTilingPacking =
        Pattern.EnumStrings "TreeMapTilingPacking" [
            "squarify"
            "binary"
            "dice"
            "slice"
            "slice-dice"
            "dice-slice"
        ]

    let TreeMapTilingFlip =
        PatternEnumStrings "TreeMapTilingFlip" [
            "x"
            "y"
            "x+y"
            "y+x"
        ]

    let TreeMapTiling =
        Pattern.Config "TreeMapTiling" {
            Required = []
            Optional = [
                "packing", TreeMapTilingPacking.Type
                "squarifyratio", T<int> + T<float>
                "flip", TreeMapTilingFlip.Type
                "pad", T<int> + T<float>
            ]
        }

    let TreeMapPathBarSide =
        Pattern.EnumStrings "TreeMapPathBarSide" [
            "top"
            "bottom"
        ]

    let TreeMapPathBarES =
        Pattern.EnumInlines "TreeMapPathBarES" [
            "greater", "'>'"
            "lower", "'<'"
            "pipeline", "'|'"
            "slash", "'/'"
            "backslash", "'\'" //TODO
        ]

    let TreeMapPathBar =
        Pattern.Config "TreeMapPathBar" {
            Required = []
            Optional = [
                "visible", T<bool>
                "side", TreeMapPathBarSide.Type
                "edgeshape", TreeMapPathBarES.type
                "thickness", T<int> + T<float>
                "textfont", TreeMapFont.Type
            ]
        }

    let TreeMapOptions =
        Class "TreeMapOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'treemap'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + TreeMapVisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgrouptitle", TreeMapLegendGroupTitle.Type
            "opacity", T<float>
            "ids", !| T<string>
            "parents", !| T<string> + !| T<int> + !| T<float>
            "values", !| T<string> + !| T<int> + !| T<float>
            "labels", !| T<string> + !| T<int> + !| T<float>
            "text", T<string> + !| T<string>
            "textposition", TreeMapTextPosition.Type
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", !| T<string> //TODO
            "hovertemplate", T<string> + !| T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", !| T<string> + !| T<int> + !| T<float>
            "domain", TreeMapDomain.Type
            "marker", TreeMapMarker.Type
            "textfont", TreeMapFont.Type
            "textinfo", !| T<string> //TODO
            "branchvalues", TreeMapBranchValues.Type
            "count", TreeMapCount.Type
            "tiling", TreeMapTiling.Type
            "pathbar", TreeMapPathBar.Type
            "hoverlabel", TreeMapHoverLabel.Type
            "insidetextfont", TreeMapFont.Type
            "outsidetextfont", TreeMapFont.Type
            "root", TreeMapRoot.Type
            "level", T<int> + T<float> + T<string>
            "maxdepth", T<int>
            "sort", T<bool>
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let TreeMapTraceNamespaces : CodeModel.NamespaceEntity list = [
        TreeMapNullValue
        TreeMapVisibleString
        TreeMapFont
        TreeMapLegendGroupTitle
        TreeMapMarkerLine
        TreeMapColorBarMode
        TreeMapXAnchor
        TreeMapYAnchor
        TreeMapTickMode
        TreeMapTicks
        TreeMapTickLabelOverflow
        TreeMapTickLabelPosition
        TreeMapTickFormatStops
        TreeMapShowTickFix
        ShowExponent
        TreeMapExponentFormat
        TreeMapSide
        TreeMapTitle
        TreeMapColorBar
        TreeMapMarkerPad
        TreeMapMarkerDepthFade
        TreeMapMarker
        TreeMapAlign
        TreeMapHoverLabel
        TreeMapDomain
        TreeMapBranchValues
        TreeMapCount
        TreeMapRoot
        TreeMapTextPosition
        TreeMapTilingPacking
        TreeMapTilingFlip
        TreeMapTiling
        TreeMapPathBarSide
        TreeMapPathBarES
        TreeMapPathBar
        TreeMapOptions
    ]