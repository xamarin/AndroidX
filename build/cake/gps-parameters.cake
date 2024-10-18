// Contains tasks for retrieving pre-generated parameter names for some GPS packages.
// Ideally these days this could be replaced with `<JavaDocJar>` or `<AndroidSourceJar>`,
// but for now we'll just copy what was in the GPS repository.

var REF_DOCS_FILE = "./build/data/docs/play-services-firebase.zip";
var REF_METADATA_FILE = "./build/data/paramnames/play-services-firebase-metadata.xml";
var REF_PARAMNAMES_FILE = "./build/data/paramnames/play-services-firebase-paramnames.txt";

// Extracts parameter names and places them in the right spot for the GPS template
Task ("javadocs-gps")
	.Does (() =>
{
	EnsureDirectoryExists ("./externals/");

	if (!FileExists ("./externals/docs.zip"))
		CopyFile (REF_DOCS_FILE, "./externals/docs.zip");

	if (!DirectoryExists ("./externals/docs"))
		Unzip ("./externals/docs.zip", "./externals/docs");

	if (!FileExists ("./externals/paramnames.txt"))
		CopyFile (REF_PARAMNAMES_FILE, "./externals/paramnames.txt");

	if (!FileExists ("./externals/paramnames.xml"))
		CopyFile (REF_METADATA_FILE, "./externals/paramnames.xml");

  return;
  
	//var astJar = new FilePath ("./util/JavaASTParameterNames-1.0.jar");
	//var sourcesJars = GetFiles ("./externals/**/*-sources.jar");

	//foreach (var srcJar in sourcesJars) {
	//	var srcJarPath = MakeAbsolute (srcJar).FullPath;
	//	var outTxtPath = srcJarPath.Replace ("-sources.jar", "-paramnames.txt");
	//	var outXmlPath = srcJarPath.Replace ("-sources.jar", "-paramnames.xml");

	//	StartProcess ("java", "-jar \"" + MakeAbsolute(astJar).FullPath + "\" --text \"" + srcJarPath + "\" \"" + outTxtPath + "\"");
	//	StartProcess ("java", "-jar \"" + MakeAbsolute(astJar).FullPath + "\" --xml \"" + srcJarPath + "\" \"" + outXmlPath + "\"");
	//}
});
