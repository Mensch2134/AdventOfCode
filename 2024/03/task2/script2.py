import re

def execute(instruction):
    factors = re.findall(r"\d{1,3}", instruction)
    product = 1
    for factor in factors:
        product *= int(factor)
    return product

with open("input.txt") as f:
    line = f.read()
    aggregatedSum = 0
    executing = True
    while True:
        nextInstruction = re.search(r"mul\(\d{1,3},\d{1,3}\)", line)

        nextDo = re.search(r"do\(\)", line)
        if nextDo and nextInstruction:
            nextInstruction = nextDo if nextDo.start() < nextInstruction.start() else nextInstruction
            
        nextDont = re.search(r"don't\(\)", line)
        if nextDont and nextInstruction:
            nextInstruction = nextDont if nextDont.start() < nextInstruction.start() else nextInstruction
    
        # If no matches are found, break loop because then string is "empty"
        if not nextInstruction:
            break
        
        instructionStr = nextInstruction[0]
        if instructionStr.startswith("mul") and executing:
            aggregatedSum += execute(instructionStr)
        elif instructionStr.startswith("don't"):
            executing = False
        elif instructionStr.startswith("do"):
            executing = True
        
        # Cut string after executed instruction
        line = line[nextInstruction.end():]
    print(aggregatedSum)