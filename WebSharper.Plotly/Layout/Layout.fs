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
open WebSharper.Plotly.Extension.Common

module LayoutModule =

    open CommonModule

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

    let LayoutTitle =
        Pattern.Config "LayoutTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", Font.Type
                "xref", LayoutRef.Type
                "yref", LayoutRef.Type
                "x", T<float>
                "y", T<float>
                "xanchor", LayoutXAnchor.Type
                "yanchor", LayoutYAnchor.Type
                "pad", Pad.Type
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
                "bgcolor", Color
                "bordercolor", Color
                "borderwidth", T<int>
                "font", Font.Type
                "orientation", LayoutOrientation.Type
                "traceorder", LayoutTraceOrder.Type
                "tracegroupgap", T<int>
                "itemsizing", LayoutItemSizing.Type
                "itemwidth", T<int>
                "itemclick", LayoutItemClick.Type
                "itemdoubleclick", LayoutItemClick.Type
                "x", T<int> + T<float>
                "xanchor", LayoutXAnchor.Type
                "y", T<int> + T<float>
                "yanchor", LayoutYAnchor.Type
                "uirevision", T<int> + T<float> + T<string>
                "valign", LayoutVAlign.Type
                "title", LegendGroupTitle.Type
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
                "sequential", ColorScale
                "sequentialminus", ColorScale
                "diverging", ColorScale
            ]
        }

    let LayoutModebar =
        Pattern.Config "LayoutModebar" {
            Required = []
            Optional = [
                "orientation", LayoutOrientation.Type
                "bgcolor", Color
                "color", Color
                "uirevision", T<int> + T<float> + T<string>
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
                "bgcolor", Color + !| Color // ?
                "bordercolor", Color + !| Color // ?
                "fonts", Font.Type
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
                "duration", T<int> + T<float>
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

    let LayoutGridDomain =
        Pattern.Config "LayoutGridDomain" {
            Required = []
            Optional = [
                "x", !| (T<int> + T<float> + T<string>)
                "y", !| (T<int> + T<float> + T<string>)
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
                "domain", LayoutGridDomain.Type
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
                "color", Color
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
                "fillcolor", Color
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
                "fillcolor", Color
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
                "font", Font.Type
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
                "values", !| T<int> + !| T<float> // array
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

    let LayoutSpikeMode =
        let generatedEnum = GenerateOptions.allPermutations ["toaxis"; "across"; "marker"] '+'
        Pattern.EnumStrings "LayoutSpikeMode" generatedEnum

    let LayoutSpikeSnap =
        Pattern.EnumInlines "LayoutSpikeSnap" [
            "data", "'data'"
            "cursor", "'cursor'"
            "hoveredData", "'hovered data'"
        ]

    let LayoutShowTickFix =
        Pattern.EnumStrings "LayoutShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let LayoutShowExponent = LayoutShowTickFix

    let LayoutExponentFormat =
        Pattern.EnumInlines "LayoutExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let LayoutTickFormatStops =
        Pattern.Config "LayoutTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + NullValue.Type) * (DTickValue + NullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let LayoutAxisAnchor =
        Pattern.EnumInlines "LayoutAxisAnchor" [
            "free", "'free'"
            "x", "'/^x([2-9]|[1-9][0-9]+)?( domain)?$/'"
            "y", "'/^y([2-9]|[1-9][0-9]+)?( domain)?$/'"
        ]

    let LayoutAxisSide =
        Pattern.EnumStrings "LayoutAxisSide" [
            "left"
            "right"
            "top"
            "bottom"
        ]

    let LayoutAxisOverlaying = LayoutAxisAnchor

    let LayoutAxisLayer =
        Pattern.EnumInlines "LayoutAxisLayer" [
            "aboveTraces", "'above traces'"
            "belowTraces", "'below traces'"
        ]

    let LayoutCO =
        Pattern.EnumInlines "LayoutCO" [
            "trace", "'trace'"
            "categoryAscending", "'category ascending'"
            "categoryDescending", "'category descending'"
            "array", "'array'"
            "totalAscending", "'total ascending'"
            "totalDescending", "'total descending'"
            "minAscending", "'min ascending'"
            "minDescending", "'min descending'"
            "maxAscending", "'max ascending'"
            "maxDescending", "'max descending'"
            "sumAscending", "'sum ascending'"
            "sumDescending", "'sum descending'"
            "meanAscending", "'mean ascending'"
            "meanDescending", "'mean descending'"
            "medianAscending", "'median ascending'"
            "medianDescending", "'median descending'"
        ]

    let LayoutSliderAxisRangemode =
        Pattern.EnumStrings "LayoutSliderAxisRangemode" [
            "auto"
            "fixed"
            "match"
        ]

    let LayoutAxisRangeSliderAxis =
        Pattern.Config "LayoutAxisRangeSliderAxis" {
            Required = []
            Optional = [
                "rangemode", LayoutSliderAxisRangemode.Type
                "range", !| T<obj> // array
            ]
        }

    let LayoutAxisRangeSlider =
        Pattern.Config "LayoutAxisRangeSlider" {
            Required = []
            Optional = [
                "bgcolor", Color
                "bordercolor", Color
                "borderwidth", T<int>
                "autorange", T<bool>
                "range", T<obj> // array
                "thickness", (T<float> + T<int>)
                "visible", T<bool>
                "yaxis", LayoutAxisRangeSliderAxis.Type
            ]
        }

    let LayoutTimeStep =
        Pattern.EnumStrings "LayoutTimeStep" [
            "month"
            "year"
            "day"
            "hour"
            "minute"
            "second"
            "all"
        ]

    let LayoutTimeStepMode =
        Pattern.EnumStrings "LayoutTimeStepMode" [
            "backward"
            "todate"
        ]

    let LayoutRangeSelectorButtons =
        Pattern.Config "LayoutRangeSelectorButtons" {
            Required = []
            Optional = [
                "visible", T<bool>
                "step", LayoutTimeStep.Type
                "stepmode", LayoutTimeStepMode.Type
                "count", T<int>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let LayoutAxisRangeSelector =
        Pattern.Config "LayoutAxisRangeSelector" {
            Required = []
            Optional = [
                "visible", T<bool>
                "buttons", LayoutRangeSelectorButtons.Type
                "x", T<int> + T<float>
                "xanchor", LayoutXAnchor.Type
                "y", T<int> + T<float>
                "yanchor", LayoutYAnchor.Type
                "font", Font.Type
                "bgcolor", Color
                "activecolor", Color
                "bordercolor", Color
                "borderwidth", T<int>
            ]
        }

    let LayoutXAxis =
        Pattern.Config "LayoutXAxis" {
            Required = []
            Optional = [
                "visible", T<bool>
                "color", Color
                "title", LayoutAxisTitle.Type
                "type", LayoutAxisType.Type
                "autotypenumbers", LayoutAutoTypeNumbers.Type
                "autorange", LayoutAutoRange.Type
                "rangemode", LayoutRangeMode.Type
                "range", !| (T<int> + T<float> + T<string>)
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
                "tickcolor", Color
                "showticklabels", T<bool>
                "automargin", T<bool>
                "showspikes", T<bool>
                "spikecolor",Color
                "spikethickness", T<int>
                "spikedash", T<string>
                "spikemode", LayoutSpikeMode.Type
                "spikesnap", LayoutSpikeSnap.Type
                "tickfont", Font.Type
                "tickangle", (T<float> + T<int>) + T<string> //type: Angle
                "tickprefix", T<string>
                "showtickprefix", LayoutShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", LayoutShowTickFix.Type
                "showexponent", LayoutShowExponent.Type
                "exponentformat", LayoutExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "separatethousands", T<bool>
                "tickformat", T<string>
                "tickformatstops", LayoutTickFormatStops.Type
                "hoverformat", T<string>
                "showline", T<bool>
                "linecolor", Color
                "linewidth", T<int>
                "showgrid", T<bool>
                "gridcolor", Color
                "gridwidth", T<int>
                "zeroline", T<bool>
                "zerolinecolor", Color
                "zerolinewidth", T<int>
                "showdividers", T<bool>
                "dividercolor", Color
                "dividerwidth", T<int>
                "anchor", LayoutAxisAnchor.Type
                "side", LayoutAxisSide.Type
                "overlaying", LayoutAxisOverlaying.Type
                "layer", LayoutAxisLayer.Type
                "domain", !| (T<float> + T<int>)
                "position", (T<float> + T<int>)
                "categoryorder", LayoutCO.Type
                "categoryarray", !| T<obj>
                "uirevision", T<int> + T<float> + T<string>
                "rangeslider", LayoutAxisRangeSlider.Type
                "rangeselector", LayoutAxisRangeSelector.Type
                "calendar", LayoutCalendar.Type
            ]
        }

    let LayoutYAxis =
        Pattern.Config "LayoutYAxis" {
            Required = []
            Optional = [
                "visible", T<bool>
                "color", Color
                "title", LayoutAxisTitle.Type
                "type", LayoutAxisType.Type
                "autotypenumbers", LayoutAutoTypeNumbers.Type
                "autorange", LayoutAutoRange.Type
                "rangemode", LayoutRangeMode.Type
                "range", !| (T<int> + T<float> + T<string>)
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
                "tickcolor", Color
                "showticklabels", T<bool>
                "automargin", T<bool>
                "showspikes", T<bool>
                "spikecolor", Color
                "spikethickness", T<int>
                "spikedash", T<string>
                "spikemode", LayoutSpikeMode.Type
                "spikesnap", LayoutSpikeSnap.Type
                "tickfont", Font.Type
                "tickangle", (T<float> + T<int>) + T<string> //type: Angle
                "tickprefix", T<string>
                "showtickprefix", LayoutShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", LayoutShowTickFix.Type
                "showexponent", LayoutShowExponent.Type
                "exponentformat", LayoutExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "separatethousands", T<bool>
                "tickformat", T<string>
                "tickformatstops", LayoutTickFormatStops.Type
                "hoverformat", T<string>
                "showline", T<bool>
                "linecolor", Color
                "linewidth", T<int>
                "showgrid", T<bool>
                "gridcolor", Color
                "gridwidth", T<int>
                "zeroline", T<bool>
                "zerolinecolor", Color
                "zerolinewidth", T<int>
                "showdividers", T<bool>
                "dividercolor", Color
                "dividerwidth", T<int>
                "anchor", LayoutAxisAnchor.Type
                "side", LayoutAxisSide.Type
                "overlaying", LayoutAxisOverlaying.Type
                "layer", LayoutAxisLayer.Type
                "domain", !| (T<float> + T<int>)
                "position", (T<float> + T<int>)
                "categoryorder", LayoutCO.Type
                "categoryarray", !| T<obj>
                "uirevision", T<int> + T<float> + T<string>
                "calendar", LayoutCalendar.Type
            ]
        }

    let LayoutTernaryAxis =
        Pattern.Config "LayoutTernaryAAxis" {
            Required = []
            Optional = [
                "title", LegendGroupTitle.Type
                "color", Color
                "tickmode", LayoutTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", LayoutTicks.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", Color
                "showticklabels", T<bool>
                "tickprefix", T<string>
                "showtickprefix", LayoutShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", LayoutShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", LayoutExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", LayoutShowExponent.Type // change type name to fit
                "tickfont", Font.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", LayoutTickFormatStops.Type
                "hoverformat", T<string>
                "showline", T<bool>
                "linecolor", Color
                "linewidth", T<int>
                "showgrid", T<bool>
                "gridcolor", Color
                "gridwidth", T<int>
                "layer", LayoutAxisLayer.Type
                "min", T<int> + T<float>
                "uirevision", T<int> + T<float> + T<string>
            ]
        }

    let LayoutTernary =
        Pattern.Config "LayoutTernary" {
            Required = []
            Optional = [
                "domain", Domain.Type
                "bgcolor", Color
                "sum", T<int> + T<float>
                "aaxis", LayoutTernaryAxis.Type 
                "baxis", LayoutTernaryAxis.Type
                "caxis", LayoutTernaryAxis.Type
                "uirevision", T<int> + T<float> + T<string>
            ]
        }

    let LayoutCameraAxises =
        Pattern.Config "LayoutCameraAxises" {
            Required = []
            Optional = [
                "x", T<int> + T<float>
                "y", T<int> + T<float>
                "z", T<int> + T<float>
            ]
        }

    let LayoutCameraProjType =
        Pattern.EnumStrings "LayoutCameraProjType" [
            "perspective"
            "orthographic"
        ]

    let LayoutCameraProjection =
        Pattern.Config "LayoutCameraProjection" {
            Required = []
            Optional = [
                "type", LayoutCameraProjType.Type
            ]
        }

    let LayoutSceneCamera =
        Pattern.Config "LayoutSceneCamera" {
            Required = []
            Optional = [
                "up", LayoutCameraAxises.Type
                "center", LayoutCameraAxises.Type
                "eye", LayoutCameraAxises.Type
                "projection", LayoutCameraProjection.Type
            ]
        }

    let LayoutAspectMode =
        Pattern.EnumStrings "LayoutAspectMode" [
            "auto"
            "cube"
            "data"
            "manual"
        ]

    let LayoutSceneAxis =
        Pattern.Config "LayoutSceneAxis" {
            Required = []
            Optional = [
                "visible", T<bool>
                "showspikes", T<bool>
                "spikesides", T<bool>
                "spikecolor",Color
                "spikethickness", T<int>
                "showbackground", T<bool>
                "backgroundcolor", Color
                "showaxeslabels", T<bool>
                "color", Color
                "categoryorder", LayoutCO.Type
                "categoryarray", !| T<obj>
                "title", LegendGroupTitle.Type
                "type", LayoutAxisType.Type
                "autotypenumbers", LayoutAutoTypeNumbers.Type
                "autorange", LayoutAutoRange.Type
                "rangemode", LayoutRangeMode.Type
                "range", T<obj>
                "tickmode", LayoutTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "mirror", T<bool> + LayoutAxisMirror.Type
                "ticklen", T<int>
                "tickwidth", T<int>
                "tickcolor", Color
                "showticklabels", T<bool>
                "tickfont", Font.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", LayoutTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", LayoutShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", LayoutShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", LayoutExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", LayoutShowExponent.Type // change type name to fit
                "hoverformat", T<string>
                "showline", T<bool>
                "linecolor", Color
                "linewidth", T<int>
                "showgrid", T<bool>
                "gridcolor", Color
                "gridwidth", T<int>
                "zeroline", T<bool>
                "zerolinecolor", Color
                "zerolinewidth", T<int>
                "calendar", LayoutCalendar.Type
            ]
        }

    let LayoutSceneDragmode =
        Pattern.EnumInlines "LayoutSceneDragmode" [
            "orbit", "'orbit'"
            "turntable", "'turntable'"
            "zoom", "'zoom'"
            "pan", "'pan'"
            "false", "false"
        ]

    let LayoutSceneHoverMode =
        Pattern.EnumInlines "LayoutSceneHoverMode" [
            "closest", "'closest'"
            "false", "false"
        ]

    let LayoutScene =
        Pattern.Config "LayoutScene" {
            Required = []
            Optional = [
                "bgcolor", Color
                "camera", LayoutSceneCamera.Type
                "domain", Domain.Type
                "aspectmode", LayoutAspectMode.Type
                "aspectratio", LayoutCameraAxises.Type
                "xaxis", LayoutSceneAxis.Type
                "yaxis", LayoutSceneAxis.Type
                "zaxis", LayoutSceneAxis.Type
                "dragmode", LayoutSceneDragmode.Type
                "hovermode", LayoutSceneHoverMode.Type
                "uirevision", T<int> + T<float> + T<string>
                "annotations", !| T<obj>
            ]
        }

    let LayoutGeoFitBounds =
        Pattern.EnumInlines "LayoutGeoFitBounds" [
            "false", "false"
            "locations", "'locations'"
            "geojson", "'geojson'"
        ]

    let LayoutGeoResolution =
        Pattern.EnumStrings "LayoutGeoResolution" [
            "110"
            "50"
        ]

    let LayoutGeoScope =
        Pattern.EnumStrings "LayoutGeoScope" [
            "world"
            "usa"
            "europe"
            "asia"
            "africa"
            "north america"
            "south america"
        ]

    let LayoutGeoProjectionType =
        Pattern.EnumStrings "LayoutGeoProjectionType" [
            "equirectangular"
            "mercator"
            "orthographic"
            "natural earth"
            "kavrayskiy7"
            "miller"
            "robinson"
            "eckert4"
            "azimuthal equal area"
            "azimuthal equidistant"
            "conic equal area"
            "conic conformal"
            "conic equidistant"
            "gnomonic"
            "stereographic"
            "mollweide"
            "hammer"
            "transverse mercator"
            "albers usa"
            "winkel tripel"
            "aitoff"
            "sinusoidal"
        ]

    let LayoutGeoProjectionRotation =
        Pattern.Config "LayoutGeoProjectionRotation" {
            Required = []
            Optional = [
                "lon", T<int> + T<float>
                "lat", T<int> + T<float>
                "roll", T<int> + T<float>
            ]
        }

    let LayoutGeoProjection =
        Pattern.Config "LayoutGeoProjection" {
            Required = []
            Optional = [
                "type", LayoutGeoProjectionType.Type
                "rotation", LayoutGeoProjectionRotation.Type
                "parallels", !| T<obj> // array
                "scale", T<int> + T<float>
            ]
        }

    let LayoutCenter =
        Pattern.Config "LayoutCenter" {
            Required = []
            Optional = [
                "lon", T<int> + T<float>
                "lat", T<int> + T<float>
            ]
        }

    let LayoutGeoAxis =
        Pattern.Config "LayoutGeoAxis" {
            Required = []
            Optional = [
                "range", !| T<obj> //array
                "showgrid", T<bool>
                "tick0", T<int> + T<float>
                "dtick", T<int> + T<float>
                "gridcolor", Color
                "gridwidth", T<int>
            ]
        }

    let LayoutGeo =
        Pattern.Config "LayoutGeo" {
            Required = []
            Optional = [
                "domain", Domain.Type
                "fitbounds", LayoutGeoFitBounds.Type
                "resolution", LayoutGeoResolution.Type
                "scope", LayoutGeoScope.Type
                "projection", LayoutGeoProjection.Type
                "center", LayoutCenter.Type
                "visible", T<bool>
                "showcoastlines", T<bool>
                "coastlinecolor", Color
                "coastlinewidth", T<int> + T<float>
                "showland", T<bool>
                "landcolor", Color
                "showocean", T<bool>
                "oceancolor", Color
                "showlakes", T<bool>
                "lakecolor", Color
                "showrivers", T<bool>
                "rivercolor", Color
                "riverwidth", T<int> + T<float>
                "showcountries", T<bool>
                "countrycolor", Color
                "countrywidth", T<int> + T<float>
                "showsubunits", T<bool>
                "subunitcolor", Color
                "subunitwidth", T<int> + T<float>
                "showframe", T<bool>
                "framecolor", Color
                "framewidth", T<int> + T<float>
                "bgcolor", Color
                "lonaxis", LayoutGeoAxis.Type
                "lataxis", LayoutGeoAxis.Type
                "uirevision", T<int> + T<float> + T<string>
            ]
        }

    let LayoutImage =
        Pattern.Config "LayoutImage" {
            Required = []
            Optional = [
                "source", T<string>
                "xref", T<string>
                "yref", T<string>
                "x", T<int>
                "y", T<int>
                "sizex", T<int>
                "sizey", T<int>
                "xanchor", T<string>
                "yanchor", T<string>
                "sizing", T<string>
                "opacity", T<float>
                "layer", T<string>
            ]
        }

    let LayoutSourceType =
        Pattern.EnumStrings "LayoutSourceType" [
            "geojson"
            "vector"
            "raster"
            "image"
        ]

    let LayoutMapboxLayerType =
        Pattern.EnumStrings "LayoutMapboxLayerType" [
            "circle"
            "line"
            "fill"
            "symbol"
        ]

    let LayoutMapboxLayerCircle =
        Pattern.Config "LayoutMapboxLayerCircle" {
            Required = []
            Optional = [
                "radius", T<int> + T<float>
            ]
        }

    let LayoutMapboxLayerLine =
        Pattern.Config "LayoutMapboxLayerLine" {
            Required = []
            Optional = [
                "color", Color
                "width", T<int> + T<float>
                "dash", T<string>
            ]
        }

    let LayoutMapboxLayerFill =
        Pattern.Config "LayoutMapboxLayerFill" {
            Required = []
            Optional = [
                "outlinecolor", Color
            ]
        }

    let LayoutSymbolPlacement =
        Pattern.EnumStrings "LayoutSymbolPlacement" [
            "point"
            "line"
            "line-center"
        ]

    let LayoutMapboxLayerSymbol =
        Pattern.Config "LayoutMapboxLayerSymbol" {
            Required = []
            Optional = [
                "icon", T<string>
                "iconsize", T<int> + T<float>
                "text", T<string>
                "placement", LayoutSymbolPlacement.Type
                "textfont", Font.Type
                "textposition", TextPositionInline.Type
            ]
        }

    let LayoutMapboxLayer =
        Pattern.Config "LayoutMapboxLayer" {
            Required = []
            Optional = [
                "visible", T<bool>
                "sourcetype", LayoutSourceType.Type
                "source", T<int> + T<float> + T<string>
                "sourcelayer", T<string>
                "sourceattribution", T<string>
                "type", LayoutMapboxLayerType.Type
                "coordinates", T<int> + T<float> + T<string>
                "below", T<string>
                "color", Color
                "opacity", T<float> + T<int>
                "minzoom", T<float> + T<int>
                "maxzoom", T<float> + T<int>
                "circle", LayoutMapboxLayerCircle.Type
                "line", LayoutMapboxLayerLine.Type
                "fill", LayoutMapboxLayerFill.Type
                "symbol", LayoutMapboxLayerSymbol.Type
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let LayoutMapbox =
        Pattern.Config "LayoutMapbox" {
            Required = []
            Optional = [
                "domain", Domain.Type
                "accesstoken", T<string>
                "style", T<int> + T<float> + T<string>
                "center", LayoutCenter.Type
                "zoom", T<int> + T<float>
                "bearing", T<int> + T<float>
                "pitch", T<int> + T<float>
                "layers", LayoutMapboxLayer.Type
                "uirevision", T<int> + T<float> + T<string>
            ]
        }

    let LayoutRadialAxisSide =
        Pattern.EnumStrings "LayoutRadialAxisSide" [
            "clockwise"
            "counterclockwise"
        ]

    let LayoutRadialAxisType =
        Pattern.EnumInlines "LayoutRadialAxisType" [
            "minus", "'-'"
            "linear", "'linear'"
            "log", "'log'"
            "date", "'date'"
            "category", "'category'"
        ]

    let LayoutPolarRadialAxis =
        Pattern.Config "LayoutPolarRadialAxis" {
            Required = []
            Optional = [
                "visible", T<bool>
                "type", LayoutRadialAxisType.Type
                "autotypenumbers", LayoutAutoTypeNumbers.Type
                "autorange", LayoutAutoRange.Type
                "range", !| T<obj>
                "categoryorder", LayoutCO.Type
                "categoryarray", !| T<obj>
                "angle", T<int> + T<float> //angle
                "side", LayoutRadialAxisSide.Type
                "title", LegendGroupTitle.Type
                "hoverformat", T<string>
                "uirevision", T<int> + T<float> + T<string>
                "color", Color
                "showline", T<bool>
                "linecolor", Color
                "linewidth", T<int>
                "showgrid", T<bool>
                "gridcolor", Color
                "gridwidth", T<int>
                "tickmode", LayoutTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", LayoutTicks.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", Color
                "showticklabels", T<bool>
                "tickfont", Font.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", LayoutTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", LayoutShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", LayoutShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", LayoutExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", LayoutShowExponent.Type // change type name to fit
                "layer", LayoutAxisLayer.Type
                "calendar", LayoutCalendar.Type
            ]
        }

    let LayoutPolarThetaUnit =
        Pattern.EnumStrings "LayoutPolarThetaUnit" [
            "radians"
            "degrees"
        ]

    let LayoutAngularAxisType =
        Pattern.EnumInlines "LayoutAngularAxisType" [
            "minus", "'-'"
            "linear", "'linear'"
            "category", "'category'"
        ]

    let LayoutPolarAngularAxis =
        Pattern.Config "LayoutPolarAngularAxis" {
            Required = []
            Optional = [
                "visible", T<bool>
                "type", LayoutAngularAxisType.Type
                "autotypenumbers", LayoutAutoTypeNumbers.Type
                "categoryorder", LayoutCO.Type
                "categoryarray", !| T<obj>
                "thetaunit", LayoutPolarThetaUnit.Type
                "period", T<int> + T<float>
                "direction", LayoutRadialAxisSide.Type
                "rotation", T<int> + T<float>
                "hoverformat", T<string>
                "uirevision", T<int> + T<float> + T<string>
                "color",Color
                "showline", T<bool>
                "linecolor", Color
                "linewidth", T<int>
                "showgrid", T<bool>
                "gridcolor", Color
                "gridwidth", T<int>
                "tickmode", LayoutTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", LayoutTicks.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", Color
                "showticklabels", T<bool>
                "tickfont", Font.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", LayoutTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", LayoutShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", LayoutShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", LayoutExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", LayoutShowExponent.Type // change type name to fit
                "layer", LayoutAxisLayer.Type
            ]
        }

    let LayoutGridShape =
        Pattern.EnumStrings "LayoutGridShape" [
            "circular"
            "linear"
        ]

    let LayoutPolar =
        Pattern.Config "LayoutPolar" {
            Required = []
            Optional = [
                "domain", Domain.Type
                "sector", !| T<obj>
                "hole", (T<float> + T<int>)
                "bgcolor", Color
                "radialaxis", LayoutPolarRadialAxis.Type
                "angularaxis", LayoutPolarAngularAxis.Type
                "gridshape", LayoutGridShape.Type
                "uirevision", T<int> + T<float> + T<string>
                "bargap", T<float> + T<int>
            ]
        }

    

    let LayoutColorBarMode =
        Pattern.EnumStrings "LayoutColorBarMode" [
            "fraction"
            "pixels"
        ]

    let LayoutColorBarTickLabelPosition =
        Pattern.EnumInlines "LayoutColorBarTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let LayoutColorBar =
        Pattern.Config "LayoutColorBar" {
            Required = []
            Optional = [
                "thicknessmode", LayoutColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", LayoutColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", LayoutXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", LayoutYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", Color
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", Color
                "borderwidth", (T<float> + T<int>)
                "bgcolor", Color
                "tickmode", LayoutTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", LayoutTicks.Type
                "ticklabeloverflow", LayoutTickLabelOverflow.Type
                "ticklabelposition", LayoutColorBarTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", Color
                "showticklabels", T<bool>
                "tickfont", Font.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", LayoutTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", LayoutShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", LayoutShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", LayoutExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", LayoutShowExponent.Type // change type name to fit
                "title", LayoutTitle.Type
            ]
        }

    let LayoutColorAxis =
        Pattern.Config "LayoutColorAxis" {
            Required = []
            Optional = [
                "cauto", T<bool>
                "cmin", T<int> + T<float>
                "cmax", T<int> + T<float>
                "cmid", T<int> + T<float>
                "colorscale", LayoutColorscale.Type
                "autocolorscale", T<bool>
                "reversescale", T<bool>
                "showscale", T<bool>
                "colorbar", LayoutColorBar.Type

            ]
        }

    let LayoutUpdateMenusType =
        Pattern.EnumStrings "LayoutUpdateMenusType" [
            "dropdown"
            "buttons"
        ]

    let LayoutDirection =
        Pattern.EnumStrings "LayoutDirection" [
            "left"
            "right"
            "up"
            "down"
        ]

    let LayoutButtonsMethod =
        Pattern.EnumStrings "LayoutButtonsMethod" [
            "restyle"
            "relayout"
            "animate"
            "update"
            "skip"
        ]

    let LayoutUpdateMenusButtons =
        Pattern.Config "LayoutUpdateMenusButtons" {
            Required = []
            Optional = [
                "visible", T<bool>
                "method", LayoutButtonsMethod.Type
                "args", !| T<obj>
                "args2", !| T<obj>
                "label", T<string>
                "execute", T<bool>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let LayoutUpdateMenus =
        Pattern.Config "LayoutUpdateMenus" {
            Required = []
            Optional = [
                "visible", T<bool>
                "type", LayoutUpdateMenusType.Type
                "direction", LayoutDirection.Type
                "active", T<int>
                "showactive", T<bool>
                "buttons", LayoutUpdateMenusButtons.Type
                "x", T<float>
                "y", T<float>
                "xanchor", LayoutXAnchor.Type
                "yanchor", LayoutYAnchor.Type
                "pad", Pad.Type
                "font", Font.Type
                "bgcolor", Color
                "bordercolor", Color
                "borderwidth", T<int>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let LayoutSlidersSteps =
        Pattern.Config "LayoutSlidersSteps" {
            Required = []
            Optional = [
                "visible", T<bool>
                "method", LayoutButtonsMethod.Type
                "args", !| T<obj>
                "label", T<string>
                "execute", T<bool>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let LayoutSlidersTransition =
        Pattern.Config "LayoutSlidersTransition" {
            Required = []
            Optional = [
                "duration", T<int> + T<float>
                "easing", LayoutEasing.Type
            ]
        }

    let LayoutSlidersCVXAnchor =
        Pattern.EnumStrings "LayoutSlidersCVXAnchor" [
            "left"
            "center"
            "right"
        ]

    let LayoutSlidersCurrentValue =
        Pattern.Config "LayoutSlidersCurrentValue" {
            Required = []
            Optional = [
                "visible", T<bool>
                "xanchor", LayoutSlidersCVXAnchor.Type
                "offset", T<int>
                "prefix", T<string>
                "suffix", T<string>
                "font", Font.Type
            ]
        }

    let LayoutSliders =
        Pattern.Config "LayoutSliders" {
            Required = []
            Optional = [
                "visible", T<bool>
                "active", T<int>
                "steps", LayoutSlidersSteps.Type
                "lenmode", LayoutColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", LayoutXAnchor.Type
                "y", T<float>
                "yanchor", LayoutYAnchor.Type
                "transition", LayoutSlidersTransition.Type
                "currentvalue", LayoutSlidersCurrentValue.Type
                "font", Font.Type
                "activebgcolor", Color
                "bgcolor", Color
                "bordercolor", Color
                "borderwidth", T<int>
                "ticklen", T<int>
                "tickwidth", T<int>
                "minorticklen", T<int>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }


    let Layout =
        Pattern.Config "Layout" {
            Required = []
            Optional = [
                "title", LayoutTitle.Type
                "showlegend", T<bool>
                "legend", LayoutLegend.Type
                "margin", LayoutMargin.Type
                "autosize", T<bool>
                "width", T<int>
                "height", T<int>
                "font", Font.Type
                "uniformtext", T<unit>
                "separators", T<string>
                "paper_bgcolor", Color
                "plot_bgcolor", Color
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
                "datarevision", T<int> + T<float> + T<string>
                "uirevision", T<int> + T<float> + T<string>
                "editrevision", T<int> + T<float> + T<string>
                "selectionrevision", T<int> + T<float> + T<string>
                "template", T<obj>
                "meta", T<int> + T<float> + T<string>
                "computed", T<int> + T<float> + T<string>
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
                "xaxis", LayoutXAxis.Type
                "yaxis", LayoutYAxis.Type
                "ternary", LayoutTernary.Type
                "scene", LayoutScene.Type
                "geo", LayoutGeo.Type
                "mapbox", LayoutMapbox.Type
                "polar", LayoutPolar.Type
                "coloraxis", LayoutColorAxis.Type
                "annotations", !| T<obj>
                "shapes", !| T<obj>
                "images", !| LayoutImage.Type
                "updatemenus", !| LayoutUpdateMenus.Type
                "sliders", !| LayoutSliders.Type
            ]
        }
    
    let LayoutNameSpaces : CodeModel.NamespaceEntity list = [
        LayoutTitle
        LayoutImage
        LayoutLegend
        LayoutMargin
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
        LayoutOrientation
        LayoutTraceOrder
        LayoutItemSizing
        LayoutItemClick
        LayoutVAlign
        LayoutLegendSide
        LayoutAlign
        LayoutEasing
        LayoutOrdering
        LayoutRoworder
        LayoutGridPattern
        LayoutGridDomain
        LayoutXSide
        LayoutYSide
        LayoutNewShapeLine
        LayoutFillRule
        LayoutNewShapeLayer
        LayoutDrawDirection
        LayoutAxisRangeSelector
        LayoutRangeSelectorButtons
        LayoutTimeStepMode
        LayoutTimeStep
        LayoutAxisTitle
        LayoutAxisType
        LayoutAutoRange
        LayoutRangeMode
        LayoutScaleAnchor
        LayoutAxisConstrain
        LayoutConstrainToward
        LayoutRangeBreaksPattern
        LayoutRangeBreaks
        LayoutTickMode
        LayoutTicks
        LayoutTicksOn
        LayoutTickLabelMode
        LayoutTickLabelPosition
        LayoutTickLabelOverflow
        LayoutAxisMirror
        LayoutSpikeMode
        LayoutSpikeSnap
        LayoutShowTickFix
        LayoutExponentFormat
        LayoutTickFormatStops
        LayoutAxisAnchor
        LayoutAxisSide
        LayoutAxisLayer
        LayoutCO
        LayoutSliderAxisRangemode
        LayoutAxisRangeSliderAxis
        LayoutAxisRangeSlider
        LayoutGeoFitBounds
        LayoutGeoResolution
        LayoutGeoScope
        LayoutGeoProjectionType
        LayoutGeoProjectionRotation
        LayoutGeoProjection
        LayoutCenter
        LayoutGeoAxis
        LayoutSourceType
        LayoutMapboxLayerType
        LayoutMapboxLayerLine
        LayoutMapboxLayerFill
        LayoutSymbolPlacement
        LayoutMapboxLayerSymbol
        LayoutMapboxLayerCircle
        LayoutMapboxLayer
        LayoutColorBarMode
        LayoutColorBarTickLabelPosition
        LayoutColorBar
        LayoutScene
        LayoutTernaryAxis
        LayoutCameraAxises
        LayoutCameraProjType
        LayoutCameraProjection
        LayoutSceneCamera
        LayoutAspectMode
        LayoutSceneAxis
        LayoutSceneDragmode
        LayoutSceneHoverMode
        LayoutRadialAxisType
        LayoutRadialAxisSide
        LayoutPolarRadialAxis
        LayoutAngularAxisType
        LayoutPolarThetaUnit
        LayoutPolarAngularAxis
        LayoutGridShape
        LayoutMapbox
        LayoutPolar
        LayoutGeo
        LayoutTernary
        LayoutXAxis
        LayoutYAxis
        LayoutColorAxis
        LayoutDirection
        LayoutButtonsMethod
        LayoutUpdateMenusButtons
        LayoutUpdateMenusType
        LayoutUpdateMenus
        LayoutSlidersCurrentValue
        LayoutSlidersCVXAnchor
        LayoutSlidersSteps
        LayoutSlidersTransition
        LayoutSliders
        Layout
    ]