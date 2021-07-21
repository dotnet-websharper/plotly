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

module ParCatsModule =

    open CommonModule

    let ParCatsDimensionCatOrd =
        Pattern.EnumInlines "ParCatsDimensionCatOrd" [
            "trace", "'trace'"
            "categoryAscending", "'category ascending'"
            "categoryDescending", "'category descending'"
            "array", "'array'"
        ]

    let ParCatsDimensions =
        Pattern.Config "ParCatsDimensions" {
            Required = []
            Optional = [
                "displayindex", T<int>
                "categoryorder", ParCatsDimensionCatOrd.Type
                "categoryarray", !| T<string> + !| T<int> + !| T<float>
                "ticktext", !| T<string> + !| T<int> + !| T<float>
                "visible", T<bool>
                "label", T<string>
                "values", !| T<string> + !| T<int> + !| T<float>
            ]
        }

    let ParCatsLineShape =
        Pattern.EnumStrings "ParCatsLineShape" [
            "linear"
            "hspline"
        ]

    let ParCatsLine =
        Pattern.Config "ParCatsLine" {
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
                "shape", ParCatsLineShape.Type
                "hovertemplate", T<string>
            ]
        }

    let ParCatsDomain =
        Pattern.Config "ParCatsDomain" {
            Required = []
            Optional = [
                "x", !| T<int> + !| T<float>
                "y", !| T<int> + !| T<float>
                "row", T<int>
                "column", T<int>
            ]
        }

    let ParCatsHoverInfo =
        Pattern.EnumStrings "ParCatsHoverInfo" [
            "count"
            "probability"
            "count+probability"
            "probability+count"
            "all"
            "none"
            "skip"
        ]

    let ParCatsArrangement =
        Pattern.EnumStrings "ParCatsArrangement" [
            "perpendicular"
            "freeform"
            "fixed"
        ]

    let ParCatsSortPath =
        Pattern.EnumStrings "ParCatsSortPath" [
            "forward"
            "backfard"
        ]

    let ParCatsHoveron =
        Pattern.EnumStrings "ParCatsHoveron" [
            "category"
            "color"
            "dimension"
        ]

    let ParCatsOptions =
        Class "ParCatsOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'parcats'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "legendgrouptitle", LegendGroupTitle.Type
            "counts", T<int> + T<float> + !| T<int> + !| T<float>
            "dimensions", !| ParCatsDimensions.Type
            "hoverinfo", ParCatsHoverInfo.Type
            "hovertemplate", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "domain", ParCatsDomain.Type
            "line", ParCatsLine.Type
            "arrangement", ParCatsArrangement.Type
            "bundlecolors", T<bool>
            "sortpaths", ParCatsSortPath.Type
            "hoveron", ParCatsHoveron.Type
            "labelfont", Font.Type
            "tickfont", Font.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let ParCatsTraceNamespaces : CodeModel.NamespaceEntity list = [
        ParCatsDimensionCatOrd
        ParCatsDimensions
        ParCatsLineShape
        ParCatsLine
        ParCatsDomain
        ParCatsHoverInfo
        ParCatsArrangement
        ParCatsSortPath
        ParCatsHoveron
        ParCatsOptions
    ]