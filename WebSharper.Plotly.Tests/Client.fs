namespace WebSharper.Plotly.Tests

open WebSharper
open WebSharper.JavaScript
open WebSharper.JQuery
open WebSharper.UI
open WebSharper.UI.Html
open WebSharper.UI.Client
open WebSharper.UI.Templating
open WebSharper.Plotly

[<JavaScript>]
module Client =

    (*x: [1, 2, 3, 4],
    y: [10, 15, 13, 17],
    mode: "markers",*)

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

    let heatmap = HeatMapOptions()
    heatmap.Z <- [|[|1; 5; 30; 50; 1|]; [|20; 1; 60; 80; 30|]; [|30; 60; 1; -10; 20|]|]
    heatmap.X <- [|"Monday"; "Tuesday"; "Wednesday"; "Thursday"; "Friday"|]
    heatmap.Y <- [|"Morning"; "Afternoon"; "Evening"|]
    heatmap.Hoverongaps <- false

    let heatmapgl = HeatMapOptions()
    heatmapgl.Z <- [|[|1; 5; 30; 50; 1|]; [|20; 1; 60; 80; 30|]; [|30; 60; 1; -10; 20|]|]
    heatmapgl.X <- [|"Monday"; "Tuesday"; "Wednesday"; "Thursday"; "Friday"|]
    heatmapgl.Y <- [|"Morning"; "Afternoon"; "Evening"|]


    let table = TableOptions()
    table.Columnwidth <- [|150; 200; 200; 150|]
    table.Columnorder <- [|0; 1; 2; 3|]
    table.Header <- TableHeader(
        Values = [|[|"<b>EXPENSES</b>"|]; [|"<b>Q1</b>"|]; [|"<b>Q2</b>"|]; [|"<b>Q3</b>"|]; [|"<b>Q4</b>"|]|],
        Align = TableAlign.Center,
        Line = TableLine(
            Width = 1,
            Color = "black"
        ),
        Fill = TableFill(
            Color = "grey"
        ),
        Font = TableFont(
            Family = "Arial",
            Size = 12,
            Color = "white"
        )
    )
    table.Cells <- TableCells(
        Values = [|
            [|"Salaries"; "Office"; "Merchandise"; "Legal"; "<b>TOTAL</b>"|]
            [|1200000; 20000; 80000; 2000; 12120000|]
            [|1300000; 20000; 70000; 2000; 130902000|]
            [|1300000; 20000; 120000; 2000; 131222000|]
            [|1400000; 20000; 90000; 2000; 14102000|]
        |],
        Align = TableAlign.Center,
        Line = TableLine(
            Color = "black",
            Width = 1
        ),
        Font = TableFont(
            Family = "Arial",
            Size = 11,
            Color = [|"black"|]
        )
    )

    let contour = ContourOptions()
    contour.Z <- [|
        [|10.0; 10.625; 12.5; 15.625; 20.0|];
        [|5.625; 6.25; 8.125; 11.25; 15.625|];
        [|2.5; 3.125; 5.0; 8.125; 12.5|];
        [|0.625; 1.25; 3.125; 6.25; 10.625|];
        [|0.0; 0.625; 2.5; 5.625; 10.0|]
    |]

    let imagetrace = ImageOptions()
    imagetrace.Source <- "./icon.png"

    let box = BoxOptions()
    box.Y <- [|0;1;1;2;3;5;8;13;21|]
    box.Boxpoints <- Union2Of2(BoxPoints.All)
    box.Jitter <- 0.3
    box.Pointpos <- -1.8

    let histogram = HGOptions()
    histogram.X <- [|1;1;2;3;4;6;4;3;7;9;6;4;3;4;5;7;5|]

    let histogram2d = HG2DOptions()
    histogram2d.X <- [|1;1;2;3;4;6;4;3;7;9;6;4;3;4;5;7;5|]
    histogram2d.Y <- [|1;1;2;3;4;6;4;3;7;9;6;4;3;4;5;7;5|]

    let scatterChart = Plotly.Plotly.NewPlot("scatterchartDiv", [|scatterTrace|])
    let scatterGLChart = Plotly.Plotly.NewPlot("scatterglchartDiv", [|scatterGLTrace|])
    let pieChart = Plotly.Plotly.NewPlot("piechartDiv", [|pieTrace|])
    let barChart = Plotly.Plotly.NewPlot("barchartDiv", [|barTrace|])
    let heatMapChart = Plotly.Plotly.NewPlot("heatmapchartDiv", [|heatmap|])
    let tableChart = Plotly.Plotly.NewPlot("tablechartDiv", [|table|])
    let heatMapGLChart = Plotly.Plotly.NewPlot("heatmapglchartDiv", [|heatmapgl|])
    let contourChart = Plotly.Plotly.NewPlot("contourchartDiv", [|contour|])
    //let imageChart = Plotly.Plotly.NewPlot("imagechartDiv", [|imagetrace|])
    let boxChart = Plotly.Plotly.NewPlot("boxchartDiv", [|box|])
    let hgChart = Plotly.Plotly.NewPlot("hgchartDiv", [|histogram|])
    let hg2dChart = Plotly.Plotly.NewPlot("hg2dchartDiv", [|histogram2d|])


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
            h2 [] [text "Heatmap chart"]
            div [attr.id "heatmapchartDiv"] []
            h2 [] [text "Table chart"]
            div [attr.id "tablechartDiv"] []
            h2 [] [text "HeatMapGL chart"]
            div [attr.id "heatmapglchartDiv"] []
            h2 [] [text "Contour chart"]
            div [attr.id "contourchartDiv"] []
            //h2 [] [text "Image chart"]
            //div [attr.id "imagechartDiv"] []
            h2 [] [text "Box chart"]
            div [attr.id "boxchartDiv"] []
            h2 [] [text "Histogram chart"]
            div [attr.id "hgchartDiv"] []
            h2 [] [text "Histogram2D chart"]
            div [attr.id "hg2dchartDiv"] []
        ]
        |> Doc.RunById "main"
        scatterChart |> ignore
        scatterGLChart |> ignore
        pieChart |> ignore
        barChart |> ignore
        heatMapChart |> ignore
        tableChart |> ignore
        heatMapGLChart |> ignore
        contourChart |> ignore
        //imageChart |> ignore
        boxChart |> ignore
        hgChart |> ignore
        hg2dChart |> ignore

