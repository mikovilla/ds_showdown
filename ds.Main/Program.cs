using ds.Application;
using ds.Main;
using ds.Utility;
using Newtonsoft.Json;
using System.Collections.Concurrent;

Dictionary<string, string> englishDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(@"C:\Users\dev\solutions\ds_showdown\ds.Main\dictionary.json")) ?? new Dictionary<string, string>();
englishDictionary.GetIntroduction();

Dictionary<string, string> hashMap = new Dictionary<string, string>();
BinarySearchTree tree = new BinarySearchTree();

var threadIds = new ConcurrentBag<int>();
string wordToSearch = "programme";

Parallel.Invoke(
    () =>
    {
        int threadId = Thread.CurrentThread.ManagedThreadId;
        threadIds.Add(threadId);
        string hashMapInsertionMetrics = Instrumentation.GetMetrics($"HashMap Insertion ({threadId})", () =>
        {
            hashMap.IterateInsert(englishDictionary);
        });
        hashMapInsertionMetrics.DisplayInfo(hm => Console.WriteLine(hm));
    },
    () =>
    {
        int threadId = Thread.CurrentThread.ManagedThreadId;
        threadIds.Add(threadId);
        string treeInsertionMetrics = Instrumentation.GetMetrics($"Binary Search Tree Insertion ({threadId})", () =>
        {
            tree.IterateInsert(englishDictionary);
        });
        treeInsertionMetrics.DisplayInfo(bst => Console.WriteLine(bst));
    }
);

string hMapDefinition = string.Empty, treeDefinition = string.Empty;
Thread.Sleep(1000);
Parallel.Invoke(
    () => { GC.Collect(); Thread.Sleep(1000); },
    () =>
    {
        int threadId = Thread.CurrentThread.ManagedThreadId;
        threadIds.Add(threadId);
        Console.WriteLine();
        string hashMapSearchMetrics = Instrumentation.GetMetrics($"HashMap LookUp ({threadId})", () =>
        {
            hMapDefinition = hashMap[wordToSearch]!;
        });
        hashMapSearchMetrics.DisplayInfo(hm => Console.WriteLine(hm));
    },
    () =>
    {
        int threadId = Thread.CurrentThread.ManagedThreadId;
        threadIds.Add(threadId);
        string treeSearchMetrics = Instrumentation.GetMetrics($"Binary Search Tree LookUp ({threadId})", () =>
        {
            treeDefinition = tree.Search("programme")!;
        });
        treeSearchMetrics.DisplayInfo(bst => Console.WriteLine(bst));
    }
);

Extra.GetOutro(
    $"{wordToSearch} (HMAP Definition): {hMapDefinition}",
    $"{wordToSearch} (TREE Definition): {treeDefinition}"
);





