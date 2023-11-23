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
open WebSharper.Plotly.Extension.Layout
open WebSharper.Plotly.Extension.Options
open WebSharper.Plotly.Extension.Common

module ConcatNamespaceEntities =
    let concatNamespaceEntities (namespaceEntities: CodeModel.NamespaceEntity list list) =
        List.concat namespaceEntities

module Definition =

    let Types = [
            ScatterModule.ScatterOptions.Type
            ScatterGLModule.ScatterGLOptions.Type
            PieModule.PieOptions.Type
            BarModule.BarOptions.Type
            HeatMapModule.HeatMapOptions.Type
            HeatMapGLModule.HeatMapGLOptions.Type
            ImageModule.ImageOptions.Type
            TableModule.TableOptions.Type
            ContourModule.ContourOptions.Type
            BoxModule.BoxOptions.Type
            HGModule.HGOptions.Type
            HG2DModule.HG2DOptions.Type
            HG2DContModule.HG2DContOptions.Type
            ViolinModule.ViolinOptions.Type
            CandleStickModule.CandleStickOptions.Type
            FunnelModule.FunnelOptions.Type
            FunnelAreaModule.FunnelAreaOptions.Type
            IndicatorModule.IndicatorOptions.Type
            OHLCModule.OHLCOptions.Type
            WaterfallModule.WaterfallOptions.Type
            ConeModule.ConeOptions.Type
            ISOSurfaceModule.ISOSurfaceOptions.Type
            MeshModule.MeshOptions.Type
            Scatter3DModule.Scatter3DOptions.Type
            StreamTubeModule.StreamTubeOptions.Type
            SurfaceModule.SurfaceOptions.Type
            VolumeModule.VolumeOptions.Type
            ChoroplethModule.ChoroplethOptions.Type
            ChoroplethMBModule.ChoroplethMBOptions.Type
            DensityMBModule.DensityMBOptions.Type
            ScatterGeoModule.ScatterGeoOptions.Type
            ScatterMBModule.ScatterMBOptions.Type
            BarPolarModule.BarPolarOptions.Type
            CarpetModule.CarpetOptions.Type
            ContourCarpetModule.ContourCarpetOptions.Type
            IcicleModule.IcicleOptions.Type
            ParCatsModule.ParCatsOptions.Type
            ParCoordsModule.ParCoordsOptions.Type
            SankeyModule.SankeyOptions.Type
            ScatterCarpetModule.ScatterCarpetOptions.Type
            ScatterPolarModule.ScatterPolarOptions.Type
            ScatterPolarGLModule.ScatterPolarGLOptions.Type
            ScatterTernaryModule.ScatterTernaryOptions.Type
            SplomModule.SplomOptions.Type
            SunBurstModule.SunBurstOptions.Type
            TreeMapModule.TreeMapOptions.Type
        ]

    let WithTypes values f =
        List.map f values
        |> List.reduce (fun l r -> l + r)

    let Layout = LayoutModule.Layout

    let Options = OptionsModule.Options

    let Plotly =
        Class "Plotly"
        |+> Static [
            "newPlot" => WithTypes Types (fun t -> (T<string> + T<HTMLElement>) * !| t * !? Layout * !? Options ^-> T<HTMLElement>)
            "newPlot" => (T<string> + T<HTMLElement>) * !| CommonModule.Trace * !? Layout * !? Options ^-> T<HTMLElement>
            "react" => WithTypes Types (fun t -> (T<string> + T<HTMLElement>) * !|t * !?Layout * !? Options ^-> T<HTMLElement>)
            "react" => (T<string> + T<HTMLElement>) * !| CommonModule.Trace * !?Layout * !? Options ^-> T<HTMLElement>
            "restyle" => (T<string> + T<HTMLElement>) * T<obj> * !? (!| T<int>) ^-> T<HTMLElement>
            "relayout" => (T<string> + T<HTMLElement>) * T<obj> ^-> T<HTMLElement>
            "update" => (T<string> + T<HTMLElement>) * T<obj> * T<obj> * !? (!| T<int>) ^-> T<HTMLElement>
            "validate" => !| T<obj> * Layout ^-> T<HTMLElement>
            "makeTemplate" => T<obj> + T<HTMLElement> ^-> T<HTMLElement>
            "validateTemplate" => (T<obj> + T<HTMLElement>) * T<obj> ^-> T<HTMLElement>
            "addTraces" => WithTypes Types (fun t -> (T<string> + T<HTMLElement>) * !| t ^-> T<HTMLElement>)
            "addTraces" => (T<string> + T<HTMLElement>) * !| CommonModule.Trace ^-> T<HTMLElement>
            "deleteTraces" => (T<string> + T<HTMLElement>) * (T<int> + !| T<int>) ^-> T<HTMLElement>
            "moveTraces" => (T<string> + T<HTMLElement>) * (T<int> + !| T<int>) * !? (T<int> + !| T<int>) ^-> T<HTMLElement>
            "extendTraces" => WithTypes Types (fun t -> (T<string> + T<HTMLElement>) * t * !| T<int> * !? T<int> ^-> T<HTMLElement>)
            "extendTraces" => (T<string> + T<HTMLElement>) * !| CommonModule.Trace * !| T<int> * !? T<int> ^-> T<HTMLElement>
            "prependTraces" => WithTypes Types (fun t -> (T<string> + T<HTMLElement>) * t * !| T<int> * !? T<int> ^-> T<HTMLElement>)
            "prependTraces" => (T<string> + T<HTMLElement>) * !| CommonModule.Trace * !| T<int> * !? T<int> ^-> T<HTMLElement>
            "addFrames" => (T<string> + T<HTMLElement>) * T<obj> ^-> T<HTMLElement>
            "animate" => (T<string> + T<HTMLElement>) * T<obj> ^-> T<HTMLElement>
            "purge" => (T<string> + T<HTMLElement>) ^-> T<HTMLElement>
            "toImage" => (T<string> + T<HTMLElement>) * T<obj> ^-> T<HTMLElement>
            "downloadImage" => (T<string> + T<HTMLElement>) * T<obj> ^-> T<HTMLElement>
        ]
        |> ImportDefault "plotly.js-dist-min"

    let Assembly =
        Assembly [
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
                ConeModule.ConeTraceNamespaces
                ISOSurfaceModule.ISOSurfaceTraceNamespaces
                MeshModule.MeshTraceNamespaces
                Scatter3DModule.Scatter3DTraceNamespaces
                StreamTubeModule.StreamTubeTraceNamespaces
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
                LayoutModule.LayoutNameSpaces
                OptionsModule.OptionsNamespaces
                CommonModule.CommonNamespaces
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
