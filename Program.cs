namespace TicketingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> watchers = new List<string>();
            string[] header = { "TicketID", "Summary", "Status", "Priority", "Submitter", "Assigned", "Watching" };
            string file = "tickets.csv";
            string choice;
            string[] input = new string[7];
            do
            {
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");

                choice = Console.ReadLine();
                Console.WriteLine();
                if (choice == "1")
                {
                    StreamReader sr = new StreamReader(file);
                    sr.ReadLine(); 
                    while (!sr.EndOfStream)
                    {


                        var line = sr.ReadLine();
                        string[] arr = line.Split(',');

                        Console.WriteLine($"{arr[0]},{arr[1]},{arr[2]},{arr[3]},{arr[4]},{arr[5]},{arr[6]}");
                    }
                    sr.Close(); 
                }
                else if (choice == "2")
                {

                    StreamWriter sw = new StreamWriter(file);

                    sw.WriteLine($"{header[0]},{header[1]},{header[2]},{header[3]},{header[4]},{header[5]},{header[6]},");
                    Console.WriteLine("Create a Ticket (Y/N)?");
                    string resp = Console.ReadLine().ToUpper();
                    if (resp != "Y") { break; }

                    Console.WriteLine("Enter the TicketID: ");
                    input[0] = Console.ReadLine();

                    Console.WriteLine("Please enter a Summary: ");
                    input[1] = Console.ReadLine();

                    Console.WriteLine("Please select a Status: ");
                    input[2] = Console.ReadLine();

                    Console.WriteLine("Please set a Priority: ");
                    input[3] = Console.ReadLine();

                    Console.WriteLine("What is your name?: ");
                    input[4] = Console.ReadLine();

                    Console.WriteLine("Who is assigned to the ticket?: ");
                    input[5] = Console.ReadLine();

                    WatcherBuilder(watchers);

                    Console.WriteLine($"There are {watchers.Count} watchers added");
                    var watcherArr = watchers.ToArray();
                    Console.WriteLine(string.Join("|", watcherArr));
                    Console.WriteLine();
                    input[6] = string.Join("|", watcherArr);
                    sw.WriteLine($"{input[0]}, {input[1]}, {input[2]}, {input[3]}, {input[4]}, {input[5]}, {input[6]}  ");
                    Console.WriteLine("A ticket has been created.");
                    Console.WriteLine();
                    watchers.Clear();

                    sw.Close();
                }

            } while (choice == "1" || choice == "2");

            static void WatcherBuilder(List<string> watchers)
            {
                string userInput;
                Console.WriteLine("Please add a watcher");
                string person = Console.ReadLine();
                watchers.Add(person);

                do
                {
                    Console.WriteLine("Are there any more watchers? Y/N: ");
                    userInput = Console.ReadLine();
                    if (userInput.ToUpper() == "Y")
                    {
                        Console.WriteLine("Please add another watcher");
                        person = Console.ReadLine();
                        watchers.Add(person);
                    }
                    else if (userInput.ToUpper() == "N")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please select Y or N ");
                        userInput = "Y";
                    }

                } while (userInput.ToUpper() == "Y");


            }


        }
    }
}