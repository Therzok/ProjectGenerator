using System;
using MonoDevelop.Components.Commands;

namespace ProjectGenerator
{
	public enum Commands
	{
		Generate,
	}

	public class GenerateHandler : CommandHandler
	{
		protected override void Run()
		{
			Service.Dump(Console.Out);
		}
	}
}
