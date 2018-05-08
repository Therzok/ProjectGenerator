using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Addins;

namespace ProjectGenerator
{
	public abstract class ProjectGenerator
	{
		public string Language { get; }
		public IEnumerable<FileGenerator> CodeGenerators { get; }

		protected ProjectGenerator (string[] supportedLanguages)
		{
			var codeGeneratorNodes = AddinManager.GetExtensionNodes<FileGeneratorNode>("MonoDevelop/ProjectGenerator/FileGenerators");
			var codeGenerators = new List<FileGenerator>();

			// Maybe only have one instance?
			foreach (var node in codeGeneratorNodes)
			{
				if (!supportedLanguages.Contains(node.Language, StringComparer.OrdinalIgnoreCase))
					continue;

				codeGenerators.Add((FileGenerator)node.CreateInstance());
				continue;
			}

			CodeGenerators = codeGenerators;
			Language = string.Join(", ", supportedLanguages);
		}
	}
}
