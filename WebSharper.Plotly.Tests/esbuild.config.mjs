import { build } from 'esbuild'
import { copyFileSync, mkdirSync } from 'fs'

const name = 'WebSharper.Plotly.Tests'

// The WebSharper-generated module imports the npm `plotly.js-dist-min` package
// (and the WebSharper runtime); bundle it all into a single IIFE for the
// static page.
await build({
  entryPoints: [`./build/${name}.js`],
  bundle: true,
  minify: true,
  format: 'iife',
  outfile: `../dist/Scripts/${name}.min.js`,
  globalName: 'wsbundle'
})

mkdirSync('../dist', { recursive: true })
copyFileSync('./index.html', '../dist/index.html')
copyFileSync('./site.css', '../dist/site.css')

console.log('Bundled:', name)
