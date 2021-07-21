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

    open CommonModule

    let VolumeHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "VolumeHoverInfo" generatedEnum    

    let VolumeContour =
        Pattern.Config "VolumeContour" {
            Required = []
            Optional = [
                "show", T<bool>
                "color", Color
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
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'volume'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "showlegend", T<bool>
            "legendrank", T<float> + T<int>
            "legendgroup", T<string>
            "legendgrouptitle", LegendGroupTitle.Type
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
            "coloraxis", T<string> // subplotid
            "colorbar", ColorBar.Type
            "autocolorscale", T<bool>
            "colorscale", ColorScale
            "showscale", T<bool>
            "reverscale", T<bool>
            "zhoverformat", T<string>
            "cauto", T<bool>
            "cmax", T<int> + T<float>
            "cmid", T<int> + T<float>
            "cmin", T<int> + T<float>
            "caps", Caps.Type
            "contour", VolumeContour.Type
            "flatshading", T<bool>
            "hoverlabel", HoverLabel.Type
            "isomax", T<int> + T<float>
            "isomin", T<int> + T<float>
            "lighting",Lighting.Type
            "lightposition", LightPosition.Type
            "opacityscale", T<int> + T<float> + T<string>
            "slices", VolumeSlices.Type
            "spaceframe", VolumeSpaceFrame.Type
            "surface", VolumeSurface.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let VolumeTraceNamespaces : CodeModel.NamespaceEntity list = [
        VolumeHoverInfo
        VolumeContour
        VolumeSlicesXYZ
        VolumeSlices
        VolumeSpaceFrame
        VolumeSurfacePattern
        VolumeSurface
        VolumeOptions
    ]