using System;
using System.Diagnostics;
using System.Threading;

namespace Xamarin.AndroidX.Migration
{
	public class MigrationTool
	{
		public bool HasLoggedErrors { get; private set; }

		public bool Verbose { get; set; }

		public event EventHandler<MessageLoggedEventArgs> MessageLogged;

		protected virtual void LogMessage(string message) =>
			Log(new MessageLoggedEventArgs(message));

		protected virtual void LogVerboseMessage(string message) =>
			Log(new MessageLoggedEventArgs(message, isVerbose: true));

		protected virtual void LogError(string message) =>
			Log(new MessageLoggedEventArgs(message, isError: true));

		protected virtual void LogError(Exception ex) =>
			Log(new MessageLoggedEventArgs(ex.Message, exception: ex));

		protected virtual void Log(MessageLoggedEventArgs e)
		{
			if (e.IsError)
				HasLoggedErrors = true;

			MessageLogged?.Invoke(this, e);
		}

		protected bool ExecuteExternalProcess(
			string command,
			string arguments = "",
			string workingDirectory = "",
			CancellationToken cancellationToken = default(CancellationToken))
		{
			LogVerboseMessage($"Running command:");
			LogVerboseMessage($"  Command: {command}");
			LogVerboseMessage($"  Arguments: {arguments}");

			var psi = new ProcessStartInfo
			{
				FileName = command,
				Arguments = arguments,
				UseShellExecute = false,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				CreateNoWindow = true,
				WindowStyle = ProcessWindowStyle.Hidden,
				WorkingDirectory = workingDirectory,
			};

			using (var outputEvent = new ManualResetEvent(false))
			using (var errorEvent = new ManualResetEvent(false))
			using (var proc = new Process())
			{
				proc.OutputDataReceived += (sender, e) =>
				{
					if (e.Data != null)
						LogMessage(e.Data);
					else
						outputEvent.Set();
				};
				proc.ErrorDataReceived += (sender, e) =>
				{
					if (e.Data != null)
						LogError(e.Data);
					else
						errorEvent.Set();
				};

				proc.StartInfo = psi;
				proc.Start();
				proc.BeginOutputReadLine();
				proc.BeginErrorReadLine();

				cancellationToken.Register(() =>
				{
					try
					{
						proc.Kill();
					}
					catch
					{
					}
				});

				proc.WaitForExit();

				if (psi.RedirectStandardError)
					errorEvent.WaitOne(TimeSpan.FromSeconds(30));

				if (psi.RedirectStandardOutput)
					outputEvent.WaitOne(TimeSpan.FromSeconds(30));

				return proc.ExitCode == 0 && !HasLoggedErrors;
			}
		}
	}
}