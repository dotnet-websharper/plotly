(function (Global) {
  "use strict";

  // Polyfill

  if (!Date.now) {
    Date.now = function () {
      return new Date().getTime();
    };
  }

  if (!Math.trunc) {
    Math.trunc = function (x) {
      return x < 0 ? Math.ceil(x) : Math.floor(x);
    }
  }

  if (!Object.setPrototypeOf) {
    Object.setPrototypeOf = function (obj, proto) {
      obj.__proto__ = proto;
      return obj;
    }
  }

  Global.WebSharper = {
    Runtime: {
      Ctor: function (ctor, typeFunction) {
        ctor.prototype = typeFunction.prototype;
        return ctor;
      },

      Class: function (members, base, statics) {
        var proto = members;
        if (base) {
          proto = new base();
          for (var m in members) { proto[m] = members[m] }
        }
        var typeFunction = function (copyFrom) {
          if (copyFrom) {
            for (var f in copyFrom) { this[f] = copyFrom[f] }
          }
        }
        typeFunction.prototype = proto;
        if (statics) {
          for (var f in statics) { typeFunction[f] = statics[f] }
        }
        return typeFunction;
      },

      Clone: function (obj) {
        var res = {};
        for (var p of Object.getOwnPropertyNames(obj)) { res[p] = obj[p] }
        Object.setPrototypeOf(res, Object.getPrototypeOf(obj));
        return res;
      },

      NewObject:
        function (kv) {
          var o = {};
          for (var i = 0; i < kv.length; i++) {
            o[kv[i][0]] = kv[i][1];
          }
          return o;
        },

      PrintObject:
        function (obj) {
          var res = "{ ";
          var empty = true;
          for (var field of Object.getOwnPropertyNames(obj)) {
            if (empty) {
              empty = false;
            } else {
              res += ", ";
            }
            res += field + " = " + obj[field];
          }
          if (empty) {
            res += "}";
          } else {
            res += " }";
          }
          return res;
        },

      DeleteEmptyFields:
        function (obj, fields) {
          for (var i = 0; i < fields.length; i++) {
            var f = fields[i];
            if (obj[f] === void (0)) { delete obj[f]; }
          }
          return obj;
        },

      GetOptional:
        function (value) {
          return (value === void (0)) ? null : { $: 1, $0: value };
        },

      SetOptional:
        function (obj, field, value) {
          if (value) {
            obj[field] = value.$0;
          } else {
            delete obj[field];
          }
        },

      SetOrDelete:
        function (obj, field, value) {
          if (value === void (0)) {
            delete obj[field];
          } else {
            obj[field] = value;
          }
        },

      Apply: function (f, obj, args) {
        return f.apply(obj, args);
      },

      Bind: function (f, obj) {
        return function () { return f.apply(this, arguments) };
      },

      CreateFuncWithArgs: function (f) {
        return function () { return f(Array.prototype.slice.call(arguments)) };
      },

      CreateFuncWithOnlyThis: function (f) {
        return function () { return f(this) };
      },

      CreateFuncWithThis: function (f) {
        return function () { return f(this).apply(null, arguments) };
      },

      CreateFuncWithThisArgs: function (f) {
        return function () { return f(this)(Array.prototype.slice.call(arguments)) };
      },

      CreateFuncWithRest: function (length, f) {
        return function () { return f(Array.prototype.slice.call(arguments, 0, length).concat([Array.prototype.slice.call(arguments, length)])) };
      },

      CreateFuncWithArgsRest: function (length, f) {
        return function () { return f([Array.prototype.slice.call(arguments, 0, length), Array.prototype.slice.call(arguments, length)]) };
      },

      BindDelegate: function (func, obj) {
        var res = func.bind(obj);
        res.$Func = func;
        res.$Target = obj;
        return res;
      },

      CreateDelegate: function (invokes) {
        if (invokes.length == 0) return null;
        if (invokes.length == 1) return invokes[0];
        var del = function () {
          var res;
          for (var i = 0; i < invokes.length; i++) {
            res = invokes[i].apply(null, arguments);
          }
          return res;
        };
        del.$Invokes = invokes;
        return del;
      },

      CombineDelegates: function (dels) {
        var invokes = [];
        for (var i = 0; i < dels.length; i++) {
          var del = dels[i];
          if (del) {
            if ("$Invokes" in del)
              invokes = invokes.concat(del.$Invokes);
            else
              invokes.push(del);
          }
        }
        return WebSharper.Runtime.CreateDelegate(invokes);
      },

      DelegateEqual: function (d1, d2) {
        if (d1 === d2) return true;
        if (d1 == null || d2 == null) return false;
        var i1 = d1.$Invokes || [d1];
        var i2 = d2.$Invokes || [d2];
        if (i1.length != i2.length) return false;
        for (var i = 0; i < i1.length; i++) {
          var e1 = i1[i];
          var e2 = i2[i];
          if (!(e1 === e2 || ("$Func" in e1 && "$Func" in e2 && e1.$Func === e2.$Func && e1.$Target == e2.$Target)))
            return false;
        }
        return true;
      },

      ThisFunc: function (d) {
        return function () {
          var args = Array.prototype.slice.call(arguments);
          args.unshift(this);
          return d.apply(null, args);
        };
      },

      ThisFuncOut: function (f) {
        return function () {
          var args = Array.prototype.slice.call(arguments);
          return f.apply(args.shift(), args);
        };
      },

      ParamsFunc: function (length, d) {
        return function () {
          var args = Array.prototype.slice.call(arguments);
          return d.apply(null, args.slice(0, length).concat([args.slice(length)]));
        };
      },

      ParamsFuncOut: function (length, f) {
        return function () {
          var args = Array.prototype.slice.call(arguments);
          return f.apply(null, args.slice(0, length).concat(args[length]));
        };
      },

      ThisParamsFunc: function (length, d) {
        return function () {
          var args = Array.prototype.slice.call(arguments);
          args.unshift(this);
          return d.apply(null, args.slice(0, length + 1).concat([args.slice(length + 1)]));
        };
      },

      ThisParamsFuncOut: function (length, f) {
        return function () {
          var args = Array.prototype.slice.call(arguments);
          return f.apply(args.shift(), args.slice(0, length).concat(args[length]));
        };
      },

      Curried: function (f, n, args) {
        args = args || [];
        return function (a) {
          var allArgs = args.concat([a === void (0) ? null : a]);
          if (n == 1)
            return f.apply(null, allArgs);
          if (n == 2)
            return function (a) { return f.apply(null, allArgs.concat([a === void (0) ? null : a])); }
          return WebSharper.Runtime.Curried(f, n - 1, allArgs);
        }
      },

      Curried2: function (f) {
        return function (a) { return function (b) { return f(a, b); } }
      },

      Curried3: function (f) {
        return function (a) { return function (b) { return function (c) { return f(a, b, c); } } }
      },

      UnionByType: function (types, value, optional) {
        var vt = typeof value;
        for (var i = 0; i < types.length; i++) {
          var t = types[i];
          if (typeof t == "number") {
            if (Array.isArray(value) && (t == 0 || value.length == t)) {
              return { $: i, $0: value };
            }
          } else {
            if (t == vt) {
              return { $: i, $0: value };
            }
          }
        }
        if (!optional) {
          throw new Error("Type not expected for creating Choice value.");
        }
      },

      MarkResizable: function (arr) {
        Object.defineProperty(arr, "resizable", { enumerable: false, writable: false, configurable: false, value: true });
        return arr;
      },

      MarkReadOnly: function (arr) {
        Object.defineProperty(arr, "readonly", { enumerable: false, writable: false, configurable: false, value: true });
        return arr;
      },

      ScriptBasePath: "./",

      ScriptPath: function (a, f) {
        return this.ScriptBasePath + (this.ScriptSkipAssemblyDir ? "" : a + "/") + f;
      },

      OnLoad:
        function (f) {
          if (!("load" in this)) {
            this.load = [];
          }
          this.load.push(f);
        },

      Start:
        function () {
          function run(c) {
            for (var i = 0; i < c.length; i++) {
              c[i]();
            }
          }
          if ("load" in this) {
            run(this.load);
            this.load = [];
          }
        },
    }
  }

  Global.WebSharper.Runtime.OnLoad(function () {
    if (Global.WebSharper && WebSharper.Activator && WebSharper.Activator.Activate)
      WebSharper.Activator.Activate()
  });

  Global.ignore = function() { };
  Global.id = function(x) { return x };
  Global.fst = function(x) { return x[0] };
  Global.snd = function(x) { return x[1] };
  Global.trd = function(x) { return x[2] };

  if (!Global.console) {
    Global.console = {
      count: ignore,
      dir: ignore,
      error: ignore,
      group: ignore,
      groupEnd: ignore,
      info: ignore,
      log: ignore,
      profile: ignore,
      profileEnd: ignore,
      time: ignore,
      timeEnd: ignore,
      trace: ignore,
      warn: ignore
    }
  }
}(self));
;
/* https://github.com/jonathantneal/closest */
(function(w,p){p=w.Element.prototype
if(!p.matches){p.matches=p.msMatchesSelector||function(s){var m=(this.document||this.ownerDocument).querySelectorAll(s);for(var i=0;m[i]&&m[i]!==e;++i);return!!m[i]}}
if(!p.closest){p.closest=function(s){var e=this;while(e&&e.nodeType==1){if(e.matches(s))return e;e=e.parentNode}return null}}})(self);
(function () {
    var lastTime = 0;
    var vendors = ['webkit', 'moz'];
    for (var x = 0; x < vendors.length && !window.requestAnimationFrame; ++x) {
        window.requestAnimationFrame = window[vendors[x] + 'RequestAnimationFrame'];
        window.cancelAnimationFrame =
          window[vendors[x] + 'CancelAnimationFrame'] || window[vendors[x] + 'CancelRequestAnimationFrame'];
    }

    if (!window.requestAnimationFrame)
        window.requestAnimationFrame = function (callback, element) {
            var currTime = new Date().getTime();
            var timeToCall = Math.max(0, 16 - (currTime - lastTime));
            var id = window.setTimeout(function () { callback(currTime + timeToCall); },
              timeToCall);
            lastTime = currTime + timeToCall;
            return id;
        };

    if (!window.cancelAnimationFrame)
        window.cancelAnimationFrame = function (id) {
            clearTimeout(id);
        };
}());
;
(function(Global)
{
 "use strict";
 var WebSharper,Plotly,Tests,Client,Operators,List,Obj,UI,HtmlModule,attr,AttrModule,T,Arrays,Unchecked,JavaScript,Pervasives,Concurrency,Doc,AttrProxy,Client$1,Templates,SC$1,AsyncBody,JS,Object,CT,SC$2,View,DomUtility,Attrs,EventTarget,Node,Collections,Dictionary,Trace,Scheduler,Error,OperationCanceledException,Enumerator,CancellationTokenSource,Snap,SC$3,HashSet,Seq,WindowOrWorkerGlobalScope,Docs,Elt,Array,DocElemNode,CharacterData,DictionaryUtil,Prepare,Slice,KeyCollection,Numeric,An,Settings,Abbrev,Mailbox,Updates,T$1,Attrs$1,Dyn,Strings,Docs$1,RunState,NodeSet,Anims,SC$4,Fresh,SC$5,SC$6,SC$7,AppendList,HashSetUtil,Var,BindVar,String,CheckedInput,Easing,HashSet$1,SC$8,Char,DomNodes,Lazy,SC$9,Queue,LazyExtensionsProxy,LazyRecord,Plotly$1,Runtime,console,Date;
 WebSharper=Global.WebSharper=Global.WebSharper||{};
 Plotly=WebSharper.Plotly=WebSharper.Plotly||{};
 Tests=Plotly.Tests=Plotly.Tests||{};
 Client=Tests.Client=Tests.Client||{};
 Operators=WebSharper.Operators=WebSharper.Operators||{};
 List=WebSharper.List=WebSharper.List||{};
 Obj=WebSharper.Obj=WebSharper.Obj||{};
 UI=WebSharper.UI=WebSharper.UI||{};
 HtmlModule=UI.HtmlModule=UI.HtmlModule||{};
 attr=HtmlModule.attr=HtmlModule.attr||{};
 AttrModule=UI.AttrModule=UI.AttrModule||{};
 T=List.T=List.T||{};
 Arrays=WebSharper.Arrays=WebSharper.Arrays||{};
 Unchecked=WebSharper.Unchecked=WebSharper.Unchecked||{};
 JavaScript=WebSharper.JavaScript=WebSharper.JavaScript||{};
 Pervasives=JavaScript.Pervasives=JavaScript.Pervasives||{};
 Concurrency=WebSharper.Concurrency=WebSharper.Concurrency||{};
 Doc=UI.Doc=UI.Doc||{};
 AttrProxy=UI.AttrProxy=UI.AttrProxy||{};
 Client$1=UI.Client=UI.Client||{};
 Templates=Client$1.Templates=Client$1.Templates||{};
 SC$1=Global.StartupCode$WebSharper_Plotly_Tests$Client=Global.StartupCode$WebSharper_Plotly_Tests$Client||{};
 AsyncBody=Concurrency.AsyncBody=Concurrency.AsyncBody||{};
 JS=JavaScript.JS=JavaScript.JS||{};
 Object=Global.Object;
 CT=Concurrency.CT=Concurrency.CT||{};
 SC$2=Global.StartupCode$WebSharper_Main$Concurrency=Global.StartupCode$WebSharper_Main$Concurrency||{};
 View=UI.View=UI.View||{};
 DomUtility=UI.DomUtility=UI.DomUtility||{};
 Attrs=UI.Attrs=UI.Attrs||{};
 EventTarget=Global.EventTarget;
 Node=Global.Node;
 Collections=WebSharper.Collections=WebSharper.Collections||{};
 Dictionary=Collections.Dictionary=Collections.Dictionary||{};
 Trace=Global.Trace;
 Scheduler=Concurrency.Scheduler=Concurrency.Scheduler||{};
 Error=Global.Error;
 OperationCanceledException=WebSharper.OperationCanceledException=WebSharper.OperationCanceledException||{};
 Enumerator=WebSharper.Enumerator=WebSharper.Enumerator||{};
 CancellationTokenSource=WebSharper.CancellationTokenSource=WebSharper.CancellationTokenSource||{};
 Snap=UI.Snap=UI.Snap||{};
 SC$3=Global.StartupCode$WebSharper_UI$Templates=Global.StartupCode$WebSharper_UI$Templates||{};
 HashSet=Collections.HashSet=Collections.HashSet||{};
 Seq=WebSharper.Seq=WebSharper.Seq||{};
 WindowOrWorkerGlobalScope=Global.WindowOrWorkerGlobalScope;
 Docs=UI.Docs=UI.Docs||{};
 Elt=UI.Elt=UI.Elt||{};
 Array=UI.Array=UI.Array||{};
 DocElemNode=UI.DocElemNode=UI.DocElemNode||{};
 CharacterData=Global.CharacterData;
 DictionaryUtil=Collections.DictionaryUtil=Collections.DictionaryUtil||{};
 Prepare=Templates.Prepare=Templates.Prepare||{};
 Slice=WebSharper.Slice=WebSharper.Slice||{};
 KeyCollection=Collections.KeyCollection=Collections.KeyCollection||{};
 Numeric=WebSharper.Numeric=WebSharper.Numeric||{};
 An=UI.An=UI.An||{};
 Settings=Client$1.Settings=Client$1.Settings||{};
 Abbrev=UI.Abbrev=UI.Abbrev||{};
 Mailbox=Abbrev.Mailbox=Abbrev.Mailbox||{};
 Updates=UI.Updates=UI.Updates||{};
 T$1=Enumerator.T=Enumerator.T||{};
 Attrs$1=Client$1.Attrs=Client$1.Attrs||{};
 Dyn=Attrs$1.Dyn=Attrs$1.Dyn||{};
 Strings=WebSharper.Strings=WebSharper.Strings||{};
 Docs$1=Client$1.Docs=Client$1.Docs||{};
 RunState=Docs$1.RunState=Docs$1.RunState||{};
 NodeSet=Docs$1.NodeSet=Docs$1.NodeSet||{};
 Anims=UI.Anims=UI.Anims||{};
 SC$4=Global.StartupCode$WebSharper_UI$Doc_Proxy=Global.StartupCode$WebSharper_UI$Doc_Proxy||{};
 Fresh=Abbrev.Fresh=Abbrev.Fresh||{};
 SC$5=Global.StartupCode$WebSharper_UI$Attr_Client=Global.StartupCode$WebSharper_UI$Attr_Client||{};
 SC$6=Global.StartupCode$WebSharper_UI$DomUtility=Global.StartupCode$WebSharper_UI$DomUtility||{};
 SC$7=Global.StartupCode$WebSharper_UI$Animation=Global.StartupCode$WebSharper_UI$Animation||{};
 AppendList=UI.AppendList=UI.AppendList||{};
 HashSetUtil=Collections.HashSetUtil=Collections.HashSetUtil||{};
 Var=UI.Var=UI.Var||{};
 BindVar=UI.BindVar=UI.BindVar||{};
 String=UI.String=UI.String||{};
 CheckedInput=UI.CheckedInput=UI.CheckedInput||{};
 Easing=UI.Easing=UI.Easing||{};
 HashSet$1=Abbrev.HashSet=Abbrev.HashSet||{};
 SC$8=Global.StartupCode$WebSharper_UI$Abbrev=Global.StartupCode$WebSharper_UI$Abbrev||{};
 Char=WebSharper.Char=WebSharper.Char||{};
 DomNodes=Docs$1.DomNodes=Docs$1.DomNodes||{};
 Lazy=WebSharper.Lazy=WebSharper.Lazy||{};
 SC$9=Global.StartupCode$WebSharper_UI$AppendList=Global.StartupCode$WebSharper_UI$AppendList||{};
 Queue=WebSharper.Queue=WebSharper.Queue||{};
 LazyExtensionsProxy=WebSharper.LazyExtensionsProxy=WebSharper.LazyExtensionsProxy||{};
 LazyRecord=LazyExtensionsProxy.LazyRecord=LazyExtensionsProxy.LazyRecord||{};
 Plotly$1=Global.Plotly;
 Runtime=WebSharper&&WebSharper.Runtime;
 console=Global.console;
 Date=Global.Date;
 Client.Main=function()
 {
  var _;
  _=Doc.Element("div",[AttrModule.OnAfterRender(function()
  {
   var _$1;
   List.iter(function(x)
   {
    x();
   },List.ofArray([Client.scatterChart,Client.pieChart,Client.barChart,Client.heatMapChart,Client.tableChart,Client.contourChart,Client.imageChart,Client.boxChart,Client.hgChart,Client.hg2dChart,Client.hg2dContChart,Client.violinChart,Client.candleStickChart,Client.funnelChart,Client.funnelAreaChart,Client.indicatorChart,Client.ohlcChart,Client.waterfallChart,Client.choroplethChart,Client.scatterGeoChart,Client.carpetChart,Client.isoSurfaceChart,Client.ccarpetChart,Client.parcatsChart,Client.sankeyChart,Client.scarpetChart,Client.spolarChart,Client.sternaryChart,Client.sunBurstChart,Client.treeMapChart,Client.icicleChart,Client.barpolarChart]));
   Concurrency.Start((_$1=null,Concurrency.Delay(function()
   {
    return Concurrency.Bind(Concurrency.Sequential(List.map(function(renderer)
    {
     var _$2;
     _$2=null;
     return Concurrency.Delay(function()
     {
      renderer();
      return Concurrency.Bind(Concurrency.Sleep(1000),function()
      {
       return Concurrency.Return(null);
      });
     });
    },List.ofArray([Client.scatterGLChart,Client.spolarglChart,Client.heatMapGLChart,Client.splomChart,Client.parcoordsChart,Client.scatter3DChart,Client.surfaceChart,Client.streamTubeChart,Client.meshChart,Client.coneChart,Client.scatterMBChart,Client.choroplethMBChart,Client.densityMBChart]))),function()
    {
     return Concurrency.Zero();
    });
   })),null);
  })],[Doc.Element("h1",[],[Doc.TextNode("Plotly Js sample site")]),Doc.Element("h2",[],[Doc.TextNode("Scatter chart")]),Doc.Element("div",[AttrProxy.Create("id","scatterchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("ScatterGL chart")]),Doc.Element("div",[AttrProxy.Create("id","scatterglchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Pie chart")]),Doc.Element("div",[AttrProxy.Create("id","piechartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Bar chart")]),Doc.Element("div",[AttrProxy.Create("id","barchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Heatmap chart")]),Doc.Element("div",[AttrProxy.Create("id","heatmapchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Table chart")]),Doc.Element("div",[AttrProxy.Create("id","tablechartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("HeatMapGL chart")]),Doc.Element("div",[AttrProxy.Create("id","heatmapglchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Contour chart")]),Doc.Element("div",[AttrProxy.Create("id","contourchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Image chart")]),Doc.Element("div",[AttrProxy.Create("id","imagechartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Box chart")]),Doc.Element("div",[AttrProxy.Create("id","boxchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Histogram chart")]),Doc.Element("div",[AttrProxy.Create("id","hgchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Histogram2D chart")]),Doc.Element("div",[AttrProxy.Create("id","hg2dchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Histogram2DContour chart")]),Doc.Element("div",[AttrProxy.Create("id","hg2dcontchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Violin chart")]),Doc.Element("div",[AttrProxy.Create("id","violinchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("CandleStick chart")]),Doc.Element("div",[AttrProxy.Create("id","candlestickchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Funnel chart")]),Doc.Element("div",[AttrProxy.Create("id","funnelchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("FunnelArea chart")]),Doc.Element("div",[AttrProxy.Create("id","funnelareachartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Indicator chart")]),Doc.Element("div",[AttrProxy.Create("id","indicatorchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("OHLC chart")]),Doc.Element("div",[AttrProxy.Create("id","ohlcchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Waterfall chart")]),Doc.Element("div",[AttrProxy.Create("id","waterfallchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Choropleth chart")]),Doc.Element("div",[AttrProxy.Create("id","choroplethchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("ChoroplethMB chart")]),Doc.Element("div",[AttrProxy.Create("id","choroplethmbchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("DensityMB chart")]),Doc.Element("div",[AttrProxy.Create("id","densitymbchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("ScatterGeo chart")]),Doc.Element("div",[AttrProxy.Create("id","scattergeochartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("ScatterMB chart")]),Doc.Element("div",[AttrProxy.Create("id","scattermbchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Cone chart")]),Doc.Element("div",[AttrProxy.Create("id","conechartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Carpet chart")]),Doc.Element("div",[AttrProxy.Create("id","carpetchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("ISOSurface chart")]),Doc.Element("div",[AttrProxy.Create("id","isochartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Mesh chart")]),Doc.Element("div",[AttrProxy.Create("id","meshchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Scatter3D chart")]),Doc.Element("div",[AttrProxy.Create("id","scatter3dchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("StreamTube chart")]),Doc.Element("div",[AttrProxy.Create("id","streamtubechartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Surface chart")]),Doc.Element("div",[AttrProxy.Create("id","surfacechartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("ContourCarpet chart")]),Doc.Element("div",[AttrProxy.Create("id","ccarpetchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Parallel Categories chart")]),Doc.Element("div",[AttrProxy.Create("id","parcatschartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Parallel Coordinates chart")]),Doc.Element("div",[AttrProxy.Create("id","parcoordschartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Sankey chart")]),Doc.Element("div",[AttrProxy.Create("id","sankeychartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("ScatterCarpet chart")]),Doc.Element("div",[AttrProxy.Create("id","scarpetchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("ScatterPolar chart")]),Doc.Element("div",[AttrProxy.Create("id","spolarchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("ScatterPolarGL chart")]),Doc.Element("div",[AttrProxy.Create("id","spolarglchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("ScatterTernary chart")]),Doc.Element("div",[AttrProxy.Create("id","sternarychartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Splom chart")]),Doc.Element("div",[AttrProxy.Create("id","splomchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("SunBurst chart")]),Doc.Element("div",[AttrProxy.Create("id","sunburstchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("TreeMap chart")]),Doc.Element("div",[AttrProxy.Create("id","treemapchartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Icicle chart")]),Doc.Element("div",[AttrProxy.Create("id","iciclechartDiv")],[]),Doc.Element("h2",[],[Doc.TextNode("Bar Polar chart")]),Doc.Element("div",[AttrProxy.Create("id","barpolarchartDiv")],[])]);
  Templates.LoadLocalTemplates("");
  Doc.RunById("main",_);
 };
 Client.scatterChart=function()
 {
  return Plotly$1.newPlot("scatterchartDiv",[Client.scatterTrace()],null,Client.option1());
 };
 Client.pieChart=function()
 {
  return Plotly$1.newPlot("piechartDiv",[Client.pieTrace()]);
 };
 Client.barChart=function()
 {
  return Plotly$1.newPlot("barchartDiv",[Client.barTrace()]);
 };
 Client.heatMapChart=function()
 {
  return Plotly$1.newPlot("heatmapchartDiv",[Client.heatmap()]);
 };
 Client.tableChart=function()
 {
  return Plotly$1.newPlot("tablechartDiv",[Client.table()]);
 };
 Client.contourChart=function()
 {
  return Plotly$1.newPlot("contourchartDiv",[Client.contour()]);
 };
 Client.imageChart=function()
 {
  return Plotly$1.newPlot("imagechartDiv",[Client.image()],Client.imageLayout());
 };
 Client.boxChart=function()
 {
  return Plotly$1.newPlot("boxchartDiv",[Client.box()]);
 };
 Client.hgChart=function()
 {
  return Plotly$1.newPlot("hgchartDiv",[Client.histogram()]);
 };
 Client.hg2dChart=function()
 {
  return Plotly$1.newPlot("hg2dchartDiv",[Client.histogram2d()]);
 };
 Client.hg2dContChart=function()
 {
  return Plotly$1.newPlot("hg2dcontchartDiv",[Client.hg2dcontour()]);
 };
 Client.violinChart=function()
 {
  return Plotly$1.newPlot("violinchartDiv",[Client.violin()]);
 };
 Client.candleStickChart=function()
 {
  return Plotly$1.newPlot("candlestickchartDiv",[Client.candlestick()]);
 };
 Client.funnelChart=function()
 {
  return Plotly$1.newPlot("funnelchartDiv",[Client.funnel()]);
 };
 Client.funnelAreaChart=function()
 {
  return Plotly$1.newPlot("funnelareachartDiv",[Client.funnelarea()]);
 };
 Client.indicatorChart=function()
 {
  return Plotly$1.newPlot("indicatorchartDiv",[Client.indicator()],Client.indicatorLayout());
 };
 Client.ohlcChart=function()
 {
  return Plotly$1.newPlot("ohlcchartDiv",[Client.ohlc()],null);
 };
 Client.waterfallChart=function()
 {
  return Plotly$1.newPlot("waterfallchartDiv",[Client.waterfall()],null,null);
 };
 Client.choroplethChart=function()
 {
  return Plotly$1.newPlot("choroplethchartDiv",[Client.choropleth()],null,null);
 };
 Client.scatterGeoChart=function()
 {
  return Plotly$1.newPlot("scattergeochartDiv",[Client.scattergeo()],Client.scatterGeoLayout(),null);
 };
 Client.carpetChart=function()
 {
  return Plotly$1.newPlot("carpetchartDiv",[Client.carpet()]);
 };
 Client.isoSurfaceChart=function()
 {
  return Plotly$1.newPlot("isochartDiv",[Client.isosurface()],null);
 };
 Client.ccarpetChart=function()
 {
  return Plotly$1.newPlot("ccarpetchartDiv",[Client.ccarpet(),Client.contourcarpet()],Client.ccarpetLayout(),null);
 };
 Client.parcatsChart=function()
 {
  return Plotly$1.newPlot("parcatschartDiv",[Client.parcats()]);
 };
 Client.sankeyChart=function()
 {
  return Plotly$1.newPlot("sankeychartDiv",[Client.sankey()]);
 };
 Client.scarpetChart=function()
 {
  return Plotly$1.newPlot("scarpetchartDiv",[Client.scarpet(),Client.scattercarpet()]);
 };
 Client.spolarChart=function()
 {
  return Plotly$1.newPlot("spolarchartDiv",[Client.spolar()]);
 };
 Client.sternaryChart=function()
 {
  return Plotly$1.newPlot("sternarychartDiv",[Client.sternary()],Client.sternaryLayout());
 };
 Client.sunBurstChart=function()
 {
  return Plotly$1.newPlot("sunburstchartDiv",[Client.sunburst()],Client.sunBurstLayout());
 };
 Client.treeMapChart=function()
 {
  return Plotly$1.newPlot("treemapchartDiv",[Client.treemap()]);
 };
 Client.icicleChart=function()
 {
  return Plotly$1.newPlot("iciclechartDiv",[Client.icicle()],Client.icicleLayout());
 };
 Client.barpolarChart=function()
 {
  return Plotly$1.newPlot("barpolarchartDiv",[Client.barpolar1(),Client.barpolar2(),Client.barpolar3(),Client.barpolar4()],Client.barpolarLayout());
 };
 Client.scatterGLChart=function()
 {
  return Plotly$1.newPlot("scatterglchartDiv",[Client.scatterGLTrace()]);
 };
 Client.spolarglChart=function()
 {
  return Plotly$1.newPlot("spolarglchartDiv",[Client.spolargl1(),Client.spolargl2()],null,Client.option2());
 };
 Client.heatMapGLChart=function()
 {
  return Plotly$1.newPlot("heatmapglchartDiv",[Client.heatmapgl()]);
 };
 Client.splomChart=function()
 {
  return Plotly$1.newPlot("splomchartDiv",[Client.splom()],Client.splomLayout(),null);
 };
 Client.parcoordsChart=function()
 {
  return Plotly$1.newPlot("parcoordschartDiv",[Client.parcoords()]);
 };
 Client.scatter3DChart=function()
 {
  return Plotly$1.newPlot("scatter3dchartDiv",[Client.scatter3d()],Client.scatter3DLayout(),null);
 };
 Client.surfaceChart=function()
 {
  return Plotly$1.newPlot("surfacechartDiv",[Client.surface()],Client.surfaceLayout());
 };
 Client.streamTubeChart=function()
 {
  return Plotly$1.newPlot("streamtubechartDiv",[Client.streamtube()],Client.streamTubeLayout());
 };
 Client.meshChart=function()
 {
  return Plotly$1.newPlot("meshchartDiv",[Client.mesh()],null);
 };
 Client.coneChart=function()
 {
  return Plotly$1.newPlot("conechartDiv",[Client.cone()]);
 };
 Client.scatterMBChart=function()
 {
  return Plotly$1.newPlot("scattermbchartDiv",[Client.scattermb()],Client.scatterMBLayout());
 };
 Client.choroplethMBChart=function()
 {
  return Plotly$1.newPlot("choroplethmbchartDiv",[Client.choroplethmb()],Client.choroplethMBLayout(),null);
 };
 Client.densityMBChart=function()
 {
  return Plotly$1.newPlot("densitymbchartDiv",[Client.densitymb()],Client.densityMBLayout());
 };
 Client.scatterTrace=function()
 {
  SC$1.$cctor();
  return SC$1.scatterTrace;
 };
 Client.option1=function()
 {
  SC$1.$cctor();
  return SC$1.option1;
 };
 Client.pieTrace=function()
 {
  SC$1.$cctor();
  return SC$1.pieTrace;
 };
 Client.barTrace=function()
 {
  SC$1.$cctor();
  return SC$1.barTrace;
 };
 Client.heatmap=function()
 {
  SC$1.$cctor();
  return SC$1.heatmap;
 };
 Client.table=function()
 {
  SC$1.$cctor();
  return SC$1.table;
 };
 Client.contour=function()
 {
  SC$1.$cctor();
  return SC$1.contour;
 };
 Client.image=function()
 {
  SC$1.$cctor();
  return SC$1.image;
 };
 Client.imageLayout=function()
 {
  SC$1.$cctor();
  return SC$1.imageLayout;
 };
 Client.box=function()
 {
  SC$1.$cctor();
  return SC$1.box;
 };
 Client.histogram=function()
 {
  SC$1.$cctor();
  return SC$1.histogram;
 };
 Client.histogram2d=function()
 {
  SC$1.$cctor();
  return SC$1.histogram2d;
 };
 Client.hg2dcontour=function()
 {
  SC$1.$cctor();
  return SC$1.hg2dcontour;
 };
 Client.violin=function()
 {
  SC$1.$cctor();
  return SC$1.violin;
 };
 Client.candlestick=function()
 {
  SC$1.$cctor();
  return SC$1.candlestick;
 };
 Client.funnel=function()
 {
  SC$1.$cctor();
  return SC$1.funnel;
 };
 Client.funnelarea=function()
 {
  SC$1.$cctor();
  return SC$1.funnelarea;
 };
 Client.indicator=function()
 {
  SC$1.$cctor();
  return SC$1.indicator;
 };
 Client.indicatorLayout=function()
 {
  SC$1.$cctor();
  return SC$1.indicatorLayout;
 };
 Client.ohlc=function()
 {
  SC$1.$cctor();
  return SC$1.ohlc;
 };
 Client.waterfall=function()
 {
  SC$1.$cctor();
  return SC$1.waterfall;
 };
 Client.choropleth=function()
 {
  SC$1.$cctor();
  return SC$1.choropleth;
 };
 Client.scattergeo=function()
 {
  SC$1.$cctor();
  return SC$1.scattergeo;
 };
 Client.scatterGeoLayout=function()
 {
  SC$1.$cctor();
  return SC$1.scatterGeoLayout;
 };
 Client.carpet=function()
 {
  SC$1.$cctor();
  return SC$1.carpet;
 };
 Client.isosurface=function()
 {
  SC$1.$cctor();
  return SC$1.isosurface;
 };
 Client.ccarpet=function()
 {
  SC$1.$cctor();
  return SC$1.ccarpet;
 };
 Client.contourcarpet=function()
 {
  SC$1.$cctor();
  return SC$1.contourcarpet;
 };
 Client.ccarpetLayout=function()
 {
  SC$1.$cctor();
  return SC$1.ccarpetLayout;
 };
 Client.parcats=function()
 {
  SC$1.$cctor();
  return SC$1.parcats;
 };
 Client.sankey=function()
 {
  SC$1.$cctor();
  return SC$1.sankey;
 };
 Client.scarpet=function()
 {
  SC$1.$cctor();
  return SC$1.scarpet;
 };
 Client.scattercarpet=function()
 {
  SC$1.$cctor();
  return SC$1.scattercarpet;
 };
 Client.spolar=function()
 {
  SC$1.$cctor();
  return SC$1.spolar;
 };
 Client.sternary=function()
 {
  SC$1.$cctor();
  return SC$1.sternary;
 };
 Client.sternaryLayout=function()
 {
  SC$1.$cctor();
  return SC$1.sternaryLayout;
 };
 Client.sunburst=function()
 {
  SC$1.$cctor();
  return SC$1.sunburst;
 };
 Client.sunBurstLayout=function()
 {
  SC$1.$cctor();
  return SC$1.sunBurstLayout;
 };
 Client.treemap=function()
 {
  SC$1.$cctor();
  return SC$1.treemap;
 };
 Client.icicle=function()
 {
  SC$1.$cctor();
  return SC$1.icicle;
 };
 Client.icicleLayout=function()
 {
  SC$1.$cctor();
  return SC$1.icicleLayout;
 };
 Client.barpolar1=function()
 {
  SC$1.$cctor();
  return SC$1.barpolar1;
 };
 Client.barpolar2=function()
 {
  SC$1.$cctor();
  return SC$1.barpolar2;
 };
 Client.barpolar3=function()
 {
  SC$1.$cctor();
  return SC$1.barpolar3;
 };
 Client.barpolar4=function()
 {
  SC$1.$cctor();
  return SC$1.barpolar4;
 };
 Client.barpolarLayout=function()
 {
  SC$1.$cctor();
  return SC$1.barpolarLayout;
 };
 Client.scatterGLTrace=function()
 {
  SC$1.$cctor();
  return SC$1.scatterGLTrace;
 };
 Client.spolargl1=function()
 {
  SC$1.$cctor();
  return SC$1.spolargl1;
 };
 Client.spolargl2=function()
 {
  SC$1.$cctor();
  return SC$1.spolargl2;
 };
 Client.option2=function()
 {
  SC$1.$cctor();
  return SC$1.option2;
 };
 Client.heatmapgl=function()
 {
  SC$1.$cctor();
  return SC$1.heatmapgl;
 };
 Client.splom=function()
 {
  SC$1.$cctor();
  return SC$1.splom;
 };
 Client.splomLayout=function()
 {
  SC$1.$cctor();
  return SC$1.splomLayout;
 };
 Client.parcoords=function()
 {
  SC$1.$cctor();
  return SC$1.parcoords;
 };
 Client.scatter3d=function()
 {
  SC$1.$cctor();
  return SC$1.scatter3d;
 };
 Client.scatter3DLayout=function()
 {
  SC$1.$cctor();
  return SC$1.scatter3DLayout;
 };
 Client.surface=function()
 {
  SC$1.$cctor();
  return SC$1.surface;
 };
 Client.surfaceLayout=function()
 {
  SC$1.$cctor();
  return SC$1.surfaceLayout;
 };
 Client.streamtube=function()
 {
  SC$1.$cctor();
  return SC$1.streamtube;
 };
 Client.streamTubeLayout=function()
 {
  SC$1.$cctor();
  return SC$1.streamTubeLayout;
 };
 Client.mesh=function()
 {
  SC$1.$cctor();
  return SC$1.mesh;
 };
 Client.cone=function()
 {
  SC$1.$cctor();
  return SC$1.cone;
 };
 Client.scattermb=function()
 {
  SC$1.$cctor();
  return SC$1.scattermb;
 };
 Client.scatterMBLayout=function()
 {
  SC$1.$cctor();
  return SC$1.scatterMBLayout;
 };
 Client.choroplethmb=function()
 {
  SC$1.$cctor();
  return SC$1.choroplethmb;
 };
 Client.choroplethMBLayout=function()
 {
  SC$1.$cctor();
  return SC$1.choroplethMBLayout;
 };
 Client.densitymb=function()
 {
  SC$1.$cctor();
  return SC$1.densitymb;
 };
 Client.densityMBLayout=function()
 {
  SC$1.$cctor();
  return SC$1.densityMBLayout;
 };
 Operators.FailWith=function(msg)
 {
  throw new Error(msg);
 };
 Operators.KeyValue=function(kvp)
 {
  return[kvp.K,kvp.V];
 };
 List.ofArray=function(arr)
 {
  var r,i,$1;
  r=T.Empty;
  for(i=Arrays.length(arr)-1,$1=0;i>=$1;i--)r=new T({
   $:1,
   $0:Arrays.get(arr,i),
   $1:r
  });
  return r;
 };
 List.iter=function(f,l)
 {
  var r;
  r=l;
  while(r.$==1)
   {
    f(List.head(r));
    r=List.tail(r);
   }
 };
 List.map=function(f,x)
 {
  var r,l,go,res,t;
  if(x.$==0)
   return x;
  else
   {
    res=new T({
     $:1
    });
    r=res;
    l=x;
    go=true;
    while(go)
     {
      r.$0=f(l.$0);
      l=l.$1;
      if(l.$==0)
       go=false;
      else
       r=(t=new T({
        $:1
       }),r.$1=t,t);
     }
    r.$1=T.Empty;
    return res;
   }
 };
 List.head=function(l)
 {
  return l.$==1?l.$0:List.listEmpty();
 };
 List.tail=function(l)
 {
  return l.$==1?l.$1:List.listEmpty();
 };
 List.listEmpty=function()
 {
  return Operators.FailWith("The input list was empty.");
 };
 Obj=WebSharper.Obj=Runtime.Class({
  Equals:function(obj)
  {
   return this===obj;
  },
  GetHashCode:function()
  {
   return -1;
  }
 },null,Obj);
 Obj.New=Runtime.Ctor(function()
 {
 },Obj);
 attr=HtmlModule.attr=Runtime.Class({},Obj,attr);
 AttrModule.OnAfterRender=function(callback)
 {
  return new AttrProxy({
   $:4,
   $0:callback
  });
 };
 T=List.T=Runtime.Class({
  GetEnumerator:function()
  {
   return new T$1.New(this,null,function(e)
   {
    var m;
    m=e.s;
    return m.$==0?false:(e.c=m.$0,e.s=m.$1,true);
   },void 0);
  }
 },null,T);
 T.Empty=new T({
  $:0
 });
 Arrays.get=function(arr,n)
 {
  Arrays.checkBounds(arr,n);
  return arr[n];
 };
 Arrays.length=function(arr)
 {
  return arr.dims===2?arr.length*arr.length:arr.length;
 };
 Arrays.checkBounds=function(arr,n)
 {
  if(n<0||n>=arr.length)
   Operators.FailWith("Index was outside the bounds of the array.");
 };
 Arrays.set=function(arr,n,x)
 {
  Arrays.checkBounds(arr,n);
  arr[n]=x;
 };
 Unchecked.Equals=function(a,b)
 {
  var m,eqR,k,k$1;
  if(a===b)
   return true;
  else
   {
    m=typeof a;
    if(m=="object")
    {
     if(a===null||a===void 0||b===null||b===void 0||!Unchecked.Equals(typeof b,"object"))
      return false;
     else
      if("Equals"in a)
       return a.Equals(b);
      else
       if("Equals"in b)
        return false;
       else
        if(a instanceof Global.Array&&b instanceof Global.Array)
         return Unchecked.arrayEquals(a,b);
        else
         if(a instanceof Global.Date&&b instanceof Global.Date)
          return Unchecked.dateEquals(a,b);
         else
          {
           eqR=[true];
           for(var k$2 in a)if(function(k$3)
           {
            eqR[0]=!a.hasOwnProperty(k$3)||b.hasOwnProperty(k$3)&&Unchecked.Equals(a[k$3],b[k$3]);
            return!eqR[0];
           }(k$2))
            break;
           if(eqR[0])
            {
             for(var k$3 in b)if(function(k$4)
             {
              eqR[0]=!b.hasOwnProperty(k$4)||a.hasOwnProperty(k$4);
              return!eqR[0];
             }(k$3))
              break;
            }
           return eqR[0];
          }
    }
    else
     return m=="function"&&("$Func"in a?a.$Func===b.$Func&&a.$Target===b.$Target:"$Invokes"in a&&"$Invokes"in b&&Unchecked.arrayEquals(a.$Invokes,b.$Invokes));
   }
 };
 Unchecked.arrayEquals=function(a,b)
 {
  var eq,i;
  if(Arrays.length(a)===Arrays.length(b))
   {
    eq=true;
    i=0;
    while(eq&&i<Arrays.length(a))
     {
      !Unchecked.Equals(Arrays.get(a,i),Arrays.get(b,i))?eq=false:void 0;
      i=i+1;
     }
    return eq;
   }
  else
   return false;
 };
 Unchecked.dateEquals=function(a,b)
 {
  return a.getTime()===b.getTime();
 };
 Unchecked.Hash=function(o)
 {
  var m;
  m=typeof o;
  return m=="function"?0:m=="boolean"?o?1:0:m=="number"?o:m=="string"?Unchecked.hashString(o):m=="object"?o==null?0:o instanceof Global.Array?Unchecked.hashArray(o):Unchecked.hashObject(o):0;
 };
 Unchecked.hashString=function(s)
 {
  var hash,i,$1;
  if(s===null)
   return 0;
  else
   {
    hash=5381;
    for(i=0,$1=s.length-1;i<=$1;i++)hash=Unchecked.hashMix(hash,s[i].charCodeAt());
    return hash;
   }
 };
 Unchecked.hashArray=function(o)
 {
  var h,i,$1;
  h=-34948909;
  for(i=0,$1=Arrays.length(o)-1;i<=$1;i++)h=Unchecked.hashMix(h,Unchecked.Hash(Arrays.get(o,i)));
  return h;
 };
 Unchecked.hashObject=function(o)
 {
  var h,k;
  if("GetHashCode"in o)
   return o.GetHashCode();
  else
   {
    h=[0];
    for(var k$1 in o)if(function(key)
    {
     h[0]=Unchecked.hashMix(Unchecked.hashMix(h[0],Unchecked.hashString(key)),Unchecked.Hash(o[key]));
     return false;
    }(k$1))
     break;
    return h[0];
   }
 };
 Unchecked.hashMix=function(x,y)
 {
  return(x<<5)+x+y;
 };
 Unchecked.Compare=function(a,b)
 {
  var $1,m,$2,cmp,k,k$1;
  if(a===b)
   return 0;
  else
   {
    m=typeof a;
    switch(m=="function"?1:m=="boolean"?2:m=="number"?2:m=="string"?2:m=="object"?3:0)
    {
     case 0:
      return typeof b=="undefined"?0:-1;
     case 1:
      return Operators.FailWith("Cannot compare function values.");
     case 2:
      return a<b?-1:1;
     case 3:
      if(a===null)
       $2=-1;
      else
       if(b===null)
        $2=1;
       else
        if("CompareTo"in a)
         $2=a.CompareTo(b);
        else
         if("CompareTo0"in a)
          $2=a.CompareTo0(b);
         else
          if(a instanceof Global.Array&&b instanceof Global.Array)
           $2=Unchecked.compareArrays(a,b);
          else
           if(a instanceof Global.Date&&b instanceof Global.Date)
            $2=Unchecked.compareDates(a,b);
           else
            {
             cmp=[0];
             for(var k$2 in a)if(function(k$3)
             {
              return!a.hasOwnProperty(k$3)?false:!b.hasOwnProperty(k$3)?(cmp[0]=1,true):(cmp[0]=Unchecked.Compare(a[k$3],b[k$3]),cmp[0]!==0);
             }(k$2))
              break;
             if(cmp[0]===0)
              {
               for(var k$3 in b)if(function(k$4)
               {
                return!b.hasOwnProperty(k$4)?false:!a.hasOwnProperty(k$4)&&(cmp[0]=-1,true);
               }(k$3))
                break;
              }
             $2=cmp[0];
            }
      return $2;
    }
   }
 };
 Unchecked.compareArrays=function(a,b)
 {
  var cmp,i;
  if(Arrays.length(a)<Arrays.length(b))
   return -1;
  else
   if(Arrays.length(a)>Arrays.length(b))
    return 1;
   else
    {
     cmp=0;
     i=0;
     while(cmp===0&&i<Arrays.length(a))
      {
       cmp=Unchecked.Compare(Arrays.get(a,i),Arrays.get(b,i));
       i=i+1;
      }
     return cmp;
    }
 };
 Unchecked.compareDates=function(a,b)
 {
  return Unchecked.Compare(a.getTime(),b.getTime());
 };
 Pervasives.NewFromSeq=function(fields)
 {
  var r,e,f;
  r={};
  e=Enumerator.Get(fields);
  try
  {
   while(e.MoveNext())
    {
     f=e.Current();
     r[f[0]]=f[1];
    }
  }
  finally
  {
   if(typeof e=="object"&&"Dispose"in e)
    e.Dispose();
  }
  return r;
 };
 Concurrency.Delay=function(mk)
 {
  return function(c)
  {
   try
   {
    (mk(null))(c);
   }
   catch(e)
   {
    c.k({
     $:1,
     $0:e
    });
   }
  };
 };
 Concurrency.Bind=function(r,f)
 {
  return Concurrency.checkCancel(function(c)
  {
   r(AsyncBody.New(function(a)
   {
    var x;
    if(a.$==0)
     {
      x=a.$0;
      Concurrency.scheduler().Fork(function()
      {
       try
       {
        (f(x))(c);
       }
       catch(e)
       {
        c.k({
         $:1,
         $0:e
        });
       }
      });
     }
    else
     Concurrency.scheduler().Fork(function()
     {
      c.k(a);
     });
   },c.ct));
  });
 };
 Concurrency.Sleep=function(ms)
 {
  return function(c)
  {
   var pending,creg;
   pending=void 0;
   creg=void 0;
   pending=Global.setTimeout(function()
   {
    creg.Dispose();
    Concurrency.scheduler().Fork(function()
    {
     c.k({
      $:0,
      $0:null
     });
    });
   },ms);
   creg=Concurrency.Register(c.ct,function()
   {
    Global.clearTimeout(pending);
    Concurrency.scheduler().Fork(function()
    {
     Concurrency.cancel(c);
    });
   });
  };
 };
 Concurrency.Return=function(x)
 {
  return function(c)
  {
   c.k({
    $:0,
    $0:x
   });
  };
 };
 Concurrency.Sequential=function(cs)
 {
  var cs$1;
  cs$1=Arrays.ofSeq(cs);
  return Arrays.length(cs$1)===0?Concurrency.Return([]):function(c)
  {
   var n,a;
   function start(i)
   {
    var action;
    while(true)
     {
      action=function(i$1)
      {
       return function()
       {
        (Arrays.get(cs$1,i$1))(AsyncBody.New(function($1)
        {
         return accept(i$1,$1);
        },c.ct));
       };
      }(i);
      return Concurrency.scheduler().Fork(action);
     }
   }
   function accept(i,x)
   {
    return x.$==0?(Arrays.set(a,i,x.$0),i===n-1?c.k({
     $:0,
     $0:a
    }):c.ct.c?Concurrency.cancel(c):start(i+1)):c.k(x);
   }
   n=cs$1.length;
   a=new Global.Array(n);
   start(0);
  };
 };
 Concurrency.Zero=function()
 {
  SC$2.$cctor();
  return SC$2.Zero;
 };
 Concurrency.Start=function(c,ctOpt)
 {
  var ct,d;
  ct=(d=(Concurrency.defCTS())[0],ctOpt==null?d:ctOpt.$0);
  Concurrency.scheduler().Fork(function()
  {
   if(!ct.c)
    c(AsyncBody.New(function(a)
    {
     if(a.$==1)
      Concurrency.UncaughtAsyncError(a.$0);
    },ct));
  });
 };
 Concurrency.checkCancel=function(r)
 {
  return function(c)
  {
   if(c.ct.c)
    Concurrency.cancel(c);
   else
    r(c);
  };
 };
 Concurrency.Register=function(ct,callback)
 {
  var i;
  return ct===Concurrency.noneCT()?{
   Dispose:function()
   {
    return null;
   }
  }:(i=ct.r.push(callback)-1,{
   Dispose:function()
   {
    return Arrays.set(ct.r,i,Global.ignore);
   }
  });
 };
 Concurrency.cancel=function(c)
 {
  c.k({
   $:2,
   $0:new OperationCanceledException.New(c.ct)
  });
 };
 Concurrency.defCTS=function()
 {
  SC$2.$cctor();
  return SC$2.defCTS;
 };
 Concurrency.UncaughtAsyncError=function(e)
 {
  console.log("WebSharper: Uncaught asynchronous exception",e);
 };
 Concurrency.scheduler=function()
 {
  SC$2.$cctor();
  return SC$2.scheduler;
 };
 Concurrency.noneCT=function()
 {
  SC$2.$cctor();
  return SC$2.noneCT;
 };
 Concurrency.FromContinuations=function(subscribe)
 {
  return function(c)
  {
   var continued;
   function once(cont)
   {
    if(continued[0])
     Operators.FailWith("A continuation provided by Async.FromContinuations was invoked multiple times");
    else
     {
      continued[0]=true;
      Concurrency.scheduler().Fork(cont);
     }
   }
   continued=[false];
   subscribe(function(a)
   {
    once(function()
    {
     c.k({
      $:0,
      $0:a
     });
    });
   },function(e)
   {
    once(function()
    {
     c.k({
      $:1,
      $0:e
     });
    });
   },function(e)
   {
    once(function()
    {
     c.k({
      $:2,
      $0:e
     });
    });
   });
  };
 };
 Doc=UI.Doc=Runtime.Class({},Obj,Doc);
 Doc.TextNode=function(v)
 {
  return Doc.Mk({
   $:5,
   $0:self.document.createTextNode(v)
  },View.Const());
 };
 Doc.RunById=function(id,tr)
 {
  var m;
  m=self.document.getElementById(id);
  if(Unchecked.Equals(m,null))
   Operators.FailWith("invalid id: "+id);
  else
   Doc.Run(m,tr);
 };
 Doc.Element=function(name,attr$1,children)
 {
  var a,a$1;
  a=AttrProxy.Concat(attr$1);
  a$1=Doc.Concat(children);
  return Elt.New(self.document.createElement(name),a,a$1);
 };
 Doc.Mk=function(node,updates)
 {
  return new Doc.New(node,updates);
 };
 Doc.Run=function(parent,doc)
 {
  Docs.LinkElement(parent,doc.docNode);
  Doc.RunInPlace(false,parent,doc);
 };
 Doc.Concat=function(xs)
 {
  var x;
  x=Array.ofSeqNonCopying(xs);
  return Array.TreeReduce(Doc.get_Empty(),Doc.Append,x);
 };
 Doc.RunInPlace=function(childrenOnly,parent,doc)
 {
  var st;
  st=Docs.CreateRunState(parent,doc.docNode);
  View.Sink(An.get_UseAnimations()||Settings.BatchUpdatesEnabled()?Mailbox.StartProcessor(Docs.PerformAnimatedUpdate(childrenOnly,st,doc.docNode)):function()
  {
   Docs.PerformSyncUpdate(childrenOnly,st,doc.docNode);
  },doc.updates);
 };
 Doc.Append=function(a,b)
 {
  return Doc.Mk({
   $:0,
   $0:a.docNode,
   $1:b.docNode
  },View.Map2Unit(a.updates,b.updates));
 };
 Doc.get_Empty=function()
 {
  return Doc.Mk(null,View.Const());
 };
 Doc.New=Runtime.Ctor(function(docNode,updates)
 {
  Obj.New.call(this);
  this.docNode=docNode;
  this.updates=updates;
 },Doc);
 AttrProxy=UI.AttrProxy=Runtime.Class({},null,AttrProxy);
 AttrProxy.Create=function(name,value)
 {
  return Attrs.Static(function(el)
  {
   el.setAttribute(name,value);
  });
 };
 AttrProxy.Concat=function(xs)
 {
  var x;
  x=Array.ofSeqNonCopying(xs);
  return Array.TreeReduce(Attrs.EmptyAttr(),AttrProxy.Append,x);
 };
 AttrProxy.Append=function(a,b)
 {
  return Attrs.AppendTree(a,b);
 };
 Templates.LoadLocalTemplates=function(baseName)
 {
  !Templates.LocalTemplatesLoaded()?(Templates.set_LocalTemplatesLoaded(true),Templates.LoadNestedTemplates(self.document.body,"")):void 0;
  Templates.LoadedTemplates().set_Item(baseName,Templates.LoadedTemplateFile(""));
 };
 Templates.LocalTemplatesLoaded=function()
 {
  SC$3.$cctor();
  return SC$3.LocalTemplatesLoaded;
 };
 Templates.set_LocalTemplatesLoaded=function($1)
 {
  SC$3.$cctor();
  SC$3.LocalTemplatesLoaded=$1;
 };
 Templates.LoadNestedTemplates=function(root,baseName)
 {
  var loadedTpls,rawTpls,wsTemplates,i,$1,node,name,wsChildrenTemplates,i$1,$2,node$1,name$1,instantiated;
  function prepareTemplate(name$2)
  {
   var m,o;
   if(!loadedTpls.ContainsKey(name$2))
    {
     m=(o=null,[rawTpls.TryGetValue(name$2,{
      get:function()
      {
       return o;
      },
      set:function(v)
      {
       o=v;
      }
     }),o]);
     if(m[0])
      {
       instantiated.SAdd(name$2);
       rawTpls.RemoveKey(name$2);
       Templates.PrepareTemplateStrict(baseName,{
        $:1,
        $0:name$2
       },m[1],{
        $:1,
        $0:prepareTemplate
       });
      }
     else
      console.warn(instantiated.Contains(name$2)?"Encountered loop when instantiating "+name$2:"Local template does not exist: "+name$2);
    }
  }
  loadedTpls=Templates.LoadedTemplateFile(baseName);
  rawTpls=new Dictionary.New$5();
  wsTemplates=root.querySelectorAll("[ws-template]");
  for(i=0,$1=wsTemplates.length-1;i<=$1;i++){
   node=wsTemplates[i];
   name=node.getAttribute("ws-template").toLowerCase();
   node.removeAttribute("ws-template");
   rawTpls.set_Item(name,Templates.FakeRootSingle(node));
  }
  wsChildrenTemplates=root.querySelectorAll("[ws-children-template]");
  for(i$1=0,$2=wsChildrenTemplates.length-1;i$1<=$2;i$1++){
   node$1=wsChildrenTemplates[i$1];
   name$1=node$1.getAttribute("ws-children-template").toLowerCase();
   node$1.removeAttribute("ws-children-template");
   rawTpls.set_Item(name$1,Templates.FakeRoot(node$1));
  }
  instantiated=new HashSet.New$3();
  while(rawTpls.count>0)
   prepareTemplate(Seq.head(rawTpls.Keys()));
 };
 Templates.LoadedTemplates=function()
 {
  SC$3.$cctor();
  return SC$3.LoadedTemplates;
 };
 Templates.LoadedTemplateFile=function(name)
 {
  var m,o,d;
  m=(o=null,[Templates.LoadedTemplates().TryGetValue(name,{
   get:function()
   {
    return o;
   },
   set:function(v)
   {
    o=v;
   }
  }),o]);
  return m[0]?m[1]:(d=new Dictionary.New$5(),(Templates.LoadedTemplates().set_Item(name,d),d));
 };
 Templates.FakeRootSingle=function(el)
 {
  var m,m$1,n,fakeroot;
  el.removeAttribute("ws-template");
  m=el.getAttribute("ws-replace");
  if(m===null)
   ;
  else
   {
    el.removeAttribute("ws-replace");
    m$1=el.parentNode;
    Unchecked.Equals(m$1,null)?void 0:(n=self.document.createElement(el.tagName),n.setAttribute("ws-replace",m),m$1.replaceChild(n,el));
   }
  fakeroot=self.document.createElement("div");
  fakeroot.appendChild(el);
  return fakeroot;
 };
 Templates.FakeRoot=function(parent)
 {
  var fakeroot;
  fakeroot=self.document.createElement("div");
  while(parent.hasChildNodes())
   fakeroot.appendChild(parent.firstChild);
  return fakeroot;
 };
 Templates.PrepareTemplateStrict=function(baseName,name,fakeroot,prepareLocalTemplate)
 {
  var name$1;
  function recF(recI,$1)
  {
   var next,m,$2,x,f,name$2,p,instName,instBaseName,d,t,instance,usedHoles,mappings,attrs,i,$3,name$3,m$1,i$1,$4,n,singleTextFill,i$2,$5,n$1;
   function g(v)
   {
   }
   while(true)
    switch(recI)
    {
     case 0:
      if($1!==null)
       {
        next=$1.nextSibling;
        if(Unchecked.Equals($1.nodeType,Node.TEXT_NODE))
         Prepare.convertTextNode($1);
        else
         if(Unchecked.Equals($1.nodeType,Node.ELEMENT_NODE))
          convertElement($1);
        $1=next;
       }
      else
       return null;
      break;
     case 1:
      name$2=Slice.string($1.nodeName,{
       $:1,
       $0:3
      },null).toLowerCase();
      p=(m=name$2.indexOf("."),m===-1?[baseName,name$2]:[Slice.string(name$2,null,{
       $:1,
       $0:m-1
      }),Slice.string(name$2,{
       $:1,
       $0:m+1
      },null)]);
      instName=p[1];
      instBaseName=p[0];
      if(instBaseName!==""&&!Templates.LoadedTemplates().ContainsKey(instBaseName))
       return Prepare.failNotLoaded(instName);
      else
       {
        if(instBaseName===""&&prepareLocalTemplate!=null)
         prepareLocalTemplate.$0(instName);
        d=Templates.LoadedTemplates().Item(instBaseName);
        if(!d.ContainsKey(instName))
         return Prepare.failNotLoaded(instName);
        else
         {
          t=d.Item(instName);
          instance=t.cloneNode(true);
          usedHoles=new HashSet.New$3();
          mappings=new Dictionary.New$5();
          attrs=$1.attributes;
          for(i=0,$3=attrs.length-1;i<=$3;i++){
           name$3=attrs.item(i).name.toLowerCase();
           mappings.set_Item(name$3,(m$1=attrs.item(i).nodeValue,m$1===""?name$3:m$1.toLowerCase()));
           if(!usedHoles.SAdd(name$3))
            console.warn("Hole mapped twice",name$3);
          }
          for(i$1=0,$4=$1.childNodes.length-1;i$1<=$4;i$1++){
           n=$1.childNodes[i$1];
           if(Unchecked.Equals(n.nodeType,Node.ELEMENT_NODE))
            !usedHoles.SAdd(n.nodeName.toLowerCase())?console.warn("Hole filled twice",instName):void 0;
          }
          singleTextFill=$1.childNodes.length===1&&Unchecked.Equals($1.firstChild.nodeType,Node.TEXT_NODE);
          if(singleTextFill)
           {
            x=Prepare.fillTextHole(instance,$1.firstChild.textContent,instName);
            ((function(a)
            {
             return function(o)
             {
              if(o!=null)
               a(o.$0);
             };
            }((f=function(usedHoles$1)
            {
             return function(a)
             {
              return usedHoles$1.SAdd(a);
             };
            }(usedHoles),function(x$1)
            {
             return g(f(x$1));
            })))(x));
           }
          Prepare.removeHolesExcept(instance,usedHoles);
          if(!singleTextFill)
           {
            for(i$2=0,$5=$1.childNodes.length-1;i$2<=$5;i$2++){
             n$1=$1.childNodes[i$2];
             if(Unchecked.Equals(n$1.nodeType,Node.ELEMENT_NODE))
              n$1.hasAttributes()?Prepare.fillInstanceAttrs(instance,n$1):fillDocHole(instance,n$1);
            }
           }
          Prepare.mapHoles(instance,mappings);
          Prepare.fill(instance,$1.parentNode,$1);
          $1.parentNode.removeChild($1);
          return;
         }
       }
      break;
    }
  }
  function fillDocHole(instance,fillWith)
  {
   var m,name$2,m$1;
   function fillHole(p,n)
   {
    var parsed;
    if(name$2==="title"&&fillWith.hasChildNodes())
     {
      parsed=DomUtility.ParseHTMLIntoFakeRoot(fillWith.textContent);
      fillWith.removeChild(fillWith.firstChild);
      while(parsed.hasChildNodes())
       fillWith.appendChild(parsed.firstChild);
     }
    else
     null;
    convertElement(fillWith);
    return Prepare.fill(fillWith,p,n);
   }
   name$2=fillWith.nodeName.toLowerCase();
   Templates.foreachNotPreserved(instance,"[ws-attr-holes]",function(e)
   {
    var holeAttrs,i,$1,attrName,_this;
    holeAttrs=Strings.SplitChars(e.getAttribute("ws-attr-holes"),[" "],1);
    for(i=0,$1=holeAttrs.length-1;i<=$1;i++){
     attrName=Arrays.get(holeAttrs,i);
     e.setAttribute(attrName,(_this=new Global.RegExp("\\${"+name$2+"}","ig"),e.getAttribute(attrName).replace(_this,fillWith.textContent)));
    }
   });
   m$1=instance.querySelector("[ws-hole="+name$2+"]");
   if(Unchecked.Equals(m$1,null))
    {
     m=instance.querySelector("[ws-replace="+name$2+"]");
     return Unchecked.Equals(m,null)?null:(fillHole(m.parentNode,m),void m.parentNode.removeChild(m));
    }
   else
    {
     while(m$1.hasChildNodes())
      m$1.removeChild(m$1.lastChild);
     m$1.removeAttribute("ws-hole");
     return fillHole(m$1,null);
    }
  }
  function convertElement(el)
  {
   if(!el.hasAttribute("ws-preserve"))
    if(Strings.StartsWith(el.nodeName.toLowerCase(),"ws-"))
     convertInstantiation(el);
    else
     {
      Prepare.convertAttrs(el);
      convertNodeAndSiblings(el.firstChild);
     }
  }
  function convertNodeAndSiblings(n)
  {
   return recF(0,n);
  }
  function convertInstantiation(el)
  {
   return recF(1,el);
  }
  function convertNestedTemplates(el)
  {
   var m,m$1,name$2,name$3;
   while(true)
    {
     m=el.querySelector("[ws-template]");
     if(Unchecked.Equals(m,null))
      {
       m$1=el.querySelector("[ws-children-template]");
       if(Unchecked.Equals(m$1,null))
        return null;
       else
        {
         name$2=m$1.getAttribute("ws-children-template");
         m$1.removeAttribute("ws-children-template");
         Templates.PrepareTemplateStrict(baseName,{
          $:1,
          $0:name$2
         },m$1,null);
         el=el;
        }
      }
     else
      {
       name$3=m.getAttribute("ws-template");
       (Templates.PrepareSingleTemplate(baseName,{
        $:1,
        $0:name$3
       },m))(null);
       el=el;
      }
    }
  }
  name$1=(name==null?"":name.$0).toLowerCase();
  Templates.LoadedTemplateFile(baseName).set_Item(name$1,fakeroot);
  if(fakeroot.hasChildNodes())
   {
    convertNestedTemplates(fakeroot);
    convertNodeAndSiblings(fakeroot.firstChild);
   }
 };
 Templates.foreachNotPreserved=function(root,selector,f)
 {
  DomUtility.IterSelector(root,selector,function(p)
  {
   if(p.closest("[ws-preserve]")==null)
    f(p);
  });
 };
 Templates.PrepareSingleTemplate=function(baseName,name,el)
 {
  var root;
  root=Templates.FakeRootSingle(el);
  return function(p)
  {
   Templates.PrepareTemplateStrict(baseName,name,root,p);
  };
 };
 Templates.TextHoleRE=function()
 {
  SC$3.$cctor();
  return SC$3.TextHoleRE;
 };
 SC$1.$cctor=function()
 {
  var r,r$1,r$2,r$3,r$4,r$5,r$6,r$7,r$8,r$9,r$10,r$11,r$12,r$13,r$14,r$15,r$16,r$17,r$18,r$19,r$20,r$21,r$22,r$23,r$24,r$25,r$26,r$27,r$28,r$29,r$30,r$31,r$32,r$33,r$34,r$35,r$36,r$37,r$38,r$39,r$40,r$41,r$42,r$43,r$44,r$45,r$46,r$47,r$48,r$49,r$50,r$51,r$52,r$53,r$54,r$55,r$56,r$57,r$58,r$59,r$60,r$61,r$62,r$63,r$64,r$65,r$66,r$67,r$68,r$69,r$70,r$71,r$72,r$73,r$74,r$75,r$76,r$77,r$78,r$79,r$80,r$81,r$82,r$83,r$84,r$85,r$86,r$87,r$88,r$89,r$90,r$91,r$92,r$93,r$94,r$95,r$96,r$97,r$98,r$99,r$100,r$101,r$102,r$103,r$104,r$105,r$106,r$107,r$108,r$109,r$110,r$111,r$112,r$113,r$114,r$115,r$116,r$117,r$118,r$119;
  SC$1.$cctor=Global.ignore;
  SC$1.carpet={
   type:"carpet"
  };
  Client.carpet().a=[4,4,4,4.5,4.5,4.5,5,5,5,6,6,6];
  Client.carpet().b=[1,2,3,1,2,3,1,2,3,1,2,3];
  Client.carpet().y=[2,3.5,4,3,4.5,5,5.5,6.5,7.5,8,8.5,10];
  SC$1.scatterTrace={
   type:"scatter"
  };
  Client.scatterTrace().x=[1,2,3,4];
  Client.scatterTrace().y=[10,15,13,17];
  Client.scatterTrace().mode="lines+markers";
  Client.scatterTrace().showlegend=true;
  SC$1.scatterGLTrace={
   type:"scattergl"
  };
  Client.scatterGLTrace().x=[1,2,3,4];
  Client.scatterGLTrace().y=[10,15,13,17];
  Client.scatterGLTrace().mode="lines+markers";
  SC$1.pieTrace={
   type:"pie"
  };
  Client.pieTrace().values=[19,26,55];
  Client.pieTrace().labels=["Residential","Non-Residential","Utility"];
  SC$1.barTrace={
   type:"bar"
  };
  Client.barTrace().x=["giraffes","orangutans","monkeys"];
  Client.barTrace().y=[20,14,23];
  SC$1.heatmap={
   type:"heatmap"
  };
  Client.heatmap().z=[[1,5,30,50,1],[20,1,60,80,30],[30,60,1,-10,20]];
  Client.heatmap().x=["Monday","Tuesday","Wednesday","Thursday","Friday"];
  Client.heatmap().y=["Morning","Afternoon","Evening"];
  Client.heatmap().hoverongaps=false;
  SC$1.heatmapgl={
   type:"heatmap"
  };
  Client.heatmapgl().z=[[1,5,30,50,1],[20,1,60,80,30],[30,60,1,-10,20]];
  Client.heatmapgl().x=["Monday","Tuesday","Wednesday","Thursday","Friday"];
  Client.heatmapgl().y=["Morning","Afternoon","Evening"];
  SC$1.table={
   type:"table"
  };
  Client.table().columnwidth=[150,150,200,200,150];
  Client.table().columnorder=[0,1,2,3,4];
  Client.table().header=(r={},r.values=[["<b>EXPENSES</b>"],["<b>Q1</b>"],["<b>Q2</b>"],["<b>Q3</b>"],["<b>Q4</b>"]],r.align="center",r.line=(r$1={},r$1.width=1,r$1.color="black",r$1),r.fill=(r$2={},r$2.color="grey",r$2),r.font=(r$3={},r$3.family="Arial",r$3.size=12,r$3.color="white",r$3),r);
  Client.table().cells=(r$4={},r$4.values=[["Salaries","Office","Merchandise","Legal","<b>TOTAL</b>"],[1200000,20000,80000,2000,12120000],[1300000,20000,70000,2000,130902000],[1300000,20000,120000,2000,131222000],[1400000,20000,90000,2000,14102000]],r$4.align="center",r$4.line=(r$5={},r$5.color="black",r$5.width=1,r$5),r$4.font=(r$6={},r$6.family="Arial",r$6.size=11,r$6.color=["black"],r$6),r$4);
  SC$1.contour={
   type:"contour"
  };
  Client.contour().z=[[10,10.625,12.5,15.625,20],[5.625,6.25,8.125,11.25,15.625],[2.5,3.125,5,8.125,12.5],[0.625,1.25,3.125,6.25,10.625],[0,0.625,2.5,5.625,10]];
  SC$1.image={
   type:"image"
  };
  Client.image().z=[[[255,0,0],[0,255,0],[0,0,255]]];
  Client.image().opacity=0.1;
  SC$1.imageLayout={};
  Client.imageLayout().width=400;
  Client.imageLayout().height=400;
  Client.imageLayout().title=(r$7={},r$7.text="Image with opacity 0.1",r$7);
  SC$1.box={
   type:"box"
  };
  Client.box().y=[0,1,1,2,3,5,8,13,21];
  Client.box().boxpoints="all";
  Client.box().jitter=0.3;
  Client.box().pointpos=-1.8;
  SC$1.histogram={
   type:"histogram"
  };
  Client.histogram().x=[1,1,2,3,4,6,4,3,7,9,6,4,3,4,5,7,5];
  SC$1.histogram2d={
   type:"histogram2d"
  };
  Client.histogram2d().x=[1,1,2,3,4,6,4,3,7,9,6,4,3,4,5,7,5];
  Client.histogram2d().y=[1,1,2,3,4,6,4,3,7,9,6,4,3,4,5,7,5];
  SC$1.hg2dcontour={
   type:"histogram2dcontour"
  };
  Client.hg2dcontour().x=[2,3,4,2,1,3,5,7,9,7,6,6,4,5,6,7,8,9,4,5,3,10,2,4,5,7,5,3,3,3,4];
  Client.hg2dcontour().y=[8,9,4,5,3,3,2,4,2,3,4,2,1,3,5,7,9,7,6,7,4,5,6,7,5,7,5,3,3,3,4];
  SC$1.violin={
   type:"violin"
  };
  Client.violin().y=[34,52,34,42,345,665,34,23,54,436,65,34,235,654,345];
  Client.violin().points="none";
  Client.violin().box=(r$8={},r$8.visible=true,r$8);
  Client.violin().points=false;
  Client.violin().line=(r$9={},r$9.color="black",r$9);
  Client.violin().fillcolor="black";
  Client.violin().opacity=0.6;
  Client.violin().meanline=(r$10={},r$10.visible=true,r$10);
  Client.violin().x0="Total Bill";
  SC$1.candlestick={
   type:"candlestick"
  };
  Client.candlestick().x=["2017-01-04","2017-01-05","2017-01-06","2017-01-09","2017-01-10","2017-01-11","2017-01-12","2017-01-13","2017-01-17","2017-01-18","2017-01-19","2017-01-20","2017-01-23","2017-01-24","2017-01-25","2017-02-02","2017-02-03","2017-02-04","2017-02-07"];
  Client.candlestick().close=[116.019997,116.610001,117.910004,118.989998,119.110001,119.75,119.25,119.040001,120,119.989998,119.779999,120,120.080002,119.970001,121.879997,121.940002,121.949997,121.629997,121.349998];
  Client.candlestick().decreasing=(r$11={},r$11.line=(r$12={},r$12.color="#7F7F7F",r$12),r$11);
  Client.candlestick().high=[116.510002,116.860001,118.160004,119.43,119.379997,119.93,119.300003,119.620003,120.239998,120.5,120.089996,120.449997,120.809998,120.099998,122.099998,122.440002,122.349998,121.629997,121.389999];
  Client.candlestick().increasing=(r$13={},r$13.line=(r$14={},r$14.color="#17BECF",r$14),r$13);
  Client.candlestick().line=(r$15={},r$15.color="rgba(31,119,180,1)",r$15);
  Client.candlestick().low=[115.510002,114.860001,115.160004,116.43,117.379997,117.93,117.300003,116.620003,118.239998,117.5,116.089996,117.449997,119.809998,116.099998,120.099998,121.440002,121.349998,120.629997,120.389999];
  Client.candlestick().open=[116.810002,116.960001,118.460004,119.93,119.779997,119.93,119.700003,119.720003,120.339998,120.65,120.689996,120.749997,120.909998,120.299998,122.399998,122.540002,122.849998,121.829997,121.589999];
  Client.candlestick().xaxis="x";
  Client.candlestick().yaxis="y";
  SC$1.funnel={
   type:"funnel"
  };
  Client.funnel().y=["Website visit","Downloads","Potential customers","Invoice sent","Closed delas"];
  Client.funnel().x=[13873,10533,5443,2703,908];
  Client.funnel().hoverinfo="x+percent previous+percent initial";
  SC$1.funnelarea={
   type:"funnelarea"
  };
  Client.funnelarea().values=[5,4,3,2,1];
  Client.funnelarea().text=["First","Second","Third","Fourth","Fifth"];
  Client.funnelarea().marker=(r$16={},r$16.colors=["59D4E8","DDB6C6","A696C8","67EACA","94D2E6"],r$16.line=(r$17={},r$17.color=["59D4E8","DDB6C6","A696C8","67EACA","94D2E6"],r$17.width=[2,1,5,0,3],r$17),r$16);
  Client.funnelarea().textfont=(r$18={},r$18.family="Old Standard TT",r$18.size=13,r$18.color="black",r$18);
  SC$1.indicator={
   type:"indicator"
  };
  Client.indicator().value=200;
  Client.indicator().delta=(r$19={},r$19.reference=160,r$19);
  Client.indicator().gauge=(r$20={},r$20.axis=(r$21={},r$21.visible=false,r$21.range=[0,250],r$21),r$20);
  Client.indicator().domain=(r$22={},r$22.row=0,r$22.column=0,r$22);
  Client.indicator().title=(r$23={},r$23.text="Speed",r$23);
  Client.indicator().mode="number+delta+gauge";
  SC$1.indicatorLayout={};
  Client.indicatorLayout().width=600;
  Client.indicatorLayout().height=400;
  Client.indicatorLayout().margin=(r$24={},r$24.t=25,r$24.b=25,r$24.l=25,r$24.r=25,r$24);
  Client.indicatorLayout().grid=(r$25={},r$25.rows=2,r$25.columns=2,r$25.pattern="independent",r$25);
  SC$1.ohlc={
   type:"ohlc"
  };
  Client.ohlc().x=["2017-01-04","2017-01-05","2017-01-06","2017-01-09","2017-01-10","2017-01-11","2017-01-12","2017-01-13","2017-01-17","2017-01-18","2017-01-19","2017-01-20","2017-01-23","2017-01-24","2017-01-25","2017-02-02","2017-02-03","2017-02-04","2017-02-07"];
  Client.ohlc().close=[116.019997,116.610001,117.910004,118.989998,119.110001,119.75,119.25,119.040001,120,119.989998,119.779999,120,120.080002,119.970001,121.879997,121.940002,121.949997,121.629997,121.349998];
  Client.ohlc().decreasing=(r$26={},r$26.line=(r$27={},r$27.color="#7F7F7F",r$27),r$26);
  Client.ohlc().high=[116.510002,116.860001,118.160004,119.43,119.379997,119.93,119.300003,119.620003,120.239998,120.5,120.089996,120.449997,120.809998,120.099998,122.099998,122.440002,122.349998,121.629997,121.389999];
  Client.ohlc().increasing=(r$28={},r$28.line=(r$29={},r$29.color="#17BECF",r$29),r$28);
  Client.ohlc().line=(r$30={},r$30.color="rgba(31,119,180,1)",r$30);
  Client.ohlc().low=[115.510002,114.860001,115.160004,116.43,117.379997,117.93,117.300003,116.620003,118.239998,117.5,116.089996,117.449997,119.809998,116.099998,120.099998,121.440002,121.349998,120.629997,120.389999];
  Client.ohlc().open=[116.810002,116.960001,118.460004,119.93,119.779997,119.93,119.700003,119.720003,120.339998,120.65,120.689996,120.749997,120.909998,120.299998,122.399998,122.540002,122.849998,121.829997,121.589999];
  Client.ohlc().xaxis="x";
  Client.ohlc().yaxis="y";
  SC$1.waterfall={
   type:"waterfall"
  };
  Client.waterfall().name="2018";
  Client.waterfall().orientation="v";
  Client.waterfall().measure=["relative","relative","total","relative","relative","total"];
  Client.waterfall().x=["Sales","Consulting","Net revenue","Purchases","Other expenses","Profit before tax"];
  Client.waterfall().textposition="outside";
  Client.waterfall().text=["+60","+80","","-40","-20","Total"];
  Client.waterfall().y=[60,80,0,-40,-20,0];
  Client.waterfall().connector=(r$31={},r$31.line=(r$32={},r$32.color="rgb(63, 63, 63)",r$32),r$31);
  SC$1.choropleth={
   type:"choropleth"
  };
  Client.choropleth().locationmode="country names";
  Client.choropleth().locations=["Brazil","Canada","Indonesia","Australia","Japan","France","Norway","Egypt","South Africa","Mongolia"];
  Client.choropleth().z=[234,234,23,235,45,23,23,5,24,234];
  Client.choropleth().text=["a","b","c","d","e","f","g","h","i","j"];
  Client.choropleth().autocolorscale=true;
  SC$1.choroplethmb={
   type:"choroplethmapbox"
  };
  Client.choroplethmb().locations=["NY","MA","VT"];
  Client.choroplethmb().z=[-50,-10,-20];
  Client.choroplethmb().geojson="https://raw.githubusercontent.com/python-visualization/folium/master/examples/data/us-states.json";
  SC$1.choroplethMBLayout={};
  Client.choroplethMBLayout().mapbox=(r$33={},r$33.style="stamen-watercolor",r$33.center=(r$34={},r$34.lon=-74,r$34.lat=43,r$34),r$33.zoom=3.5,r$33);
  SC$1.densitymb={
   type:"densitymapbox"
  };
  Client.densitymb().lon=[10,20,30];
  Client.densitymb().lat=[15,25,35];
  Client.densitymb().z=[1,3,2];
  SC$1.scattergeo={
   type:"scattergeo"
  };
  Client.scattergeo().mode="markers+text";
  Client.scattergeo().text=["Montreal","Toronto","Vancouver","Calgary","Edmonton","Ottawa","Halifax","Victoria","Winnepeg","Regina"];
  Client.scattergeo().lon=[-73.57,-79.24,-123.06,-114.1,-113.28,-75.43,-63.57,-123.21,-97.13,-104.6];
  Client.scattergeo().lat=[45.5,43.4,49.13,51.1,53.34,45.24,44.64,48.25,49.89,50.45];
  Client.scattergeo().marker=(r$35={},r$35.size=7,r$35.color=["#bebada","#fdb462","#fb8072","#d9d9d9","#bc80bd","#b3de69","#8dd3c7","#80b1d3","#fccde5","#ffffb3"],r$35.line=(r$36={},r$36.width=1,r$36),r$35);
  Client.scattergeo().name="Canadian cities";
  Client.scattergeo().textposition=["top right","top left","top center","bottom right","top right","top left","bottom right","bottom left","top right","top right"];
  SC$1.scattermb={
   type:"scattermapbox"
  };
  Client.scattermb().lat=["45.5017"];
  Client.scattermb().lon=["-73.5673"];
  Client.scattermb().mode="markers";
  Client.scattermb().marker=(r$37={},r$37.size=14,r$37);
  Client.scattermb().text=["Montreal"];
  SC$1.cone={
   type:"cone"
  };
  Client.cone().x=[1];
  Client.cone().y=[1];
  Client.cone().z=[1];
  Client.cone().u=[1];
  Client.cone().v=[1];
  Client.cone().w=[0];
  SC$1.isosurface={
   type:"isosurface"
  };
  Client.isosurface().x=[0,0,0,0,1,1,1,1];
  Client.isosurface().y=[0,1,0,1,0,1,0,1];
  Client.isosurface().z=[1,1,0,0,1,1,0,0];
  Client.isosurface().value=[1,2,3,4,5,6,7,8];
  Client.isosurface().isomin=2;
  Client.isosurface().isomax=6;
  Client.isosurface().colorscale="Reds";
  SC$1.mesh={
   type:"mesh3d"
  };
  Client.mesh().x=[34,52,34,42,345,665,34,23,54,436,65,34,235,654,345];
  Client.mesh().y=[534,345,34,65,865,34,54,764,234,54,34,64,34,345,45];
  Client.mesh().z=[56,456,234,54,56,687,34,45,345,56,34,345,456,45,45];
  Client.mesh().opacity=0.8;
  Client.mesh().color="rgb(300,100,200)";
  SC$1.option1={};
  Client.option1().locale="fr";
  SC$1.scatter3d={
   type:"scatter3d"
  };
  Client.scatter3d().x=[234,234,23,235,45,23,23,5,24,234,4,334,234,43,234,543,134,645,345,234,64];
  Client.scatter3d().y=[234,234,23,235,45,23,23,5,24,234,4,334,234,43,234,543,134,645,345,234,64];
  Client.scatter3d().z=[234,234,23,235,45,23,23,5,24,234,4,334,234,43,234,543,134,645,345,234,64];
  Client.scatter3d().mode="markers";
  Client.scatter3d().marker=(r$38={},r$38.size=12,r$38.line=(r$39={},r$39.color="rgba(217, 217, 217, 0.14)",r$39.width=0.5,r$39.opacity=0.8,r$39),r$38);
  SC$1.streamtube={
   type:"streamtube"
  };
  Client.streamtube().x=[1,1,1,1,1,1,1,1,1,1];
  Client.streamtube().y=[1,1,1,1,1,0,0,0,-1,-1];
  Client.streamtube().z=[0,0,0,0,0,0,0,0,0,0];
  Client.streamtube().u=[0,0,0,0,0,0,1,1,1,2];
  Client.streamtube().v=[0,0,0,1,1,1,1,2,2,2];
  Client.streamtube().w=[0,1,2,0,1,2,0,1,2,0];
  Client.streamtube().sizeref=0.5;
  Client.streamtube().cmin=0;
  Client.streamtube().cmax=3;
  SC$1.streamTubeLayout={};
  Client.streamTubeLayout().scene=(r$40={},r$40.camera=(r$41={},r$41.eye=(r$42={},r$42.x=-0.7243612458865182,r$42.y=1.9269804254717962,r$42.z=0.6704828299861716,r$42),r$41),r$40);
  SC$1.surface={
   type:"surface"
  };
  Client.surface().z=[[34,52,34,42,345,665,34,23,54,436,65,34,235,654,345],[65,34,654,345,235,34,42,345,34,52,54,436,665,34,23]];
  SC$1.ccarpet={
   type:"carpet"
  };
  Client.ccarpet().a=[0,1,2,3,0,1,2,3,0,1,2,3];
  Client.ccarpet().b=[4,4,4,4,5,5,5,5,6,6,6,6];
  Client.ccarpet().x=[2,3,4,5,2.2,3.1,4.1,5.1,1.5,2.5,3.5,4.5];
  Client.ccarpet().y=[1,1.4,1.6,1.75,2,2.5,2.7,2.75,3,3.5,3.7,3.75];
  Client.ccarpet().aaxis=(r$43={},r$43.tickprefix="a = ",r$43.smoothing=0,r$43.minorgridcount=9,r$43.type="linear",r$43);
  Client.ccarpet().baxis=(r$44={},r$44.tickprefix="b = ",r$44.smoothing=0,r$44.minorgridcount=9,r$44.type="linear",r$44);
  SC$1.contourcarpet={
   type:"contourcarpet"
  };
  Client.contourcarpet().a=[0,1,2,3,0,1,2,3,0,1,2,3];
  Client.contourcarpet().b=[4,4,4,4,5,5,5,5,6,6,6,6];
  Client.contourcarpet().z=[1,1.96,2.56,3.0625,4,5.0625,1,7.5625,9,12.25,15.21,14.0625];
  Client.contourcarpet().autocontour=false;
  Client.contourcarpet().contours=(r$45={},r$45.start=1,r$45.end=14,r$45.size=1,r$45);
  Client.contourcarpet().line=(r$46={},r$46.width=2,r$46.smoothing=0,r$46);
  Client.contourcarpet().colorbar=(r$47={},r$47.len=0.4,r$47.y=0.25,r$47);
  SC$1.parcats={
   type:"parcats"
  };
  Client.parcats().dimensions=[(r$48={},r$48.label="Hair",r$48.values=["Black","Black","Black","Brown","Brown","Brown","Red","Brown"],r$48),(r$49={},r$49.label="Eye",r$49.values=["Brown","Brown","Brown","Brown","Brown","Blue","Blue","Blue"],r$49),(r$50={},r$50.label="Sex",r$50.values=["Female","Female","Female","Male","Female","Male","Male","Male"],r$50)];
  SC$1.parcoords={
   type:"parcoords"
  };
  Client.parcoords().line=(r$51={},r$51.color="blue",r$51);
  Client.parcoords().dimensions=[(r$52={},r$52.range=[1,5],r$52.constraintrange=[1,2],r$52.label="A",r$52.values=[1,4],r$52),(r$53={},r$53.range=[1,5],r$53.tickvals=[1.5,3,4.5],r$53.label="B",r$53.values=[3,1.5],r$53),(r$54={},r$54.range=[1,5],r$54.tickvals=[1,2,4,5],r$54.label="C",r$54.values=[2,4],r$54.ticktext=["text1","text2","text3","text4","text5"],r$54),(r$55={},r$55.range=[1,5],r$55.label="D",r$55.values=[4,2],r$55)];
  SC$1.sankey={
   type:"sankey"
  };
  Client.sankey().orientation="h";
  Client.sankey().node=(r$56={},r$56.pad=15,r$56.thickness=30,r$56.line=(r$57={},r$57.color="black",r$57.width=0.5,r$57),r$56.label=["A1","A2","B1","B2","C1","C2"],r$56.color=List.ofArray(["blue","blue","blue","blue","blue","blue"]),r$56);
  Client.sankey().link=(r$58={},r$58.source=[0,1,0,2,3,3],r$58.target=[2,3,3,4,4,5],r$58.value=[8,4,2,8,4,2],r$58);
  SC$1.scarpet={
   type:"carpet"
  };
  Client.scarpet().a=Arrays.map(function(y)
  {
   return 1E-06*y;
  },[4,4,4,4.5,4.5,4.5,5,5,5,6,6,6]);
  Client.scarpet().b=Arrays.map(function(y)
  {
   return 1000000*y;
  },[1,2,3,1,2,3,1,2,3,1,2,3]);
  Client.scarpet().y=[2,3.5,4,3,4.5,5,5.5,6.5,7.5,8,8.5,10];
  Client.scarpet().aaxis=(r$59={},r$59.tickprefix="a = ",r$59.ticksuffix="m",r$59.smoothing=1,r$59.minorgridcount=9,r$59);
  Client.scarpet().baxis=(r$60={},r$60.tickprefix="b = ",r$60.ticksuffix="Pa",r$60.smoothing=1,r$60.minorgridcount=9,r$60);
  SC$1.scattercarpet={
   type:"scattercarpet"
  };
  Client.scattercarpet().a=Arrays.map(function(y)
  {
   return 1E-06*y;
  },[4,4.5,5,6]);
  Client.scattercarpet().b=Arrays.map(function(y)
  {
   return 1000000*y;
  },[1.5,2.5,1.5,2.5]);
  Client.scattercarpet().line=(r$61={},r$61.shape="spline",r$61.smoothing=1,r$61);
  SC$1.scarpetLayout={};
  SC$1.spolar={
   type:"scatterpolar"
  };
  Client.spolar().r=[34,52,34,42,345,665,34,23,54,436,65,34,235,654,345];
  Client.spolar().theta=[34,52,34,42,345,665,34,23,54,436,65,34,235,654,345];
  Client.spolar().mode="lines";
  Client.spolar().name="Figure8";
  Client.spolar().line=(r$62={},r$62.color="peru",r$62);
  SC$1.spolargl1={
   type:"scatterpolargl"
  };
  Client.spolargl1().r=[1,2,3];
  Client.spolargl1().theta=[50,100,200];
  Client.spolargl1().marker=(r$63={},r$63.symbol="square",r$63);
  SC$1.spolargl2={
   type:"scatterpolargl"
  };
  Client.spolargl2().r=[1,2,3];
  Client.spolargl2().theta=[1,2,3];
  Client.spolargl2().thetaunit="radians";
  SC$1.densityMBLayout={};
  Client.densityMBLayout().width=600;
  Client.densityMBLayout().height=400;
  Client.densityMBLayout().mapbox=(r$64={},r$64.style="stamen-terrain",r$64);
  SC$1.scatterGeoLayout={};
  Client.scatterGeoLayout().title=(r$65={},r$65.text="Canadian cities",r$65.font=(r$66={},r$66.size=16,r$66),r$65);
  Client.scatterGeoLayout().font=(r$67={},r$67.family="Droid Serif, serif",r$67.size=6,r$67);
  Client.scatterGeoLayout().geo=(r$68={},r$68.scope="north america",r$68.resolution="50",r$68.lonaxis=(r$69={},r$69.range=[-130,-55],r$69),r$68.lataxis=(r$70={},r$70.range=[40,70],r$70),r$68.showrivers=true,r$68.rivercolor="#fff",r$68.showlakes=true,r$68.lakecolor="#fff",r$68.showland=true,r$68.landcolor="#fff",r$68.countrycolor="EAEAAE",r$68.countrywidth=1.5,r$68.subunitcolor="#d3d3d3",r$68);
  SC$1.scatterMBLayout={};
  Client.scatterMBLayout().autosize=true;
  Client.scatterMBLayout().hovermode="closest";
  Client.scatterMBLayout().mapbox=(r$71={},r$71.style="stamen-terrain",r$71.bearing=0,r$71.center=(r$72={},r$72.lat=45,r$72.lon=-73,r$72),r$71.pitch=0,r$71.zoom=5,r$71);
  SC$1.scatter3DLayout={};
  Client.scatter3DLayout().margin=(r$73={},r$73.l=0,r$73.r=0,r$73.b=0,r$73.t=0,r$73);
  SC$1.surfaceLayout={};
  Client.surfaceLayout().title=(r$74={},r$74.text="Mt Bruno Elevation",r$74);
  Client.surfaceLayout().autosize=false;
  Client.surfaceLayout().width=500;
  Client.surfaceLayout().height=500;
  Client.surfaceLayout().margin=(r$75={},r$75.l=65,r$75.r=50,r$75.b=65,r$75.t=90,r$75);
  SC$1.ccarpetLayout={};
  Client.ccarpetLayout().margin=(r$76={},r$76.t=40,r$76.r=30,r$76.b=30,r$76.l=30,r$76);
  Client.ccarpetLayout().yaxis=(r$77={},r$77.range=[0.388,4.361],r$77);
  Client.ccarpetLayout().xaxis=(r$78={},r$78.range=[0.667,5.932],r$78);
  SC$1.sternary={
   type:"scatterternary"
  };
  Client.sternary().mode="markers";
  Client.sternary().name="k";
  Client.sternary().a=[75,70,75,5,10,10,20,10,15,10,20];
  Client.sternary().b=[25,10,20,60,80,90,70,20,5,10,10];
  Client.sternary().c=[0,20,5,35,10,0,10,70,80,80,70];
  Client.sternary().text=["point 1","point 2","point 3","point 4","point 5","point 6","point 7","point 8","point 9","point 10","point 11"];
  Client.sternary().marker=(r$79={},r$79.symbol="100",r$79.color="#DB7365",r$79.size=14,r$79.line=(r$80={},r$80.width=2,r$80),r$79);
  SC$1.sternaryLayout={};
  Client.sternaryLayout().ternary=(r$81={},r$81.sum=100,r$81.aaxis=(r$82={},r$82.title=(r$83={},r$83.text="Journalist",r$83.font=(r$84={},r$84.size=20,r$84),r$83),r$82.tickangle=0,r$82.tickfont=(r$85={},r$85.size=15,r$85.color="rgba(0,0,0,0)",r$85),r$82.ticklen=5,r$82.showline=true,r$82.showgrid=true,r$82),r$81.baxis=(r$86={},r$86.title=(r$87={},r$87.text="<br>Developer",r$87.font=(r$88={},r$88.size=20,r$88),r$87),r$86.tickangle=45,r$86.tickfont=(r$89={},r$89.size=15,r$89.color="rgba(0,0,0,0)",r$89),r$86.ticklen=5,r$86.showline=true,r$86.showgrid=true,r$86),r$81.caxis=(r$90={},r$90.title=(r$91={},r$91.text="<br>Designer",r$91.font=(r$92={},r$92.size=20,r$92),r$91),r$90.tickangle=-45,r$90.tickfont=(r$93={},r$93.size=15,r$93.color="rgba(0,0,0,0)",r$93),r$90.ticklen=5,r$90.showline=true,r$90.showgrid=true,r$90),r$81.bgcolor="#fff1e0",r$81);
  Client.sternaryLayout().showlegend=false;
  Client.sternaryLayout().width=700;
  Client.sternaryLayout().paper_bgcolor="#fff1e0";
  SC$1.splom={
   type:"splom"
  };
  Client.splom().dimensions=(r$94={},r$94.label="sepal length",r$94.values=[5.1,4.9,4.7,4.6,5,5.4,4.6,5,4.4,4.9],r$94);
  Client.splom().text=["Iris-setosa","Iris-setosa","Iris-setosa","Iris-setosa","Iris-setosa","Iris-setosa","Iris-setosa","Iris-setosa","Iris-setosa","Iris-setosa"];
  Client.splom().marker=(r$95={},r$95.color=["#c00","#343434","#343434","#343434","#343434","#343434","#343434","#343434","#343434","#343434"],r$95.size=7,r$95.line=(r$96={},r$96.color="white",r$96.width=0.5,r$96),r$95);
  SC$1.splomLayout={};
  Client.splomLayout().title=(r$97={},r$97.text="Iris Data set",r$97);
  Client.splomLayout().height=400;
  Client.splomLayout().width=400;
  Client.splomLayout().autosize=false;
  Client.splomLayout().hovermode="closest";
  Client.splomLayout().dragmode="select";
  Client.splomLayout().plot_bgcolor="rgba(240,240,240, 0.95)";
  SC$1.sunburst={
   type:"sunburst"
  };
  Client.sunburst().labels=["Eve","Cain","Seth","Enos","Noam","Abel","Awan","Enoch","Azura"];
  Client.sunburst().parents=["","Eve","Eve","Seth","Seth","Eve","Eve","Awan","Eve"];
  Client.sunburst().values=[10,14,12,10,2,6,6,4,4];
  Client.sunburst().outsidetextfont=(r$98={},r$98.size=20,r$98.color="#377eb8",r$98);
  Client.sunburst().leaf=(r$99={},r$99.opacity=0.4,r$99);
  Client.sunburst().marker=(r$100={},r$100.line=(r$101={},r$101.width=2,r$101),r$100);
  SC$1.sunBurstLayout={};
  Client.sunBurstLayout().margin=(r$102={},r$102.l=0,r$102.r=0,r$102.b=0,r$102.t=0,r$102);
  Client.sunBurstLayout().width=500;
  Client.sunBurstLayout().height=500;
  SC$1.treemap={
   type:"treemap"
  };
  Client.treemap().labels=["Eve","Cain","Seth","Enos","Noam","Abel","Awan","Enoch","Azura"];
  Client.treemap().parents=["","Eve","Eve","Seth","Seth","Eve","Eve","Awan","Eve"];
  SC$1.icicle={
   type:"icicle"
  };
  Client.icicle().labels=["Eve","Cain","Seth","Enos","Noam","Abel","Awan","Enoch","Azura"];
  Client.icicle().parents=["","Eve","Eve","Seth","Seth","Eve","Eve","Awan","Eve"];
  Client.icicle().values=[10,14,12,10,2,6,6,4,4];
  Client.icicle().outsidetextfont=(r$103={},r$103.size=20,r$103.color="#377eb8",r$103);
  Client.icicle().leaf=(r$104={},r$104.opacity=0.4,r$104);
  Client.icicle().marker=(r$105={},r$105.line=(r$106={},r$106.width=2,r$106),r$105);
  Client.icicle().root=(r$107={},r$107.color="lightgrey",r$107);
  SC$1.icicleLayout={};
  Client.icicleLayout().margin=(r$108={},r$108.l=25,r$108.r=25,r$108.b=25,r$108.t=50,r$108);
  SC$1.barpolar3={
   type:"barpolar"
  };
  Client.barpolar3().r=[57.5,50,45,35,20,22.5,37.5,55];
  Client.barpolar3().name="8-11 m/s";
  Client.barpolar3().marker=(r$109={},r$109.color="rgb(158,154,200)",r$109);
  Client.barpolar3().theta=["North","N-E","East","S-E","South","S-W","West","N-W"];
  SC$1.barpolar2={
   type:"barpolar"
  };
  Client.barpolar2().r=[40,30,30,35,7.5,7.5,32.5,40];
  Client.barpolar2().name="5-8 m/s";
  Client.barpolar2().marker=(r$110={},r$110.color="rgb(203,201,226)",r$110);
  Client.barpolar2().theta=["North","N-E","East","S-E","South","S-W","West","N-W"];
  SC$1.barpolar1={
   type:"barpolar"
  };
  Client.barpolar1().r=[77.5,72.5,70,45,22.5,42.5,40,62.5];
  Client.barpolar1().name="11-14 m/s";
  Client.barpolar1().marker=(r$111={},r$111.color="rgb(106,81,163)",r$111);
  Client.barpolar1().theta=["North","N-E","East","S-E","South","S-W","West","N-W"];
  SC$1.barpolar4={
   type:"barpolar"
  };
  Client.barpolar4().r=[20,7.5,15,22.5,2.5,2.5,12.5,22.5];
  Client.barpolar4().name="< 5 m/s";
  Client.barpolar4().marker=(r$112={},r$112.color="rgb(242,240,247)",r$112);
  Client.barpolar4().theta=["North","N-E","East","S-E","South","S-W","West","N-W"];
  SC$1.barpolarLayout={};
  Client.barpolarLayout().title=(r$113={},r$113.text="Wind Speed Distribution in Laurel, NE",r$113.font=(r$114={},r$114.size=16,r$114),r$113);
  Client.barpolarLayout().legend=(r$115={},r$115.font=(r$116={},r$116.size=16,r$116),r$115);
  Client.barpolarLayout().polar=(r$117={},r$117.radialaxis=(r$118={},r$118.ticksuffix="%",r$118.angle=45,r$118.dtick=20,r$118),r$117.angularaxis=(r$119={},r$119.direction="clockwise",r$119),r$117.bargap=0,r$117);
  SC$1.option2={};
  Client.option2().locale="fr";
 };
 AsyncBody.New=function(k,ct)
 {
  return{
   k:k,
   ct:ct
  };
 };
 JS.GetFieldValues=function(o)
 {
  var r,k;
  r=[];
  for(var k$1 in o)r.push(o[k$1]);
  return r;
 };
 Arrays.ofSeq=function(xs)
 {
  var q,o;
  if(xs instanceof Global.Array)
   return xs.slice();
  else
   if(xs instanceof T)
    return Arrays.ofList(xs);
   else
    {
     q=[];
     o=Enumerator.Get(xs);
     try
     {
      while(o.MoveNext())
       q.push(o.Current());
      return q;
     }
     finally
     {
      if(typeof o=="object"&&"Dispose"in o)
       o.Dispose();
     }
    }
 };
 Arrays.map=function(f,arr)
 {
  var r,i,$1;
  r=new Global.Array(arr.length);
  for(i=0,$1=arr.length-1;i<=$1;i++)r[i]=f(arr[i]);
  return r;
 };
 Arrays.ofList=function(xs)
 {
  var l,q;
  q=[];
  l=xs;
  while(!(l.$==0))
   {
    q.push(List.head(l));
    l=List.tail(l);
   }
  return q;
 };
 Arrays.exists=function(f,x)
 {
  var e,i,$1,l;
  e=false;
  i=0;
  l=Arrays.length(x);
  while(!e&&i<l)
   if(f(x[i]))
    e=true;
   else
    i=i+1;
  return e;
 };
 Arrays.tryPick=function(f,arr)
 {
  var res,i,m;
  res=null;
  i=0;
  while(i<arr.length&&res==null)
   {
    m=f(arr[i]);
    if(m!=null&&m.$==1)
     res=m;
    i=i+1;
   }
  return res;
 };
 Arrays.tryFindIndex=function(f,arr)
 {
  var res,i;
  res=null;
  i=0;
  while(i<arr.length&&res==null)
   {
    f(arr[i])?res={
     $:1,
     $0:i
    }:void 0;
    i=i+1;
   }
  return res;
 };
 Arrays.filter=function(f,arr)
 {
  var r,i,$1;
  r=[];
  for(i=0,$1=arr.length-1;i<=$1;i++)if(f(arr[i]))
   r.push(arr[i]);
  return r;
 };
 Arrays.iter=function(f,arr)
 {
  var i,$1;
  for(i=0,$1=arr.length-1;i<=$1;i++)f(arr[i]);
 };
 Arrays.foldBack=function(f,arr,zero)
 {
  var acc,$1,len,i,$2;
  acc=zero;
  len=arr.length;
  for(i=1,$2=len;i<=$2;i++)acc=f(arr[len-i],acc);
  return acc;
 };
 Arrays.pick=function(f,arr)
 {
  var m;
  m=Arrays.tryPick(f,arr);
  return m==null?Operators.FailWith("KeyNotFoundException"):m.$0;
 };
 Arrays.concat=function(xs)
 {
  return Global.Array.prototype.concat.apply([],Arrays.ofSeq(xs));
 };
 Arrays.choose=function(f,arr)
 {
  var q,i,$1,m;
  q=[];
  for(i=0,$1=arr.length-1;i<=$1;i++){
   m=f(arr[i]);
   if(m==null)
    ;
   else
    q.push(m.$0);
  }
  return q;
 };
 Arrays.create=function(size,value)
 {
  var r,i,$1;
  r=new Global.Array(size);
  for(i=0,$1=size-1;i<=$1;i++)r[i]=value;
  return r;
 };
 Arrays.init=function(size,f)
 {
  var r,i,$1;
  if(size<0)
   Operators.FailWith("Negative size given.");
  else
   null;
  r=new Global.Array(size);
  for(i=0,$1=size-1;i<=$1;i++)r[i]=f(i);
  return r;
 };
 Arrays.forall=function(f,x)
 {
  var a,i,$1,l;
  a=true;
  i=0;
  l=Arrays.length(x);
  while(a&&i<l)
   if(f(x[i]))
    i=i+1;
   else
    a=false;
  return a;
 };
 CT.New=function(IsCancellationRequested,Registrations)
 {
  return{
   c:IsCancellationRequested,
   r:Registrations
  };
 };
 SC$2.$cctor=function()
 {
  SC$2.$cctor=Global.ignore;
  SC$2.noneCT=CT.New(false,[]);
  SC$2.scheduler=new Scheduler.New();
  SC$2.defCTS=[new CancellationTokenSource.New()];
  SC$2.Zero=Concurrency.Return();
  SC$2.GetCT=function(c)
  {
   c.k({
    $:0,
    $0:c.ct
   });
  };
 };
 View.Const=function(x)
 {
  var o;
  o=Snap.New({
   $:0,
   $0:x
  });
  return function()
  {
   return o;
  };
 };
 View.Sink=function(act,a)
 {
  function loop()
  {
   Snap.WhenRun(a(),act,function()
   {
    Concurrency.scheduler().Fork(loop);
   });
  }
  Concurrency.scheduler().Fork(loop);
 };
 View.Map2Unit=function(a,a$1)
 {
  return View.CreateLazy(function()
  {
   return Snap.Map2Unit(a(),a$1());
  });
 };
 View.CreateLazy=function(observe)
 {
  var lv;
  lv={
   c:null,
   o:observe
  };
  return function()
  {
   var c,$1;
   c=lv.c;
   return c===null?(c=lv.o(),lv.c=c,($1=c.s,$1!=null&&$1.$==0)?lv.o=null:Snap.WhenObsoleteRun(c,function()
   {
    lv.c=null;
   }),c):c;
  };
 };
 View.Map=function(fn,a)
 {
  return View.CreateLazy(function()
  {
   return Snap.Map(fn,a());
  });
 };
 DomUtility.ParseHTMLIntoFakeRoot=function(elem)
 {
  var root,tag,m,p,w;
  function unwrap(elt,a)
  {
   var i;
   while(true)
    if(a===0)
     return elt;
    else
     {
      i=a;
      elt=elt.lastChild;
      a=i-1;
     }
  }
  root=self.document.createElement("div");
  return!DomUtility.rhtml().test(elem)?(root.appendChild(self.document.createTextNode(elem)),root):(tag=(m=DomUtility.rtagName().exec(elem),Unchecked.Equals(m,null)?"":Arrays.get(m,1).toLowerCase()),(p=(w=(DomUtility.wrapMap())[tag],w?w:DomUtility.defaultWrap()),(root.innerHTML=p[1]+elem.replace(DomUtility.rxhtmlTag(),"<$1></$2>")+p[2],unwrap(root,p[0]))));
 };
 DomUtility.rhtml=function()
 {
  SC$6.$cctor();
  return SC$6.rhtml;
 };
 DomUtility.wrapMap=function()
 {
  SC$6.$cctor();
  return SC$6.wrapMap;
 };
 DomUtility.defaultWrap=function()
 {
  SC$6.$cctor();
  return SC$6.defaultWrap;
 };
 DomUtility.rxhtmlTag=function()
 {
  SC$6.$cctor();
  return SC$6.rxhtmlTag;
 };
 DomUtility.rtagName=function()
 {
  SC$6.$cctor();
  return SC$6.rtagName;
 };
 DomUtility.IterSelector=function(el,selector,f)
 {
  var l,i,$1;
  l=el.querySelectorAll(selector);
  for(i=0,$1=l.length-1;i<=$1;i++)f(l[i]);
 };
 DomUtility.InsertAt=function(parent,pos,node)
 {
  var m;
  if(!(node.parentNode===parent&&pos===(m=node.nextSibling,Unchecked.Equals(m,null)?null:m)))
   parent.insertBefore(node,pos);
 };
 DomUtility.RemoveNode=function(parent,el)
 {
  if(el.parentNode===parent)
   parent.removeChild(el);
 };
 Attrs.Static=function(attr$1)
 {
  return new AttrProxy({
   $:3,
   $0:attr$1
  });
 };
 Attrs.Updates=function(dyn)
 {
  return Array.MapTreeReduce(function(x)
  {
   return x.NChanged();
  },View.Const(),View.Map2Unit,dyn.DynNodes);
 };
 Attrs.AppendTree=function(a,b)
 {
  var x;
  return a===null?b:b===null?a:(x=new AttrProxy({
   $:2,
   $0:a,
   $1:b
  }),(Attrs.SetFlags(x,Attrs.Flags(a)|Attrs.Flags(b)),x));
 };
 Attrs.EmptyAttr=function()
 {
  SC$5.$cctor();
  return SC$5.EmptyAttr;
 };
 Attrs.Insert=function(elem,tree)
 {
  var nodes,oar,arr;
  function loop(node)
  {
   var b,a;
   while(true)
    if(!(node===null))
    {
     if(node!=null&&node.$==1)
      return nodes.push(node.$0);
     else
      if(node!=null&&node.$==2)
       {
        b=node.$1;
        a=node.$0;
        loop(a);
        node=b;
       }
      else
       return node!=null&&node.$==3?node.$0(elem):node!=null&&node.$==4?oar.push(node.$0):null;
    }
    else
     return null;
  }
  nodes=[];
  oar=[];
  loop(tree);
  arr=nodes.slice(0);
  return Dyn.New(elem,Attrs.Flags(tree),arr,oar.length===0?null:{
   $:1,
   $0:function(el)
   {
    Seq.iter(function(f)
    {
     f(el);
    },oar);
   }
  });
 };
 Attrs.SetFlags=function(a,f)
 {
  a.flags=f;
 };
 Attrs.Flags=function(a)
 {
  return a!==null&&a.hasOwnProperty("flags")?a.flags:0;
 };
 Attrs.HasExitAnim=function(attr$1)
 {
  var flag;
  flag=2;
  return(attr$1.DynFlags&flag)===flag;
 };
 Attrs.GetExitAnim=function(dyn)
 {
  return Attrs.GetAnim(dyn,function($1,$2)
  {
   return $1.NGetExitAnim($2);
  });
 };
 Attrs.HasEnterAnim=function(attr$1)
 {
  var flag;
  flag=1;
  return(attr$1.DynFlags&flag)===flag;
 };
 Attrs.GetEnterAnim=function(dyn)
 {
  return Attrs.GetAnim(dyn,function($1,$2)
  {
   return $1.NGetEnterAnim($2);
  });
 };
 Attrs.HasChangeAnim=function(attr$1)
 {
  var flag;
  flag=4;
  return(attr$1.DynFlags&flag)===flag;
 };
 Attrs.GetChangeAnim=function(dyn)
 {
  return Attrs.GetAnim(dyn,function($1,$2)
  {
   return $1.NGetChangeAnim($2);
  });
 };
 Attrs.GetAnim=function(dyn,f)
 {
  return An.Concat(Arrays.map(function(n)
  {
   return f(n,dyn.DynElem);
  },dyn.DynNodes));
 };
 Attrs.Sync=function(elem,dyn)
 {
  Arrays.iter(function(d)
  {
   d.NSync(elem);
  },dyn.DynNodes);
 };
 Dictionary=Collections.Dictionary=Runtime.Class({
  set_Item:function(k,v)
  {
   this.set(k,v);
  },
  ContainsKey:function(k)
  {
   var $this,d;
   $this=this;
   d=this.data[this.hash(k)];
   return d==null?false:Arrays.exists(function(a)
   {
    return $this.equals.apply(null,[(Operators.KeyValue(a))[0],k]);
   },d);
  },
  TryGetValue:function(k,res)
  {
   var $this,d,v;
   $this=this;
   d=this.data[this.hash(k)];
   return d==null?false:(v=Arrays.tryPick(function(a)
   {
    var a$1;
    a$1=Operators.KeyValue(a);
    return $this.equals.apply(null,[a$1[0],k])?{
     $:1,
     $0:a$1[1]
    }:null;
   },d),v!=null&&v.$==1&&(res.set(v.$0),true));
  },
  RemoveKey:function(k)
  {
   return this.remove(k);
  },
  Keys:function()
  {
   return new KeyCollection.New(this);
  },
  set:function(k,v)
  {
   var $this,h,d,m;
   $this=this;
   h=this.hash(k);
   d=this.data[h];
   if(d==null)
    {
     this.count=this.count+1;
     this.data[h]=new Global.Array({
      K:k,
      V:v
     });
    }
   else
    {
     m=Arrays.tryFindIndex(function(a)
     {
      return $this.equals.apply(null,[(Operators.KeyValue(a))[0],k]);
     },d);
     m==null?(this.count=this.count+1,d.push({
      K:k,
      V:v
     })):d[m.$0]={
      K:k,
      V:v
     };
    }
  },
  remove:function(k)
  {
   var $this,h,d,r;
   $this=this;
   h=this.hash(k);
   d=this.data[h];
   return d==null?false:(r=Arrays.filter(function(a)
   {
    return!$this.equals.apply(null,[(Operators.KeyValue(a))[0],k]);
   },d),Arrays.length(r)<d.length&&(this.count=this.count-1,this.data[h]=r,true));
  },
  Item:function(k)
  {
   return this.get(k);
  },
  get:function(k)
  {
   var $this,d;
   $this=this;
   d=this.data[this.hash(k)];
   return d==null?DictionaryUtil.notPresent():Arrays.pick(function(a)
   {
    var a$1;
    a$1=Operators.KeyValue(a);
    return $this.equals.apply(null,[a$1[0],k])?{
     $:1,
     $0:a$1[1]
    }:null;
   },d);
  },
  GetEnumerator:function()
  {
   return Enumerator.Get0(Arrays.concat(JS.GetFieldValues(this.data)));
  }
 },Obj,Dictionary);
 Dictionary.New$5=Runtime.Ctor(function()
 {
  Dictionary.New$6.call(this,[],Unchecked.Equals,Unchecked.Hash);
 },Dictionary);
 Dictionary.New$6=Runtime.Ctor(function(init,equals,hash)
 {
  var e,x;
  Obj.New.call(this);
  this.equals=equals;
  this.hash=hash;
  this.count=0;
  this.data=[];
  e=Enumerator.Get(init);
  try
  {
   while(e.MoveNext())
    {
     x=e.Current();
     this.set(x.K,x.V);
    }
  }
  finally
  {
   if(typeof e=="object"&&"Dispose"in e)
    e.Dispose();
  }
 },Dictionary);
 Scheduler=Concurrency.Scheduler=Runtime.Class({
  Fork:function(action)
  {
   var $this;
   $this=this;
   this.robin.push(action);
   if(this.idle)
    {
     this.idle=false;
     Global.setTimeout(function()
     {
      $this.tick();
     },0);
    }
  },
  tick:function()
  {
   var loop,$this,t;
   $this=this;
   t=Date.now();
   loop=true;
   while(loop)
    if(this.robin.length===0)
     {
      this.idle=true;
      loop=false;
     }
    else
     {
      (this.robin.shift())();
      Date.now()-t>40?(Global.setTimeout(function()
      {
       $this.tick();
      },0),loop=false):void 0;
     }
  }
 },Obj,Scheduler);
 Scheduler.New=Runtime.Ctor(function()
 {
  Obj.New.call(this);
  this.idle=true;
  this.robin=[];
 },Scheduler);
 OperationCanceledException=WebSharper.OperationCanceledException=Runtime.Class({},Error,OperationCanceledException);
 OperationCanceledException.New=Runtime.Ctor(function(ct)
 {
  OperationCanceledException.New$1.call(this,"The operation was canceled.",null,ct);
 },OperationCanceledException);
 OperationCanceledException.New$1=Runtime.Ctor(function(message,inner,ct)
 {
  this.message=message;
  this.inner=inner;
  Object.setPrototypeOf(this,OperationCanceledException.prototype);
  this.ct=ct;
 },OperationCanceledException);
 Enumerator.Get=function(x)
 {
  return x instanceof Global.Array?Enumerator.ArrayEnumerator(x):Unchecked.Equals(typeof x,"string")?Enumerator.StringEnumerator(x):x.GetEnumerator();
 };
 Enumerator.ArrayEnumerator=function(s)
 {
  return new T$1.New(0,null,function(e)
  {
   var i;
   i=e.s;
   return i<Arrays.length(s)&&(e.c=Arrays.get(s,i),e.s=i+1,true);
  },void 0);
 };
 Enumerator.StringEnumerator=function(s)
 {
  return new T$1.New(0,null,function(e)
  {
   var i;
   i=e.s;
   return i<s.length&&(e.c=s[i],e.s=i+1,true);
  },void 0);
 };
 Enumerator.Get0=function(x)
 {
  return x instanceof Global.Array?Enumerator.ArrayEnumerator(x):Unchecked.Equals(typeof x,"string")?Enumerator.StringEnumerator(x):"GetEnumerator0"in x?x.GetEnumerator0():x.GetEnumerator();
 };
 CancellationTokenSource=WebSharper.CancellationTokenSource=Runtime.Class({},Obj,CancellationTokenSource);
 CancellationTokenSource.New=Runtime.Ctor(function()
 {
  Obj.New.call(this);
  this.c=false;
  this.pending=null;
  this.r=[];
  this.init=1;
 },CancellationTokenSource);
 View=UI.View=Runtime.Class({},null,View);
 Snap.WhenRun=function(snap,avail,obs)
 {
  var m;
  m=snap.s;
  if(m==null)
   obs();
  else
   m!=null&&m.$==2?(m.$1.push(obs),avail(m.$0)):m!=null&&m.$==3?(m.$0.push(avail),m.$1.push(obs)):avail(m.$0);
 };
 Snap.Copy=function(sn)
 {
  var m,res,res$1;
  m=sn.s;
  return m==null?sn:m!=null&&m.$==2?(res=Snap.New({
   $:2,
   $0:m.$0,
   $1:[]
  }),(Snap.WhenObsolete(sn,res),res)):m!=null&&m.$==3?(res$1=Snap.New({
   $:3,
   $0:[],
   $1:[]
  }),(Snap.When(sn,function(v)
  {
   Snap.MarkDone(res$1,sn,v);
  },res$1),res$1)):sn;
 };
 Snap.WhenObsoleteRun=function(snap,obs)
 {
  var m;
  m=snap.s;
  if(m==null)
   obs();
  else
   m!=null&&m.$==2?m.$1.push(obs):m!=null&&m.$==3?m.$1.push(obs):void 0;
 };
 Snap.Map2Unit=function(sn1,sn2)
 {
  var $1,$2,res;
  function cont()
  {
   var m,$3,$4;
   if(!(m=res.s,m!=null&&m.$==0||m!=null&&m.$==2))
    {
     $3=Snap.ValueAndForever(sn1);
     $4=Snap.ValueAndForever(sn2);
     if($3!=null&&$3.$==1)
      $4!=null&&$4.$==1?$3.$0[1]&&$4.$0[1]?Snap.MarkForever(res,null):Snap.MarkReady(res,null):void 0;
    }
  }
  $1=sn1.s;
  $2=sn2.s;
  return $1!=null&&$1.$==0?$2!=null&&$2.$==0?Snap.New({
   $:0,
   $0:null
  }):sn2:$2!=null&&$2.$==0?sn1:(res=Snap.New({
   $:3,
   $0:[],
   $1:[]
  }),(Snap.When(sn1,cont,res),Snap.When(sn2,cont,res),res));
 };
 Snap.WhenObsolete=function(snap,obs)
 {
  var m;
  m=snap.s;
  if(m==null)
   Snap.Obsolete(obs);
  else
   m!=null&&m.$==2?Snap.EnqueueSafe(m.$1,obs):m!=null&&m.$==3?Snap.EnqueueSafe(m.$1,obs):void 0;
 };
 Snap.When=function(snap,avail,obs)
 {
  var m;
  m=snap.s;
  if(m==null)
   Snap.Obsolete(obs);
  else
   m!=null&&m.$==2?(Snap.EnqueueSafe(m.$1,obs),avail(m.$0)):m!=null&&m.$==3?(m.$0.push(avail),Snap.EnqueueSafe(m.$1,obs)):avail(m.$0);
 };
 Snap.MarkDone=function(res,sn,v)
 {
  var $1;
  if($1=sn.s,$1!=null&&$1.$==0)
   Snap.MarkForever(res,v);
  else
   Snap.MarkReady(res,v);
 };
 Snap.ValueAndForever=function(snap)
 {
  var m;
  m=snap.s;
  return m!=null&&m.$==0?{
   $:1,
   $0:[m.$0,true]
  }:m!=null&&m.$==2?{
   $:1,
   $0:[m.$0,false]
  }:null;
 };
 Snap.MarkForever=function(sn,v)
 {
  var m,qa,i,$1;
  m=sn.s;
  if(m!=null&&m.$==3)
   {
    sn.s={
     $:0,
     $0:v
    };
    qa=m.$0;
    for(i=0,$1=Arrays.length(qa)-1;i<=$1;i++)(Arrays.get(qa,i))(v);
   }
  else
   void 0;
 };
 Snap.MarkReady=function(sn,v)
 {
  var m,qa,i,$1;
  m=sn.s;
  if(m!=null&&m.$==3)
   {
    sn.s={
     $:2,
     $0:v,
     $1:m.$1
    };
    qa=m.$0;
    for(i=0,$1=Arrays.length(qa)-1;i<=$1;i++)(Arrays.get(qa,i))(v);
   }
  else
   void 0;
 };
 Snap.EnqueueSafe=function(q,x)
 {
  var qcopy,i,$1,o;
  q.push(x);
  if(q.length%20===0)
   {
    qcopy=q.slice(0);
    Queue.Clear(q);
    for(i=0,$1=Arrays.length(qcopy)-1;i<=$1;i++){
     o=Arrays.get(qcopy,i);
     if(typeof o=="object")
      (function(sn)
      {
       if(sn.s)
        q.push(sn);
      }(o));
     else
      (function(f)
      {
       q.push(f);
      }(o));
    }
   }
  else
   void 0;
 };
 Snap.Map=function(fn,sn)
 {
  var m,res;
  m=sn.s;
  return m!=null&&m.$==0?Snap.New({
   $:0,
   $0:fn(m.$0)
  }):(res=Snap.New({
   $:3,
   $0:[],
   $1:[]
  }),(Snap.When(sn,function(a)
  {
   Snap.MarkDone(res,sn,fn(a));
  },res),res));
 };
 SC$3.$cctor=function()
 {
  SC$3.$cctor=Global.ignore;
  SC$3.LoadedTemplates=new Dictionary.New$5();
  SC$3.LocalTemplatesLoaded=false;
  SC$3.GlobalHoles=new Dictionary.New$5();
  SC$3.TextHoleRE="\\${([^}]+)}";
  SC$3.RenderedFullDocTemplate=null;
 };
 HashSet=Collections.HashSet=Runtime.Class({
  SAdd:function(item)
  {
   return this.add(item);
  },
  Contains:function(item)
  {
   var arr;
   arr=this.data[this.hash(item)];
   return arr==null?false:this.arrContains(item,arr);
  },
  add:function(item)
  {
   var h,arr;
   h=this.hash(item);
   arr=this.data[h];
   return arr==null?(this.data[h]=[item],this.count=this.count+1,true):this.arrContains(item,arr)?false:(arr.push(item),this.count=this.count+1,true);
  },
  arrContains:function(item,arr)
  {
   var c,i,$1,l;
   c=true;
   i=0;
   l=arr.length;
   while(c&&i<l)
    if(this.equals.apply(null,[arr[i],item]))
     c=false;
    else
     i=i+1;
   return!c;
  },
  GetEnumerator:function()
  {
   return Enumerator.Get(HashSetUtil.concat(this.data));
  },
  ExceptWith:function(xs)
  {
   var e;
   e=Enumerator.Get(xs);
   try
   {
    while(e.MoveNext())
     this.Remove(e.Current());
   }
   finally
   {
    if(typeof e=="object"&&"Dispose"in e)
     e.Dispose();
   }
  },
  Count:function()
  {
   return this.count;
  },
  IntersectWith:function(xs)
  {
   var other,all,i,$1,item;
   other=new HashSet.New$4(xs,this.equals,this.hash);
   all=HashSetUtil.concat(this.data);
   for(i=0,$1=all.length-1;i<=$1;i++){
    item=all[i];
    if(!other.Contains(item))
     this.Remove(item);
   }
  },
  Remove:function(item)
  {
   var arr;
   arr=this.data[this.hash(item)];
   return arr==null?false:this.arrRemove(item,arr)&&(this.count=this.count-1,true);
  },
  CopyTo:function(arr,index)
  {
   var all,i,$1;
   all=HashSetUtil.concat(this.data);
   for(i=0,$1=all.length-1;i<=$1;i++)Arrays.set(arr,i+index,all[i]);
  },
  arrRemove:function(item,arr)
  {
   var c,i,$1,l;
   c=true;
   i=0;
   l=arr.length;
   while(c&&i<l)
    if(this.equals.apply(null,[arr[i],item]))
     {
      arr.splice.apply(arr,[i,1]);
      c=false;
     }
    else
     i=i+1;
   return!c;
  }
 },Obj,HashSet);
 HashSet.New$3=Runtime.Ctor(function()
 {
  HashSet.New$4.call(this,[],Unchecked.Equals,Unchecked.Hash);
 },HashSet);
 HashSet.New$4=Runtime.Ctor(function(init,equals,hash)
 {
  var e;
  Obj.New.call(this);
  this.equals=equals;
  this.hash=hash;
  this.data=[];
  this.count=0;
  e=Enumerator.Get(init);
  try
  {
   while(e.MoveNext())
    this.add(e.Current());
  }
  finally
  {
   if(typeof e=="object"&&"Dispose"in e)
    e.Dispose();
  }
 },HashSet);
 HashSet.New$2=Runtime.Ctor(function(init)
 {
  HashSet.New$4.call(this,init,Unchecked.Equals,Unchecked.Hash);
 },HashSet);
 Seq.head=function(s)
 {
  var e;
  e=Enumerator.Get(s);
  try
  {
   return e.MoveNext()?e.Current():Seq.insufficient();
  }
  finally
  {
   if(typeof e=="object"&&"Dispose"in e)
    e.Dispose();
  }
 };
 Seq.fold=function(f,x,s)
 {
  var r,e;
  r=x;
  e=Enumerator.Get(s);
  try
  {
   while(e.MoveNext())
    r=f(r,e.Current());
   return r;
  }
  finally
  {
   if(typeof e=="object"&&"Dispose"in e)
    e.Dispose();
  }
 };
 Seq.iter=function(p,s)
 {
  var e;
  e=Enumerator.Get(s);
  try
  {
   while(e.MoveNext())
    p(e.Current());
  }
  finally
  {
   if(typeof e=="object"&&"Dispose"in e)
    e.Dispose();
  }
 };
 Seq.map=function(f,s)
 {
  return{
   GetEnumerator:function()
   {
    var en;
    en=Enumerator.Get(s);
    return new T$1.New(null,null,function(e)
    {
     return en.MoveNext()&&(e.c=f(en.Current()),true);
    },function()
    {
     en.Dispose();
    });
   }
  };
 };
 Seq.max=function(s)
 {
  var e,m,x;
  e=Enumerator.Get(s);
  try
  {
   if(!e.MoveNext())
    Seq.seqEmpty();
   m=e.Current();
   while(e.MoveNext())
    {
     x=e.Current();
     if(Unchecked.Compare(x,m)===1)
      m=x;
    }
   return m;
  }
  finally
  {
   if(typeof e=="object"&&"Dispose"in e)
    e.Dispose();
  }
 };
 Seq.forall=function(p,s)
 {
  return!Seq.exists(function(x)
  {
   return!p(x);
  },s);
 };
 Seq.seqEmpty=function()
 {
  return Operators.FailWith("The input sequence was empty.");
 };
 Seq.exists=function(p,s)
 {
  var e,r;
  e=Enumerator.Get(s);
  try
  {
   r=false;
   while(!r&&e.MoveNext())
    r=p(e.Current());
   return r;
  }
  finally
  {
   if(typeof e=="object"&&"Dispose"in e)
    e.Dispose();
  }
 };
 Docs.LinkElement=function(el,children)
 {
  Docs.InsertDoc(el,children,null);
 };
 Docs.InsertDoc=function(parent,doc,pos)
 {
  var d,b,a;
  while(true)
   if(doc!=null&&doc.$==1)
    return Docs.InsertNode(parent,doc.$0.El,pos);
   else
    if(doc!=null&&doc.$==2)
     {
      d=doc.$0;
      d.Dirty=false;
      doc=d.Current;
     }
    else
     if(doc==null)
      return pos;
     else
      if(doc!=null&&doc.$==4)
       return Docs.InsertNode(parent,doc.$0.Text,pos);
      else
       if(doc!=null&&doc.$==5)
        return Docs.InsertNode(parent,doc.$0,pos);
       else
        if(doc!=null&&doc.$==6)
         return Arrays.foldBack(function($1,$2)
         {
          return(((Runtime.Curried3(function(parent$1,el,pos$1)
          {
           return el==null||el.constructor===Object?Docs.InsertDoc(parent$1,el,pos$1):Docs.InsertNode(parent$1,el,pos$1);
          }))(parent))($1))($2);
         },doc.$0.Els,pos);
        else
         {
          b=doc.$1;
          a=doc.$0;
          doc=a;
          pos=Docs.InsertDoc(parent,b,pos);
         }
 };
 Docs.CreateRunState=function(parent,doc)
 {
  return RunState.New(NodeSet.get_Empty(),Docs.CreateElemNode(parent,Attrs.EmptyAttr(),doc));
 };
 Docs.PerformAnimatedUpdate=function(childrenOnly,st,doc)
 {
  var _;
  return An.get_UseAnimations()?(_=null,Concurrency.Delay(function()
  {
   var cur,change,enter;
   cur=NodeSet.FindAll(doc);
   change=Docs.ComputeChangeAnim(st,cur);
   enter=Docs.ComputeEnterAnim(st,cur);
   return Concurrency.Bind(An.Play(An.Append(change,Docs.ComputeExitAnim(st,cur))),function()
   {
    return Concurrency.Bind(Docs.SyncElemNodesNextFrame(childrenOnly,st),function()
    {
     return Concurrency.Bind(An.Play(enter),function()
     {
      st.PreviousNodes=cur;
      return Concurrency.Return(null);
     });
    });
   });
  })):Docs.SyncElemNodesNextFrame(childrenOnly,st);
 };
 Docs.PerformSyncUpdate=function(childrenOnly,st,doc)
 {
  var cur;
  cur=NodeSet.FindAll(doc);
  Docs.SyncElemNode(childrenOnly,st.Top);
  st.PreviousNodes=cur;
 };
 Docs.CreateElemNode=function(el,attr$1,children)
 {
  var attr$2;
  Docs.LinkElement(el,children);
  attr$2=Attrs.Insert(el,attr$1);
  return DocElemNode.New(attr$2,children,null,el,Fresh.Int(),Runtime.GetOptional(attr$2.OnAfterRender));
 };
 Docs.InsertNode=function(parent,node,pos)
 {
  DomUtility.InsertAt(parent,pos,node);
  return node;
 };
 Docs.SyncElemNodesNextFrame=function(childrenOnly,st)
 {
  function a(ok)
  {
   Global.requestAnimationFrame(function()
   {
    Docs.SyncElemNode(childrenOnly,st.Top);
    ok();
   });
  }
  return Settings.BatchUpdatesEnabled()?Concurrency.FromContinuations(function($1,$2,$3)
  {
   return a.apply(null,[$1,$2,$3]);
  }):(Docs.SyncElemNode(childrenOnly,st.Top),Concurrency.Return(null));
 };
 Docs.ComputeExitAnim=function(st,cur)
 {
  return An.Concat(Arrays.map(function(n)
  {
   return Attrs.GetExitAnim(n.Attr);
  },NodeSet.ToArray(NodeSet.Except(cur,NodeSet.Filter(function(n)
  {
   return Attrs.HasExitAnim(n.Attr);
  },st.PreviousNodes)))));
 };
 Docs.ComputeEnterAnim=function(st,cur)
 {
  return An.Concat(Arrays.map(function(n)
  {
   return Attrs.GetEnterAnim(n.Attr);
  },NodeSet.ToArray(NodeSet.Except(st.PreviousNodes,NodeSet.Filter(function(n)
  {
   return Attrs.HasEnterAnim(n.Attr);
  },cur)))));
 };
 Docs.ComputeChangeAnim=function(st,cur)
 {
  var relevant;
  function a(n)
  {
   return Attrs.HasChangeAnim(n.Attr);
  }
  relevant=function(a$1)
  {
   return NodeSet.Filter(a,a$1);
  };
  return An.Concat(Arrays.map(function(n)
  {
   return Attrs.GetChangeAnim(n.Attr);
  },NodeSet.ToArray(NodeSet.Intersect(relevant(st.PreviousNodes),relevant(cur)))));
 };
 Docs.SyncElemNode=function(childrenOnly,el)
 {
  !childrenOnly?Docs.SyncElement(el):void 0;
  Docs.Sync(el.Children);
  Docs.AfterRender(el);
 };
 Docs.SyncElement=function(el)
 {
  function hasDirtyChildren(el$1)
  {
   function dirty(doc)
   {
    var t,b,a,d;
    while(true)
     {
      if(doc!=null&&doc.$==0)
       {
        b=doc.$1;
        a=doc.$0;
        if(dirty(a))
         return true;
        else
         doc=b;
       }
      else
       if(doc!=null&&doc.$==2)
        {
         d=doc.$0;
         if(d.Dirty)
          return true;
         else
          doc=d.Current;
        }
       else
        return doc!=null&&doc.$==6&&(t=doc.$0,t.Dirty||Arrays.exists(hasDirtyChildren,t.Holes));
     }
   }
   return dirty(el$1.Children);
  }
  Attrs.Sync(el.El,el.Attr);
  if(hasDirtyChildren(el))
   Docs.DoSyncElement(el);
 };
 Docs.Sync=function(doc)
 {
  var d,t,n,b,a;
  while(true)
   {
    if(doc!=null&&doc.$==1)
     return Docs.SyncElemNode(false,doc.$0);
    else
     if(doc!=null&&doc.$==2)
      {
       n=doc.$0;
       doc=n.Current;
      }
     else
      if(doc==null)
       return null;
      else
       if(doc!=null&&doc.$==5)
        return null;
       else
        if(doc!=null&&doc.$==4)
         {
          d=doc.$0;
          return d.Dirty?(d.Text.nodeValue=d.Value,d.Dirty=false):null;
         }
        else
         if(doc!=null&&doc.$==6)
          {
           t=doc.$0;
           Arrays.iter(function(h)
           {
            Docs.SyncElemNode(false,h);
           },t.Holes);
           Arrays.iter(function(t$1)
           {
            Attrs.Sync(t$1[0],t$1[1]);
           },t.Attrs);
           return Docs.AfterRender(t);
          }
         else
          {
           b=doc.$1;
           a=doc.$0;
           Docs.Sync(a);
           doc=b;
          }
   }
 };
 Docs.AfterRender=function(el)
 {
  var m;
  m=Runtime.GetOptional(el.Render);
  if(m!=null&&m.$==1)
   {
    m.$0(el.El);
    Runtime.SetOptional(el,"Render",null);
   }
 };
 Docs.DoSyncElement=function(el)
 {
  var parent,p,m;
  function ins(doc,pos)
  {
   var t,d,b,a;
   while(true)
    {
     if(doc!=null&&doc.$==1)
      return doc.$0.El;
     else
      if(doc!=null&&doc.$==2)
       {
        d=doc.$0;
        if(d.Dirty)
         {
          d.Dirty=false;
          return Docs.InsertDoc(parent,d.Current,pos);
         }
        else
         doc=d.Current;
       }
      else
       if(doc==null)
        return pos;
       else
        if(doc!=null&&doc.$==4)
         return doc.$0.Text;
        else
         if(doc!=null&&doc.$==5)
          return doc.$0;
         else
          if(doc!=null&&doc.$==6)
           {
            t=doc.$0;
            t.Dirty?t.Dirty=false:void 0;
            return Arrays.foldBack(function($1,$2)
            {
             return $1==null||$1.constructor===Object?ins($1,$2):$1;
            },t.Els,pos);
           }
          else
           {
            b=doc.$1;
            a=doc.$0;
            doc=a;
            pos=ins(b,pos);
           }
    }
  }
  parent=el.El;
  DomNodes.Iter((p=el.El,function(e)
  {
   DomUtility.RemoveNode(p,e);
  }),DomNodes.Except(DomNodes.DocChildren(el),DomNodes.Children(el.El,Runtime.GetOptional(el.Delimiters))));
  ins(el.Children,(m=Runtime.GetOptional(el.Delimiters),m!=null&&m.$==1?m.$0[1]:null));
 };
 Elt=UI.Elt=Runtime.Class({},Doc,Elt);
 Elt.New=function(el,attr$1,children)
 {
  var node,rvUpdates;
  node=Docs.CreateElemNode(el,attr$1,children.docNode);
  rvUpdates=Updates.Create(children.updates);
  return new Elt.New$1({
   $:1,
   $0:node
  },View.Map2Unit(Attrs.Updates(node.Attr),rvUpdates.v),el,rvUpdates);
 };
 Elt.New$1=Runtime.Ctor(function(docNode,updates,elt,rvUpdates)
 {
  Doc.New.call(this,docNode,updates);
  this.docNode$1=docNode;
  this.updates$1=updates;
  this.elt=elt;
  this.rvUpdates=rvUpdates;
 },Elt);
 Array.ofSeqNonCopying=function(xs)
 {
  var q,o;
  if(xs instanceof Global.Array)
   return xs;
  else
   if(xs instanceof T)
    return Arrays.ofList(xs);
   else
    if(xs===null)
     return[];
    else
     {
      q=[];
      o=Enumerator.Get(xs);
      try
      {
       while(o.MoveNext())
        q.push(o.Current());
       return q;
      }
      finally
      {
       if(typeof o=="object"&&"Dispose"in o)
        o.Dispose();
      }
     }
 };
 Array.TreeReduce=function(defaultValue,reduction,array)
 {
  var l;
  function loop(off)
  {
   return function(len)
   {
    var $1,l2;
    switch(len<=0?0:len===1?off>=0&&off<l?1:($1=len,2):($1=len,2))
    {
     case 0:
      return defaultValue;
     case 1:
      return Arrays.get(array,off);
     case 2:
      l2=len/2>>0;
      return reduction((loop(off))(l2),(loop(off+l2))(len-l2));
    }
   };
  }
  l=Arrays.length(array);
  return(loop(0))(l);
 };
 Array.MapTreeReduce=function(mapping,defaultValue,reduction,array)
 {
  var l;
  function loop(off)
  {
   return function(len)
   {
    var $1,l2;
    switch(len<=0?0:len===1?off>=0&&off<l?1:($1=len,2):($1=len,2))
    {
     case 0:
      return defaultValue;
     case 1:
      return mapping(Arrays.get(array,off));
     case 2:
      l2=len/2>>0;
      return reduction((loop(off))(l2),(loop(off+l2))(len-l2));
    }
   };
  }
  l=Arrays.length(array);
  return(loop(0))(l);
 };
 DocElemNode=UI.DocElemNode=Runtime.Class({
  Equals:function(o)
  {
   return this.ElKey===o.ElKey;
  },
  GetHashCode:function()
  {
   return this.ElKey;
  }
 },null,DocElemNode);
 DocElemNode.New=function(Attr,Children,Delimiters,El,ElKey,Render)
 {
  var $1;
  return new DocElemNode(($1={
   Attr:Attr,
   Children:Children,
   El:El,
   ElKey:ElKey
  },(Runtime.SetOptional($1,"Delimiters",Delimiters),Runtime.SetOptional($1,"Render",Render),$1)));
 };
 DictionaryUtil.notPresent=function()
 {
  return Operators.FailWith("The given key was not present in the dictionary.");
 };
 Prepare.convertTextNode=function(n)
 {
  var m,li,$1,s,strRE,hole;
  m=null;
  li=0;
  s=n.textContent;
  strRE=new Global.RegExp(Templates.TextHoleRE(),"g");
  while(m=strRE.exec(s),m!==null)
   {
    n.parentNode.insertBefore(self.document.createTextNode(Slice.string(s,{
     $:1,
     $0:li
    },{
     $:1,
     $0:strRE.lastIndex-Arrays.get(m,0).length-1
    })),n);
    li=strRE.lastIndex;
    hole=self.document.createElement("span");
    hole.setAttribute("ws-replace",Arrays.get(m,1).toLowerCase());
    n.parentNode.insertBefore(hole,n);
   }
  strRE.lastIndex=0;
  n.textContent=Slice.string(s,{
   $:1,
   $0:li
  },null);
 };
 Prepare.failNotLoaded=function(name)
 {
  console.warn("Instantiating non-loaded template",name);
 };
 Prepare.fillTextHole=function(instance,fillWith,templateName)
 {
  var m;
  m=instance.querySelector("[ws-replace]");
  return Unchecked.Equals(m,null)?(console.warn("Filling non-existent text hole",templateName),null):(m.parentNode.replaceChild(self.document.createTextNode(fillWith),m),{
   $:1,
   $0:m.getAttribute("ws-replace")
  });
 };
 Prepare.removeHolesExcept=function(instance,dontRemove)
 {
  function run(attrName)
  {
   Templates.foreachNotPreserved(instance,"["+attrName+"]",function(e)
   {
    if(!dontRemove.Contains(e.getAttribute(attrName)))
     e.removeAttribute(attrName);
   });
  }
  run("ws-attr");
  run("ws-onafterrender");
  run("ws-var");
  Templates.foreachNotPreserved(instance,"[ws-hole]",function(e)
  {
   if(!dontRemove.Contains(e.getAttribute("ws-hole")))
    {
     e.removeAttribute("ws-hole");
     while(e.hasChildNodes())
      e.removeChild(e.lastChild);
    }
  });
  Templates.foreachNotPreserved(instance,"[ws-replace]",function(e)
  {
   if(!dontRemove.Contains(e.getAttribute("ws-replace")))
    e.parentNode.removeChild(e);
  });
  Templates.foreachNotPreserved(instance,"[ws-on]",function(e)
  {
   e.setAttribute("ws-on",Strings.concat(" ",Arrays.filter(function(x)
   {
    return dontRemove.Contains(Arrays.get(Strings.SplitChars(x,[":"],1),1));
   },Strings.SplitChars(e.getAttribute("ws-on"),[" "],1))));
  });
  Templates.foreachNotPreserved(instance,"[ws-attr-holes]",function(e)
  {
   var holeAttrs,i,$1,attrName,_this;
   holeAttrs=Strings.SplitChars(e.getAttribute("ws-attr-holes"),[" "],1);
   for(i=0,$1=holeAttrs.length-1;i<=$1;i++){
    attrName=Arrays.get(holeAttrs,i);
    e.setAttribute(attrName,(_this=new Global.RegExp(Templates.TextHoleRE(),"g"),e.getAttribute(attrName).replace(_this,function($2,$3)
    {
     return dontRemove.Contains($3)?$2:"";
    })));
   }
  });
 };
 Prepare.fillInstanceAttrs=function(instance,fillWith)
 {
  var name,m,i,$1,a;
  Prepare.convertAttrs(fillWith);
  name=fillWith.nodeName.toLowerCase();
  m=instance.querySelector("[ws-attr="+name+"]");
  if(Unchecked.Equals(m,null))
   console.warn("Filling non-existent attr hole",name);
  else
   {
    m.removeAttribute("ws-attr");
    for(i=0,$1=fillWith.attributes.length-1;i<=$1;i++){
     a=fillWith.attributes.item(i);
     if(a.name==="class"&&m.hasAttribute("class"))
      m.setAttribute("class",m.getAttribute("class")+" "+a.nodeValue);
     else
      m.setAttribute(a.name,a.nodeValue);
    }
   }
 };
 Prepare.mapHoles=function(t,mappings)
 {
  function run(attrName)
  {
   Templates.foreachNotPreserved(t,"["+attrName+"]",function(e)
   {
    var m,o;
    m=(o=null,[mappings.TryGetValue(e.getAttribute(attrName).toLowerCase(),{
     get:function()
     {
      return o;
     },
     set:function(v)
     {
      o=v;
     }
    }),o]);
    if(m[0])
     e.setAttribute(attrName,m[1]);
   });
  }
  run("ws-hole");
  run("ws-replace");
  run("ws-attr");
  run("ws-onafterrender");
  run("ws-var");
  Templates.foreachNotPreserved(t,"[ws-on]",function(e)
  {
   e.setAttribute("ws-on",Strings.concat(" ",Arrays.map(function(x)
   {
    var a,m,o;
    a=Strings.SplitChars(x,[":"],1);
    m=(o=null,[mappings.TryGetValue(Arrays.get(a,1),{
     get:function()
     {
      return o;
     },
     set:function(v)
     {
      o=v;
     }
    }),o]);
    return m[0]?Arrays.get(a,0)+":"+m[1]:x;
   },Strings.SplitChars(e.getAttribute("ws-on"),[" "],1))));
  });
  Templates.foreachNotPreserved(t,"[ws-attr-holes]",function(e)
  {
   var holeAttrs,i,$1;
   holeAttrs=Strings.SplitChars(e.getAttribute("ws-attr-holes"),[" "],1);
   for(i=0,$1=holeAttrs.length-1;i<=$1;i++)(function()
   {
    var attrName;
    function f(s,a)
    {
     var a$1;
     a$1=Operators.KeyValue(a);
     return s.replace(new Global.RegExp("\\${"+a$1[0]+"}","ig"),"${"+a$1[1]+"}");
    }
    attrName=Arrays.get(holeAttrs,i);
    return e.setAttribute(attrName,(((Runtime.Curried3(Seq.fold))(f))(e.getAttribute(attrName)))(mappings));
   }());
  });
 };
 Prepare.fill=function(fillWith,p,n)
 {
  while(true)
   if(fillWith.hasChildNodes())
    n=p.insertBefore(fillWith.lastChild,n);
   else
    return null;
 };
 Prepare.convertAttrs=function(el)
 {
  var attrs,toRemove,events,holedAttrs,i,$1,a,_this;
  function lowercaseAttr(name)
  {
   var m;
   m=el.getAttribute(name);
   if(m===null)
    ;
   else
    el.setAttribute(name,m.toLowerCase());
  }
  attrs=el.attributes;
  toRemove=[];
  events=[];
  holedAttrs=[];
  for(i=0,$1=attrs.length-1;i<=$1;i++){
   a=attrs.item(i);
   if(Strings.StartsWith(a.nodeName,"ws-on")&&a.nodeName!=="ws-onafterrender"&&a.nodeName!=="ws-on")
    {
     toRemove.push(a.nodeName);
     events.push(Slice.string(a.nodeName,{
      $:1,
      $0:"ws-on".length
     },null)+":"+a.nodeValue.toLowerCase());
    }
   else
    !Strings.StartsWith(a.nodeName,"ws-")&&(new Global.RegExp(Templates.TextHoleRE())).test(a.nodeValue)?(a.nodeValue=(_this=new Global.RegExp(Templates.TextHoleRE(),"g"),a.nodeValue.replace(_this,function($2,$3)
    {
     return"${"+$3.toLowerCase()+"}";
    })),holedAttrs.push(a.nodeName)):void 0;
  }
  if(!(events.length==0))
   el.setAttribute("ws-on",Strings.concat(" ",events));
  if(!(holedAttrs.length==0))
   el.setAttribute("ws-attr-holes",Strings.concat(" ",holedAttrs));
  lowercaseAttr("ws-hole");
  lowercaseAttr("ws-replace");
  lowercaseAttr("ws-attr");
  lowercaseAttr("ws-onafterrender");
  lowercaseAttr("ws-var");
  Arrays.iter(function(a$1)
  {
   el.removeAttribute(a$1);
  },toRemove);
 };
 Slice.string=function(source,start,finish)
 {
  var f,f$1;
  return start==null?finish!=null&&finish.$==1?(f=finish.$0,f<0?"":source.slice(0,f+1)):"":finish==null?source.slice(start.$0):(f$1=finish.$0,f$1<0?"":source.slice(start.$0,f$1+1));
 };
 Seq.insufficient=function()
 {
  return Operators.FailWith("The input sequence has an insufficient number of elements.");
 };
 KeyCollection=Collections.KeyCollection=Runtime.Class({
  GetEnumerator:function()
  {
   return Enumerator.Get(Seq.map(function(kvp)
   {
    return kvp.K;
   },this.d));
  }
 },Obj,KeyCollection);
 KeyCollection.New=Runtime.Ctor(function(d)
 {
  Obj.New.call(this);
  this.d=d;
 },KeyCollection);
 Numeric.TryParseInt32=function(s,r)
 {
  return Numeric.TryParse(s,-2147483648,2147483647,r);
 };
 An.get_UseAnimations=function()
 {
  return Anims.UseAnimations();
 };
 An.Play=function(anim)
 {
  var _;
  _=null;
  return Concurrency.Delay(function()
  {
   return Concurrency.Bind(An.Run(Global.ignore,Anims.Actions(anim)),function()
   {
    Anims.Finalize(anim);
    return Concurrency.Return(null);
   });
  });
 };
 An.Append=function(a,a$1)
 {
  return{
   $:0,
   $0:AppendList.Append(a.$0,a$1.$0)
  };
 };
 An.Run=function(k,anim)
 {
  var dur;
  function a(ok)
  {
   function loop(start)
   {
    return function(now)
    {
     var t;
     t=now-start;
     anim.Compute(t);
     k();
     return t<=dur?void Global.requestAnimationFrame(function(t$1)
     {
      (loop(start))(t$1);
     }):ok();
    };
   }
   Global.requestAnimationFrame(function(t)
   {
    (loop(t))(t);
   });
  }
  dur=anim.Duration;
  return dur===0?Concurrency.Zero():Concurrency.FromContinuations(function($1,$2,$3)
  {
   return a.apply(null,[$1,$2,$3]);
  });
 };
 An.Concat=function(xs)
 {
  return{
   $:0,
   $0:AppendList.Concat(Seq.map(Anims.List,xs))
  };
 };
 Settings.BatchUpdatesEnabled=function()
 {
  SC$4.$cctor();
  return SC$4.BatchUpdatesEnabled;
 };
 Mailbox.StartProcessor=function(procAsync)
 {
  var st;
  function work()
  {
   var _;
   _=null;
   return Concurrency.Delay(function()
   {
    return Concurrency.Bind(procAsync,function()
    {
     var m;
     m=st[0];
     return Unchecked.Equals(m,1)?(st[0]=0,Concurrency.Zero()):Unchecked.Equals(m,2)?(st[0]=1,work()):Concurrency.Zero();
    });
   });
  }
  st=[0];
  return function()
  {
   var m;
   m=st[0];
   if(Unchecked.Equals(m,0))
    {
     st[0]=1;
     Concurrency.Start(work(),null);
    }
   else
    Unchecked.Equals(m,1)?st[0]=2:void 0;
  };
 };
 Updates=UI.Updates=Runtime.Class({},null,Updates);
 Updates.Create=function(v)
 {
  var _var;
  _var=null;
  _var=Updates.New(v,null,function()
  {
   var c;
   c=_var.s;
   return c===null?(c=Snap.Copy(_var.c()),_var.s=c,Snap.WhenObsoleteRun(c,function()
   {
    _var.s=null;
   }),c):c;
  });
  return _var;
 };
 Updates.New=function(Current,Snap$1,VarView)
 {
  return new Updates({
   c:Current,
   s:Snap$1,
   v:VarView
  });
 };
 T$1=Enumerator.T=Runtime.Class({
  Dispose:function()
  {
   if(this.d)
    this.d(this);
  },
  MoveNext:function()
  {
   var m;
   m=this.n(this);
   this.e=m?1:2;
   return m;
  },
  Current:function()
  {
   return this.e===1?this.c:this.e===0?Operators.FailWith("Enumeration has not started. Call MoveNext."):Operators.FailWith("Enumeration already finished.");
  }
 },Obj,T$1);
 T$1.New=Runtime.Ctor(function(s,c,n,d)
 {
  Obj.New.call(this);
  this.s=s;
  this.c=c;
  this.n=n;
  this.d=d;
  this.e=0;
 },T$1);
 Dyn.New=function(DynElem,DynFlags,DynNodes,OnAfterRender)
 {
  var $1;
  $1={
   DynElem:DynElem,
   DynFlags:DynFlags,
   DynNodes:DynNodes
  };
  Runtime.SetOptional($1,"OnAfterRender",OnAfterRender);
  return $1;
 };
 Snap.Obsolete=function(sn)
 {
  var $1,m,i,$2,o;
  m=sn.s;
  if(m==null||(m!=null&&m.$==2?($1=m.$1,false):m!=null&&m.$==3?($1=m.$1,false):true))
   void 0;
  else
   {
    sn.s=null;
    for(i=0,$2=Arrays.length($1)-1;i<=$2;i++){
     o=Arrays.get($1,i);
     if(typeof o=="object")
      (function(sn$1)
      {
       Snap.Obsolete(sn$1);
      }(o));
     else
      o();
    }
   }
 };
 Snap.New=function(State)
 {
  return{
   s:State
  };
 };
 Strings.concat=function(separator,strings)
 {
  return Arrays.ofSeq(strings).join(separator);
 };
 Strings.SplitChars=function(s,sep,opts)
 {
  return Strings.Split(s,new Global.RegExp("["+Strings.RegexEscape(sep.join(""))+"]"),opts);
 };
 Strings.StartsWith=function(t,s)
 {
  return t.substring(0,s.length)==s;
 };
 Strings.Split=function(s,pat,opts)
 {
  return opts===1?Arrays.filter(function(x)
  {
   return x!=="";
  },Strings.SplitWith(s,pat)):Strings.SplitWith(s,pat);
 };
 Strings.RegexEscape=function(s)
 {
  return s.replace(new Global.RegExp("[-\\/\\\\^$*+?.()|[\\]{}]","g"),"\\$&");
 };
 Strings.SplitWith=function(str,pat)
 {
  return str.split(pat);
 };
 Strings.forall=function(f,s)
 {
  return Seq.forall(f,Strings.protect(s));
 };
 Strings.protect=function(s)
 {
  return s===null?"":s;
 };
 RunState.New=function(PreviousNodes,Top)
 {
  return{
   PreviousNodes:PreviousNodes,
   Top:Top
  };
 };
 NodeSet.get_Empty=function()
 {
  return{
   $:0,
   $0:new HashSet.New$3()
  };
 };
 NodeSet.FindAll=function(doc)
 {
  var q;
  function recF(recI,$1)
  {
   var x,b,a,el,em;
   while(true)
    switch(recI)
    {
     case 0:
      if($1!=null&&$1.$==0)
       {
        b=$1.$1;
        a=$1.$0;
        recF(0,a);
        $1=b;
       }
      else
       if($1!=null&&$1.$==1)
        {
         el=$1.$0;
         $1=el;
         recI=1;
        }
       else
        if($1!=null&&$1.$==2)
         {
          em=$1.$0;
          $1=em.Current;
         }
        else
         return $1!=null&&$1.$==6?(x=$1.$0.Holes,(function(a$1)
         {
          return function(a$2)
          {
           Arrays.iter(a$1,a$2);
          };
         }(loopEN))(x)):null;
      break;
     case 1:
      q.push($1);
      $1=$1.Children;
      recI=0;
      break;
    }
  }
  function loop(node)
  {
   return recF(0,node);
  }
  function loopEN(el)
  {
   return recF(1,el);
  }
  q=[];
  loop(doc);
  return{
   $:0,
   $0:new HashSet.New$2(q)
  };
 };
 NodeSet.Filter=function(f,a)
 {
  return{
   $:0,
   $0:HashSet$1.Filter(f,a.$0)
  };
 };
 NodeSet.Except=function(a,a$1)
 {
  return{
   $:0,
   $0:HashSet$1.Except(a.$0,a$1.$0)
  };
 };
 NodeSet.ToArray=function(a)
 {
  return HashSet$1.ToArray(a.$0);
 };
 NodeSet.Intersect=function(a,a$1)
 {
  return{
   $:0,
   $0:HashSet$1.Intersect(a.$0,a$1.$0)
  };
 };
 Anims.UseAnimations=function()
 {
  SC$7.$cctor();
  return SC$7.UseAnimations;
 };
 Anims.Actions=function(a)
 {
  return Anims.ConcatActions(Arrays.choose(function(a$1)
  {
   return a$1.$==1?{
    $:1,
    $0:a$1.$0
   }:null;
  },AppendList.ToArray(a.$0)));
 };
 Anims.Finalize=function(a)
 {
  Arrays.iter(function(a$1)
  {
   if(a$1.$==0)
    a$1.$0();
  },AppendList.ToArray(a.$0));
 };
 Anims.ConcatActions=function(xs)
 {
  var xs$1,m,dur,xs$2;
  xs$1=Array.ofSeqNonCopying(xs);
  m=Arrays.length(xs$1);
  return m===0?Anims.Const():m===1?Arrays.get(xs$1,0):(dur=Seq.max(Seq.map(function(anim)
  {
   return anim.Duration;
  },xs$1)),(xs$2=Arrays.map(function(x)
  {
   return Anims.Prolong(dur,x);
  },xs$1),Anims.Def(dur,function(t)
  {
   Arrays.iter(function(anim)
   {
    anim.Compute(t);
   },xs$2);
  })));
 };
 Anims.List=function(a)
 {
  return a.$0;
 };
 Anims.Const=function(v)
 {
  return Anims.Def(0,function()
  {
   return v;
  });
 };
 Anims.Def=function(d,f)
 {
  return{
   Compute:f,
   Duration:d
  };
 };
 Anims.Prolong=function(nextDuration,anim)
 {
  var comp,dur,last;
  comp=anim.Compute;
  dur=anim.Duration;
  last=Lazy.Create(function()
  {
   return anim.Compute(anim.Duration);
  });
  return{
   Compute:function(t)
   {
    return t>=dur?last.f():comp(t);
   },
   Duration:nextDuration
  };
 };
 SC$4.$cctor=function()
 {
  SC$4.$cctor=Global.ignore;
  SC$4.BatchUpdatesEnabled=true;
 };
 Fresh.Int=function()
 {
  Fresh.set_counter(Fresh.counter()+1);
  return Fresh.counter();
 };
 Fresh.set_counter=function($1)
 {
  SC$8.$cctor();
  SC$8.counter=$1;
 };
 Fresh.counter=function()
 {
  SC$8.$cctor();
  return SC$8.counter;
 };
 SC$5.$cctor=function()
 {
  var g,s,g$1,s$1,g$2,s$2,g$3,s$3,g$4,s$4;
  SC$5.$cctor=Global.ignore;
  SC$5.EmptyAttr=null;
  SC$5.BoolCheckedApply=function(_var)
  {
   function set(el,v)
   {
    return v!=null&&v.$==1?void(el.checked=v.$0):null;
   }
   return[function(el)
   {
    el.addEventListener("change",function()
    {
     return!Unchecked.Equals(_var.Get(),el.checked)?_var.Set(el.checked):null;
    });
   },function($1)
   {
    return function($2)
    {
     return set($1,$2);
    };
   },View.Map(function(a)
   {
    return{
     $:1,
     $0:a
    };
   },_var.get_View())];
  };
  SC$5.StringSet=function(el)
  {
   return function(s$5)
   {
    el.value=s$5;
   };
  };
  SC$5.StringGet=function(el)
  {
   return{
    $:1,
    $0:el.value
   };
  };
  SC$5.StringApply=(g=BindVar.StringGet(),(s=BindVar.StringSet(),function(v)
  {
   return BindVar.ApplyValue(g,s,v);
  }));
  SC$5.IntSetUnchecked=function(el)
  {
   return function(i)
   {
    el.value=Global.String(i);
   };
  };
  SC$5.IntGetUnchecked=function(el)
  {
   var s$5,pd;
   s$5=el.value;
   return String.isBlank(s$5)?{
    $:1,
    $0:0
   }:(pd=+s$5,pd!==pd>>0?null:{
    $:1,
    $0:pd
   });
  };
  SC$5.IntApplyUnchecked=(g$1=BindVar.IntGetUnchecked(),(s$1=BindVar.IntSetUnchecked(),function(v)
  {
   return BindVar.ApplyValue(g$1,s$1,v);
  }));
  SC$5.IntSetChecked=function(el)
  {
   return function(i)
   {
    var i$1;
    i$1=i.get_Input();
    return el.value!==i$1?void(el.value=i$1):null;
   };
  };
  SC$5.IntGetChecked=function(el)
  {
   var s$5,m,o;
   s$5=el.value;
   return{
    $:1,
    $0:String.isBlank(s$5)?(el.checkValidity?el.checkValidity():true)?new CheckedInput({
     $:2,
     $0:s$5
    }):new CheckedInput({
     $:1,
     $0:s$5
    }):(m=(o=0,[Numeric.TryParseInt32(s$5,{
     get:function()
     {
      return o;
     },
     set:function(v)
     {
      o=v;
     }
    }),o]),m[0]?new CheckedInput({
     $:0,
     $0:m[1],
     $1:s$5
    }):new CheckedInput({
     $:1,
     $0:s$5
    }))
   };
  };
  SC$5.IntApplyChecked=(g$2=BindVar.IntGetChecked(),(s$2=BindVar.IntSetChecked(),function(v)
  {
   return BindVar.ApplyValue(g$2,s$2,v);
  }));
  SC$5.FloatSetUnchecked=function(el)
  {
   return function(i)
   {
    el.value=Global.String(i);
   };
  };
  SC$5.FloatGetUnchecked=function(el)
  {
   var s$5,pd;
   s$5=el.value;
   return String.isBlank(s$5)?{
    $:1,
    $0:0
   }:(pd=+s$5,Global.isNaN(pd)?null:{
    $:1,
    $0:pd
   });
  };
  SC$5.FloatApplyUnchecked=(g$3=BindVar.FloatGetUnchecked(),(s$3=BindVar.FloatSetUnchecked(),function(v)
  {
   return BindVar.ApplyValue(g$3,s$3,v);
  }));
  SC$5.FloatSetChecked=function(el)
  {
   return function(i)
   {
    var i$1;
    i$1=i.get_Input();
    return el.value!==i$1?void(el.value=i$1):null;
   };
  };
  SC$5.FloatGetChecked=function(el)
  {
   var s$5,i;
   s$5=el.value;
   return{
    $:1,
    $0:String.isBlank(s$5)?(el.checkValidity?el.checkValidity():true)?new CheckedInput({
     $:2,
     $0:s$5
    }):new CheckedInput({
     $:1,
     $0:s$5
    }):(i=+s$5,Global.isNaN(i)?new CheckedInput({
     $:1,
     $0:s$5
    }):new CheckedInput({
     $:0,
     $0:i,
     $1:s$5
    }))
   };
  };
  SC$5.FloatApplyChecked=(g$4=BindVar.FloatGetChecked(),(s$4=BindVar.FloatSetChecked(),function(v)
  {
   return BindVar.ApplyValue(g$4,s$4,v);
  }));
 };
 SC$6.$cctor=function()
 {
  var table;
  SC$6.$cctor=Global.ignore;
  SC$6.rxhtmlTag=new Global.RegExp("<(?!area|br|col|embed|hr|img|input|link|meta|param)(([\\w:]+)[^>]*)\\/>","gi");
  SC$6.rtagName=new Global.RegExp("<([\\w:]+)");
  SC$6.rhtml=new Global.RegExp("<|&#?\\w+;");
  SC$6.wrapMap=(table=[1,"<table>","</table>"],{
   option:[1,"<select multiple='multiple'>","</select>"],
   legend:[1,"<fieldset>","</fieldset>"],
   area:[1,"<map>","</map>"],
   param:[1,"<object>","</object>"],
   thead:table,
   tbody:table,
   tfoot:table,
   tr:[2,"<table><tbody>","</tbody></table>"],
   col:[2,"<table><colgroup>","</colgoup></table>"],
   td:[3,"<table><tbody><tr>","</tr></tbody></table>"]
  });
  SC$6.defaultWrap=[0,"",""];
 };
 SC$7.$cctor=function()
 {
  SC$7.$cctor=Global.ignore;
  SC$7.CubicInOut=Easing.Custom(function(t)
  {
   var t2;
   t2=t*t;
   return 3*t2-2*(t2*t);
  });
  SC$7.UseAnimations=true;
 };
 AppendList.Append=function(x,y)
 {
  return x.$==0?y:y.$==0?x:{
   $:2,
   $0:x,
   $1:y
  };
 };
 AppendList.ToArray=function(xs)
 {
  var out;
  function loop(xs$1)
  {
   var y,x;
   while(true)
    if(xs$1.$==1)
     return out.push(xs$1.$0);
    else
     if(xs$1.$==2)
      {
       y=xs$1.$1;
       x=xs$1.$0;
       loop(x);
       xs$1=y;
      }
     else
      return xs$1.$==3?Arrays.iter(function(v)
      {
       out.push(v);
      },xs$1.$0):null;
  }
  out=[];
  loop(xs);
  return out.slice(0);
 };
 AppendList.Concat=function(xs)
 {
  var x;
  x=Array.ofSeqNonCopying(xs);
  return Array.TreeReduce(AppendList.Empty(),AppendList.Append,x);
 };
 AppendList.Empty=function()
 {
  SC$9.$cctor();
  return SC$9.Empty;
 };
 HashSetUtil.concat=function(o)
 {
  var r,k;
  r=[];
  for(var k$1 in o)r.push.apply(r,o[k$1]);
  return r;
 };
 Var=UI.Var=Runtime.Class({},Obj,Var);
 BindVar.ApplyValue=function(get,set,_var)
 {
  var expectedValue;
  function f(a,o)
  {
   return o==null?null:a(o.$0);
  }
  expectedValue=null;
  return[function(el)
  {
   function onChange()
   {
    _var.UpdateMaybe(function(v)
    {
     var $1;
     expectedValue=get(el);
     return expectedValue!=null&&expectedValue.$==1&&(!Unchecked.Equals(expectedValue.$0,v)&&($1=[expectedValue,expectedValue.$0],true))?$1[0]:null;
    });
   }
   el.addEventListener("change",onChange);
   el.addEventListener("input",onChange);
   el.addEventListener("keypress",onChange);
  },function(x)
  {
   var $1;
   $1=set(x);
   return function($2)
   {
    return f($1,$2);
   };
  },View.Map(function(v)
  {
   var $1;
   return expectedValue!=null&&expectedValue.$==1&&(Unchecked.Equals(expectedValue.$0,v)&&($1=expectedValue.$0,true))?null:{
    $:1,
    $0:v
   };
  },_var.get_View())];
 };
 BindVar.StringSet=function()
 {
  SC$5.$cctor();
  return SC$5.StringSet;
 };
 BindVar.StringGet=function()
 {
  SC$5.$cctor();
  return SC$5.StringGet;
 };
 BindVar.IntSetUnchecked=function()
 {
  SC$5.$cctor();
  return SC$5.IntSetUnchecked;
 };
 BindVar.IntGetUnchecked=function()
 {
  SC$5.$cctor();
  return SC$5.IntGetUnchecked;
 };
 BindVar.IntSetChecked=function()
 {
  SC$5.$cctor();
  return SC$5.IntSetChecked;
 };
 BindVar.IntGetChecked=function()
 {
  SC$5.$cctor();
  return SC$5.IntGetChecked;
 };
 BindVar.FloatSetUnchecked=function()
 {
  SC$5.$cctor();
  return SC$5.FloatSetUnchecked;
 };
 BindVar.FloatGetUnchecked=function()
 {
  SC$5.$cctor();
  return SC$5.FloatGetUnchecked;
 };
 BindVar.FloatSetChecked=function()
 {
  SC$5.$cctor();
  return SC$5.FloatSetChecked;
 };
 BindVar.FloatGetChecked=function()
 {
  SC$5.$cctor();
  return SC$5.FloatGetChecked;
 };
 String.isBlank=function(s)
 {
  return Strings.forall(Char.IsWhiteSpace,s);
 };
 CheckedInput=UI.CheckedInput=Runtime.Class({
  get_Input:function()
  {
   return this.$==1?this.$0:this.$==2?this.$0:this.$1;
  }
 },null,CheckedInput);
 Easing=UI.Easing=Runtime.Class({},Obj,Easing);
 Easing.Custom=function(f)
 {
  return new Easing.New(f);
 };
 Easing.New=Runtime.Ctor(function(transformTime)
 {
  Obj.New.call(this);
  this.transformTime=transformTime;
 },Easing);
 HashSet$1.Filter=function(ok,set)
 {
  return new HashSet.New$2(Arrays.filter(ok,HashSet$1.ToArray(set)));
 };
 HashSet$1.Except=function(excluded,included)
 {
  var set;
  set=new HashSet.New$2(HashSet$1.ToArray(included));
  set.ExceptWith(HashSet$1.ToArray(excluded));
  return set;
 };
 HashSet$1.ToArray=function(set)
 {
  var arr;
  arr=Arrays.create(set.Count(),void 0);
  set.CopyTo(arr,0);
  return arr;
 };
 HashSet$1.Intersect=function(a,b)
 {
  var set;
  set=new HashSet.New$2(HashSet$1.ToArray(a));
  set.IntersectWith(HashSet$1.ToArray(b));
  return set;
 };
 SC$8.$cctor=function()
 {
  SC$8.$cctor=Global.ignore;
  SC$8.counter=0;
 };
 Char.IsWhiteSpace=function(c)
 {
  return c.match(new Global.RegExp("\\s"))!==null;
 };
 Numeric.TryParse=function(s,min,max,r)
 {
  var x,ok;
  x=+s;
  ok=x===x-x%1&&x>=min&&x<=max;
  if(ok)
   r.set(x);
  return ok;
 };
 DomNodes.Children=function(elem,delims)
 {
  var n,o,a;
  if(delims!=null&&delims.$==1)
   {
    a=[];
    n=delims.$0[0].nextSibling;
    while(n!==delims.$0[1])
     {
      a.push(n);
      n=n.nextSibling;
     }
    return{
     $:0,
     $0:a
    };
   }
  else
   return{
    $:0,
    $0:Arrays.init(elem.childNodes.length,(o=elem.childNodes,function(a$1)
    {
     return o[a$1];
    }))
   };
 };
 DomNodes.Except=function(a,a$1)
 {
  var excluded;
  excluded=a.$0;
  return{
   $:0,
   $0:Arrays.filter(function(n)
   {
    return Arrays.forall(function(k)
    {
     return!(n===k);
    },excluded);
   },a$1.$0)
  };
 };
 DomNodes.Iter=function(f,a)
 {
  Arrays.iter(f,a.$0);
 };
 DomNodes.DocChildren=function(node)
 {
  var q;
  function loop(doc)
  {
   var x,d,b,a;
   while(true)
    {
     if(doc!=null&&doc.$==2)
      {
       d=doc.$0;
       doc=d.Current;
      }
     else
      if(doc!=null&&doc.$==1)
       return q.push(doc.$0.El);
      else
       if(doc==null)
        return null;
       else
        if(doc!=null&&doc.$==5)
         return q.push(doc.$0);
        else
         if(doc!=null&&doc.$==4)
          return q.push(doc.$0.Text);
         else
          if(doc!=null&&doc.$==6)
           {
            x=doc.$0.Els;
            return(function(a$1)
            {
             return function(a$2)
             {
              Arrays.iter(a$1,a$2);
             };
            }(function(a$1)
            {
             if(a$1==null||a$1.constructor===Object)
              loop(a$1);
             else
              q.push(a$1);
            }))(x);
           }
          else
           {
            b=doc.$1;
            a=doc.$0;
            loop(a);
            doc=b;
           }
    }
  }
  q=[];
  loop(node.Children);
  return{
   $:0,
   $0:Array.ofSeqNonCopying(q)
  };
 };
 Lazy.Create=function(f)
 {
  return LazyRecord.New(false,f,Lazy.forceLazy);
 };
 Lazy.forceLazy=function()
 {
  var v;
  v=this.v();
  this.c=true;
  this.v=v;
  this.f=Lazy.cachedLazy;
  return v;
 };
 Lazy.cachedLazy=function()
 {
  return this.v;
 };
 SC$9.$cctor=function()
 {
  SC$9.$cctor=Global.ignore;
  SC$9.Empty={
   $:0
  };
 };
 Queue.Clear=function(a)
 {
  a.splice(0,Arrays.length(a));
 };
 LazyRecord.New=function(created,evalOrVal,force)
 {
  return{
   c:created,
   v:evalOrVal,
   f:force
  };
 };
 Runtime.OnLoad(function()
 {
  Client.Main();
 });
}(self));


if (typeof WebSharper !=='undefined') {
  WebSharper.Runtime.ScriptBasePath = '/Content/';
  WebSharper.Runtime.Start();
}
