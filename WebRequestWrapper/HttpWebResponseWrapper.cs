using System.Net;

namespace WebRequestWrapper
{
	public class HttpWebResponseWrapper
	{
		private readonly HttpWebResponse _httpWebResponse;
		private readonly string _body;
		private readonly WebException _exception;

		private HttpWebResponseWrapper(HttpWebResponse httpWebResponse) {
			_httpWebResponse = httpWebResponse;
			_body = _httpWebResponse.GetResponseStream().ReadAndClose();
		}

		private HttpWebResponseWrapper(WebException exception):this((HttpWebResponse)exception.Response) {
			_exception = exception;
		}

		public static HttpWebResponseWrapper FromWebResponse(WebResponse httpWebResponse) {
			return new HttpWebResponseWrapper((HttpWebResponse) httpWebResponse);
		}

		public static HttpWebResponseWrapper FromWebException(WebException exception) {
			return new HttpWebResponseWrapper(exception);
		}

		public string Body {
			get { return _body; }
		}

		public HttpStatusCode StatusCode {
			get { return _httpWebResponse.StatusCode; }
		}

		public WebHeaderCollection Headers {
			get { return _httpWebResponse.Headers; }
		}

		public WebException Exception { get { return _exception; } }
	}
}