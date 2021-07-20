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

module SankeyModule =

    let SankeyNullValue = Pattern.EnumInlines "SankeyNullValue" ["null", "null"]

    let SankeyColor = T<string> + (T<float> + T<int>) + (!| (!? (SankeyNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (SankeyNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let SankeyColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let SankeyVisibleString = Pattern.EnumStrings "SankeyVisibleString" ["legendonly"]

    let SankeyFont =
        Pattern.Config "SankeyFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", SankeyColor
            ]
        }

    let SankeyLegendGroupTitle =
        Pattern.Config "SankeyLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", SankeyFont.Type
            ]
        }

    let SankeyAlign =
        Pattern.EnumStrings "SankeyAlign" [
            "left"
            "right"
            "auto"
        ]

    let SankeyHoverLabel =
        Pattern.Config "SankeyHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", SankeyColor + !| SankeyColor
                "bordercolor", SankeyColor + !| SankeyColor
                "font", SankeyFont.Type
                "align", SankeyAlign.Type
                "namelength", T<int>
            ]
        }

    let SankeyDomain =
        Pattern.Config "SankeyDomain" {
            Required = []
            Optional = [
                "x", !| T<int> + !| T<float>
                "y", !| T<int> + !| T<float>
                "row", T<int>
                "column", T<int>
            ]
        }

    let SankeyHoverInfo =
        Pattern.EnumStrings "SankeyHoverInfo" [
            "none"
            "skip"
        ]

    let SankeyOrientation =
        Pattern.EnumStrings "SankeyOrientation" [
            "v"
            "h"
        ]

    let SankeyNodeLine =
        Pattern.Config "SankeyNodeLine" {
            Required = []
            Optional = [
                "color", SankeyColor + !| SankeyColor
                "width", T<int> + T<float> + !| T<int> + !| T<float>
            ]
        }

    let SankeyNodeHoverInfo =
        Pattern.EnumStrings "SankeyNodeHoverInfo" [
            "all"
            "none"
            "skip"
        ]

    let SankeyLinkColorScale =
        Pattern.Config "SankeyLinkColorScale" {
            Required = []
            Optional = [
                "label", T<string>
                "cmax", T<int> + T<float>
                "cmin", T<int> + T<float>
                "colorscale", SankeyColorScale
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let SankeyLink =
        Pattern.Config "SankeyLink" {
            Required = []
            Optional = [
                "label", !| T<string> + !| T<int> + !| T<float>
                "color", SankeyColor + !| SankeyColor
                "customdata", !| T<string> + !| T<int> + !| T<float>
                "line", SankeyNodeLine.Type
                "source", !| T<string> + !| T<int> + !| T<float>
                "target", !| T<string> + !| T<int> + !| T<float>
                "value", !| T<string> + !| T<int> + !| T<float>
                "hoverinfo", SankeyNodeHoverInfo.Type
                "hoverlabel", SankeyHoverLabel.Type
                "hovertemplate", T<string> + !| T<string>
                "colorscales", SankeyLinkColorScale.Type
            ]
        }

    let SankeyNode =
        Pattern.Config "SankeyNode" {
            Required = []
            Optional = [
                "label", !| T<string> + !| T<int> + !| T<float>
                "groups", !| T<string> + !| T<int> + !| T<float>
                "x", !| T<string> + !| T<int> + !| T<float>
                "y", !| T<string> + !| T<int> + !| T<float>
                "color", SankeyColor + !| SankeyColor
                "customdata", !| T<string> + !| T<int> + !| T<float>
                "line", SankeyNodeLine.Type
                "pad", T<int> + T<float>
                "thickness", T<int> + T<float>
                "hoverinfo", SankeyNodeHoverInfo.Type
                "hoverlabel", SankeyHoverLabel.Type
                "hovertemplate", T<string> + !| T<string>
            ]
        }

    let SankeyArrangement =
        Pattern.EnumStrings "SankeyArrangement" [
            "snap"
            "perpendicular"
            "freeform"
            "fixed"
        ]

    let SankeyOptions =
        Class "SankeyOptions"
        |=> Inherits CommonModule.Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'sankey'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + SankeyVisibleString.Type
            "legendrank", (T<float> + T<int>)
            "legendgrouptitle", SankeyLegendGroupTitle.Type
            "ids", !| T<string>
            "parents", !| T<string> + !| T<int> + !| T<float>
            "values", !| T<string> + !| T<int> + !| T<float>
            "labels", !| T<string> + !| T<int> + !| T<float>
            "text", T<string> + !| T<string>
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", SankeyHoverInfo.Type
            "meta", (T<float> + T<int>) + T<string>
            "customdata", !| T<string> + !| T<int> + !| T<float>
            "domain", SankeyDomain.Type
            "orientation", SankeyOrientation.Type
            "node", SankeyNode.Type
            "link", SankeyLink.Type
            "textfont", SankeyFont.Type
            "selectedpoints", T<int> + T<float> + T<string>
            "arrangement", SankeyArrangement.Type
            "hoverlabel", SankeyHoverLabel.Type
            "valueformat", T<string>
            "valuesuffix", T<string>
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let SankeyTraceNamespaces : CodeModel.NamespaceEntity list = [
        SankeyNullValue
        SankeyVisibleString
        SankeyFont
        SankeyLegendGroupTitle
        SankeyAlign
        SankeyHoverLabel
        SankeyDomain
        SankeyHoverInfo
        SankeyOrientation
        SankeyNodeLine
        SankeyNodeHoverInfo
        SankeyLinkColorScale
        SankeyLink
        SankeyNode
        SankeyArrangement
        SankeyOptions
    ]