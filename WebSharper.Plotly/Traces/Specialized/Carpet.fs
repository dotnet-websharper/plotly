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

module CarpetModule =

    open CommonModule

    let CarpetAxisTitle =
        Pattern.Config "CarpetAxisTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", Font.Type
                "offset", T<int> + T<float>
            ]
        }

    let CarpetAxisType =
        Pattern.EnumInlines "CarpetAxisType" [
            "line", "'-'"
            "linear", "'linear'"
            "date", "'date'"
            "category", "'category'"
        ]


    let CarpetAxisATN =
        Pattern.EnumInlines "CarpetAxisATN" [
            "convertTypes", "'convert types'"
            "strict", "'strict'"
        ]

    let CarpetAxisAR =
        Pattern.EnumStrings "CarpetAxisAR" [
            "reversed"
        ]

    let CarpetAxisRM =
        Pattern.EnumStrings "CarpetAxisRM" [
            "normal"
            "tozero"
            "nonnegative"
        ]

    let CarpetAxisCT =
        Pattern.EnumStrings "CarpetAxisCT" [
            "index"
            "value"
        ]

    let CarpetAxisCO =
        Pattern.EnumInlines "CarpetAxisCO" [
            "trace", "'trace'"
            "categoryAscending", "'category ascending'"
            "categoryDescending", "'category descending'"
            "array", "'array'"
        ]

    let CarpetAxis =
        Pattern.Config "CarpetAxis" {
            Required = []
            Optional = [
                "color", Color
                "smoothing", T<float> + T<int>
                "title", CarpetAxisTitle.Type
                "type", CarpetAxisType.Type
                "autotypenumbers", CarpetAxisATN.Type
                "autorange", T<bool> + CarpetAxisAR.Type
                "rangemode", CarpetAxisRM.Type
                "range", !| T<int> + !| T<float> + !| T<string>
                "fixedrange", T<bool>
                "cheatertype", CarpetAxisCT.Type
                "tickmode", TickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>)
                "dtick", (T<float> + T<int>)
                "arraytick0", T<int>
                "arraydtick", T<int>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "showticklabels", T<bool>
                "tickfont", Font.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", TickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", ShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", ShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", ExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowTickFix.Type
                "categoryorder", CarpetAxisCO.Type
                "categoryarray", !| T<int> + !| T<float> + !| T<string>
                "labelpadding", T<int>
                "labelprefix", T<string>
                "labelsuffix", T<string>
                "showline", T<bool>
                "linecolor", Color
                "linewidth", T<int> + T<float>
                "gridcolor", Color
                "gridwidth", T<int> + T<float>
                "showgrid", T<bool>
                "minorgridcount", T<int>
                "minorgridwidth", T<int> + T<float>
                "minorgridcolor", Color
                "startline", T<bool>
                "startlinecolor", Color
                "startlinewidth", T<int> + T<float>
                "endline", T<bool>
                "endlinewidth", T<int> + T<float>
                "endlinecolor", Color
            ]
        }

    let CarpetOptions =
        Class "CarpetOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'carpet'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "legendrank", T<int> + T<float>
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", T<float>
            "ids", !| T<int> + !| T<float> + !| T<string>
            "x", !| T<int> + !| T<float> + !| T<string>
            "y", !| T<int> + !| T<float> + !| T<string>
            "a", !| T<int> + !| T<float> + !| T<string>
            "a0", T<int> + T<float>
            "da", T<int> + T<float>
            "b", !| T<int> + !| T<float> + !| T<string>
            "b0", T<int> + T<float>
            "db", T<int> + T<float>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", !| T<int> + !| T<float> + !| T<string>
            "aaxis", CarpetAxis.Type
            "baxis", CarpetAxis.Type
            "xaxis", T<string> //subplotid
            "yaxis", T<string> //subplotid
            "color", Color
            "carpet", T<string>
            "cheaterslope", T<int> + T<float>
            "font", Font.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let CarpetTraceNamespaces : CodeModel.NamespaceEntity list = [
        CarpetAxisTitle
        CarpetAxisType
        CarpetAxisATN
        CarpetAxisAR
        CarpetAxisRM
        CarpetAxisCO
        CarpetAxis
        CarpetOptions
        CarpetAxisCT
    ]