#! "netcoreapp2.0"
#load "MavenNet"
using MavenNet;

const string MAVEN_REPO = "../externals/m2repository/";
const string OLD_VER = "27.0.2";
const string NEW_VER = "27.1.1";

var repo = MavenNet.MavenRepository.OpenDirectory (MAVEN_REPO);
await repo.LoadMetadataAsync ();

foreach (var item in repo.Metadata) {

    var oldProj = await repo.GetProjectAsync (item.GroupId, item.ArtifactId, OLD_VER);
    var newProj = await repo.GetProjectAsync (item.GroupId, item.ArtifactId, NEW_VER);
    
    if (oldProj == null && newProj == null)
        continue;
    if (newProj == null) {
        Console.WriteLine (item.ArtifactId + " -> Removed");
        continue;
    }
    if (oldProj == null) {
        Console.WriteLine (item.ArtifactId + " -> Added");

        foreach (var d in newProj.Dependencies)
            Console.WriteLine ($"-> Dependency: {d.ArtifactId}");
            
        continue;
    }

    var removedDeps = oldProj.Dependencies.Where (od => !newProj.Dependencies.Any (nd => nd.GroupId == od.GroupId && nd.ArtifactId == od.ArtifactId));
    var addedDeps = newProj.Dependencies.Where (od => !oldProj.Dependencies.Any (nd => nd.GroupId == od.GroupId && nd.ArtifactId == od.ArtifactId));

    if (removedDeps.Any () || addedDeps.Any ())
        Console.WriteLine (item.ArtifactId + " dependencies changed!");

    foreach (var rm in removedDeps)
        Console.WriteLine ($"-> Removed: {rm.ArtifactId}");

    foreach (var ad in addedDeps)
        Console.WriteLine ($"-> Added: {ad.ArtifactId}");
}
