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

module ParCoordsModule =

    open CommonModule

    let ParCoordsDimensions =
        Pattern.Config "ParCoordsDimensions" {
            Required = []
            Optional = [
                "tickvals", !| T<string> + !| T<int> + !| T<float>
                "ticktext", !| T<string> + !| T<int> + !| T<float>
                "tickformat", T<string>
                "visible", T<bool>
                "label", T<string>
                "range", !| T<string> + !| T<int> + !| T<float>
                "constraintrange", !| T<string> + !| T<int> + !| T<float>
                "multiselect", T<bool>
                "values", !| T<string> + !| T<int> + !| T<float>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let ParCoordsLine =
        Pattern.Config "ParCoordsLine" {
            Required = []
            Optional = [
                "color", Color + !| Color //data array
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

    let ParCoordsLabelSide =
        Pattern.EnumStrings "ParCoordsLabelSide" [
            "top"
            "bottom"
        ]

    let ParCoordsOptions =
        Class "ParCoordsOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'parcoords'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "legendrank", (T<float> + T<int>)
            "legendgrouptitle", LegendGroupTitle.Type
            "ids", !| T<string>
            "dimensions", !| ParCoordsDimensions.Type
            "meta", (T<float> + T<int>) + T<string>
            "customdata", !| T<string> + !| T<int> + !| T<float>
            "domain", Domain.Type
            "line", ParCoordsLine.Type
            "labelangle", T<int> + T<float>
            "labelfont", Font.Type
            "labelside", ParCoordsLabelSide.Type
            "rangefont", Font.Type
            "tickfont", Font.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ParCoordsTraceNamespaces : CodeModel.NamespaceEntity list = [
        ParCoordsDimensions
        ParCoordsLine
        ParCoordsLabelSide
        ParCoordsOptions
    ]