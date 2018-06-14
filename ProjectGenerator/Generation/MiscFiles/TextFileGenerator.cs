using System;
using System.IO;

namespace ProjectGenerator
{
	public class TextFileGenerator : FileGenerator
	{
		public override string Name => "Text file";

		public override string FileExtension => ".txt";

		protected override void OnGenerate(TextWriter writer, FileGenerationOptions options)
		{
			for (int i = 0; i < options.LineCount; ++i)
				writer.WriteLine("test");
		}
	}
}
