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

module HeatMapModule =

    let TableNullValue = Pattern.EnumInlines "NullValue" ["null", "null"]

    let TableColor = T<string> + (T<float> + T<int>) + (!| (!? (TableNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (TableNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let TableColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let TableVisibleString = Pattern.EnumStrings "TableVisibleString" ["legendonly"]

    let TableFont =
        Pattern.Config "TableFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", TableColor
            ]
        }

    let TableLegendGroupTitle =
        Pattern.Config "TableLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", TableFont.Type
            ]
        }

    let TableHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "TableHoverInfo" generatedEnum

    let TableHoverLabel =
        Pattern.Config "TableHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", TableColor + !| TableColor
                "bordercolor", TableColor + !| TableColor
                "fonts", TableFont.Type
                "align", TableAlign.Type
                "namelength", T<int>
            ]
        }

    let TableDomain =
        Pattern.Config "TableDomain" {
            Required = []
            Optional = [
                "x", !| T<Number> + !| T<string>
                "y", !| T<int> + !| T<float> + !| T<string>
                "row", T<int>
                "column", T<int>
            ]
        }

    let TableAlign =
        Pattern.EnumStrings "TableAlign" [
            "left"
            "center"
            "right"
        ]

    let TableLine =
        Pattern.Config "tableLine" {
            Required = []
            Optional = [
                "width", T<Number> + !| T <Number>
                "color", TableColor + !| TableColor
            ]
        }

    let TableFill =
        Pattern.Config "TableFill" {
            Required = []
            Optional = [
                "color", TableColor + !| TableColor
            ]
        }

    let TableCells =
        Pattern.Config "TableCells" {
            Required = []
            Optional = [
                "values",  !| T<Number> + !| T<string>
                "format",  !| T<Number> + !| T<string>
                "prefix", T<string> + !| T<string>
                "suffix", T<string> + !| T<string>
                "height", T<Number>
                "align", TableAlign.Type
                "line", TableLine.Type
                "fill", TableFill.Type
                "font", TableFont.Type
            ]
        }

    let TableHeader = 
        Pattern.Config "TableHeader" {
            Required = []
            Optional = [
                "values",  !| T<Number> + !| T<string>
                "format",  !| T<Number> + !| T<string>
                "prefix", T<string> + !| T<string>
                "suffix", T<string> + !| T<string>
                "height", T<Number>
                "align", TableAlign.Type
                "line", TableLine.Type
                "fill", TableFill.Type
                "font", TableFont.Type
            ]
        }

    let TableOptions = 
        Class "TableOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'table'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + TableVisibleString.Type
            "legendrank", T<float> + T<int>
            "legendgrouptitle", TableLegendGroupTitle.Type
            "opacity", (T<float> + T<int>)
            "ids", !| T<string> //data array
            "columnorder", !| T<string> + !| T<Number>
            "columnwidth", T<number> + !| T<Number>
            "hoverinfo", TableHoverInfo.Type
            "meta", (T<float> + T<int>) + T<string>
            "customdata", !| T<string> //data array
            "domain", TableDomain.Type
            "cells", TableCells.Type
            "header", TableHeader.Type
            "hoverlabel", TableHoverLabel.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let TableTraceNamespaces : CodeModel.NamespaceEntity list = [
        TableNullValue
        TableVisibleString
        TableFont
        TableLegendGroupTitle
        TableHoverInfo
        TableHoverLabel
        TableDomain
        TableAlign
        TableFill
        TableLine
        TableFill
        TableCells
        TableHeader
        TableOptions
    ]
