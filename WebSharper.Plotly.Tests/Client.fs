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

    let carpet = CarpetOptions()
    carpet.A <- [|
        4.0; 4.0; 4.0; 4.5; 4.5; 4.5;
        5.0; 5.0; 5.0; 6.0; 6.0; 6.0
    |]
    carpet.B <- [|1;2;3;1;2;3;1;2;3;1;2;3|]
    carpet.Y <- [|2.0;3.5;4.0;3.0;4.5;5.0;5.5;6.5;7.5;8.0;8.5;10.0|]

    let scatterTrace = ScatterOptions()
    scatterTrace.X <- [|1; 2; 3; 4 |]
    scatterTrace.Y <- [|10; 15; 13; 17 |]
    scatterTrace.Mode <- ScatterModes.Lines_markers
    scatterTrace.Showlegend <- true

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
    violin.Y <- [|34;52;34;42;345;665;34;23;54;436;65;34;235;654;345|]
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
    indicator.Domain <- IndicatorDomain(
        Row = 0,
        Column = 0
    )
    indicator.Title <- IndicatorTitle(
        Text = "Speed"
    )
    indicator.Mode <- IndicatorMode.Number_delta_gauge

    let indicatorLayout = WebSharper.Plotly.Layout()
    indicatorLayout.Width <- 600
    indicatorLayout.Height <- 400
    indicatorLayout.Margin <- LayoutMargin(T = 25, B = 25, L = 25, R = 25)
    indicatorLayout.Grid <- LayoutGrid(
        Rows = 2,
        Columns = 2,
        Pattern = LayoutGridPattern.Independent
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

    let choropleth = ChoroplethOptions()
    choropleth.Locationmode <- ChoroplethLocationMode.CountryNames
    choropleth.Locations <- [|"Montreal";"Toronto";"Vancouver";"Calgary";"Edmonton";"Ottawa";"Halifax";"Victoria";"Winnepeg";"Regina"|]
    choropleth.Z <- [|234;234;23;235;45;23;23;5;24;234|]
    choropleth.Text <- Union2Of2([|"a";"b";"c";"d";"e";"f";"g";"h";"i";"j"|])
    choropleth.Autocolorscale <- true

    (*let choroplethmb = ChoroplethMBOptions()
    choroplethmb.Locations <- [|"NY";"MA";"VT"|]
    choroplethmb.Z <- [|-50;-10;-20|]
    choroplethmb.Geojson <- "https://raw.githubusercontent.com/python-visualization/folium/master/examples/data/us-states.json"
    *)
    let densitymb = DensityMBOptions()
    densitymb.Lon <- [|10;20;30|]
    densitymb.Lat <- [|15;25;35|]
    densitymb.Z <- [|1;3;2|]

    let scattergeo = ScatterGeoOptions()
    scattergeo.Mode <- ScatterGeoModes.Markers_text
    scattergeo.Text <- Union2Of2([|
        "Montreal";"Toronto";"Vancouver";"Calgary";
        "Edmonton";"Ottawa";"Halifax";"Victoria";
        "Winnepeg";"Regina"
    |])
    scattergeo.Lon <- [|
        -73.57; -79.24; -123.06; -114.1; -113.28;
        -75.43; -63.57; -123.21; -97.13; -104.6    
    |]
    scattergeo.Lat <- [|
        45.5; 43.4; 49.13; 51.1; 53.34; 45.24;
        44.64; 48.25; 49.89; 50.45
    |]
    scattergeo.Marker <- ScatterGeoMarker(
        Size = 7,
        Color = [|
            "#bebada"; "#fdb462"; "#fb8072"; "#d9d9d9"; "#bc80bd";
            "#b3de69"; "#8dd3c7"; "#80b1d3"; "#fccde5"; "#ffffb3"
        |],
        Line = ScatterGeoMarkerLine(
            Width = 1
        )
    )
    scattergeo.Name <- "Canadian cities"
    scattergeo.Textposition <- [|
        ScatterGeoTextPosition.TopRight;
        ScatterGeoTextPosition.TopLeft;
        ScatterGeoTextPosition.TopCenter;
        ScatterGeoTextPosition.BottomRight;
        ScatterGeoTextPosition.TopRight;
        ScatterGeoTextPosition.TopLeft;
        ScatterGeoTextPosition.BottomRight;
        ScatterGeoTextPosition.BottomLeft;
        ScatterGeoTextPosition.TopRight;
        ScatterGeoTextPosition.TopRight;
    |]

    let scattermb = ScatterMBOptions()
    scattermb.Lat <- [|"45.5017"|]
    scattermb.Lon <- [|"-73.5673"|]
    scattermb.Mode <- ScatterMBModes.Markers
    scattermb.Marker <- ScatterMBMarker(
        Size = 14
    )
    scattermb.Text <- Union2Of2([|"Montreal"|])

    let cone = ConeOptions()
    cone.X <- Union1Of2([|1|])
    cone.Y <- Union1Of2([|1|])
    cone.Z <- Union1Of2([|1|])
    cone.U <- Union1Of2([|1|])
    cone.V <- Union1Of2([|1|])
    cone.W <- Union1Of2([|0|])

    let isosurface = ISOSurfaceOptions()
    isosurface.X <- [|0;0;0;0;1;1;1;1|]
    isosurface.Y <- [|0;1;0;1;0;1;0;1|]
    isosurface.Z <- [|1;1;0;0;1;1;0;0|]
    isosurface.Value <- [|1;2;3;4;5;6;7;8|]
    isosurface.Isomin <- 2
    isosurface.Isomax <- 6
    isosurface.Colorscale <- "Reds"

    let mesh = MeshOptions()
    mesh.X <- [|34;52;34;42;345;665;34;23;54;436;65;34;235;654;345|]
    mesh.Y <- [|534;345;34;65;865;34;54;764;234;54;34;64;34;345;45|]
    mesh.Z <- [|56;456;234;54;56;687;34;45;345;56;34;345;456;45;45|]
    mesh.Opacity <- 0.8
    mesh.Color <- "rgb(300,100,200)"

    let option1 = WebSharper.Plotly.Options()
    option1.Locale <- "fr"

    let scatter3d = Scatter3DOptions()
    scatter3d.X <- [|234;234;23;235;45;23;23;5;24;234;4;334;234;43;234;543;134;645;345;234;64|]
    scatter3d.Y <- [|234;234;23;235;45;23;23;5;24;234;4;334;234;43;234;543;134;645;345;234;64|]
    scatter3d.Z <- [|234;234;23;235;45;23;23;5;24;234;4;334;234;43;234;543;134;645;345;234;64|]
    scatter3d.Mode <- Scatter3DModes.Markers
    scatter3d.Marker <- Scatter3DMarker(
        Size = 12,
        Line = Scatter3DMarkerLine(
            Color = "rgba(217, 217, 217, 0.14)",
            Width = 0.5,
            Opacity = 0.8
        )
    )

    let streamtube = StreamTubeOptions()
    streamtube.X <- [|1;1;1;1;1;1;1;1;1;1|]
    streamtube.Y <- [|1;1;1;1;1;0;0;0;-1;-1|]
    streamtube.Z <- [|0;0;0;0;0;0;0;0;0;0|]
    streamtube.U <- [|0;0;0;0;0;0;1;1;1;2|]
    streamtube.V <- [|0;0;0;1;1;1;1;2;2;2|]
    streamtube.W <- [|0;1;2;0;1;2;0;1;2;0|]
    streamtube.Sizeref <- 0.5
    streamtube.Cmin <- 0
    streamtube.Cmax <- 3

    let streamTubeLayout = Layout()
    streamTubeLayout.Scene <- LayoutScene(
        Camera = LayoutSceneCamera(
            Eye = LayoutCameraAxises(
                X = -0.7243612458865182,
                Y = 1.9269804254717962,
                Z = 0.6704828299861716
            )
        )
    )

    let surface = SurfaceOptions()
    surface.Z <- [|[|34;52;34;42;345;665;34;23;54;436;65;34;235;654;345|];[|65;34;654;345;235;34;42;345;34;52;54;436;665;34;23|]|]

    //VOLUME

    let ccarpet = ContourCarpetOptions()
    ccarpet.A <- [|0; 1; 2; 3; 0; 1; 2; 3; 0; 1; 2; 3|]
    ccarpet.B <- [|4; 4; 4; 4; 5; 5; 5; 5; 6; 6; 6; 6|]
    ccarpet.Z <- [|
        1.0; 1.96; 2.56; 3.0625; 4.0; 5.0625;
        1.0; 7.5625; 9.0; 12.25; 15.21; 14.0625
    |]
    ccarpet.Autocontour <- false
    ccarpet.Contours <- ContourCarpetContours(
        Start = 1,
        End = 14,
        Size = 1
    )
    ccarpet.Line <- ContourCarpetLine(
        Width = 0.4,
        Smoothing = 0
    )
    ccarpet.Colorbar <- ContourCarpetColorBar(
        Len = 0.4,
        Y = 0.25
    )

    //Icicle

    let parcats = ParCatsOptions()
    parcats.Dimensions <- [|
        ParCatsDimensions(
            Label = "Hair",
            Values = [|"Black"; "Black"; "Black"; "Brown";
              "Brown"; "Brown"; "Red"; "Brown"|]
        );
        ParCatsDimensions(
            Label = "Eye",
            Values = [|"Brown"; "Brown"; "Brown"; "Brown";
              "Brown"; "Blue"; "Blue"; "Blue"|]
        );
        ParCatsDimensions(
            Label = "Sex",
            Values = [|"Female"; "Female"; "Female"; "Male";
              "Female"; "Male"; "Male"; "Male"|]
        );
    |]

    let parcoords = ParCoordsOptions()
    parcoords.Line <- ParCoordsLine(
        Color = "blue"
    )
    parcoords.Dimensions <- [|
        ParCoordsDimensions(
            Range = [|1;5|],
            Constraintrange = [|1;2|],
            Label = "A",
            Values = [|1;4|]
        );
        ParCoordsDimensions(
            Range = [|1;5|],
            Tickvals = [|1.5;3.0;4.5|],
            Label = "B",
            Values = [|3.0;1.5|]
        );
        ParCoordsDimensions(
            Range = [|1;5|],
            Tickvals = [|1;2;4;5|],
            Label = "C",
            Values = [|2;4|],
            Ticktext = [|"text1";"text2";"text3";"text4";"text5"|]
        );
        ParCoordsDimensions(
            Range = [|1;5|],
            Label = "D",
            Values = [|4;2|]
        )
    |]

    let sankey = SankeyOptions()
    sankey.Orientation <- SankeyOrientation.H
    sankey.Node <- SankeyNode(
        Pad = 15,
        Thickness = 30,
        Line = SankeyNodeLine(
            Color = "black",
            Width = 0.5
        ),
        Label = [|"A1"; "A2"; "B1"; "B2"; "C1"; "C2"|],
        Color = ["blue"; "blue"; "blue"; "blue"; "blue"; "blue"]
    )
    sankey.Link <- SankeyLink(
        Source = [|0;1;0;2;3;3|],
        Target = [|2;3;3;4;4;5|],
        Value = [|8;4;2;8;4;2|]
    )

    let scarpet = CarpetOptions()
    scarpet.A <- Seq.map ((*)1e-6)
        [|4.0;4.0;4.0;4.5;4.5;4.5;5.0;5.0;5.0;6.0;6.0;6.0|]
    scarpet.B <- Seq.map ((*)1e6)
        [|1.0;2.0;3.0;1.0;2.0;3.0;1.0;2.0;3.0;1.0;2.0;3.0|]
    scarpet.Y <- [|2.0;3.5;4.0;3.0;4.5;5.0;5.5;6.5;7.5;8.0;8.5;10.0|]
    scarpet.Aaxis <- CarpetAxis(
        Tickprefix = "a = ",
        Ticksuffix = "m",
        Smoothing = 1,
        Minorgridcount = 9
    )
    scarpet.Baxis <- CarpetAxis(
        Tickprefix = "b = ",
        Ticksuffix = "Pa",
        Smoothing = 1,
        Minorgridcount = 9
    )
    let scattercarpet = ScatterCarpetOptions()
    scattercarpet.A <- Seq.map ((*)1e-6) [|4.0;4.5;5.0;6.0|]
    scattercarpet.B <- Seq.map ((*)1e6) [|1.5;2.5;1.5;2.5|]
    scattercarpet.Line <- ScatterCarpetLine(
        Shape = ScatterCarpetShape.Spline,
        Smoothing = 1
    )

    let spolar = ScatterPolarOptions()
    spolar.R <- [|34;52;34;42;345;665;34;23;54;436;65;34;235;654;345|]
    spolar.Theta <- [|34;52;34;42;345;665;34;23;54;436;65;34;235;654;345|]
    spolar.Mode <- ScatterPolarModes.Lines
    spolar.Name <- "Figure8"
    spolar.Line <- ScatterPolarLine(
        Color = "peru"
    )

    let spolargl1 = ScatterPolarGLOptions()
    spolargl1.R <- [|1;2;3|]
    spolargl1.Theta <- [|50;100;200|]
    spolargl1.Marker <- ScatterPolarGLMarker(
        Symbol = ScatterPolarGLSymbol.Square
    )
    let spolargl2 = ScatterPolarGLOptions()
    spolargl2.R <- [|1;2;3|]
    spolargl2.Theta <- [|1;2;3|]
    spolargl2.Thetaunit <-  ScatterPolarGLThetaUnit.Radians

    let densityMBLayout = Layout()
    densityMBLayout.Width <- 600
    densityMBLayout.Height <- 400
    densityMBLayout.Mapbox <- LayoutMapbox(
        Style = "stamen-terrain"
    )

    let scatterGeoLayout = Layout()
    scatterGeoLayout.Title <- LayoutTitle(
        Text = "Canadian cities",
        Font = LayoutFontConfig(
            Size = 16
        )
    )
    scatterGeoLayout.Font <- LayoutFontConfig(
        Family = "Droid Serif, serif",
        Size = 6
    )
    scatterGeoLayout.Geo <- LayoutGeo(
        Scope = LayoutGeoScope.North_america,
        Resolution = LayoutGeoResolution.``50``,
        Lonaxis = LayoutGeoAxis(
            Range = [|-130;-55|] 
        ),
        Lataxis = LayoutGeoAxis(
            Range = [|40;70|] 
        ),
        Showrivers = true,
        Rivercolor = "#fff",
        Showlakes = true,
        Lakecolor = "#fff",
        Showland = true,
        Landcolor = "#fff",
        Countrycolor = "EAEAAE",
        Countrywidth = 1.5,
        Subunitcolor = "#d3d3d3"
    )

    let scatterMBLayout = Layout()
    scatterMBLayout.Autosize <- true
    scatterMBLayout.Hovermode <- LayoutHoverMode.Closest
    scatterMBLayout.Mapbox <- LayoutMapbox(
        Bearing = 0,
        Center = LayoutCenter(
            Lat = 45,
            Lon = -73
        ),
        Pitch = 0,
        Zoom = 5
    )

    let scatter3DLayout = Layout()
    scatter3DLayout.Margin <- LayoutMargin(
        L = 0,
        R = 0,
        B = 0,
        T = 0
    )

    let surfaceLayout = Layout()
    surfaceLayout.Title <- LayoutTitle(Text = "Mt Bruno Elevation")
    surfaceLayout.Autosize <- false
    surfaceLayout.Width <- 500
    surfaceLayout.Height <- 500
    surfaceLayout.Margin <- LayoutMargin(
        L = 65,
        R = 50,
        B = 65,
        T = 90    
    )

    let ccarpetLayout = Layout()
    ccarpetLayout.Title <- LayoutTitle(Text = "Cheater plot with 1d input")
    ccarpetLayout.Margin <- LayoutMargin(
        T = 40,
        R = 30,
        B = 30,
        L = 30
    )
    ccarpetLayout.Yaxis <- LayoutYAxis(
        Range = [|0.388;4.361|]
    )
    ccarpetLayout.Xaxis <- LayoutXAxis(
        Range = [|0.667;5.932|]
    )

    let imageLayout = Layout()
    imageLayout.Images <- [|
        LayoutImage(
            Source = "https://images.plot.ly/language-icons/api-home/r-logo.png",
            Xref = "x",
            Yref = "y",
            X = 1,
            Y = 3,
            Sizex = 2,
            Sizey = 2,
            Sizing = "stretch",
            Opacity = 0.4,
            Layer = "below"

        )
    |]

    let sternary = ScatterTernaryOptions()
    sternary.Mode <- ScatterTernaryModes.Lines
    sternary.Name <- "k"
    sternary.A <- [||]
    sternary.B <- [||]
    sternary.C <- [||]
    sternary.Line <- ScatterTernaryLine(
        Color = "#c00"
    )

    let sternaryLayout = Layout()
    sternaryLayout.Ternary <- LayoutTernary(
        Sum = 100
    )
    sternaryLayout.Showlegend <- false
    sternaryLayout.Width <- 700

    let splom = SplomOptions()
    splom.Dimensions <- SplomDimensions(
        Label = "sepal length",
        Values = [|34;52|]
    )
    splom.Text <- Union2Of2([|"fst"; "snd"|])
    splom.Marker <- SplomMarker(
        Color = [|"#c00";"#343434"|],
        Size = 7,
        Line = SplomMarkerLine(
            Color = "white",
            Width = 0.5
        )
    )

    let splomLayout = Layout()
    splomLayout.Title <- LayoutTitle(Text = "Iris Data set")
    splomLayout.Height <- 400
    splomLayout.Width <- 400
    splomLayout.Autosize <- false
    splomLayout.Hovermode <- LayoutHoverMode.Closest
    splomLayout.Dragmode <- LayoutDragMode.Select
    splomLayout.Plot_bgcolor <- "rgba(240,240,240, 0.95)"

    let sunburst = SunBurstOptions()
    sunburst.Labels <- [|
        "Eve"; "Cain"; "Seth"; "Enos"; "Noam"; "Abel";
        "Awan"; "Enoch"; "Azura"
    |]
    sunburst.Parents <- [|
        ""; "Eve"; "Eve"; "Seth"; "Seth"; "Eve"; "Eve"; "Awan"; "Eve"
    |]
    sunburst.Values <- [|10;14;12;10;2;6;6;4;4|]
    sunburst.Outsidetextfont <- SunBurstFont(
        Size = 20,
        Color = "#377eb8"
    )
    sunburst.Leaf <- SunBurstLeaf(
        Opacity = 0.4
    )
    sunburst.Marker <- SunBurstMarker(
        Line = SunBurstMarkerLine(
            Width = 2
        )
    )

    let sunBurstLayout = Layout()
    sunBurstLayout.Margin <- LayoutMargin(
        L = 0,
        R = 0,
        B = 0,
        T = 0
    )
    sunBurstLayout.Width <- 500
    sunBurstLayout.Height <- 500

    let treemap = TreeMapOptions()
    treemap.Labels <- [|"Eve"; "Cain"; "Seth"; "Enos";
    "Noam"; "Abel"; "Awan"; "Enoch"; "Azura"|]
    treemap.Parents <- [|
        ""; "Eve"; "Eve"; "Seth"; "Seth"; "Eve"; "Eve"; "Awan"; "Eve"
    |]





    let streamTubeChart = Plotly.Plotly.NewPlot("streamtubechartDiv", [|streamtube|], streamTubeLayout)
    let treeMapChart = Plotly.Plotly.NewPlot("treemapchartDiv", [|treemap|])
    let sunBurstChart = Plotly.Plotly.NewPlot("sunburstchartDiv", [|sunburst|], sunBurstLayout)
    let splomChart = Plotly.Plotly.NewPlot("splomchartDiv", [|splom|], splomLayout, null)
    let scatter3DChart = Plotly.Plotly.NewPlot("scatter3dchartDiv", [|scatter3d|], scatter3DLayout, null)
    let sternaryChart = Plotly.Plotly.NewPlot("sternarychartDiv", [|sternary|], sternaryLayout)
    // needs a carpet -- let ccarpetChart = Plotly.Plotly.NewPlot("ccarpetchartDiv", [|ccarpet|],ccarpetLayout, null)
    let densityMBChart = Plotly.Plotly.NewPlot("densitymbchartDiv", [|densitymb|], densityMBLayout)
    let spolarglChart = Plotly.Plotly.NewPlot("spolarglchartDiv", [|spolargl1;spolargl2|])
    let spolarChart = Plotly.Plotly.NewPlot("spolarchartDiv", [|spolar|])
    //let scarpetChart = Plotly.Plotly.NewPlot("sankeychartDiv", [|scattercarpet|])
    let sankeyChart = Plotly.Plotly.NewPlot("sankeychartDiv", [|sankey|])
    let parcoordsChart = Plotly.Plotly.NewPlot("parcoordschartDiv", [|parcoords|])
    let parcatsChart = Plotly.Plotly.NewPlot("parcatschartDiv", [|parcats|])
    let meshChart = Plotly.Plotly.NewPlot("meshchartDiv", [|mesh|], null, option1)
    let isoSurfaceChart = Plotly.Plotly.NewPlot("isochartDiv", [|isosurface|], null, option1)
    let coneChart = Plotly.Plotly.NewPlot("conechartDiv", [|cone|])
    let carpetChart = Plotly.Plotly.NewPlot("carpetchartDiv", [|carpet|])
    let scatterChart = Plotly.Plotly.NewPlot("scatterchartDiv", [|scatterTrace|], null, option1)
    let scatterGLChart = Plotly.Plotly.NewPlot("scatterglchartDiv", [|scatterGLTrace|])
    let pieChart = Plotly.Plotly.NewPlot("piechartDiv", [|pieTrace|])
    let barChart = Plotly.Plotly.NewPlot("barchartDiv", [|barTrace|])
    let heatMapChart = Plotly.Plotly.NewPlot("heatmapchartDiv", [|heatmap|])
    let tableChart = Plotly.Plotly.NewPlot("tablechartDiv", [|table|])
    let heatMapGLChart = Plotly.Plotly.NewPlot("heatmapglchartDiv", [|heatmapgl|])
    let contourChart = Plotly.Plotly.NewPlot("contourchartDiv", [|contour|])
    //layout image obj -- let imageChart = Plotly.Plotly.NewPlot("imagechartDiv", [|scatterTrace|], imageLayout)
    let boxChart = Plotly.Plotly.NewPlot("boxchartDiv", [|box|])
    let hgChart = Plotly.Plotly.NewPlot("hgchartDiv", [|histogram|])
    let hg2dChart = Plotly.Plotly.NewPlot("hg2dchartDiv", [|histogram2d|])
    let hg2dContChart = Plotly.Plotly.NewPlot("hg2dcontchartDiv", [|hg2dcontour|])
    let violinChart = Plotly.Plotly.NewPlot("violinchartDiv", [|violin|])
    let candleStickChart = Plotly.Plotly.NewPlot("candlestickchartDiv", [|candlestick|])
    let funnelChart = Plotly.Plotly.NewPlot("funnelchartDiv", [|funnel|])
    let funnelAreaChart = Plotly.Plotly.NewPlot("funnelareachartDiv", [|funnelarea|])
    let indicatorChart = Plotly.Plotly.NewPlot("indicatorchartDiv", [|indicator|], indicatorLayout)
    let ohlcChart = Plotly.Plotly.NewPlot("ohlcchartDiv", [|ohlc|], null, option1)
    let waterfallChart = Plotly.Plotly.NewPlot("waterfallchartDiv", [|waterfall|], null, null)
    let choroplethChart = Plotly.Plotly.NewPlot("choroplethchartDiv", [|choropleth|], null, null)
    // needs a token -- let choroplethMBChart = Plotly.Plotly.NewPlot("choroplethmbchartDiv", [|choroplethmb|], null, null)
    let scatterGeoChart = Plotly.Plotly.NewPlot("scattergeochartDiv", [|scattergeo|], scatterGeoLayout, null)
    let surfaceChart = Plotly.Plotly.NewPlot("surfacechartDiv", [|surface|], surfaceLayout)
    //let scatterMBChart = Plotly.Plotly.NewPlot("scattermbchartDiv", [|scattermb|], scatterMBLayout)


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
            h2 [] [text "Violin chart"]
            div [attr.id "violinchartDiv"] []
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
            h2 [] [text "Choropleth chart"]
            div [attr.id "choroplethchartDiv"] []
            //h2 [] [text "ChoroplethMB chart"]
            //div [attr.id "choroplethmbchartDiv"] []
            h2 [] [text "DensityMB chart"]
            div [attr.id "densitymbchartDiv"] []
            h2 [] [text "ScatterGeo chart"]
            div [attr.id "scattergeochartDiv"] []
            //h2 [] [text "ScatterMB chart"]
            //div [attr.id "scattermbchartDiv"] []
            h2 [] [text "Cone chart"]
            div [attr.id "conechartDiv"] []
            h2 [] [text "Carpet chart"]
            div [attr.id "carpetchartDiv"] []
            h2 [] [text "ISOSurface chart"]
            div [attr.id "isochartDiv"] []
            h2 [] [text "Mesh chart"]
            div [attr.id "meshchartDiv"] []
            h2 [] [text "Scatter3D chart"]
            div [attr.id "scatter3dchartDiv"] []
            h2 [] [text "StreamTube chart"]
            div [attr.id "streamtubechartDiv"] []
            h2 [] [text "Surface chart"]
            div [attr.id "surfacechartDiv"] []
            //h2 [] [text "ContourCarpet chart"]
            //div [attr.id "ccarpetchartDiv"] []
            h2 [] [text "Parallel Categories chart"]
            div [attr.id "parcatschartDiv"] []
            h2 [] [text "Parallel Coordinates chart"]
            div [attr.id "parcoordschartDiv"] []
            h2 [] [text "Sankey chart"]
            div [attr.id "sankeychartDiv"] []
            //h2 [] [text "ScatterCarpet chart"]
            //div [attr.id "scarpetchartDiv"] []
            h2 [] [text "ScatterPolar chart"]
            div [attr.id "spolarchartDiv"] []
            h2 [] [text "ScatterPolarGL chart"]
            div [attr.id "spolarglchartDiv"] []
            h2 [] [text "ScatterTernary chart"]
            div [attr.id "sternarychartDiv"] []
            h2 [] [text "Splom chart"]
            div [attr.id "splomchartDiv"] []
            h2 [] [text "SunBurst chart"]
            div [attr.id "sunburstchartDiv"] []
            h2 [] [text "TreeMap chart"]
            div [attr.id "treemapchartDiv"] []
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
        violinChart |> ignore
        candleStickChart |> ignore
        funnelChart |> ignore
        funnelAreaChart |> ignore
        indicatorChart |> ignore
        ohlcChart |> ignore
        waterfallChart |> ignore
        choroplethChart |> ignore
        //choroplethMBChart |> ignore
        densityMBChart |> ignore
        scatterGeoChart |> ignore
        //scatterMBChart |> ignore
        coneChart |> ignore
        carpetChart |> ignore
        isoSurfaceChart |> ignore
        meshChart |> ignore
        scatter3DChart |> ignore
        streamTubeChart |> ignore
        surfaceChart |> ignore
        //ccarpetChart |> ignore
        parcatsChart |> ignore
        parcoordsChart |> ignore
        sankeyChart |> ignore
        //scarpetChart |> ignore
        spolarChart |> ignore
        spolarglChart |> ignore
        sternaryChart |> ignore
        splomChart |> ignore
        sunBurstChart |> ignore
        treeMapChart |> ignore
