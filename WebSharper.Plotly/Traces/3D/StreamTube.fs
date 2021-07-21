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

module StreamTubeModule =

    open CommonModule

    // let StreamTubeHoverInfo =
    //     let generatedEnum =
    //         let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "u"; "v"; "w"; "norm"; "divergence"; "text"; "name"] '+')
    //         let seq2 = seq{"all"; "none"; "skip"}
    //         Seq.append seq1 seq2
    //     Pattern.EnumStrings "StreamTubeHoverInfo" generatedEnum

    let StreamTubeStarts =
        Pattern.Config "StreamTubeStarts" {
            Required = []
            Optional = [
                "x", !| T<int> + !| T<float> //data array
                "y", !| T<int> + !| T<float> //data array
                "z", !| T<int> + !| T<float> //data array
            ]
        }

    let StreamTubeOptions =
        Class "StreamTubeOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'streamtube'}"
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
            "u", !| T<int> + !| T<float> //data array
            "v", !| T<int> + !| T<float> //data array
            "w", !| T<int> + !| T<float> //data array
            "text", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", T<string> //StreamTubeHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "uhoverformat", T<string>
            "vhoverformat", T<string>
            "whoverformat", T<string>
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
            "hoverlabel", HoverLabel.Type
            "lighting", Lighting.Type
            "lightposition", LightPosition.Type
            "maxdisplayed", T<int>
            "sizeref", T<int> + T<float>
            "starts", StreamTubeStarts.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let StreamTubeTraceNamespaces : CodeModel.NamespaceEntity list = [
        //StreamTubeHoverInfo
        StreamTubeStarts
        StreamTubeOptions
    ]