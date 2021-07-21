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

module ScatterMBModule =

    open CommonModule

    let ScatterMBModes =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["lines"; "markers"; "text"] '+')
            let seq2 = seq{"none"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ScatterMBModes" generatedEnum

    let ScatterMBHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["lon"; "lat"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ScatterMBHoverInfo" generatedEnum

    let ScatterMBMarker =
        Pattern.Config "ScatterMBMarker" {
            Required = []
            Optional = [
                "symbol", T<string> + !| T<string>
                "angle", T<int> + T<float> + !| T<int> + !| T<float>
                "allowoverleap", T<bool>
                "opacity", T<float> + !| T<float>
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "sizeref", (T<float> + T<int>)
                "sizemin", (T<float> + T<int>)
                "sizemode", SizeMode.Type
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

    let ScatterMBLine =
        Pattern.Config "ScatterMBLine" {
            Required = []
            Optional = [
                "color", Color
                "width", (T<float> + T<int>)
            ]
        }

    let ScatterMBSelectedOption =
        Pattern.Config "ScatterMBSelectedOption" {
            Required = []
            Optional = [
                "marker", SelectedMarker.Type
            ]
        }

    let ScatterMBOptions =
        Class "ScatterMBOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'scattermapbox'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", T<float>
            "mode", ScatterMBModes.Type
            "ids", !| T<string>
            "lat", !| T<int> + !| T<float> + !| T<string>
            "lon", !| T<int> + !| T<float> + !| T<string>
            "text", T<string> + !| T<string>
            "textposition", TextPositionInline.Type
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", ScatterMBHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "subplot", T<string> //subplotid
            "marker", ScatterMBMarker.Type
            "line", ScatterMBLine.Type
            "textfont", Font.Type
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", ScatterMBSelectedOption.Type
            "unselected", ScatterMBSelectedOption.Type // change name later
            "below", T<string>
            "connectgaps", T<bool>
            "fill", Fill.Type
            "fillcolor", Color
            "hoverlabel", HoverLabel.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ScatterMBTraceNamespaces : CodeModel.NamespaceEntity list = [
        ScatterMBModes
        ScatterMBHoverInfo
        ScatterMBMarker
        ScatterMBLine
        ScatterMBSelectedOption
        ScatterMBOptions
    ]