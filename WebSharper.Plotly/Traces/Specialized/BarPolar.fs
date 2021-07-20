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

module BarPolarModule =

    let BarPolarNullValue = Pattern.EnumInlines "BarPolarNullValue" ["null", "null"]

    let BarPolarColor = T<string> + (T<float> + T<int>) + (!| (!? (BarPolarNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (BarPolarNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let BarPolarColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let BarPolarVisibleString = Pattern.EnumStrings "BarPolarVisibleString" ["legendonly"]

    let BarPolarFont =
        Pattern.Config "BarPolarFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", BarPolarColor
            ]
        }

    let BarPolarLegendGroupTitle =
        Pattern.Config "BarPolarLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", BarPolarFont.Type
            ]
        }

    let BarPolarModes =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["lines"; "markers"; "text"] '+')
            let seq2 = seq{"none"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "BarPolarModes" generatedEnum

    let BarPolarHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["r"; "thetea"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "BarPolarHoverInfo" generatedEnum

    let BarPolarMarkerLine =
        Pattern.Config "BarPolarMarkerLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
                "color", BarPolarColor
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", BarPolarColorScale
                "autocolorscale", T<bool>
                "reversescale", T<bool>
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let BarPolarColorBarMode =
        Pattern.EnumStrings "BarPolarThicknessMode" [
            "fraction"
            "pixels"
        ]

    let BarPolarXAnchor =
        Pattern.EnumStrings "BarPolarXAnchor" [
            "left"
            "center"
            "right"
        ]

    let BarPolarYAnchor =
        Pattern.EnumStrings "BarPolarYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let BarPolarTickMode =
        Pattern.EnumStrings "BarPolarTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let BarPolarTicks =
        Pattern.EnumInlines "BarPolarTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let BarPolarTickLabelOverflow =
        Pattern.EnumInlines "BarPolarTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let BarPolarTickLabelPosition =
        Pattern.EnumInlines "BarPolarTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let BarPolarTickFormatStops =
        Pattern.Config "BarPolarTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + BarPolarNullValue.Type) * (DTickValue + BarPolarNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let BarPolarShowTickFix =
        Pattern.EnumStrings "BarPolarShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = BarPolarShowTickFix

    let BarPolarExponentFormat =
        Pattern.EnumInlines "BarPolarExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let BarPolarSide =
        Pattern.EnumStrings "BarPolarSide" [
            "right"
            "top"
            "bottom"
        ]

    let BarPolarTitle =
        Pattern.Config "BarPolarTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", BarPolarFont.Type
                "side", BarPolarSide.Type
            ]
        }

    let BarPolarColorBar =
        Pattern.Config "BarPolarColorBar" {
            Required = []
            Optional = [
                "thicknessmode", BarPolarColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", BarPolarColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", BarPolarXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", BarPolarYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", BarPolarColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", BarPolarColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", BarPolarColor
                "tickmode", BarPolarTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", BarPolarTicks.Type
                "ticklabeloverflow", BarPolarTickLabelOverflow.Type
                "ticklabelposition", BarPolarTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", BarPolarColor
                "showticklabels", T<bool>
                "tickfont", BarPolarFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", BarPolarTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", BarPolarShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", BarPolarShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", BarPolarExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", BarPolarTitle.Type
            ]
        }

    let BarPolarMarkerPatternShape =
        Pattern.EnumInlines "BarPolarMarkerPatternShape" [
            "empty", "''"
            "slash", "'/'"
            "backslash", """'\\'"""
            "x", "'x'"
            "minus", "'-'"
            "pipeline", "'|'"
            "plus", "'+'"
            "dot", "'.'"
        ]

    let BarPolarFillMode =
        Pattern.EnumStrings "BarPolarFillMode" [
            "replace"
            "overlay"
        ]

    let BarPolarMarkerPattern =
        Pattern.Config "BarPolarMarkerPattern" {
            Required = []
            Optional = [
                "shape", BarPolarMarkerPatternShape.Type
                "fillmode", BarPolarFillMode.Type
                "bgcolor", BarPolarColor + !| BarPolarColor
                "fgcolor", BarPolarColor + !| BarPolarColor
                "fgopacity", (T<float> + T<int>)
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "solidity", (T<float> + T<int>) + !| T<float> + !| T<int>               
            ]
        }

    let BarPolarMarker =
        Pattern.Config "BarPolarMarker" {
            Required = []
            Optional = [
                "opacity", T<float> + !| T<float>
                "line", BarPolarMarkerLine.Type
                "color", BarPolarColor + !| BarPolarColor
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", BarPolarColorScale
                "autocolorscale", T<bool>
                "reverscale", T<bool>
                "showscale", T<bool>
                "ColorBar", BarPolarColorBar.Type
                "coloraxis", T<string> // type: subplotid
                "pattern", BarPolarMarkerPattern.Type
            ]
        }

    let BarPolarSelectedMarker =
        Pattern.Config "BarPolarSelectedMarker" {
            Required = []
            Optional = [
                "opacity", (T<float> + T<int>)
                "color", BarPolarColor
                "size", (T<float> + T<int>)
            ]
        }

    let BarPolarSelectedTextFont =
        Pattern.Config "BarPolarSelectedTextFont" {
            Required = []
            Optional = ["color", BarPolarColor]
        }

    let BarPolarSelectedOption =
        Pattern.Config "BarPolarSelectedOption" {
            Required = []
            Optional = [
                "marker", BarPolarSelectedMarker.Type
                "textfont", BarPolarSelectedTextFont.Type
            ]
        }

    let BarPolarFill =
        Pattern.EnumStrings "BarPolarFill" [
            "none"
            "tozeroy"
            "tozerox"
            "tonexty"
            "tonextx"
            "toself"
            "tonext"
        ]

    let BarPolarAlign =
        Pattern.EnumStrings "BarPolarAlign" [
            "left"
            "right"
            "auto"
        ]

    let BarPolarHoverLabel =
        Pattern.Config "BarPolarHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", BarPolarColor + !| BarPolarColor
                "bordercolor", BarPolarColor + !| BarPolarColor
                "fonts", BarPolarFont.Type
                "align", BarPolarAlign.Type
                "namelength", T<int>
            ]
        }

    let BarPolarThetaUnit =
        Pattern.EnumStrings "BarPolarThetaUnit" [
            "radians"
            "degrees"
            "gradians"
        ]

    let BarPolarOptions =
        Class "BarPolarOptions"
        |=> Inherits CommonModule.Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'BarPolar'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + BarPolarVisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", BarPolarLegendGroupTitle.Type
            "opacity", T<float>
            "mode", BarPolarModes.Type
            "ids", !| T<string>
            "base", T<int> + T<float> + T<string>
            "r", !| T<int> + !| T<float>
            "r0", (T<float> + T<int>) + T<string>
            "dr", (T<float> + T<int>)
            "theta", !| T<int> + !| T<float>
            "theta0", (T<float> + T<int>) + T<string>
            "dtheta", (T<float> + T<int>)
            "thetaunit", BarPolarThetaUnit.Type
            "width", T<int> + T<float> + !| T<int> + !| T<float>
            "offset", T<int> + T<float> + !| T<int> + !| T<float>
            "text", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", BarPolarHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "subplot", T<string> //type is 'subplotid'
            "marker", BarPolarMarker.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", BarPolarSelectedOption.Type
            "unselected", BarPolarSelectedOption.Type // change name later
            "hoverlabel", BarPolarHoverLabel.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let BarPolarTraceNamespaces : CodeModel.NamespaceEntity list = [
        BarPolarNullValue
        BarPolarVisibleString
        BarPolarFont
        BarPolarLegendGroupTitle
        BarPolarModes
        BarPolarHoverInfo
        BarPolarMarkerLine
        BarPolarColorBarMode
        BarPolarXAnchor
        BarPolarYAnchor
        BarPolarTickMode
        BarPolarTicks
        BarPolarTickLabelOverflow
        BarPolarTickLabelPosition
        BarPolarTickFormatStops
        BarPolarShowTickFix
        BarPolarExponentFormat
        BarPolarSide
        BarPolarTitle
        BarPolarColorBar
        BarPolarMarkerPatternShape
        BarPolarFillMode
        BarPolarMarkerPattern
        BarPolarMarker
        BarPolarSelectedMarker
        BarPolarSelectedTextFont
        BarPolarSelectedOption
        BarPolarFill
        BarPolarAlign
        BarPolarHoverLabel
        BarPolarThetaUnit
        BarPolarOptions
    ]