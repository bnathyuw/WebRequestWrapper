using System;
using System.Linq;

namespace WebRequestWrapper
{
	public class ConsoleRequestLogger:IRequestLogger
	{
		public void WriteLine() {
			Console.WriteLine();
		}

		public void WriteLine(string format, params object[] arguments) {
			if(arguments.Any())
			Console.WriteLine(format, arguments);
			else Console.WriteLine(format);
		}
	}
}