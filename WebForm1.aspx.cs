using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Accord.Math;
using System.Text.RegularExpressions;
using Microsoft.ML.Data;

namespace NewPublic.DealerBranding.v2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                using (ResXResourceReader resxReader = new ResXResourceReader(@"C:\FALCOR\software\Websites\Web\NewPublic\DealerBranding\v2\App_LocalResources\default.aspx.resx"))
                {
                    string aspxContent = File.ReadAllText(@"C:\FALCOR\software\Websites\Web\NewPublic\DealerBranding\v2\default.aspx");
                    string aspxCsContent = File.ReadAllText(@"C:\FALCOR\software\Websites\Web\NewPublic\DealerBranding\v2\default.aspx.cs");
                    
                    //string path = @"C:\FALCOR\software\Websites\Web\NewPublic\DealerBranding\v2\default.aspx";
                    //string[] test = File.ReadAllLines(path);
                    
                    int aspxCountFound = 0;
                    int aspxCountNotFound = 0;

                    foreach (System.Collections.DictionaryEntry entry in resxReader)
                    {
                        // Check if the key is not null
                        if (entry.Key != null)
                        {   
                            //Key value without .text extension
                            string keyWithoutTextExtension = Regex.Replace(entry.Key.ToString(), "\\.text", "", RegexOptions.IgnoreCase);

                            //Key value without .title extension
                            string keyWithoutTitleExtension = Regex.Replace(entry.Key.ToString(), "\\.title", "", RegexOptions.IgnoreCase);    

                            //Key value without .tooltip extension
                            string keyWithoutTooltipExtension = Regex.Replace(entry.Key.ToString(), "\\.tooltip", "", RegexOptions.IgnoreCase);  
                            
                            //Key value with out .ErrorMessage extension
                            string keyWithoutErrorMessageExtension = Regex.Replace(entry.Key.ToString(), "\\.errormessage", "", RegexOptions.IgnoreCase);  

                            //Key value with out .Value extension
                            string keyWithoutValueExtension = Regex.Replace(entry.Key.ToString(), "\\.value", "", RegexOptions.IgnoreCase); 
                           

                            //Search the aspx file to see if the key is present
                            bool aspxContains = aspxContent.IndexOf(entry.Key.ToString(), StringComparison.OrdinalIgnoreCase) >= 0;
                            bool aspxCsContains = aspxCsContent.IndexOf(entry.Key.ToString(), StringComparison.OrdinalIgnoreCase) >= 0;
                            
                            bool aspxContainsWithoutTextExt = aspxContent.IndexOf(keyWithoutTextExtension, StringComparison.OrdinalIgnoreCase) >= 0;                           
                            bool aspxCsContainsWithoutTextExt = aspxCsContent.IndexOf(keyWithoutTextExtension, StringComparison.OrdinalIgnoreCase) >= 0;

                            bool aspxContainsWithoutTitleExt = aspxContent.IndexOf(keyWithoutTitleExtension, StringComparison.OrdinalIgnoreCase) >= 0;
                            bool aspxCsContainsWithoutTitleExt = aspxCsContent.IndexOf(keyWithoutTitleExtension, StringComparison.OrdinalIgnoreCase) >= 0;

                            bool aspxContainseWithoutTooltipExt = aspxContent.IndexOf(keyWithoutTooltipExtension, StringComparison.OrdinalIgnoreCase) >= 0;
                            bool aspxCsContainsWithoutTooltipExt = aspxCsContent.IndexOf(keyWithoutTooltipExtension, StringComparison.OrdinalIgnoreCase) >= 0;

                            bool aspxContainseWithoutErrorMessageExt = aspxContent.IndexOf(keyWithoutErrorMessageExtension, StringComparison.OrdinalIgnoreCase) >= 0;
                            bool aspxCsContainsWithoutErrorMessageExt = aspxCsContent.IndexOf(keyWithoutErrorMessageExtension, StringComparison.OrdinalIgnoreCase) >= 0;

                            bool aspxContainseWithoutValueExt = aspxContent.IndexOf(keyWithoutValueExtension, StringComparison.OrdinalIgnoreCase) >= 0;
                            bool aspxCsContainsWithoutValueExt = aspxCsContent.IndexOf(keyWithoutValueExtension, StringComparison.OrdinalIgnoreCase) >= 0;
                            
                            
                            //bool aspxContainsWithoutTextExt = aspxContent.Contains(keyWithoutTextExtension, StringComparison.OrdinalIgnoreCase);
                            //bool aspxCsContains = aspxCsContent.Contains(entry.Key.ToString());
                            //bool aspxCsContainsWithoutTextExt = aspxCsContent.Contains(keyWithoutTextExtension);
                            //bool aspxContainsWithoutTitleExt = aspxContent.Contains(keyWithoutTitleExtension);
                            //bool aspxCsContainsWithoutTitleExt = aspxCsContent.Contains(keyWithoutTitleExtension);

                            // Check if the key is present in the .aspx or .aspx.cs files
                            if (aspxContains || aspxContainsWithoutTextExt || aspxCsContains || aspxCsContainsWithoutTextExt || aspxContainsWithoutTitleExt || aspxCsContainsWithoutTitleExt || aspxContainseWithoutTooltipExt || aspxCsContainsWithoutTooltipExt || aspxContainseWithoutErrorMessageExt || aspxCsContainsWithoutErrorMessageExt || aspxContainseWithoutValueExt || aspxCsContainsWithoutValueExt)
                            {
                                //Console.WriteLine($"Key '{entry.Key}' is referenced in the .aspx or .aspx.cs file.");
                                aspxResults.Text += " Key " + entry.Key.ToString() + " IS referenced in the aspx or aspx.cs file <br /></br />";
                                aspxCountFound++;
                            }
                            else
                            {
                                //Console.WriteLine($"Key '{entry.Key}' is not referenced in the .aspx or .aspx.cs file.");
                                aspxResults.Text += " -- Key " + entry.Key.ToString() + " IS NOT referenced in the aspx or aspx.cs file <br /></br />";
                                aspxCountNotFound++;
                            }
                        }

                    }

                    aspxTextFound.Text = "Number of instances found: " + aspxCountFound.ToString();
                    aspxTextNotFound.Text = "Number of instances NOT found: " + aspxCountNotFound.ToString();

                    //string aspxCsContent = File.ReadAllText(@"C:\FALCOR\software\Websites\Web\NewPublic\DealerBranding\v2\default.aspx.cs");

                    //    foreach (System.Collections.DictionaryEntry entry in resxReader)
                    //    {
                    //        // Check if the key is not null
                    //        if (entry.Key != null)
                    //        {
                    //            string keyWithoutTextExtension = entry.Key.ToString().Replace(".text", string.Empty);

                    //            // Check if the key is present in the .aspx or .aspx.cs files
                    //            if (aspxContent.Contains(entry.Key.ToString()) || aspxCsContent.Contains(entry.Key.ToString()) || aspxContent.Contains(keyWithoutTextExtension.ToString())  )
                    //            {
                    //                //Console.WriteLine($"Key '{entry.Key}' is referenced in the .aspx or .aspx.cs file.");
                    //                text.Text +="Key " + entry.Key.ToString() + " IS referenced in the aspx or aspx.cs file <br /></br />";
                    //            }
                    //            else
                    //            {
                    //                //Console.WriteLine($"Key '{entry.Key}' is not referenced in the .aspx or .aspx.cs file.");
                    //                text.Text +="Key " + entry.Key.ToString() + " IS NOT referenced in the aspx or aspx.cs file <br /></br />";
                    //            }
                    //        }
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
