using System;
using MonoDevelop.Projects.Extensions;

namespace ProjectGenerator
{
	class DotNetProjectGenerator : ProjectGenerator
	{
		public DotNetProjectGenerator(DotNetProjectTypeNode node) : base (new [] { node.Language })
		{
		}
	}
}
