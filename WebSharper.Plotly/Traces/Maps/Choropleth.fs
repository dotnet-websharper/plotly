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

module ChoroplethModule =

    open CommonModule

    let ChoroplethHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["location"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ChoroplethHoverInfo" generatedEnum

    let ChoroplethMarkerLine =
        Pattern.Config "ChoroplethMarkerLine" {
            Required = []
            Optional = [
                "color", Color
                "width", T<int> + T<float>
            ]
        }

    let ChoroplethMarker =
        Pattern.Config "ChoroplethMarker" {
            Required = []
            Optional = [
                "line", ChoroplethMarkerLine.Type
                "opacity", T<float>
            ]
        }

    let ChoroplethSelectedMarker =
        Pattern.Config "ChoroplethSelectedMarker" {
            Required = []
            Optional = [
                "opacity", T<float>
            ]
        }

    let ChoroplethSelectedOption =
        Pattern.Config "ChoroplethSelectedOption" {
            Required = []
            Optional = [
                "marker", ChoroplethSelectedMarker.Type
            ]
        }

    let ChoroplethAlign =
        Pattern.EnumStrings "ChoroplethAlign" [
            "left"
            "right"
            "auto"
        ]

    let ChoroplethHoverLabel =
        Pattern.Config "ChoroplethHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", Color + !| Color
                "bordercolor", Color + !| Color
                "font", Font.Type
                "align", ChoroplethAlign.Type
                "namelength", T<int>
            ]
        }

    let ChoroplethOptions =
        Class "ChoroplethOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'choropleth'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", LegendGroupTitle.Type
            "ids", !| T<string>
            "z", !| T<int> + !| T<float> + !| T<string> //data array
            "geojson", T<int> + T<float> + T<string>
            "featureidkey", T<string>
            "locations", !| T<int> + !| T<float> + !| T<string>
            "text", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", ChoroplethHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "geo", T<string> //subplotid
            "coloraxis", T<string> //subplotid
            "marker", ChoroplethMarker.Type
            "colorbar", ColorBar.Type
            "autocolorscale", T<bool>
            "colorscale", ColorScale
            "showscale", T<bool>
            "reversescale", T<bool>
            "zauto", T<bool>
            "zmax", T<int> + T<float>
            "zmid", T<int> + T<float>
            "zmin", T<int> + T<float>
            "selectedpoints", (T<float> + T<int>) + T<string>
            "selected", ChoroplethSelectedOption.Type
            "unselected", ChoroplethSelectedOption.Type // change name later
            "hoverlabel", ChoroplethHoverLabel.Type
            "locationmode", LocationMode.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ChoroplethTraceNamespaces : CodeModel.NamespaceEntity list = [
        ChoroplethHoverInfo
        ChoroplethMarkerLine
        ChoroplethMarker
        ChoroplethSelectedMarker
        ChoroplethSelectedOption
        ChoroplethAlign
        ChoroplethHoverLabel
        ChoroplethOptions
    ]