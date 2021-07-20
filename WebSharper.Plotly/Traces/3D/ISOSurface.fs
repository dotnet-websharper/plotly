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

module ISOSurfaceModule =

    let ISOSurfaceNullValue = Pattern.EnumInlines "ISOSurfaceNullValue" ["null", "null"]

    let ISOSurfaceColor = T<string> + (T<float> + T<int>) + (!| (!? (ISOSurfaceNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (ISOSurfaceNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let ISOSurfaceColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let ISOSurfaceVisibleString = Pattern.EnumStrings "ISOSurfaceVisibleString" ["legendonly"]

    let ISOSurfaceFont =
        Pattern.Config "ISOSurfaceFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", ISOSurfaceColor
            ]
        }

    let ISOSurfaceLegendGroupTitle =
        Pattern.Config "ISOSurfaceLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ISOSurfaceFont.Type
            ]
        }

    let ISOSurfaceHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ISOSurfaceHoverInfo" generatedEnum

    let ISOSurfaceColorBarMode =
        Pattern.EnumStrings "ISOSurfaceThicknessMode" [
            "fraction"
            "pixels"
        ]

    let ISOSurfaceXAnchor =
        Pattern.EnumStrings "ISOSurfaceXAnchor" [
            "left"
            "center"
            "right"
        ]

    let ISOSurfaceYAnchor =
        Pattern.EnumStrings "ISOSurfaceYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let ISOSurfaceTickMode =
        Pattern.EnumStrings "ISOSurfaceTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let ISOSurfaceTicks =
        Pattern.EnumInlines "ISOSurfaceTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let ISOSurfaceTickLabelOverflow =
        Pattern.EnumInlines "ISOSurfaceTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let ISOSurfaceTickLabelPosition =
        Pattern.EnumInlines "ISOSurfaceTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let ISOSurfaceTickFormatStops =
        Pattern.Config "ISOSurfaceTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + ISOSurfaceNullValue.Type) * (DTickValue + ISOSurfaceNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let ISOSurfaceShowTickFix =
        Pattern.EnumStrings "ISOSurfaceShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = ISOSurfaceShowTickFix

    let ISOSurfaceExponentFormat =
        Pattern.EnumInlines "ISOSurfaceExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let ISOSurfaceSide =
        Pattern.EnumStrings "ISOSurfaceSide" [
            "right"
            "top"
            "bottom"
        ]

    let ISOSurfaceTitle =
        Pattern.Config "ISOSurfaceTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ISOSurfaceFont.Type
                "side", ISOSurfaceSide.Type
            ]
        }

    let ISOSurfaceColorBar =
        Pattern.Config "ISOSurfaceColorBar" {
            Required = []
            Optional = [
                "thicknessmode", ISOSurfaceColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", ISOSurfaceColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", ISOSurfaceXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", ISOSurfaceYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", ISOSurfaceColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", ISOSurfaceColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", ISOSurfaceColor
                "tickmode", ISOSurfaceTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", ISOSurfaceTicks.Type
                "ticklabeloverflow", ISOSurfaceTickLabelOverflow.Type
                "ticklabelposition", ISOSurfaceTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", ISOSurfaceColor
                "showticklabels", T<bool>
                "tickfont", ISOSurfaceFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", ISOSurfaceTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", ISOSurfaceShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", ISOSurfaceShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", ISOSurfaceExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", ISOSurfaceTitle.Type
            ]
        }

    let ISOSurfaceAlign =
        Pattern.EnumStrings "ISOSurfaceAlign" [
            "left"
            "right"
            "auto"
        ]

    let ISOSurfaceHoverLabel =
        Pattern.Config "ISOSurfaceHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", ISOSurfaceColor + !| ISOSurfaceColor
                "bordercolor", ISOSurfaceColor + !| ISOSurfaceColor
                "fonts", ISOSurfaceFont.Type
                "align", ISOSurfaceAlign.Type
                "namelength", T<int>
            ]
        }

    let ISOSurfaceLighting =
        Pattern.Config "ISOSurfaceLighting" {
            Required = []
            Optional = [
                "vertexnormalsepsilon", T<float>
                "facenormalsepsilon", T<float>
                "ambient", T<float>
                "diffuse", T<float>
                "specular", T<float>
                "roughness", T<float>
                "fresnel", T<float>
            ]        
        }

    let ISOSurfaceLightPosition =
        Pattern.Config "ISOSurfaceLightPosition" {
            Required = []
            Optional = [
                "x", T<int> + T<float>
                "y", T<int> + T<float>
                "z", T<int> + T<float>
            ]
        }

    let ISOSurfaceCapsXYZ =
        Pattern.Config "ISOSurfaceCapsXYZ" {
            Required = []
            Optional = [
                "show", T<bool>
                "fill", T<int> + T<float>
            ]
        }

    let ISOSurfaceCaps =
        Pattern.Config "ISOSurfaceCaps" {
            Required = []
            Optional = [
                "x", ISOSurfaceCapsXYZ.Type
                "y", ISOSurfaceCapsXYZ.Type
                "z", ISOSurfaceCapsXYZ.Type
            ]
        }

    let ISOSurfaceContour =
        Pattern.Config "ISOSurfaceContour" {
            Required = []
            Optional = [
                "show", T<bool>
                "color", ISOSurfaceColor
                "width", T<int> + T<float>
            ]
        }

    let ISOSurfaceSlicesXYZ =
        Pattern.Config "ISOSurfaceSlicesXYZ" {
            Required = []
            Optional = [
                "show", T<bool>
                "locations", !| T<int> + !| T<float> + !| T<string>
                "fill", T<float>
            ]
        }

    let ISOSurfaceSlices =
        Pattern.Config "ISOSurfaceSlices" {
            Required = []
            Optional = [
                "x", ISOSurfaceSlicesXYZ.Type
                "y", ISOSurfaceSlicesXYZ.Type
                "z", ISOSurfaceSlicesXYZ.Type
            ]
        }

    let ISOSurfaceSpaceFrame =
        Pattern.Config "ISOSurfaceSpaceFrame" {
            Required = []
            Optional = [
                "show", T<bool>
                "fill", T<float>
            ]
        }

    let ISOSurfaceSurfacePattern =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["A"; "B"; "C"; "D"; "E"] '+')
            let seq2 = seq{"all"; "odd"; "even"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ISOSurfaceSurfacePattern" generatedEnum

    let ISOSurfaceSurface =
        Pattern.Config "ISOSurfaceSurface" {
            Required = []
            Optional = [
                "show", T<bool>
                "count", T<int>
                "fill", T<float>
                "pattern", ISOSurfaceSurfacePattern.Type
            ]
        }

    let ISOSurfaceOptions =
        Class "ISOSurfaceOptions"
        |=> Inherits CommonModule.Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'isosurface'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + ISOSurfaceVisibleString.Type
            "showlegend", T<bool>
            "legendrank", T<float> + T<int>
            "legendgroup", T<string>
            "legendgrouptitle", ISOSurfaceLegendGroupTitle.Type
            "opacity", T<float>
            "ids", !| T<string>
            "x", !| T<int> + !| T<float> //data array
            "y", !| T<int> + !| T<float> //data array
            "z", !| T<int> + !| T<float> //data array
            "value", !| T<int> + !| T<float> + !| T<string>
            "text", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", ISOSurfaceHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "valuehoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "scene", T<string> //subplotid
            "coloraxis", T<string> // type: subplotid
            "colorbar", ISOSurfaceColorBar.Type
            "autocolorscale", T<bool>
            "colorscale", ISOSurfaceColorScale
            "showscale", T<bool>
            "reverscale", T<bool>
            "zhoverformat", T<string>
            "cauto", T<bool>
            "cmax", T<int> + T<float>
            "cmid", T<int> + T<float>
            "cmin", T<int> + T<float>
            "caps", ISOSurfaceCaps.Type
            "contour", ISOSurfaceContour.Type
            "flatshading", T<bool>
            "hoverlabel", ISOSurfaceHoverLabel.Type
            "isomax", T<int> + T<float>
            "isomin", T<int> + T<float>
            "lighting", ISOSurfaceLighting.Type
            "lightposition", ISOSurfaceLightPosition.Type
            "opacityscale", T<int> + T<float> + T<string>
            "slices", ISOSurfaceSlices.Type
            "spaceframe", ISOSurfaceSpaceFrame.Type
            "surface", ISOSurfaceSurface.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ISOSurfaceTraceNamespaces : CodeModel.NamespaceEntity list = [
        ISOSurfaceNullValue
        ISOSurfaceVisibleString
        ISOSurfaceFont
        ISOSurfaceLegendGroupTitle
        ISOSurfaceHoverInfo
        ISOSurfaceColorBarMode
        ISOSurfaceXAnchor
        ISOSurfaceYAnchor
        ISOSurfaceTickMode
        ISOSurfaceTicks
        ISOSurfaceTickLabelOverflow
        ISOSurfaceTickLabelPosition
        ISOSurfaceTickFormatStops
        ISOSurfaceShowTickFix
        ISOSurfaceExponentFormat
        ISOSurfaceSide
        ISOSurfaceTitle
        ISOSurfaceColorBar
        ISOSurfaceAlign
        ISOSurfaceHoverLabel
        ISOSurfaceLighting
        ISOSurfaceLightPosition
        ISOSurfaceCapsXYZ
        ISOSurfaceCaps
        ISOSurfaceContour
        ISOSurfaceSlicesXYZ
        ISOSurfaceSlices
        ISOSurfaceSpaceFrame
        ISOSurfaceSurfacePattern
        ISOSurfaceSurface
        ISOSurfaceOptions
    ]