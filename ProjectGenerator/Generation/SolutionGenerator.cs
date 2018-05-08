using System;
using System.Collections.Generic;
using MonoDevelop.Core;

namespace ProjectGenerator
{
	public abstract class SolutionGenerator
	{
		protected SolutionGenerator (IEnumerable<ProjectGenerator> projectGenerators)
		{
			ProjectGenerators = projectGenerators;
		}

		public abstract string Name { get; }

		public IEnumerable<ProjectGenerator> ProjectGenerators {
			get;
		}
	}
}
