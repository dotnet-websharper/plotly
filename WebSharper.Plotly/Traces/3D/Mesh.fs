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

module MeshModule =

    open CommonModule

    let MeshHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "MeshHoverInfo" generatedEnum

    let MeshLighting =
        Pattern.Config "MeshLighting" {
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
                "color", Color
                "width", T<int> + T<float>
            ]
        }

    let MeshOptions =
        Class "MeshOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'mesh3d'}"
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
            "i", !| T<int> + !| T<float> //data array
            "j", !| T<int> + !| T<float> //data array
            "k", !| T<int> + !| T<float> //data array
            "facecolor", Color
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
            "color", Color
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
            "alphahull", T<int> + T<float>
            "delaunayaxis", MeshDelanuayAxis.Type
            "contour", MeshContour.Type
            "flatshading", T<bool>
            "hoverlabel", HoverLabel.Type
            "lighting", MeshLighting.Type
            "lightposition", MeshLightPosition.Type
            "xcalendar", Calendar.Type
            "ycalendar", Calendar.Type
            "zcalendar", Calendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let MeshTraceNamespaces : CodeModel.NamespaceEntity list = [
        MeshHoverInfo
        MeshLighting
        MeshLightPosition
        MeshIntensityMode
        MeshDelanuayAxis
        MeshContour
        MeshOptions
    ]