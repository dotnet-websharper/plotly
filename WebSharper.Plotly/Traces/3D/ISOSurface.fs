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

    open CommonModule

    let ISOSurfaceHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ISOSurfaceHoverInfo" generatedEnum

    let ISOSurfaceContour =
        Pattern.Config "ISOSurfaceContour" {
            Required = []
            Optional = [
                "show", T<bool>
                "color", Color
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
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'isosurface'}"
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
            "hoverinfo", ISOSurfaceHoverInfo.Type
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
            "contour", ISOSurfaceContour.Type
            "flatshading", T<bool>
            "hoverlabel", HoverLabel.Type
            "isomax", T<int> + T<float>
            "isomin", T<int> + T<float>
            "lighting", Lighting.Type
            "lightposition", LightPosition.Type
            "opacityscale", T<int> + T<float> + T<string>
            "slices", ISOSurfaceSlices.Type
            "spaceframe", ISOSurfaceSpaceFrame.Type
            "surface", ISOSurfaceSurface.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ISOSurfaceTraceNamespaces : CodeModel.NamespaceEntity list = [
        ISOSurfaceHoverInfo
        ISOSurfaceContour
        ISOSurfaceSlicesXYZ
        ISOSurfaceSlices
        ISOSurfaceSpaceFrame
        ISOSurfaceSurfacePattern
        ISOSurfaceSurface
        ISOSurfaceOptions
    ]