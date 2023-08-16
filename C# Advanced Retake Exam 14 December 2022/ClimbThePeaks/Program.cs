using System;

Stack<int> portionsQuantities = new(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
Queue<int> staminaQuantities = new(Console.ReadLine()
.Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

HashSet<string> peaksNames = new();
while (portionsQuantities.Any() && staminaQuantities.Any())
{
    int result = portionsQuantities.Pop() + staminaQuantities.Dequeue();
    switch (result)
    {
        case 60: peaksNames.Add("Polezhan"); break;
        case 70: peaksNames.Add("Kamenitza"); break;
        case 80: peaksNames.Add("Vihren"); break;
        case 90: peaksNames.Add("Kutelo"); break;
        case 100: peaksNames.Add("Banski Suhodol"); break;
    }
    if (result >= 60 && result < 70)
        peaksNames.Add("Polezhan");
    else if (result >= 70 && result < 80)
        peaksNames.Add("Kamenitza"); 
    else if (result >= 80 && result < 90)
        peaksNames.Add("Vihren");
    else if (result >= 90 & result < 100)
        peaksNames.Add("Kutelo");
    else if (result >= 100)
        peaksNames.Add("Banski Suhodol");

    if (peaksNames.Count == 5)
    {
        Console.WriteLine("Alex did it! He climbed all top five Pirin " +
            "peaks in one week -> @FIVEinAWEEK");
        break;
    }
}
if (!portionsQuantities.Any() && !staminaQuantities.Any()
    && peaksNames.Count < 5)
{
    Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
}
if (peaksNames.Count > 0)
{
    Console.WriteLine("Conquered peaks:");
    foreach (var peak in peaksNames)
    {
        Console.WriteLine(peak);
    }
}
