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
    // The templates are loaded from the DOM, so you just can edit index.html
    // and refresh your browser, no need to recompile unless you add or remove holes.
    type IndexTemplate = Template<"wwwroot/index.html", ClientLoad.FromDocument>

    let People =
        ListModel.FromSeq [
            "John"
            "Paul"
        ]

    //let Tests = ScatterOptions2(Hoverinfo = HoverInfo.All)

    let symbolTest = Plotly.Symbol.Triangle_sw_open_dot

    let marker = Plotly.Marker(Symbol = symbolTest)

    (*x: [1, 2, 3, 4],
    y: [10, 15, 13, 17],
    mode: 'markers',*)

    let x =
        [|1; 2; 3; 4 |]
        |> Array.map (Number)

    let y =
        [|10; 15; 13; 17 |]
        |> Array.map (Number)

    let scatterTrace = ScatterOptions()
    scatterTrace.X <- x
    scatterTrace.Y <- y

    let chart = Plotly.Plotly.NewPlot("myDiv", [|scatterTrace|])

    //Console.Log(Tests)

    [<SPAEntryPoint>]
    let Main () =
        let newName = Var.Create ""

        IndexTemplate.Main()
            .ListContainer(
                People.View.DocSeqCached(fun (name: string) ->
                    IndexTemplate.ListItem().Name(name).Doc()
                )
            )
            .Name(newName)
            .Add(fun _ ->
                People.Add(newName.Value)
                newName.Value <- ""
            )
            .Doc()
        |> Doc.RunById "main"
        chart
