using System.IO;

namespace Xamarin.AndroidX.Migration
{
	public abstract class CsvMapping
	{
		protected CsvMapping()
		{
		}

		protected CsvMapping(string mappingFile)
		{
			LoadMapping(mappingFile);
		}

		protected CsvMapping(Stream csv)
		{
			LoadMapping(csv);
		}

		protected void LoadMapping(string mappingFile)
		{
			using (var stream = File.OpenRead(mappingFile))
			using (var reader = new StreamReader(stream))
			{
				LoadMapping(reader);
			}
		}

		protected void LoadMapping(Stream csv)
		{
			using (var reader = new StreamReader(csv))
			{
				LoadMapping(reader);
			}
		}

		protected void LoadMapping(TextReader reader)
		{
			foreach (var line in reader.ReadToEnd().Split('\r', '\n'))
			{
				if (string.IsNullOrWhiteSpace(line))
					continue;

				var split = line.Split(',');

				OnLoadRecord(split);
			}
		}

		protected abstract void OnLoadRecord(string[] record);
	}
}
