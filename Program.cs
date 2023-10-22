using System.Globalization;
using System.Reflection.Metadata;
using static System.Math;
namespace Prog1;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Solve3("B2.txt"));
    }

    // 4 сделано на занятии
    static int Solve4(string path) {
        string[] rawData = File.ReadAllLines(path);
        int numberOfEntries = int.Parse(rawData[0]);

        List<int> buffer = new List<int>();

        foreach (string i in rawData) {
            buffer.Add(int.Parse(i));
        }

        buffer.Remove(buffer[0]);

        int[] tbsArr = buffer.ToArray();
        Array.Sort(tbsArr);
        Array.Reverse(tbsArr);
        

        for (int i = 0; i < tbsArr.Length; i++) {
            
            for (int j = 0; j < tbsArr.Length; j++) {
                if (i == j) {
                    continue;
                }
                else if (i != j && ((tbsArr[i] * tbsArr[j]) % 14) != 0) {
                    continue;
                }
                else if (i != j && ((tbsArr[i] * tbsArr[j]) % 14) == 0) {
                    return tbsArr[i] * tbsArr[j];
                } 
            }
            
        }

        return 0;
    }

    // 3 сделано на занятии
    static int Solve3(string path) {
        string[] rawData = File.ReadAllLines(path);

        int num = 0;

        List<int> sub = new List<int>();
        List<int> sum = new List<int>();

        for (int i = 1; i < rawData.Length; i++) {
            string[] pair = rawData[i].Split(" ");
            
            int num1 = int.Parse(pair[0]);
            int num2 = int.Parse(pair[1]);

            num = Max(num1, num2);

            sum.Add(num);

            int diff = Abs(num1 - num2);
            if ((diff % 5) != 0) sub.Add(diff);
        }

        sub.Sort();

        int totalsum = sum.Sum();

        if ((totalsum % 5) == 0) {
            return totalsum - sub[0];
        }

        return totalsum;
    }

    // 2 сделано на занятии
    static int Solve2(string path) {
        string[] rawData = File.ReadAllLines(path);
        int numberOfPairs = int.Parse(rawData[0]);

        int num = 0;

        List<int> sum = new List<int>();
        List<int> sub = new List<int>();
        for (int i = 1; i < rawData.Length; i++) {

            string[] pairStr = rawData[i].Split(" ");

            int pairA = int.Parse(pairStr[0]);
            int pairB = int.Parse(pairStr[1]);

            num = Min(pairA, pairB);
            sum.Add(num);

            if (((pairA - pairB) % 3) != 0) sub.Add(Abs(pairA - pairB));


        }

        sub.Sort();
        sub.Reverse();

        int sumnew = sum.Sum();

        if ((sumnew % 3) == 0) {
            return sumnew + sub[0];
        }

        return sumnew;
    }

     // 1 сделано на занятии
    static int ReadAndProcessFile(string path) {
        string[] rawData = File.ReadAllLines(path);
        int numberOfPairs = int.Parse(rawData[0]);

        int num = 0;

        List<int> sum = new List<int>();
        List<int> sub = new List<int>();
        for (int i = 1; i < rawData.Length; i++) {

            string[] pairStr = rawData[i].Split(" ");

            int pairA = int.Parse(pairStr[0]);
            int pairB = int.Parse(pairStr[1]);

            num = Max(pairA, pairB);
            sum.Add(num);

            int subnum = pairA - pairB;

            if ((subnum % 3) != 0) { sub.Add(Abs(subnum)); }
        }

        sub.Sort();
        int sumnew = sum.Sum();

        if ((sumnew % 3) == 0) {

            return sumnew - sub[0];
        }

        return sumnew;

    }

    static int Solve5(string path) {

        // Зачитали файл
        string[] inputNumList = File.ReadAllLines(path);
        
        // Превратили массив стрингов в инты и убрали число строк
        List<int> buffer = new List<int>();
        foreach (string i in inputNumList) {
            buffer.Add(int.Parse(i));
        }
        buffer.Remove(buffer[0]);

        // Проинициализировали список для пар
        List<(int, int)> ipairs = new List<(int, int)>();
        for (int i = 0; i < buffer.Count; i++) {

            for (int j = 0; j < buffer.Count; j++) {
                if (i == j) continue;
                else if (i != j && (buffer[i] * buffer[j] % 26) != 0) continue;
                else if (i != j && (buffer[i] * buffer[j] % 26) == 0) {
                    ipairs.Add((buffer[i], buffer[j]));
                }
            } 
        }

        return ipairs.Count;
    }

    static int Solve6(string path) {

        // Зачитали файл
        string[] inputNumList = File.ReadAllLines(path);
        
        // Превратили массив стрингов в инты и убрали число строк
        List<int> buffer = new List<int>();
        foreach (string i in inputNumList) {
            buffer.Add(int.Parse(i));
        }
        buffer.Remove(buffer[0]);

        // Проинициализировали список для пар
        List<(int, int)> ipairs = new List<(int, int)>();
        for (int i = 0; i < buffer.Count; i++) {

            for (int j = 0; j < buffer.Count; j++) {
                if (i == j) continue;
                else if (i != j && (buffer[i] * buffer[j] % 62) != 0) continue;
                else if (i != j && (buffer[i] * buffer[j] % 62) == 0) {
                    ipairs.Add((buffer[i], buffer[j]));
                }
            } 
        }

        return ipairs.Count;
    }


    /* Нужно либо пару с макс суммой, либо 00, но у C# статическая типизация
    * З.Ы. в TS можно возвращать один из двух типов например public String | Array solve7(String path)
    */
    static (int, int) Solve7(string path) {

        // Зачитали файл
        string[] inputNumList = File.ReadAllLines(path);
        
        // Превратили массив стрингов в инты и убрали число строк
        List<int> buffer = new List<int>();
        foreach (string i in inputNumList) {
            buffer.Add(int.Parse(i));
        }
        buffer.Remove(buffer[0]);

        // Создали списки для пар и сумм
        Dictionary<(int, int), int> pairsandSums = new Dictionary<(int, int), int>();


        // Просчитали и отсеяли числа
        for (int i = 0; i < buffer.Count; i++) {
            for (int j = 0; j < buffer.Count; j++) {
                if (i == j) continue;
                else if (i != j && (((buffer[i] % 17) != 0) || ((buffer[i] % 17) != 0)) && ((Abs(buffer[i] - buffer[j]) % 2) != 0)) {
                    continue;
                } else if (i != j && (((buffer[i] % 17) == 0) || ((buffer[i] % 17) == 0))  && ((Abs(buffer[i] - buffer[j]) % 2) == 0)) {
                    pairsandSums.Add((buffer[i], buffer[j]), buffer[i] + buffer[j]);
                    
                }
            }
        }

        SortedDictionary<(int, int), int> sorted = (SortedDictionary<(int, int), int>)pairsandSums.OrderByDescending(f => f.Value);

        return sorted.Keys.Count != 0 ? sorted.Keys.ToArray()[0] : (0, 0);
    }


    // Отличается от 7 логическими выражениями, в остальном алгоритм тот же
    static (int, int) Solve8(string path) {

        // Зачитали файл
        string[] inputNumList = File.ReadAllLines(path);
        
        // Превратили массив стрингов в инты и убрали число строк
        List<int> buffer = new List<int>();
        foreach (string i in inputNumList) {
            buffer.Add(int.Parse(i));
        }
        buffer.Remove(buffer[0]);

        // Создали списки для пар и сумм
        Dictionary<(int, int), int> pairsandSums = new Dictionary<(int, int), int>();


        // Просчитали и отсеяли числа
        for (int i = 0; i < buffer.Count; i++) {
            for (int j = 0; j < buffer.Count; j++) {
                if (i == j) {
                    continue;
                }
                else if (i != j && ((buffer[i] % 160) == (buffer[j] % 160)) && (((buffer[i] % 7) != 0) || (buffer[j] % 7) != 0)) {
                    continue;
                } else if (i != j && ((buffer[i] % 160) != (buffer[j] % 160)) && (((buffer[i] % 7) == 0) || (buffer[j] % 7) == 0)) {
                    pairsandSums.Add((buffer[i], buffer[j]), buffer[i] + buffer[j]);
                }
            }
        }

        SortedDictionary<(int, int), int> sorted = (SortedDictionary<(int, int), int>)pairsandSums.OrderByDescending(f => f.Value);

        (int pairA, int pairB) = (0, 0);

        try {
            (pairA, pairB) = sorted.Keys.ToArray()[0];
            if (pairA > pairB) (pairA, pairB) = (pairB, pairA); else (pairA, pairB) = (pairB, pairA);
        } catch {
            Console.WriteLine("Искомая пара не найдена.");
        }
        

        return (pairA, pairB);
    }

    // Чтобы не копипастить решение задач с одинаковым условием и различными логическими выражениями, решил решить (sic!) 10.
    static (int, int) Solve10(string path) {
        string[] rawData = File.ReadAllLines(path);
        List<int> buffer = new List<int>();

        foreach (string entry in rawData) {
            buffer.Add(int.Parse(entry));
        }
        buffer.Remove(buffer[0]);

        Dictionary<(int, int), int> valuePairs = new Dictionary<(int, int), int>();

        for (int i = 0; i < buffer.Count; i++) {
            for (int j = 0; j < buffer.Count; j++) {
                if (i == j || i > j) continue;
                if (i < j) {
                    if (buffer[i] > buffer[j]) {
                        int sum = buffer[i] + buffer[j];
                        if ((sum % 120) == 0) {
                            valuePairs.Add((buffer[i], buffer[j]), sum);
                        }
                    }
                }
            }
        }

        SortedDictionary<(int, int), int> sorted = (SortedDictionary<(int, int), int>)valuePairs.OrderByDescending(f => f.Value);

        try {
            return sorted.Keys.ToArray()[0];
        } catch (IndexOutOfRangeException) {
            return (0, 0);
        }        
    }
}
