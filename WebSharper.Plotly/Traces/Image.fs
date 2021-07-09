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

module ImageModule =

    let ImgNullValue = Pattern.EnumInlines "NullValue" ["null", "null"]

    let ImgColor = T<string> + (T<int> + T<string>) + (!| (!? (ImgNullValue.Type + T<string> + (T<int> + T<string>)))) + (!| (!| ((!? (ImgNullValue.Type + T<string> + (T<int> + T<string>)))))) 

    let ImgFont =
        Pattern.Config "ImgFont" {
            Required = []
            Optional = [
                "family", T<string> + !| T<string>
                "size", (T<int> + T<string>) + !| T<int> + !| T<string>
                "color", ImgColor + !| ImgColor
            ]
        }

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
                "font", ImgFont.Type
                "position", ImgTitlePosition.Type
            ]
        }

    let ImgVisibleString = Pattern.EnumStrings "ImgVisibleString" ["legendonly"]

    let ImgLegendGroupTitle =
        Pattern.Config "ImgLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ImgFont.Type
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
        
    let ImgAlign =
        Pattern.EnumStrings "ImgAlign" [
            "left"
            "right"
            "auto"
        ]

    let ImgHoverLabel =
        Pattern.Config "ImgHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", ImgColor + !| ImgColor
                "bordercolor", ImgColor + !| ImgColor
                "fonts", ImgFont.Type
                "align", ImgAlign.Type
                "namelength", T<int>
            ]
        }

    let ImageOptions =
        Class "ImageOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'image'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + ImgVisibleString.Type
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", ImgLegendGroupTitle.Type
            "opacity", (T<int> + T<string>)
            "ids", !| T<string> //data array
            "x0", (T<int> + T<string>) + T<string>
            "dx", (T<int> + T<string>)
            "y0", (T<int> + T<string>) + T<string>
            "dy", (T<int> + T<string>)
            "z", (T<int> + T<string>) + T<string>
            "source", T<string>
            "text", (T<int> + T<string>) + T<string>
            "hovertext", (T<int> + T<string>) + T<string>
            "hoverinfo", ImgHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "meta", (T<int> + T<string>) + T<string>
            "customdata", !| T<int> + !| T<string> + !| T<string> //data array
            "xaxis", T<string> // type: subplotid
            "yaxis", T<string> // type: subplotid
            "colormodel", ImgColorModel.Type
            "zmax", !| T<int> + !| T<string> + !| T<string> //array
            "min", !| T<int> + !| T<string> + !| T<string> //array
            "zsmooth", ImgZSmooth.Type + T<bool>
            "hoverlabel", ImgHoverLabel.Type
            "uirevision", (T<int> + T<string>) + T<string>
        ]

    let ImageTraceNamespaces : CodeModel.NamespaceEntity list = [
        ImgNullValue
        ImgFont
        ImgTitlePosition
        ImgTitle
        ImgVisibleString
        ImgLegendGroupTitle
        ImgHoverInfo
        ImgColorModel
        ImgZSmooth
        ImgAlign
        ImgHoverLabel
        ImageOptions
    ]