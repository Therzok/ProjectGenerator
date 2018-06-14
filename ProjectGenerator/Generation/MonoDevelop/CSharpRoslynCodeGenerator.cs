using System;
using System.IO;
using Microsoft.CodeAnalysis.Editing;
using MonoDevelop.Ide.Composition;
using MonoDevelop.Ide.TypeSystem;

namespace ProjectGenerator
{
	class CSharpRoslynCodeGenerator : RoslynCodeGenerator
	{
		public override string Name => "Roslyn C# Generator";

		public override string FileExtension => ".cs";

		protected override void OnGenerate(TextWriter writer, FileGenerationOptions options)
		{
			// HACK: Fix this X.
			writer.WriteLine("class MyClass" + options.X);
			writer.WriteLine("{");
			writer.WriteLine("}");
		}
	}
}
