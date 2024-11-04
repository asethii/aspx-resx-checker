using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;

namespace NewPublic.DealerBranding.v2
{
    public class Class1
    {

        static void Main (string[] args)
        {
            try
            {
                using(ResourceReader resxReader = new ResourceReader(@"App_LocalResources/default.aspx.resx") )
                {
                    string aspxContent = File.ReadAllText(@"default.aspx");
                    string aspxCsContent = File.ReadAllText(@"default.aspx.cs");

                    foreach (System.Collections.DictionaryEntry entry in resxReader)
                    {
                        // Check if the key is not null
                        if (entry.Key != null)
                        {
                            // Check if the key is present in the .aspx or .aspx.cs files
                            if (aspxContent.Contains(entry.Key.ToString()) || aspxCsContent.Contains(entry.Key.ToString()))
                            {
                                Console.WriteLine($"Key '{entry.Key}' is referenced in the .aspx or .aspx.cs file.");
                            }
                            else
                            {
                                Console.WriteLine($"Key '{entry.Key}' is not referenced in the .aspx or .aspx.cs file.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {            
                    Console.WriteLine(ex.ToString());            
            }
        } 
    }
}
