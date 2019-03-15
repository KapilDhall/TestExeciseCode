using System;
using System.Collections.Generic;
using System.Linq;
using ThirdPartyTools;

namespace FileData
{
    public static class Program
    {        

        public static void Main(string[] args)
        {                       
            try
            {
                if (args.Length == 2)
                {
                    string identifier = args[0];
                    string filepath = args[1];

                    string output = "";
                    if (identifier != "" && filepath != "")
                    {
                        //Getting the output by calling GetOutput function which will be displayed in Console application
                        output = GetOutput(identifier, filepath);
                        Console.WriteLine("Output is " + output);
                        Console.ReadLine();
                    }
                    else
                    {
                        //Check to make sure two arguments are mandatory
                        Console.WriteLine("Two arguments are mandatory");
                        Console.ReadLine();
                    }
                }
                else
                {
                    //Required arguments to be passed as 2
                    Console.WriteLine("Incorrect number of arguments. Please pass two arguments");
                    Console.ReadLine();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            

        }

        

        public static string GetOutput(string identifier, string filepath)
        {
            string output = String.Empty;

            //Checking this condition if GetOutput method to be tested alone and throwing exception
            if (identifier == "" || filepath == "")
            {
                throw new Exception("identifier and filepath are mandatory");
                //return output;
            }

            
            List<string> list1 = new List<string>();
            List<string> list2 = new List<string>();

            try
            {
                //Adding the items which will be used to get Version info
                list1.Add("-v");
                list1.Add("--v");
                list1.Add("/v");
                list1.Add("--version");

                //Adding the items which will be used ot get size info
                list2.Add("-s");
                list2.Add("--s");
                list2.Add("/s");
                list2.Add("--size");

                FileDetails filedetails = new FileDetails();

                //Condition and call Version(filepath) method from FileDetails class to get Version info
                if (list1.Contains(identifier))
                {                    
                    output = filedetails.Version(filepath);
                }

                //Condition and call Version(filepath) method from FileDetails class to get Size info
                else if (list2.Contains(identifier))
                {                    
                    output = Convert.ToString(filedetails.Size(filepath));
                }

                //Returning the output if correct identifier not passed
                else
                {
                    output = "Incorrect identifier; Please check";
                }
            }
            catch (Exception ex)
            {
                output = "Exception occurred: " + ex.Message + ".Please pass proper identifier";
            }

            list1 = null;
            list2 = null;
            return output;
        }
                
    }
}
