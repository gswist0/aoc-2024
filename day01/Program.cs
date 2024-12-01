
var lines = File.ReadLines("input.txt");

//part 1
var result = lines.Aggregate(new List<List<int>>{new List<int>(), new List<int>()}, (current, next) => {
    var split = next.Split("   ");
    current[0].Add(int.Parse(split[0]));
    current[1].Add(int.Parse(split[1]));
    return current;
}).Select(x => {
    x.Sort();
    return x;
}).Aggregate(new List<int>(), (current, next) => {
    if(current.Count == 0){
        current = next;
    }
    else{
        for(int i = 0; i < current.Count; i++){
            current[i] = Math.Abs(current[i] - next[i]);
        }
    }
    return current;
}).Sum();

Console.WriteLine(result);

//part 2
var result2 = lines.Aggregate(new List<List<int>>{new List<int>(), new List<int>()}, (current, next) => {
    var split = next.Split("   ");
    current[0].Add(int.Parse(split[0]));
    current[1].Add(int.Parse(split[1]));
    return current;
}).Select(x => {
    x.Sort();
    return x;
}).Aggregate(new List<int>(), (current, next) => {
    if(current.Count == 0){
        current = next;
    }
    else{
        for(int i = 0; i < current.Count; i++){
            current[i] = current[i] * next.Count(x => x == current[i]);
        }
    }
    return current;
}).Sum();

Console.WriteLine(result2);


