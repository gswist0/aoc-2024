
var lines = File.ReadAllLines("input.txt");

var rules = lines.Where(x => x.Contains('|')).Select(x => {
    var split = x.Split('|');
    return (split[0], split[1]);
});
var updates = lines.Where(x => !x.Contains('|') && !string.IsNullOrWhiteSpace(x));

//part1

var result = updates.Aggregate(0, (current, update) => {
    var split = update.Split(',');
    var violation = false;

    for (int i = 0; i < split.Length; i++){
        for (int j = 0; j < split.Length; j++){
            if ( i == j ) 
                continue;
            if (i < j) {
                var found = rules.Where(x => {
                    return x.Item1 == split[j] && x.Item2 == split[i];
                }).Count();
                if (found > 0){
                    violation = true;
                }
            }
            if (i > j){
                var found = rules.Where(x => {
                    return x.Item1 == split[i] && x.Item2 == split[j];
                }).Count();
                if (found > 0){
                    violation = true;
                }
            }
        }
    }

    if (violation)
        return current;
    else
        return current + int.Parse(split[(split.Length - 1) / 2 ]);
});

Console.WriteLine(result);

//part2

var result2 = updates.Aggregate(0, (current, update) => {
    var split = update.Split(',');
    var violation = false;

    for (int i = 0; i < split.Length; i++){
        for (int j = 0; j < split.Length; j++){
            if ( i == j ) 
                continue;
            if (i < j) {
                var found = rules.Where(x => {
                    return x.Item1 == split[j] && x.Item2 == split[i];
                }).Count();
                if (found > 0){
                    violation = true;
                }
            }
            if (i > j){
                var found = rules.Where(x => {
                    return x.Item1 == split[i] && x.Item2 == split[j];
                }).Count();
                if (found > 0){
                    violation = true;
                }
            }
        }
    }

    if (violation){
        var temp = split.ToList();
        temp.Sort(new Sorter(rules));
        return current + int.Parse(temp[(temp.Count() - 1) / 2 ]);
    }
    else
        return current;
        
});

Console.WriteLine(result2); 


class Sorter : IComparer<string>
{
    private IEnumerable<(string, string)> Rules;

    public Sorter(IEnumerable<(string, string)> rules){
        Rules = rules;
    }

    public int Compare(string x, string y){
        var found = Rules.Where(rule => {
            return rule.Item1 == x && rule.Item2 == y;
        }).Count();
        if (found > 0){
            return -1;
        }
        var found2 = Rules.Where(rule => {
            return rule.Item1 == y && rule.Item2 == x;
        }).Count();
        if (found2 > 0){
            return 1;
        }
        return 0;
    }

}

