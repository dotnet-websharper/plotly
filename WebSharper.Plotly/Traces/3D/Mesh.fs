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

module MeshModule =

    let MeshNullValue = Pattern.EnumInlines "MeshNullValue" ["null", "null"]

    let MeshColor = T<string> + (T<float> + T<int>) + (!| (!? (MeshNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (MeshNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let MeshColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let MeshVisibleString = Pattern.EnumStrings "MeshVisibleString" ["legendonly"]

    let MeshFont =
        Pattern.Config "MeshFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", MeshColor
            ]
        }

    let MeshLegendGroupTitle =
        Pattern.Config "MeshLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", MeshFont.Type
            ]
        }

    let MeshHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "MeshHoverInfo" generatedEnum

    let MeshColorBarMode =
        Pattern.EnumStrings "MeshThicknessMode" [
            "fraction"
            "pixels"
        ]

    let MeshXAnchor =
        Pattern.EnumStrings "MeshXAnchor" [
            "left"
            "center"
            "right"
        ]

    let MeshYAnchor =
        Pattern.EnumStrings "MeshYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let MeshTickMode =
        Pattern.EnumStrings "MeshTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let MeshTicks =
        Pattern.EnumInlines "MeshTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let MeshTickLabelOverflow =
        Pattern.EnumInlines "MeshTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let MeshTickLabelPosition =
        Pattern.EnumInlines "MeshTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let MeshTickFormatStops =
        Pattern.Config "MeshTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + MeshNullValue.Type) * (DTickValue + MeshNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let MeshShowTickFix =
        Pattern.EnumStrings "MeshShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = MeshShowTickFix

    let MeshExponentFormat =
        Pattern.EnumInlines "MeshExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let MeshSide =
        Pattern.EnumStrings "MeshSide" [
            "right"
            "top"
            "bottom"
        ]

    let MeshTitle =
        Pattern.Config "MeshTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", MeshFont.Type
                "side", MeshSide.Type
            ]
        }

    let MeshColorBar =
        Pattern.Config "MeshColorBar" {
            Required = []
            Optional = [
                "thicknessmode", MeshColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", MeshColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", MeshXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", MeshYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", MeshColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", MeshColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", MeshColor
                "tickmode", MeshTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", MeshTicks.Type
                "ticklabeloverflow", MeshTickLabelOverflow.Type
                "ticklabelposition", MeshTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", MeshColor
                "showticklabels", T<bool>
                "tickfont", MeshFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", MeshTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", MeshShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", MeshShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", MeshExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", MeshTitle.Type
            ]
        }

    let MeshAlign =
        Pattern.EnumStrings "MeshAlign" [
            "left"
            "right"
            "auto"
        ]

    let MeshHoverLabel =
        Pattern.Config "MeshHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", MeshColor + !| MeshColor
                "bordercolor", MeshColor + !| MeshColor
                "fonts", MeshFont.Type
                "align", MeshAlign.Type
                "namelength", T<int>
            ]
        }

    let MeshCalendar =
        Pattern.EnumStrings "MeshCalendar" [
            "gregorian"
            "chinese"
            "coptic"
            "discworld"
            "ethiopian"
            "hebrew"
            "islamic"
            "julian"
            "mayan"
            "nanakshahi"
            "nepali"
            "persian"
            "jalali"
            "taiwan"
            "thai"
            "ummalqura"
        ]

    let MeshLighting =
        Pattern.Config "MeshLighting" {
            Required = []
            Optional = [
                "ambient", T<float>
                "diffuse", T<float>
                "specular", T<float>
                "roughness", T<float>
                "fresnel", T<float>
            ]        
        }

    let MeshLightPosition =
        Pattern.Config "MeshLightPosition" {
            Required = []
            Optional = [
                "x", T<int> + T<float>
                "y", T<int> + T<float>
                "z", T<int> + T<float>
            ]
        }

    let MeshIntensityMode =
        Pattern.EnumStrings "MeshIntensityMode" [
            "vertex"
            "cell"
        ]

    let MeshDelanuayAxis =
        Pattern.EnumStrings "MeshDelanuayAxis" [
            "x"
            "y"
            "z"
        ]

    let MeshContour =
        Pattern.Config "MeshContour" {
            Required = []
            Optional = [
                "show", T<bool>
                "color", MeshColor
                "width", T<int> + T<float>
            ]
        }

    let MeshOptions =
        Class "MeshOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'mesh3d'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + MeshVisibleString.Type
            "showlegend", T<bool>
            "legendrank", T<float> + T<int>
            "legendgroup", T<string>
            "legendgrouptitle", MeshLegendGroupTitle.Type
            "opacity", T<float>
            "ids", !| T<string>
            "x", !| T<int> + !| T<float> //data array
            "y", !| T<int> + !| T<float> //data array
            "z", !| T<int> + !| T<float> //data array
            "i", !| T<int> + !| T<float> //data array
            "j", !| T<int> + !| T<float> //data array
            "k", !| T<int> + !| T<float> //data array
            "facecolor", MeshColor
            "intensity", !| T<int> + !| T<float> //data array
            "intensitymode", MeshIntensityMode.Type
            "vertexcolor",  !| T<int> + !| T<float> //data array
            "text", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", MeshHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "scene", T<string> //subplotid
            "coloraxis", T<string> // type: subplotid
            "color", MeshColor
            "colorbar", MeshColorBar.Type
            "autocolorscale", T<bool>
            "colorscale", MeshColorScale
            "showscale", T<bool>
            "reverscale", T<bool>
            "zhoverformat", T<string>
            "cauto", T<bool>
            "cmax", T<int> + T<float>
            "cmid", T<int> + T<float>
            "cmin", T<int> + T<float>
            "alphahull", T<int> + T<float>
            "delaunayaxis", MeshDelanuayAxis.Type
            "contour", MeshContour.Type
            "flatshading", T<bool>
            "hoverlabel", MeshHoverLabel.Type
            "lighting", MeshLighting.Type
            "lightposition", MeshLightPosition.Type
            "xcalendar", MeshCalendar.Type
            "ycalendar", MeshCalendar.Type
            "zcalendar", MeshCalendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let MeshTraceNamespaces : CodeModel.NamespaceEntity list = [
        MeshNullValue
        MeshVisibleString
        MeshFont
        MeshLegendGroupTitle
        MeshHoverInfo
        MeshColorBarMode
        MeshXAnchor
        MeshYAnchor
        MeshTickMode
        MeshTicks
        MeshTickLabelOverflow
        MeshTickLabelPosition
        MeshTickFormatStops
        MeshShowTickFix
        ShowExponent
        MeshExponentFormat
        MeshSide
        MeshTitle
        MeshColorBar
        MeshAlign
        MeshHoverLabel
        MeshCalendar
        MeshLighting
        MeshLightPosition
        MeshIntensityMode
        MeshDelanuayAxis
        MeshContour
        MeshOptions
    ]