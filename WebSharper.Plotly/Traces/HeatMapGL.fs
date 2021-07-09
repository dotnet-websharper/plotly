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

    let HMGLNullValue = Pattern.EnumInlines "NullValue" ["null", "null"]

    let HMGLColor = T<string> + (T<float> + T<int>) + (!| (!? (HMGLNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (HMGLNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let HMGLColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let HMGLVisibleString = Pattern.EnumStrings "HMGLVisibleString" ["legendonly"]

    let HMGLFont =
        Pattern.Config "HMGLFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", HMGLColor
            ]
        }

    let HMGLLegendGroupTitle =
        Pattern.Config "HMGLLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", HMGLFont.Type
            ]
        }

    let HMGLXYType =
        Pattern.EnumStrings "HMGLXYType" [
            "array"
            "scaled"
        ]

    let HMGLHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "HMGLHoverInfo" generatedEnum

    let HMGLPeriodAlignment =
        Pattern.EnumStrings "HMGLPeriodAlignment" [
            "start"
            "middle"
            "end"
        ]

    let HMGLColorBarMode =
        Pattern.EnumStrings "HMGLColorBarMode" [
            "fraction"
            "pixels"
        ]

    let HMGLXAnchor =
        Pattern.EnumStrings "HMGLXAnchor" [
            "left"
            "center"
            "right"
        ]

    let HMGLYAnchor =
        Pattern.EnumStrings "HMGLYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let HMGLTickMode =
        Pattern.EnumStrings "HMGLTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let HMGLTicks =
        Pattern.EnumInlines "HMGLTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let HMGLTickLabelOverflow =
        Pattern.EnumInlines "HMGLTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let HMGLTickLabelPosition =
        Pattern.EnumInlines "HMGLTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let HMGLDTickValue = (T<float> + T<int>) + T<string>

    let HMGLTickFormatStops =
        Pattern.Config "HMGLTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((HMGLDTickValue + HMGLNullValue.Type) * (HMGLDTickValue + HMGLNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let HMGLShowTickFix =
        Pattern.EnumStrings "HMGLShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let HMGLShowExponent = HMGLShowTickFix

    let HMGLExponentFormat =
        Pattern.EnumInlines "HMGLExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let HMGLSide =
        Pattern.EnumStrings "HMGLSide" [
            "right"
            "top"
            "bottom"
        ]

    let HMGLTitle =
        Pattern.Config "HMGLTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", HMGLFont.Type
                "side", HMGLSide.Type
            ]
        }

    let HMGLColorBar =
        Pattern.Config "HMGLColorBar" {
            Required = []
            Optional = [
                "thicknessmode", HMGLColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", HMGLColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", HMGLXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", HMGLYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", HMGLColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", HMGLColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", HMGLColor
                "tickmode", HMGLTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", HMGLTicks.Type
                "ticklabeloverflow", HMGLTickLabelOverflow.Type
                "ticklabelposition", HMGLTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", HMGLColor
                "showticklabels", T<bool>
                "tickfont", HMGLFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", HMGLTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", HMGLShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", HMGLShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", HMGLExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", HMGLShowExponent.Type // change type name to fit
                "title", HMGLTitle.Type
            ]
        }

    let HMGLZSmooth =
        Pattern.EnumStrings "HMGLZSmooth" [
            "fast"
            "best"
        ]

    let HMGLAlign =
        Pattern.EnumStrings "HMGLAlign" [
            "left"
            "right"
            "auto"
        ]

    let HMGLHoverLabel =
        Pattern.Config "HMGLHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", HMGLColor + !| HMGLColor
                "bordercolor", HMGLColor + !| HMGLColor
                "fonts", HMGLFont.Type
                "align", HMGLAlign.Type
                "namelength", T<int>
            ]
        }

    let HeatMapGLOptions = 
        Class "HeatMapGLOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'heatmapgl'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + HMGLVisibleString.Type
            "legendrank", T<float> + T<int>
            "legendgrouptitle", HMGLLegendGroupTitle.Type
            "opacity", (T<float> + T<int>)
            "ids", !| T<string> //data array
            "x", !| T<float> + !| T<int> + !| T<string> //data array
            "x0", (T<float> + T<int>) + !| T<string>
            "dx", (T<float> + T<int>)
            "xtype", HMGLXYType.Type
            "y", !| T<float> + !| T<int> + !| T<string> + !| (!| T<float> + !| T<int> + !| T<string>) + !| (!| (!| T<float> + !| T<int> + !| T<string>))    //data array
            "y0", (T<float> + T<int>) + !| T<string>
            "dy", (T<float> + T<int>)
            "ytype", HMGLXYType.Type
            "z", !| T<float> + !| T<int> + !| T<string> //data array
            "text", !| T<string> //data array
            "hoverinfo", HMGLHoverInfo.Type
            "meta", (T<float> + T<int>) + T<string>
            "customdata", !| T<string> //data array
            "xaxis", T<string> //subplotid
            "yaxis", T<string> //subplotid
            "coloraxis", T<string> //subplotid
            "colorbar", HMGLColorBar.Type
            "autocolorscale", T<bool>
            "colorscale", HMGLColorScale
            "showscale", T<bool>
            "reversescale", T<bool>
            "zauto", T<bool>
            "zmax", (T<float> + T<int>)
            "mid", (T<float> + T<int>)
            "min", (T<float> + T<int>)
            "zsmooth", HMGLZSmooth.Type + T<bool>
            "hoverlabel", HMGLHoverLabel.Type
            "transpose", T<bool>
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let HeatMapGLTraceNamespaces : CodeModel.NamespaceEntity list = [
        HMGLFont
        HMGLNullValue
        HMGLVisibleString
        HMGLLegendGroupTitle
        HMGLXYType
        HMGLHoverInfo
        HMGLPeriodAlignment
        HMGLColorBarMode
        HMGLXAnchor
        HMGLYAnchor
        HMGLTickMode
        HMGLTicks
        HMGLTickFormatStops
        HMGLTickLabelOverflow
        HMGLTickLabelPosition
        HMGLShowTickFix
        HMGLExponentFormat
        HMGLSide
        HMGLTitle
        HMGLColorBar
        HMGLZSmooth
        HMGLAlign
        HMGLHoverLabel
        HeatMapOptions
    ]
