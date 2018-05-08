using System;
using Mono.Addins;

namespace ProjectGenerator
{
	public partial class CodeGeneratorOptions
	{
		public int LinesOfCode { get; set; }
	}

	public abstract class FileGenerator
	{
		public abstract string Name { get; }
	}

	public abstract class CodeGenerator : FileGenerator
	{
	}
}
