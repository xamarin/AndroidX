// Forward to running 'tools-executive-order' in 'utilities.cake'
Task("tools-executive-order")
    .Does (() =>
{
    CakeExecuteScript (
        "./utilities.cake",
        new CakeSettings { Arguments = new Dictionary<string, string> () { 
                { "target", "tools-executive-order" } 
            } 
        }
    );        
});
