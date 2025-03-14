import { build } from 'esbuild'

var options =
{
  entryPoints: ['./build/WebSharper.Plotly.Tests.js'],
  bundle: true,
  minify: true,
  format: 'iife',
  outfile: '../build/Scripts/WebSharper.Plotly.Tests.min.js',
  globalName: 'wsbundle'
};

build(options);

