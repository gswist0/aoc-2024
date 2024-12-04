var lines1 = File.ReadLines("input.txt");

//part1


//2

int rows2 = lines1.Count();
int cols2 = lines1.ElementAt(0).Count();
var lines2T = new char[cols2, rows2];

for (int i = 0; i < rows2; i++){
    for (int j = 0; j < cols2; j++){
        lines2T[j, i] = lines1.ElementAt(i).ElementAt(j);
    }
}

var lines2 = new List<List<char>>();
for(int i = 0; i < lines2T.GetLength(0); i++){
    var temp = new List<char>();
    for(int j = 0; j < lines2T.GetLength(1); j++){
        temp.Add(lines2T[i,j]);
    }
    lines2.Add(temp);
}

//3

int rows3 = lines1.Count();
int cols3 = lines1.ElementAt(0).Count();

var lines3 = new List<List<char>>();


for (int i = 0; i < rows3 + cols3 -1; i++){
    var curLine = new List<char>();
    int startRow = Math.Max(0, rows3 - 1 - i);
    int startCol = Math.Max(0, i - (rows3 - 1));

    while(startRow < rows3 && startCol < cols3){
        curLine.Add(lines1.ElementAt(startRow).ElementAt(startCol));
        startRow++;
        startCol++;
    }
    lines3.Add(curLine);
}


//4

int rows4 = lines1.Count();
int cols4 = lines1.ElementAt(0).Count();
var lines4 = new List<List<char>>();



for (int i = 0; i < rows4 + cols4 -1; i++){
    var curLine = new List<char>();
    int startRow = i < cols4 ? 0 : i - cols4 + 1;
    int startCol = i < cols4 ? i : cols4 - 1;

    while(startRow < rows4 && startCol >= 0){
        curLine.Add(lines1.ElementAt(startRow).ElementAt(startCol));
        startRow++;
        startCol--;
    }
    lines4.Add(curLine);
}

int result = 0;

foreach (var line in lines1){
    var count1 = line.Split("XMAS").Length - 1 + line.Split("SAMX").Length - 1;
    result += line.Split("XMAS").Length - 1;
    result += line.Split("SAMX").Length - 1;
}

foreach (var line in lines2){
    var temp = "";
    foreach(var c in line) temp += c;
    var count2 = temp.Split("XMAS").Length - 1 + temp.Split("SAMX").Length - 1;
    result += temp.Split("XMAS").Length - 1;
    result += temp.Split("SAMX").Length - 1;
}

foreach (var line in lines3){
    var temp = "";
    foreach(var c in line) temp += c;
    var count3 = temp.Split("XMAS").Length - 1 + temp.Split("SAMX").Length - 1;
    result += temp.Split("XMAS").Length - 1;
    result += temp.Split("SAMX").Length - 1;
}

foreach (var line in lines4){
    var temp = "";
    foreach(var c in line) temp += c;
    var count4 = temp.Split("XMAS").Length - 1 + temp.Split("SAMX").Length - 1;
    result += temp.Split("XMAS").Length - 1;
    result += temp.Split("SAMX").Length - 1;
}

Console.WriteLine(result);

//part 2

var result2 = 0;

for (int i = 1; i < lines2T.GetLength(0) - 1; i ++){
    for (int j = 1; j < lines2T.GetLength(1) - 1; j ++){
        if (lines2T[i,j] != 'A')    
            continue;
        var left = false;
        var right = false;
        if (lines2T[i-1, j-1] == 'M' && lines2T[i+1, j+1] == 'S'){
            left = true;
        }
        if (lines2T[i-1, j-1] == 'S' && lines2T[i+1, j+1] == 'M'){
            left = true;
        }
        if (lines2T[i-1, j+1] == 'M' && lines2T[i+1, j-1] == 'S'){
            right = true;
        }
        if (lines2T[i-1, j+1] == 'S' && lines2T[i+1, j-1] == 'M'){
            right = true;
        }
        if (left && right){
            result2++;
        }
    }
}

Console.WriteLine(result2);