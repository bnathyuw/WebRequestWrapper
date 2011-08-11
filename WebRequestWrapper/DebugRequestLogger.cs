using System.Diagnostics;
using System.Linq;

namespace WebRequestWrapper
{
	public class DebugRequestLogger:IRequestLogger
	{
		public void WriteLine() {
			Debug.WriteLine("");
		}

		public void WriteLine(string format, params object[] arguments) {
			if(arguments.Any())
			Debug.WriteLine(format, arguments);
			else Debug.WriteLine(format);
		}
	}
}