
using System.IO;
namespace LibraryApp
{
    class Program
    {
        static void Main()
        {

            string writeText = "Hello David!";  // Create a text string
            File.WriteAllText("filename.txt", writeText);
        }
    }
}
