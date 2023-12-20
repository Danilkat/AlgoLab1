// See https://aka.ms/new-console-template for more information
using AlgoLab1;
using System.Diagnostics;

long printAndReturnCurrentWorkingSet(Process process)
{
    if (process == null)
    {
        process = Process.GetCurrentProcess();
    }
    long currWorkingSet = process.WorkingSet64;
    Console.WriteLine($"Текущая потребляемая память: {currWorkingSet} байт");
    return currWorkingSet;
}

// Заполняем стек
MyStack<int> stack = new MyStack<int>();
stack.Push(1);
stack.Push(2);
stack.Push(3);

// Тестируем стек
Console.WriteLine("Текущий стек: {3, 2, 1}");
stack.PrintStack();

Console.WriteLine($"Ищем элемент 2: {stack.Contains(2)}");

int popped = stack.Pop();
Console.WriteLine($"Вытащили элемент {popped}");
stack.PrintStack();

// Заполняем очередь
MyQueue<int> queue = new MyQueue<int>();
queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);

// Тестируем очередь
Console.WriteLine("Текущая очередь: {1, 2, 3}");
queue.PrintQueue();

popped = queue.Dequeue();
Console.WriteLine($"Вытащили элемент {popped}");
queue.PrintQueue();

// Заполняем двусвязный список
DoublyLinkedList<string> doublyLinkedList = new DoublyLinkedList<string>();
doublyLinkedList.AddToFront("front1");
doublyLinkedList.AddToBack("back1");
doublyLinkedList.AddToFront("front2");
doublyLinkedList.AddToBack("back2");
doublyLinkedList.AddToFront("front3");
doublyLinkedList.AddToBack("back3");
doublyLinkedList.InsertAfter("front1", "insertedInTheMiddle");

// Тестируем двусвязный список
Console.WriteLine("ожидаемый лист: {front3, front2, front1, insertedInTheMiddle, back1, back2, back3}");
doublyLinkedList.PrintList();

doublyLinkedList.Remove("insertedInTheMiddle");
doublyLinkedList.Remove("back2");
Console.WriteLine("ожидаемый лист: {front3, front2, front1, back1, back3}");
doublyLinkedList.PrintList();


stack = null;
queue = null;
doublyLinkedList = null;
GC.Collect();
int n = 5000;
long init = printAndReturnCurrentWorkingSet(null);
Console.WriteLine($"Заполняем стек {n} целочисленных элементов");
Stack<int> smallStack = new Stack<int>();
Random random = new Random();
for (int i = 0; i < n; i++)
{
    smallStack.Push(random.Next());
}
long afterInt = printAndReturnCurrentWorkingSet(null);
long diffSmall = afterInt - init;
Console.WriteLine($"Разница: {diffSmall} байт ({diffSmall / (1024.0 * 1024.0)} Мб)");
//smallStack = null;
//GC.Collect();
long beforeArr = printAndReturnCurrentWorkingSet(null);
Console.WriteLine($"Заполняем стек {n} массивов, состоящих из сотен тысяч целочисленных элементов");
Stack<int[]> bigStack = new Stack<int[]>();
for (int i = 0; i < n; i++)
{
    int[] arr = new int[100000];
    for (int j = 0; j < arr.Length; j++)
    {
        arr[j] = random.Next();
    }
    bigStack.Push(arr);
}
long afterArr = printAndReturnCurrentWorkingSet(null);
long diffBig = afterArr - beforeArr;
Console.WriteLine($"Разница: {diffBig} байт ({diffBig / (1024.0 * 1024.0)} Мб)");
Console.WriteLine($"Увеличение размера в {diffBig / diffSmall} раз.");