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

module ChoroplethMBModule =

    open CommonModule

    let ChoroplethMBHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["location"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ChoroplethMBHoverInfo" generatedEnum

    let ChoroplethMBColorBarMode =
        Pattern.EnumStrings "ChoroplethMBThicknessMode" [
            "fraction"
            "pixels"
        ]

    let ChoroplethMBMarkerLine =
        Pattern.Config "ChoroplethMBMarkerLine" {
            Required = []
            Optional = [
                "color", Color
                "width", T<int> + T<float>
            ]
        }

    let ChoroplethMBMarker =
        Pattern.Config "ChoroplethMBMarker" {
            Required = []
            Optional = [
                "line", ChoroplethMBMarkerLine.Type
                "opacity", T<float>
            ]
        }

    let ChoroplethMBSelectedMarker =
        Pattern.Config "ChoroplethMBSelectedMarker" {
            Required = []
            Optional = [
                "opacity", T<float>
            ]
        }

    let ChoroplethMBSelectedOption =
        Pattern.Config "ChoroplethMBSelectedOption" {
            Required = []
            Optional = [
                "marker", ChoroplethMBSelectedMarker.Type
            ]
        }

    let ChoroplethMBAlign =
        Pattern.EnumStrings "ChoroplethMBAlign" [
            "left"
            "right"
            "auto"
        ]

    let ChoroplethMBHoverLabel =
        Pattern.Config "ChoroplethMBHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", Color + !| Color
                "bordercolor", Color + !| Color
                "font", Font.Type
                "align", ChoroplethMBAlign.Type
                "namelength", T<int>
            ]
        }

    let ChoroplethMBLocationMode =
        Pattern.EnumInlines "ChoroplethMBLocationMode" [
            "ISO-3", "'ISO-3'"
            "USA-states", "'USA-states'"
            "countryNames", "'country names'"
            "geojson-id", "'geojson-id'"
        ]

    let ChoroplethMBOptions =
        Class "ChoroplethMBOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'choroplethmapbox'}"
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
            "hoverinfo", ChoroplethMBHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "subplot", T<string> //subplotid
            "coloraxis", T<string> //subplotid
            "marker", ChoroplethMBMarker.Type
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
            "selected", ChoroplethMBSelectedOption.Type
            "unselected", ChoroplethMBSelectedOption.Type // change name later
            "below", T<string>
            "hoverlabel", ChoroplethMBHoverLabel.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ChoroplethMBTraceNamespaces : CodeModel.NamespaceEntity list = [
        ChoroplethMBHoverInfo
        ChoroplethMBColorBarMode
        ChoroplethMBMarkerLine
        ChoroplethMBMarker
        ChoroplethMBSelectedMarker
        ChoroplethMBSelectedOption
        ChoroplethMBAlign
        ChoroplethMBHoverLabel
        ChoroplethMBLocationMode
        ChoroplethMBOptions
    ]