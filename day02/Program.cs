
using System.Xml;

var lines = File.ReadLines("input.txt");

//part1

var result = lines.Select(line => {
    var goodLine = line.Split(" ").Aggregate(new {check = true, prev = -1, inc = -1}, (current, next) => {
        if (!current.check){
            return current;
        }
        if (current.prev == -1){
            current = new {check = true, prev = int.Parse(next), inc = -1};
            return current;
        }
        var curInc = -1;

        if (current.prev < int.Parse(next) ){
            curInc = 1;
        }
        else
        {
            curInc = 0;
        }
        if (current.inc != -1 && current.inc != curInc){
            return new {check = false, prev = -1, inc = -1};
        }

        var diff = current.prev - int.Parse(next);
        if (Math.Abs(diff) > 3 || diff == 0){
            return new {check = false, prev = -1, inc = -1};
        }
        else
        {
            return new {check = true, prev = int.Parse(next), inc = curInc};
        }
    });
    return goodLine.check;
}).Count(x => x);

Console.WriteLine(result);

//part2

var result2 = lines.Select(line => {
    var split = line.Split(" ");
    var check = false;
    for (int i = 0; i < split.Count(); i++){
        var newLine = new List<string>();
        foreach (var x in split){
            newLine.Add(x);
        }
        newLine.RemoveAt(i);

        var goodLine = newLine.Aggregate(new {check = true, prev = -1, inc = -1}, (current, next) => {
            if (!current.check){
                return current;
            }
            if (current.prev == -1){
                current = new {check = true, prev = int.Parse(next), inc = -1};
                return current;
            }
            var curInc = -1;

            if (current.prev < int.Parse(next) ){
                curInc = 1;
            }
            else
            {
                curInc = 0;
            }
            if (current.inc != -1 && current.inc != curInc){
                return new {check = false, prev = -1, inc = -1};
            }

            var diff = current.prev - int.Parse(next);
            if (Math.Abs(diff) > 3 || diff == 0){
                return new {check = false, prev = -1, inc = -1};
            }
            else
            {
                return new {check = true, prev = int.Parse(next), inc = curInc};
            }
        });
        if (goodLine.check){
            check = true;
            break;
        }
    }
    return check;

}).Count(x => x);

Console.WriteLine(result2);
