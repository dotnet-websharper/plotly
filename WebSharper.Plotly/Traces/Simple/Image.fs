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

module ImageModule =

    open CommonModule

    let ImgTitlePosition =
        Pattern.EnumInlines "ImgTitlePosition" [
            "topLeft", "'top left'"
            "topCenter", "'top center'"
            "topRight", "'top right'"
            "middleCenter", "'middle center'"
            "bottomLeft", "'bottom left'"
            "bottomCenter", "'bottom center'"
            "bottomRight", "'bottom right'"
        ]

    let ImgTitle =
        Pattern.Config "ImgTitle" {
            Required= []
            Optional = [
                "text", T<string>
                "font", Font.Type
                "position", ImgTitlePosition.Type
            ]
        }

    let ImgHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "color"; "name"; "text"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ImgHoverInfo" generatedEnum

    let ImgColorModel =
        Pattern.EnumStrings "ImgColorModel" [
            "rgb"
            "rgba"
            "rgba256"
            "hsl"
            "hsla"
        ]

    let ImgZSmooth =
        Pattern.EnumStrings "ImgZSmooth" ["fast"]

    let ImageOptions =
        Class "ImageOptions"
        |=> Inherits Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'image'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + VisibleString.Type
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", LegendGroupTitle.Type
            "opacity", (T<int> + T<float>)
            "ids", !| T<string> //data array
            "x0", (T<int> + T<float>) + T<string>
            "dx", (T<int> + T<float>)
            "y0", (T<int> + T<float>) + T<string>
            "dy", (T<int> + T<float>)
            "z", (T<int> + T<float>) + T<string>
            "source", T<string>
            "text", (T<int> + T<float>) + T<string>
            "hovertext", (T<int> + T<float>) + T<string>
            "hoverinfo", ImgHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "meta", (T<int> + T<float>) + T<string>
            "customdata", !| T<int> + !| T<float> + !| T<string> //data array
            "xaxis", T<string> // subplotid
            "yaxis", T<string> // subplotid
            "colormodel", ImgColorModel.Type
            "zmax", !| T<int> + !| T<float> + !| T<string> //array
            "min", !| T<int> + !| T<float> + !| T<string> //array
            "zsmooth", ImgZSmooth.Type + T<bool>
            "hoverlabel", HoverLabel.Type
            "uirevision", (T<int> + T<float>) + T<string>
        ]

    let ImageTraceNamespaces : CodeModel.NamespaceEntity list = [
        ImgTitlePosition
        ImgTitle
        ImgHoverInfo
        ImgColorModel
        ImgZSmooth
        ImageOptions
    ]