namespace WebSharper.Plotly.Extension.Common

open WebSharper
open WebSharper.InterfaceGenerator

module CommonModule =

    let Trace =
        Class "Trace"

    let NullValue = Pattern.EnumInlines "nullValue" ["null", "null"]

    let Color = T<string> + (T<float> + T<int>) + (!| (!? (NullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (NullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let ColorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let VisibleString = Pattern.EnumStrings "VisibleString" ["legendonly"]

    let Font =
        Pattern.Config "Font" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", Color
            ]
        }

    let LegendGroupTitle =
        Pattern.Config "LegendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", Font.Type
            ]
        }

    let TextPositionEnum =
        Pattern.EnumStrings "TextPositionEnum" [
            "inside"
            "outside"
            "auto"
            "none"
        ]

    let TextPositionInline =
        Pattern.EnumInlines "TextPositionInline" [
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
    
    let Orientation =
        Pattern.EnumStrings "Orientation" [
            "v"
            "h"
        ]

    let ErrorType =
        Pattern.EnumStrings "ErrorType" [
            "percent"
            "constant"
            "sqrt"
            "data"
        ]
    
    let Calendar =
        Pattern.EnumStrings "Calendar" [
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

    let Symbol =
        Pattern.EnumStrings "Symbol" [
            "0"
            "circle"
            "100"
            "circle-open"
            "200"
            "circle-dot"
            "300"
            "circle-open-dot"
            "1"
            "square"
            "101"
            "square-open"
            "201"
            "square-dot"
            "301"
            "square-open-dot"
            "2"
            "diamond"
            "102"
            "diamond-open"
            "202"
            "diamond-dot"
            "302"
            "diamond-open-dot"
            "3"
            "cross"
            "103"
            "cross-open"
            "203"
            "cross-dot"
            "303"
            "cross-open-dot"
            "4"
            "x"
            "104"
            "x-open"
            "204"
            "x-dot"
            "304"
            "x-open-dot"
            "5"
            "triangle-up"
            "105"
            "triangle-up-open"
            "205"
            "triangle-up-dot"
            "305"
            "triangle-up-open-dot"
            "6"
            "triangle-down"
            "106"
            "triangle-down-open"
            "206"
            "triangle-down-dot"
            "306"
            "triangle-down-open-dot"
            "7"
            "triangle-left"
            "107"
            "triangle-left-open"
            "207"
            "triangle-left-dot"
            "307"
            "triangle-left-open-dot"
            "8"
            "triangle-right"
            "108"
            "triangle-right-open"
            "208"
            "triangle-right-dot"
            "308"
            "triangle-right-open-dot"
            "9"
            "triangle-ne"
            "109"
            "triangle-ne-open"
            "209"
            "triangle-ne-dot"
            "309"
            "triangle-ne-open-dot"
            "10"
            "triangle-se"
            "110"
            "triangle-se-open"
            "210"
            "triangle-se-dot"
            "310"
            "triangle-se-open-dot"
            "11"
            "triangle-sw"
            "111"
            "triangle-sw-open"
            "211"
            "triangle-sw-dot"
            "311"
            "triangle-sw-open-dot"
            "12"
            "triangle-nw"
            "112"
            "triangle-nw-open"
            "212"
            "triangle-nw-dot"
            "312"
            "triangle-nw-open-dot"
            "13"
            "pentagon"
            "113"
            "pentagon-open"
            "213"
            "pentagon-dot"
            "313"
            "pentagon-open-dot"
            "14"
            "hexagon"
            "114"
            "hexagon-open"
            "214"
            "hexagon-dot"
            "314"
            "hexagon-open-dot"
            "15"
            "hexagon2"
            "115"
            "hexagon2-open"
            "215"
            "hexagon2-dot"
            "315"
            "hexagon2-open-dot"
            "16"
            "octagon"
            "116"
            "octagon-open"
            "216"
            "octagon-dot"
            "316"
            "octagon-open-dot"
            "17"
            "star"
            "117"
            "star-open"
            "217"
            "star-dot"
            "317"
            "star-open-dot"
            "18"
            "hexagram"
            "118"
            "hexagram-open"
            "218"
            "hexagram-dot"
            "318"
            "hexagram-open-dot"
            "19"
            "star-triangle-up"
            "119"
            "star-triangle-up-open"
            "219"
            "star-triangle-up-dot"
            "319"
            "star-triangle-up-open-dot"
            "20"
            "star-triangle-down"
            "120"
            "star-triangle-down-open"
            "220"
            "star-triangle-down-dot"
            "320"
            "star-triangle-down-open-dot"
            "21"
            "star-square"
            "121"
            "star-square-open"
            "221"
            "star-square-dot"
            "321"
            "star-square-open-dot"
            "22"
            "star-diamond"
            "122"
            "star-diamond-open"
            "222"
            "star-diamond-dot"
            "322"
            "star-diamond-open-dot"
            "23"
            "diamond-tall"
            "123"
            "diamond-tall-open"
            "223"
            "diamond-tall-dot"
            "323"
            "diamond-tall-open-dot"
            "24"
            "diamond-wide"
            "124"
            "diamond-wide-open"
            "224"
            "diamond-wide-dot"
            "324"
            "diamond-wide-open-dot"
            "25"
            "hourglass"
            "125"
            "hourglass-open"
            "26"
            "bowtie"
            "126"
            "bowtie-open"
            "27"
            "circle-cross"
            "127"
            "circle-cross-open"
            "28"
            "circle-x"
            "128"
            "circle-x-open"
            "29"
            "square-cross"
            "129"
            "square-cross-open"
            "30"
            "square-x"
            "130"
            "square-x-open"
            "31"
            "diamond-cross"
            "131"
            "diamond-cross-open"
            "32"
            "diamond-x"
            "132"
            "diamond-x-open"
            "33"
            "cross-thin"
            "133"
            "cross-thin-open"
            "34"
            "x-thin"
            "134"
            "x-thin-open"
            "35"
            "asterisk"
            "135"
            "asterisk-open"
            "36"
            "hash"
            "136"
            "hash-open"
            "236"
            "hash-dot"
            "336"
            "hash-open-dot"
            "37"
            "y-up"
            "137"
            "y-up-open"
            "38"
            "y-down"
            "138"
            "y-down-open"
            "39"
            "y-left"
            "139"
            "y-left-open"
            "40"
            "y-right"
            "140"
            "y-right-open"
            "41"
            "line-ew"
            "141"
            "line-ew-open"
            "42"
            "line-ns"
            "142"
            "line-ns-open"
            "43"
            "line-ne"
            "143"
            "line-ne-open"
            "44"
            "line-nw"
            "144"
            "line-nw-open"
            "45"
            "arrow-up"
            "145"
            "arrow-up-open"
            "46"
            "arrow-down"
            "146"
            "arrow-down-open"
            "47"
            "arrow-left"
            "147"
            "arrow-left-open"
            "48"
            "arrow-right"
            "148"
            "arrow-right-open"
            "49"
            "arrow-bar-up"
            "149"
            "arrow-bar-up-open"
            "50"
            "arrow-bar-down"
            "150"
            "arrow-bar-down-open"
            "51"
            "arrow-bar-left"
            "151"
            "arrow-bar-left-open"
            "52"
            "arrow-bar-right"
            "152"
            "arrow-bar-right-open"
        ]

    let Fill =
        Pattern.EnumStrings "Fill" [
            "none"
            "tozeroy"
            "tozerox"
            "tonexty"
            "tonextx"
            "toself"
            "tonext"
        ]

    let SelectedMarker =
        Pattern.Config "SelectedMarker" {
            Required = []
            Optional = [
                "opacity", T<float>
                "color", Color
                "size", T<int> + T<float>
            ]
        }

    let SelectedTextFont =
        Pattern.Config "SelectedTextFont" {
            Required = []
            Optional = [
                "color", Color
            ]
        }

    let SelectedOption =
        Pattern.Config "SelectedOption" {
            Required = []
            Optional = [
                "marker", SelectedMarker.Type
                "textfont", SelectedTextFont.Type
            ]
        }

    let Root =
        Pattern.Config "Root" {
            Required = []
            Optional = [
                "color", Color
            ]
        }

    let Domain =
        Pattern.Config "Domain" {
            Required = []
            Optional = [
                "x", !| T<int> + !| T<float>
                "y", !| T<int> + !| T<float>
                "row", T<int>
                "column", T<int>
            ]
        }

    let SizeMode =
        Pattern.EnumStrings "SizeMode" [
            "diameter"
            "area"
        ]

    let PeriodAlignment =
        Pattern.EnumStrings "PeriodAlignment" [
            "start"
            "middle"
            "end"
        ]

    let GradientType =
        Pattern.EnumStrings "ScatterTernaryGradientType" [
            "radial"
            "horizontal"
            "vertical"
            "none"
        ]

    let Gradient =
        Pattern.Config "ScatterTernaryGradient" {
            Required = []
            Optional = [
                "type", GradientType.Type
                "color", Color + !| Color
            ]
        }

    let GroupNorm =
        Pattern.EnumInlines "GroupNorm" [
            "empty", "''"
            "fraction", "'fraction'"
            "percent", "'percent'"
        ]

    let StackGaps =
        Pattern.EnumInlines "StackGaps" [
            "inferZero", "'infer zero'"
            "interpolate", "'interpolate'"
        ]

    let ZSmooth =
        Pattern.EnumStrings "ZSmooth" [
            "fast"
            "best"
        ]

    let XYType =
        Pattern.EnumStrings "XYType" [
            "array"
            "scaled"
        ]

    let Shape =
        Pattern.EnumStrings "Shape" [
            "linear"
            "spline"
            "hv"
            "vh"
            "hvh"
            "vhv"
        ]

    let TextOrientation =
        Pattern.EnumStrings "TextOrientation" [
            "horizontal"
            "radial"
            "tangential"
            "auto"
        ]

    let HistFunc =
        Pattern.EnumStrings "HistFunc" [
            "count"
            "sum"
            "avg"
            "min"
            "max"
        ]

    let MarkerPatternShape =
        Pattern.EnumInlines "MarkerPatternShape" [
            "empty", "''"
            "slash", "'/'"
            "backslash", """'\\'"""
            "x", "'x'"
            "minus", "'-'"
            "pipeline", "'|'"
            "plus", "'+'"
            "dot", "'.'"
        ]   

    let FillMode =
        Pattern.EnumStrings "FillMode" [
            "replace"
            "overlay"
        ]

    let MarkerPattern =
        Pattern.Config "MarkerPattern" {
            Required = []
            Optional = [
                "shape", MarkerPatternShape.Type
                "fillmode", FillMode.Type
                "bgcolor", Color + !| Color
                "fgcolor", Color + !|Color
                "fgopacity", (T<float> + T<int>)
                "size", (T<float> + T<int>) + !| T<float> + !| T<int>
                "solidity", (T<float> + T<int>) + !| T<float> + !| T<int>               
            ]
        }

    let ThetaUnit =
        Pattern.EnumStrings "ThetaUnit" [
            "radians"
            "degrees"
            "gradians"
        ]

    let Pad =
        Pattern.Config "Pad" {
            Required = []
            Optional = [
                "t", T<int> + T<float>
                "r", T<int> + T<float>
                "b", T<int> + T<float>
                "l", T<int> + T<float>
            ]
        }

    let BranchValues =
        Pattern.EnumStrings "BranchValues" [
            "remainder"
            "total"
        ]

    let Operation =
        Pattern.EnumInlines "Operation" [
            "equal", "'='"
            "less", "'<'"
            "greater", "'>'"
            "greaterEqual", "'>='"
            "lessEqual", "'<='"
            "square", "'[]'"
            "bracket", "'()'"
            "squareBracket", "'[)'"
            "bracketSquare", "'(]'"
            "reverseSquare", "']['"
            "reverseBracket", "')('"
            "reverseSquareBracket", "']('"
            "reverseBracketSquare", "')['"
        ]

    let EdgeShape =
        Pattern.EnumInlines "EdgeShape" [
            "greater", "'>'"
            "lower", "'<'"
            "pipeline", "'|'"
            "slash", "'/'"
            "backslash", "'\'" //TODO
        ]

    let Lighting =
        Pattern.Config "Lighting" {
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

    let Count =
        Pattern.EnumStrings "Count" [
            "branches"
            "leaves"
            "branches+leaves"
            "leaves+branches"
        ]

    let Leaf =
        Pattern.Config "Leaf" {
            Required = []
            Optional = [
                "opacity", T<float>
            ]
        }

    let LocationMode =
        Pattern.EnumInlines "LocationMode" [
            "ISO-3", "'ISO-3'"
            "USA-states", "'USA-states'"
            "countryNames", "'country names'"
            "geojson-id", "'geojson-id'"
        ]

    let TextAnchor =
        Pattern.EnumStrings "TextAnchor" [
            "end"
            "middle"
            "start"
        ]

    let ConstrainText =
        Pattern.EnumStrings "ConstrainText" [
            "inside"
            "outside"
            "both"
            "none"
        ]

    let LightPosition =
        Pattern.Config "LightPosition" {
            Required = []
            Optional = [
                "x", T<int> + T<float>
                "y", T<int> + T<float>
                "z", T<int> + T<float>
            ]
        }

    let CapsXYZ =
        Pattern.Config "CapsXYZ" {
            Required = []
            Optional = [
                "show", T<bool>
                "fill", T<int> + T<float>
            ]
        }

    let Caps =
        Pattern.Config "Caps" {
            Required = []
            Optional = [
                "x", CapsXYZ.Type
                "y", CapsXYZ.Type
                "z", CapsXYZ.Type
            ]
        }

    let CommonNamespaces : CodeModel.NamespaceEntity list = [
        Trace
        VisibleString
        Font
        LegendGroupTitle
        TextPositionEnum
        TextPositionInline
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
        Symbol
        Fill
        SelectedMarker
        SelectedTextFont
        SelectedOption
        Root
        Domain
        SizeMode
        PeriodAlignment
        GradientType
        Gradient
        GroupNorm
        StackGaps
        ZSmooth
        XYType
        Shape
        TextOrientation
        HistFunc
        MarkerPatternShape
        FillMode
        MarkerPattern
        ThetaUnit
        Pad
        BranchValues
        Operation
        EdgeShape
        Lighting
        Count
        Leaf
        LocationMode
        TextAnchor
        ConstrainText
        LightPosition
        CapsXYZ
        Caps
    ]