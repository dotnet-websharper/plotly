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

module TableModule =

    open CommonModule

    let TableHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "TableHoverInfo" generatedEnum

    let TableAlign =
        Pattern.EnumStrings "TableAlign" [
            "left"
            "center"
            "right"
        ]

    let TableHoverLabel =
        Pattern.Config "TableHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", Color + !| Color
                "bordercolor", Color + !| Color
                "fonts", Font.Type
                "align", TableAlign.Type
                "namelength", T<int>
            ]
        }

    let TableDomain =
        Pattern.Config "TableDomain" {
            Required = []
            Optional = [
                "x", !| T<float> + !| T<int> + !| T<string>
                "y", !| T<int> + !| T<float> + !| T<string>
                "row", T<int>
                "column", T<int>
            ]
        }

    let TableLine =
        Pattern.Config "tableLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
                "color", Color + !| Color
            ]
        }

    let TableFill =
        Pattern.Config "TableFill" {
            Required = []
            Optional = [
                "color", Color + !| Color
            ]
        }

    let TableCells =
        Pattern.Config "TableCells" {
            Required = []
            Optional = [
                "values",  !| (!| T<float> + !| T<int> + !| T<string>)
                "format",  !| T<float> + !| T<int> + !| T<string>
                "prefix", T<string> + !| T<string>
                "suffix", T<string> + !| T<string>
                "height", (T<float> + T<int>)
                "align", TableAlign.Type
                "line", TableLine.Type
                "fill", TableFill.Type
                "font", Font.Type
            ]
        }

    let TableHeader = 
        Pattern.Config "TableHeader" {
            Required = []
            Optional = [
                "values",  !| (!| T<float> + !| T<int> + !| T<string>)
                "format",  !| T<float> + !| T<int> + !| T<string>
                "prefix", T<string> + !| T<string>
                "suffix", T<string> + !| T<string>
                "height", (T<float> + T<int>)
                "align", TableAlign.Type
                "line", TableLine.Type
                "fill", TableFill.Type
                "font", Font.Type
            ]
        }

    let TableOptions = 
        Class "TableOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'table'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "legendrank", T<float> + T<int>
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", (T<float> + T<int>)
            "ids", !| T<string> //data array
            "columnorder", !| T<string> + !| T<float> + !| T<int>
            "columnwidth", (T<float> + T<int>) + !| T<float> + !| T<int>
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
        TableHoverInfo
        TableHoverLabel
        TableDomain
        TableAlign
        TableLine
        TableFill
        TableCells
        TableHeader
        TableOptions
    ]
