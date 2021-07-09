namespace WebSharper.Plotly.Extension.Layout

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
open WebSharper.InterfaceGenerator
open WebSharper.JavaScript
open WebSharper.Plotly.Extension.GenerateEnum

module LayoutModule =

    let LayoutNullValue = Pattern.EnumInlines "LayoutNullValue" ["null", "null"]

    let LayoutColor = T<string> + (T<float> + T<int>) + (!| (!? (LayoutNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (LayoutNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let LayoutFontConfig =
        Pattern.Config "LayoutFontConfig" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", LayoutColor
            ]
        }

    let Ref =
        Pattern.EnumStrings "Ref" [
            "container"
            "paper"
        ]

    let LayoutXAnchor =
        Pattern.EnumStrings "LayoutXAnchor" [
            "auto"
            "left"
            "center"
            "right"
        ]

    let LayoutYAnchor =
        Pattern.EnumStrings "LayoutYAnchor" [
            "auto"
            "top"
            "middle"
            "bottom"
        ]

    let LayoutPadding =
        Pattern.Config "LayoutPadding" {
            Required = []
            Optional = [
                "t", T<Number>
                "r", T<Number>
                "b", T<Number>
                "l", T<Number>
            ]
        }

    let LayoutTitle =
        Pattern.Config "LayoutTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", LayoutFontConfig.Type
                "xref", Ref.Type
                "yref", Ref.Type
                "x", T<float>
                "y", T<float>
                "xanchor", LayoutXAnchor.Type
                "yanchor", LayoutYAnchor.Type
                "pad", LayoutPadding.Type
            ]
        }

    let LAyoutOrientation =
        Pattern.EnumStrings "LayoutOrientation" [
            "v"
            "h"
        ]

    let LayoutTraceOrder =
        let generatedEnum =
            let seq1 = GenerateOptions.allPermutations ["reversed"; "grouped"] '+'
            let seq2 = seq{"normal"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "LayoutTraceOrder" generatedEnum

    let LayoutItemSizing =
        Pattern.EnumStrings "LayoutItemSizing" [
            "trace"
            "constant"
        ]

    let LayoutItemClick =
        Pattern.EnumInlines "LayoutItemClick" [
            "toggle", "'toggle'"
            "toggleothers", "'toggleothers'"
            "false", "false"
        ]

    let LayoutVAlign =
        Pattern.EnumStrings "LayoutVAlign" [
            "top"
            "middle"
            "bottom"
        ]

    let LayoutLegendTitle =
        Pattern.Config "LayoutLegendTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", LayoutFontConfig.Type
            ]
        }

    let LayoutLegendSide =
        Pattern.EnumInlines "LayoutLegendSide" [
            "top", "'top'"
            "left", "'left'"
            "topLeft", "'top left'"
        ]

    let LayoutLegend =
        Pattern.Config "LayoutLegend" {
            Required = []
            Optional = [
                "bgcolor", LayoutColor
                "bordercolor", LayoutColor
                "borderwidth", T<int>
                "font", LayoutFontConfig.Type
                "orientation", LAyoutOrientation.Type
                "traceorder", LayoutTraceOrder.Type
                "tracegroupgap", T<int>
                "itemsizing", LayoutItemSizing.Type
                "itemwidth", T<int>
                "itemclick", LayoutItemClick.Type
                "itemdoubleclick", LayoutItemClick.Type
                "x", T<Number>
                "xanchor", LayoutXAnchor.Type
                "y", T<Number>
                "yanchor", LayoutYAnchor.Type
                "uirevision", T<Number> + T<string>
                "valign", LayoutVAlign.Type
                "title", LayoutLegendTitle.Type
                "side", LayoutLegendSide.Type
            ]
        }

    let LayoutAutoTypeNumbers =
        Pattern.EnumInlines "LayoutAutoTypeNumbers" [
            "convertTypes", "'convert types'"
            "strict", "'strict'"
        ]

    let LayoutHoverMode =
        Pattern.EnumInlines "LayoutHoverMode" [
            "x", "'x'"
            "y", "'y'"
            "closest", "'closest'"
            "false", "false"
            "xUnified", "'x unified'"
            "yUnified", "'y unified'"
        ]

    let LayoutClickMode =
        let generatedEnum =
            let seq1 = GenerateOptions.allPermutations ["event"; "select"] '+'
            let seq2 = seq{"none"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "LayoutClickMode" generatedEnum

    let LayoutDragMode =
        Pattern.EnumInlines "LayoutDragMode" [
            "zoom", "'zoom'"
            "pan", "'pan'"
            "select", "'select'"
            "lasso", "'lasso'"
            "drawclosedpath", "'drawclosedpath'"
            "drawopenpath", "'drawopenpath'"
            "drawline", "'drawline'"
            "drawrect", "'drawrect'"
            "drawcircle", "'drawcircle'"
            "orbit", "'orbit'"
            "turntable", "'turntable'"
            "false", "false"
        ]

    let LayoutSelectDirection =
        Pattern.EnumStrings "LayoutSelectDirection" [
            "h"
            "v"
            "d"
            "any"
        ]

    let LayoutAlign =
        Pattern.EnumStrings "LayoutAlign" [
            "left"
            "right"
            "auto"
        ]

    let LayoutHoverLabel =
        Pattern.Config "LayoutHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", LayoutColor + !| LayoutColor // ?
                "bordercolor", LayoutColor + !| LayoutColor // ?
                "fonts", LayoutFontConfig.Type
                "align", LayoutAlign.Type
                "namelength", T<int>
            ]
        }

    let LayoutEasing =
        Pattern.EnumStrings "LayoutEasing" [
            "linear"
            "quad"
            "cubic"
            "sin"
            "exp"
            "circle"
            "elastic"
            "back"
            "bounce"
            "linear-in"
            "quad-in"
            "cubic-in"
            "sin-in"
            "exp-in"
            "circle-in"
            "elastic-in"
            "back-in"
            "bounce-in"
            "linear-out"
            "quad-out"
            "cubic-out"
            "sin-out"
            "exp-out"
            "circle-out"
            "elastic-out"
            "back-out"
            "bounce-out"
            "linear-in-out"
            "quad-in-out"
            "cubic-in-out"
            "sin-in-out"
            "exp-in-out"
            "circle-in-out"
            "elastic-in-out"
            "back-in-out"
            "bounce-in-out"
        ]

    let LayoutOrdering =
        Pattern.EnumInlines "LayoutOrdering" [
            "layoutFirst", "'layout first'"
            "tracesFirst", "'traces first'"
        ]

    let LayoutTransition =
        Pattern.Config "LayoutTransition" {
            Required = []
            Optional = [
                "duration", T<Number>
                "easing", LayoutEasing.Type
                "ordering", LayoutOrdering.Type
            ]
        }

    let LayoutCalendar =
        Pattern.EnumStrings "LayoutCalendar" [
            "gregorian"
            "chinese"
            "coptic"
            "discworld"
            "ethiopian"
            "hebrew"
            "islamic"
            "julian"
            "mayan"
            "nanakshahi"
            "nepali"
            "persian"
            "jalali"
            "taiwan"
            "thai"
            "ummalqura"
        ]

    let LayoutBarMode =
        Pattern.EnumStrings "LayoutBarMode" [
            "stack"
            "group"
            "overlay"
            "relative"
        ]

    let LayoutBarNorm =
        Pattern.EnumInlines "LayoutBarNorm" [
            "empty", "''"
            "fraction", "'fraction'"
            "percent", "'percent'"
        ]

    let LayoutBoxMode =
        Pattern.EnumStrings "LayoutBoxMode" [
            "group"
            "overlay"
        ]

    let LayoutFunnelMode =
        Pattern.EnumStrings "LayoutFunnelMode" [
            "stack"
            "group"
            "overlay"
        ]

    let Layout =
        Class "Layout"
        |+> Static [
            Constructor T<unit>
        ]
        |+> Pattern.OptionalFields [
            "title", LayoutTitle.Type
            "showlegend", T<bool>
            "legend", LayoutLegend.Type
            "margin", T<unit>
            "autosize", T<bool>
            "width", T<int>
            "height", T<int>
            "font", LayoutFontConfig.Type
            "uniformtext", T<unit>
            "separators", T<string>
            "paper_bgcolor", LayoutColor
            "plot_bgcolor", LayoutColor
            "autotypenumbers", LayoutAutoTypeNumbers.Type
            "colorscale", T<unit>
            "colorway", T<obj> //colorlist
            "modebar", T<unit>
            "hovermode", LayoutHoverMode.Type
            "clickmode", LayoutClickMode.Type
            "dragmode", LayoutDragMode.Type
            "selectdirection", LayoutSelectDirection.Type
            "hoverdistance", T<int>
            "spikedistance", T<int>
            "hoverlabel", LayoutHoverLabel.Type
            "transition", LayoutTransition.Type
            "datarevision", T<Number> + T<string>
            "uirevision", T<Number> + T<string>
            "editrevision", T<Number> + T<string>
            "selectionrevision", T<Number> + T<string>
            "template", T<Number> + T<string>
            "meta", T<Number> + T<string>
            "computed", T<Number> + T<string>
            "grid", T<unit>
            "calendar", LayoutCalendar.Type
            "newshape", T<unit>
            "activeshape", T<unit>
            "hidesources", T<bool>
            "barmode", LayoutBarMode.Type
            "barnorm", LayoutBarNorm.Type
            "bargap", T<float> + T<int>
            "bargroupgap", T<float> + T<int>
            "hiddenlabels", T<string> //data array
            "piecolorway", T<obj> //colorlist
            "extendpiecolors", T<bool>
            "boxmode", LayoutBoxMode.Type
            "boxgap", T<float> + T<int>
            "boxgroupgap", T<float> + T<int>
            "violinmode", LayoutBoxMode.Type
            "violingap", T<float> + T<int>
            "violingroupgap", T<float> + T<int>
            "waterfallmode", LayoutBoxMode.Type
            "waterfallgap", T<float> + T<int>
            "waterfallgroupgap", T<float> + T<int>
            "funnelmode", LayoutFunnelMode.Type
            "funnelgap", T<float> + T<int>
            "funnelgroupgap", T<float> + T<int>
            "funnelareacolorway", T<obj> //colorlist
            "extendfunnelareacolors", T<bool>
            "sunburstcolorway", T<obj> //colorlist
            "extendsunburstcolors", T<bool>
            "treemapcolorway", T<obj> //colorlist
            "extendtreemapcolors", T<bool>
            "iciclecolorway", T<obj> //colorlist
            "extendiciclecolors", T<bool>
        ]