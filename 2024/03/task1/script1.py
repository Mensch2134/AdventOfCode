import re

def execute(instruction):
    factors = re.findall(r"\d{1,3}", instruction)
    product = 1
    for factor in factors:
        product *= int(factor)
    return product

with open("input.txt") as f:
    lines = f.readlines()
    aggregatedSum = 0
    for line in lines:
        matches = re.findall(r"mul\(\d{1,3},\d{1,3}\)", line)
        results = [execute(m) for m in matches]
        aggregatedSum += sum(results)
    print(aggregatedSum)