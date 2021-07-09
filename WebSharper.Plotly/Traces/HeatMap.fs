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

    let HMNullValue = Pattern.EnumInlines "NullValue" ["null", "null"]

    let HMColor = T<string> + (T<float> + T<int>) + (!| (!? (HMNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (HMNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let HMColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let HMVisibleString = Pattern.EnumStrings "HMVisibleString" ["legendonly"]

    let HMFont =
        Pattern.Config "HMFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", HMColor
            ]
        }

    let HMLegendGroupTitle =
        Pattern.Config "HMLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", HMFont.Type
            ]
        }

    let HMXYType =
        Pattern.EnumStrings "HMXYType" [
            "array"
            "scaled"
        ]

    let HMHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "HMHoverInfo" generatedEnum

    let HMPeriodAlignment =
        Pattern.EnumStrings "HMPeriodAlignment" [
            "start"
            "middle"
            "end"
        ]

    let HMColorBarMode =
        Pattern.EnumStrings "HMColorBarMode" [
            "fraction"
            "pixels"
        ]

    let HMXAnchor =
        Pattern.EnumStrings "HMXAnchor" [
            "left"
            "center"
            "right"
        ]

    let HMYAnchor =
        Pattern.EnumStrings "HMYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let HMTickMode =
        Pattern.EnumStrings "HMTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let HMTicks =
        Pattern.EnumInlines "HMTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let HMTickLabelOverflow =
        Pattern.EnumInlines "HMTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let HMTickLabelPosition =
        Pattern.EnumInlines "HMTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let HMDTickValue = (T<float> + T<int>) + T<string>

    let HMTickFormatStops =
        Pattern.Config "HMTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((HMDTickValue + HMNullValue.Type) * (HMDTickValue + HMNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let HMShowTickFix =
        Pattern.EnumStrings "HMShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let HMShowExponent = HMShowTickFix

    let HMExponentFormat =
        Pattern.EnumInlines "HMExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let HMSide =
        Pattern.EnumStrings "HMSide" [
            "right"
            "top"
            "bottom"
        ]

    let HMTitle =
        Pattern.Config "HMTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", HMFont.Type
                "side", HMSide.Type
            ]
        }

    let HMColorBar =
        Pattern.Config "HMColorBar" {
            Required = []
            Optional = [
                "thicknessmode", HMColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", HMColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", HMXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", HMYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", HMColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", HMColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", HMColor
                "tickmode", HMTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", HMTicks.Type
                "ticklabeloverflow", HMTickLabelOverflow.Type
                "ticklabelposition", HMTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", HMColor
                "showticklabels", T<bool>
                "tickfont", HMFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", HMTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", HMShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", HMShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", HMExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", HMShowExponent.Type // change type name to fit
                "title", HMTitle.Type
            ]
        }

    let HMZSmooth =
        Pattern.EnumStrings "HMZSmooth" [
            "fast"
            "best"
        ]

    let HMAlign =
        Pattern.EnumStrings "HMAlign" [
            "left"
            "right"
            "auto"
        ]

    let HMHoverLabel =
        Pattern.Config "HMHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", HMColor + !| HMColor
                "bordercolor", HMColor + !| HMColor
                "fonts", HMFont.Type
                "align", HMAlign.Type
                "namelength", T<int>
            ]
        }

    let HMCalendar =
        Pattern.EnumStrings "HMCalendar" [
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

    let HeatMapOptions = 
        Class "HeatMapOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'heatmap'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + HMVisibleString.Type
            "showlegend", T<bool>
            "legendrank", T<float> + T<int>
            "legendgroup", T<string>
            "legendgrouptitle", HMLegendGroupTitle.Type
            "opacity", (T<float> + T<int>)
            "ids", !| T<string> //data array
            "x", !| T<float> + !| T<int> + !| T<string> //data array
            "x0", (T<float> + T<int>) + !| T<string>
            "dx", (T<float> + T<int>)
            "xtype", HMXYType.Type
            "xgap", (T<float> + T<int>)
            "y", !| T<float> + !| T<int> + !| T<string> + !| (!| T<float> + !| T<int> + !| T<string>) + !| (!| (!| T<float> + !| T<int> + !| T<string>))    //data array
            "y0", (T<float> + T<int>) + !| T<string>
            "dy", (T<float> + T<int>)
            "ytype", HMXYType.Type
            "ygap", (T<float> + T<int>)
            "z", !| T<float> + !| T<int> + !| T<string> //data array
            "text", !| T<string> //data array
            "hovertext", !| T<string> //data array
            "hoverinfo", HMHoverInfo.Type
            "hovertemplate", T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", !| T<string> //data array
            "xaxis", T<string> //subplotid
            "yaxis", T<string> //subplotid
            "coloraxis", T<string> //subplotid
            "xperiod", (T<float> + T<int>) + T<string>
            "xperiodalignment", HMPeriodAlignment.Type
            "xperiod0", (T<float> + T<int>) + T<string>
            "yperiod", (T<float> + T<int>) + T<string>
            "yperiodalignment", HMPeriodAlignment.Type
            "yperiod0", (T<float> + T<int>) + T<string>
            "colorbar", HMColorBar.Type
            "autocolorscale", T<bool>
            "colorscale", HMColorScale
            "showscale", T<bool>
            "zauto", T<bool>
            "zhoverformat", T<string>
            "zmax", (T<float> + T<int>)
            "mid", (T<float> + T<int>)
            "min", (T<float> + T<int>)
            "zsmooth", HMZSmooth.Type + T<bool>
            "connectgaps", T<bool>
            "hoverlabel", HMHoverLabel.Type
            "hoverongaps", T<bool>
            "transpose", T<bool>
            "xcalendar", HMCalendar.Type
            "ycalendar", HMCalendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let HeatMapTraceNamespaces : CodeModel.NamespaceEntity list = [
        HMFont
        HMNullValue
        HMVisibleString
        HMLegendGroupTitle
        HMXYType
        HMHoverInfo
        HMPeriodAlignment
        HMColorBarMode
        HMXAnchor
        HMYAnchor
        HMTickMode
        HMTicks
        HMTickFormatStops
        HMTickLabelOverflow
        HMTickLabelPosition
        HMShowTickFix
        HMExponentFormat
        HMSide
        HMTitle
        HMColorBar
        HMZSmooth
        HMAlign
        HMHoverLabel
        HMCalendar
        HeatMapOptions
    ]
