using System;
using MonoDevelop.Core;

namespace ProjectGenerator
{
	public class GenerationOptions
	{
		public FilePath OutputDirectory { get; }

		public GenerationOptions(FilePath outputDirectory)
		{
		}
	}
}
