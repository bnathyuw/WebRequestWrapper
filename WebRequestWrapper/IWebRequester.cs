using System.Net;

namespace WebRequestWrapper
{
	public interface IWebRequester {
		HttpWebResponseWrapper Get(string url);
	}
}