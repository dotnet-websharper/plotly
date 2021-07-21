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

module HG2DContModule =

    open CommonModule

    let HG2DContHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "HG2DContHoverInfo" generatedEnum

    let HG2DContMarker =
        Pattern.Config "HG2DContMarker" {
            Required = []
            Optional = [
                "color", Color + !| Color //data array
            ]
        }  

    let HG2DContHistNorm =
        Pattern.EnumInlines "HG2DContHistNorm" [
            "empty", "''"
            "percent", "'percent'"
            "probability", "'probability'"
            "density", "'density'"
            "probabilityDensity", "'probability density'"
        ]

    let HG2DContXYBins =
        Pattern.Config "HG2DContXYBins" {
            Required = []
            Optional = [
                "start", T<int> + T<float> + T<string>
                "end", T<int> + T<float> + T<string>
                "size", T<int> + T<float> + T<string>
            ]
        }

    let HG2DContLine =
        Pattern.Config "HG2DContLine" {
            Required = []
            Optional = [
                "color", Color
                "width", T<int> + T<float>
                "dash", T<string>
                "smoothing", T<int> + T<float>
            ]
        }

    let HG2DContContoursType =
        Pattern.EnumStrings "HG2DContContoursType" [
            "levels"
            "constraint"
        ]

    let HG2DContContoursColoring =
        Pattern.EnumStrings "HG2DContContoursColoring" [
            "fill"
            "heatmap"
            "lines"
            "none"
        ]

    let HG2DContOperation =
        Pattern.EnumInlines "HG2DContOperation" [
            "equal", "'='"
            "less", "'<'"
            "greater", "'>'"
            "greaterEqual", "'>='"
            "lessEqual", "'<='"
            "square", "'[]'"
            "bracket", "'()'"
            "squareBracket", "'[)'"
            "bracketSquare", "'(]'"
            "reverseSquare", "']['"
            "reverseBracket", "')('"
            "reverseSquareBracket", "']('"
            "reverseBracketSquare", "')['"
        ]

    let HG2DContContours =
        Pattern.Config "HG2DContContours" {
            Required = []
            Optional = [
                "type", HG2DContContoursType.Type
                "start", T<int> + T<float>
                "end", T<int> + T<float>
                "size", T<int> + T<float>
                "coloring", HG2DContContoursColoring.Type
                "showlines", T<bool>
                "showlabels", T<bool>
                "labelfont", Font.Type
                "labelformat", T<string>
                "operation", HG2DContOperation.Type
                "value", T<int> + T<float> + T<string>
            ]
        }

    let HG2DContOptions =
        Class "HG2DContOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'histogram2dcontour'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", T<float>
            "ids", !| T<string>
            "x", !| T<int> + !| T<float>
            "y", !| T<int> + !| T<float>
            "z", !| T<int> + !| T<float> + !| T<string>
            "hoverinfo", HG2DContHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "xaxis", T<string> //type is 'subplotid'
            "yaxis", T<string> //type is 'subplotid'
            "coloraxis", T<string> //type is 'subplotid'
            "histfunc", HistFunc.Type
            "histnorm", HG2DContHistNorm.Type
            "nbinsx", T<int>
            "ybinsx", T<int>
            "autobinx", T<bool>
            "autobiny", T<bool>
            "bingroup", T<string>
            "xbingroup", T<string>
            "xbins", HG2DContXYBins.Type
            "ybingroup", T<string>
            "ybins", HG2DContXYBins.Type
            "marker", HG2DContMarker.Type
            "line", HG2DContLine.Type
            "colorbar", ColorBar.Type
            "autocolorscale", T<bool>
            "colorscale", ColorScale
            "showscale", T<bool>
            "reversescale", T<bool>
            "zauto", T<bool>
            "zhoverformat", T<string>
            "zmax", T<int> + T<float>
            "zmid", T<int> + T<float>
            "zmin", T<int> + T<float>
            "autocontour", T<bool>
            "contours", HG2DContContours.Type
            "hoverlabel",HoverLabel.Type
            "ncontours", T<int>
            "xcalendar", Calendar.Type
            "ycalendar", Calendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let HG2DContTraceNamespaces : CodeModel.NamespaceEntity list = [       
        HG2DContHoverInfo
        HG2DContMarker
        HG2DContHistNorm
        HG2DContXYBins
        HG2DContLine
        HG2DContContoursType
        HG2DContContoursColoring
        HG2DContOperation
        HG2DContContours
        HG2DContOptions
    ]