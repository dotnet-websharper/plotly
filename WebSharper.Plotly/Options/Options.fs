namespace WebSharper.Plotly.Extension.Options

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

module OptionsModule =

    let FormatOptions =
        Pattern.EnumStrings "FormatOptions" [
            "png"
            "svg"
            "jpeg"
            "webp"
        ]

    let ToImageButtonOptions =
        Pattern.Config "ToImageButtonOptions" {
            Required = []
            Optional = [
                "format", FormatOptions.Type
                "filename", T<string>
                "height", T<int>
                "width", T<int>
                "scale", T<int>
            ]
        }

    let ModeBarButtonTypes =
        Pattern.EnumStrings "ModeBarButtons" [
            "zoom2d"
            "pan2d"
            "select2d"
            "lasso2d"
            "zoomIn2d"
            "zoomOut2d"
            "autoScale2d"
            "resetScale2d"
            "zoom3d"
            "pan3d"
            "orbitRotation"
            "tableRotation"
            "handleDrag3d"
            "resetCameraDefault3d"
            "resetCameraLastSave3d"
            "hoverClosest3d"
            "hoverClosestCartesian"
            "hoverCompareCartesian"
            "zoomInGeo"
            "zoomOutGeo"
            "resetGeo"
            "hoverClosestGeo"
            "hoverClosestGl2d"
            "hoverClosestPie"
            "toggleHover"
            "resetViews"
            "toImage"
            "sendDataToCloud"
            "toggleSpikelines"
            "resetViewMapbox"
        ]

    let IconConfig =
        Pattern.Config "IconConfig" {
            Required = []
            Optional = [
                "width", T<int>
                "height", T<int>
                "path", T<string>
                "transform", T<string>
                "name", T<string>
                "svg", T<string>
            ]
        }

    let ModeBarButtonsToAdd =
        Pattern.Config "ModeBarButtonsToAdd" {
            Required = []
            Optional = [
                "name", T<string>
                "icon", IconConfig.Type
                "click", T<JavaScript.Function>
            ]
        }

    let LocalInterface =
        Class "ILocale"

    let Locale =
        Class "Locale"

    let mutable Resources : CodeModel.NamespaceEntity list = []

    let LocaleSetup (s: string) = 
        let r =
            Resource (s.ToUpperInvariant() + "CDN") (sprintf "https://cdnjs.cloudflare.com/ajax/libs/plotly.js/2.2.1/plotly-locale-%s.min.js" s)
        let cl =
            Class (s.ToUpperInvariant())
            |> Requires [r]
            |=> Inherits LocalInterface
            |+> Static [
                "localeString" =? T<string>
                |> WithGetterInline (sprintf "'%s'" s)
            ]

        Resources <- List.append Resources [r]

        Locale
        |+> Static [
            (s.ToUpperInvariant()) =? cl
            |> WithGetterInline (sprintf "'%s'" s)
        ]
        |> ignore
        
        cl

    let AF = LocaleSetup "af"
    let AM = LocaleSetup "am"
    let ARDZ = LocaleSetup "ar-dz"
    let AREG = LocaleSetup "ar-eg"
    let AR = LocaleSetup "ar"
    let AZ = LocaleSetup "az"
    let BG = LocaleSetup "bg"
    let BS = LocaleSetup "bs"
    let CA = LocaleSetup "ca"
    let CS = LocaleSetup "cs"
    let CY = LocaleSetup "cy"
    let DA = LocaleSetup "da"
    let DECH = LocaleSetup "de-ch"
    let DE = LocaleSetup "de"
    let EL = LocaleSetup "el"
    let EO = LocaleSetup "eo"
    let ESAR = LocaleSetup "es-ar"
    let ESPE = LocaleSetup "es-pe"
    let ES = LocaleSetup "es"
    let ET = LocaleSetup "et"
    let EU = LocaleSetup "eu"
    let FA = LocaleSetup "fa"
    let FI = LocaleSetup "fi"
    let FO = LocaleSetup "fo"
    let FRCH = LocaleSetup "fr-ch"
    let FR = LocaleSetup "fr"
    let GL = LocaleSetup "gl"
    let GU = LocaleSetup "gu"
    let HE = LocaleSetup "he"
    let HIIN = LocaleSetup "hi-in"
    let HR = LocaleSetup "hr"
    let HU = LocaleSetup "hu"
    let HY = LocaleSetup "hy"
    let ID = LocaleSetup "id"
    let IS = LocaleSetup "is"
    let IT = LocaleSetup "it"
    let JA = LocaleSetup "ja"
    let KA = LocaleSetup "ka"
    let KM = LocaleSetup "km"
    let KO = LocaleSetup "ko"
    let LT = LocaleSetup "lt"
    let LV = LocaleSetup "lv"
    let MEME = LocaleSetup "me-me"
    let ME = LocaleSetup "me"
    let MK = LocaleSetup "mk"
    let ML = LocaleSetup "ml"
    let MS = LocaleSetup "ms"
    let MT = LocaleSetup "mt"
    let NLBE = LocaleSetup "nl-be"
    let NL = LocaleSetup "nl"
    let NO = LocaleSetup "no"
    let PA = LocaleSetup "pa"
    let PL = LocaleSetup "pl"
    let PTBR = LocaleSetup "pt-br"
    let PTPT = LocaleSetup "pt-pt"
    let RM = LocaleSetup "rm"
    let RO = LocaleSetup "ro"
    let RU = LocaleSetup "ru"
    let SK =  LocaleSetup "sk"
    let SL = LocaleSetup "sl"
    let SQ = LocaleSetup "sq"
    let SRSR = LocaleSetup "sr-sr"
    let SR = LocaleSetup "sr"
    let SV = LocaleSetup "sv"
    let SW = LocaleSetup "sw"
    let TA = LocaleSetup "ta"
    let TH = LocaleSetup "th"
    let TR = LocaleSetup "tr"
    let TT = LocaleSetup "tt"
    let UK = LocaleSetup "uk"
    let UR = LocaleSetup "ur"
    let VI = LocaleSetup "vi"
    let ZHCN = LocaleSetup "zh-cn"
    let ZHHK = LocaleSetup "zh-hk"
    let ZHTW = LocaleSetup "zh-tw"

    let Options =
        Pattern.Config "Options" {
            Required = []
            Optional = [
                "scrollZoom", T<bool>
                "editable", T<bool>
                "staticPlot", T<bool>
                "toImageButtonOptions", ToImageButtonOptions.Type
                "displayModeBar", T<bool>
                "modeBarButtonsToRemove", ModeBarButtonTypes.Type
                "modeBarButtonsToAdd", ModeBarButtonsToAdd.Type
                "showLink", T<bool>
                "plotlyServerURL", T<string> // investigate
                "linkText", T<string>
                "showEditInChartStudio", T<bool>
                "locale", LocalInterface.Type
                "displayLogo", T<bool>
                "responsive", T<bool>
                "doubleClickDelay", T<int>
            ]
        } 

    let OptionsNamespaces : CodeModel.NamespaceEntity list = [
        FormatOptions
        ToImageButtonOptions
        IconConfig
        ModeBarButtonTypes
        ModeBarButtonsToAdd
        Options
        Locale
        LocalInterface
        AF
        AM
        ARDZ
        AREG
        AR
        AZ
        BG
        BS
        CA
        CS
        CY
        DA
        DECH
        DE
        EL
        EO
        ESAR
        ESPE
        ES
        ET
        EU
        FA
        FI
        FO
        FRCH
        FR
        GL
        GU
        HE
        HIIN
        HR
        HU
        HY
        ID
        IS
        IT
        JA
        KA
        KM
        KO
        LT
        LV
        MEME
        ME
        MK
        ML
        MS
        MT
        NLBE
        NL
        NO
        PA
        PL
        PTBR
        PTPT
        RM
        RO
        RU
        SK
        SL
        SQ
        SRSR
        SR
        SV
        SW
        TA
        TH
        TR
        TT
        UK
        UR
        VI
        ZHCN
        ZHHK
        ZHTW
    ]