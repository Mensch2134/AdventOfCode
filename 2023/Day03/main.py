import re


def isSymbol(character):
    return not character.isdigit() and not character == '.'


def findSurroundingSymbol(grid, cx, cy):
    mat = [-1, 0, 1]
    symbols = []
    for row in mat:
        for column in mat:
            y = cy + row
            x = cx + column
            if y > 0 and y < len(grid):
                if x > 0 and x < len(grid[y]):
                    if isSymbol(grid[y][x]):
                        symbols.append(grid[y][x])
    return len(symbols) > 0


def task01():
    # preprocessing
    grid = []
    with open("input.txt", "r") as f:
        for line in f.readlines():
            grid.append(line.rstrip())

    # Actual algorithm
    nums = []
    for i, line in enumerate(grid):
        for match in re.finditer(r'\b\d+\b', line):
            for j in range(match.start(), match.end()):
                if findSurroundingSymbol(grid, j, i):
                    nums.append(int(line[match.start():match.end()]))
                    break

    return sum(nums)


# Part 2
def findSurroundingNumbers(grid, cx, cy):
    mat = [-1, 0, 1]
    numbers = []
    for row in mat:
        y = cy + row
        colSearchArea = set(range(cx-1, cx+2))
        if 0 <= y < len(grid):
            for candidate in re.finditer(r'\b\d+\b', grid[y]):
                if len(colSearchArea & set(range(candidate.start(), candidate.end()))) > 0:
                    numbers.append(int(grid[y][candidate.start():candidate.end()]))
    return numbers


def task02():
    # preprocessing
    grid = []
    with open("input.txt", "r") as f:
        for line in f.readlines():
            grid.append(line.rstrip())

    # Algorithm
    ratioSum = 0
    for i, line in enumerate(grid):
        gearIDs = [i for i, char in enumerate(line) if char == '*']
        for gearID in gearIDs:
            adjacents = findSurroundingNumbers(grid, gearID, i)
            if len(adjacents) == 2:
                ratioSum += adjacents[0]*adjacents[1]
    return ratioSum

if __name__ == "__main__":
    # print(task01())
    print(task02())
