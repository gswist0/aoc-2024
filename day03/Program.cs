using System.Text.RegularExpressions;

var chars = File.ReadAllText("input.txt");

//part 1

var matches = Regex.Matches(chars, @"mul\((\d+),(\d+)\)").Aggregate(0, (sum, match) => sum + int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value));

Console.WriteLine(matches);

//part 2

var matches2 = Regex.Matches(chars, @"mul\((\d+),(\d+)\)").Aggregate(0, (sum, match) => sum + ((string.Concat(chars.Take(match.Index)).LastIndexOf("do()") > string.Concat(chars.Take(match.Index)).LastIndexOf("don't()") || string.Concat(chars.Take(match.Index)).LastIndexOf("don't()") == -1) ? int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value) : 0));


Console.WriteLine(matches2);