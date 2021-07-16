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

module Scatter3DModule =

    let Scatter3DNullValue = Pattern.EnumInlines "Scatter3DNullValue" ["null", "null"]

    let Scatter3DColor = T<string> + (T<float> + T<int>) + (!| (!? (Scatter3DNullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (Scatter3DNullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let Scatter3DColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let Scatter3DVisibleString = Pattern.EnumStrings "Scatter3DVisibleString" ["legendonly"]

    let Scatter3DFont =
        Pattern.Config "Scatter3DFont" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", Scatter3DColor
            ]
        }

    let Scatter3DLegendGroupTitle =
        Pattern.Config "Scatter3DLegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", Scatter3DFont.Type
            ]
        }

    let Scatter3DModes =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["lines"; "markers"; "text"] '+')
            let seq2 = seq{"none"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "Scatter3DModes" generatedEnum

    let Scatter3DTextPosition =
        Pattern.EnumInlines "Scatter3DTextPosition" [
            "TopLeft", "'top left'"
            "TopCenter", "'top center'"
            "TopRight", "'top right'"
            "MiddleLeft", "'middle left'"
            "MiddleCenter", "'middle center'"
            "MiddleRight", "'middle right'"
            "BottomLeft", "'bottom left'"
            "BottomCenter", "'bottom center'"
            "BottomRight", "'bottom right'"
        ]

    let Scatter3DHoverInfo =
        let generatedEnum =
            let seq1 = (GenerateOptions.allPermutations ["x"; "y"; "z"; "text"; "name"] '+')
            let seq2 = seq{"all"; "none"; "skip"}
            Seq.append seq1 seq2
        Pattern.EnumStrings "Scatter3DHoverInfo" generatedEnum

    let Scatter3DSizeMode =
        Pattern.EnumStrings "Scatter3DSizeMode" [
            "diameter"
            "area"
        ]

    let Scatter3DMarkerLine =
        Pattern.Config "Scatter3DMarkerLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>) + !| T<float> + !| T<int>
                "color", Scatter3DColor
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", Scatter3DColorScale
                "autocolorscale", T<bool>
                "reversescale", T<bool>
                "coloraxis", T<string> // type: subplotid
                "opacity", T<float>
            ]
        }

    let Scatter3DColorBarMode =
        Pattern.EnumStrings "Scatter3DThicknessMode" [
            "fraction"
            "pixels"
        ]

    let Scatter3DXAnchor =
        Pattern.EnumStrings "Scatter3DXAnchor" [
            "left"
            "center"
            "right"
        ]

    let Scatter3DYAnchor =
        Pattern.EnumStrings "Scatter3DYAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let Scatter3DTickMode =
        Pattern.EnumStrings "Scatter3DTickMode" [
            "auto"
            "linear"
            "array"
        ]

    let Scatter3DTicks =
        Pattern.EnumInlines "Scatter3DTicks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let Scatter3DTickLabelOverflow =
        Pattern.EnumInlines "Scatter3DTickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide Past Domain'"
        ]

    let Scatter3DTickLabelPosition =
        Pattern.EnumInlines "Scatter3DTickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let DTickValue = (T<float> + T<int>) + T<string>

    let Scatter3DTickFormatStops =
        Pattern.Config "Scatter3DTickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + Scatter3DNullValue.Type) * (DTickValue + Scatter3DNullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let Scatter3DShowTickFix =
        Pattern.EnumStrings "Scatter3DShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ShowExponent = Scatter3DShowTickFix

    let Scatter3DExponentFormat =
        Pattern.EnumInlines "Scatter3DExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let Scatter3DSide =
        Pattern.EnumStrings "Scatter3DSide" [
            "right"
            "top"
            "bottom"
        ]

    let Scatter3DTitle =
        Pattern.Config "Scatter3DTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", Scatter3DFont.Type
                "side", Scatter3DSide.Type
            ]
        }

    let Scatter3DColorBar =
        Pattern.Config "Scatter3DColorBar" {
            Required = []
            Optional = [
                "thicknessmode", Scatter3DColorBarMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", Scatter3DColorBarMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", Scatter3DXAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", Scatter3DYAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", Scatter3DColor
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", Scatter3DColor
                "borderwidth", (T<float> + T<int>)
                "bgcolor", Scatter3DColor
                "tickmode", Scatter3DTickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", Scatter3DTicks.Type
                "ticklabeloverflow", Scatter3DTickLabelOverflow.Type
                "ticklabelposition", Scatter3DTickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", Scatter3DColor
                "showticklabels", T<bool>
                "tickfont", Scatter3DFont.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", Scatter3DTickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", Scatter3DShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", Scatter3DShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", Scatter3DExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowExponent.Type // change type name to fit
                "title", Scatter3DTitle.Type
            ]
        }

    let Scatter3DSymbol =
        Pattern.EnumStrings "Scatter3DSymbol" [
            "circle"
            "circle-open"
            "square"
            "square-open"
            "diamond"
            "diamond-open"
            "cross"
            "x"
        ]

    let Scatter3DMarker =
        Pattern.Config "Scatter3DMarker" {
            Required = []
            Optional = [
                "symbol", Scatter3DSymbol.Type
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "sizeref", (T<float> + T<int>)
                "sizemin", (T<float> + T<int>)
                "sizemode", Scatter3DSizeMode.Type
                "opacity", T<float> + !| T<float>
                "colorbar", Scatter3DColorBar.Type
                "line", Scatter3DMarkerLine.Type
                "color", Scatter3DColor + !| Scatter3DColor
                "cauto", T<bool>
                "cmin", (T<float> + T<int>)
                "cmax", (T<float> + T<int>)
                "cmid", (T<float> + T<int>)
                "colorscale", Scatter3DColorScale
                "autocolorscale", T<bool>
                "reverscale", T<bool>
                "showscale", T<bool>
                "coloraxis", T<string> // type: subplotid
            ]
        }

    let Scatter3DLine =
        Pattern.Config "Scatter3DLine" {
            Required = []
            Optional = [
                "width", (T<float> + T<int>)
                "dash", T<string>
                "color", Scatter3DColor
                "cauto", T<bool>
                "cmin", T<int> + T<float>
                "cmax", T<int> + T<float>
                "cmid", T<int> + T<float>
                "colorscale", Scatter3DColorScale
                "autocolorscale", T<bool>
                "reversescale", T<bool>
                "showscale", T<bool>
                "colorbar", Scatter3DColorBar.Type
                "coloraxis", T<string> //subplotid
            ]
        }

    let Scatter3DErrorType =
        Pattern.EnumStrings "Scatter3DErrorType" [
            "percent"
            "constant"
            "sqrt"
            "data"
        ]

    let Scatter3DErrorX = 
        Pattern.Config "Scatter3DErrorX" {
            Required = []
            Optional = [
                "visible", T<bool>
                "type", Scatter3DErrorType.Type
                "symmetric", T<bool>
                "array", !| T<obj> // data array
                "arrayminus", !| T<obj> // data array
                "value", (T<float> + T<int>)
                "valueminus", (T<float> + T<int>)
                "traceref", T<int>
                "tracerefminus", T<int>
                "copy_zstyle", T<bool>
                "color", Scatter3DColor
                "thickness", (T<float> + T<int>)
                "width", (T<float> + T<int>)
            ]
        }

    let Scatter3DErrorY = 
        Pattern.Config "Scatter3DErrorY" {
            Required = []
            Optional = [
                "visible", T<bool>
                "type", Scatter3DErrorType.Type
                "symmetric", T<bool>
                "array", !| T<obj> // data array
                "arrayminus", !| T<obj> // data array
                "value", (T<float> + T<int>)
                "valueminus", (T<float> + T<int>)
                "traceref", T<int>
                "tracerefminus", T<int>
                "copy_zstyle", T<bool>
                "color", Scatter3DColor
                "thickness", (T<float> + T<int>)
                "width", (T<float> + T<int>)
            ]
        }

    let Scatter3DErrorZ = 
        Pattern.Config "Scatter3DErrorZ" {
            Required = []
            Optional = [
                "visible", T<bool>
                "type", Scatter3DErrorType.Type
                "symmetric", T<bool>
                "array", !| T<obj> // data array
                "arrayminus", !| T<obj> // data array
                "value", (T<float> + T<int>)
                "valueminus", (T<float> + T<int>)
                "traceref", T<int>
                "tracerefminus", T<int>
                "color", Scatter3DColor
                "thickness", (T<float> + T<int>)
                "width", (T<float> + T<int>)
            ]
        }

    let Scatter3DAlign =
        Pattern.EnumStrings "Scatter3DAlign" [
            "left"
            "right"
            "auto"
        ]

    let Scatter3DHoverLabel =
        Pattern.Config "Scatter3DHoverLabel" {
            Required = []
            Optional = [
                "bgcolor", Scatter3DColor + !| Scatter3DColor
                "bordercolor", Scatter3DColor + !| Scatter3DColor
                "fonts", Scatter3DFont.Type
                "align", Scatter3DAlign.Type
                "namelength", T<int>
            ]
        }

    let Scatter3DCalendar =
        Pattern.EnumStrings "Scatter3DCalendar" [
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

    let Scatter3DProjectionXYZ =
        Pattern.Config "Scatter3DProjectionXYZ" {
            Required = []
            Optional = [
                "show", T<bool>
                "opacity", T<float>
                "scale", T<int> + T<float>
            ]
        }

    let Scatter3DProjection =
        Pattern.Config "Scatter3DProjection" {
            Required = []
            Optional = [
                "x", Scatter3DProjectionXYZ.Type
                "y", Scatter3DProjectionXYZ.Type
                "z", Scatter3DProjectionXYZ.Type
            ]
        }

    let Scatter3DSurfaceAxis =
        Pattern.EnumStrings "Scatter3DSurfaceAxis" [
            "-1"
            "0"
            "1"
            "2"
        ]

    let Scatter3DOptions =
        Class "Scatter3DOptions"
        |+> Static [
            Constructor T<unit>
            |> WithInline "{type:'scatter3d'}"
        ]
        |+> Pattern.OptionalFields [
            "name", T<string>
            "visible", T<bool> + Scatter3DVisibleString.Type
            "showlegend", T<bool>
            "legendrank", (T<float> + T<int>)
            "legendgroup", T<string>
            "legendgrouptitle", Scatter3DLegendGroupTitle.Type
            "opacity", T<float>
            "mode", Scatter3DModes.Type
            "ids", !| T<string>
            "x", !| T<int> + !| T<float>
            "y", !| T<int> + !| T<float>
            "z", !| T<int> + !| T<float>
            "surfacecolor", Scatter3DColor
            "text", T<string> + !| T<string>
            "textposition", Scatter3DTextPosition.Type
            "texttemplate", T<string> + !| T<string>
            "hovertext", T<string> + !| T<string>
            "hoverinfo", Scatter3DHoverInfo.Type
            "hovertemplate", T<string> + !| T<string>
            "xhoverformat", T<string>
            "yhoverformat", T<string>
            "meta", (T<float> + T<int>) + T<string>
            "customdata", T<string> // undefined type, string is placeholder
            "scene", T<string> //subplotid
            "marker", Scatter3DMarker.Type
            "line", Scatter3DLine.Type
            "textfont", Scatter3DFont.Type
            "error_x", Scatter3DErrorX.Type
            "error_y", Scatter3DErrorY.Type
            "error_z", Scatter3DErrorZ.Type
            "zhoverformat", T<string>
            "connectgaps", T<bool>
            "hoverlabel", Scatter3DHoverLabel.Type
            "projection", Scatter3DProjection.Type
            "surfaceaxis", Scatter3DSurfaceAxis.Type
            "xcalendar", Scatter3DCalendar.Type
            "ycalendar", Scatter3DCalendar.Type
            "zcalendar", Scatter3DCalendar.Type
            "uirevision", (T<float> + T<int>) + T<string>
        ]

    let Scatter3DTraceNamespaces : CodeModel.NamespaceEntity list = [
        Scatter3DNullValue
        Scatter3DVisibleString
        Scatter3DFont
        Scatter3DLegendGroupTitle
        Scatter3DModes
        Scatter3DTextPosition
        Scatter3DHoverInfo
        Scatter3DSizeMode
        Scatter3DMarkerLine
        Scatter3DColorBarMode
        Scatter3DXAnchor
        Scatter3DYAnchor
        Scatter3DTickMode
        Scatter3DTicks
        Scatter3DTickLabelOverflow
        Scatter3DTickLabelPosition
        Scatter3DTickFormatStops
        Scatter3DShowTickFix
        Scatter3DExponentFormat
        Scatter3DSide
        Scatter3DTitle
        Scatter3DColorBar
        Scatter3DSymbol
        Scatter3DMarker
        Scatter3DLine
        Scatter3DErrorType
        Scatter3DErrorX
        Scatter3DErrorY
        Scatter3DErrorZ
        Scatter3DAlign
        Scatter3DHoverLabel
        Scatter3DCalendar
        Scatter3DProjectionXYZ
        Scatter3DProjection
        Scatter3DSurfaceAxis
        Scatter3DOptions
    ]