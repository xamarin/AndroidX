// Contains tasks for asserting certain conditions are met

// Ensures we don't expose default package accessibility interfaces as public
System.Xml.XmlDocument xmldoc = null;
System.Xml.XmlNamespaceManager ns = null;

Task ("metadata-verify")
    .Does (() =>
{
    FilePathCollection metadata_files = null;

    var xpath_expression_nodes_to_find =
                //$@"//attr[contains(@path,'interface') and contains(@name ,'visibility')]"
                $@"//attr[contains(@path,'interface')]"
                ;

    metadata_files = GetFiles ($"./generated/**/Metadata*.xml");
    
    foreach (var fp in metadata_files)
    {
        Information ($"Metadata = {fp}");
        throw new Exception ("Move this file to source");
    }
    
    metadata_files = GetFiles ($"./source/**/Metadata*.xml");
    
    foreach (var fp in metadata_files)
    {
        // Maintain some that slipped through for backwards compatibility
        if (fp.ToString ().Contains ("/com.github.bumptech.glide/") || fp.ToString ().Contains ("/com.google.zxing/"))
            continue;
        
        xmldoc = new System.Xml.XmlDocument ();
        xmldoc.Load (fp.ToString ());
        ns = new System.Xml.XmlNamespaceManager (xmldoc.NameTable);

        var result = GetXmlMetadata(xpath_expression_nodes_to_find, ns).ToList ();
        
        foreach ((string Path, bool IsPublic) r in result)
        {
            if (r.IsPublic)
            {
                Information ($"Metadata = {fp}");
                Information ($"		Found:");
                Information ($"			Path: {r.Path}");
                Information ($"			IsPublic: {r.IsPublic}");
                throw new Exception ("Preventing exposing/surfacing interfaces with default package accessibility as public");
            }
        }
    }
});

private IEnumerable<(string Path, bool IsPublic)> GetXmlMetadata (string xpath, System.Xml.XmlNamespaceManager xml_namespace)
{
    System.Xml.XmlNodeList node_list = xmldoc.SelectNodes (xpath, xml_namespace);

    foreach (System.Xml.XmlNode node in node_list)
    {
        string name = node.Attributes["name"].Value;
        string inner_text = node.InnerText;	//.Value;
        string path = node.Attributes["path"].Value;


        if (path.Contains ("MediaRouteProvider.DynamicGroupRouteController"))
        {
            Information ($"	path        = {path}");
            Information($"		Found:");
            Information($"			Name: {name}");
            Information($"			Visibility: {inner_text}");
            throw new Exception ("MediaRouteProvider.DynamicGroupRouteController");
        }

        if (string.Equals (name, "visibility") && inner_text.Contains ("public"))
        {
            Information ($"		Visibility  = {inner_text}");

            bool is_public = inner_text.Contains ("public") ? true : false;

            yield return (Path: path, IsPublic: is_public);
        }
    }
}
