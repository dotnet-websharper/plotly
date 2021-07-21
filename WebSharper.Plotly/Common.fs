namespace WebSharper.Plotly.Extension.Common

open WebSharper
open WebSharper.InterfaceGenerator

module CommonModule =

    let Trace =
        Class "Trace"

    let NullValue = Pattern.EnumInlines "nullValue" ["null", "null"]

    let Color = T<string> + (T<float> + T<int>) + (!| (!? (NullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (NullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let ColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let VisibleString = Pattern.EnumStrings "visibleString" ["legendonly"]

    let Font =
        Pattern.Config "font" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", Color
            ]
        }

    let LegendGroupTitle =
        Pattern.Config "legendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", Font.Type
            ]
        }

    let TextPosition =
        Pattern.EnumStrings "textPosition" [
            "inside"
            "outside"
            "auto"
            "none"
        ]
    
    let Orientation =
        Pattern.EnumStrings "orientation" [
            "v"
            "h"
        ]

    let ErrorType =
        Pattern.EnumStrings "errorType" [
            "percent"
            "constant"
            "sqrt"
            "data"
        ]
    
    let Calendar =
        Pattern.EnumStrings "calendar" [
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

    let DTickValue = (T<float> + T<int>) + T<string>

    let ThicknessMode =
        Pattern.EnumStrings "ThicknessMode" [
            "fraction"
            "pixels"
        ]

    let XAnchor =
        Pattern.EnumStrings "XAnchor" [
            "left"
            "center"
            "right"
        ]

    let YAnchor =
        Pattern.EnumStrings "YAnchor" [
            "top"
            "middle"
            "bottom"
        ]

    let TickMode =
        Pattern.EnumStrings "TickMode" [
            "auto"
            "linear"
            "array"
        ]

    let Ticks =
        Pattern.EnumInlines "Ticks" [
            "outside", "'outside'"
            "inside", "'inside'"
            "empty", "''"
        ]

    let TickLabelOverflow =
        Pattern.EnumInlines "TickLabelOverflow" [
            "allow", "'allow'"
            "hidePastDiv", "'hide past div'"
            "hidePastDomain", "'hide past domain'"
        ]

    let TickLabelPosition =
        Pattern.EnumInlines "TickLabelPosition" [
            "outside", "'outside'"
            "inside", "'inside'"
            "outsideTop", "'outside top'"
            "insideTop", "'inside top'"
            "outsideBottom", "'outside bottom'"
            "insideBottom", "'inside bottom'"
        ]

    let TickFormatStops =
        Pattern.Config "TickFormatStops" {
            Required = []
            Optional = [
                "enabled", T<bool>
                "dtickrange", !| ((DTickValue + NullValue.Type) * (DTickValue + NullValue.Type))
                "value", T<string>
                "name", T<string>
                "templateitemname", T<string>
            ]
        }

    let ShowTickFix =
        Pattern.EnumStrings "ShowTickFix" [
            "all"
            "first"
            "last"
            "none"
        ]

    let ExponentFormat =
        Pattern.EnumInlines "ExponentFormat" [
            "none", "'none'"
            "Lowercase_E", "'e'"
            "Uppercase_E", "'E'"
            "power", "'power'"
            "SI", "'SI'"
            "B", "'B'"
        ]

    let Side =
        Pattern.EnumStrings "Side" [
            "right"
            "top"
            "bottom"
        ]

    let Title =
        Pattern.Config "Title" {
            Required = []
            Optional = [
                "text", T<string>
                "font", Font.Type
                "side", Side.Type
            ]
        }

    let ColorBar =
        Pattern.Config "ColorBar" {
            Required = []
            Optional = [
                "thicknessmode", ThicknessMode.Type
                "thickness", (T<float> + T<int>)
                "lenmode", ThicknessMode.Type
                "len", (T<float> + T<int>)
                "x", T<float>
                "xanchor", XAnchor.Type
                "xpad", (T<float> + T<int>)
                "y", T<float>
                "yanchor", YAnchor.Type
                "ypad", (T<float> + T<int>)
                "outlinecolor", Color
                "outlinewidth", (T<float> + T<int>)
                "bordercolor", Color
                "borderwidth", (T<float> + T<int>)
                "bgcolor", Color
                "tickmode", TickMode.Type
                "nticks", T<int>
                "tick0", (T<float> + T<int>) + T<string>
                "dtick", (T<float> + T<int>) + T<string>
                "tickvals", !| T<obj>
                "ticktext", !| T<string> 
                "ticks", Ticks.Type
                "ticklabeloverflow", TickLabelOverflow.Type
                "ticklabelposition", TickLabelPosition.Type
                "ticklen", (T<float> + T<int>)
                "tickwidth", (T<float> + T<int>)
                "tickcolor", Color
                "showticklabels", T<bool>
                "tickfont", Font.Type
                "tickangle", (T<float> + T<int>) //type: Angle
                "tickformat", T<string>
                "tickformatstops", TickFormatStops.Type
                "tickprefix", T<string>
                "showtickprefix", ShowTickFix.Type
                "ticksuffix", T<string>
                "showticksuffix", ShowTickFix.Type
                "separatethousands", T<bool>
                "exponentformat", ExponentFormat.Type
                "minexponent", (T<float> + T<int>)
                "showexponent", ShowTickFix.Type
                "title", Title.Type
            ]
        }

    let Align =
        Pattern.EnumStrings "Align" [
            "left"
            "right"
            "auto"
        ]

    let HoverLabel =
        Pattern.Config "HoverLabel" {
            Required = []
            Optional = [
                "bgcolor", Color + !| Color
                "bordercolor", Color + !| Color
                "fonts", Font.Type
                "align", Align.Type
                "namelength", T<int>
            ]
        }

    let CommonNamespaces : CodeModel.NamespaceEntity list = [
        Trace
        VisibleString
        Font
        LegendGroupTitle
        TextPosition
        Orientation
        ErrorType
        Calendar
        ThicknessMode
        XAnchor
        YAnchor
        TickMode
        Ticks
        TickLabelOverflow
        TickLabelPosition
        TickFormatStops
        ShowTickFix
        ExponentFormat
        Side
        Title
        ColorBar
        Align
        HoverLabel
    ]