# Usage guide

1. Download release archive with template to Visual Studio's project templates folder
	(example: `C:\Users\Job\Documents\Visual Studio 2022\Templates\ProjectTemplates`)
2. Create empty solution via Visual Studio
3. (optional) Generate `.editorconfig` file from Visual Studio properties
	Usable for file-style namespaces for example (for this completing #5 required).
	3.1. Navigate in Visual Studio to Tools => Options => Text Editor => C# => Code Style => General
	3.2. Check your style options - for example, ensure option "**Namespace declarations**" set to "**File**" in "**Code Block**" chapter
	3.3. Generate `.editorconfig` file by pressing "Generate .editorconfig file from settings" in solution root folder
4. Create projects from downloaded template
	4.1. RMB Click by solution in project explorer
	4.2. Choose "Add" => "New Project..."
	4.3. Choose downloaded template from templates list
	4.4. Setup selected template by setting solution name (Note, that to solution name will be appended "**Services**" postfix)
	4.5. Press "Create" button to create projects
5. (optional) To adjust all namespaces to file-area style execute following regex replacement for all sultion:
	expression `namespace\s+(.*?);\s*\n[/\w]`
	replace with `expression namespace $1;\n\n\n$2`

