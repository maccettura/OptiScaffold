// See https://aka.ms/new-console-template for more information
using CommandLine;
using OptiScaffold.Options;
using OptiScaffold.Scaffolders;
using OptiScaffold.Utility;

var blockScaffolder = new AddBlock();
var pageScaffolder = new AddPage();

await Parser.Default
    .ParseArguments<AddBlockOptions, AddPageOptions, InitOptions>(args)
    .MapResult(
    async (AddBlockOptions options) => await blockScaffolder.ScaffoldBlock(options),
    async (AddPageOptions options) => await pageScaffolder.ScaffoldPage(options),
    async (InitOptions options) => await ConfigurationUtility.CreateScafFile(options),
    errors => Task.FromResult(0));