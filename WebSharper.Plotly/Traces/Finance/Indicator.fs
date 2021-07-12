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

module IndicatorModule =

    let IndicatorNullValue = Pattern.EnumInlines "IndicatorNullValue" ["null", "null"]

    let IndicatorColor = T<string> + (T<float> + T<int>) + (!| (!? (IndicatorNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (IndicatorNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let IndicatorVisibleString = Pattern.EnumStrings "IndicatorVisibleString" ["legendonly"]

    let IndicatorFont =
        Pattern.Config "IndicatorFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", IndicatorColor
            ]
        }

    let IndicatorLegendGroupTitle =
        Pattern.Config "IndicatorLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", IndicatorFont.Type
            ]
        }

    let IndicatorAlign =
        Pattern.EnumStrings "IndicatorAlign" [
            "left"
            "center"
            "right"
        ]

    let IndicatorTitlePosition =
        Pattern.EnumInlines "IndicatorTitlePosition" [
            "topLeft", "top left"
            "topCenter", "top center"
            "topRight", "top right"
        ]

    let IndicatorTitle =
        Pattern.Config "IndicatorTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", IndicatorFont.Type
                "position", IndicatorTitlePosition.Type
            ]
        }

    let IndicatorDomain =
        Pattern.Config "IndicatorDomain" {
            Required = []
            Optional = [
                "x", !| T<string> + !| T<int> + !| T<float>
                "y", !| T<string> + !| T<int> + !| T<float>
                "row", T<int>
                "column", T<int>
            ]
        }

    let IndicatorMode =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["number"; "delta"; "gauge"] '+')
        Pattern.EnumStrings "IndicatorMode" generatedEnum

    let IndicatorDeltaPosition =
        Pattern.EnumStrings "IndicatorDeltaPosition" [
            "top"
            "bottom"
            "left"
            "right"
        ]

    let IndicatorDeltaCreasing =
        Pattern.Config "IndicatorDeltaCreasing" {
            Required = []
            Optional = [
                "symbol", T<string>
                "color", IndicatorColor
            ]
        }

    let IndicatorDelta =
        Pattern.Config "IndicatorDelta" {
            Required = []
            Optional = [
                "reference", T<int> + T<float>
                "position", IndicatorDeltaPosition.Type
                "relative", T<bool>
                "valuformat", T<string>
                "increasing", IndicatorDeltaCreasing.Type
                "decreasing", IndicatorDeltaCreasing.Type
                "font", IndicatorFont.Type
            ]
        }

    let IndicatorNumber =
        Pattern.Config "IndicatorNumber" {
            Required = []
            Optional = [
                "valueformat", T<string>
                "font", IndicatorFont.Type
            ]
        }

    let IndicatorGaugeShape =
        Pattern.EnumStrings "IndicatorGaugeShape" [
            "angular"
            "bullet"
        ]

    let IndicatorGaugeLine =
        Pattern.Config "IndicatorGaugeLine" {
            Required = []
            Optional = [
                "color", IndicatorColor
                "width", T<int> + T<float>
            ]
        }

    let IndicatorGaugeBar =
        Pattern.Config "IndicatorGaugeBar" {
            Required = []
            Optional = [
                "color", IndicatorColor
                "line", IndicatorGaugeLine.Type
                "thickness", T<float>
            ]
        }

    let IndicatorGaugeAxisTickMode =
        Pattern.EnumStrings "IndicatorGaugeAxisTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let IndicatorGaugeAxisTicks =
        Pattern.EnumInlines "IndicatorGaugeAxisTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let IndicatorGaugeAxisTFS =
        Pattern.Config "IndicatorGaugeAxisTFS" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| T<int> + !| T<float> + !| T<string>
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let IndicatorGaugeAxisSTF =
        Pattern.EnumStrings "IndicatorGaugeAxisSTF" [
            "all"
            "first"
            "last"
            "none"
        ]

    let IndicatorGaugeAxisEF =
        Pattern.EnumInlines "BarExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"

    let IndicatorGaugeAxis =
        Pattern.Config "IndicatorGaugeAxis" {
            Required = []
            Optional = [
                "range", !| T<int> + !| T<float> + !| T<string>
                "visible", T<bool>
                "tickmode", IndicatorGaugeAxisTickMode.Type
                "nticks", T<int>
                "tick0", T<int> + T<float> + T<string>
                "dtick", T<int> + T<float> + T<string>
                "tickvals", !| T<int> + !| T<float> + !| T<string>
                "ticktext", !| T<int> + !| T<float> + !| T<string>
                "ticks", IndicatorGaugeAxisTicks.Type
                "ticklen", T<int> + T<float>
                "tickwidth", T<int> + T<float>
                "tickcolor", IndicatorColor
                "showticklabels", T<bool>
                "tickfont", IndicatorFont.Type
                "tickangle", T<int> + T<float>
                "tickformat", T<string>
                "tickformatstops", IndicatorGaugeAxisTFS.Type
                "tickprefix", T<string>
                "showtickprefix", IndicatorGaugeAxisSTF.Type
                "ticksuffix", T<string>
                "showticksuffix", IndicatorGaugeAxisSTF.Type
                "separatethousands", T<bool>
                "exponentformat", IndicatorGaugeAxisEF.Type
                "minexponent", T<int> + T<float>
                "showexponent", IndicatorGaugeAxisEF.Type
            ]
        }

    let IndicatorGaugeSteps =
        Pattern.Config "IndicatorGaugeSteps" {
            Required = []
            Optional = [
                "color", IndicatorColor
                "line", IndicatorGaugeLine.Type
                "thickness", T<float>
                "range", !| T<int> + !| T<float> + !| T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let IndicatorGaugeTreshold =
        Pattern.Config "IndicatorGaugeTreshold" {
            Required = []
            Optional = [
                "line", IndicatorGaugeLine.Type
                "thickness", T<float>
                "value", T<int> + T<float>
            ]
        }

    let IndicatorGauge =
        Pattern.Config "IndicatorGauge" {
            Required = []
            Optional = [
                "shape", IndicatorGaugeShape.Type
                "bar", IndicatorGaugeBar.Type
                "bgcolor", IndicatorColor
                "bordercolor", IndicatorColor
                "borderwidth", T<int> + T<float>
                "axis", IndicatorGaugeAxis.Type
                "steps", IndicatorGaugeSteps.Type
                "treshold", IndicatorGaugeTreshold.Type
            ]
        }

    let IndicatorOptions =
        Class "IndicatorOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'indicator'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "title" IndicatorTitle.Type
            "visible", T<bool> + IndicatorVisibleString.Type
            "legendrank", (T<float> + T<int>)
            "legendgrouptitle", IndicatorLegendGroupTitle.Type
            "mode", IndicatorMode.Type
            "ids", !| T<string>
            "value", T<int> + T<float>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "domain", IndicatorDomain.Type
            "align", IndicatorAlign.Type
            "delta", IndicatorDelta.Type
            "number", IndicatorNumber.Type
            "gauge", IndicatorGauge.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let IndicatorTraceNamespaces : CodeModel.NamespaceEntity list = [
        IndicatorNullValue
        IndicatorVisibleString
        IndicatorFont
        IndicatorLegendGroupTitle
        IndicatorAlign
        IndicatorTitlePosition
        IndicatorTitle
        IndicatorDomain
        IndicatorMode
        IndicatorDeltaPosition
        IndicatorDeltaCreasing
        IndicatorDelta
        IndicatorNumber
        IndicatorGaugeShape
        IndicatorGaugeLine
        IndicatorGaugeBar
        IndicatorGaugeAxisTickMode
        IndicatorGaugeAxisTicks
        IndicatorGaugeAxisTFS
        IndicatorGaugeAxisSTF
        IndicatorGaugeAxisEF
        IndicatorGaugeAxis
        IndicatorGaugeSteps
        IndicatorGaugeTreshold
        IndicatorGauge
        IndicatorOptions
    ]