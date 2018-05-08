using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MonoDevelop.Core;

namespace ProjectGenerator
{
	public class Application : IApplication
	{
		public Task<int> Run(string[] arguments)
		{
			var opts = new Mono.Options.OptionSet {
				{ "list", "Lists all available generators", s => ListGenerators() },
			};

			var remainingArgs = opts.Parse(arguments);
			return Task.FromResult(0);
		}

		void ListGenerators()
		{
			Service.Dump(Console.Out);
		}
	}
}
