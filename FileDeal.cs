using System.IO;

string writeText = "Hello David!";  // Create a text string
File.WriteAllText("filename.txt", writeText);  // Create a file and write the content of writeText to it

//string readText = File.ReadAllText("filename.txt");  // Read the contents of the file
//Console.WriteLine(readText);  