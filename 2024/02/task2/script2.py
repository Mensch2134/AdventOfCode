import numpy as np

# BRUTE FORCEEEEEEEEE
def checkArray(a):
    diff = np.zeros(len(a)-1) # n-1 because there is no diff for the last (or first) element
    for i in range(1, len(a)):
        diff[i-1] = a[i] - a[i-1]
    allChanging = np.all(diff != 0)
    descOrAsc = np.all(diff < 0) or np.all(diff > 0)
    atMostThree = np.all(np.abs(diff) <= 3)
    return allChanging and descOrAsc and atMostThree

with open('input.txt') as f:
    lines = f.readlines()
    saveReports = 0
    for line in lines:
        numbers = [int(n) for n in line.strip().split(" ")]
        save = False

        # If the full report is save there is nothing else to check
        if checkArray(numbers):
            save = True
            #print(numbers, "is save")

        if not save:
            for i, number in enumerate(numbers):
                testCase = numbers.copy()
                testCase.pop(i)
                if checkArray(testCase):
                    save = True
                    #print(testCase, "of original list", numbers, "is save")
                    break
        
        if save:
            saveReports += 1
        # else:
        #     print(numbers, "is not save")


    print(saveReports, "Reports were save")