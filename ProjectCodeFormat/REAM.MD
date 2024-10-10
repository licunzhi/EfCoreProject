# Code format validation
## reference link
- [overview](https://editorconfig.org/#overview)
- [project-confgiuration](https://github.com/editorconfig/editorconfig/wiki/Projects-Using-EditorConfig)

## configuration file
- [reference](https://editorconfig.org/#overview)
```yml
# EditorConfig is awesome: https://EditorConfig.org# top-most EditorConfig file
root = true # Don't use tabs for indentation.
[*]
indent_style = space # Code files
[*.{cs,csx,vb,vbx}]
indent_size = 4
insert_final_newline = true # Xml project files
[*.{csproj,vbproj,vcxproj,vcxproj.filters,proj,projitems,shproj}]
indent_size = 2 # JSON files
[*.json]
indent_size = 2 # Dotnet code style settings:# C# files
[*.cs]
csharp_preserve_single_line_blocks = true
csharp_preserve_single_line_statements = false
dotnet_style_parentheses_in_arithmetic_binary_operators = always_for_clarity
dotnet_style_predefined_type_for_locals_parameters_members = true
dotnet_style_predefined_type_for_member_access = true
dotnet_style_object_initializer = true
dotnet_style_collection_initializer = true
dotnet_style_explicit_tuple_names = true
dotnet_style_coalesce_expression = true
dotnet_style_null_propagation = true

```
- update based on reference

- export from current project

## husky install
- Husky install
`sudo dotnet tool install --global Husky`

- Husky init
`husky install`

create a new folder in your project


## hooks
.git folder
  - applypatch-msg.sample  
  - commit-msg.sample  
  - fsmonitor-watchman.sample  
  - post-update.sample  
  - pre-applypatch.sample  
  - pre-commit  
  - pre-commit.sample  
  - pre-merge-commit.sample  
  - pre-push.sample  
  - pre-receive.sample  
  - pre-rebase.sample  
  - prepare-commit-msg.sample  
  - push-to-checkout.sample  
  - update.sample

## pre-commit validation
```shell
#!/bin/sh
. "$(dirname "$0")/_/husky.sh"

dotnet format --verify-no-changes

echo 'code format validation by Husky passed!'
```


## All models validation 
### Directory.Build.targets
```xml
<Project>
    <Target Name="FormatCode" BeforeTargets="Build" Condition="'$(CommandName)' != 'ef'">
        <Exec Command="dotnet format --verify-no-changes" />
    </Target>
</Project>
```

- EFCore migrations issue
  - solution
