// See https://aka.ms/new-console-template for more information
var lines = File.ReadLines("input.txt").ToList();

List<List<int>> grid = new List<List<int>>();

for (int i = 0; i < lines.Count; i++)
{
    grid.Add(new List<int>());
    foreach (var c in lines[i])
    {
        grid[i].Add(int.Parse(c.ToString()));
    }
}

firstHalf();
secondHalf();

//Halfs
void secondHalf()
{
    int gridWidth = grid[0].Count;
    int gridHeight = grid.Count;

    int highestScenicScore = 0; 

    for (int i = 1; i < gridHeight - 1; i++)          //only run both loops from index 1 to n-1 because the outer edge is visible anyways
    {
        for (int j = 1; j < gridWidth - 1; j++)
        {
            int topView = getViewDistance(grid, i, j, Dir.UP);
            int bottomView = getViewDistance(grid, i, j, Dir.DOWN);
            int leftView = getViewDistance(grid, i, j, Dir.LEFT);
            int rightView = getViewDistance(grid, i, j, Dir.RIGHT);

            var scenicScore = topView * bottomView * leftView * rightView;
            highestScenicScore = scenicScore > highestScenicScore ? scenicScore : highestScenicScore; 
        }
    }

    Console.WriteLine(highestScenicScore);
}

void firstHalf()
{
    int gridWidth = grid[0].Count;
    int gridHeight = grid.Count;

    int visibleTrees = gridHeight * 2 + gridWidth * 2 - 4;

    for (int i = 1; i < gridHeight - 1; i++)          //only run both loops from index 1 to n-1 because the outer edge is visible anyways
    {
        for (int j = 1; j < gridWidth - 1; j++)
        {
            bool vFromTop = !lookAround(grid, i, j, Dir.UP).Where(x => x >= grid[i][j]).Any();
            bool vFromBottom = !lookAround(grid, i, j, Dir.DOWN).Where(x => x >= grid[i][j]).Any();
            bool vFromLeft = !lookAround(grid, i, j, Dir.LEFT).Where(x => x >= grid[i][j]).Any();
            bool vFromRight = !lookAround(grid, i, j, Dir.RIGHT).Where(x => x >= grid[i][j]).Any();
            if (vFromTop || vFromBottom || vFromLeft || vFromRight)
                visibleTrees++;
        }
    }

    Console.WriteLine(visibleTrees);
}

//Methods
List<int> lookAround(List<List<int>> l, int row, int column, Dir dir)
{
    int rowIndex;
    int columnIndex;
    List<int> sightline = new List<int>();

    switch (dir)
    {
        case Dir.UP:
            rowIndex = 0;
            while (rowIndex < row)
            {
                if (rowIndex != row)
                    sightline.Add(l[rowIndex][column]);
                rowIndex++;
            }
            return sightline;

        case Dir.DOWN:
            rowIndex = row + 1;
            while (rowIndex < l.Count)
            {
                if (rowIndex != row)
                    sightline.Add(l[rowIndex][column]);
                rowIndex++;
            }
            return sightline;

        case Dir.LEFT:
            columnIndex = 0;
            while (columnIndex < column)
            {
                if (columnIndex != column)
                    sightline.Add(l[row][columnIndex]);
                columnIndex++;
            }
            return sightline;

        case Dir.RIGHT:
            columnIndex = column + 1;
            while (columnIndex < l[0].Count)
            {
                if (columnIndex != column)
                    sightline.Add(l[row][columnIndex]);
                columnIndex++;
            }
            return sightline;
        default: return sightline;
    }
}

int getViewDistance(List<List<int>> l, int row, int column, Dir dir)
{
    int viewDist = 0;
    var view = lookAround(l, row, column, dir);
    if (dir == Dir.UP || dir == Dir.LEFT)
    {
        view.Reverse();
    }
    viewDist = view.FindIndex(x => x >= grid[row][column]);
    return viewDist < 0 ? view.Count : viewDist + 1; ;
}

public enum Dir
{
    UP, DOWN, LEFT, RIGHT
};
