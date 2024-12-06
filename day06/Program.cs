
var lines = File.ReadAllLines("input.txt");

var grid = new char[lines.Count(), lines.ElementAt(0).Count()];
var gridB = new char[lines.Count(), lines.ElementAt(0).Count()];

char guardDirection = '^';
char guardDirectionB = '^';
(int, int) guardPosition = (0,0);
(int, int) guardPositionB = (0,0);

for (int i = 0; i < lines.Count(); i++){
    for (int j = 0; j < lines.ElementAt(0).Count(); j++){
        grid[i,j] = lines.ElementAt(i).ElementAt(j);
        gridB[i,j] = lines.ElementAt(i).ElementAt(j);
        if (grid[i,j] == '^' || grid[i,j] == '>' || grid[i,j] == '<' || grid[i,j] == 'v'){
            guardDirection = grid[i,j];
            guardPosition = (i,j);
            guardDirectionB = grid[i,j];
            guardPositionB = (i,j);
        }
    }
}

//part1


var guardInside = true;

while (guardInside){
    switch(guardDirection){
        case '^':
            grid[guardPosition.Item1, guardPosition.Item2] = 'X';
            if(guardPosition.Item1 - 1 >= 0 && grid[guardPosition.Item1 - 1, guardPosition.Item2] == '#'){
                guardDirection = '>';
            }
            else{
                guardPosition = (guardPosition.Item1 - 1, guardPosition.Item2);
            }
            break;
        case '>':
            grid[guardPosition.Item1, guardPosition.Item2] = 'X';
            if(guardPosition.Item2 + 1 < grid.GetLength(0) && grid[guardPosition.Item1, guardPosition.Item2 + 1] == '#'){
                guardDirection = 'v';
            }
            else{
                guardPosition = (guardPosition.Item1, guardPosition.Item2 + 1);
            }
            break;
        case 'v':
            grid[guardPosition.Item1, guardPosition.Item2] = 'X';
            if(guardPosition.Item1 + 1 < grid.GetLength(1) && grid[guardPosition.Item1 + 1, guardPosition.Item2] == '#'){
                guardDirection = '<';
            }
            else{
                guardPosition = (guardPosition.Item1 + 1, guardPosition.Item2);
            }
            break;
        case '<':
            grid[guardPosition.Item1, guardPosition.Item2] = 'X';
            if(guardPosition.Item2 - 1 >= 0 && grid[guardPosition.Item1, guardPosition.Item2 - 1] == '#'){
                guardDirection = '^';
            }
            else{
                guardPosition = (guardPosition.Item1, guardPosition.Item2 - 1);
            }
            break;
    }

    if(guardPosition.Item1 < 0 || guardPosition.Item1 >= grid.GetLength(0) || guardPosition.Item2 < 0 ||guardPosition.Item2 >= grid.GetLength(1)){
        guardInside = false;
    }
}

var visited = new List<(int,int)>();

var counter = 0;
for (int i = 0; i < grid.GetLength(0); i++){
    for (int j = 0; j < grid.GetLength(1); j++){
        if(grid[i,j] == 'X'){
            visited.Add((i,j));
            counter++;
        }
    }
}

Console.WriteLine(counter);


//part2

var loopedCounter = 0;

for(int i = 0; i < gridB.GetLength(0); i++){
    for (int j = 0; j < gridB.GetLength(1);j++){
        var guardInside2 = true;

        List<(int, int, char)> prevObstacles = new List<(int, int, char)>();

        var grid2 = new char[lines.Count(), lines.ElementAt(0).Count()];
        for(int x = 0; x < gridB.GetLength(0); x++){
            for(int y = 0; y < gridB.GetLength(1); y++){
                grid2[x,y] = gridB[x,y];
            }
        }

        grid2[i,j] = '#';

        char guardDirection2 = guardDirectionB;
        (int, int) guardPosition2 = (guardPositionB.Item1, guardPositionB.Item2);

        if ((i,j) == guardPosition2 || !visited.Contains((i,j))){
            continue;
        }


        while (guardInside2){  
            var obstacleHit = false;
            var obstacle = (-1,-1);
            var from = 'x';
            switch(guardDirection2){
                case '^':
                    grid2[guardPosition2.Item1, guardPosition2.Item2] = 'X';
                    if(guardPosition2.Item1 - 1 >= 0 && grid2[guardPosition2.Item1 - 1, guardPosition2.Item2] == '#'){
                        guardDirection2 = '>';
                        obstacleHit = true;
                        obstacle = (guardPosition2.Item1 - 1, guardPosition2.Item2);
                        from = '^';
                    }
                    else{
                        guardPosition2 = (guardPosition2.Item1 - 1, guardPosition2.Item2);
                    }
                    break;
                case '>':
                    grid2[guardPosition2.Item1, guardPosition2.Item2] = 'X';
                    if(guardPosition2.Item2 + 1 < grid2.GetLength(0) && grid2[guardPosition2.Item1, guardPosition2.Item2 + 1] == '#'){
                        guardDirection2 = 'v';
                        obstacleHit = true;
                        obstacle = (guardPosition2.Item1, guardPosition2.Item2 + 1);
                        from = '>';
                    }
                    else{
                        guardPosition2 = (guardPosition2.Item1, guardPosition2.Item2 + 1);
                    }
                    break;
                case 'v':
                    grid2[guardPosition2.Item1, guardPosition2.Item2] = 'X';
                    if(guardPosition2.Item1 + 1 < grid2.GetLength(1) && grid2[guardPosition2.Item1 + 1, guardPosition2.Item2] == '#'){
                        guardDirection2 = '<';
                        obstacleHit = true;
                        obstacle = (guardPosition2.Item1 + 1, guardPosition2.Item2);
                        from = 'v';
                    }
                    else{
                        guardPosition2 = (guardPosition2.Item1 + 1, guardPosition2.Item2);
                    }
                    break;
                case '<':
                    grid2[guardPosition2.Item1, guardPosition2.Item2] = 'X';
                    if(guardPosition2.Item2 - 1 >= 0 && grid2[guardPosition2.Item1, guardPosition2.Item2 - 1] == '#'){
                        guardDirection2 = '^';
                        obstacleHit = true;
                        obstacle = (guardPosition2.Item1, guardPosition2.Item2 - 1);
                        from = '<';
                    }
                    else{
                        guardPosition2 = (guardPosition2.Item1, guardPosition2.Item2 - 1);
                    }
                    break;
            }
            if(prevObstacles.Contains((obstacle.Item1, obstacle.Item2,from))){
                loopedCounter++;
                guardInside2 = false;
            }
            if(obstacleHit){
                prevObstacles.Add((obstacle.Item1, obstacle.Item2,from));
            }

            if(guardPosition2.Item1 < 0 || guardPosition2.Item1 >= grid2.GetLength(0) || guardPosition2.Item2 < 0 ||guardPosition2.Item2 >= grid2.GetLength(1)){
                guardInside2 = false;
            }
            
        }

    }
}

Console.WriteLine(loopedCounter);