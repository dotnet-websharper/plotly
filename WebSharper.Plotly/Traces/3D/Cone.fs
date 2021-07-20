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

module ConeModule =

    let ConeNullValue = Pattern.EnumInlines "ConeNullValue" ["null", "null"]

    let ConeColor = T<string> + (T<float> + T<int>) + (!| (!? (ConeNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (ConeNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let ConeColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let ConeVisibleString = Pattern.EnumStrings "ConeVisibleString" ["legendonly"]

    let ConeFont =
        Pattern.Config "ConeFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", ConeColor
            ]
        }

    let ConeLegendGroupTitle =
        Pattern.Config "ConeLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ConeFont.Type
            ]
        }

    (*let ConeHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "u"; "v"; "w"; "norm"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "ConeHoverInfo" generatedEnum*)

    let ConeColorBarMode =
        Pattern.EnumStrings "ConeThicknessMode" [
            "fraction"
            "pixels"
        ]

    let ConeXAnchor =
        Pattern.EnumStrings "ConeXAnchor" [
            "left"
            "center"
            "right"
        ]

    let ConeYAnchor =
        Pattern.EnumStrings "ConeYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let ConeTickMode =
        Pattern.EnumStrings "ConeTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let ConeTicks =
        Pattern.EnumInlines "ConeTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let ConeTickLabelOverflow =
        Pattern.EnumInlines "ConeTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide past domain'"
        ]

    let ConeTickLabelPosition =
        Pattern.EnumInlines "ConeTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let ConeTickFormatStops =
        Pattern.Config "ConeTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + ConeNullValue.Type) * (DTickValue + ConeNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let ConeShowTickFix =
        Pattern.EnumStrings "ConeShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = ConeShowTickFix

    let ConeExponentFormat =
        Pattern.EnumInlines "ConeExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let ConeSide =
        Pattern.EnumStrings "ConeSide" [
            "right"
            "top"
            "bottom"
        ]

    let ConeTitle =
        Pattern.Config "ConeTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", ConeFont.Type
                "side", ConeSide.Type
            ]
        }

    let ConeColorBar =
        Pattern.Config "ConeColorBar" {
            Required = []
            Optional = [
                "thicknessmode", ConeColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", ConeColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", ConeXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", ConeYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", ConeColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", ConeColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", ConeColor
                "tickmode", ConeTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", ConeTicks.Type
                "ticklabeloverflow", ConeTickLabelOverflow.Type
                "ticklabelposition", ConeTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", ConeColor
                "showticklabels", T<bool>
                "tickfont", ConeFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", ConeTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", ConeShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", ConeShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", ConeExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", ConeTitle.Type
            ]
        }

    let ConeAlign =
        Pattern.EnumStrings "ConeAlign" [
            "left"
            "right"
            "auto"
        ]

    let ConeHoverLabel =
        Pattern.Config "ConeHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", ConeColor + !| ConeColor
                "bordercolor", ConeColor + !| ConeColor
                "fonts", ConeFont.Type
                "align", ConeAlign.Type
                "namelength", T<int>
            ]
        }

    let ConeLighting =
        Pattern.Config "ConeLighting" {
            Required = []
            Optional = [
                "vertexnormalsepsilon", T<float>
                "facenormalsepsilon", T<float>
                "ambient", T<float>
                "diffuse", T<float>
                "specular", T<float>
                "roughness", T<float>
                "fresnel", T<float>
            ]        
        }

    let ConeLightPosition =
        Pattern.Config "ConeLightPosition" {
            Required = []
            Optional = [
                "x", T<int> + T<float>
                "y", T<int> + T<float>
                "z", T<int> + T<float>
            ]
        }

    let ConeAnchor =
        Pattern.EnumStrings "ConeAnchor" [
            "tip"
            "tail"
            "cm"
            "center"
        ]

    let ConeSizeMode =
        Pattern.EnumStrings "ConeSizeMode" [
            "scaled"
            "absolute"
        ]

    let ConeOptions =        
        Class "ConeOptions"
        |=> Inherits CommonModule.Trace
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'cone'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + ConeVisibleString.Type
            "showlegend", T<bool>
            "legendrank", T<float> + T<int>
            "legendgroup", T<string>
            "legendgrouptitle", ConeLegendGroupTitle.Type
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
            "hoverinfo", T<string> //ConeHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "uhoverformat", T<string>
            "vhoverformat", T<string>
            "whoverformat", T<string>
            "meta", T<float> + T<int> + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "scene", T<string> //subplotid
            "coloraxis", T<string> // type: subplotid
            "colorbar", ConeColorBar.Type
            "autocolorscale", T<bool>
            "colorscale", ConeColorScale
            "showscale", T<bool>
            "reverscale", T<bool>
            "zhoverformat", T<string>
            "cauto", T<bool>
            "cmax", T<int> + T<float>
            "cmid", T<int> + T<float>
            "cmin", T<int> + T<float>
            "anchor", ConeAnchor.Type
            "hoverlabel", ConeHoverLabel.Type
            "lighting", ConeLighting.Type
            "lightposition", ConeLightPosition.Type
            "sizemode", ConeSizeMode.Type
            "sizeref", T<int> + T<float>
            "uirevision", T<float> + T<int> + T<string>
        ]

    let ConeTraceNamespaces : CodeModel.NamespaceEntity list = [
        ConeNullValue
        ConeVisibleString
        ConeFont
        ConeLegendGroupTitle
        //ConeHoverInfo
        ConeColorBarMode
        ConeXAnchor
        ConeYAnchor
        ConeTickMode
        ConeTicks
        ConeTickLabelOverflow
        ConeTickLabelPosition
        ConeTickFormatStops
        ConeShowTickFix
        ConeExponentFormat
        ConeSide
        ConeTitle
        ConeColorBar
        ConeAlign
        ConeHoverLabel
        ConeLighting
        ConeLightPosition
        ConeAnchor
        ConeSizeMode
        ConeOptions
    ]