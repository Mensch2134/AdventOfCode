
def task01():
    points = 0
    with open("input.txt", "r") as f:
        for line in f.readlines():
            numberSets = [l.strip() for l in line.split(": ")[1].rstrip().split(" | ")]
            winNums = [int(num.strip()) for num in numberSets[0].split(" ") if num.isdigit()]
            myNums = [int(num.strip()) for num in numberSets[1].split(" ") if num.isdigit()]

            hits = 0
            for n in myNums:
                try:
                    winNums.index(n)
                    hits += 1
                except ValueError:
                    hits = hits

            if hits > 0:
                points += 2 ** (hits - 1)

    return points


# Part 2
def task02():
    with open("input.txt", "r") as f:
        lines = f.readlines()
        copies = [1] * len(lines)
        for i, line in enumerate(lines):
            numberSets = [l.strip() for l in line.split(": ")[1].rstrip().split(" | ")]
            winNums = [int(num.strip()) for num in numberSets[0].split(" ") if num.isdigit()]
            myNums = [int(num.strip()) for num in numberSets[1].split(" ") if num.isdigit()]

            hits = 0
            for n in myNums:
                try:
                    winNums.index(n)
                    hits += 1
                except ValueError:
                    hits = hits

            if hits > 0:
                last = min(i+hits, len(copies))
                copies[i+1:last+1] = [x+copies[i] for x in copies[i+1:last+1]]
        return sum(copies)


if __name__ == "__main__":
    # print(task01())
    print(task02())
