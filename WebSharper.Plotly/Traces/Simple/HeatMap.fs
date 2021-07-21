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

module HeatMapModule =

    open CommonModule

    let HMHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "HMHoverInfo" generatedEnum

    let HeatMapOptions = 
        Class "HeatMapOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'heatmap'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "showlegend", T<bool>
            "legendrank", T<float> + T<int>
            "legendgroup", T<string>
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", (T<float> + T<int>)
            "ids", !| T<string> //data array
            "x", !| T<float> + !| T<int> + !| T<string> //data array
            "x0", (T<float> + T<int>) + !| T<string>
            "dx", (T<float> + T<int>)
            "xtype", XYType.Type
            "xgap", (T<float> + T<int>)
            "y", !| T<float> + !| T<int> + !| T<string> + !| (!| T<float> + !| T<int> + !| T<string>) + !| (!| (!| T<float> + !| T<int> + !| T<string>))    //data array
            "y0", (T<float> + T<int>) + !| T<string>
            "dy", (T<float> + T<int>)
            "ytype", XYType.Type
            "ygap", (T<float> + T<int>)
            "z", !| T<float> + !| T<int> + !| T<string> //data array
            "text", !| T<string> //data array
            "hovertext", !| T<string> //data array
            "hoverinfo", HMHoverInfo.Type
            "hovertemplate", T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", !| T<string> //data array
            "xaxis", T<string> //subplotid
            "yaxis", T<string> //subplotid
            "coloraxis", T<string> //subplotid
            "xperiod", (T<float> + T<int>) + T<string>
            "xperiodalignment", PeriodAlignment.Type
            "xperiod0", (T<float> + T<int>) + T<string>
            "yperiod", (T<float> + T<int>) + T<string>
            "yperiodalignment", PeriodAlignment.Type
            "yperiod0", (T<float> + T<int>) + T<string>
            "colorbar", ColorBar.Type
            "autocolorscale", T<bool>
            "colorscale", ColorScale
            "showscale", T<bool>
            "reversescale", T<bool>
            "zauto", T<bool>
            "zhoverformat", T<string>
            "zmax", (T<float> + T<int>)
            "mid", (T<float> + T<int>)
            "min", (T<float> + T<int>)
            "zsmooth", ZSmooth.Type + T<bool>
            "connectgaps", T<bool>
            "hoverlabel", HoverLabel.Type
            "hoverongaps", T<bool>
            "transpose", T<bool>
            "xcalendar", Calendar.Type
            "ycalendar", Calendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let HeatMapTraceNamespaces : CodeModel.NamespaceEntity list = [
        HMHoverInfo
        HeatMapOptions
    ]
