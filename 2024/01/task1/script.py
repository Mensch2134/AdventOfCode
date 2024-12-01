import numpy as np

with open('input.txt') as f:
    lines = f.readlines()
    list1 = np.zeros(len(lines))
    list2 = np.zeros(len(lines))
    for i, line in enumerate(lines):
        numbers = line.strip().split("   ")
        list1[i] = int(numbers[0])
        list2[i] = int(numbers[1])

    list1 = np.sort(list1)
    list2 = np.sort(list2)
    
    sumOfDifferences = np.sum(np.abs(list2 - list1))
    print(sumOfDifferences)
