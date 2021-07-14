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

    let LayoutRef =
        Pattern.EnumStrings "LayoutRef" [
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
                "xref", LayoutRef.Type
                "yref", LayoutRef.Type
                "x", T<float>
                "y", T<float>
                "xanchor", LayoutXAnchor.Type
                "yanchor", LayoutYAnchor.Type
                "pad", LayoutPadding.Type
            ]
        }

    let LayoutOrientation =
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
                "orientation", LayoutOrientation.Type
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

    let LayoutMargin =
        Pattern.Config "LayoutMargin" {
            Required = []
            Optional = [
                "l", T<int>
                "r", T<int>
                "t", T<int>
                "b", T<int>
                "pad", T<int>
                "autoexpand", T<bool>
            ]
        }

    let LayoutAutoTypeNumbers =
        Pattern.EnumInlines "LayoutAutoTypeNumbers" [
            "convertTypes", "'convert types'"
            "strict", "'strict'"
        ]

    let LayoutColorscale =
        Pattern.Config "LayoutColorscale" {
            Required = []
            Optional = [
                "sequential", T<obj> // colorscale
                "sequentialminus", T<obj> // colorscale
                "diverging", T<obj> // colorscale
            ]
        }

    let LayoutModebar =
        Pattern.Config "LayoutModebar" {
            Required = []
            Optional = [
                "orientation", LayoutOrientation.Type
                "bgcolor", LayoutColor
                "color", LayoutColor
                "uirevision", T<Number> + T<string>
                "add", T<string> + !| T<string>
                "remove", T<string> + !| T<string>
            ]
        }

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

    let LayoutRoworder =
        Pattern.EnumInlines "LayoutRoworder" [
            "topToBottom", "'top to bottom'"
            "bottomToTop", "'bottom to top'"
        ]

    let LayoutGridPattern =
        Pattern.EnumStrings "LayoutGridPattern" [
            "independent"
            "coupled"
        ]

    let LayoutDomain =
        Pattern.Config "LayoutDomain" {
            Required = []
            Optional = [
                "x", !| (T<Number> + T<string>)
                "y", !| (T<Number> + T<string>)
            ]
        }

    let LayoutXSide =
        Pattern.EnumInlines "LayoutXSide" [
            "bottom", "'bottom'"
            "bottomPlot", "'bottom plot'"
            "topPlot", "'top plot'"
            "top", "'top'"
        ]

    let LayoutYSide =
        Pattern.EnumInlines "LayoutYSide" [
            "left", "'left'"
            "leftPlot", "'left plot'"
            "rightPlot", "'right plot'"
            "right", "'right'"
        ]

    let LayoutGrid =
        Pattern.Config "LayoutGrid" {
            Required = []
            Optional = [
                "rows", T<int>
                "roworder", LayoutRoworder.Type
                "columns", T<int>
                "subplots", !| T<obj>
                "xaxes", !| T<obj>
                "yaxes", !| T<obj>
                "pattern", LayoutGridPattern.Type
                "xgap", (T<float> + T<int>)
                "ygap", (T<float> + T<int>)
                "domain", LayoutDomain.Type
                "xside", LayoutXSide.Type
                "yside", LayoutYSide.Type
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

    let LayoutNewShapeLine =
        Pattern.Config "LayoutNewShapeLine" {
            Required = []
            Optional = [
                "color", LayoutColor
                "width", T<int>
                "dash", T<string>
            ]
        }

    let LayoutFillRule =
        Pattern.EnumStrings "LayoutFillRule" [
            "evenodd"
            "nonzero"
        ]

    let LayoutNewShapeLayer =
        Pattern.EnumStrings "LayoutNewShapeLayer" [
            "below"
            "above"
        ]

    let LayoutDrawDirection =
        Pattern.EnumStrings "LayoutDrawDirection" [
            "ortho"
            "horizontal"
            "vertical"
            "diagonal"
        ]

    let LayoutNewShape =
        Pattern.Config "LayoutNewShape" {
            Required = []
            Optional = [
                "line", LayoutNewShapeLine.Type
                "fillcolor", LayoutColor
                "fillrule", LayoutFillRule.Type
                "opacity", T<float> + T<int>
                "layer", LayoutNewShapeLayer.Type
                "drawdirection", LayoutDrawDirection.Type
            ]
        }

    let LayoutActiveShape =
        Pattern.Config "LayoutActiveShape" {
            Required = []
            Optional = [
                "fillcolor", LayoutColor
                "opacity", T<float> + T<int>
            ]
        }

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

    let LayoutAxisTitle =
        Pattern.Config "LayoutAxisTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", LayoutFontConfig.Type
                "stadoff", T<int>
            ]
        }

    let LayoutAxisType =
        Pattern.EnumInlines "LayoutAxisType" [
            "minus", "'-'"
            "linear", "'linear'"
            "log", "'log'"
            "date", "'date'"
            "category", "'category'"
            "multicategory", "'multicategory'"
        ]

    let LayoutAutoRange =
        Pattern.EnumInlines "LayoutAutoRange" [
            "true", "true"
            "false", "false"
            "reversed", "'reversed'"
        ]

    let LayoutRangeMode =
        Pattern.EnumStrings "LayoutRangeMode" [
            "normal"
            "tozero"
            "nonnegative"
        ]

    let LayoutScaleAnchor =
        Pattern.EnumInlines "LayoutScaleAnchor" [
            "x", "'/^x([2-9]|[1-9][0-9]+)?( domain)?$/'"
            "y", "'/^y([2-9]|[1-9][0-9]+)?( domain)?$/'"
        ]

    let LayoutAxisConstrain =
        Pattern.EnumStrings "LayoutAxisConstrain" [
            "range"
            "domain"
        ]

    let LayoutConstrainToward =
        Pattern.EnumStrings "LayoutConstrainToward" [
            "left"
            "center"
            "right"
            "top"
            "middle"
            "bottom"
        ]

    let LayoutRangeBreaksPattern =
        Pattern.EnumInlines "LayoutRangeBreaksPattern" [
            "dayOfWeek", "'day of week'"
            "hour", "'hour'"
            "empty", "''"
        ]

    let LayoutRangeBreaks =
        Pattern.Config "LayoutRangeBreaks" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "bounds", !| T<string> // array, seems to be string arr
                "pattern", LayoutRangeBreaksPattern.Type
                "values", !| T<Number> // array
                "dvalue", T<int>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let LayoutTickMode =
        Pattern.EnumStrings "LayoutTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let LayoutTicks =
        Pattern.EnumInlines "LayoutTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let LayoutTicksOn =
        Pattern.EnumStrings "LayoutTicksOn" [
            "labels"
            "boundaries"
        ]

    let LayoutTickLabelMode =
        Pattern.EnumStrings "LayoutTickLabelMode" [
            "instant"
            "period"
        ]

    let LayoutTickLabelPosition =
        Pattern.EnumInlines "LayoutTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideLeft", "'outside left'"
            "insideLeft", "'inside left'"
            "outsideRight", "'outside right'"
            "insideRight", "'inside right'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let LayoutTickLabelOverflow =
        Pattern.EnumInlines "LayoutTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let LayoutAxisMirror =
        Pattern.EnumStrings "LayoutAxisMirror" [
            "ticks"
            "all"
            "allticks"
        ]

    let LayoutXAxis =
        Pattern.Config "LayoutXAxis" {
            Required = []
            Optional = [
                "visible", T<bool>
                "color", LayoutColor
                "title", LayoutAxisTitle.Type
                "type", LayoutAxisType.Type
                "autotypenumbers", LayoutAutoTypeNumbers.Type
                "autorange", LayoutAutoRange.Type
                "rangemode", LayoutRangeMode.Type
                "range", !| (T<Number> + T<string>)
                "fixedrange", T<bool>
                "scaleanchor", LayoutScaleAnchor.Type
                "scaleratio", T<float> + T<int>
                "constrain", LayoutAxisConstrain.Type
                "constraintoward", LayoutConstrainToward.Type
                "matches", LayoutScaleAnchor.Type
                "rangebreaks", LayoutRangeBreaks.Type
                "tickmode", LayoutTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string>
                "ticks", LayoutTicks.Type
                "tickson", LayoutTicksOn.Type
                "ticklabelmode", LayoutTickLabelMode.Type
                "ticklabelposition", LayoutTickLabelPosition.Type
                "ticklabeloverflow", LayoutTickLabelOverflow.Type
                "mirror", T<bool> + LayoutAxisMirror.Type
                "ticklen", T<int>
                "tickwidth", T<int>
                "tickcolor", LayoutColor
                "showticklabels", T<bool>
                "automargin", T<bool>
                "showspikes", T<bool>
                "spikecolor",LayoutColor
                "spikethickness", T<int>
                "spikedash", T<string>
            ]
        }

    let LayoutYAxis =
        Pattern.Config "LayoutYAxis" {
            Required = []
            Optional = [
                
            ]
        }

    let LayoutTernary =
        Pattern.Config "LayoutTernary" {
            Required = []
            Optional = [
                
            ]
        }

    let LayoutScene =
        Pattern.Config "LayoutScene" {
            Required = []
            Optional = [
                
            ]
        }

    let LayoutGeo =
        Pattern.Config "LayoutGeo" {
            Required = []
            Optional = [
                
            ]
        }

    let LayoutMapbox =
        Pattern.Config "LayoutMapbox" {
            Required = []
            Optional = [
                
            ]
        }

    let LayoutPolar =
        Pattern.Config "LayoutPolar" {
            Required = []
            Optional = [
                
            ]
        }

    let LayoutColorAxis =
        Pattern.Config "LayoutColorAxis" {
            Required = []
            Optional = [
                
            ]
        }

    let Layout =
        Class "Layout"
        |+> Static [
            Constructor T<unit>
        ]
        |+> Pattern.OptionalFields [
            "title", LayoutTitle.Type
            "showlegend", T<bool>
            "legend", LayoutLegend.Type
            "margin", LayoutMargin.Type
            "autosize", T<bool>
            "width", T<int>
            "height", T<int>
            "font", LayoutFontConfig.Type
            "uniformtext", T<unit>
            "separators", T<string>
            "paper_bgcolor", LayoutColor
            "plot_bgcolor", LayoutColor
            "autotypenumbers", LayoutAutoTypeNumbers.Type
            "colorscale", LayoutColorscale.Type
            "colorway", !| T<string> //colorlist
            "modebar", LayoutModebar.Type
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
            "grid", LayoutGrid.Type
            "calendar", LayoutCalendar.Type
            "newshape", LayoutNewShape.Type
            "activeshape", LayoutActiveShape.Type
            "hidesources", T<bool>
            "barmode", LayoutBarMode.Type
            "barnorm", LayoutBarNorm.Type
            "bargap", T<float> + T<int>
            "bargroupgap", T<float> + T<int>
            "hiddenlabels", T<string> //data array
            "piecolorway", !| T<string> //colorlist
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
            "funnelareacolorway", !| T<string> //colorlist
            "extendfunnelareacolors", T<bool>
            "sunburstcolorway", !| T<string> //colorlist
            "extendsunburstcolors", T<bool>
            "treemapcolorway", !| T<string> //colorlist
            "extendtreemapcolors", T<bool>
            "iciclecolorway", !| T<string> //colorlist
            "extendiciclecolors", T<bool>
            "xaxis", T<unit>
            "yaxis", T<unit>
            "ternary", T<unit>
            "scene", T<unit>
            "geo", T<unit>
            "mapbox", T<unit>
            "polar", T<unit>
            "coloraxis", T<unit>
            "annotations", T<unit>
            "shapes", T<unit>
            "images", T<unit>
            "updatemenus", T<unit>
            "sliders", T<unit>
        ]
    
    let LayoutNameSpaces : CodeModel.NamespaceEntity list = [
        LayoutTitle
        LayoutLegend
        LayoutMargin
        LayoutFontConfig
        LayoutAutoTypeNumbers
        LayoutColorscale
        LayoutModebar
        LayoutHoverMode
        LayoutClickMode
        LayoutDragMode
        LayoutSelectDirection
        LayoutHoverLabel
        LayoutTransition
        LayoutGrid
        LayoutCalendar
        LayoutNewShape
        LayoutActiveShape
        LayoutBarMode
        LayoutBarNorm
        LayoutBoxMode
        LayoutFunnelMode
        LayoutRef
        LayoutXAnchor
        LayoutYAnchor
        LayoutPadding
        LayoutOrientation
        LayoutTraceOrder
        LayoutItemSizing
        LayoutItemClick
        LayoutVAlign
        LayoutLegendTitle
        LayoutLegendSide
        LayoutAlign
        LayoutEasing
        LayoutOrdering
        LayoutRoworder
        LayoutGridPattern
        LayoutDomain
        LayoutXSide
        LayoutYSide
        LayoutNewShapeLine
        LayoutFillRule
        LayoutNewShapeLayer
        LayoutDrawDirection
        Layout
    ]