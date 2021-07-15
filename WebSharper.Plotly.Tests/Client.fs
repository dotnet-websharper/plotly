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

    let hg2dcontour = HG2DContOptions()
    hg2dcontour.X <- [|2;3;4;2;1;3;5;7;98;7;6;54;4;5;6;7;8;9;4;5;3;32;2;4;5;7;45;3;3;3;4|]
    hg2dcontour.Y <- [|8;9;4;5;3;32;2;4;2;3;4;2;1;3;5;7;98;7;6;54;4;5;6;7;5;7;45;3;3;3;4|]    

    let violin = ViolinOptions()
    //violin.Y <- violin.
    violin.Points <- Union2Of2(ViolinPoints.None)
    violin.Box <- ViolinBox(
        Visible = true
    )
    violin.Points <- Union1Of2(false)
    violin.Line <- ViolinLine(
        Color = "black"
    )
    violin.Fillcolor <- "black"
    violin.Opacity <- 0.6
    violin.Meanline <- ViolinMeanLine(
        Visible = true
    )
    violin.X0 <- "Total Bill"

    let candlestick = CandleStickOptions()
    candlestick.X <- [|
        "2017-01-04";"2017-01-05";"2017-01-06";
        "2017-01-09";"2017-01-10";"2017-01-11";"2017-01-12";
        "2017-01-13";"2017-01-17";"2017-01-18";"2017-01-19";
        "2017-01-20";"2017-01-23";"2017-01-24";"2017-01-25";
        "2017-02-02";"2017-02-03";"2017-02-04";"2017-02-07"
        |]
    candlestick.Close <- [|
        116.019997;116.610001;117.910004;
        118.989998;119.110001;119.75;119.25;
        119.040001;120.0;119.989998;119.779999;
        120.0;120.080002;119.970001;121.879997;
        121.940002;121.949997;121.629997;121.349998
        |]
    candlestick.Decreasing <- CandleStickCreasing(
        Line = CandleStickCreasingLine(
            Color = "#7F7F7F"
        )
    )
    candlestick.High <- [|
        116.510002; 116.860001; 118.160004; 119.43;
        119.379997; 119.93; 119.300003; 119.620003;
        120.239998; 120.5; 120.089996; 120.449997;
        120.809998; 120.099998; 122.099998; 122.440002;
        122.349998; 121.629997; 121.389999
    |]
    candlestick.Increasing <- CandleStickCreasing(
        Line = CandleStickCreasingLine(
            Color = "#17BECF"
        )
    )
    candlestick.Line <- CandleStickLine(
        Color = "rgba(31,119,180,1)"
    )
    candlestick.Low <- [|
        115.510002; 114.860001; 115.160004; 116.43;
        117.379997; 117.93; 117.300003; 116.620003;
        118.239998; 117.5; 116.089996; 117.449997;
        119.809998; 116.099998; 120.099998; 121.440002;
        121.349998; 120.629997; 120.389999
    |]
    candlestick.Open <- [|
        116.810002; 116.960001; 118.460004; 119.93;
        119.779997; 119.93; 119.700003; 119.720003;
        120.339998; 120.65; 120.689996; 120.749997;
        120.909998; 120.299998; 122.399998; 122.540002;
        122.849998; 121.829997; 121.589999
    |]
    candlestick.Xaxis <- "x"
    candlestick.Yaxis <- "y"

    let funnel = FunnelOptions()
    funnel.Y <- [|
        "Website visit"; "Downloads";
        "Potential customers"; "Invoice sent";
        "Closed delas"
    |]
    funnel.X <- [|13873; 10533; 5443; 2703; 908|]
    funnel.Hoverinfo <- "x+percent previous+percent initial"

    let funnelarea = FunnelAreaOptions()
    funnelarea.Values <- [|5;4;3;2;1|]
    funnelarea.Text <- Union2Of2([|
        "First"; "Second"; "Third";
        "Fourth"; "Fifth"
    |])
    funnelarea.Marker <- FunnelAreaMarker(
        Colors = Union2Of2([|
            "59D4E8"; "DDB6C6"; "A696C8";
            "67EACA"; "94D2E6"
        |]),
        Line = FunnelAreaMarkerLine(
            Color = Union2Of2([|
                "59D4E8"; "DDB6C6"; "A696C8";
                "67EACA"; "94D2E6"
            |]),
            Width = Union4Of4([|2;1;5;0;3|])
        )
    )
    funnelarea.Textfont <- FunnelAreaFont(
        Family = "Old Standard TT",
        Size = 13,
        Color = "black",
        Opacity = 0.65
    )

    let indicator = IndicatorOptions()
    indicator.Value <- 200
    indicator.Delta <- IndicatorDelta(
        Reference = 160
    )
    indicator.Gauge <- IndicatorGauge(
        Axis = IndicatorGaugeAxis(
            Visible = false,
            Range = [|0;250|]
        )
    )

    let ohlc = OHLCOptions()
    ohlc.X <- [|
        "2017-01-04";"2017-01-05";"2017-01-06";
        "2017-01-09";"2017-01-10";"2017-01-11";"2017-01-12";
        "2017-01-13";"2017-01-17";"2017-01-18";"2017-01-19";
        "2017-01-20";"2017-01-23";"2017-01-24";"2017-01-25";
        "2017-02-02";"2017-02-03";"2017-02-04";"2017-02-07"
        |]
    ohlc.Close <- [|
        116.019997;116.610001;117.910004;
        118.989998;119.110001;119.75;119.25;
        119.040001;120.0;119.989998;119.779999;
        120.0;120.080002;119.970001;121.879997;
        121.940002;121.949997;121.629997;121.349998
        |]
    ohlc.Decreasing <- OHLCCreasing(
        Line = OHLCCreasingLine(
            Color = "#7F7F7F"
        )
    )
    ohlc.High <- [|
        116.510002; 116.860001; 118.160004; 119.43;
        119.379997; 119.93; 119.300003; 119.620003;
        120.239998; 120.5; 120.089996; 120.449997;
        120.809998; 120.099998; 122.099998; 122.440002;
        122.349998; 121.629997; 121.389999
    |]
    ohlc.Increasing <- OHLCCreasing(
        Line = OHLCCreasingLine(
            Color = "#17BECF"
        )
    )
    ohlc.Line <- OHLCLine(
        Color = "rgba(31,119,180,1)"
    )
    ohlc.Low <- [|
        115.510002; 114.860001; 115.160004; 116.43;
        117.379997; 117.93; 117.300003; 116.620003;
        118.239998; 117.5; 116.089996; 117.449997;
        119.809998; 116.099998; 120.099998; 121.440002;
        121.349998; 120.629997; 120.389999
    |]
    ohlc.Open <- [|
        116.810002; 116.960001; 118.460004; 119.93;
        119.779997; 119.93; 119.700003; 119.720003;
        120.339998; 120.65; 120.689996; 120.749997;
        120.909998; 120.299998; 122.399998; 122.540002;
        122.849998; 121.829997; 121.589999
    |]
    ohlc.Xaxis <- "x"
    ohlc.Yaxis <- "y"

    let waterfall = WaterfallOptions()
    waterfall.Name <- "2018"
    waterfall.Orientation <- WaterfallOrientation.V
    waterfall.Measure <- [|
        "relative"; "relative"; "total"; "relative";
        "relative"; "total"
    |]
    waterfall.X <- [|
        "Sales"; "Consulting"; "Net revenue"; "Purchases";
        "Other expenses"; "Profit before tax"       
    |]
    waterfall.Textposition <- WaterfallTextPosition.Outside
    waterfall.Text <- Union2Of2([|"+60";"+80";"";"-40";"-20";"Total"|])
    waterfall.Y <- [|60;80;0;-40;-20;0|]
    waterfall.Connector <- WaterfallConnector(
        Line = WaterfallLine(
            Color = "rgb(63, 63, 63)"
        )
    )






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
    let hg2dContChart = Plotly.Plotly.NewPlot("hg2dcontchartDiv", [|hg2dcontour|])
    //let violinChart = Plotly.Plotly.NewPlot("violinchartDiv", [|violin|])
    let candleStickChart = Plotly.Plotly.NewPlot("candlestickchartDiv", [|candlestick|])
    let funnelChart = Plotly.Plotly.NewPlot("funnelchartDiv", [|funnel|])
    let funnelAreaChart = Plotly.Plotly.NewPlot("funnelareachartDiv", [|funnelarea|])
    let indicatorChart = Plotly.Plotly.NewPlot("indicatorchartDiv", [|indicator|])
    let ohlcChart = Plotly.Plotly.NewPlot("ohlcchartDiv", [|ohlc|])
    let waterfallChart = Plotly.Plotly.NewPlot("waterfallchartDiv", [|waterfall|])

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
            h2 [] [text "Histogram2DContour chart"]
            div [attr.id "hg2dcontchartDiv"] []
            //h2 [] [text "Violin chart"]
            //div [attr.id "violinchartDiv"] []
            h2 [] [text "CandleStick chart"]
            div [attr.id "candlestickchartDiv"] []
            h2 [] [text "Funnel chart"]
            div [attr.id "funnelchartDiv"] []        
            h2 [] [text "FunnelArea chart"]
            div [attr.id "funnelareachartDiv"] []
            h2 [] [text "Indicator chart"]
            div [attr.id "indicatorchartDiv"] []
            h2 [] [text "OHLC chart"]
            div [attr.id "ohlcchartDiv"] []  
            h2 [] [text "Waterfall chart"]
            div [attr.id "waterfallchartDiv"] []            
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
        hg2dContChart |> ignore
        //violinChart |> ignore
        candleStickChart |> ignore
        funnelChart |> ignore
        funnelAreaChart |> ignore
        indicatorChart |> ignore
        ohlcChart |> ignore
        waterfallChart |> ignore
