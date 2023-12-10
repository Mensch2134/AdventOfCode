from functools import reduce
from operator import mul

def task01():
    with open("input.txt", "r") as f:
        gameIDSum = 0
        for line in f.readlines():
            id = int(line.split(": ")[0].split(" ")[1])
            runs = line.split(": ")[1].split("; ")
            valid = True
            for run in runs:
                run = run.rstrip()
                grabs = run.split(", ")
                for grab in grabs:
                    num = int(grab.split(" ")[0])
                    color = grab.split(" ")[1]
                    if color == 'red' and num > 12 or color == 'green' and num > 13 or color == 'blue' and num > 14:
                        valid = False
            if valid:
                gameIDSum += id
    return gameIDSum

def task02():
    with open("input2.txt", "r") as f:
        gamePowerSum = 0
        for line in f.readlines():
            id = int(line.split(": ")[0].split(" ")[1])
            runs = line.split(": ")[1].split("; ")
            minimumCubes = [0, 0, 0] #red, green, blue
            for run in runs:
                run = run.rstrip()
                grabs = run.split(", ")
                for grab in grabs:
                    num = int(grab.split(" ")[0])
                    color = grab.split(" ")[1]
                    if color == 'red' and num > minimumCubes[0]:
                        minimumCubes[0] = num
                    elif color == 'green' and num > minimumCubes[1]:
                        minimumCubes[1] = num
                    elif color == 'blue' and num > minimumCubes[2]:
                        minimumCubes[2] = num
            power = reduce(mul, minimumCubes)
            gamePowerSum += power
        return gamePowerSum


if __name__ == "__main__":
    print(task01())
    print(task02())