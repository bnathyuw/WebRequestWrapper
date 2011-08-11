using System;
using System.Net;

namespace WebRequestWrapper
{
	public class WebRequester : IWebRequester
	{
		private readonly IRequestLogger _logger;

		public WebRequester(IRequestLogger logger) {
			_logger = logger;
		}

		public HttpWebResponseWrapper Get(string url) {
			var request = WebRequest.Create(url);

			return SendRequest(request);
		}

		private HttpWebResponseWrapper SendRequest(WebRequest webRequest) {
			LogRequest(webRequest);

			HttpWebResponseWrapper httpWebResponse;
			try {
				httpWebResponse = HttpWebResponseWrapper.FromWebResponse(webRequest.GetResponse());
			} catch (WebException ex) {
				httpWebResponse = HttpWebResponseWrapper.FromWebException(ex);
			}
			LogResponse(httpWebResponse);
			return httpWebResponse;
		}

		private void LogRequest(WebRequest request) {
			_logger.WriteLine("REQUEST {0}", DateTime.Now);
			_logger.WriteLine("-----");
			_logger.WriteLine("{0} {1} HTTP/1.1", request.Method.ToUpper(), request.RequestUri.PathAndQuery);
			_logger.WriteLine("Host: {0}", request.RequestUri.Host);
			foreach (string header in request.Headers) {
				_logger.WriteLine("{0}: {1}", header, request.Headers[header]);
			}
			_logger.WriteLine("=====");
		}

		private void LogResponse(HttpWebResponseWrapper response) {
			_logger.WriteLine("RESPONSE {0}", DateTime.Now);
			_logger.WriteLine("-----");
			_logger.WriteLine("HTTP/1.1 {0} {1}", (int)response.StatusCode, response.StatusCode);
			foreach (string header in response.Headers) {
				_logger.WriteLine("{0}: {1}", header, response.Headers[header]);
			}
			var responseString = response.Body;
			if (!string.IsNullOrEmpty(responseString)) {
				_logger.WriteLine();
				_logger.WriteLine(responseString);
			}

			_logger.WriteLine("=====");
		}
	}
}