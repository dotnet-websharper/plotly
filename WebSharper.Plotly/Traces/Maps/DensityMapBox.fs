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

module DensityMBModule =

    open CommonModule

    let DensityMBHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["lon"; "lat"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "DensityMBHoverInfo" generatedEnum

    let DensityMBOptions =
        Class "DensityMBOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'densitymapbox'}"
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
            "z", !| T<int> + !| T<float> + !| T<string> //data array
            "radius", T<int> + !| T<int>
            "lat", !| T<int> + !| T<float> + !| T<string> //data array
            "lon", !| T<int> + !| T<float> + !| T<string> //data array
            "text", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", DensityMBHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "subplot", T<string> //subplotid
            "coloraxis", T<string> //subplotid
            "colorbar", ColorBar.Type
            "autocolorscale", T<bool>
            "colorscale", ColorScale
            "showscale", T<bool>
            "reversescale", T<bool>
            "zauto", T<bool>
            "zmax", T<int> + T<float>
            "zmid", T<int> + T<float>
            "zmin", T<int> + T<float>
            "below", T<string>
            "hoverlabel", HoverLabel.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let DensityMBTraceNamespaces : CodeModel.NamespaceEntity list = [
        DensityMBHoverInfo
        DensityMBOptions
    ]