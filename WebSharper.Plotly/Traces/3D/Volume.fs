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

module VolumeModule =

    let VolumeNullValue = Pattern.EnumInlines "VolumeNullValue" ["null", "null"]

    let VolumeColor = T<string> + (T<float> + T<int>) + (!| (!? (VolumeNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (VolumeNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let VolumeColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let VolumeVisibleString = Pattern.EnumStrings "VolumeVisibleString" ["legendonly"]

    let VolumeFont =
        Pattern.Config "VolumeFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", VolumeColor
            ]
        }

    let VolumeLegendGroupTitle =
        Pattern.Config "VolumeLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", VolumeFont.Type
            ]
        }

    let VolumeHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "VolumeHoverInfo" generatedEnum

    let VolumeColorBarMode =
        Pattern.EnumStrings "VolumeThicknessMode" [
            "fraction"
            "pixels"
        ]

    let VolumeXAnchor =
        Pattern.EnumStrings "VolumeXAnchor" [
            "left"
            "center"
            "right"
        ]

    let VolumeYAnchor =
        Pattern.EnumStrings "VolumeYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let VolumeTickMode =
        Pattern.EnumStrings "VolumeTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let VolumeTicks =
        Pattern.EnumInlines "VolumeTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let VolumeTickLabelOverflow =
        Pattern.EnumInlines "VolumeTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let VolumeTickLabelPosition =
        Pattern.EnumInlines "VolumeTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let VolumeTickFormatStops =
        Pattern.Config "VolumeTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + VolumeNullValue.Type) * (DTickValue + VolumeNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let VolumeShowTickFix =
        Pattern.EnumStrings "VolumeShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = VolumeShowTickFix

    let VolumeExponentFormat =
        Pattern.EnumInlines "VolumeExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let VolumeSide =
        Pattern.EnumStrings "VolumeSide" [
            "right"
            "top"
            "bottom"
        ]

    let VolumeTitle =
        Pattern.Config "VolumeTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", VolumeFont.Type
                "side", VolumeSide.Type
            ]
        }

    let VolumeColorBar =
        Pattern.Config "VolumeColorBar" {
            Required = []
            Optional = [
                "thicknessmode", VolumeColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", VolumeColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", VolumeXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", VolumeYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", VolumeColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", VolumeColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", VolumeColor
                "tickmode", VolumeTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", VolumeTicks.Type
                "ticklabeloverflow", VolumeTickLabelOverflow.Type
                "ticklabelposition", VolumeTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", VolumeColor
                "showticklabels", T<bool>
                "tickfont", VolumeFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", VolumeTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", VolumeShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", VolumeShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", VolumeExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", VolumeTitle.Type
            ]
        }

    let VolumeAlign =
        Pattern.EnumStrings "VolumeAlign" [
            "left"
            "right"
            "auto"
        ]

    let VolumeHoverLabel =
        Pattern.Config "VolumeHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", VolumeColor + !| VolumeColor
                "bordercolor", VolumeColor + !| VolumeColor
                "fonts", VolumeFont.Type
                "align", VolumeAlign.Type
                "namelength", T<int>
            ]
        }

    let VolumeLighting =
        Pattern.Config "VolumeLighting" {
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

    let VolumeLightPosition =
        Pattern.Config "VolumeLightPosition" {
            Required = []
            Optional = [
                "x", T<int> + T<float>
                "y", T<int> + T<float>
                "z", T<int> + T<float>
            ]
        }

    let VolumeCapsXYZ =
        Pattern.Config "VolumeCapsXYZ" {
            Required = []
            Optional = [
                "show", T<bool>
                "fill", T<int> + T<float>
            ]
        }

    let VolumeCaps =
        Pattern.Config "VolumeCaps" {
            Required = []
            Optional = [
                "x", VolumeCapsXYZ.Type
                "y", VolumeCapsXYZ.Type
                "z", VolumeCapsXYZ.Type
            ]
        }

    let VolumeContour =
        Pattern.Config "VolumeContour" {
            Required = []
            Optional = [
                "show", T<bool>
                "color", VolumeColor
                "width", T<int> + T<float>
            ]
        }

    let VolumeSlicesXYZ =
        Pattern.Config "VolumeSlicesXYZ" {
            Required = []
            Optional = [
                "show", T<bool>
                "locations", !| T<int> + !| T<float> + !| T<string>
                "fill", T<float>
            ]
        }

    let VolumeSlices =
        Pattern.Config "VolumeSlices" {
            Required = []
            Optional = [
                "x", VolumeSlicesXYZ.Type
                "y", VolumeSlicesXYZ.Type
                "z", VolumeSlicesXYZ.Type
            ]
        }

    let VolumeSpaceFrame =
        Pattern.Config "VolumeSpaceFrame" {
            Required = []
            Optional = [
                "show", T<bool>
                "fill", T<float>
            ]
        }

    let VolumeSurfacePattern =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["A"; "B"; "C"; "D"; "E"] '+')
            let seq2 = seq{"all"; "odd"; "even"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "VolumeSurfacePattern" generatedEnum

    let VolumeSurface =
        Pattern.Config "VolumeSurface" {
            Required = []
            Optional = [
                "show", T<bool>
                "count", T<int>
                "fill", T<float>
                "pattern", VolumeSurfacePattern.Type
            ]
        }

    let VolumeOptions =
        Class "VolumeOptions"
        |=> Inherits CommonModule.Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'volume'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VolumeVisibleString.Type
            "showlegend", T<bool>
            "legendrank", T<float> + T<int>
            "legendgroup", T<string>
            "legendgrouptitle", VolumeLegendGroupTitle.Type
            "opacity", T<float>
            "ids", !| T<string>
            "x", !| T<int> + !| T<float> //data array
            "y", !| T<int> + !| T<float> //data array
            "z", !| T<int> + !| T<float> //data array
            "value", !| T<int> + !| T<float> + !| T<string>
            "text", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", VolumeHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "valuehoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "scene", T<string> //subplotid
            "coloraxis", T<string> // type: subplotid
            "colorbar", VolumeColorBar.Type
            "autocolorscale", T<bool>
            "colorscale", VolumeColorScale
            "showscale", T<bool>
            "reverscale", T<bool>
            "zhoverformat", T<string>
            "cauto", T<bool>
            "cmax", T<int> + T<float>
            "cmid", T<int> + T<float>
            "cmin", T<int> + T<float>
            "caps", VolumeCaps.Type
            "contour", VolumeContour.Type
            "flatshading", T<bool>
            "hoverlabel", VolumeHoverLabel.Type
            "isomax", T<int> + T<float>
            "isomin", T<int> + T<float>
            "lighting", VolumeLighting.Type
            "lightposition", VolumeLightPosition.Type
            "opacityscale", T<int> + T<float> + T<string>
            "slices", VolumeSlices.Type
            "spaceframe", VolumeSpaceFrame.Type
            "surface", VolumeSurface.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let VolumeTraceNamespaces : CodeModel.NamespaceEntity list = [
        VolumeNullValue
        VolumeVisibleString
        VolumeFont
        VolumeLegendGroupTitle
        VolumeHoverInfo
        VolumeColorBarMode
        VolumeXAnchor
        VolumeYAnchor
        VolumeTickMode
        VolumeTicks
        VolumeTickLabelOverflow
        VolumeTickLabelPosition
        VolumeTickFormatStops
        VolumeShowTickFix
        VolumeExponentFormat
        VolumeSide
        VolumeTitle
        VolumeColorBar
        VolumeAlign
        VolumeHoverLabel
        VolumeLighting
        VolumeLightPosition
        VolumeCapsXYZ
        VolumeCaps
        VolumeContour
        VolumeSlicesXYZ
        VolumeSlices
        VolumeSpaceFrame
        VolumeSurfacePattern
        VolumeSurface
        VolumeOptions
    ]