/*
     dotnet cake spell-check.cake
    dotnet cake spell-check.cake -t=spell-check
 */
#addin nuget:?package=WeCantSpell.Hunspell&version=3.0.1
#addin nuget:?package=Newtonsoft.Json&version=12.0.3
#addin nuget:?package=Cake.FileHelpers&version=3.2.1

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

var TARGET = Argument ("t", Argument ("target", "Default"));

string file_spell_errors = "output/spell-errors.txt";
List<string> spell_errors = null;
JArray binderator_json_array = null;

Task ("spell-check")
    .Does 
    (
        () =>
        {
            EnsureDirectoryExists("./externals/");
            string url = "https://raw.githubusercontent.com/titoBouzout/Dictionaries/master/";

            string[] files = new[]
            {
                "English (American).dic",
                "English (American).txt",
                "English (American).aff",
            };
            foreach(string file in files)
            {
                string url_full = url + System.Uri.EscapeDataString(file); 
                Information($"Downloading ");
                Information($"      {url_full}");
                if (!FileExists($"./externals/{file}"))
                {
                    DownloadFile(url_full, $"./externals/{file}");
                }
            }

            var dictionary = WeCantSpell.Hunspell.WordList.CreateFromFiles(@"externals/English (American).dic");
            var words = new[]
            {
                "Xamarin",
                "AndroidX",
		        "IdentifierCommon",
		        "IdentifierProvider",
		        "AppCompat",
		        "AppCompatResources",
		        "Runtime",
		        "AsyncLayoutInflater",
		        "AutoFill",
		        "Biometric",
		        "Camera2",
		        "Lifecycle",
		        "CardView",
		        "ConstraintLayout",
		        "CoordinatorLayout",
		        "ContentPager",
		        "CursorAdapter",
		        "CustomView",
		        "DataBinding",
		        "DataBindingAdapters",
		        "DataBindingCommon",
		        "DataBindingRuntime",
		        "ViewBinding",
		        "DocumentFile",
		        "DrawerLayout",
		        "DynamicAnimation",
		        "Emoji",
		        "ExifInterface",
		        "GridLayout",
		        "HeifWriter",
		        "Interpolator",
		        "Leanback",
		        "V14",
		        "UI",
		        "Utils",
		        "V13",
		        "V4",
		        "LiveData",
		        "ViewModel",
		        "ViewModelSavedState",
		        "LocalBroadcastManager",
		        "Media2",
		        "MediaRouter",
		        "MultiDex",
		        "Runtime",
		        "PercentLayout",
		        "RecyclerView",
		        "SavedState",
		        "SlidingPaneLayout",
		        "Sqlite",
		        "SwipeRefreshLayout",
		        "TvProvider",
		        "VectorDrawable",
		        "VersionedParcelable",
		        "ViewPager",
		        "ViewPager2",
		        "WebKit",
            };
            var dictionary_custom = WeCantSpell.Hunspell.WordList.CreateFromWords(words);

            using (StreamReader reader = System.IO.File.OpenText(@"./config.json"))
            {
                JsonTextReader jtr = new JsonTextReader(reader);
                binderator_json_array = (JArray)JToken.ReadFrom(jtr);
            }

            spell_errors = new List<string>();
            Information("config.json spell checking...");

            foreach(JObject jo in binderator_json_array[0]["artifacts"])
            {
                bool? dependency_only = (bool?) jo["dependencyOnly"];
                if ( dependency_only == true)
                {
                    continue;
                }
                string nuget_id  	= (string) jo["nugetId"];
                Information($"       spell-check {nuget_id}");

                string[] nuget_id_parts = nuget_id.Split('.');
                foreach(string nuget_id_part in nuget_id_parts)
                {
                    bool check_dictionary_custom = dictionary_custom.Check(nuget_id_part);
                    Information($"      check_dictionary_custom {nuget_id_part} = {check_dictionary_custom}");
                    if (check_dictionary_custom)
                    {
                        Information($"          Found in custom dictionary!");
                        continue;
                    }
                    bool check_dictionary = dictionary.Check(nuget_id_part);
                    Information($"      check_dictionary {nuget_id_part} = {check_dictionary}");
                    if (check_dictionary)
                    {
                        Information($"          Found in EN-US dictionary!");
                        continue;
                    }
                    spell_errors.Add(nuget_id_part);
                }
            }

            if (spell_errors.Count > 0)
            {
                System.IO.File.WriteAllLines(file_spell_errors, spell_errors);
            }
        }
    );

Task ("api-diff-markdown-info-pr")
    .Does 
    (
        () =>
        {
            // TODO: api-diff markdown info based on diff from master

            return;
        }
    );


Task ("namespace-check")
    .Does 
    (
        () =>
        {
            // Namespace Checks
            FilePath[] files = new FilePath[]{};
            FilePath[] files_com = GetFiles("./generated/**/Com.*.cs").ToArray();
            FilePath[] files_org = GetFiles("./generated/**/Org.*.cs").ToArray();
            FilePath[] files_io = GetFiles("./generated/**/Io.*.cs").ToArray();

            files = files.Concat(files_com.ToArray()).ToArray();
            files = files.Concat(files_org.ToArray()).ToArray();
            files = files.Concat(files_io.ToArray()).ToArray();

            if (files.Any())
            {
                throw new Exception("Namespaces!!!");
            }

            return;
        }
    );

Task("binderate-diff")
    .Does
    (
        () =>
        {
			EnsureDirectoryExists("./output/");

			// "git diff master:config.json config.json" > ./output/config.json.diff-from-master.txt"
			string process = "git";
			string process_args = "diff master:config.json config.json";
			IEnumerable<string> redirectedStandardOutput;
			ProcessSettings process_settings = new ProcessSettings ()
			{
             Arguments = process_args,
             RedirectStandardOutput = true
         	};
			int exitCodeWithoutArguments = StartProcess(process, process_settings, out redirectedStandardOutput);
			System.IO.File.WriteAllLines("./output/config.json.diff-from-master.txt", redirectedStandardOutput.ToArray());
			Information("Exit code: {0}", exitCodeWithoutArguments);
		}
	);


Task ("Default")
    .IsDependentOn ("namespace-check")
    .IsDependentOn ("binderate-diff")
    .IsDependentOn ("api-diff-markdown-info-pr")
    .IsDependentOn ("spell-check")
    ;

if (System.IO.File.Exists(file_spell_errors))
{
    string separator = System.Environment.NewLine + "\t" + "\t";
    string msg = "Spell Errors:" + System.Environment.NewLine + "\t" + "\t"
                    + string.Join(separator, System.IO.File.ReadAllLines(file_spell_errors));
    throw new Exception(msg);
}

RunTarget (TARGET);
