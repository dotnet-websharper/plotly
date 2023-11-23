import Runtime, { LoadScript, Start as Start_1 } from "./WebSharper.Core.JavaScript/Runtime.js"
Runtime.ScriptBasePath="/Content/";
LoadScript("WebSharper.UI/closest.js");
LoadScript("WebSharper.Main/AnimFrame.js");
import plotly_js_dist_min from "plotly.js-dist-min"
import { Create as Create_1, Lazy, Force, GetOptional, SetOptional, OnLoad } from "./WebSharper.Core.JavaScript/Runtime.js"
function isIDisposable(x){
  return"Dispose"in x;
}
function Main(){
  const _1=_c_3.Element("div", [OnAfterRender(() => {
    iter((x) => {
      x();
    }, ofArray([scatterChart, pieChart, barChart, heatMapChart, tableChart, contourChart, imageChart, boxChart, hgChart, hg2dChart, hg2dContChart, violinChart, candleStickChart, funnelChart, funnelAreaChart, indicatorChart, ohlcChart, waterfallChart, choroplethChart, scatterGeoChart, carpetChart, isoSurfaceChart, ccarpetChart, parcatsChart, sankeyChart, scarpetChart, spolarChart, sternaryChart, sunBurstChart, treeMapChart, icicleChart, barpolarChart]));
    const _2=null;
    Start(Delay(() => Bind(Sequential(map((renderer) => {
      const _3=null;
      return Delay(() => {
        renderer();
        return Bind(Sleep(1000), () => Return(null));
      });
    }, ofArray([scatterGLChart, spolarglChart, heatMapGLChart, splomChart, parcoordsChart, scatter3DChart, surfaceChart, streamTubeChart, meshChart, coneChart, scatterMBChart, choroplethMBChart, densityMBChart]))), () => Zero())), null);
  })], [_c_3.Element("h1", [], [_c_3.TextNode("Plotly Js sample site")]), _c_3.Element("h2", [], [_c_3.TextNode("Scatter chart")]), _c_3.Element("div", [_c_4.Create("id", "scatterchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("ScatterGL chart")]), _c_3.Element("div", [_c_4.Create("id", "scatterglchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Pie chart")]), _c_3.Element("div", [_c_4.Create("id", "piechartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Bar chart")]), _c_3.Element("div", [_c_4.Create("id", "barchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Heatmap chart")]), _c_3.Element("div", [_c_4.Create("id", "heatmapchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Table chart")]), _c_3.Element("div", [_c_4.Create("id", "tablechartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("HeatMapGL chart")]), _c_3.Element("div", [_c_4.Create("id", "heatmapglchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Contour chart")]), _c_3.Element("div", [_c_4.Create("id", "contourchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Image chart")]), _c_3.Element("div", [_c_4.Create("id", "imagechartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Box chart")]), _c_3.Element("div", [_c_4.Create("id", "boxchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Histogram chart")]), _c_3.Element("div", [_c_4.Create("id", "hgchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Histogram2D chart")]), _c_3.Element("div", [_c_4.Create("id", "hg2dchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Histogram2DContour chart")]), _c_3.Element("div", [_c_4.Create("id", "hg2dcontchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Violin chart")]), _c_3.Element("div", [_c_4.Create("id", "violinchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("CandleStick chart")]), _c_3.Element("div", [_c_4.Create("id", "candlestickchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Funnel chart")]), _c_3.Element("div", [_c_4.Create("id", "funnelchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("FunnelArea chart")]), _c_3.Element("div", [_c_4.Create("id", "funnelareachartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Indicator chart")]), _c_3.Element("div", [_c_4.Create("id", "indicatorchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("OHLC chart")]), _c_3.Element("div", [_c_4.Create("id", "ohlcchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Waterfall chart")]), _c_3.Element("div", [_c_4.Create("id", "waterfallchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Choropleth chart")]), _c_3.Element("div", [_c_4.Create("id", "choroplethchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("ChoroplethMB chart")]), _c_3.Element("div", [_c_4.Create("id", "choroplethmbchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("DensityMB chart")]), _c_3.Element("div", [_c_4.Create("id", "densitymbchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("ScatterGeo chart")]), _c_3.Element("div", [_c_4.Create("id", "scattergeochartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("ScatterMB chart")]), _c_3.Element("div", [_c_4.Create("id", "scattermbchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Cone chart")]), _c_3.Element("div", [_c_4.Create("id", "conechartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Carpet chart")]), _c_3.Element("div", [_c_4.Create("id", "carpetchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("ISOSurface chart")]), _c_3.Element("div", [_c_4.Create("id", "isochartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Mesh chart")]), _c_3.Element("div", [_c_4.Create("id", "meshchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Scatter3D chart")]), _c_3.Element("div", [_c_4.Create("id", "scatter3dchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("StreamTube chart")]), _c_3.Element("div", [_c_4.Create("id", "streamtubechartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Surface chart")]), _c_3.Element("div", [_c_4.Create("id", "surfacechartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("ContourCarpet chart")]), _c_3.Element("div", [_c_4.Create("id", "ccarpetchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Parallel Categories chart")]), _c_3.Element("div", [_c_4.Create("id", "parcatschartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Parallel Coordinates chart")]), _c_3.Element("div", [_c_4.Create("id", "parcoordschartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Sankey chart")]), _c_3.Element("div", [_c_4.Create("id", "sankeychartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("ScatterCarpet chart")]), _c_3.Element("div", [_c_4.Create("id", "scarpetchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("ScatterPolar chart")]), _c_3.Element("div", [_c_4.Create("id", "spolarchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("ScatterPolarGL chart")]), _c_3.Element("div", [_c_4.Create("id", "spolarglchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("ScatterTernary chart")]), _c_3.Element("div", [_c_4.Create("id", "sternarychartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Splom chart")]), _c_3.Element("div", [_c_4.Create("id", "splomchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("SunBurst chart")]), _c_3.Element("div", [_c_4.Create("id", "sunburstchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("TreeMap chart")]), _c_3.Element("div", [_c_4.Create("id", "treemapchartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Icicle chart")]), _c_3.Element("div", [_c_4.Create("id", "iciclechartDiv")], []), _c_3.Element("h2", [], [_c_3.TextNode("Bar Polar chart")]), _c_3.Element("div", [_c_4.Create("id", "barpolarchartDiv")], [])]);
  LoadLocalTemplates("");
  _c_3.RunById("main", _1);
}
function scatterChart(){
  return plotly_js_dist_min.newPlot("scatterchartDiv", [scatterTrace()], null, option1());
}
function pieChart(){
  return plotly_js_dist_min.newPlot("piechartDiv", [pieTrace()]);
}
function barChart(){
  return plotly_js_dist_min.newPlot("barchartDiv", [barTrace()]);
}
function heatMapChart(){
  return plotly_js_dist_min.newPlot("heatmapchartDiv", [heatmap()]);
}
function tableChart(){
  return plotly_js_dist_min.newPlot("tablechartDiv", [table()]);
}
function contourChart(){
  return plotly_js_dist_min.newPlot("contourchartDiv", [contour()]);
}
function imageChart(){
  return plotly_js_dist_min.newPlot("imagechartDiv", [image()], imageLayout());
}
function boxChart(){
  return plotly_js_dist_min.newPlot("boxchartDiv", [box()]);
}
function hgChart(){
  return plotly_js_dist_min.newPlot("hgchartDiv", [histogram()]);
}
function hg2dChart(){
  return plotly_js_dist_min.newPlot("hg2dchartDiv", [histogram2d()]);
}
function hg2dContChart(){
  return plotly_js_dist_min.newPlot("hg2dcontchartDiv", [hg2dcontour()]);
}
function violinChart(){
  return plotly_js_dist_min.newPlot("violinchartDiv", [violin()]);
}
function candleStickChart(){
  return plotly_js_dist_min.newPlot("candlestickchartDiv", [candlestick()]);
}
function funnelChart(){
  return plotly_js_dist_min.newPlot("funnelchartDiv", [funnel()]);
}
function funnelAreaChart(){
  return plotly_js_dist_min.newPlot("funnelareachartDiv", [funnelarea()]);
}
function indicatorChart(){
  return plotly_js_dist_min.newPlot("indicatorchartDiv", [indicator()], indicatorLayout());
}
function ohlcChart(){
  return plotly_js_dist_min.newPlot("ohlcchartDiv", [ohlc()], null);
}
function waterfallChart(){
  return plotly_js_dist_min.newPlot("waterfallchartDiv", [waterfall()], null, null);
}
function choroplethChart(){
  return plotly_js_dist_min.newPlot("choroplethchartDiv", [choropleth()], null, null);
}
function scatterGeoChart(){
  return plotly_js_dist_min.newPlot("scattergeochartDiv", [scattergeo()], scatterGeoLayout(), null);
}
function carpetChart(){
  return plotly_js_dist_min.newPlot("carpetchartDiv", [carpet()]);
}
function isoSurfaceChart(){
  return plotly_js_dist_min.newPlot("isochartDiv", [isosurface()], null);
}
function ccarpetChart(){
  return plotly_js_dist_min.newPlot("ccarpetchartDiv", [ccarpet(), contourcarpet()], ccarpetLayout(), null);
}
function parcatsChart(){
  return plotly_js_dist_min.newPlot("parcatschartDiv", [parcats()]);
}
function sankeyChart(){
  return plotly_js_dist_min.newPlot("sankeychartDiv", [sankey()]);
}
function scarpetChart(){
  return plotly_js_dist_min.newPlot("scarpetchartDiv", [scarpet(), scattercarpet()]);
}
function spolarChart(){
  return plotly_js_dist_min.newPlot("spolarchartDiv", [spolar()]);
}
function sternaryChart(){
  return plotly_js_dist_min.newPlot("sternarychartDiv", [sternary()], sternaryLayout());
}
function sunBurstChart(){
  return plotly_js_dist_min.newPlot("sunburstchartDiv", [sunburst()], sunBurstLayout());
}
function treeMapChart(){
  return plotly_js_dist_min.newPlot("treemapchartDiv", [treemap()]);
}
function icicleChart(){
  return plotly_js_dist_min.newPlot("iciclechartDiv", [icicle()], icicleLayout());
}
function barpolarChart(){
  return plotly_js_dist_min.newPlot("barpolarchartDiv", [barpolar1(), barpolar2(), barpolar3(), barpolar4()], barpolarLayout());
}
function scatterGLChart(){
  return plotly_js_dist_min.newPlot("scatterglchartDiv", [scatterGLTrace()]);
}
function spolarglChart(){
  return plotly_js_dist_min.newPlot("spolarglchartDiv", [spolargl1(), spolargl2()], null, option2());
}
function heatMapGLChart(){
  return plotly_js_dist_min.newPlot("heatmapglchartDiv", [heatmapgl()]);
}
function splomChart(){
  return plotly_js_dist_min.newPlot("splomchartDiv", [splom()], splomLayout(), null);
}
function parcoordsChart(){
  return plotly_js_dist_min.newPlot("parcoordschartDiv", [parcoords()]);
}
function scatter3DChart(){
  return plotly_js_dist_min.newPlot("scatter3dchartDiv", [scatter3d()], scatter3DLayout(), null);
}
function surfaceChart(){
  return plotly_js_dist_min.newPlot("surfacechartDiv", [surface()], surfaceLayout());
}
function streamTubeChart(){
  return plotly_js_dist_min.newPlot("streamtubechartDiv", [streamtube()], streamTubeLayout());
}
function meshChart(){
  return plotly_js_dist_min.newPlot("meshchartDiv", [mesh()], null);
}
function coneChart(){
  return plotly_js_dist_min.newPlot("conechartDiv", [cone()]);
}
function scatterMBChart(){
  return plotly_js_dist_min.newPlot("scattermbchartDiv", [scattermb()], scatterMBLayout());
}
function choroplethMBChart(){
  return plotly_js_dist_min.newPlot("choroplethmbchartDiv", [choroplethmb()], choroplethMBLayout(), null);
}
function densityMBChart(){
  return plotly_js_dist_min.newPlot("densitymbchartDiv", [densitymb()], densityMBLayout());
}
function scatterTrace(){
  return _c_5.scatterTrace;
}
function option1(){
  return _c_5.option1;
}
function pieTrace(){
  return _c_5.pieTrace;
}
function barTrace(){
  return _c_5.barTrace;
}
function heatmap(){
  return _c_5.heatmap;
}
function table(){
  return _c_5.table;
}
function contour(){
  return _c_5.contour;
}
function image(){
  return _c_5.image;
}
function imageLayout(){
  return _c_5.imageLayout;
}
function box(){
  return _c_5.box;
}
function histogram(){
  return _c_5.histogram;
}
function histogram2d(){
  return _c_5.histogram2d;
}
function hg2dcontour(){
  return _c_5.hg2dcontour;
}
function violin(){
  return _c_5.violin;
}
function candlestick(){
  return _c_5.candlestick;
}
function funnel(){
  return _c_5.funnel;
}
function funnelarea(){
  return _c_5.funnelarea;
}
function indicator(){
  return _c_5.indicator;
}
function indicatorLayout(){
  return _c_5.indicatorLayout;
}
function ohlc(){
  return _c_5.ohlc;
}
function waterfall(){
  return _c_5.waterfall;
}
function choropleth(){
  return _c_5.choropleth;
}
function scattergeo(){
  return _c_5.scattergeo;
}
function scatterGeoLayout(){
  return _c_5.scatterGeoLayout;
}
function carpet(){
  return _c_5.carpet;
}
function isosurface(){
  return _c_5.isosurface;
}
function ccarpet(){
  return _c_5.ccarpet;
}
function contourcarpet(){
  return _c_5.contourcarpet;
}
function ccarpetLayout(){
  return _c_5.ccarpetLayout;
}
function parcats(){
  return _c_5.parcats;
}
function sankey(){
  return _c_5.sankey;
}
function scarpet(){
  return _c_5.scarpet;
}
function scattercarpet(){
  return _c_5.scattercarpet;
}
function spolar(){
  return _c_5.spolar;
}
function sternary(){
  return _c_5.sternary;
}
function sternaryLayout(){
  return _c_5.sternaryLayout;
}
function sunburst(){
  return _c_5.sunburst;
}
function sunBurstLayout(){
  return _c_5.sunBurstLayout;
}
function treemap(){
  return _c_5.treemap;
}
function icicle(){
  return _c_5.icicle;
}
function icicleLayout(){
  return _c_5.icicleLayout;
}
function barpolar1(){
  return _c_5.barpolar1;
}
function barpolar2(){
  return _c_5.barpolar2;
}
function barpolar3(){
  return _c_5.barpolar3;
}
function barpolar4(){
  return _c_5.barpolar4;
}
function barpolarLayout(){
  return _c_5.barpolarLayout;
}
function scatterGLTrace(){
  return _c_5.scatterGLTrace;
}
function spolargl1(){
  return _c_5.spolargl1;
}
function spolargl2(){
  return _c_5.spolargl2;
}
function option2(){
  return _c_5.option2;
}
function heatmapgl(){
  return _c_5.heatmapgl;
}
function splom(){
  return _c_5.splom;
}
function splomLayout(){
  return _c_5.splomLayout;
}
function parcoords(){
  return _c_5.parcoords;
}
function scatter3d(){
  return _c_5.scatter3d;
}
function scatter3DLayout(){
  return _c_5.scatter3DLayout;
}
function surface(){
  return _c_5.surface;
}
function surfaceLayout(){
  return _c_5.surfaceLayout;
}
function streamtube(){
  return _c_5.streamtube;
}
function streamTubeLayout(){
  return _c_5.streamTubeLayout;
}
function mesh(){
  return _c_5.mesh;
}
function cone(){
  return _c_5.cone;
}
function scattermb(){
  return _c_5.scattermb;
}
function scatterMBLayout(){
  return _c_5.scatterMBLayout;
}
function choroplethmb(){
  return _c_5.choroplethmb;
}
function choroplethMBLayout(){
  return _c_5.choroplethMBLayout;
}
function densitymb(){
  return _c_5.densitymb;
}
function densityMBLayout(){
  return _c_5.densityMBLayout;
}
function FailWith(msg){
  throw new Error(msg);
}
function KeyValue(kvp){
  return[kvp.K, kvp.V];
}
function range(min, max_1){
  const count=1+max_1-min;
  return count<=0?[]:init_1(count, (x) => x+min);
}
function ofArray(arr){
  let r=_c_2.Empty;
  for(let i=length(arr)-1, _1=0;i>=_1;i--)r=_c_2.Cons(get(arr, i), r);
  return r;
}
function iter(f, l){
  let r=l;
  while(r.$==1)
    {
      f(head(r));
      r=tail(r);
    }
}
function map(f, x){
  let r;
  let l;
  let go;
  if(x.$==0)return x;
  else {
    const res=Create_1(_c_2, {$:1});
    r=res;
    l=x;
    go=true;
    while(go)
      {
        r.$0=f(l.$0);
        l=l.$1;
        if(l.$==0)go=false;
        else {
          const t=Create_1(_c_2, {$:1});
          r=(r.$1=t,t);
        }
      }
    r.$1=_c_2.Empty;
    return res;
  }
}
function head(l){
  return l.$==1?l.$0:listEmpty();
}
function tail(l){
  return l.$==1?l.$1:listEmpty();
}
function listEmpty(){
  return FailWith("The input list was empty.");
}
let _c=Lazy((_i) => class Object_1 {
  static {
    _c=_i(this);
  }
  Equals(obj){
    return this===obj;
  }
  GetHashCode(){
    return -1;
  }
});
let _c_1=Lazy((_i) => class attr extends _c {
  static {
    _c_1=_i(this);
  }
});
function OnAfterRender(callback){
  return _c_4.A4(callback);
}
let _c_2=Lazy((_i) => class FSharpList {
  static {
    _c_2=_i(this);
  }
  static Empty=Create_1(_c_2, {$:0});
  static Cons(Head, Tail){
    return Create_1(FSharpList, {
      $:1, 
      $0:Head, 
      $1:Tail
    });
  }
  GetEnumerator(){
    return new _c_19(this, null, (e) => {
      const m=e.s;
      return m.$==0?false:(e.c=m.$0,e.s=m.$1,true);
    }, void 0);
  }
});
function get(arr, n){
  checkBounds(arr, n);
  return arr[n];
}
function length(arr){
  return arr.dims===2?arr.length*arr.length:arr.length;
}
function checkBounds(arr, n){
  if(n<0||n>=arr.length)FailWith("Index was outside the bounds of the array.");
}
function set(arr, n, x){
  checkBounds(arr, n);
  arr[n]=x;
}
function Equals(a, b){
  if(a===b)return true;
  else {
    const m=typeof a;
    if(m=="object"){
      if(a===null||a===void 0||b===null||b===void 0||!Equals(typeof b, "object"))return false;
      else if("Equals"in a)return a.Equals(b);
      else if("Equals"in b)return false;
      else if(a instanceof Array&&b instanceof Array)return arrayEquals(a, b);
      else if(a instanceof Date&&b instanceof Date)return dateEquals(a, b);
      else {
        const eqR=[true];
        let k;
        for(var k_2 in a)if(((k_3) => {
          eqR[0]=!a.hasOwnProperty(k_3)||b.hasOwnProperty(k_3)&&Equals(a[k_3], b[k_3]);
          return!eqR[0];
        })(k_2))break;
        if(eqR[0]){
          let k_1;
          for(var k_3 in b)if(((k_4) => {
            eqR[0]=!b.hasOwnProperty(k_4)||a.hasOwnProperty(k_4);
            return!eqR[0];
          })(k_3))break;
        }
        return eqR[0];
      }
    }
    else return m=="function"&&("$Func"in a?a.$Func===b.$Func&&a.$Target===b.$Target:"$Invokes"in a&&"$Invokes"in b&&arrayEquals(a.$Invokes, b.$Invokes));
  }
}
function arrayEquals(a, b){
  let eq;
  let i;
  if(length(a)===length(b)){
    eq=true;
    i=0;
    while(eq&&i<length(a))
      {
        !Equals(get(a, i), get(b, i))?eq=false:void 0;
        i=i+1;
      }
    return eq;
  }
  else return false;
}
function dateEquals(a, b){
  return a.getTime()===b.getTime();
}
function Hash(o){
  const m=typeof o;
  return m=="function"?0:m=="boolean"?o?1:0:m=="number"?o:m=="string"?hashString(o):m=="object"?o==null?0:o instanceof Array?hashArray(o):hashObject(o):0;
}
function hashString(s){
  let hash;
  if(s===null)return 0;
  else {
    hash=5381;
    for(let i=0, _1=s.length-1;i<=_1;i++)hash=hashMix(hash, s[i].charCodeAt());
    return hash;
  }
}
function hashArray(o){
  let h=-34948909;
  for(let i=0, _1=length(o)-1;i<=_1;i++)h=hashMix(h, Hash(get(o, i)));
  return h;
}
function hashObject(o){
  if("GetHashCode"in o)return o.GetHashCode();
  else {
    const h=[0];
    let k;
    for(var k_1 in o)if(((key) => {
      h[0]=hashMix(hashMix(h[0], hashString(key)), Hash(o[key]));
      return false;
    })(k_1))break;
    return h[0];
  }
}
function hashMix(x, y){
  return(x<<5)+x+y;
}
function Compare(a, b){
  if(a===b)return 0;
  else {
    const m=typeof a;
    switch(m=="function"?1:m=="boolean"?2:m=="number"?2:m=="string"?2:m=="object"?3:0){
      case 0:
        return typeof b=="undefined"?0:-1;
      case 1:
        return FailWith("Cannot compare function values.");
      case 2:
        return a<b?-1:1;
      case 3:
        if(a===null)return -1;
        else if(b===null)return 1;
        else if("CompareTo"in a)return a.CompareTo(b);
        else if("CompareTo0"in a)return a.CompareTo0(b);
        else if(a instanceof Array&&b instanceof Array)return compareArrays(a, b);
        else if(a instanceof Date&&b instanceof Date)return compareDates(a, b);
        else {
          const cmp=[0];
          let k;
          for(var k_2 in a)if(((k_3) =>!a.hasOwnProperty(k_3)?false:!b.hasOwnProperty(k_3)?(cmp[0]=1,true):(cmp[0]=Compare(a[k_3], b[k_3]),cmp[0]!==0))(k_2))break;
          if(cmp[0]===0){
            let k_1;
            for(var k_3 in b)if(((k_4) =>!b.hasOwnProperty(k_4)?false:!a.hasOwnProperty(k_4)&&(cmp[0]=-1,true))(k_3))break;
          }
          return cmp[0];
        }
        break;
    }
  }
}
function compareArrays(a, b){
  let cmp;
  let i;
  if(length(a)<length(b))return -1;
  else if(length(a)>length(b))return 1;
  else {
    cmp=0;
    i=0;
    while(cmp===0&&i<length(a))
      {
        cmp=Compare(get(a, i), get(b, i));
        i=i+1;
      }
    return cmp;
  }
}
function compareDates(a, b){
  return Compare(a.getTime(), b.getTime());
}
function NewFromSeq(fields){
  const r={};
  const e=Get(fields);
  try {
    while(e.MoveNext())
      {
        const f=e.Current;
        r[f[0]]=f[1];
      }
  }
  finally {
    if(typeof e=="object"&&isIDisposable(e))e.Dispose();
  }
  return r;
}
function Delay(mk){
  return(c) => {
    try {
      (mk())(c);
    }
    catch(e){
      c.k(No(e));
    }
  };
}
function Bind(r, f){
  return checkCancel((c) => {
    r(New((a) => {
      if(a.$==0){
        const x=a.$0;
        scheduler().Fork(() => {
          try {
            (f(x))(c);
          }
          catch(e){
            c.k(No(e));
          }
        });
      }
      else scheduler().Fork(() => {
        c.k(a);
      });
    }, c.ct));
  });
}
function Sleep(ms){
  return(c) => {
    let pending;
    let creg;
    pending=void 0;
    creg=void 0;
    pending=setTimeout(() => {
      creg.Dispose();
      scheduler().Fork(() => {
        c.k(Ok(null));
      });
    }, ms);
    creg=Register(c.ct, () => {
      clearTimeout(pending);
      scheduler().Fork(() => {
        cancel(c);
      });
    });
  };
}
function Return(x){
  return(c) => {
    c.k(Ok(x));
  };
}
function Sequential(cs){
  const cs_1=ofSeq(cs);
  return length(cs_1)===0?Return([]):(c) => {
    const n=cs_1.length;
    const a=new Array(n);
    function start(i){
      while(true)
        {
          const action=((i_1) =>() => {
            (get(cs_1, i_1))(New((_1) => accept(i_1, _1), c.ct));
          })(i);
          return scheduler().Fork(action);
        }
    }
    function accept(i, x){
      return x.$==0?(set(a, i, x.$0),i===n-1?c.k(Ok(a)):c.ct.c?cancel(c):start(i+1)):c.k(x);
    }
    start(0);
  };
}
function Zero(){
  return _c_6.Zero;
}
function Start(c, ctOpt){
  const d=(defCTS())[0];
  const ct=ctOpt==null?d:ctOpt.$0;
  scheduler().Fork(() => {
    if(!ct.c)c(New((a) => {
      if(a.$==1)UncaughtAsyncError(a.$0);
    }, ct));
  });
}
function checkCancel(r){
  return(c) => {
    if(c.ct.c)cancel(c);
    else r(c);
  };
}
function Register(ct, callback){
  if(ct===noneCT())return{Dispose(){
    return null;
  }};
  else {
    const i=ct.r.push(callback)-1;
    return{Dispose(){
      return set(ct.r, i, () => { });
    }};
  }
}
function cancel(c){
  c.k(Cc(new _c_9("New", c.ct)));
}
function defCTS(){
  return _c_6.defCTS;
}
function UncaughtAsyncError(e){
  console.log("WebSharper: Uncaught asynchronous exception", e);
}
function scheduler(){
  return _c_6.scheduler;
}
function noneCT(){
  return _c_6.noneCT;
}
function FromContinuations(subscribe){
  return(c) => {
    const continued=[false];
    const once=(cont) => {
      if(continued[0])FailWith("A continuation provided by Async.FromContinuations was invoked multiple times");
      else {
        continued[0]=true;
        scheduler().Fork(cont);
      }
    };
    subscribe((a) => {
      once(() => {
        c.k(Ok(a));
      });
    }, (e) => {
      once(() => {
        c.k(No(e));
      });
    }, (e) => {
      once(() => {
        c.k(Cc(e));
      });
    });
  };
}
let _c_3=Lazy((_i) => class Doc extends _c {
  static {
    _c_3=_i(this);
  }
  docNode;
  updates;
  static TextNode(v){
    return _c_3.Mk(TextNodeDoc(globalThis.document.createTextNode(v)), Const());
  }
  static RunById(id, tr){
    const m=globalThis.document.getElementById(id);
    if(Equals(m, null))FailWith("invalid id: "+id);
    else _c_3.Run(m, tr);
  }
  static Element(name, attr, children){
    const a=_c_4.Concat(attr);
    const a_1=_c_3.Concat(children);
    return _c_14.New(globalThis.document.createElement(name), a, a_1);
  }
  static Mk(node, updates){
    return new Doc(node, updates);
  }
  static Run(parent, doc){
    LinkElement(parent, doc.docNode);
    _c_3.RunInPlace(false, parent, doc);
  }
  static Concat(xs){
    return TreeReduce(_c_3.Empty, _c_3.Append, ofSeqNonCopying(xs));
  }
  static RunInPlace(childrenOnly, parent, doc){
    const st=CreateRunState(parent, doc.docNode);
    Sink(get_UseAnimations()||BatchUpdatesEnabled()?StartProcessor(PerformAnimatedUpdate(childrenOnly, st, doc.docNode)):() => {
      PerformSyncUpdate(childrenOnly, st, doc.docNode);
    }, doc.updates);
  }
  static Append(a, b){
    return _c_3.Mk(AppendDoc(a.docNode, b.docNode), Map2Unit(a.updates, b.updates));
  }
  static get Empty(){
    return _c_3.Mk(null, Const());
  }
  constructor(docNode, updates){
    super();
    this.docNode=docNode;
    this.updates=updates;
  }
});
let _c_4=Lazy((_i) => class Attr {
  static {
    _c_4=_i(this);
  }
  static Create(name, value){
    return Static((el) => {
      el.setAttribute(name, value);
    });
  }
  static A4(onAfterRender){
    return Create_1(Attr, {$:4, $0:onAfterRender});
  }
  static Concat(xs){
    const x=ofSeqNonCopying(xs);
    return TreeReduce(EmptyAttr(), _c_4.Append, x);
  }
  static A3(init_2){
    return Create_1(Attr, {$:3, $0:init_2});
  }
  static Append(a, b){
    return AppendTree(a, b);
  }
  static A2(Item1, Item2){
    return Create_1(Attr, {
      $:2, 
      $0:Item1, 
      $1:Item2
    });
  }
});
function LoadLocalTemplates(baseName){
  !LocalTemplatesLoaded()?(set_LocalTemplatesLoaded(true),LoadNestedTemplates(globalThis.document.body, "")):void 0;
  LoadedTemplates().set_Item(baseName, LoadedTemplateFile(""));
}
function LocalTemplatesLoaded(){
  return _c_12.LocalTemplatesLoaded;
}
function set_LocalTemplatesLoaded(_1){
  _c_12.LocalTemplatesLoaded=_1;
}
function LoadNestedTemplates(root, baseName){
  const loadedTpls=LoadedTemplateFile(baseName);
  const rawTpls=new _c_7("New_5");
  const wsTemplates=root.querySelectorAll("[ws-template]");
  for(let i=0, _1=wsTemplates.length-1;i<=_1;i++){
    const node=wsTemplates[i];
    const name=node.getAttribute("ws-template").toLowerCase();
    node.removeAttribute("ws-template");
    rawTpls.set_Item(name, FakeRootSingle(node));
  }
  const wsChildrenTemplates=root.querySelectorAll("[ws-children-template]");
  for(let i_1=0, _2=wsChildrenTemplates.length-1;i_1<=_2;i_1++){
    const node_1=wsChildrenTemplates[i_1];
    const name_1=node_1.getAttribute("ws-children-template").toLowerCase();
    node_1.removeAttribute("ws-children-template");
    rawTpls.set_Item(name_1, FakeRoot(node_1));
  }
  const html5TemplateBasedTemplates=root.querySelectorAll("template[id]");
  for(let i_2=0, _3=html5TemplateBasedTemplates.length-1;i_2<=_3;i_2++){
    const node_2=html5TemplateBasedTemplates[i_2];
    rawTpls.set_Item(node_2.getAttribute("id").toLowerCase(), FakeRootFromHTMLTemplate(node_2));
  }
  const html5TemplateBasedTemplates_1=root.querySelectorAll("template[name]");
  for(let i_3=0, _4=html5TemplateBasedTemplates_1.length-1;i_3<=_4;i_3++){
    const node_3=html5TemplateBasedTemplates_1[i_3];
    rawTpls.set_Item(node_3.getAttribute("name").toLowerCase(), FakeRootFromHTMLTemplate(node_3));
  }
  const instantiated=new _c_13("New_3");
  function prepareTemplate(name_2){
    if(!loadedTpls.ContainsKey(name_2)){
      let o;
      const m=(o=null,[rawTpls.TryGetValue(name_2, {get:() => o, set:(v) => {
        o=v;
      }}), o]);
      if(m[0]){
        instantiated.SAdd(name_2);
        rawTpls.RemoveKey(name_2);
        PrepareTemplateStrict(baseName, Some(name_2), m[1], Some(prepareTemplate));
      }
      else console.warn(instantiated.Contains(name_2)?"Encountered loop when instantiating "+name_2:"Local template does not exist: "+name_2);
    }
  }
  while(rawTpls.count>0)
    prepareTemplate(head_1(rawTpls.Keys));
}
function LoadedTemplates(){
  return _c_12.LoadedTemplates;
}
function LoadedTemplateFile(name){
  let o;
  const m=(o=null,[LoadedTemplates().TryGetValue(name, {get:() => o, set:(v) => {
    o=v;
  }}), o]);
  if(m[0])return m[1];
  else {
    const d=new _c_7("New_5");
    LoadedTemplates().set_Item(name, d);
    return d;
  }
}
function FakeRootSingle(el){
  el.removeAttribute("ws-template");
  const m=el.getAttribute("ws-replace");
  if(m==null){ }
  else {
    el.removeAttribute("ws-replace");
    const m_1=el.parentNode;
    if(Equals(m_1, null)){ }
    else {
      const n=globalThis.document.createElement(el.tagName);
      n.setAttribute("ws-replace", m);
      m_1.replaceChild(n, el);
    }
  }
  const fakeroot=globalThis.document.createElement("div");
  fakeroot.appendChild(el);
  return fakeroot;
}
function FakeRoot(parent){
  const fakeroot=globalThis.document.createElement("div");
  while(parent.hasChildNodes())
    fakeroot.appendChild(parent.firstChild);
  return fakeroot;
}
function FakeRootFromHTMLTemplate(parent){
  const fakeroot=globalThis.document.createElement("div");
  const content=parent.content;
  for(let i=0, _1=content.childNodes.length-1;i<=_1;i++)fakeroot.appendChild(content.childNodes[i].cloneNode(true));
  return fakeroot;
}
function PrepareTemplateStrict(baseName, name, fakeroot, prepareLocalTemplate){
  const processedHTML5Templates=new _c_13("New_3");
  function recF(recI, _1){
    while(true)
      switch(recI){
        case 0:
          if(_1!==null){
            const next=_1.nextSibling;
            if(Equals(_1.nodeType, Node.TEXT_NODE))convertTextNode(_1);
            else if(Equals(_1.nodeType, Node.ELEMENT_NODE))convertElement(_1);
            _1=next;
          }
          else return null;
          break;
        case 1:
          const name_2=string(_1.nodeName, Some(3), null).toLowerCase();
          const m=name_2.indexOf(".");
          const p=m===-1?[baseName, name_2]:[string(name_2, null, Some(m-1)), string(name_2, Some(m+1), null)];
          const instName=p[1];
          const instBaseName=p[0];
          if(instBaseName!=""&&!LoadedTemplates().ContainsKey(instBaseName))return failNotLoaded(instName);
          else {
            if(instBaseName==""&&prepareLocalTemplate!=null)prepareLocalTemplate.$0(instName);
            const d=LoadedTemplates().Item(instBaseName);
            if(!d.ContainsKey(instName))return failNotLoaded(instName);
            else {
              const t=d.Item(instName);
              const instance=t.cloneNode(true);
              const usedHoles=new _c_13("New_3");
              const mappings=new _c_7("New_5");
              const attrs=_1.attributes;
              for(let i=0, _4=attrs.length-1;i<=_4;i++){
                const name_3=attrs.item(i).name.toLowerCase();
                const m_1=attrs.item(i).nodeValue;
                let _2=m_1==""?name_3:m_1.toLowerCase();
                mappings.set_Item(name_3, _2);
                if(!usedHoles.SAdd(name_3))console.warn("Hole mapped twice", name_3);
              }
              for(let i_1=0, _5=_1.childNodes.length-1;i_1<=_5;i_1++){
                const n=_1.childNodes[i_1];
                if(Equals(n.nodeType, Node.ELEMENT_NODE))if(!usedHoles.SAdd(n.nodeName.toLowerCase()))console.warn("Hole filled twice", instName);
              }
              const singleTextFill=_1.childNodes.length===1&&Equals(_1.firstChild.nodeType, Node.TEXT_NODE);
              if(singleTextFill){
                const x=fillTextHole(instance, _1.firstChild.textContent, instName);
                const f=((usedHoles_1) =>(a) => usedHoles_1.SAdd(a))(usedHoles);
                let _3=((a) =>(o) => {
                  if(o!=null)a(o.$0);
                })((x_1) => {
                  f(x_1);
                });
                _3(x);
              }
              removeHolesExcept(instance, usedHoles);
              if(!singleTextFill){
                for(let i_2=0, _6=_1.childNodes.length-1;i_2<=_6;i_2++){
                  const n_1=_1.childNodes[i_2];
                  if(Equals(n_1.nodeType, Node.ELEMENT_NODE))if(n_1.hasAttributes())fillInstanceAttrs(instance, n_1);
                  else fillDocHole(instance, n_1);
                }
              }
              mapHoles(instance, mappings);
              fill(instance, _1.parentNode, _1);
              _1.parentNode.removeChild(_1);
              return;
            }
          }
          break;
      }
  }
  function fillDocHole(instance, fillWith){
    const name_2=fillWith.nodeName.toLowerCase();
    const fillHole=(p, n) => {
      if(name_2=="title"&&fillWith.hasChildNodes()){
        const parsed=ParseHTMLIntoFakeRoot(fillWith.textContent);
        fillWith.removeChild(fillWith.firstChild);
        while(parsed.hasChildNodes())
          fillWith.appendChild(parsed.firstChild);
      }
      convertElement(fillWith);
      return fill(fillWith, p, n);
    };
    foreachNotPreserved(instance, "[ws-attr-holes]", (e) => {
      const holeAttrs=SplitChars(e.getAttribute("ws-attr-holes"), [" "], 1);
      for(let i=0, _2=holeAttrs.length-1;i<=_2;i++){
        const attrName=get(holeAttrs, i);
        let this_1=new RegExp("\\${"+name_2+"}", "ig");
        let _1=e.getAttribute(attrName).replace(this_1, fillWith.textContent);
        e.setAttribute(attrName, _1);
      }
    });
    const m=instance.querySelector("[ws-hole="+name_2+"]");
    if(Equals(m, null)){
      const m_1=instance.querySelector("[ws-replace="+name_2+"]");
      if(Equals(m_1, null)){
        const m_2=instance.querySelector("slot[name="+name_2+"]");
        return instance.tagName.toLowerCase()=="template"?(fillHole(m_2.parentNode, m_2),void m_2.parentNode.removeChild(m_2)):null;
      }
      else {
        fillHole(m_1.parentNode, m_1);
        m_1.parentNode.removeChild(m_1);
        return;
      }
    }
    else {
      while(m.hasChildNodes())
        m.removeChild(m.lastChild);
      m.removeAttribute("ws-hole");
      return fillHole(m, null);
    }
  }
  function convertElement(el){
    if(!el.hasAttribute("ws-preserve"))if(StartsWith(el.nodeName.toLowerCase(), "ws-"))convertInstantiation(el);
    else {
      convertAttrs(el);
      convertNodeAndSiblings(el.firstChild);
    }
  }
  function convertNodeAndSiblings(n){
    return recF(0, n);
  }
  function convertInstantiation(el){
    return recF(1, el);
  }
  function convertNestedTemplates(el){
    while(true)
      {
        const m=el.querySelector("[ws-template]");
        if(Equals(m, null)){
          const m_1=el.querySelector("[ws-children-template]");
          if(Equals(m_1, null)){
            const idTemplates=el.querySelectorAll("template[id]");
            for(let i=1, _1=idTemplates.length-1;i<=_1;i++){
              const n=idTemplates[i];
              if(processedHTML5Templates.Contains(n)){ }
              else {
                PrepareTemplateStrict(baseName, Some(n.getAttribute("id")), n, null);
                processedHTML5Templates.SAdd(n);
              }
            }
            const nameTemplates=el.querySelectorAll("template[name]");
            for(let i_1=1, _2=nameTemplates.length-1;i_1<=_2;i_1++){
              const n_1=nameTemplates[i_1];
              if(processedHTML5Templates.Contains(n_1)){ }
              else {
                PrepareTemplateStrict(baseName, Some(n_1.getAttribute("name")), n_1, null);
                processedHTML5Templates.SAdd(n_1);
              }
            }
            return null;
          }
          else {
            const name_2=m_1.getAttribute("ws-children-template");
            m_1.removeAttribute("ws-children-template");
            PrepareTemplateStrict(baseName, Some(name_2), m_1, null);
            el=el;
          }
        }
        else {
          const name_3=m.getAttribute("ws-template");
          (PrepareSingleTemplate(baseName, Some(name_3), m))(null);
          el=el;
        }
      }
  }
  const name_1=(name==null?"":name.$0).toLowerCase();
  LoadedTemplateFile(baseName).set_Item(name_1, fakeroot);
  if(fakeroot.hasChildNodes()){
    convertNestedTemplates(fakeroot);
    convertNodeAndSiblings(fakeroot.firstChild);
  }
}
function foreachNotPreserved(root, selector, f){
  IterSelector(root, selector, (p) => {
    if(p.closest("[ws-preserve]")==null)f(p);
  });
}
function PrepareSingleTemplate(baseName, name, el){
  const root=FakeRootSingle(el);
  return(p) => {
    PrepareTemplateStrict(baseName, name, root, p);
  };
}
function TextHoleRE(){
  return _c_12.TextHoleRE;
}
let _c_5=Lazy((_i) => class $StartupCode_Client {
  static {
    _c_5=_i(this);
  }
  static option2;
  static barpolarLayout;
  static barpolar4;
  static barpolar1;
  static barpolar2;
  static barpolar3;
  static icicleLayout;
  static icicle;
  static treemap;
  static sunBurstLayout;
  static sunburst;
  static splomLayout;
  static splom;
  static sternaryLayout;
  static sternary;
  static ccarpetLayout;
  static surfaceLayout;
  static scatter3DLayout;
  static scatterMBLayout;
  static scatterGeoLayout;
  static densityMBLayout;
  static spolargl2;
  static spolargl1;
  static spolar;
  static scarpetLayout;
  static scattercarpet;
  static scarpet;
  static sankey;
  static parcoords;
  static parcats;
  static contourcarpet;
  static ccarpet;
  static surface;
  static streamTubeLayout;
  static streamtube;
  static scatter3d;
  static option1;
  static mesh;
  static isosurface;
  static cone;
  static scattermb;
  static scattergeo;
  static densitymb;
  static choroplethMBLayout;
  static choroplethmb;
  static choropleth;
  static waterfall;
  static ohlc;
  static indicatorLayout;
  static indicator;
  static funnelarea;
  static funnel;
  static candlestick;
  static violin;
  static hg2dcontour;
  static histogram2d;
  static histogram;
  static box;
  static imageLayout;
  static image;
  static contour;
  static table;
  static heatmapgl;
  static heatmap;
  static barTrace;
  static pieTrace;
  static scatterGLTrace;
  static scatterTrace;
  static carpet;
  static {
    let r;
    let r_1;
    let r_2;
    let r_3;
    let r_4;
    let r_5;
    let r_6;
    let r_7;
    let r_8;
    let r_9;
    let r_10;
    let r_11;
    let r_12;
    let r_13;
    let r_14;
    let r_15;
    let r_16;
    let r_17;
    let r_18;
    let r_19;
    let r_20;
    let r_21;
    let r_22;
    let r_23;
    let r_24;
    let r_25;
    let r_26;
    let r_27;
    let r_28;
    let r_29;
    let r_30;
    let r_31;
    let r_32;
    let r_33;
    let r_34;
    let r_35;
    let r_36;
    let r_37;
    let r_38;
    let r_39;
    let r_40;
    let r_41;
    let r_42;
    let r_43;
    let r_44;
    let r_45;
    let r_46;
    let r_47;
    let r_48;
    let r_49;
    let r_50;
    let r_51;
    let r_52;
    let r_53;
    let r_54;
    let r_55;
    let r_56;
    let r_57;
    let r_58;
    let r_59;
    let r_60;
    let r_61;
    let r_62;
    let r_63;
    let r_64;
    let r_65;
    let r_66;
    let r_67;
    let r_68;
    let r_69;
    let r_70;
    let r_71;
    let r_72;
    let r_73;
    let r_74;
    let r_75;
    let r_76;
    let r_77;
    let r_78;
    let r_79;
    let r_80;
    let r_81;
    let r_82;
    let r_83;
    let r_84;
    let r_85;
    let r_86;
    let r_87;
    let r_88;
    let r_89;
    let r_90;
    let r_91;
    let r_92;
    let r_93;
    let r_94;
    let r_95;
    let r_96;
    let r_97;
    let r_98;
    let r_99;
    let r_100;
    let r_101;
    let r_102;
    let r_103;
    let r_104;
    let r_105;
    let r_106;
    let r_107;
    let r_108;
    let r_109;
    let r_110;
    let r_111;
    let r_112;
    let r_113;
    let r_114;
    let r_115;
    let r_116;
    let r_117;
    let r_118;
    let r_119;
    this.carpet={type:"carpet"};
    carpet().a=[4, 4, 4, 4.5, 4.5, 4.5, 5, 5, 5, 6, 6, 6];
    carpet().b=[1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3];
    carpet().y=[2, 3.5, 4, 3, 4.5, 5, 5.5, 6.5, 7.5, 8, 8.5, 10];
    this.scatterTrace={type:"scatter"};
    scatterTrace().x=[1, 2, 3, 4];
    scatterTrace().y=[10, 15, 13, 17];
    scatterTrace().mode="lines+markers";
    scatterTrace().showlegend=true;
    this.scatterGLTrace={type:"scattergl"};
    scatterGLTrace().x=[1, 2, 3, 4];
    scatterGLTrace().y=[10, 15, 13, 17];
    scatterGLTrace().mode="lines+markers";
    this.pieTrace={type:"pie"};
    pieTrace().values=[19, 26, 55];
    pieTrace().labels=["Residential", "Non-Residential", "Utility"];
    this.barTrace={type:"bar"};
    barTrace().x=["giraffes", "orangutans", "monkeys"];
    barTrace().y=[20, 14, 23];
    this.heatmap={type:"heatmap"};
    heatmap().z=[[1, 5, 30, 50, 1], [20, 1, 60, 80, 30], [30, 60, 1, -10, 20]];
    heatmap().x=["Monday", "Tuesday", "Wednesday", "Thursday", "Friday"];
    heatmap().y=["Morning", "Afternoon", "Evening"];
    heatmap().hoverongaps=false;
    this.heatmapgl={type:"heatmap"};
    heatmapgl().z=[[1, 5, 30, 50, 1], [20, 1, 60, 80, 30], [30, 60, 1, -10, 20]];
    heatmapgl().x=["Monday", "Tuesday", "Wednesday", "Thursday", "Friday"];
    heatmapgl().y=["Morning", "Afternoon", "Evening"];
    this.table={type:"table"};
    table().columnwidth=[150, 150, 200, 200, 150];
    table().columnorder=[0, 1, 2, 3, 4];
    table().header=(r={},r.values=[["<b>EXPENSES</b>"], ["<b>Q1</b>"], ["<b>Q2</b>"], ["<b>Q3</b>"], ["<b>Q4</b>"]],r.align="center",r.line=(r_1={},r_1.width=1,r_1.color="black",r_1),r.fill=(r_2={},r_2.color="grey",r_2),r.font=(r_3={},r_3.family="Arial",r_3.size=12,r_3.color="white",r_3),r);
    table().cells=(r_4={},r_4.values=[["Salaries", "Office", "Merchandise", "Legal", "<b>TOTAL</b>"], [1200000, 20000, 80000, 2000, 12120000], [1300000, 20000, 70000, 2000, 130902000], [1300000, 20000, 120000, 2000, 131222000], [1400000, 20000, 90000, 2000, 14102000]],r_4.align="center",r_4.line=(r_5={},r_5.color="black",r_5.width=1,r_5),r_4.font=(r_6={},r_6.family="Arial",r_6.size=11,r_6.color=["black"],r_6),r_4);
    this.contour={type:"contour"};
    contour().z=[[10, 10.625, 12.5, 15.625, 20], [5.625, 6.25, 8.125, 11.25, 15.625], [2.5, 3.125, 5, 8.125, 12.5], [0.625, 1.25, 3.125, 6.25, 10.625], [0, 0.625, 2.5, 5.625, 10]];
    this.image={type:"image"};
    image().z=[[[255, 0, 0], [0, 255, 0], [0, 0, 255]]];
    image().opacity=0.1;
    this.imageLayout={};
    imageLayout().width=400;
    imageLayout().height=400;
    imageLayout().title=(r_7={},r_7.text="Image with opacity 0.1",r_7);
    this.box={type:"box"};
    box().y=[0, 1, 1, 2, 3, 5, 8, 13, 21];
    box().boxpoints="all";
    box().jitter=0.3;
    box().pointpos=-1.8;
    this.histogram={type:"histogram"};
    histogram().x=[1, 1, 2, 3, 4, 6, 4, 3, 7, 9, 6, 4, 3, 4, 5, 7, 5];
    this.histogram2d={type:"histogram2d"};
    histogram2d().x=[1, 1, 2, 3, 4, 6, 4, 3, 7, 9, 6, 4, 3, 4, 5, 7, 5];
    histogram2d().y=[1, 1, 2, 3, 4, 6, 4, 3, 7, 9, 6, 4, 3, 4, 5, 7, 5];
    this.hg2dcontour={type:"histogram2dcontour"};
    hg2dcontour().x=[2, 3, 4, 2, 1, 3, 5, 7, 9, 7, 6, 6, 4, 5, 6, 7, 8, 9, 4, 5, 3, 10, 2, 4, 5, 7, 5, 3, 3, 3, 4];
    hg2dcontour().y=[8, 9, 4, 5, 3, 3, 2, 4, 2, 3, 4, 2, 1, 3, 5, 7, 9, 7, 6, 7, 4, 5, 6, 7, 5, 7, 5, 3, 3, 3, 4];
    this.violin={type:"violin"};
    violin().y=[34, 52, 34, 42, 345, 665, 34, 23, 54, 436, 65, 34, 235, 654, 345];
    violin().points="none";
    violin().box=(r_8={},r_8.visible=true,r_8);
    violin().points=false;
    violin().line=(r_9={},r_9.color="black",r_9);
    violin().fillcolor="black";
    violin().opacity=0.6;
    violin().meanline=(r_10={},r_10.visible=true,r_10);
    violin().x0="Total Bill";
    this.candlestick={type:"candlestick"};
    candlestick().x=["2017-01-04", "2017-01-05", "2017-01-06", "2017-01-09", "2017-01-10", "2017-01-11", "2017-01-12", "2017-01-13", "2017-01-17", "2017-01-18", "2017-01-19", "2017-01-20", "2017-01-23", "2017-01-24", "2017-01-25", "2017-02-02", "2017-02-03", "2017-02-04", "2017-02-07"];
    candlestick().close=[116.019997, 116.610001, 117.910004, 118.989998, 119.110001, 119.75, 119.25, 119.040001, 120, 119.989998, 119.779999, 120, 120.080002, 119.970001, 121.879997, 121.940002, 121.949997, 121.629997, 121.349998];
    candlestick().decreasing=(r_11={},r_11.line=(r_12={},r_12.color="#7F7F7F",r_12),r_11);
    candlestick().high=[116.510002, 116.860001, 118.160004, 119.43, 119.379997, 119.93, 119.300003, 119.620003, 120.239998, 120.5, 120.089996, 120.449997, 120.809998, 120.099998, 122.099998, 122.440002, 122.349998, 121.629997, 121.389999];
    candlestick().increasing=(r_13={},r_13.line=(r_14={},r_14.color="#17BECF",r_14),r_13);
    candlestick().line=(r_15={},r_15.color="rgba(31,119,180,1)",r_15);
    candlestick().low=[115.510002, 114.860001, 115.160004, 116.43, 117.379997, 117.93, 117.300003, 116.620003, 118.239998, 117.5, 116.089996, 117.449997, 119.809998, 116.099998, 120.099998, 121.440002, 121.349998, 120.629997, 120.389999];
    candlestick().open=[116.810002, 116.960001, 118.460004, 119.93, 119.779997, 119.93, 119.700003, 119.720003, 120.339998, 120.65, 120.689996, 120.749997, 120.909998, 120.299998, 122.399998, 122.540002, 122.849998, 121.829997, 121.589999];
    candlestick().xaxis="x";
    candlestick().yaxis="y";
    this.funnel={type:"funnel"};
    funnel().y=["Website visit", "Downloads", "Potential customers", "Invoice sent", "Closed delas"];
    funnel().x=[13873, 10533, 5443, 2703, 908];
    funnel().hoverinfo="x+percent previous+percent initial";
    this.funnelarea={type:"funnelarea"};
    funnelarea().values=[5, 4, 3, 2, 1];
    funnelarea().text=["First", "Second", "Third", "Fourth", "Fifth"];
    funnelarea().marker=(r_16={},r_16.colors=["59D4E8", "DDB6C6", "A696C8", "67EACA", "94D2E6"],r_16.line=(r_17={},r_17.color=["59D4E8", "DDB6C6", "A696C8", "67EACA", "94D2E6"],r_17.width=[2, 1, 5, 0, 3],r_17),r_16);
    funnelarea().textfont=(r_18={},r_18.family="Old Standard TT",r_18.size=13,r_18.color="black",r_18);
    this.indicator={type:"indicator"};
    indicator().value=200;
    indicator().delta=(r_19={},r_19.reference=160,r_19);
    indicator().gauge=(r_20={},r_20.axis=(r_21={},r_21.visible=false,r_21.range=[0, 250],r_21),r_20);
    indicator().domain=(r_22={},r_22.row=0,r_22.column=0,r_22);
    indicator().title=(r_23={},r_23.text="Speed",r_23);
    indicator().mode="number+delta+gauge";
    this.indicatorLayout={};
    indicatorLayout().width=600;
    indicatorLayout().height=400;
    indicatorLayout().margin=(r_24={},r_24.t=25,r_24.b=25,r_24.l=25,r_24.r=25,r_24);
    indicatorLayout().grid=(r_25={},r_25.rows=2,r_25.columns=2,r_25.pattern="independent",r_25);
    this.ohlc={type:"ohlc"};
    ohlc().x=["2017-01-04", "2017-01-05", "2017-01-06", "2017-01-09", "2017-01-10", "2017-01-11", "2017-01-12", "2017-01-13", "2017-01-17", "2017-01-18", "2017-01-19", "2017-01-20", "2017-01-23", "2017-01-24", "2017-01-25", "2017-02-02", "2017-02-03", "2017-02-04", "2017-02-07"];
    ohlc().close=[116.019997, 116.610001, 117.910004, 118.989998, 119.110001, 119.75, 119.25, 119.040001, 120, 119.989998, 119.779999, 120, 120.080002, 119.970001, 121.879997, 121.940002, 121.949997, 121.629997, 121.349998];
    ohlc().decreasing=(r_26={},r_26.line=(r_27={},r_27.color="#7F7F7F",r_27),r_26);
    ohlc().high=[116.510002, 116.860001, 118.160004, 119.43, 119.379997, 119.93, 119.300003, 119.620003, 120.239998, 120.5, 120.089996, 120.449997, 120.809998, 120.099998, 122.099998, 122.440002, 122.349998, 121.629997, 121.389999];
    ohlc().increasing=(r_28={},r_28.line=(r_29={},r_29.color="#17BECF",r_29),r_28);
    ohlc().line=(r_30={},r_30.color="rgba(31,119,180,1)",r_30);
    ohlc().low=[115.510002, 114.860001, 115.160004, 116.43, 117.379997, 117.93, 117.300003, 116.620003, 118.239998, 117.5, 116.089996, 117.449997, 119.809998, 116.099998, 120.099998, 121.440002, 121.349998, 120.629997, 120.389999];
    ohlc().open=[116.810002, 116.960001, 118.460004, 119.93, 119.779997, 119.93, 119.700003, 119.720003, 120.339998, 120.65, 120.689996, 120.749997, 120.909998, 120.299998, 122.399998, 122.540002, 122.849998, 121.829997, 121.589999];
    ohlc().xaxis="x";
    ohlc().yaxis="y";
    this.waterfall={type:"waterfall"};
    waterfall().name="2018";
    waterfall().orientation="v";
    waterfall().measure=["relative", "relative", "total", "relative", "relative", "total"];
    waterfall().x=["Sales", "Consulting", "Net revenue", "Purchases", "Other expenses", "Profit before tax"];
    waterfall().textposition="outside";
    waterfall().text=["+60", "+80", "", "-40", "-20", "Total"];
    waterfall().y=[60, 80, 0, -40, -20, 0];
    waterfall().connector=(r_31={},r_31.line=(r_32={},r_32.color="rgb(63, 63, 63)",r_32),r_31);
    this.choropleth={type:"choropleth"};
    choropleth().locationmode="country names";
    choropleth().locations=["Brazil", "Canada", "Indonesia", "Australia", "Japan", "France", "Norway", "Egypt", "South Africa", "Mongolia"];
    choropleth().z=[234, 234, 23, 235, 45, 23, 23, 5, 24, 234];
    choropleth().text=["a", "b", "c", "d", "e", "f", "g", "h", "i", "j"];
    choropleth().autocolorscale=true;
    this.choroplethmb={type:"choroplethmapbox"};
    choroplethmb().locations=["NY", "MA", "VT"];
    choroplethmb().z=[-50, -10, -20];
    choroplethmb().geojson="https://raw.githubusercontent.com/python-visualization/folium/master/examples/data/us-states.json";
    this.choroplethMBLayout={};
    choroplethMBLayout().mapbox=(r_33={},r_33.style="stamen-watercolor",r_33.center=(r_34={},r_34.lon=-74,r_34.lat=43,r_34),r_33.zoom=3.5,r_33);
    this.densitymb={type:"densitymapbox"};
    densitymb().lon=[10, 20, 30];
    densitymb().lat=[15, 25, 35];
    densitymb().z=[1, 3, 2];
    this.scattergeo={type:"scattergeo"};
    scattergeo().mode="markers+text";
    scattergeo().text=["Montreal", "Toronto", "Vancouver", "Calgary", "Edmonton", "Ottawa", "Halifax", "Victoria", "Winnepeg", "Regina"];
    scattergeo().lon=[-73.57, -79.24, -123.06, -114.1, -113.28, -75.43, -63.57, -123.21, -97.13, -104.6];
    scattergeo().lat=[45.5, 43.4, 49.13, 51.1, 53.34, 45.24, 44.64, 48.25, 49.89, 50.45];
    scattergeo().marker=(r_35={},r_35.size=7,r_35.color=["#bebada", "#fdb462", "#fb8072", "#d9d9d9", "#bc80bd", "#b3de69", "#8dd3c7", "#80b1d3", "#fccde5", "#ffffb3"],r_35.line=(r_36={},r_36.width=1,r_36),r_35);
    scattergeo().name="Canadian cities";
    scattergeo().textposition=["top right", "top left", "top center", "bottom right", "top right", "top left", "bottom right", "bottom left", "top right", "top right"];
    this.scattermb={type:"scattermapbox"};
    scattermb().lat=["45.5017"];
    scattermb().lon=["-73.5673"];
    scattermb().mode="markers";
    scattermb().marker=(r_37={},r_37.size=14,r_37);
    scattermb().text=["Montreal"];
    this.cone={type:"cone"};
    cone().x=[1];
    cone().y=[1];
    cone().z=[1];
    cone().u=[1];
    cone().v=[1];
    cone().w=[0];
    this.isosurface={type:"isosurface"};
    isosurface().x=[0, 0, 0, 0, 1, 1, 1, 1];
    isosurface().y=[0, 1, 0, 1, 0, 1, 0, 1];
    isosurface().z=[1, 1, 0, 0, 1, 1, 0, 0];
    isosurface().value=[1, 2, 3, 4, 5, 6, 7, 8];
    isosurface().isomin=2;
    isosurface().isomax=6;
    isosurface().colorscale="Reds";
    this.mesh={type:"mesh3d"};
    mesh().x=[34, 52, 34, 42, 345, 665, 34, 23, 54, 436, 65, 34, 235, 654, 345];
    mesh().y=[534, 345, 34, 65, 865, 34, 54, 764, 234, 54, 34, 64, 34, 345, 45];
    mesh().z=[56, 456, 234, 54, 56, 687, 34, 45, 345, 56, 34, 345, 456, 45, 45];
    mesh().opacity=0.8;
    mesh().color="rgb(300,100,200)";
    this.option1={};
    option1().locale="fr";
    this.scatter3d={type:"scatter3d"};
    scatter3d().x=[234, 234, 23, 235, 45, 23, 23, 5, 24, 234, 4, 334, 234, 43, 234, 543, 134, 645, 345, 234, 64];
    scatter3d().y=[234, 234, 23, 235, 45, 23, 23, 5, 24, 234, 4, 334, 234, 43, 234, 543, 134, 645, 345, 234, 64];
    scatter3d().z=[234, 234, 23, 235, 45, 23, 23, 5, 24, 234, 4, 334, 234, 43, 234, 543, 134, 645, 345, 234, 64];
    scatter3d().mode="markers";
    scatter3d().marker=(r_38={},r_38.size=12,r_38.line=(r_39={},r_39.color="rgba(217, 217, 217, 0.14)",r_39.width=0.5,r_39.opacity=0.8,r_39),r_38);
    this.streamtube={type:"streamtube"};
    streamtube().x=[1, 1, 1, 1, 1, 1, 1, 1, 1, 1];
    streamtube().y=[1, 1, 1, 1, 1, 0, 0, 0, -1, -1];
    streamtube().z=[0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
    streamtube().u=[0, 0, 0, 0, 0, 0, 1, 1, 1, 2];
    streamtube().v=[0, 0, 0, 1, 1, 1, 1, 2, 2, 2];
    streamtube().w=[0, 1, 2, 0, 1, 2, 0, 1, 2, 0];
    streamtube().sizeref=0.5;
    streamtube().cmin=0;
    streamtube().cmax=3;
    this.streamTubeLayout={};
    streamTubeLayout().scene=(r_40={},r_40.camera=(r_41={},r_41.eye=(r_42={},r_42.x=-0.7243612458865182,r_42.y=1.9269804254717962,r_42.z=0.6704828299861716,r_42),r_41),r_40);
    this.surface={type:"surface"};
    surface().z=[[34, 52, 34, 42, 345, 665, 34, 23, 54, 436, 65, 34, 235, 654, 345], [65, 34, 654, 345, 235, 34, 42, 345, 34, 52, 54, 436, 665, 34, 23]];
    this.ccarpet={type:"carpet"};
    ccarpet().a=[0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3];
    ccarpet().b=[4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6];
    ccarpet().x=[2, 3, 4, 5, 2.2, 3.1, 4.1, 5.1, 1.5, 2.5, 3.5, 4.5];
    ccarpet().y=[1, 1.4, 1.6, 1.75, 2, 2.5, 2.7, 2.75, 3, 3.5, 3.7, 3.75];
    ccarpet().aaxis=(r_43={},r_43.tickprefix="a = ",r_43.smoothing=0,r_43.minorgridcount=9,r_43.type="linear",r_43);
    ccarpet().baxis=(r_44={},r_44.tickprefix="b = ",r_44.smoothing=0,r_44.minorgridcount=9,r_44.type="linear",r_44);
    this.contourcarpet={type:"contourcarpet"};
    contourcarpet().a=[0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3];
    contourcarpet().b=[4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6];
    contourcarpet().z=[1, 1.96, 2.56, 3.0625, 4, 5.0625, 1, 7.5625, 9, 12.25, 15.21, 14.0625];
    contourcarpet().autocontour=false;
    contourcarpet().contours=(r_45={},r_45.start=1,r_45.end=14,r_45.size=1,r_45);
    contourcarpet().line=(r_46={},r_46.width=2,r_46.smoothing=0,r_46);
    contourcarpet().colorbar=(r_47={},r_47.len=0.4,r_47.y=0.25,r_47);
    this.parcats={type:"parcats"};
    parcats().dimensions=[(r_48={},r_48.label="Hair",r_48.values=["Black", "Black", "Black", "Brown", "Brown", "Brown", "Red", "Brown"],r_48), (r_49={},r_49.label="Eye",r_49.values=["Brown", "Brown", "Brown", "Brown", "Brown", "Blue", "Blue", "Blue"],r_49), (r_50={},r_50.label="Sex",r_50.values=["Female", "Female", "Female", "Male", "Female", "Male", "Male", "Male"],r_50)];
    this.parcoords={type:"parcoords"};
    parcoords().line=(r_51={},r_51.color="blue",r_51);
    parcoords().dimensions=[(r_52={},r_52.range=[1, 5],r_52.constraintrange=[1, 2],r_52.label="A",r_52.values=[1, 4],r_52), (r_53={},r_53.range=[1, 5],r_53.tickvals=[1.5, 3, 4.5],r_53.label="B",r_53.values=[3, 1.5],r_53), (r_54={},r_54.range=[1, 5],r_54.tickvals=[1, 2, 4, 5],r_54.label="C",r_54.values=[2, 4],r_54.ticktext=["text1", "text2", "text3", "text4", "text5"],r_54), (r_55={},r_55.range=[1, 5],r_55.label="D",r_55.values=[4, 2],r_55)];
    this.sankey={type:"sankey"};
    sankey().orientation="h";
    sankey().node=(r_56={},r_56.pad=15,r_56.thickness=30,r_56.line=(r_57={},r_57.color="black",r_57.width=0.5,r_57),r_56.label=["A1", "A2", "B1", "B2", "C1", "C2"],r_56.color=ofArray(["blue", "blue", "blue", "blue", "blue", "blue"]),r_56);
    sankey().link=(r_58={},r_58.source=[0, 1, 0, 2, 3, 3],r_58.target=[2, 3, 3, 4, 4, 5],r_58.value=[8, 4, 2, 8, 4, 2],r_58);
    this.scarpet={type:"carpet"};
    scarpet().a=map_1((y) => 1E-06*y, [4, 4, 4, 4.5, 4.5, 4.5, 5, 5, 5, 6, 6, 6]);
    scarpet().b=map_1((y) => 1000000*y, [1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3]);
    scarpet().y=[2, 3.5, 4, 3, 4.5, 5, 5.5, 6.5, 7.5, 8, 8.5, 10];
    scarpet().aaxis=(r_59={},r_59.tickprefix="a = ",r_59.ticksuffix="m",r_59.smoothing=1,r_59.minorgridcount=9,r_59);
    scarpet().baxis=(r_60={},r_60.tickprefix="b = ",r_60.ticksuffix="Pa",r_60.smoothing=1,r_60.minorgridcount=9,r_60);
    this.scattercarpet={type:"scattercarpet"};
    scattercarpet().a=map_1((y) => 1E-06*y, [4, 4.5, 5, 6]);
    scattercarpet().b=map_1((y) => 1000000*y, [1.5, 2.5, 1.5, 2.5]);
    scattercarpet().line=(r_61={},r_61.shape="spline",r_61.smoothing=1,r_61);
    this.scarpetLayout={};
    this.spolar={type:"scatterpolar"};
    spolar().r=[34, 52, 34, 42, 345, 665, 34, 23, 54, 436, 65, 34, 235, 654, 345];
    spolar().theta=[34, 52, 34, 42, 345, 665, 34, 23, 54, 436, 65, 34, 235, 654, 345];
    spolar().mode="lines";
    spolar().name="Figure8";
    spolar().line=(r_62={},r_62.color="peru",r_62);
    this.spolargl1={type:"scatterpolargl"};
    spolargl1().r=[1, 2, 3];
    spolargl1().theta=[50, 100, 200];
    spolargl1().marker=(r_63={},r_63.symbol="square",r_63);
    this.spolargl2={type:"scatterpolargl"};
    spolargl2().r=[1, 2, 3];
    spolargl2().theta=[1, 2, 3];
    spolargl2().thetaunit="radians";
    this.densityMBLayout={};
    densityMBLayout().width=600;
    densityMBLayout().height=400;
    densityMBLayout().mapbox=(r_64={},r_64.style="stamen-terrain",r_64);
    this.scatterGeoLayout={};
    scatterGeoLayout().title=(r_65={},r_65.text="Canadian cities",r_65.font=(r_66={},r_66.size=16,r_66),r_65);
    scatterGeoLayout().font=(r_67={},r_67.family="Droid Serif, serif",r_67.size=6,r_67);
    scatterGeoLayout().geo=(r_68={},r_68.scope="north america",r_68.resolution="50",r_68.lonaxis=(r_69={},r_69.range=[-130, -55],r_69),r_68.lataxis=(r_70={},r_70.range=[40, 70],r_70),r_68.showrivers=true,r_68.rivercolor="#fff",r_68.showlakes=true,r_68.lakecolor="#fff",r_68.showland=true,r_68.landcolor="#fff",r_68.countrycolor="EAEAAE",r_68.countrywidth=1.5,r_68.subunitcolor="#d3d3d3",r_68);
    this.scatterMBLayout={};
    scatterMBLayout().autosize=true;
    scatterMBLayout().hovermode="closest";
    scatterMBLayout().mapbox=(r_71={},r_71.style="stamen-terrain",r_71.bearing=0,r_71.center=(r_72={},r_72.lat=45,r_72.lon=-73,r_72),r_71.pitch=0,r_71.zoom=5,r_71);
    this.scatter3DLayout={};
    scatter3DLayout().margin=(r_73={},r_73.l=0,r_73.r=0,r_73.b=0,r_73.t=0,r_73);
    this.surfaceLayout={};
    surfaceLayout().title=(r_74={},r_74.text="Mt Bruno Elevation",r_74);
    surfaceLayout().autosize=false;
    surfaceLayout().width=500;
    surfaceLayout().height=500;
    surfaceLayout().margin=(r_75={},r_75.l=65,r_75.r=50,r_75.b=65,r_75.t=90,r_75);
    this.ccarpetLayout={};
    ccarpetLayout().margin=(r_76={},r_76.t=40,r_76.r=30,r_76.b=30,r_76.l=30,r_76);
    ccarpetLayout().yaxis=(r_77={},r_77.range=[0.388, 4.361],r_77);
    ccarpetLayout().xaxis=(r_78={},r_78.range=[0.667, 5.932],r_78);
    this.sternary={type:"scatterternary"};
    sternary().mode="markers";
    sternary().name="k";
    sternary().a=[75, 70, 75, 5, 10, 10, 20, 10, 15, 10, 20];
    sternary().b=[25, 10, 20, 60, 80, 90, 70, 20, 5, 10, 10];
    sternary().c=[0, 20, 5, 35, 10, 0, 10, 70, 80, 80, 70];
    sternary().text=["point 1", "point 2", "point 3", "point 4", "point 5", "point 6", "point 7", "point 8", "point 9", "point 10", "point 11"];
    sternary().marker=(r_79={},r_79.symbol="100",r_79.color="#DB7365",r_79.size=14,r_79.line=(r_80={},r_80.width=2,r_80),r_79);
    this.sternaryLayout={};
    sternaryLayout().ternary=(r_81={},r_81.sum=100,r_81.aaxis=(r_82={},r_82.title=(r_83={},r_83.text="Journalist",r_83.font=(r_84={},r_84.size=20,r_84),r_83),r_82.tickangle=0,r_82.tickfont=(r_85={},r_85.size=15,r_85.color="rgba(0,0,0,0)",r_85),r_82.ticklen=5,r_82.showline=true,r_82.showgrid=true,r_82),r_81.baxis=(r_86={},r_86.title=(r_87={},r_87.text="<br>Developer",r_87.font=(r_88={},r_88.size=20,r_88),r_87),r_86.tickangle=45,r_86.tickfont=(r_89={},r_89.size=15,r_89.color="rgba(0,0,0,0)",r_89),r_86.ticklen=5,r_86.showline=true,r_86.showgrid=true,r_86),r_81.caxis=(r_90={},r_90.title=(r_91={},r_91.text="<br>Designer",r_91.font=(r_92={},r_92.size=20,r_92),r_91),r_90.tickangle=-45,r_90.tickfont=(r_93={},r_93.size=15,r_93.color="rgba(0,0,0,0)",r_93),r_90.ticklen=5,r_90.showline=true,r_90.showgrid=true,r_90),r_81.bgcolor="#fff1e0",r_81);
    sternaryLayout().showlegend=false;
    sternaryLayout().width=700;
    sternaryLayout().paper_bgcolor="#fff1e0";
    this.splom={type:"splom"};
    splom().dimensions=(r_94={},r_94.label="sepal length",r_94.values=[5.1, 4.9, 4.7, 4.6, 5, 5.4, 4.6, 5, 4.4, 4.9],r_94);
    splom().text=["Iris-setosa", "Iris-setosa", "Iris-setosa", "Iris-setosa", "Iris-setosa", "Iris-setosa", "Iris-setosa", "Iris-setosa", "Iris-setosa", "Iris-setosa"];
    splom().marker=(r_95={},r_95.color=["#c00", "#343434", "#343434", "#343434", "#343434", "#343434", "#343434", "#343434", "#343434", "#343434"],r_95.size=7,r_95.line=(r_96={},r_96.color="white",r_96.width=0.5,r_96),r_95);
    this.splomLayout={};
    splomLayout().title=(r_97={},r_97.text="Iris Data set",r_97);
    splomLayout().height=400;
    splomLayout().width=400;
    splomLayout().autosize=false;
    splomLayout().hovermode="closest";
    splomLayout().dragmode="select";
    splomLayout().plot_bgcolor="rgba(240,240,240, 0.95)";
    this.sunburst={type:"sunburst"};
    sunburst().labels=["Eve", "Cain", "Seth", "Enos", "Noam", "Abel", "Awan", "Enoch", "Azura"];
    sunburst().parents=["", "Eve", "Eve", "Seth", "Seth", "Eve", "Eve", "Awan", "Eve"];
    sunburst().values=[10, 14, 12, 10, 2, 6, 6, 4, 4];
    sunburst().outsidetextfont=(r_98={},r_98.size=20,r_98.color="#377eb8",r_98);
    sunburst().leaf=(r_99={},r_99.opacity=0.4,r_99);
    sunburst().marker=(r_100={},r_100.line=(r_101={},r_101.width=2,r_101),r_100);
    this.sunBurstLayout={};
    sunBurstLayout().margin=(r_102={},r_102.l=0,r_102.r=0,r_102.b=0,r_102.t=0,r_102);
    sunBurstLayout().width=500;
    sunBurstLayout().height=500;
    this.treemap={type:"treemap"};
    treemap().labels=["Eve", "Cain", "Seth", "Enos", "Noam", "Abel", "Awan", "Enoch", "Azura"];
    treemap().parents=["", "Eve", "Eve", "Seth", "Seth", "Eve", "Eve", "Awan", "Eve"];
    this.icicle={type:"icicle"};
    icicle().labels=["Eve", "Cain", "Seth", "Enos", "Noam", "Abel", "Awan", "Enoch", "Azura"];
    icicle().parents=["", "Eve", "Eve", "Seth", "Seth", "Eve", "Eve", "Awan", "Eve"];
    icicle().values=[10, 14, 12, 10, 2, 6, 6, 4, 4];
    icicle().outsidetextfont=(r_103={},r_103.size=20,r_103.color="#377eb8",r_103);
    icicle().leaf=(r_104={},r_104.opacity=0.4,r_104);
    icicle().marker=(r_105={},r_105.line=(r_106={},r_106.width=2,r_106),r_105);
    icicle().root=(r_107={},r_107.color="lightgrey",r_107);
    this.icicleLayout={};
    icicleLayout().margin=(r_108={},r_108.l=25,r_108.r=25,r_108.b=25,r_108.t=50,r_108);
    this.barpolar3={type:"barpolar"};
    barpolar3().r=[57.5, 50, 45, 35, 20, 22.5, 37.5, 55];
    barpolar3().name="8-11 m/s";
    barpolar3().marker=(r_109={},r_109.color="rgb(158,154,200)",r_109);
    barpolar3().theta=["North", "N-E", "East", "S-E", "South", "S-W", "West", "N-W"];
    this.barpolar2={type:"barpolar"};
    barpolar2().r=[40, 30, 30, 35, 7.5, 7.5, 32.5, 40];
    barpolar2().name="5-8 m/s";
    barpolar2().marker=(r_110={},r_110.color="rgb(203,201,226)",r_110);
    barpolar2().theta=["North", "N-E", "East", "S-E", "South", "S-W", "West", "N-W"];
    this.barpolar1={type:"barpolar"};
    barpolar1().r=[77.5, 72.5, 70, 45, 22.5, 42.5, 40, 62.5];
    barpolar1().name="11-14 m/s";
    barpolar1().marker=(r_111={},r_111.color="rgb(106,81,163)",r_111);
    barpolar1().theta=["North", "N-E", "East", "S-E", "South", "S-W", "West", "N-W"];
    this.barpolar4={type:"barpolar"};
    barpolar4().r=[20, 7.5, 15, 22.5, 2.5, 2.5, 12.5, 22.5];
    barpolar4().name="< 5 m/s";
    barpolar4().marker=(r_112={},r_112.color="rgb(242,240,247)",r_112);
    barpolar4().theta=["North", "N-E", "East", "S-E", "South", "S-W", "West", "N-W"];
    this.barpolarLayout={};
    barpolarLayout().title=(r_113={},r_113.text="Wind Speed Distribution in Laurel, NE",r_113.font=(r_114={},r_114.size=16,r_114),r_113);
    barpolarLayout().legend=(r_115={},r_115.font=(r_116={},r_116.size=16,r_116),r_115);
    barpolarLayout().polar=(r_117={},r_117.radialaxis=(r_118={},r_118.ticksuffix="%",r_118.angle=45,r_118.dtick=20,r_118),r_117.angularaxis=(r_119={},r_119.direction="clockwise",r_119),r_117.bargap=0,r_117);
    this.option2={};
    option2().locale="fr";
  }
});
function New(k, ct){
  return{k:k, ct:ct};
}
function No(Item){
  return{$:1, $0:Item};
}
function Ok(Item){
  return{$:0, $0:Item};
}
function Cc(Item){
  return{$:2, $0:Item};
}
function GetFieldValues(o){
  let r=[];
  let k;
  for(var k_1 in o)r.push(o[k_1]);
  return r;
}
function ofSeq(xs){
  if(xs instanceof Array)return xs.slice();
  else if(xs instanceof _c_2)return ofList(xs);
  else {
    const q=[];
    const o=Get(xs);
    try {
      while(o.MoveNext())
        q.push(o.Current);
      return q;
    }
    finally {
      if(typeof o=="object"&&isIDisposable(o))o.Dispose();
    }
  }
}
function map_1(f, arr){
  const r=new Array(arr.length);
  for(let i=0, _1=arr.length-1;i<=_1;i++)r[i]=f(arr[i]);
  return r;
}
function ofList(xs){
  const q=[];
  let l=xs;
  while(!(l.$==0))
    {
      q.push(head(l));
      l=tail(l);
    }
  return q;
}
function exists(f, x){
  let e=false;
  let i=0;
  while(!e&&i<length(x))
    if(f(x[i]))e=true;
    else i=i+1;
  return e;
}
function tryPick(f, arr){
  let res=null;
  let i=0;
  while(i<arr.length&&res==null)
    {
      const m=f(arr[i]);
      if(m!=null&&m.$==1)res=m;
      i=i+1;
    }
  return res;
}
function tryFindIndex(f, arr){
  let res=null;
  let i=0;
  while(i<arr.length&&res==null)
    {
      f(arr[i])?res=Some(i):void 0;
      i=i+1;
    }
  return res;
}
function filter(f, arr){
  const r=[];
  for(let i=0, _1=arr.length-1;i<=_1;i++)if(f(arr[i]))r.push(arr[i]);
  return r;
}
function iter_1(f, arr){
  for(let i=0, _1=arr.length-1;i<=_1;i++)f(arr[i]);
}
function foldBack(f, arr, zero){
  let acc=zero;
  const len=arr.length;
  for(let i=1, _1=len;i<=_1;i++)acc=f(arr[len-i], acc);
  return acc;
}
function pick(f, arr){
  const m=tryPick(f, arr);
  return m==null?FailWith("KeyNotFoundException"):m.$0;
}
function concat(xs){
  return Array.prototype.concat.apply([], ofSeq(xs));
}
function choose(f, arr){
  const q=[];
  for(let i=0, _1=arr.length-1;i<=_1;i++){
    const m=f(arr[i]);
    if(m==null){ }
    else q.push(m.$0);
  }
  return q;
}
function create(size, value){
  const r=new Array(size);
  for(let i=0, _1=size-1;i<=_1;i++)r[i]=value;
  return r;
}
function init(size, f){
  if(size<0)FailWith("Negative size given.");
  else null;
  const r=new Array(size);
  for(let i=0, _1=size-1;i<=_1;i++)r[i]=f(i);
  return r;
}
function forall(f, x){
  let a=true;
  let i=0;
  while(a&&i<length(x))
    if(f(x[i]))i=i+1;
    else a=false;
  return a;
}
function New_1(IsCancellationRequested, Registrations){
  return{c:IsCancellationRequested, r:Registrations};
}
let _c_6=Lazy((_i) => class $StartupCode_Concurrency {
  static {
    _c_6=_i(this);
  }
  static GetCT;
  static Zero;
  static defCTS;
  static scheduler;
  static noneCT;
  static {
    this.noneCT=New_1(false, []);
    this.scheduler=new _c_8();
    this.defCTS=[new _c_10()];
    this.Zero=Return();
    this.GetCT=(c) => {
      c.k(Ok(c.ct));
    };
  }
});
function Const(x){
  const o={s:Forever(x)};
  return() => o;
}
function Sink(act, a){
  function loop(){
    WhenRun(a(), act, () => {
      scheduler().Fork(loop);
    });
  }
  scheduler().Fork(loop);
}
function Map2Unit(a, a_1){
  return CreateLazy(() => Map2Unit_1(a(), a_1()));
}
function CreateLazy(observe){
  const lv={c:null, o:observe};
  return() => {
    let c=lv.c;
    if(c===null){
      c=lv.o();
      lv.c=c;
      const _1=c.s;
      if(_1!=null&&_1.$==0)lv.o=null;
      else WhenObsoleteRun(c, () => {
        lv.c=null;
      });
      return c;
    }
    else return c;
  };
}
function Map(fn, a){
  return CreateLazy(() => Map_1(fn, a()));
}
function ParseHTMLIntoFakeRoot(elem){
  const root=globalThis.document.createElement("div");
  if(!rhtml().test(elem)){
    root.appendChild(globalThis.document.createTextNode(elem));
    return root;
  }
  else {
    const m=rtagName().exec(elem);
    const tag=Equals(m, null)?"":get(m, 1).toLowerCase();
    const w=(wrapMap())[tag];
    const p=w?w:defaultWrap();
    root.innerHTML=p[1]+elem.replace(rxhtmlTag(), "<$1></$2>")+p[2];
    function unwrap(elt, a){
      while(true)
        {
          if(a===0)return elt;
          else {
            const i=a;
            elt=elt.lastChild;
            a=i-1;
          }
        }
    }
    return unwrap(root, p[0]);
  }
}
function rhtml(){
  return _c_22.rhtml;
}
function wrapMap(){
  return _c_22.wrapMap;
}
function defaultWrap(){
  return _c_22.defaultWrap;
}
function rxhtmlTag(){
  return _c_22.rxhtmlTag;
}
function rtagName(){
  return _c_22.rtagName;
}
function IterSelector(el, selector, f){
  const l=el.querySelectorAll(selector);
  for(let i=0, _1=l.length-1;i<=_1;i++)f(l[i]);
}
function InsertAt(parent, pos, node){
  let _1;
  if(node.parentNode===parent){
    const m=node.nextSibling;
    let _2=Equals(m, null)?null:m;
    _1=pos===_2;
  }
  else _1=false;
  if(!_1)parent.insertBefore(node, pos);
}
function RemoveNode(parent, el){
  if(el.parentNode===parent)parent.removeChild(el);
}
function TextNodeDoc(Item){
  return{$:5, $0:Item};
}
function ElemDoc(Item){
  return{$:1, $0:Item};
}
function AppendDoc(Item1, Item2){
  return{
    $:0, 
    $0:Item1, 
    $1:Item2
  };
}
function Static(attr){
  return _c_4.A3(attr);
}
function Updates(dyn){
  return MapTreeReduce((x) => x.NChanged, Const(), Map2Unit, dyn.DynNodes);
}
function AppendTree(a, b){
  if(a===null)return b;
  else if(b===null)return a;
  else {
    const x=_c_4.A2(a, b);
    SetFlags(x, Flags(a)|Flags(b));
    return x;
  }
}
function EmptyAttr(){
  return _c_21.EmptyAttr;
}
function Insert(elem, tree){
  const nodes=[];
  const oar=[];
  function loop(node){
    while(true)
      {
        if(!(node===null)){
          if(node!=null&&node.$==1)return nodes.push(node.$0);
          else if(node!=null&&node.$==2){
            const b=node.$1;
            const a=node.$0;
            loop(a);
            node=b;
          }
          else return node!=null&&node.$==3?node.$0(elem):node!=null&&node.$==4?oar.push(node.$0):null;
        }
        else return null;
      }
  }
  loop(tree);
  const arr=nodes.slice(0);
  let _1=New_2(elem, Flags(tree), arr, oar.length===0?null:Some((el) => {
    iter_2((f) => {
      f(el);
    }, oar);
  }));
  return _1;
}
function SetFlags(a, f){
  a.flags=f;
}
function Flags(a){
  return a!==null&&a.hasOwnProperty("flags")?a.flags:0;
}
function HasExitAnim(attr){
  const flag=2;
  return(attr.DynFlags&flag)===flag;
}
function GetExitAnim(dyn){
  return GetAnim(dyn, (_1, _2) => _1.NGetExitAnim(_2));
}
function HasEnterAnim(attr){
  const flag=1;
  return(attr.DynFlags&flag)===flag;
}
function GetEnterAnim(dyn){
  return GetAnim(dyn, (_1, _2) => _1.NGetEnterAnim(_2));
}
function HasChangeAnim(attr){
  const flag=4;
  return(attr.DynFlags&flag)===flag;
}
function GetChangeAnim(dyn){
  return GetAnim(dyn, (_1, _2) => _1.NGetChangeAnim(_2));
}
function GetAnim(dyn, f){
  return Concat(map_1((n) => f(n, dyn.DynElem), dyn.DynNodes));
}
function Sync(elem, dyn){
  iter_1((d) => {
    d.NSync(elem);
  }, dyn.DynNodes);
}
let _c_7=Lazy((_i) => class Dictionary extends _c {
  static {
    _c_7=_i(this);
  }
  equals;
  hash;
  count;
  data;
  set_Item(k, v){
    this.set(k, v);
  }
  ContainsKey(k){
    const d=this.data[this.hash(k)];
    return d==null?false:exists((a) => this.equals.apply(null, [(KeyValue(a))[0], k]), d);
  }
  TryGetValue(k, res){
    const d=this.data[this.hash(k)];
    if(d==null)return false;
    else {
      const v=tryPick((a) => {
        const a_1=KeyValue(a);
        return this.equals.apply(null, [a_1[0], k])?Some(a_1[1]):null;
      }, d);
      return v!=null&&v.$==1&&(res.set(v.$0),true);
    }
  }
  RemoveKey(k){
    return this.remove(k);
  }
  get Keys(){
    return new _c_17(this);
  }
  set(k, v){
    const h=this.hash(k);
    const d=this.data[h];
    if(d==null){
      this.count=this.count+1;
      this.data[h]=new Array({K:k, V:v});
    }
    else {
      const m=tryFindIndex((a) => this.equals.apply(null, [(KeyValue(a))[0], k]), d);
      if(m==null){
        this.count=this.count+1;
        d.push({K:k, V:v});
      }
      else d[m.$0]={K:k, V:v};
    }
  }
  remove(k){
    const h=this.hash(k);
    const d=this.data[h];
    if(d==null)return false;
    else {
      const r=filter((a) =>!this.equals.apply(null, [(KeyValue(a))[0], k]), d);
      return length(r)<d.length&&(this.count=this.count-1,this.data[h]=r,true);
    }
  }
  Item(k){
    return this.get(k);
  }
  get(k){
    const d=this.data[this.hash(k)];
    return d==null?notPresent():pick((a) => {
      const a_1=KeyValue(a);
      return this.equals.apply(null, [a_1[0], k])?Some(a_1[1]):null;
    }, d);
  }
  GetEnumerator(){
    return Get0(concat(GetFieldValues(this.data)));
  }
  static New_5(){
    return new this("New_5");
  }
  static New_6(init_2, equals, hash){
    return new this("New_6", init_2, equals, hash);
  }
  constructor(i, _1, _2, _3){
    if(i=="New_5"){
      i="New_6";
      _1=[];
      _2=Equals;
      _3=Hash;
    }
    if(i=="New_6"){
      const init_2=_1;
      const equals=_2;
      const hash=_3;
      super();
      this.equals=equals;
      this.hash=hash;
      this.count=0;
      this.data=[];
      const e=Get(init_2);
      try {
        while(e.MoveNext())
          {
            const x=e.Current;
            this.set(x.K, x.V);
          }
      }
      finally {
        if(typeof e=="object"&&isIDisposable(e))e.Dispose();
      }
    }
  }
});
let _c_8=Lazy((_i) => class Scheduler extends _c {
  static {
    _c_8=_i(this);
  }
  idle;
  robin;
  Fork(action){
    this.robin.push(action);
    this.idle?(this.idle=false,setTimeout(() => {
      this.tick();
    }, 0)):void 0;
  }
  tick(){
    const t=Date.now();
    let loop=true;
    while(loop)
      if(this.robin.length===0){
        this.idle=true;
        loop=false;
      }
      else {
        (this.robin.shift())();
        Date.now()-t>40?(setTimeout(() => {
          this.tick();
        }, 0),loop=false):void 0;
      }
  }
  constructor(){
    super();
    this.idle=true;
    this.robin=[];
  }
});
let _c_9=Lazy((_i) => {
  Force(Error);
  return class OperationCanceledException extends Error {
    static {
      _c_9=_i(this);
    }
    ct;
    static New(ct){
      return new this("New", ct);
    }
    static New_1(message, inner, ct){
      return new this("New_1", message, inner, ct);
    }
    constructor(i, _1, _2, _3){
      let ct;
      if(i=="New"){
        ct=_1;
        i="New_1";
        _1="The operation was canceled.";
        _2=null;
        _3=ct;
      }
      if(i=="New_1"){
        const message=_1;
        const inner=_2;
        const ct_1=_3;
        super(message);
        this.inner=inner;
        this.ct=ct_1;
      }
    }
  };
});
function Get(x){
  return x instanceof Array?ArrayEnumerator(x):Equals(typeof x, "string")?StringEnumerator(x):x.GetEnumerator();
}
function ArrayEnumerator(s){
  return new _c_19(0, null, (e) => {
    const i=e.s;
    return i<length(s)&&(e.c=get(s, i),e.s=i+1,true);
  }, void 0);
}
function StringEnumerator(s){
  return new _c_19(0, null, (e) => {
    const i=e.s;
    return i<s.length&&(e.c=s[i],e.s=i+1,true);
  }, void 0);
}
function Get0(x){
  return x instanceof Array?ArrayEnumerator(x):Equals(typeof x, "string")?StringEnumerator(x):"GetEnumerator0"in x?x.GetEnumerator0():x.GetEnumerator();
}
let _c_10=Lazy((_i) => class CancellationTokenSource extends _c {
  static {
    _c_10=_i(this);
  }
  init;
  c;
  pending;
  r;
  constructor(){
    super();
    this.c=false;
    this.pending=null;
    this.r=[];
    this.init=1;
  }
});
let _c_11=Lazy((_i) => class View {
  static {
    _c_11=_i(this);
  }
});
function WhenRun(snap, avail, obs){
  const m=snap.s;
  if(m==null)obs();
  else m!=null&&m.$==2?(m.$1.push(obs),avail(m.$0)):m!=null&&m.$==3?(m.$0.push(avail),m.$1.push(obs)):avail(m.$0);
}
function Copy(sn){
  const m=sn.s;
  if(m==null)return sn;
  else if(m!=null&&m.$==2){
    const res={s:Ready(m.$0, [])};
    WhenObsolete(sn, res);
    return res;
  }
  else if(m!=null&&m.$==3){
    const res_1={s:Waiting([], [])};
    When(sn, (v) => {
      MarkDone(res_1, sn, v);
    }, res_1);
    return res_1;
  }
  else return sn;
}
function WhenObsoleteRun(snap, obs){
  const m=snap.s;
  if(m==null)obs();
  else m!=null&&m.$==2?m.$1.push(obs):m!=null&&m.$==3?m.$1.push(obs):void 0;
}
function Map2Unit_1(sn1, sn2){
  const _1=sn1.s;
  const _2=sn2.s;
  if(_1!=null&&_1.$==0)return _2!=null&&_2.$==0?{s:Forever(null)}:sn2;
  else if(_2!=null&&_2.$==0)return sn1;
  else {
    const res={s:Waiting([], [])};
    const cont=() => {
      const m=res.s;
      if(!(m!=null&&m.$==0||m!=null&&m.$==2)){
        const _3=ValueAndForever(sn1);
        const _4=ValueAndForever(sn2);
        if(_3!=null&&_3.$==1)if(_4!=null&&_4.$==1)if(_3.$0[1]&&_4.$0[1])MarkForever(res, null);
        else MarkReady(res, null);
      }
    };
    When(sn1, cont, res);
    When(sn2, cont, res);
    return res;
  }
}
function WhenObsolete(snap, obs){
  const m=snap.s;
  if(m==null)Obsolete(obs);
  else m!=null&&m.$==2?EnqueueSafe(m.$1, obs):m!=null&&m.$==3?EnqueueSafe(m.$1, obs):void 0;
}
function When(snap, avail, obs){
  const m=snap.s;
  if(m==null)Obsolete(obs);
  else m!=null&&m.$==2?(EnqueueSafe(m.$1, obs),avail(m.$0)):m!=null&&m.$==3?(m.$0.push(avail),EnqueueSafe(m.$1, obs)):avail(m.$0);
}
function MarkDone(res, sn, v){
  const _1=sn.s;
  if(_1!=null&&_1.$==0)MarkForever(res, v);
  else MarkReady(res, v);
}
function ValueAndForever(snap){
  const m=snap.s;
  return m!=null&&m.$==0?Some([m.$0, true]):m!=null&&m.$==2?Some([m.$0, false]):null;
}
function MarkForever(sn, v){
  const m=sn.s;
  if(m!=null&&m.$==3){
    sn.s=Forever(v);
    const qa=m.$0;
    for(let i=0, _1=length(qa)-1;i<=_1;i++)(get(qa, i))(v);
  }
  else void 0;
}
function MarkReady(sn, v){
  const m=sn.s;
  if(m!=null&&m.$==3){
    sn.s=Ready(v, m.$1);
    const qa=m.$0;
    for(let i=0, _1=length(qa)-1;i<=_1;i++)(get(qa, i))(v);
  }
  else void 0;
}
function EnqueueSafe(q, x){
  q.push(x);
  if(q.length%20===0){
    const qcopy=q.slice(0);
    Clear(q);
    for(let i=0, _1=length(qcopy)-1;i<=_1;i++){
      const o=get(qcopy, i);
      if(typeof o=="object")(((sn) => {
        if(sn.s)q.push(sn);
      })(o));
      else(((f) => {
        q.push(f);
      })(o));
    }
  }
  else void 0;
}
function Map_1(fn, sn){
  const m=sn.s;
  if(m!=null&&m.$==0)return{s:Forever(fn(m.$0))};
  else {
    const res={s:Waiting([], [])};
    When(sn, (a) => {
      MarkDone(res, sn, fn(a));
    }, res);
    return res;
  }
}
let _c_12=Lazy((_i) => class $StartupCode_Templates {
  static {
    _c_12=_i(this);
  }
  static RenderedFullDocTemplate;
  static TextHoleRE;
  static GlobalHoles;
  static LocalTemplatesLoaded;
  static LoadedTemplates;
  static {
    this.LoadedTemplates=new _c_7("New_5");
    this.LocalTemplatesLoaded=false;
    this.GlobalHoles=new _c_7("New_5");
    this.TextHoleRE="\\${([^}]+)}";
    this.RenderedFullDocTemplate=null;
  }
});
let _c_13=Lazy((_i) => class HashSet extends _c {
  static {
    _c_13=_i(this);
  }
  equals;
  hash;
  data;
  count;
  SAdd(item){
    return this.add(item);
  }
  Contains(item){
    const arr=this.data[this.hash(item)];
    return arr==null?false:this.arrContains(item, arr);
  }
  add(item){
    const h=this.hash(item);
    const arr=this.data[h];
    return arr==null?(this.data[h]=[item],this.count=this.count+1,true):this.arrContains(item, arr)?false:(arr.push(item),this.count=this.count+1,true);
  }
  arrContains(item, arr){
    let c=true;
    let i=0;
    const l=arr.length;
    while(c&&i<l)
      if(this.equals.apply(null, [arr[i], item]))c=false;
      else i=i+1;
    return!c;
  }
  GetEnumerator(){
    return Get(concat_3(this.data));
  }
  ExceptWith(xs){
    const e=Get(xs);
    try {
      while(e.MoveNext())
        this.Remove(e.Current);
    }
    finally {
      if(typeof e=="object"&&isIDisposable(e))e.Dispose();
    }
  }
  get Count(){
    return this.count;
  }
  IntersectWith(xs){
    const other=new _c_13("New_4", xs, this.equals, this.hash);
    const all=concat_3(this.data);
    for(let i=0, _1=all.length-1;i<=_1;i++){
      const item=all[i];
      if(!other.Contains(item))this.Remove(item);
    }
  }
  Remove(item){
    const arr=this.data[this.hash(item)];
    return arr==null?false:this.arrRemove(item, arr)&&(this.count=this.count-1,true);
  }
  CopyTo(arr, index){
    const all=concat_3(this.data);
    for(let i=0, _1=all.length-1;i<=_1;i++)set(arr, i+index, all[i]);
  }
  arrRemove(item, arr){
    let c=true;
    let i=0;
    const l=arr.length;
    while(c&&i<l)
      if(this.equals.apply(null, [arr[i], item])){
        arr.splice(i, 1);
        c=false;
      }
      else i=i+1;
    return!c;
  }
  static New_3(){
    return new this("New_3");
  }
  static New_4(init_2, equals, hash){
    return new this("New_4", init_2, equals, hash);
  }
  static New_2(init_2){
    return new this("New_2", init_2);
  }
  constructor(i, _1, _2, _3){
    if(i=="New_3"){
      i="New_4";
      _1=[];
      _2=Equals;
      _3=Hash;
    }
    let init_2;
    if(i=="New_2"){
      init_2=_1;
      i="New_4";
      _1=init_2;
      _2=Equals;
      _3=Hash;
    }
    if(i=="New_4"){
      const init_3=_1;
      const equals=_2;
      const hash=_3;
      super();
      this.equals=equals;
      this.hash=hash;
      this.data=[];
      this.count=0;
      const e=Get(init_3);
      try {
        while(e.MoveNext())
          this.add(e.Current);
      }
      finally {
        if(typeof e=="object"&&isIDisposable(e))e.Dispose();
      }
    }
  }
});
function Some(Value){
  return{$:1, $0:Value};
}
function head_1(s){
  const e=Get(s);
  try {
    return e.MoveNext()?e.Current:insufficient();
  }
  finally {
    if(typeof e=="object"&&isIDisposable(e))e.Dispose();
  }
}
function fold(f, x, s){
  let r=x;
  const e=Get(s);
  try {
    while(e.MoveNext())
      r=f(r, e.Current);
    return r;
  }
  finally {
    if(typeof e=="object"&&isIDisposable(e))e.Dispose();
  }
}
function iter_2(p, s){
  const e=Get(s);
  try {
    while(e.MoveNext())
      p(e.Current);
  }
  finally {
    if(typeof e=="object"&&isIDisposable(e))e.Dispose();
  }
}
function delay(f){
  return{GetEnumerator:() => Get(f())};
}
function collect(f, s){
  return concat_1(map_2(f, s));
}
function map_2(f, s){
  return{GetEnumerator:() => {
    const en=Get(s);
    return new _c_19(null, null, (e) => en.MoveNext()&&(e.c=f(en.Current),true), () => {
      en.Dispose();
    });
  }};
}
function concat_1(ss){
  return{GetEnumerator:() => {
    const outerE=Get(ss);
    function next(st){
      while(true)
        {
          const m=st.s;
          if(Equals(m, null)){
            if(outerE.MoveNext()){
              st.s=Get(outerE.Current);
              st=st;
            }
            else {
              outerE.Dispose();
              return false;
            }
          }
          else if(m.MoveNext()){
            st.c=m.Current;
            return true;
          }
          else {
            st.Dispose();
            st.s=null;
            st=st;
          }
        }
    }
    return new _c_19(null, null, next, (st) => {
      const x=st.s;
      if(!Equals(x, null))x.Dispose();
      if(!Equals(outerE, null))outerE.Dispose();
    });
  }};
}
function init_1(n, f){
  return take(n, initInfinite(f));
}
function max(s){
  const e=Get(s);
  try {
    if(!e.MoveNext())seqEmpty();
    let m=e.Current;
    while(e.MoveNext())
      {
        const x=e.Current;
        if(Compare(x, m)===1)m=x;
      }
    return m;
  }
  finally {
    if(typeof e=="object"&&isIDisposable(e))e.Dispose();
  }
}
function take(n, s){
  n<0?nonNegative():void 0;
  return{GetEnumerator:() => {
    const e=[Get(s)];
    return new _c_19(0, null, (o) => {
      o.s=o.s+1;
      if(o.s>n)return false;
      else {
        const en=e[0];
        return Equals(en, null)?insufficient():en.MoveNext()?(o.c=en.Current,o.s===n?(en.Dispose(),e[0]=null):void 0,true):(en.Dispose(),e[0]=null,insufficient());
      }
    }, () => {
      const x=e[0];
      if(!Equals(x, null))x.Dispose();
    });
  }};
}
function initInfinite(f){
  return{GetEnumerator:() => new _c_19(0, null, (e) => {
    e.c=f(e.s);
    e.s=e.s+1;
    return true;
  }, void 0)};
}
function forall_1(p, s){
  return!exists_1((x) =>!p(x), s);
}
function seqEmpty(){
  return FailWith("The input sequence was empty.");
}
function exists_1(p, s){
  const e=Get(s);
  try {
    let r=false;
    while(!r&&e.MoveNext())
      r=p(e.Current);
    return r;
  }
  finally {
    if(typeof e=="object"&&isIDisposable(e))e.Dispose();
  }
}
function LinkElement(el, children){
  InsertDoc(el, children, null);
}
function InsertDoc(parent, doc, pos){
  while(true)
    {
      if(doc!=null&&doc.$==1)return InsertNode(parent, doc.$0.El, pos);
      else if(doc!=null&&doc.$==2){
        const d=doc.$0;
        d.Dirty=false;
        doc=d.Current;
      }
      else if(doc==null)return pos;
      else if(doc!=null&&doc.$==4)return InsertNode(parent, doc.$0.Text, pos);
      else if(doc!=null&&doc.$==5)return InsertNode(parent, doc.$0, pos);
      else if(doc!=null&&doc.$==6)return foldBack((_1, _2) =>((((parent_1) =>(el) =>(pos_1) => el==null||el.constructor===Object?InsertDoc(parent_1, el, pos_1):InsertNode(parent_1, el, pos_1))(parent))(_1))(_2), doc.$0.Els, pos);
      else {
        const b=doc.$1;
        const a=doc.$0;
        doc=a;
        pos=InsertDoc(parent, b, pos);
      }
    }
}
function CreateRunState(parent, doc){
  return New_3(get_Empty(), CreateElemNode(parent, EmptyAttr(), doc));
}
function PerformAnimatedUpdate(childrenOnly, st, doc){
  if(get_UseAnimations()){
    const _1=null;
    return Delay(() => {
      const cur=FindAll(doc);
      const change=ComputeChangeAnim(st, cur);
      const enter=ComputeEnterAnim(st, cur);
      return Bind(Play(Append(change, ComputeExitAnim(st, cur))), () => Bind(SyncElemNodesNextFrame(childrenOnly, st), () => Bind(Play(enter), () => {
        st.PreviousNodes=cur;
        return Return(null);
      })));
    });
  }
  else return SyncElemNodesNextFrame(childrenOnly, st);
}
function PerformSyncUpdate(childrenOnly, st, doc){
  const cur=FindAll(doc);
  SyncElemNode(childrenOnly, st.Top);
  st.PreviousNodes=cur;
}
function CreateElemNode(el, attr, children){
  LinkElement(el, children);
  const attr_1=Insert(el, attr);
  return _c_15.New(attr_1, children, null, el, Int(), GetOptional(attr_1.OnAfterRender));
}
function InsertNode(parent, node, pos){
  InsertAt(parent, pos, node);
  return node;
}
function SyncElemNodesNextFrame(childrenOnly, st){
  if(BatchUpdatesEnabled()){
    const a=(ok) => {
      requestAnimationFrame(() => {
        SyncElemNode(childrenOnly, st.Top);
        ok();
      });
    };
    return FromContinuations((_1, _2, _3) => a.apply(null, [_1, _2, _3]));
  }
  else {
    SyncElemNode(childrenOnly, st.Top);
    return Return(null);
  }
}
function ComputeExitAnim(st, cur){
  return Concat(map_1((n) => GetExitAnim(n.Attr), ToArray(Except(cur, Filter((n) => HasExitAnim(n.Attr), st.PreviousNodes)))));
}
function ComputeEnterAnim(st, cur){
  return Concat(map_1((n) => GetEnterAnim(n.Attr), ToArray(Except(st.PreviousNodes, Filter((n) => HasEnterAnim(n.Attr), cur)))));
}
function ComputeChangeAnim(st, cur){
  const a=(n) => HasChangeAnim(n.Attr);
  const relevant=(a_1) => Filter(a, a_1);
  return Concat(map_1((n) => GetChangeAnim(n.Attr), ToArray(Intersect(relevant(st.PreviousNodes), relevant(cur)))));
}
function SyncElemNode(childrenOnly, el){
  !childrenOnly?SyncElement(el):void 0;
  Sync_1(el.Children);
  AfterRender(el);
}
function SyncElement(el){
  function hasDirtyChildren(el_1){
    function dirty(doc){
      while(true)
        {
          if(doc!=null&&doc.$==0){
            const b=doc.$1;
            const a=doc.$0;
            if(dirty(a))return true;
            else doc=b;
          }
          else if(doc!=null&&doc.$==2){
            const d=doc.$0;
            if(d.Dirty)return true;
            else doc=d.Current;
          }
          else if(doc!=null&&doc.$==6){
            const t=doc.$0;
            return t.Dirty||exists(hasDirtyChildren, t.Holes);
          }
          else return false;
        }
    }
    return dirty(el_1.Children);
  }
  Sync(el.El, el.Attr);
  if(hasDirtyChildren(el))DoSyncElement(el);
}
function Sync_1(doc){
  while(true)
    {
      if(doc!=null&&doc.$==1)return SyncElemNode(false, doc.$0);
      else if(doc!=null&&doc.$==2){
        const n=doc.$0;
        doc=n.Current;
      }
      else if(doc==null)return null;
      else if(doc!=null&&doc.$==5)return null;
      else if(doc!=null&&doc.$==4){
        const d=doc.$0;
        return d.Dirty?(d.Text.nodeValue=d.Value,d.Dirty=false):null;
      }
      else if(doc!=null&&doc.$==6){
        const t=doc.$0;
        iter_1((h) => {
          SyncElemNode(false, h);
        }, t.Holes);
        iter_1((t_1) => {
          Sync(t_1[0], t_1[1]);
        }, t.Attrs);
        return AfterRender(t);
      }
      else {
        const b=doc.$1;
        const a=doc.$0;
        Sync_1(a);
        doc=b;
      }
    }
}
function AfterRender(el){
  const m=GetOptional(el.Render);
  if(m!=null&&m.$==1){
    m.$0(el.El);
    SetOptional(el, "Render", null);
  }
}
function DoSyncElement(el){
  const parent=el.El;
  function ins(doc, pos){
    while(true)
      {
        if(doc!=null&&doc.$==1)return doc.$0.El;
        else if(doc!=null&&doc.$==2){
          const d=doc.$0;
          if(d.Dirty){
            d.Dirty=false;
            return InsertDoc(parent, d.Current, pos);
          }
          else doc=d.Current;
        }
        else if(doc==null)return pos;
        else if(doc!=null&&doc.$==4)return doc.$0.Text;
        else if(doc!=null&&doc.$==5)return doc.$0;
        else if(doc!=null&&doc.$==6){
          const t=doc.$0;
          if(t.Dirty)t.Dirty=false;
          return foldBack((_2, _3) => _2==null||_2.constructor===Object?ins(_2, _3):_2, t.Els, pos);
        }
        else {
          const b=doc.$1;
          const a=doc.$0;
          doc=a;
          pos=ins(b, pos);
        }
      }
  }
  const p=el.El;
  Iter((e) => {
    RemoveNode(p, e);
  }, Except_2(DocChildren(el), Children(el.El, GetOptional(el.Delimiters))));
  let _1=el.Children;
  const m=GetOptional(el.Delimiters);
  ins(_1, m!=null&&m.$==1?m.$0[1]:null);
}
let _c_14=Lazy((_i) => {
  Force(_c_3);
  return class Elt extends _c_3 {
    static {
      _c_14=_i(this);
    }
    docNode_1;
    updates_1;
    elt;
    rvUpdates;
    static New(el, attr, children){
      const node=CreateElemNode(el, attr, children.docNode);
      const rvUpdates=_c_18.Create(children.updates);
      return new Elt(ElemDoc(node), Map2Unit(Updates(node.Attr), rvUpdates.v), el, rvUpdates);
    }
    constructor(docNode, updates, elt, rvUpdates){
      super(docNode, updates);
      this.docNode_1=docNode;
      this.updates_1=updates;
      this.elt=elt;
      this.rvUpdates=rvUpdates;
    }
  };
});
function ofSeqNonCopying(xs){
  if(xs instanceof Array)return xs;
  else if(xs instanceof _c_2)return ofList(xs);
  else if(xs===null)return[];
  else {
    const q=[];
    const o=Get(xs);
    try {
      while(o.MoveNext())
        q.push(o.Current);
      return q;
    }
    finally {
      if(typeof o=="object"&&isIDisposable(o))o.Dispose();
    }
  }
}
function TreeReduce(defaultValue, reduction, array){
  const l=length(array);
  function loop(off){
    return(len) => {
      let _1;
      switch(len<=0?0:len===1?off>=0&&off<l?1:(_1=len,2):(_1=len,2)){
        case 0:
          return defaultValue;
        case 1:
          return get(array, off);
        case 2:
          const l2=len/2>>0;
          return reduction((loop(off))(l2), (loop(off+l2))(len-l2));
      }
    };
  }
  return(loop(0))(l);
}
function MapTreeReduce(mapping, defaultValue, reduction, array){
  const l=length(array);
  function loop(off){
    return(len) => {
      let _1;
      switch(len<=0?0:len===1?off>=0&&off<l?1:(_1=len,2):(_1=len,2)){
        case 0:
          return defaultValue;
        case 1:
          return mapping(get(array, off));
        case 2:
          const l2=len/2>>0;
          return reduction((loop(off))(l2), (loop(off+l2))(len-l2));
      }
    };
  }
  return(loop(0))(l);
}
function TryParse(s, r){
  return TryParse_2(s, -2147483648, 2147483647, r);
}
let _c_15=Lazy((_i) => class DocElemNode {
  static {
    _c_15=_i(this);
  }
  Attr;
  Children;
  Delimiters;
  El;
  ElKey;
  Render;
  Equals(o){
    return this.ElKey===o.ElKey;
  }
  GetHashCode(){
    return this.ElKey;
  }
  static New(Attr, Children_1, Delimiters, El, ElKey, Render){
    const _1={
      Attr:Attr, 
      Children:Children_1, 
      El:El, 
      ElKey:ElKey
    };
    let _2=(SetOptional(_1, "Delimiters", Delimiters),SetOptional(_1, "Render", Render),_1);
    return Create_1(_c_15, _2);
  }
});
function Forever(Item){
  return{$:0, $0:Item};
}
function Ready(Item1, Item2){
  return{
    $:2, 
    $0:Item1, 
    $1:Item2
  };
}
function Waiting(Item1, Item2){
  return{
    $:3, 
    $0:Item1, 
    $1:Item2
  };
}
let _c_16=Lazy((_i) => class TemplateHole extends _c {
  static {
    _c_16=_i(this);
  }
});
function notPresent(){
  throw new _c_26("New");
}
function convertTextNode(n){
  let m=null;
  let li=0;
  const s=n.textContent;
  const strRE=new RegExp(TextHoleRE(), "g");
  while(m=strRE.exec(s),m!==null)
    {
      n.parentNode.insertBefore(globalThis.document.createTextNode(string(s, Some(li), Some(strRE.lastIndex-get(m, 0).length-1))), n);
      li=strRE.lastIndex;
      const hole=globalThis.document.createElement("span");
      hole.setAttribute("ws-replace", get(m, 1).toLowerCase());
      n.parentNode.insertBefore(hole, n);
    }
  strRE.lastIndex=0;
  n.textContent=string(s, Some(li), null);
}
function failNotLoaded(name){
  console.warn("Instantiating non-loaded template", name);
}
function fillTextHole(instance, fillWith, templateName){
  const m=instance.querySelector("[ws-replace]");
  return Equals(m, null)?(console.warn("Filling non-existent text hole", templateName),null):(m.parentNode.replaceChild(globalThis.document.createTextNode(fillWith), m),Some(m.getAttribute("ws-replace")));
}
function removeHolesExcept(instance, dontRemove){
  const run=(attrName) => {
    foreachNotPreserved(instance, "["+attrName+"]", (e) => {
      if(!dontRemove.Contains(e.getAttribute(attrName)))e.removeAttribute(attrName);
    });
  };
  run("ws-attr");
  run("ws-onafterrender");
  run("ws-var");
  foreachNotPreserved(instance, "[ws-hole]", (e) => {
    if(!dontRemove.Contains(e.getAttribute("ws-hole"))){
      e.removeAttribute("ws-hole");
      while(e.hasChildNodes())
        e.removeChild(e.lastChild);
    }
  });
  foreachNotPreserved(instance, "[ws-replace]", (e) => {
    if(!dontRemove.Contains(e.getAttribute("ws-replace")))e.parentNode.removeChild(e);
  });
  foreachNotPreserved(instance, "[ws-on]", (e) => {
    e.setAttribute("ws-on", concat_2(" ", filter((x) => dontRemove.Contains(get(SplitChars(x, [":"], 1), 1)), SplitChars(e.getAttribute("ws-on"), [" "], 1))));
  });
  foreachNotPreserved(instance, "[ws-attr-holes]", (e) => {
    const holeAttrs=SplitChars(e.getAttribute("ws-attr-holes"), [" "], 1);
    for(let i=0, _2=holeAttrs.length-1;i<=_2;i++){
      const attrName=get(holeAttrs, i);
      let this_1=new RegExp(TextHoleRE(), "g");
      let _1=e.getAttribute(attrName).replace(this_1, (_3, _4) => dontRemove.Contains(_4)?_3:"");
      e.setAttribute(attrName, _1);
    }
  });
}
function fillInstanceAttrs(instance, fillWith){
  convertAttrs(fillWith);
  const name=fillWith.nodeName.toLowerCase();
  const m=instance.querySelector("[ws-attr="+name+"]");
  if(Equals(m, null))console.warn("Filling non-existent attr hole", name);
  else {
    m.removeAttribute("ws-attr");
    for(let i=0, _1=fillWith.attributes.length-1;i<=_1;i++){
      const a=fillWith.attributes.item(i);
      if(a.name=="class"&&m.hasAttribute("class"))m.setAttribute("class", m.getAttribute("class")+" "+a.nodeValue);
      else m.setAttribute(a.name, a.nodeValue);
    }
  }
}
function mapHoles(t, mappings){
  const run=(attrName) => {
    foreachNotPreserved(t, "["+attrName+"]", (e) => {
      let o;
      const m=(o=null,[mappings.TryGetValue(e.getAttribute(attrName).toLowerCase(), {get:() => o, set:(v) => {
        o=v;
      }}), o]);
      if(m[0])e.setAttribute(attrName, m[1]);
    });
  };
  run("ws-hole");
  run("ws-replace");
  run("ws-attr");
  run("ws-onafterrender");
  run("ws-var");
  foreachNotPreserved(t, "[ws-on]", (e) => {
    e.setAttribute("ws-on", concat_2(" ", map_1((x) => {
      let o;
      const a=SplitChars(x, [":"], 1);
      const m=(o=null,[mappings.TryGetValue(get(a, 1), {get:() => o, set:(v) => {
        o=v;
      }}), o]);
      return m[0]?get(a, 0)+":"+m[1]:x;
    }, SplitChars(e.getAttribute("ws-on"), [" "], 1))));
  });
  foreachNotPreserved(t, "[ws-attr-holes]", (e) => {
    const holeAttrs=SplitChars(e.getAttribute("ws-attr-holes"), [" "], 1);
    for(let i=0, _1=holeAttrs.length-1;i<=_1;i++)((() => {
      const attrName=get(holeAttrs, i);
      return e.setAttribute(attrName, fold((_2, _3) => {
        const a=KeyValue(_3);
        return _2.replace(new RegExp("\\${"+a[0]+"}", "ig"), "${"+a[1]+"}");
      }, e.getAttribute(attrName), mappings));
    })());
  });
}
function fill(fillWith, p, n){
  while(true)
    {
      if(fillWith.hasChildNodes())n=p.insertBefore(fillWith.lastChild, n);
      else return null;
    }
}
function convertAttrs(el){
  const attrs=el.attributes;
  const toRemove=[];
  const events=[];
  const holedAttrs=[];
  for(let i=0, _2=attrs.length-1;i<=_2;i++){
    const a=attrs.item(i);
    if(StartsWith(a.nodeName, "ws-on")&&a.nodeName!="ws-onafterrender"&&a.nodeName!="ws-on"){
      toRemove.push(a.nodeName);
      events.push(string(a.nodeName, Some("ws-on".length), null)+":"+a.nodeValue.toLowerCase());
    }
    else if(!StartsWith(a.nodeName, "ws-")&&(new RegExp(TextHoleRE())).test(a.nodeValue)){
      let this_1=new RegExp(TextHoleRE(), "g");
      let _1=a.nodeValue.replace(this_1, (_3, _4) =>"${"+_4.toLowerCase()+"}");
      a.nodeValue=_1;
      holedAttrs.push(a.nodeName);
    }
    else void 0;
  }
  if(!(events.length==0))el.setAttribute("ws-on", concat_2(" ", events));
  if(!(holedAttrs.length==0))el.setAttribute("ws-attr-holes", concat_2(" ", holedAttrs));
  const lowercaseAttr=(name) => {
    const m=el.getAttribute(name);
    if(m==null){ }
    else el.setAttribute(name, m.toLowerCase());
  };
  lowercaseAttr("ws-hole");
  lowercaseAttr("ws-replace");
  lowercaseAttr("ws-attr");
  lowercaseAttr("ws-onafterrender");
  lowercaseAttr("ws-var");
  iter_1((a_1) => {
    el.removeAttribute(a_1);
  }, toRemove);
}
function string(source, start, finish){
  if(start==null){
    if(finish!=null&&finish.$==1){
      const f=finish.$0;
      return f<0?"":source.slice(0, f+1);
    }
    else return"";
  }
  else if(finish==null)return source.slice(start.$0);
  else {
    const f_1=finish.$0;
    return f_1<0?"":source.slice(start.$0, f_1+1);
  }
}
function insufficient(){
  return FailWith("The input sequence has an insufficient number of elements.");
}
function arrContains(item, arr){
  let c=true;
  let i=0;
  while(c&&i<length(arr))
    if(Equals(arr[i], item))c=false;
    else i=i+1;
  return!c;
}
function nonNegative(){
  return FailWith("The input must be non-negative.");
}
let _c_17=Lazy((_i) => class KeyCollection extends _c {
  static {
    _c_17=_i(this);
  }
  d;
  GetEnumerator(){
    return Get(map_2((kvp) => kvp.K, this.d));
  }
  constructor(d){
    super();
    this.d=d;
  }
});
function get_UseAnimations(){
  return UseAnimations();
}
function Play(anim){
  const _1=null;
  return Delay(() => Bind(Run(() => { }, Actions(anim)), () => {
    Finalize(anim);
    return Return(null);
  }));
}
function Append(a, a_1){
  return Anim(Append_1(a.$0, a_1.$0));
}
function Run(k, anim){
  const dur=anim.Duration;
  if(dur===0)return Zero();
  else {
    const a=(ok) => {
      function loop(start){
        return(now) => {
          const t=now-start;
          anim.Compute(t);
          k();
          return t<=dur?void requestAnimationFrame((t_1) => {
            (loop(start))(t_1);
          }):ok();
        };
      }
      requestAnimationFrame((t) => {
        (loop(t))(t);
      });
    };
    return FromContinuations((_1, _2, _3) => a.apply(null, [_1, _2, _3]));
  }
}
function Anim(Item){
  return{$:0, $0:Item};
}
function Concat(xs){
  return Anim(Concat_1(map_2(List, xs)));
}
function BatchUpdatesEnabled(){
  return _c_20.BatchUpdatesEnabled;
}
function StartProcessor(procAsync){
  const st=[0];
  function work(){
    const _1=null;
    return Delay(() => Bind(procAsync, () => {
      const m=st[0];
      return Equals(m, 1)?(st[0]=0,Zero()):Equals(m, 2)?(st[0]=1,work()):Zero();
    }));
  }
  return() => {
    const m=st[0];
    if(Equals(m, 0)){
      st[0]=1;
      Start(work(), null);
    }
    else Equals(m, 1)?st[0]=2:void 0;
  };
}
let _c_18=Lazy((_i) => class Updates_1 {
  static {
    _c_18=_i(this);
  }
  c;
  s;
  v;
  static Create(v){
    let var_1;
    var_1=null;
    var_1=_c_18.New(v, null, () => {
      let c;
      c=var_1.s;
      return c===null?(c=Copy(var_1.c()),var_1.s=c,WhenObsoleteRun(c, () => {
        var_1.s=null;
      }),c):c;
    });
    return var_1;
  }
  static New(Current, Snap, VarView){
    return Create_1(_c_18, {
      c:Current, 
      s:Snap, 
      v:VarView
    });
  }
});
let _c_19=Lazy((_i) => class T extends _c {
  static {
    _c_19=_i(this);
  }
  s;
  c;
  n;
  d;
  e;
  Dispose(){
    if(this.d)this.d(this);
  }
  MoveNext(){
    const m=this.n(this);
    this.e=m?1:2;
    return m;
  }
  get Current(){
    return this.e===1?this.c:this.e===0?FailWith("Enumeration has not started. Call MoveNext."):FailWith("Enumeration already finished.");
  }
  constructor(s, c, n, d){
    super();
    this.s=s;
    this.c=c;
    this.n=n;
    this.d=d;
    this.e=0;
  }
});
function New_2(DynElem, DynFlags, DynNodes, OnAfterRender_1){
  const _1={
    DynElem:DynElem, 
    DynFlags:DynFlags, 
    DynNodes:DynNodes
  };
  SetOptional(_1, "OnAfterRender", OnAfterRender_1);
  return _1;
}
function concat_2(separator, strings){
  return ofSeq(strings).join(separator);
}
function SplitChars(s, sep, opts){
  return Split(s, new RegExp("["+RegexEscape(sep.join(""))+"]"), opts);
}
function StartsWith(t, s){
  return t.substring(0, s.length)==s;
}
function Split(s, pat, opts){
  return opts===1?filter((x) => x!=="", SplitWith(s, pat)):SplitWith(s, pat);
}
function RegexEscape(s){
  return s.replace(new RegExp("[-\\/\\\\^$*+?.()|[\\]{}]", "g"), "\\$&");
}
function SplitWith(str, pat){
  return str.split(pat);
}
function forall_2(f, s){
  return forall_1(f, protect(s));
}
function protect(s){
  return s==null?"":s;
}
function New_3(PreviousNodes, Top){
  return{PreviousNodes:PreviousNodes, Top:Top};
}
function get_Empty(){
  return NodeSet(new _c_13("New_3"));
}
function FindAll(doc){
  const q=[];
  function recF(recI, _1){
    while(true)
      switch(recI){
        case 0:
          if(_1!=null&&_1.$==0){
            const b=_1.$1;
            const a=_1.$0;
            recF(0, a);
            _1=b;
          }
          else if(_1!=null&&_1.$==1){
            const el=_1.$0;
            _1=el;
            recI=1;
          }
          else if(_1!=null&&_1.$==2){
            const em=_1.$0;
            _1=em.Current;
          }
          else if(_1!=null&&_1.$==6){
            const x=_1.$0.Holes;
            return(((a_1) =>(a_2) => {
              iter_1(a_1, a_2);
            })(loopEN))(x);
          }
          else return null;
          break;
        case 1:
          q.push(_1);
          _1=_1.Children;
          recI=0;
          break;
      }
  }
  function loop(node){
    return recF(0, node);
  }
  function loopEN(el){
    return recF(1, el);
  }
  loop(doc);
  return NodeSet(new _c_13("New_2", q));
}
function NodeSet(Item){
  return{$:0, $0:Item};
}
function Filter(f, a){
  return NodeSet(Filter_1(f, a.$0));
}
function Except(a, a_1){
  return NodeSet(Except_1(a.$0, a_1.$0));
}
function ToArray(a){
  return ToArray_2(a.$0);
}
function Intersect(a, a_1){
  return NodeSet(Intersect_1(a.$0, a_1.$0));
}
function UseAnimations(){
  return _c_23.UseAnimations;
}
function Actions(a){
  return ConcatActions(choose((a_1) => a_1.$==1?Some(a_1.$0):null, ToArray_1(a.$0)));
}
function Finalize(a){
  iter_1((a_1) => {
    if(a_1.$==0)a_1.$0();
  }, ToArray_1(a.$0));
}
function ConcatActions(xs){
  const xs_1=ofSeqNonCopying(xs);
  const m=length(xs_1);
  if(m===0)return Const_1();
  else if(m===1)return get(xs_1, 0);
  else {
    const dur=max(map_2((anim) => anim.Duration, xs_1));
    const xs_2=map_1((x) => Prolong(dur, x), xs_1);
    return Def(dur, (t) => {
      iter_1((anim) => {
        anim.Compute(t);
      }, xs_2);
    });
  }
}
function List(a){
  return a.$0;
}
function Const_1(v){
  return Def(0, () => v);
}
function Def(d, f){
  return{Compute:f, Duration:d};
}
function Prolong(nextDuration, anim){
  const comp=anim.Compute;
  const dur=anim.Duration;
  const last=Create(() => anim.Compute(anim.Duration));
  return{Compute:(t) => t>=dur?last.f():comp(t), Duration:nextDuration};
}
let _c_20=Lazy((_i) => class Proxy {
  static {
    _c_20=_i(this);
  }
  static BatchUpdatesEnabled;
  static {
    this.BatchUpdatesEnabled=true;
  }
});
function Int(){
  set_counter(counter()+1);
  return counter();
}
function set_counter(_1){
  _c_28.counter=_1;
}
function counter(){
  return _c_28.counter;
}
let _c_21=Lazy((_i) => class Client {
  static {
    _c_21=_i(this);
  }
  static FloatApplyChecked;
  static FloatGetChecked;
  static FloatSetChecked;
  static FloatApplyUnchecked;
  static FloatGetUnchecked;
  static FloatSetUnchecked;
  static IntApplyChecked;
  static IntGetChecked;
  static IntSetChecked;
  static IntApplyUnchecked;
  static IntGetUnchecked;
  static IntSetUnchecked;
  static FileApplyUnchecked;
  static FileGetUnchecked;
  static FileSetUnchecked;
  static DateTimeApplyUnchecked;
  static DateTimeGetUnchecked;
  static DateTimeSetUnchecked;
  static StringListApply;
  static StringListGet;
  static StringListSet;
  static StringApply;
  static StringGet;
  static StringSet;
  static BoolCheckedApply;
  static EmptyAttr;
  static {
    this.EmptyAttr=null;
    this.BoolCheckedApply=(var_1) =>[(el) => {
      el.addEventListener("change", () => var_1.Get()!=el.checked?var_1.Set(el.checked):null);
    }, (_1) =>(_2) => _2!=null&&_2.$==1?void(_1.checked=_2.$0):null, Map(Some, var_1.View)];
    this.StringSet=(el) =>(s_8) => {
      el.value=s_8;
    };
    this.StringGet=(el) => Some(el.value);
    const g=StringGet();
    const s=StringSet();
    this.StringApply=(v) => ApplyValue(g, s, v);
    this.StringListSet=(el) =>(s_8) => {
      const options_=el.options;
      for(let i=0, _1=options_.length-1;i<=_1;i++)((() => {
        const option=options_.item(i);
        option.selected=arrContains(option.value, s_8);
      })());
    };
    this.StringListGet=(el) => {
      const selectedOptions=el.selectedOptions;
      return Some(ofSeq(delay(() => collect((i) =>[selectedOptions.item(i).value], range(0, selectedOptions.length-1)))));
    };
    const g_1=StringListGet();
    const s_1=StringListSet();
    this.StringListApply=(v) => ApplyValue(g_1, s_1, v);
    this.DateTimeSetUnchecked=(el) =>(i) => {
      el.value=(new Date(i)).toLocaleString();
    };
    this.DateTimeGetUnchecked=(el) => {
      let o;
      let m;
      const s_8=el.value;
      if(isBlank(s_8))return Some(-8640000000000000);
      else {
        o=0;
        const m_1=TryParse_1(s_8);
        let _1=m_1!=null&&m_1.$==1&&(o=m_1.$0,true);
        m=[_1, o];
        return m[0]?Some(m[1]):null;
      }
    };
    const g_2=DateTimeGetUnchecked();
    const s_2=DateTimeSetUnchecked();
    this.DateTimeApplyUnchecked=(v) => ApplyValue(g_2, s_2, v);
    this.FileSetUnchecked=() =>() => null;
    this.FileGetUnchecked=(el) => {
      const files=el.files;
      return Some(ofSeq(delay(() => map_2((i) => files.item(i), range(0, files.length-1)))));
    };
    const g_3=FileGetUnchecked();
    const s_3=FileSetUnchecked();
    this.FileApplyUnchecked=(v) => FileApplyValue(g_3, s_3, v);
    this.IntSetUnchecked=(el) =>(i) => {
      el.value=String(i);
    };
    this.IntGetUnchecked=(el) => {
      const s_8=el.value;
      if(isBlank(s_8))return Some(0);
      else {
        const pd=+s_8;
        return pd!==pd>>0?null:Some(pd);
      }
    };
    const g_4=IntGetUnchecked();
    const s_4=IntSetUnchecked();
    this.IntApplyUnchecked=(v) => ApplyValue(g_4, s_4, v);
    this.IntSetChecked=(el) =>(i) => {
      const i_1=i.Input;
      return el.value!=i_1?void(el.value=i_1):null;
    };
    this.IntGetChecked=(el) => {
      let _1;
      let o;
      const s_8=el.value;
      if(isBlank(s_8))_1=(el.checkValidity?el.checkValidity():true)?_c_25.Blank(s_8):_c_25.Invalid(s_8);
      else {
        const m=(o=0,[TryParse(s_8, {get:() => o, set:(v) => {
          o=v;
        }}), o]);
        _1=m[0]?_c_25.Valid(m[1], s_8):_c_25.Invalid(s_8);
      }
      return Some(_1);
    };
    const g_5=IntGetChecked();
    const s_5=IntSetChecked();
    this.IntApplyChecked=(v) => ApplyValue(g_5, s_5, v);
    this.FloatSetUnchecked=(el) =>(i) => {
      el.value=String(i);
    };
    this.FloatGetUnchecked=(el) => {
      const s_8=el.value;
      if(isBlank(s_8))return Some(0);
      else {
        const pd=+s_8;
        return isNaN(pd)?null:Some(pd);
      }
    };
    const g_6=FloatGetUnchecked();
    const s_6=FloatSetUnchecked();
    this.FloatApplyUnchecked=(v) => ApplyValue(g_6, s_6, v);
    this.FloatSetChecked=(el) =>(i) => {
      const i_1=i.Input;
      return el.value!=i_1?void(el.value=i_1):null;
    };
    this.FloatGetChecked=(el) => {
      let _1;
      const s_8=el.value;
      if(isBlank(s_8))_1=(el.checkValidity?el.checkValidity():true)?_c_25.Blank(s_8):_c_25.Invalid(s_8);
      else {
        const i=+s_8;
        _1=isNaN(i)?_c_25.Invalid(s_8):_c_25.Valid(i, s_8);
      }
      return Some(_1);
    };
    const g_7=FloatGetChecked();
    const s_7=FloatSetChecked();
    this.FloatApplyChecked=(v) => ApplyValue(g_7, s_7, v);
  }
});
let _c_22=Lazy((_i) => class $StartupCode_DomUtility {
  static {
    _c_22=_i(this);
  }
  static defaultWrap;
  static wrapMap;
  static rhtml;
  static rtagName;
  static rxhtmlTag;
  static {
    this.rxhtmlTag=new RegExp("<(?!area|br|col|embed|hr|img|input|link|meta|param)(([\\w:]+)[^>]*)\\/>", "gi");
    this.rtagName=new RegExp("<([\\w:]+)");
    this.rhtml=new RegExp("<|&#?\\w+;");
    const table_1=[1, "<table>", "</table>"];
    let _1=Object.fromEntries([["option", [1, "<select multiple='multiple'>", "</select>"]], ["legend", [1, "<fieldset>", "</fieldset>"]], ["area", [1, "<map>", "</map>"]], ["param", [1, "<object>", "</object>"]], ["thead", table_1], ["tbody", table_1], ["tfoot", table_1], ["tr", [2, "<table><tbody>", "</tbody></table>"]], ["col", [2, "<table><colgroup>", "</colgoup></table>"]], ["td", [3, "<table><tbody><tr>", "</tr></tbody></table>"]]]);
    this.wrapMap=_1;
    this.defaultWrap=[0, "", ""];
  }
});
function Obsolete(sn){
  let _1;
  const m=sn.s;
  if(m==null||(m!=null&&m.$==2?(_1=m.$1,false):m!=null&&m.$==3?(_1=m.$1,false):true))void 0;
  else {
    sn.s=null;
    for(let i=0, _2=length(_1)-1;i<=_2;i++){
      const o=get(_1, i);
      if(typeof o=="object")(((sn_1) => {
        Obsolete(sn_1);
      })(o));
      else o();
    }
  }
}
let _c_23=Lazy((_i) => class $StartupCode_Animation {
  static {
    _c_23=_i(this);
  }
  static UseAnimations;
  static CubicInOut;
  static {
    this.CubicInOut=_c_27.Custom((t) => {
      const t2=t*t;
      return 3*t2-2*(t2*t);
    });
    this.UseAnimations=true;
  }
});
function Append_1(x, y){
  return x.$==0?y:y.$==0?x:{
    $:2, 
    $0:x, 
    $1:y
  };
}
function ToArray_1(xs){
  const out=[];
  function loop(xs_1){
    while(true)
      {
        if(xs_1.$==1)return out.push(xs_1.$0);
        else if(xs_1.$==2){
          const y=xs_1.$1;
          const x=xs_1.$0;
          loop(x);
          xs_1=y;
        }
        else return xs_1.$==3?iter_1((v) => {
          out.push(v);
        }, xs_1.$0):null;
      }
  }
  loop(xs);
  return out.slice(0);
}
function Concat_1(xs){
  const x=ofSeqNonCopying(xs);
  return TreeReduce(Empty(), Append_1, x);
}
function Empty(){
  return _c_29.Empty;
}
function concat_3(o){
  let r=[];
  let k;
  for(var k_1 in o)r.push.apply(r, o[k_1]);
  return r;
}
let _c_24=Lazy((_i) => class Var extends _c {
  static {
    _c_24=_i(this);
  }
});
function ApplyValue(get_1, set_1, var_1){
  let expectedValue;
  expectedValue=null;
  return[(el) => {
    const onChange=() => {
      var_1.UpdateMaybe((v) => {
        let _1;
        expectedValue=get_1(el);
        return expectedValue!=null&&expectedValue.$==1&&(!Equals(expectedValue.$0, v)&&(_1=[expectedValue, expectedValue.$0],true))?_1[0]:null;
      });
    };
    el.addEventListener("change", onChange);
    el.addEventListener("input", onChange);
    el.addEventListener("keypress", onChange);
  }, (x) => {
    const _1=set_1(x);
    return(_2) => _2==null?null:_1(_2.$0);
  }, Map((v) => {
    let _1;
    return expectedValue!=null&&expectedValue.$==1&&(Equals(expectedValue.$0, v)&&(_1=expectedValue.$0,true))?null:Some(v);
  }, var_1.View)];
}
function StringSet(){
  return _c_21.StringSet;
}
function StringGet(){
  return _c_21.StringGet;
}
function StringListSet(){
  return _c_21.StringListSet;
}
function StringListGet(){
  return _c_21.StringListGet;
}
function DateTimeSetUnchecked(){
  return _c_21.DateTimeSetUnchecked;
}
function DateTimeGetUnchecked(){
  return _c_21.DateTimeGetUnchecked;
}
function FileApplyValue(get_1, set_1, var_1){
  let expectedValue;
  expectedValue=null;
  return[(el) => {
    el.addEventListener("change", () => {
      var_1.UpdateMaybe((v) => {
        let _1;
        expectedValue=get_1(el);
        return expectedValue!=null&&expectedValue.$==1&&(expectedValue.$0!==v&&(_1=[expectedValue, expectedValue.$0],true))?_1[0]:null;
      });
    });
  }, (x) => {
    const _1=set_1(x);
    return(_2) => _2==null?null:_1(_2.$0);
  }, Map((v) => {
    let _1;
    return expectedValue!=null&&expectedValue.$==1&&(Equals(expectedValue.$0, v)&&(_1=expectedValue.$0,true))?null:Some(v);
  }, var_1.View)];
}
function FileSetUnchecked(){
  return _c_21.FileSetUnchecked;
}
function FileGetUnchecked(){
  return _c_21.FileGetUnchecked;
}
function IntSetUnchecked(){
  return _c_21.IntSetUnchecked;
}
function IntGetUnchecked(){
  return _c_21.IntGetUnchecked;
}
function IntSetChecked(){
  return _c_21.IntSetChecked;
}
function IntGetChecked(){
  return _c_21.IntGetChecked;
}
function FloatSetUnchecked(){
  return _c_21.FloatSetUnchecked;
}
function FloatGetUnchecked(){
  return _c_21.FloatGetUnchecked;
}
function FloatSetChecked(){
  return _c_21.FloatSetChecked;
}
function FloatGetChecked(){
  return _c_21.FloatGetChecked;
}
function isBlank(s){
  return forall_2(IsWhiteSpace, s);
}
let _c_25=Lazy((_i) => class CheckedInput {
  static {
    _c_25=_i(this);
  }
  get Input(){
    return this.$==1?this.$0:this.$==2?this.$0:this.$1;
  }
  static Blank(inputText){
    return Create_1(CheckedInput, {$:2, $0:inputText});
  }
  static Invalid(inputText){
    return Create_1(CheckedInput, {$:1, $0:inputText});
  }
  static Valid(value, inputText){
    return Create_1(CheckedInput, {
      $:0, 
      $0:value, 
      $1:inputText
    });
  }
});
let _c_26=Lazy((_i) => {
  Force(Error);
  return class KeyNotFoundException extends Error {
    static {
      _c_26=_i(this);
    }
    static New(){
      return new this("New");
    }
    static New_1(message){
      return new this("New_1", message);
    }
    constructor(i, _1){
      if(i=="New"){
        i="New_1";
        _1="The given key was not present in the dictionary.";
      }
      if(i=="New_1"){
        const message=_1;
        super(message);
      }
    }
  };
});
let _c_27=Lazy((_i) => class Easing extends _c {
  static {
    _c_27=_i(this);
  }
  transformTime;
  static Custom(f){
    return new Easing(f);
  }
  constructor(transformTime){
    super();
    this.transformTime=transformTime;
  }
});
function Filter_1(ok, set_1){
  return new _c_13("New_2", filter(ok, ToArray_2(set_1)));
}
function Except_1(excluded, included){
  const set_1=new _c_13("New_2", ToArray_2(included));
  set_1.ExceptWith(ToArray_2(excluded));
  return set_1;
}
function ToArray_2(set_1){
  const arr=create(set_1.Count, void 0);
  set_1.CopyTo(arr, 0);
  return arr;
}
function Intersect_1(a, b){
  const set_1=new _c_13("New_2", ToArray_2(a));
  set_1.IntersectWith(ToArray_2(b));
  return set_1;
}
let _c_28=Lazy((_i) => class $StartupCode_Abbrev {
  static {
    _c_28=_i(this);
  }
  static counter;
  static {
    this.counter=0;
  }
});
function IsWhiteSpace(c){
  return c.match(new RegExp("\\s"))!==null;
}
function TryParse_1(s){
  const d=Date.parse(s);
  return isNaN(d)?null:Some(d);
}
function TryParse_2(s, min, max_1, r){
  const x=+s;
  const ok=x===x-x%1&&x>=min&&x<=max_1;
  if(ok)r.set(x);
  return ok;
}
function Children(elem, delims){
  let n;
  if(delims!=null&&delims.$==1){
    const a=[];
    n=delims.$0[0].nextSibling;
    while(n!==delims.$0[1])
      {
        a.push(n);
        n=n.nextSibling;
      }
    return DomNodes(a);
  }
  else {
    let _1=elem.childNodes.length;
    const o=elem.childNodes;
    let _2=init(_1, (a_1) => o[a_1]);
    return DomNodes(_2);
  }
}
function Except_2(a, a_1){
  const excluded=a.$0;
  return DomNodes(filter((n) => forall((k) =>!(n===k), excluded), a_1.$0));
}
function Iter(f, a){
  iter_1(f, a.$0);
}
function DocChildren(node){
  const q=[];
  function loop(doc){
    while(true)
      {
        if(doc!=null&&doc.$==2){
          const d=doc.$0;
          doc=d.Current;
        }
        else if(doc!=null&&doc.$==1)return q.push(doc.$0.El);
        else if(doc==null)return null;
        else if(doc!=null&&doc.$==5)return q.push(doc.$0);
        else if(doc!=null&&doc.$==4)return q.push(doc.$0.Text);
        else if(doc!=null&&doc.$==6){
          const x=doc.$0.Els;
          return(((a_1) =>(a_2) => {
            iter_1(a_1, a_2);
          })((a_1) => {
            if(a_1==null||a_1.constructor===Object)loop(a_1);
            else q.push(a_1);
          }))(x);
        }
        else {
          const b=doc.$1;
          const a=doc.$0;
          loop(a);
          doc=b;
        }
      }
  }
  loop(node.Children);
  return DomNodes(ofSeqNonCopying(q));
}
function DomNodes(Item){
  return{$:0, $0:Item};
}
function Create(f){
  return New_4(false, f, forceLazy);
}
function forceLazy(){
  const v=this.v();
  this.c=true;
  this.v=v;
  this.f=cachedLazy;
  return v;
}
function cachedLazy(){
  return this.v;
}
let _c_29=Lazy((_i) => class $StartupCode_AppendList {
  static {
    _c_29=_i(this);
  }
  static Empty;
  static {
    this.Empty={$:0};
  }
});
function Clear(a){
  a.splice(0, length(a));
}
function New_4(created, evalOrVal, force){
  return{
    c:created, 
    v:evalOrVal, 
    f:force
  };
}
OnLoad(() => {
  Main();
});
Start_1();

