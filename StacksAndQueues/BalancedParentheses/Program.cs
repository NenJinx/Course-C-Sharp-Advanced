

//( - 40
//[ - 91
//{ - 123

//List<char> parentheses = Console.ReadLine().ToCharArray().ToList();
//char[] parentheses = Console.ReadLine().ToCharArray();
//Queue<char> openParentheses = new();
Stack<char> openParentheses = new();
//Stack<char> closeParentheses = new();
int count = 0;

//for (int i = 0; i < countElements; i++)
//{
//    if (parentheses[i] == '[' || parentheses[i] == '(' || parentheses[i] == '{')
//        closeParentheses.Push(parentheses[i]);
//}
//for (int i = 0; i < countElements; i++)
//{
//    if (parentheses[i] == ']' || parentheses[i] == ')' || parentheses[i] == '}')
//        openParentheses.Enqueue(parentheses[i]);
//}
//while (parentheses.Contains('[') || parentheses.Contains('(') || parentheses.Contains('{'))
//while (parentheses[count] == '(' || parentheses[count] == '[' || 
//parentheses[count] == '{';
//{
// openParentheses.Enqueue(parentheses[count]);
//parentheses.Remove(parentheses[count]);
//}
//while (parentheses.Contains(']') || parentheses.Contains(')') || parentheses.Contains('}'))

//while (parentheses[count] == ')' || parentheses[count] == ']' ||
//parentheses[count] == '}')
//{
// closeParentheses.Push(parentheses[count]);
// parentheses.Remove(parentheses[count]);
//if (count == parentheses.Count)
//{
//break;
//}
//}
//if (openParentheses.Count != closeParentheses.Count)
//{
//    Console.WriteLine("NO");
//    return;
//}
//for (int i = 0; i < countElements / 2; i++)
//{
//    if (openParentheses.Peek() == '{' && closeParentheses.Peek() == '}')
//    {
//        openParentheses.Dequeue();
//        closeParentheses.Pop();
//    }
//    else if (openParentheses.Peek() == '[' && closeParentheses.Peek() == ']')
//    {
//        openParentheses.Dequeue();
//        closeParentheses.Pop();
//    }
//    else if (openParentheses.Peek() == '(' && closeParentheses.Peek() == ')')
//    {
//        openParentheses.Dequeue();
//        closeParentheses.Pop();
//    }
//    else
//    {
//        Console.WriteLine("NO");
//        break;
//    }
//}
//if (closeParentheses.Count == 0 && openParentheses.Count == 0)
//{
//    Console.WriteLine("YES");
//}

//int countElements = 0;
//while (parentheses.Any())
//{
//    if (parentheses[count] == '[' || parentheses[count] == '('
//        || parentheses[count] == '{')
//    {
//        openParentheses.Push(parentheses[count]);
//        //count++;
//        parentheses.Remove(parentheses[count]);
//        countElements = openParentheses.Count;
//    }
//    else
//    {
//        for (int i = 0; i < countElements; i++)
//        {
//            if (parentheses.Count < openParentheses.Count || parentheses.Count
//                > openParentheses.Count)
//            {
//                Console.WriteLine("NO");
//                return;
//            }
//            if (openParentheses.Peek() == '[' && parentheses[i] == ']')
//            {
//                //parentheses.Remove(parentheses[i]);
//                openParentheses.Pop();
//                continue;
//            }
//            else if (openParentheses.Peek() == '(' && parentheses[i] == ')')
//            {
//                //parentheses.Remove(parentheses[i]);
//                openParentheses.Pop();
//                continue;
//            }
//            else if (openParentheses.Peek() == '{' && parentheses[i] == '}')
//            {
//                //parentheses.Remove(parentheses[i]);
//                openParentheses.Pop();
//                continue;
//            }
//            else
//            {
//                Console.WriteLine("NO");
//                return;
//            }
//        }
//        parentheses.RemoveRange(0, countElements);
//    }
//}
//if (!parentheses.Any())
//{
//    Console.WriteLine("YES");
//}
//else
//{
//    Console.WriteLine("NO");
//}


string parentheses = Console.ReadLine();

Stack<char> stack = new();

foreach (var parenthese in parentheses)
{
    switch (parenthese)
    {
        case '{':
        case '(':
        case '[':
            stack.Push(parenthese);
            break;
        case '}':
            if (stack.Count == 0 || stack.Pop() != '{')
            {
                Console.WriteLine("NO");
                return;
            }
            break;
        case ')':
            if (stack.Count == 0 || stack.Pop() != '(')
            {
                Console.WriteLine("NO");
                return;
            }
            break;
        case ']':
            if (stack.Count == 0 || stack.Pop() != '[')
            {
                Console.WriteLine("NO");
                return;
            }
            break;
    }
}

if (stack.Count > 0) // Missed case in judge ((((()))
{
    Console.WriteLine("NO");
}
else
{
    Console.WriteLine("YES");
}
