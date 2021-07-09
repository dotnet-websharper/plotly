namespace WebSharper.Plotly.Tests

open WebSharper
open WebSharper.JavaScript
open WebSharper.JQuery
open WebSharper.UI
open WebSharper.UI.Html
open WebSharper.UI.Client
open WebSharper.UI.Templating
open WebSharper.Plotly

type P = PlotlyJs

[<JavaScript>]
module Client =

    let symbolTest = Plotly.Symbol.Triangle_sw_open_dot

    let marker = Plotly.Marker(Symbol = symbolTest)

    (*x: [1, 2, 3, 4],
    y: [10, 15, 13, 17],
    mode: 'markers',*)

    let scatterTrace = ScatterOptions()
    scatterTrace.X <- [|1; 2; 3; 4 |]
    scatterTrace.Y <- [|10; 15; 13; 17 |]
    scatterTrace.Mode <- Modes.Lines_markers

    let chart = Plotly.Plotly.NewPlot("myDiv", [|scatterTrace|])

    //Console.Log(Tests)

    [<SPAEntryPoint>]
    let Main () =

        Doc.Concat [
            h1 [] [text "Plotly Js sample site"]
            div [attr.id "myDiv"] []
        ]
        |> Doc.RunById "main"
        chart
