using System.Text.RegularExpressions;

var chars = File.ReadAllText("input.txt");

//part 1

var matches = Regex.Matches(chars, @"mul\((\d+),(\d+)\)").Aggregate(0, (sum, match) => sum + int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value));

Console.WriteLine(matches);

//part 2

var matches2 = Regex.Matches(chars, @"mul\((\d+),(\d+)\)").Aggregate(0, (sum, match) => {
    var position = match.Index;
    var cutOff = chars.Take(position);
    var doIndex = string.Concat(cutOff).LastIndexOf("do()");
    var dontIndex = string.Concat(cutOff).LastIndexOf("don't()");
    if (doIndex > dontIndex  || dontIndex == -1)
        return sum + int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
    else return sum;
});

Console.WriteLine(matches2);