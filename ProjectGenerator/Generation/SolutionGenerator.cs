using System;
using System.Collections.Generic;
using MonoDevelop.Core;

namespace ProjectGenerator
{
	public abstract class SolutionGenerator
	{
		public IEnumerable<ProjectGenerator> ProjectGenerators
		{
			get;
		}

		public void Generate(SolutionGenerationOptions opts)
		{
			OnGenerate(opts);
		}

		protected SolutionGenerator (IEnumerable<ProjectGenerator> projectGenerators)
		{
			ProjectGenerators = projectGenerators;
		}

		public abstract string Name { get; }

		protected abstract void OnGenerate(SolutionGenerationOptions opts);
	}
}
