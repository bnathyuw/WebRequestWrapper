namespace WebRequestWrapper
{
	public interface IRequestLogger
	{
		void WriteLine();
		void WriteLine(string format, params object[] arguments);
	}
}