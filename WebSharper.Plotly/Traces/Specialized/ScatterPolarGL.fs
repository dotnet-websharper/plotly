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

module ScatterPolarGLModule =

    open CommonModule

    let ScatterPolarGLModes =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["lines"; "markers"; "text"] '+')
            let seq2 = seq{"none"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ScatterPolarGLModes" generatedEnum

    let ScatterPolarGLHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["r"; "thetea"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ScatterPolarGLHoverInfo" generatedEnum

    let ScatterPolarGLMarkerLine =
        Pattern.Config "ScatterPolarGLMarkerLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
                "color", Color
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", ColorScale
                "autocolorscale", T<bool>
                "reversescale", T<bool>
                "coloraxis", T<string> // subplotid
            ]
        }

    let ScatterPolarGLMarker =
        Pattern.Config "ScatterPolarGLMarker" {
            Required = []
            Optional = [
                "symbol", Symbol.Type
                "opacity", T<float> + !| T<float>
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "sizeref", (T<float> + T<int>)
                "sizemin", (T<float> + T<int>)
                "sizemode", SizeMode.Type
                "line", ScatterPolarGLMarkerLine.Type
                "color", Color + !| Color
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", ColorScale
                "autocolorscale", T<bool>
                "reverscale", T<bool>
                "showscale", T<bool>
                "colorbar", ColorBar.Type
                "coloraxis", T<string> // subplotid
            ]
        }

    let ScatterPolarGLShape =
        Pattern.EnumStrings "ScatterPolarGLShape" [
            "linear"
            "hv"
            "vh"
            "hvh"
            "vhv"
        ]

    let ScatterPolarGLLineDash =
        Pattern.EnumStrings "ScatterPolarGLLineDash" [
            "solid"
            "dot"
            "dash"
            "longdash"
            "dashdot"
            "longdashdot"
        ]

    let ScatterPolarGLLine =
        Pattern.Config "ScatterPolarGLLine" {
            Required = []
            Optional = [
                "color", Color
                "width", (T<float> + T<int>)
                "shape", ScatterPolarGLShape.Type
                "dash", ScatterPolarGLLineDash.Type
            ]
        }    

    let ScatterPolarGLOptions =
        Class "ScatterPolarGLOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'scatterpolargl'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", T<float>
            "mode", ScatterPolarGLModes.Type
            "ids", !| T<string>
            "r", !| T<int> + !| T<float>
            "r0", (T<float> + T<int>) + T<string>
            "dr", (T<float> + T<int>)
            "theta", !| T<int> + !| T<float>
            "theta0", (T<float> + T<int>) + T<string>
            "dtheta", (T<float> + T<int>)
            "thetaunit", ThetaUnit.Type
            "text", T<string> + !| T<string>
            "textposition", TextPositionInline.Type
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", ScatterPolarGLHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "subplot", T<string> //type is 'subplotid'
            "marker", ScatterPolarGLMarker.Type
            "line", ScatterPolarGLLine.Type
            "textfont", Font.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", SelectedOption.Type
            "unselected", SelectedOption.Type // change name later
            "connectgaps", T<bool>
            "fill", Fill.Type
            "fillcolor", Color
            "hoverlabel", HoverLabel.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ScatterPolarGLTraceNamespaces : CodeModel.NamespaceEntity list = [
        ScatterPolarGLModes
        ScatterPolarGLHoverInfo
        ScatterPolarGLMarkerLine
        ScatterPolarGLMarker
        ScatterPolarGLShape
        ScatterPolarGLLineDash
        ScatterPolarGLLine
        ScatterPolarGLOptions
    ]