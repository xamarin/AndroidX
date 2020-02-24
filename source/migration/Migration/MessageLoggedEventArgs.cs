using System;

namespace Xamarin.AndroidX.Migration
{
	public class MessageLoggedEventArgs : EventArgs
	{
		public MessageLoggedEventArgs(
			string message,
			bool isError = false,
			bool isVerbose = false,
			Exception exception = null)
		{
			Message = message;
			IsError = isError;
			IsVerbose = isVerbose;
			Exception = exception;
		}

		public string Message { get; }

		public bool IsError { get; }

		public bool IsVerbose { get; }

		public Exception Exception { get; }
	}
}
