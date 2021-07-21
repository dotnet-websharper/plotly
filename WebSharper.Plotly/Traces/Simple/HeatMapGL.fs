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

module HeatMapGLModule =

    open CommonModule

    let HMGLHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "HMGLHoverInfo" generatedEnum

    let HeatMapGLOptions = 
        Class "HeatMapGLOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'heatmapgl'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "legendrank", T<float> + T<int>
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", (T<float> + T<int>)
            "ids", !| T<string> //data array
            "x", !| T<float> + !| T<int> + !| T<string> //data array
            "x0", (T<float> + T<int>) + !| T<string>
            "dx", (T<float> + T<int>)
            "xtype", XYType.Type
            "y", !| T<float> + !| T<int> + !| T<string> + !| (!| T<float> + !| T<int> + !| T<string>) + !| (!| (!| T<float> + !| T<int> + !| T<string>))    //data array
            "y0", (T<float> + T<int>) + !| T<string>
            "dy", (T<float> + T<int>)
            "ytype", XYType.Type
            "z", !| T<float> + !| T<int> + !| T<string> //data array
            "text", !| T<string> //data array
            "hoverinfo", HMGLHoverInfo.Type
            "meta", (T<float> + T<int>) + T<string>
            "customdata", !| T<string> //data array
            "xaxis", T<string> //subplotid
            "yaxis", T<string> //subplotid
            "coloraxis", T<string> //subplotid
            "colorbar", ColorBar.Type
            "autocolorscale", T<bool>
            "colorscale", ColorScale
            "showscale", T<bool>
            "reversescale", T<bool>
            "zauto", T<bool>
            "zmax", (T<float> + T<int>)
            "mid", (T<float> + T<int>)
            "min", (T<float> + T<int>)
            "zsmooth", ZSmooth.Type + T<bool>
            "hoverlabel", HoverLabel.Type
            "transpose", T<bool>
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let HeatMapGLTraceNamespaces : CodeModel.NamespaceEntity list = [
        HMGLHoverInfo
        HeatMapGLOptions
    ]
