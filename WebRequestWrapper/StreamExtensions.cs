using System.IO;

namespace WebRequestWrapper
{
	public static class StreamExtensions
	{
		public static string ReadAndClose(this Stream inputStream) {
			using(var streamReader = new StreamReader(inputStream)) {
				var responseStream = streamReader.ReadToEnd();
				inputStream.Close();
				return responseStream;
			}
		}
	}
}