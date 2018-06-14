using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Addins;
using MonoDevelop.Projects;
using MonoDevelop.Projects.Extensions;

namespace ProjectGenerator
{
	class DotNetSolutionGenerator : SolutionGenerator
	{
		const string msbuildItemTypesPath = "/MonoDevelop/ProjectModel/MSBuildItemTypes";

		public override string Name => ".NET";

		static IEnumerable<ProjectGenerator> GetProjectGenerators ()
		{
			return Enumerable.Empty<ProjectGenerator>();
			/*
			var itemTypeNodes = AddinManager.GetExtensionNodes<ExtensionNode>(msbuildItemTypesPath).OfType<DotNetProjectTypeNode>();
			foreach (var itemTypeNode in itemTypeNodes)
				yield return new DotNetProjectGenerator(itemTypeNode);
				*/
		}

		public DotNetSolutionGenerator () : base (GetProjectGenerators ())
		{
		}

		protected override void OnGenerate(SolutionGenerationOptions opts)
		{
			var solution = new Solution();
			solution.AddConfiguration("", true);
			solution.BaseDirectory = opts.OutputDirectory;
			solution.FileName = "test.sln";

			int i = 0;
			// FIXME: make this addin data based
			foreach (var projectOptions in opts.ProjectOptions)
			{
				var project = GenerateProject(projectOptions, i++);
				solution.DefaultSolutionFolder.AddItem(project);
			}
		}

		Project GenerateProject (ProjectGenerationOptions options, int index)
		{
			var project = Services.ProjectService.CreateDotNetProject(options.Generator.Language);
			project.BaseDirectory = "project" + index;
			project.Name = project + "index";

			int i = 0;
			foreach (var fileOptions in options.FileOptions) {
				var file = GenerateFile (fileOptions, project.BaseDirectory, i++);
				project.Files.Add(file);
			}

			return project;
		}

		ProjectFile GenerateFile (FileGenerationOptions options, string baseDirectory, int index)
		{
			var file = new ProjectFile("/" + index + options.Generator.FileExtension);

			using (var sw = new StreamWriter(Path.Combine (baseDirectory, index + options.Generator.FileExtension))) {
				options.X = index;
				options.Generator.Generate(sw, options);
			}
			return file;
		}
	}
}
