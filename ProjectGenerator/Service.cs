using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Addins;
using MonoDevelop.Projects;

namespace ProjectGenerator
{
	static class Service
	{
		public static IEnumerable<SolutionGenerator> SolutionGenerators =>
			AddinManager.GetExtensionObjects<SolutionGenerator> ("/MonoDevelop/ProjectGenerator/SolutionGenerators");

		public static IEnumerable<FileGenerator> MiscFileGenerators =>
			AddinManager.GetExtensionNodes<FileGeneratorNode>("/MonoDevelop/ProjectGenerator/FileGenerators")
						.Where(x => string.IsNullOrEmpty(x.Language) || x.BuildAction != BuildAction.Compile)
						.Select(x => (FileGenerator)x.GetInstance());

		internal static void Dump (TextWriter tw)
		{
			foreach (var sol in SolutionGenerators)
			{
				tw.WriteLine("Solution Generators:");
				tw.WriteLine($"* {sol.Name}");
				foreach (var projectGenerator in sol.ProjectGenerators)
				{
					tw.WriteLine($"\t* {projectGenerator.Language}");
					foreach (var codeGenerator in projectGenerator.CodeGenerators)
						tw.WriteLine($"\t\t* {codeGenerator.Name}");
				}

				tw.WriteLine();
				tw.WriteLine("Misc file generators:");
				foreach (var gen in MiscFileGenerators)
					tw.WriteLine ($"* {gen.Name}");
			}
		}
	}
}
