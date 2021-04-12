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

string file_spell_errors = "./output/spell-errors.txt";
List<string> spell_errors = null;
JArray binderator_json_array = null;

Task ("spell-check")
    .Does 
    (
        () =>
        {
            if (FileExists(file_spell_errors))
            {
                DeleteFile(file_spell_errors);
            }
            EnsureDirectoryExists("./externals/");
            string url = "https://raw.githubusercontent.com/titoBouzout/Dictionaries/master/";

            string[] files_dictionaries = new[]
            {
                "English (American).dic",
                "English (American).txt",
                "English (American).aff",
            };
            foreach(string file_dictionary in files_dictionaries)
            {
                string url_full = url + System.Uri.EscapeDataString(file_dictionary); 
                Information($"Downloading ");
                Information($"      {url_full}");
                if (!FileExists($"./externals/{file_dictionary}"))
                {
                    DownloadFile(url_full, $"./externals/{file_dictionary}");
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
                "WindowExtensions",
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

Task ("api-diff-markdown-info-pr")
    .IsDependentOn("binderate-diff")
    .Does 
    (
        () =>
        {
            // TODO: api-diff markdown info based on diff from master
            string[] lines = System.IO.File.ReadAllLines("./output/config.json.diff-from-master.txt");

            bool group_new = false;
            bool artifact_new = false;
            string group_id = null;
            string artifact_id = null;
            string g = "g";
            string a = "a";
            string v_a;
            string v_a_old = null;
            string v_a_new = null;
            string v_n;
            string v_n_old = null;
            string v_n_new = null;
            string changelog_item = null;

            List<string> changelog = new List<string>();
            foreach(string line in lines)
            {
                if (line.Contains("{") && line.Contains("}"))
                {
                    changelog_item = null;
                }
                if (line.Contains("groupId") && line.Contains("+"))
                {
                    group_new = true;
                }
                if (line.Contains("artifactId") && line.Contains("+"))
                {
                    artifact_new = true;
                }
                if (line.Contains("groupId"))
                {
                    g = new string
                                        (
                                            line
                                                .ToCharArray()
                                                .Where(c => !Char.IsWhiteSpace(c))
                                                .ToArray()
                                        )
                                        .Replace("\"", "")
                                        .Replace("+", "")
                                        .Replace(":", "")
                                        .Replace("groupId", "")
                                        .Replace(",", "")
                                        ;
                    Information($"       g = {g}");
                    continue;
                }
                if (line.Contains("artifactId"))
                {
                    a = new string
                                        (
                                            line
                                                .ToCharArray()
                                                .Where(c => !Char.IsWhiteSpace(c))
                                                .ToArray()
                                        )
                                        .Replace("\"", "")
                                        .Replace("+", "")
                                        .Replace(":", "")
                                        .Replace("artifactId", "")
                                        .Replace(",", "")
                                        ;
                    Information($"       a = {a}");
                    continue;
                }
                if (line.Contains("version"))
                {
                    v_a = new string
                                        (
                                            line
                                                .ToCharArray()
                                                .Where(c => !Char.IsWhiteSpace(c))
                                                .ToArray()
                                        )
                                        .Replace("\"", "")
                                        .Replace("+", "")
                                        .Replace("-", "")
                                        .Replace(":", "")
                                        .Replace("version", "")
                                        .Replace(",", "")
                                        ;
                    Information($"          v_a     = {v_a}");
                    if (line.StartsWith("+"))
                    {
                        v_a_new = v_a;
                        Information($"       v_a_new = {v_a_new}");
                    } 
                    else if (line.StartsWith("-"))
                    {
                        v_a_old = v_a;
                        Information($"       v_a_old = {v_a_old}");
                    }
                    else
                    {

                    }
                    continue;
                }
                if (line.Contains("nugetVersion"))
                {
                    v_n = new string
                                        (
                                            line
                                                .ToCharArray()
                                                .Where(c => !Char.IsWhiteSpace(c))
                                                .ToArray()
                                        )
                                        .Replace("\"", "")
                                        .Replace("+", "")
                                        .Replace("-", "")
                                        .Replace(":", "")
                                        .Replace("nugetVersion", "")
                                        .Replace(",", "")
                                        ;
                    Information($"          v_n     = {v_n}");
                    if (line.StartsWith("+"))
                    {
                        v_n_new = v_n;
                        Information($"       v_n_new = {v_n_new}");
                    } 
                    else if (line.StartsWith("-"))
                    {
                        v_n_old = v_n;
                        Information($"       v_n_old = {v_n_old}");
                    }
                    else
                    {

                    }

                    continue;
                }

                changelog_item = $"- {g}:{a} - {v_a_old} -> {v_a_new}";
                changelog.Add(changelog_item);
            }

            if (changelog.Count > 0)
            {
                System.IO.File.WriteAllLines("./output/changelog.md", changelog);
            }
            return;
        }
    );

Task ("read-analysis-files")
    .IsDependentOn ("namespace-check")
    .IsDependentOn ("binderate-diff")
    .IsDependentOn ("api-diff-markdown-info-pr")
    .IsDependentOn ("spell-check")
    .Does 
    (
        () =>
        {
            string[] files = new[]
            {
                "./output/spell-errors.txt",
                "./output/changelog.md",
                "./output/config.json.diff-from-master.txt",
                "./output/missing_dotnet_override_type.csv",
                "./output/missing_dotnet_type.csv",
                "./output/missing_java_type.csv",
            };
			string process = "code";
			string process_args = $"-n {string.Join(" ", files)}";
			IEnumerable<string> redirectedStandardOutput;
			ProcessSettings process_settings = new ProcessSettings ()
			{
             Arguments = process_args,
             RedirectStandardOutput = true
         	};
			int exitCodeWithoutArguments = StartProcess(process, process_settings, out redirectedStandardOutput);
			Information("Exit code: {0}", exitCodeWithoutArguments);
        }
    );


Task ("Default")
    .IsDependentOn ("read-analysis-files")
    ;

if (System.IO.File.Exists(file_spell_errors))
{
    string separator = System.Environment.NewLine + "\t" + "\t";
    string msg = "Spell Errors:" + System.Environment.NewLine + "\t" + "\t"
                    + string.Join(separator, System.IO.File.ReadAllLines(file_spell_errors));
    throw new Exception(msg);
}

RunTarget (TARGET);
