import numpy as np

with open('input.txt') as f:
    lines = f.readlines()
    saveReports = 0
    for line in lines:
        numbers = [int(n) for n in line.strip().split(" ")]
        diff = np.zeros(len(numbers)-1) # n-1 because there is no diff for the last (or first) element
        for i in range(1, len(numbers)):
            diff[i-1] = numbers[i] - numbers[i-1]
        
        # Check if diff has consistent sign and is not greater than 3
        save = (not (np.any(diff <= 0) and np.any(diff >= 0))) and np.all(np.abs(diff) <= 3)
        if save:
            saveReports += 1

    print(saveReports, "Reports were save")
