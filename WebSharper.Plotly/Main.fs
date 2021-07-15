namespace WebSharper.Plotly.Extension

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
open WebSharper.Plotly.Extension.Traces
//open WebSharper.Plotly.Extension.Layout
open WebSharper.Plotly.Extension.Options

module ConcatNamespaceEntities =
    let concatNamespaceEntities (namespaceEntities: CodeModel.NamespaceEntity list list) =
        List.concat namespaceEntities

module Definition =

    let Data =
        !| ScatterModule.ScatterOptions.Type +
        !| ScatterGLModule.ScatterGLOptions.Type +
        !| PieModule.PieOptions.Type +
        !| BarModule.BarOptions.Type +
        !| HeatMapModule.HeatMapOptions.Type +
        !| HeatMapGLModule.HeatMapGLOptions +
        !| ImageModule.ImageOptions +
        !| TableModule.TableOptions +
        !| ContourModule.ContourOptions +
        !| BoxModule.BoxOptions +
        !| HGModule.HGOptions +
        !| HG2DModule.HG2DOptions +
        !| HG2DContModule.HG2DContOptions +
        !| ViolinModule.ViolinOptions +
        !| CandleStickModule.CandleStickOptions +
        !| FunnelModule.FunnelOptions +
        !| FunnelAreaModule.FunnelAreaOptions +
        !| IndicatorModule.IndicatorOptions +
        !| OHLCModule.OHLCOptions +
        !| WaterfallModule.WaterfallOptions +
        !| ConeModule.ConeOptions + //
        !| ISOSurfaceModule.ISOSurfaceOptions +
        !| MeshModule.MeshOptions +
        !| Scatter3DModule.Scatter3DOptions +
        !| StreamTubeModule.StreamTubeOptions + //
        !| SurfaceModule.SurfaceOptions +
        !| VolumeModule.VolumeOptions +
        !| ChoroplethModule.ChoroplethOptions +
        !| ChoroplethMBModule.ChoroplethMBOptions +
        !| DensityMBModule.DensityMBOptions +
        !| ScatterGeoModule.ScatterGeoOptions +
        !| ScatterMBModule.ScatterMBOptions +
        !| BarPolarModule.BarPolarOptions +
        !| CarpetModule.CarpetOptions +
        !| ContourCarpetModule.ContourCarpetOptions +
        !| IcicleModule.IcicleOptions +
        !| ParCatsModule.ParCatsOptions +
        !| ParCoordsModule.ParCoordsOptions +
        !| SankeyModule.SankeyOptions +
        !| ScatterCarpetModule.ScatterCarpetOptions +
        !| ScatterPolarModule.ScatterPolarOptions +
        !| ScatterPolarGLModule.ScatterPolarGLOptions +
        !| ScatterTernaryModule.ScatterTernaryOptions +
        !| SplomModule.SplomOptions +
        !| SunBurstModule.SunBurstOptions +
        !| TreeMapModule.TreeMapOptions

    //let Layout = LayoutModule.Layout

    let Options = OptionsModule.Options

    let Plotly =
        Class "Plotly"
        |+> Static [
            "newPlot" => (T<string> + T<HTMLElement>) * Data * !? Options.Type ^-> T<HTMLElement> //TODO
            "react" => T<unit> //TODO
            "restyle" => T<unit> //TODO
            "relayout" => T<unit> //TODO
            "update" => T<unit> //TODO
            "validate" => T<unit> //TODO
            "makeTeamplate" => T<unit> //TODO
            "validateTeamplate" => T<unit> //TODO
            "addTraces" => T<unit> //TODO
            "deleteTraces" => T<unit> //TODO
            "moveTraces" => T<unit> //TODO
            "extendTraces" => T<unit> //TODO
            "prependTraces" => T<unit> //TODO
            "addFrames" => T<unit> //TODO
            "animate" => T<unit> //TODO
            "purge" => T<unit> //TODO
            "toImage" => T<unit> //TODO
            "downloadImage" => T<unit> //TODO
        ]

    let Assembly =
        Assembly [
            Namespace "WebSharper.Plotly.Resources" [
                Resource "PlotlyJsCDN" "https://cdn.plot.ly/plotly-2.2.0.min.js"
                |> AssemblyWide
            ]
            Namespace "WebSharper.Plotly" (ConcatNamespaceEntities.concatNamespaceEntities [
                ScatterModule.ScatterTraceNamespaces
                ScatterGLModule.ScatterGLTraceNamespaces
                PieModule.PieTraceNamespaces
                BarModule.BarTraceNamespaces
                HeatMapModule.HeatMapTraceNamespaces
                HeatMapGLModule.HeatMapGLTraceNamespaces
                ImageModule.ImageTraceNamespaces
                TableModule.TableTraceNamespaces
                ContourModule.ContourTraceNamespaces
                BoxModule.BoxTraceNamespaces
                HGModule.HGTraceNamespaces
                HG2DModule.HG2DTraceNamespaces
                HG2DContModule.HG2DContTraceNamespaces
                ViolinModule.ViolinTraceNamespaces
                CandleStickModule.CandleStickTraceNamespaces
                FunnelModule.FunnelTraceNamespaces
                FunnelAreaModule.FunnelAreaTraceNamespaces
                IndicatorModule.IndicatorTraceNamespaces
                OHLCModule.OHLCTraceNamespaces
                WaterfallModule.WaterfallTraceNamespaces
                ConeModule.ConeTraceNamespaces //
                ISOSurfaceModule.ISOSurfaceTraceNamespaces
                MeshModule.MeshTraceNamespaces
                Scatter3DModule.Scatter3DTraceNamespaces
                StreamTubeModule.StreamTubeTraceNamespaces //
                SurfaceModule.SurfaceTraceNamespaces
                VolumeModule.VolumeTraceNamespaces
                ChoroplethModule.ChoroplethTraceNamespaces
                ChoroplethMBModule.ChoroplethMBTraceNamespaces
                DensityMBModule.DensityMBTraceNamespaces
                ScatterGeoModule.ScatterGeoTraceNamespaces
                ScatterMBModule.ScatterMBTraceNamespaces
                BarPolarModule.BarPolarTraceNamespaces
                CarpetModule.CarpetTraceNamespaces
                ContourCarpetModule.ContourCarpetTraceNamespaces
                IcicleModule.IcicleTraceNamespaces
                ParCatsModule.ParCatsTraceNamespaces
                ParCoordsModule.ParCoordsTraceNamespaces
                SankeyModule.SankeyTraceNamespaces
                ScatterCarpetModule.ScatterCarpetTraceNamespaces
                ScatterPolarModule.ScatterPolarTraceNamespaces
                ScatterPolarGLModule.ScatterPolarGLTraceNamespaces
                ScatterTernaryModule.ScatterTernaryTraceNamespaces
                SplomModule.SplomTraceNamespaces
                SunBurstModule.SunBurstTraceNamespaces
                TreeMapModule.TreeMapTraceNamespaces
                //LayoutModule.LayoutNameSpaces
                OptionsModule.OptionsNamespaces
                [Plotly]
            ])
        ]

[<Sealed>]
type Extension() =
    interface IExtension with
        member ext.Assembly =
            Definition.Assembly

[<assembly: Extension(typeof<Extension>)>]
do ()
