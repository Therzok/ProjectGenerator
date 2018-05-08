using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Addins;
using MonoDevelop.Projects.Extensions;

namespace ProjectGenerator
{
	class DotNetSolutionGenerator : SolutionGenerator
	{
		const string msbuildItemTypesPath = "/MonoDevelop/ProjectModel/MSBuildItemTypes";

		public override string Name => ".NET";

		static IEnumerable<ProjectGenerator> GetProjectGenerators ()
		{
			var itemTypeNodes = AddinManager.GetExtensionNodes<ExtensionNode>(msbuildItemTypesPath).OfType<DotNetProjectTypeNode>();
			foreach (var itemTypeNode in itemTypeNodes)
				yield return new DotNetProjectGenerator(itemTypeNode);
		}

		public DotNetSolutionGenerator () : base (GetProjectGenerators ())
		{
		}
	}
}
