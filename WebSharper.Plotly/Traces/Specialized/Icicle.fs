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
open WebSharper.Plotly.Extension.Common

module IcicleModule =

    let IcicleNullValue = Pattern.EnumInlines "IcicleNullValue" ["null", "null"]

    let IcicleColor = T<string> + (T<float> + T<int>) + (!| (!? (IcicleNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (IcicleNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let IcicleColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let IcicleVisibleString = Pattern.EnumStrings "IcicleVisibleString" ["legendonly"]

    let IcicleFont =
        Pattern.Config "IcicleFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", IcicleColor
            ]
        }

    let IcicleLegendGroupTitle =
        Pattern.Config "IcicleLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", IcicleFont.Type
            ]
        }

    let IcicleMarkerLine =
        Pattern.Config "IcicleMarkerLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
                "color", IcicleColor
            ]
        }

    let IcicleColorBarMode =
        Pattern.EnumStrings "IcicleThicknessMode" [
            "fraction"
            "pixels"
        ]

    let IcicleXAnchor =
        Pattern.EnumStrings "IcicleXAnchor" [
            "left"
            "center"
            "right"
        ]

    let IcicleYAnchor =
        Pattern.EnumStrings "IcicleYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let IcicleTickMode =
        Pattern.EnumStrings "IcicleTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let IcicleTicks =
        Pattern.EnumInlines "IcicleTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let IcicleTickLabelOverflow =
        Pattern.EnumInlines "IcicleTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let IcicleTickLabelPosition =
        Pattern.EnumInlines "IcicleTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let IcicleTickFormatStops =
        Pattern.Config "IcicleTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + IcicleNullValue.Type) * (DTickValue + IcicleNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let IcicleShowTickFix =
        Pattern.EnumStrings "IcicleShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = IcicleShowTickFix

    let IcicleExponentFormat =
        Pattern.EnumInlines "IcicleExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let IcicleSide =
        Pattern.EnumStrings "IcicleSide" [
            "right"
            "top"
            "bottom"
        ]

    let IcicleTitle =
        Pattern.Config "IcicleTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", IcicleFont.Type
                "side", IcicleSide.Type
            ]
        }

    let IcicleColorBar =
        Pattern.Config "IcicleColorBar" {
            Required = []
            Optional = [
                "thicknessmode", IcicleColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", IcicleColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", IcicleXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", IcicleYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", IcicleColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", IcicleColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", IcicleColor
                "tickmode", IcicleTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", IcicleTicks.Type
                "ticklabeloverflow", IcicleTickLabelOverflow.Type
                "ticklabelposition", IcicleTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", IcicleColor
                "showticklabels", T<bool>
                "tickfont", IcicleFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", IcicleTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", IcicleShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", IcicleShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", IcicleExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", IcicleTitle.Type
            ]
        }

    let IcicleMarker =
        Pattern.Config "IcicleMarker" {
            Required = []
            Optional = [
                "line", IcicleMarkerLine.Type
                "colors", IcicleColor + !| IcicleColor //data array
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", IcicleColorScale
                "autocolorscale", T<bool>
                "reverscale", T<bool>
                "showscale", T<bool>
                "colorbar", IcicleColorBar.Type
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let IcicleAlign =
        Pattern.EnumStrings "IcicleAlign" [
            "left"
            "right"
            "auto"
        ]

    let IcicleHoverLabel =
        Pattern.Config "IcicleHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", IcicleColor + !| IcicleColor
                "bordercolor", IcicleColor + !| IcicleColor
                "fonts", IcicleFont.Type
                "align", IcicleAlign.Type
                "namelength", T<int>
            ]
        }

    let IcicleDomain =
        Pattern.Config "IcicleDomain" {
            Required = []
            Optional = [
                "x", !| T<int> + !| T<float>
                "y", !| T<int> + !| T<float>
                "row", T<int>
                "column", T<int>
            ]
        }

    let IcicleBranchValues =
        Pattern.EnumStrings "IcicleBranchValues" [
            "remainder"
            "total"
        ]

    let IcicleCount =
        Pattern.EnumStrings "IcicleCount" [
            "branches"
            "leaves"
            "branches+leaves"
            "leaves+branches"
        ]

    let IcicleRoot =
        Pattern.Config "IcicleRoot" {
            Required = []
            Optional = [
                "color", IcicleColor
            ]
        }

    let IcicleLeaf =
        Pattern.Config "IcicleLeaf" {
            Required = []
            Optional = [
                "opacity", T<float>
            ]
        }

    let IcicleTilingFlip =
        Pattern.EnumStrings "IcicleTilingFlip" [
            "x"
            "y"
            "x+y"
            "y+x"
        ]

    let IcicleTilingOrientation =
        Pattern.EnumStrings "IcicleTilingOrientation" [
            "v"
            "h"
        ]

    let IcicleTiling =
        Pattern.Config "IcicleTiling" {
            Required = []
            Optional = [
                "orientation", IcicleTilingOrientation.Type
                "flip", IcicleTilingFlip.Type
                "pad", T<int> + T<float>
            ]
        }

    let IciclePathBarSide =
        Pattern.EnumStrings "IciclePathBarSide" [
            "top"
            "bottom"
        ]

    let IciclePathBarES =
        Pattern.EnumInlines "IciclePathBarES" [
            "greater", "'>'"
            "lower", "'<'"
            "pipeline", "'|'"
            "slash", "'/'"
            "backslash", "'\'" //TODO
        ]

    let IciclePathBar =
        Pattern.Config "IciclePathBar" {
            Required = []
            Optional = [
                "visible", T<bool>
                "side", IciclePathBarSide.Type
                "edgeshape", IciclePathBarES.Type
                "thickness", T<int> + T<float>
                "textfont", IcicleFont.Type
            ]
        }

    let IcicleOptions =
        Class "IcicleOptions"
        |=> Inherits CommonModule.Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'icicle'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + IcicleVisibleString.Type
            "legendrank", (T<float> + T<int>)
            "legendgrouptitle", IcicleLegendGroupTitle.Type
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
            "customdata", !| T<string> + !| T<int> + !| T<float>
            "domain", IcicleDomain.Type
            "marker", IcicleMarker.Type
            "textfont", IcicleFont.Type
            "textinfo", !| T<string> //TODO
            "branchvalues", IcicleBranchValues.Type
            "count", IcicleCount.Type
            "tiling", IcicleTiling.Type
            "pathbar", IciclePathBar.Type
            "hoverlabel", IcicleHoverLabel.Type
            "insidetextfont", IcicleFont.Type
            "outsidetextfont", IcicleFont.Type
            "root", IcicleRoot.Type
            "leaf", IcicleLeaf.Type
            "level", T<int> + T<float> + T<string>
            "maxdepth", T<int>
            "sort", T<bool>
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let IcicleTraceNamespaces : CodeModel.NamespaceEntity list = [
        IcicleNullValue
        IcicleVisibleString
        IcicleFont
        IcicleLegendGroupTitle
        IcicleMarkerLine
        IcicleColorBarMode
        IcicleXAnchor
        IcicleYAnchor
        IcicleTickMode
        IcicleTicks
        IcicleTickLabelOverflow
        IcicleTickLabelPosition
        IcicleTickFormatStops
        IcicleShowTickFix
        IcicleExponentFormat
        IcicleSide
        IcicleTitle
        IcicleColorBar
        IcicleMarker
        IcicleAlign
        IcicleHoverLabel
        IcicleDomain
        IcicleBranchValues
        IcicleCount
        IcicleRoot
        IcicleLeaf
        IcicleTilingFlip
        IcicleTilingOrientation
        IcicleTiling
        IciclePathBarSide
        IciclePathBarES
        IciclePathBar
        IcicleOptions
    ]