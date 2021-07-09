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

    (*x: [1, 2, 3, 4],
    y: [10, 15, 13, 17],
    mode: 'markers',*)

    let scatterTrace = ScatterOptions()
    scatterTrace.X <- [|1; 2; 3; 4 |]
    scatterTrace.Y <- [|10; 15; 13; 17 |]
    scatterTrace.Mode <- ScatterModes.Lines_markers

    let scatterGLTrace = ScatterGLOptions()
    scatterGLTrace.X <- [|1; 2; 3; 4 |]
    scatterGLTrace.Y <- [|10; 15; 13; 17 |]
    scatterGLTrace.Mode <- ScatterGLModes.Lines_markers

    let pieTrace = PieOptions()
    pieTrace.Values <- [|19; 26; 55|]
    pieTrace.Labels <- [|"Residential"; "Non-Residential"; "Utility"|]

    let barTrace = BarOptions()
    barTrace.X <- [|"giraffes"; "orangutans"; "monkeys"|]
    barTrace.Y <- [|20; 14; 23|]

    let chart1 = Plotly.Plotly.NewPlot("scatterchartDiv", [|scatterTrace|])
    let chart2 = Plotly.Plotly.NewPlot("scatterglchartDiv", [|scatterGLTrace|])
    let chart3 = Plotly.Plotly.NewPlot("piechartDiv", [|pieTrace|])
    let chart4 = Plotly.Plotly.NewPlot("barchartDiv", [|barTrace|])

    //Console.Log(Tests)

    [<SPAEntryPoint>]
    let Main () =

        Doc.Concat [
            h1 [] [text "Plotly Js sample site"]
            h2 [] [text "Scatter chart"]
            div [attr.id "scatterchartDiv"] []
            h2 [] [text "ScatterGL chart"]
            div [attr.id "scatterglchartDiv"] []
            h2 [] [text "Pie chart"]
            div [attr.id "piechartDiv"] []
            h2 [] [text "Bar chart"]
            div [attr.id "barchartDiv"] []
        ]
        |> Doc.RunById "main"
        chart1 |> ignore
        chart2 |> ignore
        chart3 |> ignore
        chart4 |> ignore
