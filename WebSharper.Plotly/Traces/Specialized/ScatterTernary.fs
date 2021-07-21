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

module ScatterTernaryModule =

    open CommonModule

    let ScatterTernaryModes =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["lines"; "markers"; "text"] '+')
            let seq2 = seq{"none"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ScatterTernaryModes" generatedEnum

    let ScatterTernaryHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["a"; "b"; "c"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ScatterTernaryHoverInfo" generatedEnum

    let ScatterTernaryMarkerLine =
        Pattern.Config "ScatterTernaryMarkerLine" {
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
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let ScatterTernaryMarker =
        Pattern.Config "ScatterTernaryMarker" {
            Required = []
            Optional = [
                "symbol", Symbol.Type
                "opacity", T<float> + !| T<float>
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "maxdisplayed", (T<float> + T<int>)
                "sizeref", (T<float> + T<int>)
                "sizemin", (T<float> + T<int>)
                "sizemode", SizeMode.Type
                "line", ScatterTernaryMarkerLine.Type
                "gradient", Gradient.Type
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
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let ScatterTernaryShape =
        Pattern.EnumStrings "ScatterTernaryShape" [
            "linear"
            "spline"
        ]

    let ScatterTernaryLine =
        Pattern.Config "ScatterTernaryLine" {
            Required = []
            Optional = [
                "color", Color
                "width", (T<float> + T<int>)
                "shape", ScatterTernaryShape.Type
                "smoothing", (T<float> + T<int>)
                "dash", T<string>
            ]
        }

    let ScatterTernaryFill =
        Pattern.EnumStrings "ScatterTernaryFill" [
            "none"
            "toself"
            "tonext"
        ]

    let ScatterTernaryHoverOn =
        let generatedEnum = GenerateOptions.allPermutations ["points"; "fills"] '+'
        Pattern.EnumStrings "ScatterTernaryHoverOn" generatedEnum

    let ScatterTernaryOptions =
        Class "ScatterTernaryOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'scatterternary'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", T<float>
            "mode", ScatterTernaryModes.Type
            "ids", !| T<string>
            "a", !| T<int> + !| T<float>
            "b", !| T<int> + !| T<float>
            "c", !| T<int> + !| T<float>
            "text", T<string> + !| T<string>
            "textposition", TextPositionInline.Type
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", ScatterTernaryHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "subplot", T<string> //type is 'subplotid'
            "marker", ScatterTernaryMarker.Type
            "line", ScatterTernaryLine.Type
            "textfont", Font.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", SelectedOption.Type
            "unselected", SelectedOption.Type // change name later
            "cliponaxis", T<bool>
            "connectgaps", T<bool>
            "fill", ScatterTernaryFill.Type
            "fillcolor", Color
            "hoverlabel", HoverLabel.Type
            "hoveron", ScatterTernaryHoverOn.Type
            "sum", T<int> + T<float>
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ScatterTernaryTraceNamespaces : CodeModel.NamespaceEntity list = [
        ScatterTernaryModes
        ScatterTernaryHoverInfo
        ScatterTernaryMarkerLine
        ScatterTernaryMarker
        ScatterTernaryShape
        ScatterTernaryLine
        ScatterTernaryFill
        ScatterTernaryHoverOn
        ScatterTernaryOptions
    ]