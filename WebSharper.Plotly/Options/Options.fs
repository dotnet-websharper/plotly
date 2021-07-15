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
                "locale", T<string>
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
    ]