﻿using System;
using System.Collections.Generic;
using System.Linq;

const int litersPerKilometer = 1;
int n = int.Parse(Console.ReadLine());
Queue<int[]> pumps = new();

for (int i = 0; i < n; i++)
{
    int[] cmdArgs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
    pumps.Enqueue(cmdArgs);
}

int startIndex = 0;

while (true)
{
    bool isComplete = false;
    int totalLiters = 0;

    foreach (var pump in pumps)
    {
        int liters = pump[0];
        int distance = pump[1];

        totalLiters += liters;

        if (totalLiters - distance * litersPerKilometer < 0)
        {
            startIndex++;

            int[] currentPump = pumps.Dequeue();
            pumps.Enqueue(currentPump);

            isComplete = false;

            break;
        }
        totalLiters -= distance * litersPerKilometer;
    }

    if (isComplete)
    {
        Console.WriteLine(startIndex);
        break;
    }
}   

