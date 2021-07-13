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

module SurfaceModule =

    let SurfaceNullValue = Pattern.EnumInlines "SurfaceNullValue" ["null", "null"]

    let SurfaceColor = T<string> + (T<float> + T<int>) + (!| (!? (SurfaceNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (SurfaceNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let SurfaceColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let SurfaceVisibleString = Pattern.EnumStrings "SurfaceVisibleString" ["legendonly"]

    let SurfaceFont =
        Pattern.Config "SurfaceFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", SurfaceColor
            ]
        }

    let SurfaceLegendGroupTitle =
        Pattern.Config "SurfaceLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", SurfaceFont.Type
            ]
        }

    let SurfaceHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "SurfaceHoverInfo" generatedEnum

    let SurfaceColorBarMode =
        Pattern.EnumStrings "SurfaceThicknessMode" [
            "fraction"
            "pixels"
        ]

    let SurfaceXAnchor =
        Pattern.EnumStrings "SurfaceXAnchor" [
            "left"
            "center"
            "right"
        ]

    let SurfaceYAnchor =
        Pattern.EnumStrings "SurfaceYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let SurfaceTickMode =
        Pattern.EnumStrings "SurfaceTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let SurfaceTicks =
        Pattern.EnumInlines "SurfaceTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let SurfaceTickLabelOverflow =
        Pattern.EnumInlines "SurfaceTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let SurfaceTickLabelPosition =
        Pattern.EnumInlines "SurfaceTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let SurfaceTickFormatStops =
        Pattern.Config "SurfaceTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + SurfaceNullValue.Type) * (DTickValue + SurfaceNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let SurfaceShowTickFix =
        Pattern.EnumStrings "SurfaceShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = SurfaceShowTickFix

    let SurfaceExponentFormat =
        Pattern.EnumInlines "SurfaceExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let SurfaceSide =
        Pattern.EnumStrings "SurfaceSide" [
            "right"
            "top"
            "bottom"
        ]

    let SurfaceTitle =
        Pattern.Config "SurfaceTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", SurfaceFont.Type
                "side", SurfaceSide.Type
            ]
        }

    let SurfaceColorBar =
        Pattern.Config "SurfaceColorBar" {
            Required = []
            Optional = [
                "thicknessmode", SurfaceColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", SurfaceColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", SurfaceXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", SurfaceYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", SurfaceColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", SurfaceColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", SurfaceColor
                "tickmode", SurfaceTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", SurfaceTicks.Type
                "ticklabeloverflow", SurfaceTickLabelOverflow.Type
                "ticklabelposition", SurfaceTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", SurfaceColor
                "showticklabels", T<bool>
                "tickfont", SurfaceFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", SurfaceTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", SurfaceShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", SurfaceShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", SurfaceExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", SurfaceTitle.Type
            ]
        }

    let SurfaceAlign =
        Pattern.EnumStrings "SurfaceAlign" [
            "left"
            "right"
            "auto"
        ]

    let SurfaceHoverLabel =
        Pattern.Config "SurfaceHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", SurfaceColor + !| SurfaceColor
                "bordercolor", SurfaceColor + !| SurfaceColor
                "fonts", SurfaceFont.Type
                "align", SurfaceAlign.Type
                "namelength", T<int>
            ]
        }

    let SurfaceCalendar =
        Pattern.EnumStrings "SurfaceCalendar" [
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

    let SurfaceLighting =
        Pattern.Config "SurfaceLighting" {
            Required = []
            Optional = [
                "ambient", T<float>
                "diffuse", T<float>
                "specular", T<float>
                "roughness", T<float>
                "fresnel", T<float>
            ]        
        }

    let SurfaceLightPosition =
        Pattern.Config "SurfaceLightPosition" {
            Required = []
            Optional = [
                "x", T<int> + T<float>
                "y", T<int> + T<float>
                "z", T<int> + T<float>
            ]
        }

    let SurfaceContoursProject =
        Pattern.Config "SurfaceContoursProject" {
            Required = []
            Optional = [
                "x", T<bool>
                "y", T<bool>
                "z", T<bool>
            ]
        }

    let SurfaceContoursXYZ =
        Pattern.Config "SurfaceContoursXYZ" {
            Required = []
            Optional = [
                "show", T<bool>
                "start", T<int> + T<float>
                "end", T<int> + T<float>
                "size", T<int> + T<float>
                "project", SurfaceContoursProject.Type
                "color", SurfaceColor
                "usecolormap", T<bool>
                "width", T<int> + T<float>
                "highlight", T<bool>
                "highlightcolorr", SurfaceColor
                "highlightwidth", T<int> + T<float>
            ]
        }

    let SurfaceContours =
        Pattern.Config "SurfaceContours" {
            Required = []
            Optional = [
                "x", SurfaceContoursXYZ.Type
                "y", SurfaceContoursXYZ.Type
                "z", SurfaceContoursXYZ.Type
            ]
        }

    let SurfaceOptions =
        Class "SurfaceOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'surface'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + SurfaceVisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", SurfaceLegendGroupTitle.Type
            "opacity", T<float>
            "ids", !| T<string>
            "x", !| T<int> + !| T<float>
            "y", !| T<int> + !| T<float>
            "z", !| T<int> + !| T<float>
            "surfacecolor", SurfaceColor
            "text", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", SurfaceHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "scene", T<string> //subplotid
            "coloraxis", T<string> // type: subplotid
            "colorbar", SurfaceColorBar.Type
            "autocolorscale", T<bool>
            "colorscale", SurfaceColorScale
            "showscale", T<bool>
            "reverscale", T<bool>
            "zhoverformat", T<string>
            "cauto", T<bool>
            "cmax", T<int> + T<float>
            "cmid", T<int> + T<float>
            "cmin", T<int> + T<float>
            "connectgaps", T<bool>
            "contours", SurfaceContours.Type //
            "hidesurface", T<bool>
            "hoverlabel", SurfaceHoverLabel.Type
            "lighting", SurfaceLighting.Type
            "lightposition", SurfaceLightPosition.Type
            "opacityscale", T<int> + T<float> + T<string>
            "xcalendar", SurfaceCalendar.Type
            "ycalendar", SurfaceCalendar.Type
            "zcalendar", SurfaceCalendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let SurfaceTraceNamespaces : CodeModel.NamespaceEntity list = [
        SurfaceNullValue
        SurfaceVisibleString
        SurfaceFont
        SurfaceLegendGroupTitle
        SurfaceHoverInfo
        SurfaceColorBarMode
        SurfaceXAnchor
        SurfaceYAnchor
        SurfaceTickMode
        SurfaceTicks
        SurfaceTickLabelOverflow
        SurfaceTickLabelPosition
        SurfaceTickFormatStops
        SurfaceShowTickFix
        ShowExponent
        SurfaceExponentFormat
        SurfaceSide
        SurfaceTitle
        SurfaceColorBar
        SurfaceAlign
        SurfaceHoverLabel
        SurfaceCalendar
        SurfaceLighting
        SurfaceLightPosition
        SurfaceContoursProject
        SurfaceContoursXYZ
        SurfaceContours
        SurfaceOptions
    ]