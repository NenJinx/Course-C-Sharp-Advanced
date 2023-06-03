using System;
using System.Collections.Generic;
using System.Linq;

Stack<int> boxWithClothes = new(Console.ReadLine().Split(" ").
    Select(int.Parse));
int theCapacityOfTheRack = int.Parse(Console.ReadLine());

int theSumOfTheClothes = 0;
int countRacks = 0;


while (boxWithClothes.Any())
{
    if (theSumOfTheClothes + boxWithClothes.Peek() > theCapacityOfTheRack)
    {
        theSumOfTheClothes = 0;
        countRacks++;
        continue;
    }
    theSumOfTheClothes += boxWithClothes.Peek();
    boxWithClothes.Pop();
}
countRacks++;
Console.WriteLine(countRacks);


