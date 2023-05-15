Queue<string> songs = new(Console.ReadLine().Split(", "));
string[] cmdArgs = new string[2];
while (songs.Any())
{
    
    cmdArgs = Console.ReadLine().Split(' ');
    string command = cmdArgs[0];
    if (command =="Play")
    {
        songs.Dequeue();
    }
    else if (command == "Add")
    {
        string song = string.Join(" ",cmdArgs[1..]);
        if (songs.Contains(song))
        {
            Console.WriteLine($"{song} is already contained!");
        }
        else
        {
            songs.Enqueue(song);
        }
    }
    else
    {
        Console.WriteLine(string.Join(", ",songs));
    }
}
Console.WriteLine("No more songs!");
