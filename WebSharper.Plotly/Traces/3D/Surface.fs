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

module SurfaceModule =

    open CommonModule

    let SurfaceHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "SurfaceHoverInfo" generatedEnum

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
                "color", Color
                "usecolormap", T<bool>
                "width", T<int> + T<float>
                "highlight", T<bool>
                "highlightcolorr", Color
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
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'surface'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", T<float>
            "ids", !| T<string>
            "x", !| T<int> + !| T<float>
            "y", !| T<int> + !| T<float>
            "z", !| T<int> + !| T<float>
            "surfacecolor", Color
            "text", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", SurfaceHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type
            "scene", T<string> // subplotid
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
            "connectgaps", T<bool>
            "contours", SurfaceContours.Type
            "hidesurface", T<bool>
            "hoverlabel", HoverLabel.Type
            "lighting", SurfaceLighting.Type
            "lightposition", LightPosition.Type
            "opacityscale", T<int> + T<float> + T<string>
            "xcalendar", Calendar.Type
            "ycalendar", Calendar.Type
            "zcalendar", Calendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let SurfaceTraceNamespaces : CodeModel.NamespaceEntity list = [
        SurfaceHoverInfo
        SurfaceLighting
        SurfaceContoursProject
        SurfaceContoursXYZ
        SurfaceContours
        SurfaceOptions
    ]