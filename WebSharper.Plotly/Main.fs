namespace WebSharper.Plotly

open WebSharper
open WebSharper.JavaScript
open WebSharper.InterfaceGenerator
open WebSharper.Plotly.Traces

module Definition =

    let Plotly =
        Class "Plotly"
        |+> Static [
            "newPlot" => (T<string> + T<HTMLElement>) * T<Object> //TODO
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
            Namespace "WebSharper.Plotly" [
                (*TracesModule.ScatterType
                TracesModule.VisibleString
                TracesModule.FontConfig
                TracesModule.LegendGroupTitle
                TracesModule.Modes
                TracesModule.TextPosition
                TracesModule.ScatterOptions*)
                Plotly
            ]
        ]

[<Sealed>]
type Extension() =
    interface IExtension with
        member ext.Assembly =
            Definition.Assembly

[<assembly: Extension(typeof<Extension>)>]
do ()
