using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MonoDevelop.Core;

namespace ProjectGenerator
{
	public class SolutionGenerationOptions
	{
		public FilePath OutputDirectory { get; }
		public ProjectGenerationOptions[] ProjectOptions { get; }

		public SolutionGenerationOptions(FilePath outputDirectory, ProjectGenerationOptions[] options)
		{
			OutputDirectory = outputDirectory;
			ProjectOptions = options;
		}

		public static SolutionGenerationOptions Dispersed (FilePath outputDirectory, DisperseOptions options)
		{
			return new SolutionGenerationOptions(outputDirectory, DispersedProjects (options));
		}

		static ProjectGenerationOptions[] DispersedProjects (DisperseOptions options)
		{
			var result = new ProjectGenerationOptions[options.ProjectCount];
			for (int i = 0; i < options.ProjectCount; ++i)
			{
				// TODO: Use stddev to disperse files and loc between projects. for now, hacky equal distribution
				int lineCountInProject = options.LineCount / options.ProjectCount;
				int fileCountInProject = options.FileCount / options.ProjectCount;

				// HACK: Choose a good generator.
				var generator = options.PossibleGenerators.Single(x => x.Language == "C#");

				result[i] = ProjectGenerationOptions.Dispersed (generator, fileCountInProject, lineCountInProject);
			}
			return result;
		}
	}

	public class DisperseOptions
	{
		public int ProjectCount { get; }
		public int LineCount { get; }
		public int FileCount { get; }
		public ProjectGenerator[] PossibleGenerators { get; }

		public int CodeStdDev { get; set; }
		public int FileStdDev { get; set; }

		public DisperseOptions (int projectCount, int fileCount, int lineCount, ProjectGenerator[] possibleGenerators)
		{
			ProjectCount = projectCount;
			LineCount = lineCount;
			FileCount = fileCount;
			PossibleGenerators = possibleGenerators;
		}
	}

	public class ProjectGenerationOptions
	{
		public FileGenerationOptions[] FileOptions { get; }
		internal ProjectGenerator Generator { get; }

		public ProjectGenerationOptions(ProjectGenerator generator, FileGenerationOptions[] options)
		{
			Generator = generator;
			FileOptions = options;
		}

		public static ProjectGenerationOptions Dispersed (ProjectGenerator projectGenerator, int lineCount, int fileCount)
		{
			return new ProjectGenerationOptions(projectGenerator, DispersedFiles(projectGenerator, fileCount, lineCount));
		}

		static FileGenerationOptions[] DispersedFiles(ProjectGenerator projectGenerator, int fileCount, int lineCount)
		{
			var result = new FileGenerationOptions[fileCount];
			for (int i = 0; i < fileCount; ++i)
			{
				// TODO: Use stddev to disperse files and loc between projects. for now, hacky equal distribution
				int linesInFile = lineCount / fileCount;

				// HACK: Choose a good generator.
				var fileGenerator = projectGenerator.CodeGenerators.Single();

				result[i] = new FileGenerationOptions(linesInFile, fileGenerator);
			}
			return result;
		}
	}

	public class FileGenerationOptions
	{
		public int X { get; set; }
		public int LineCount { get; }
		internal FileGenerator Generator { get; }

		// TODO: Directory depth

		public FileGenerationOptions(int lineCount, FileGenerator generator)
		{
			LineCount = lineCount;
			Generator = generator;
		}
	}
}
