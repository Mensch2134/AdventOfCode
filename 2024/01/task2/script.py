import numpy as np

with open('input.txt') as f:
    lines = f.readlines()
    list1 = np.zeros(len(lines))
    list2 = np.zeros(len(lines))
    for i, line in enumerate(lines):
        numbers = line.strip().split("   ")
        list1[i] = int(numbers[0])
        list2[i] = int(numbers[1])

    similarity = 0
    for i, num in enumerate(list1):
        occurences = np.count_nonzero(list2 == num)
        similarity += num * occurences
    
    print("Similarity score: ", similarity)
