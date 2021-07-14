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

module CarpetModule =

    let CarpetNullValue = Pattern.EnumInlines "CarpetNullValue" ["null", "null"]

    let CarpetColor = T<string> + (T<float> + T<int>) + (!| (!? (CarpetNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (CarpetNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let CarpetColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let CarpetVisibleString = Pattern.EnumStrings "CarpetVisibleString" ["legendonly"]

    let CarpetFont =
        Pattern.Config "CarpetFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", CarpetColor
            ]
        }

    let CarpetLegendGroupTitle =
        Pattern.Config "CarpetLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", CarpetFont.Type
            ]
        }

    let CarpetTickMode =
        Pattern.EnumStrings "CarpetTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let CarpetTickFormatStops =
        Pattern.Config "CarpetTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + CarpetNullValue.Type) * (DTickValue + CarpetNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let CarpetShowTickFix =
        Pattern.EnumStrings "CarpetShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = CarpetShowTickFix

    let CarpetExponentFormat =
        Pattern.EnumInlines "CarpetExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let CarpetAxisTitle =
        Pattern.Config "CarpetAxisTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", CarpetFont.Type
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

    let ParAxisCT =
        Pattern.EnumStrings "ParAxisCT" [
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
                "color", CarpetColor
                "smoothing", T<float> + T<int>
                "title", CarpetAxisTitle.Type
                "type", CarpetAxisType.Type
                "autotypenumbers", CarpetAxisATN.Type
                "autorange", T<bool> + CarpetAxisAR.Type
                "rangemode", CarpetAxisRM.type
                "range", !| T<int> + !| T<float> + !| T<string>
                "fixedrange", T<bool>
                "cheatertype", ParAxisCT.Type
                "tickmode", CarpetTickMode.Type//
                "nticks", T<int>//
                "tick0", (T<float> + T<int>)//
                "dtick", (T<float> + T<int>)//
                "arraytick0", T<int>//
                "arraydtick", T<int>//
                "tickvals", !| T<obj>//
                "ticktext", !| T<string> //
                "showticklabels", T<bool>//
                "tickfont", CarpetFont.Type//
                "tickangle", (T<float> + T<int>) //type: Angle//
                "tickformat", T<string>//
                "tickformatstops", CarpetTickFormatStops.Type//
                "tickprefix", T<string>//
                "showtickprefix", CarpetShowTickFix.Type//
                "ticksuffix", T<string>//
                "showticksuffix", CarpetShowTickFix.Type//
                "separatethousands", T<bool>//
                "exponentformat", CarpetExponentFormat.Type//
                "minexponent", (T<float> + T<int>)//
                "showexponent", ShowExponent.Type//
                "categoryorder", CarpetAxisCO.type
                "categoryarray", !| T<int> + !| T<float> + !| T<string>
                "labelpadding", T<int>
                "labelprefix", T<string>
                "labelsuffix", T<string>
                "showline", T<bool>
                "linecolor", CarpetColor
                "linewidth", T<int> + T<float>
                "gridcolor", CarpetColor
                "gridwidth", T<int> + T<float>
                "showgrid", T<bool>
                "minorgridcount", T<int>
                "minorgridwidth", T<int> + T<float>
                "minorgridcolor", CarpetColor
                "startline", T<bool>
                "startlinecolor", CarpetColor
                "startlinewidth", T<int> + T<float>
                "endline", T<bool>
                "endlinewidth", T<int> + T<float>
                "endlinecolor", CarpetColor
            ]
        }

    let CarpetOptions =
        Class "CarpetOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'carpet'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + CarpetVisibleString.Type
            "legendrank", T<int> + T<float>
            "legendgrouptitle", CarpetLegendGroupTitle.Type
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
            "color", CarpetColor
            "carpet", T<string>
            "cheaterslope", T<int> + T<float>
            "font", CarpetFont
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let CarpetTraceNamespaces : CodeModel.NamespaceEntity list = [
        CarpetNullValue
        CarpetVisibleString
        CarpetFont
        CarpetLegendGroupTitle
        CarpetTickMode
        CarpetTickFormatStops
        CarpetShowTickFix
        ShowExponent
        CarpetExponentFormat
        CarpetAxisTitle
        CarpetAxisType
        CarpetAxisATN
        CarpetAxisAR
        CarpetAxisRM
        voidptrv
        CarpetAxis
        CarpetOptions
    ]