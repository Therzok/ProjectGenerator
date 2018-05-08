using System;
using Mono.Addins;

namespace ProjectGenerator
{
	[ExtensionNode]
	class FileGeneratorNode : TypeExtensionNode
	{
		[NodeAttribute("language")]
		public string Language { get; set; }

		[NodeAttribute("buildAction")]
		public string BuildAction { get; set; } = MonoDevelop.Projects.BuildAction.None;
	}
}
