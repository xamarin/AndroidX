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
                    // var suggestions = dictionary.Suggest("teh");
                    // bool ok = dictionary.Check("the");
                    // Information($" the is correct = {ok}");
                }
            }

            if (spell_errors.Count > 0)
            {
                System.IO.File.WriteAllLines(file_spell_errors, spell_errors);
            }
        }
    );

if (System.IO.File.Exists(file_spell_errors))
{
    string separator = System.Environment.NewLine + "\t" + "\t";
    string msg = "Spell Errors:" + System.Environment.NewLine + "\t" + "\t"
                    + string.Join(separator, System.IO.File.ReadAllLines(file_spell_errors));
    throw new Exception(msg);
}

Task ("Default")
    .IsDependentOn ("spell-check");

RunTarget (TARGET);
