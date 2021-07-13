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

module StreamTubeModule =

    let StreamTubeNullValue = Pattern.EnumInlines "StreamTubeNullValue" ["null", "null"]

    let StreamTubeColor = T<string> + (T<float> + T<int>) + (!| (!? (StreamTubeNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (StreamTubeNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let StreamTubeColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let StreamTubeVisibleString = Pattern.EnumStrings "StreamTubeVisibleString" ["legendonly"]

    let StreamTubeFont =
        Pattern.Config "StreamTubeFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", StreamTubeColor
            ]
        }

    let StreamTubeLegendGroupTitle =
        Pattern.Config "StreamTubeLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", StreamTubeFont.Type
            ]
        }

    let StreamTubeHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "u"; "v"; "w"; "norm"; "divergence"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "StreamTubeHoverInfo" generatedEnum

    let StreamTubeColorBarMode =
        Pattern.EnumStrings "StreamTubeThicknessMode" [
            "fraction"
            "pixels"
        ]

    let StreamTubeXAnchor =
        Pattern.EnumStrings "StreamTubeXAnchor" [
            "left"
            "center"
            "right"
        ]

    let StreamTubeYAnchor =
        Pattern.EnumStrings "StreamTubeYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let StreamTubeTickMode =
        Pattern.EnumStrings "StreamTubeTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let StreamTubeTicks =
        Pattern.EnumInlines "StreamTubeTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let StreamTubeTickLabelOverflow =
        Pattern.EnumInlines "StreamTubeTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let StreamTubeTickLabelPosition =
        Pattern.EnumInlines "StreamTubeTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let StreamTubeTickFormatStops =
        Pattern.Config "StreamTubeTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + StreamTubeNullValue.Type) * (DTickValue + StreamTubeNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let StreamTubeShowTickFix =
        Pattern.EnumStrings "StreamTubeShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = StreamTubeShowTickFix

    let StreamTubeExponentFormat =
        Pattern.EnumInlines "StreamTubeExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let StreamTubeSide =
        Pattern.EnumStrings "StreamTubeSide" [
            "right"
            "top"
            "bottom"
        ]

    let StreamTubeTitle =
        Pattern.Config "StreamTubeTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", StreamTubeFont.Type
                "side", StreamTubeSide.Type
            ]
        }

    let StreamTubeColorBar =
        Pattern.Config "StreamTubeColorBar" {
            Required = []
            Optional = [
                "thicknessmode", StreamTubeColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", StreamTubeColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", StreamTubeXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", StreamTubeYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", StreamTubeColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", StreamTubeColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", StreamTubeColor
                "tickmode", StreamTubeTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", StreamTubeTicks.Type
                "ticklabeloverflow", StreamTubeTickLabelOverflow.Type
                "ticklabelposition", StreamTubeTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", StreamTubeColor
                "showticklabels", T<bool>
                "tickfont", StreamTubeFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", StreamTubeTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", StreamTubeShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", StreamTubeShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", StreamTubeExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", StreamTubeTitle.Type
            ]
        }

    let StreamTubeAlign =
        Pattern.EnumStrings "StreamTubeAlign" [
            "left"
            "right"
            "auto"
        ]

    let StreamTubeHoverLabel =
        Pattern.Config "StreamTubeHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", StreamTubeColor + !| StreamTubeColor
                "bordercolor", StreamTubeColor + !| StreamTubeColor
                "fonts", StreamTubeFont.Type
                "align", StreamTubeAlign.Type
                "namelength", T<int>
            ]
        }
,
    let StreamTubeLighting =
        Pattern.Config "StreamTubeLighting" {
            Required = []
            Optional = [
                "ambient", T<float>
                "diffuse", T<float>
                "specular", T<float>
                "roughness", T<float>
                "fresnel", T<float>
            ]        
        }

    let StreamTubeLightPosition =
        Pattern.Config "StreamTubeLightPosition" {
            Required = []
            Optional = [
                "x", T<int> + T<float>
                "y", T<int> + T<float>
                "z", T<int> + T<float>
            ]
        }

    let StreamTubeStarts =
        Pattern.Config "StreamTubeStarts" {
            Required = []
            Optional = [
                "x", !| T<int> + !| T<float> //data array
                "y", !| T<int> + !| T<float> //data array
                "z", !| T<int> + !| T<float> //data array
            ]
        }

    let StreamTubeOptions =
        Class "StreamTubeOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'streamtube'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + StreamTubeVisibleString.Type
            "showlegend", T<bool>
            "legendrank", T<float> + T<int>
            "legendgroup", T<string>
            "legendgrouptitle", StreamTubeLegendGroupTitle.Type
            "opacity", T<float>
            "ids", !| T<string>
            "x", !| T<int> + !| T<float> //data array
            "y", !| T<int> + !| T<float> //data array
            "z", !| T<int> + !| T<float> //data array
            "u", !| T<int> + !| T<float> //data array
            "v", !| T<int> + !| T<float> //data array
            "w", !| T<int> + !| T<float> //data array
            "text", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", StreamTubeHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "uhoverformat", T<string>
            "vhoverformat", T<string>
            "whoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "scene", T<string> //subplotid
            "coloraxis", T<string> // type: subplotid
            "colorbar", StreamTubeColorBar.Type
            "autocolorscale", T<bool>
            "colorscale", StreamTubeColorScale
            "showscale", T<bool>
            "reverscale", T<bool>
            "zhoverformat", T<string>
            "cauto", T<bool>
            "cmax", T<int> + T<float>
            "cmid", T<int> + T<float>
            "cmin", T<int> + T<float>
            "hoverlabel", StreamTubeHoverLabel.Type
            "lighting", StreamTubeLighting.Type
            "lightposition", StreamTubeLightPosition.Type
            "maxdisplayed", T<int>
            "sizeref", T<int> + T<float>
            "starts", StreamTubeStarts.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let StreamTubeTraceNamespaces : CodeModel.NamespaceEntity list = [
        StreamTubeNullValue
        StreamTubeVisibleString
        StreamTubeFont
        StreamTubeLegendGroupTitle
        StreamTubeHoverInfo
        StreamTubeColorBarMode
        StreamTubeXAnchor
        StreamTubeYAnchor
        StreamTubeTickMode
        StreamTubeTicks
        StreamTubeTickLabelOverflow
        StreamTubeTickLabelPosition
        StreamTubeTickFormatStops
        StreamTubeShowTickFix
        ShowExponent
        StreamTubeExponentFormat
        StreamTubeSide
        StreamTubeTitle
        StreamTubeColorBar
        StreamTubeAlign
        StreamTubeHoverLabel
        StreamTubeLighting
        StreamTubeLightPosition
        StreamTubeStarts
        StreamTubeOptions
    ]