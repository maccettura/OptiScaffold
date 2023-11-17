<h1 align="center">
  Opti Scaffolder
</h1>
<p align="center">Create new Optimizely blocks & pages with ease, in a simple to used CLI.</p>

## ⚡️ Quick start

Install using the dotnet tool install via your favorite terminal: `dotnet tool install --global OptiScaffold`

## ⚙️ How to use

### `init`

Run the `optiscaffolder init` command at the root of your project. This creates an `opti.scaf` file that contains all the variables needed to scaffold your blocks/pages.

The following parameters are required when running the `optiscaffolder init` command:

`-n` - The namespace root of all pages/blocks. It is recommended to use feature folders in your Optimizely solution so a good example would be: "SomeCompany.Web.Features". Note that "Blocks" and "Pages" will dynamically be added to this namespace when writing files so do not include them in this parameter.

`-b` - The _fully qualified_ class name of the block abstract class base, for example: "SomeCompany.Web.Features.Shared.Blocks.SharedBlockData". 

`-p` - The _fully qualified_ class name of the page abstract class base, for example: "SomeCompany.Web.Features.Shared.Pages.SharedPageData". 

`--blockVm` - The _fully qualified_ class name of base block view model, for example: "SomeCompany.Web.Features.Shared.BlockViewModel". 

`--pagevm` - The _fully qualified_ class name of base page view model, for example: "SomeCompany.Web.Features.Shared.ContentViewModel". 

In the above examples, the command would be:
```shell
optiscaffolder init -n SomeCompany.Web.Features -b SomeCompany.Web.Features.Shared.Blocks.SharedBlockData -p SomeCompany.Web.Features.Shared.Pages.SharedPageData --blockvm SomeCompany.Web.Features.Shared.BlockViewModel --pagevm SomeCompany.Web.Features.Shared.ContentViewModel
```

### `block`

Run the `optiscaffolder block` command in the directory you wish to scaffold a new block in. This will scaffold out all the files needed for a new block, along with creating a new GUID on the block file.

The `block` verb accepts the following required parameters:

`-n` | `--class` - The name of the C# class to create, for example: `TestBlock`. Note that no whitespace is allowed in this parameter. 

`-c` | `--cmsname` - The name that you want to appear as the "DisplayName" in CMS, for example: `"Test Block"`. Spaces are allowed here.

In the above examples, the command would be:
```shell
optiscaffolder block -n TestBlock -c "Test Block"
```

### `page`

Run the `optiscaffolder page` command in the directory you wish to scaffold a new page in. This will scaffold out all the files needed for a new page, along with creating a new GUID on the page file.

The `page` verb accepts the following required parameters:

`-n` | `--class` - The name of the C# class to create, for example: `TestPage`. Note that no whitespace is allowed in this parameter. 

`-c` | `--cmsname` - The name that you want to appear as the "DisplayName" in CMS, for example: `"Test Page"`. Spaces are allowed here.

In the above examples, the command would be:
```shell
optiscaffolder page -n TestPage -c "Test Page"
```
