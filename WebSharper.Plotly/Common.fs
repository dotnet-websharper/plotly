namespace WebSharper.Plotly.Extension.Common

open WebSharper
open WebSharper.InterfaceGenerator

module CommonModule =

    let Trace =
        Class "Trace"

    let nullValue = Pattern.EnumInlines "nullValue" ["null", "null"]

    let color = T<string> + (T<float> + T<int>) + (!| (!? (nullValue.Type + T<string> + T<float>))) + (!| (!| ((!? (nullValue.Type + T<string> + (T<float> + T<int>)))))) 

    let colorScale = T<string> + (!| T<string>) + (!| ((T<float> + T<int>) * T<string>))

    let visibleString = Pattern.EnumStrings "visibleString" ["legendonly"]

    let font =
        Pattern.Config "font" {
            Required = []
            Optional = [
                "family", T<string>
                "size", (T<float> + T<int>)
                "color", color
            ]
        }

    let legendGroupTitle =
        Pattern.Config "legendGroupTitle" {
            Required = []
            Optional = [
                "text", T<string>
                "font", font.Type
            ]
        }

    let textPosition =
        Pattern.EnumStrings "textPosition" [
            "inside"
            "outside"
            "auto"
            "none"
        ]
    
    let orientation =
        Pattern.EnumStrings "orientation" [
            "v"
            "h"
        ]

    let errorType =
        Pattern.EnumStrings "errorType" [
            "percent"
            "constant"
            "sqrt"
            "data"
        ]
    
    let calendar =
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