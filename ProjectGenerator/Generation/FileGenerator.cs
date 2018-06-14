using System;
using System.IO;
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

		public abstract string FileExtension { get; }

		public void Generate(TextWriter writer, FileGenerationOptions options)
		{
			OnGenerate(writer, options);
		}

		protected abstract void OnGenerate(TextWriter writer, FileGenerationOptions options);
	}

	public abstract class CodeGenerator : FileGenerator
	{
	}
}
