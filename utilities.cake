#tool nuget:?package=Cake.CoreCLR
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
                "SecurityCrypto",
                "Java8",
                "ReactiveStreams",
                "Ktx",
                "RxJava2",
                "RxJava3",
                "GoogleShortcuts",
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

                    Information($"Added {nuget_id_part} from {nuget_id}");
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
            FilePath[] files_androidx = GetFiles("./generated/**/Androidx.*.cs").ToArray();
            FilePath[] files_com = GetFiles("./generated/**/Com.*.cs").ToArray();
            FilePath[] files_org = GetFiles("./generated/**/Org.*.cs").ToArray();
            FilePath[] files_io = GetFiles("./generated/**/Io.*.cs").ToArray();

            files = files.Concat(files_androidx.ToArray()).ToArray();
            files = files.Concat(files_com.ToArray()).ToArray();
            files = files.Concat(files_org.ToArray()).ToArray();
            files = files.Concat(files_io.ToArray()).ToArray();

            if (files.Any())
            {
                string[] namespaces = Array.ConvertAll(files, x => x.ToString());
                System.IO.File.WriteAllLines("./output/namespaces.md", namespaces);

                StringBuilder msg = new StringBuilder("Namespaces!!!");
                msg.AppendLine();
                msg.AppendLine(string.Join(System.Environment.NewLine, namespaces));

                throw new Exception(msg.ToString());
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

			// "git diff -U999999 main:config.json config.json" > ./output/config.json.diff-from-main.txt"
			string process = "git"; 
			string process_args = "diff -U999999 main:config.json config.json";
			IEnumerable<string> redirectedStandardOutput;
			ProcessSettings process_settings = new ProcessSettings ()
			{
             Arguments = process_args,
             RedirectStandardOutput = true
         	};
			int exitCodeWithoutArguments = StartProcess(process, process_settings, out redirectedStandardOutput);
			System.IO.File.WriteAllLines("./output/config.json.diff-from-main.txt", redirectedStandardOutput.ToArray());
			Information("Exit code: {0}", exitCodeWithoutArguments);
		}
	);

Task ("api-diff-markdown-info-pr")
    .IsDependentOn("binderate-diff")
    .Does 
    (
        () =>
        {
            // TODO: api-diff markdown info based on diff from main
            string[] lines_from_file = System.IO.File.ReadAllLines("./output/config.json.diff-from-main.txt");

            List<string> lines = new List<string>(lines_from_file);
            List<string> changelog = new List<string>();

            List<List<string>> changelog_blocks = new List<List<string>>();
            List<string> changelog_block = null;
            int idx_start = -1;
            int idx_stop = -1;
            for(int i = 0; i < lines.Count(); i++)
            {
                string line = lines[i];
                if (line.Contains("groupId"))
                {
                    idx_start = i;
                }
                                
                if(line.Contains("dependencyOnly"))
                {
                    if (line.StartsWith("-"))
                    {
                        continue;
                    }
                    idx_stop = i;
                }

                if (idx_start != -1 && idx_stop != -1)
                {
                    changelog_block = lines.GetRange(idx_start, idx_stop - idx_start);
                    changelog_blocks.Add(changelog_block);
                    idx_start = -1;
                    idx_stop = -1;
                }
            }


            foreach (List<string> changelog_block_lines in changelog_blocks)
            {
                string g = null;
                string a = null;
                string v_artifact_new = null;
                string v_artifact_old = null;
                string v_nuget_new = null;
                string v_nuget_old = null;
                string nuget_id = null;

                foreach(string line in changelog_block_lines)
                {
                    if (line.Contains("groupId"))
                    {
                        g = ParseDiffLine(line, "groupId");
                        continue;
                    }
                    if (line.Contains("artifactId"))
                    {
                        a = ParseDiffLine(line, "artifactId");
                        continue;
                    }
                    if (line.Contains("version"))
                    {
                        if (line.StartsWith("+"))
                        {
                            v_artifact_new = ParseDiffLine(line, "version");
                            continue;
                        }

                        v_artifact_old = ParseDiffLine(line, "version");
                        continue;
                    }

                    if (line.Contains("nugetVersion"))
                    {
                        v_nuget_old = ParseDiffLine(line, "nugetVersion");
                        continue;
                    }
                    if (line.Contains("nugetVersion"))
                    {
                        v_nuget_new = ParseDiffLine(line, "nugetVersion");
                        continue;
                    }
                    if (line.Contains("nugetId"))
                    {
                        nuget_id = ParseDiffLine(line, "nugetId");
                        continue;
                    }
                }

                if(v_artifact_new == null)
                {
                    continue;
                }

                string changelog_line = $"- {g}:{a} - {v_artifact_old} -> {v_artifact_new}";

                changelog.Add(changelog_line);
            }

            if (changelog.Count > 0)
            {
                System.IO.File.WriteAllLines("./output/changelog.md", changelog);
            }

            return;
        }
    );

string ParseDiffLine(string line, string name)
{
    if (line[0] == '-')
    {
        StringBuilder sb = new StringBuilder(line);
        sb[0] = ' ';
        line = sb.ToString();
    }

    return new string
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
                    .Replace(name, "")
                    .Replace(",", "")
                    ;
}

Task ("api-diff-analysis")
    .Does 
    (
        () =>
        {
            using (StreamReader reader = System.IO.File.OpenText(@"./config.json"))
            {
                JsonTextReader jtr = new JsonTextReader(reader);
                binderator_json_array = (JArray)JToken.ReadFrom(jtr);
            }

            DirectoryPathCollection directories = GetSubDirectories("./output/api-diff");
            Dictionary<string, string>  nugets_modified = new Dictionary<string, string>();

            foreach(DirectoryPath d in directories)
            {
                string d_name = d.GetDirectoryName();

                Information( $"Directory    = {d}");
                Information( $"     nugetId    = {d.GetDirectoryName()}");

                string groupId      = null;
                string artifactId   = null;
                string nugetId      = null;
                string nugetVersion = null;
                // no guarantees thta config.json is sorted, so linear "search"
                // TODO: sort + (LINQ or binary serch)
                foreach(JObject jo in binderator_json_array[0]["artifacts"])
                {
                    groupId      = (string) jo["groupId"];
                    artifactId   = (string) jo["artifactId"];
                    nugetId      = (string) jo["nugetId"];
                    nugetVersion = (string) jo["nugetVersion"];

                    if (nugetId == d_name)
                    {
                        Information( $"     groupId                     = {groupId}");
                        Information( $"     artifactId                  = {artifactId}");
                        Information( $"     artifactId  fully qualified = {groupId}.{artifactId}");

                        nugets_modified.Add(d_name, $"{groupId}.{artifactId}");
                    }
                }
            }

            string[] lines = nugets_modified.Select(kv => kv.Key + Environment.NewLine + "\t" + kv.Value).ToArray();
            System.IO.File.WriteAllLines("./output/nugets-with-changed-APIs.md", lines);

            return;
        }
    );

Task ("read-analysis-files")
    .IsDependentOn ("binderate-diff")
    .IsDependentOn ("api-diff-markdown-info-pr")
    .IsDependentOn ("namespace-check")
    .IsDependentOn ("spell-check")
    .IsDependentOn ("api-diff-analysis")    
    .Does 
    (
        () =>
        {
            List<string> files = new List<string>
            {
                "./output/spell-errors.txt",
                "./output/changelog.md",
                "./output/config.json.diff-from-main.txt",
                "./output/missing_dotnet_override_type.csv",
                "./output/missing_dotnet_type.csv",
                "./output/missing_java_type.csv",
                "./output/nugets-with-changed-APIs.md",
            };

            if ( ! FileExists("./output/spell-errors.txt") )
            {
                files.Remove("./output/spell-errors.txt");
            }

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

Task("dependencies")
    .Does
    (
        () =>
        {
            if (!(binderator_json_array?.Count > 0)) 
            {
                using (StreamReader reader = System.IO.File.OpenText(@"./config.json"))
                {
                    JsonTextReader jtr = new JsonTextReader(reader);
                    binderator_json_array = (JArray)JToken.ReadFrom(jtr);
                }
            }

            Warning("config.json dependencies ...");
            foreach(JObject jo in binderator_json_array[0]["artifacts"])
            {
                string groupId      = (string) jo["groupId"];
                string artifactId   = (string) jo["artifactId"];
                string nugetId      = (string) jo["nugetId"];
                string nugetVersion = (string) jo["nugetVersion"];

            }
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
