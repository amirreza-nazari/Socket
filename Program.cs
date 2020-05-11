using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Test
{
        
    private static string search_key;
    private static string add_key;
    private static string add_val;
    private static string update_key;
    private static string update_val;

    static void Main(string[] args)
    {
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;
        string filePath = @"F:\Project\dict\dict_file\dict.txt";
        string line;
        char[] spearator = {':'};

        Dictionary<string, string> dict = new Dictionary<string, string>();

        if (File.Exists(filePath))
        {
            StreamReader file = null;
            try
            {
                file = new StreamReader(filePath);
                while ((line = file.ReadLine()) != null)
                {
                    String[] dic = line.Split(spearator,
                       StringSplitOptions.RemoveEmptyEntries);
                    dict.Add(dic[0],dic[1]);
                }

            }
            finally
            {
                if (file != null)
                    file.Close();
            }
            //write
            foreach (KeyValuePair<string, string> kvp in dict)
            {
                //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                Console.WriteLine("{0}-->{1}", kvp.Key, kvp.Value);
            }
        }

        bool amoo;
        amoo = true;
        string yes_or_no, caseSwitch;
        yes_or_no = "y";


        while (amoo == true)
        {

            Console.WriteLine("for search key is : 1\n " +
                "              for add word key is :2"\n +
                "               for update meaning key is :3\n"+
                               "for end you can use :4");

            caseSwitch = Console.ReadLine();


            if (yes_or_no == "y")
            {
                switch (caseSwitch)
                {
                    case "1":
                        search_in_file();
                        break;
                    case "2":
                        add_in_file();
                        break;
                    case "3":
                        update_file();
                        break;
                    default:
                        Console.WriteLine("pls enter one of this character ");
                        break;
                }
                if (yes_or_no == "n")
                {
                    amoo = false;
                }
            }
            else
            {
                Console.WriteLine("Good by");

            }
        }


//-----------------------------------search_in_file-------------------------------------------------

        void search_in_file()
        {
            Console.WriteLine("enter search word");

            search_key = Console.ReadLine();
            Console.WriteLine("{0}-->{1}", search_key , dict[search_key]);


        }
//-----------------------------------add_in_file-------------------------------------------------

        void add_in_file()
        {
            Console.WriteLine("enter your new word");
            add_key = Console.ReadLine();
            Console.WriteLine("enter your new meaning");
            add_val = Console.ReadLine();

            dict.Add(add_key, add_val);

            

                //// Create a string array with the lines of text
                //string[] lines = { "First line", "Second line", "Third line" };

                // Set a variable to the Documents path.
                string docPath =
                  Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Write the string array to a new file named "WriteLines.txt".
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"F:\Project\dict\dict_file\dict.txt")))
                {
                    foreach (KeyValuePair<string, string> line in dict)
                        outputFile.WriteLine("{0}:{1}", line.Key, line.Value);
                }

            }
//-----------------------------------update-------------------------------------------------
        void update_file()
        {
            Console.WriteLine("enter your  word");
            update_key = Console.ReadLine();
            Console.WriteLine("enter your new meaning");
            update_val = Console.ReadLine();

            dict.Remove(update_key);

            dict.Add(update_key, update_val);

            update_val = Console.ReadLine();


            string docPath =
                  Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"F:\Project\dict\dict_file\dict.txt")))
            {
                foreach (KeyValuePair<string, string> line in dict)
                    outputFile.WriteLine("{0}:{1}", line.Key, line.Value);
            }
        }
        



        
    }
}
