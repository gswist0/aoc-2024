
var lines = File.ReadAllLines("input.txt").Select(x => {
    var split = x.Split(": ");
    var target = long.Parse(split[0]);
    var values = split[1].Split(' ').ToList().Select(x => long.Parse(x)).ToList();
    return (target, values);
});

var operationsP1 = new Func<long, long, long>[] {
    Add,
    Mul
};

var operationsP2 = new Func<long, long, long>[] {
    Add,
    Mul,
    Con
};

var result = lines.Aggregate((long)0, (current, next) => {
    if (FindRecursive(next.values, operationsP1, 0, 0, next.target, Add)){
        return current + next.target;
    }
    return current;
});

Console.WriteLine(result);

var result2 = lines.Aggregate((long)0, (current, next) => {
    if (FindRecursive(next.values, operationsP2, 0, 0, next.target, Add)){
        return current + next.target;
    }
    return current;
});

Console.WriteLine(result2);

bool FindRecursive(List<long> values, Func<long, long, long>[] operations, int index, long accumulator, long target, Func<long, long, long> operation){
    if (accumulator > target)
        return false;

    if (index >= values.Count())
        return accumulator == target;

    var value = operation(accumulator, values[index]);

    var result = false;
    for (int i = 0; !result && i < operations.Length; i++){
        result = result || FindRecursive(values, operations, index + 1, value, target, operations[i]);
    }

    return result;
}

static long Add(long a, long b) => a + b;
static long Mul(long a, long b) => a * b;
static long Con(long a, long b) => long.Parse(a.ToString() + b);