
import math

def calib_trebuchet():
    with open("input.txt", 'r') as f:
        calibration_values = []
        for line in f.readlines():
            nums = list(filter(str.isdigit, line))
            num = int(nums[0]+nums[-1])
            calibration_values.append(num)
        return sum(calibration_values)

def calib_trebuchet_02():
    digitNames = {
        'one': 1,
        'two': 2,
        'three': 3,
        'four': 4,
        'five': 5,
        'six': 6,
        'seven': 7,
        'eight': 8,
        'nine': 9
    }
    with open("input_02.txt", "r") as f:
        calibration_values = []
        for line in f.readlines():
            first = (math.inf, None)
            last = (-1, None)
            lineList = list(line.rstrip())
            print(line)
            for key in digitNames.keys():
                f = line.find(key)
                l = line.rfind(key)
                if f != -1 and f < first[0]:
                    first = (f, key)
                if l != -1 and l > last[0]:
                    last = (l, key)
            if not first[1] is None:
                lineList[first[0]] = str(digitNames[first[1]])
            if not last[1] is None and last[0] != first[0]:
                lineList[last[0]] = str(digitNames[last[1]])

            nums = list(filter(str.isdigit, lineList))
            num = int(nums[0] + nums[-1])
            calibration_values.append(num)
        return sum(calibration_values)

if __name__ == '__main__':
    #print(calib_trebuchet())
    print(calib_trebuchet_02())