

def almanac_map(number, dest, source, len):
    for d, s, l in zip(dest, source, len):
        if s <= number < s + l:
            return d + (number - s)
    return number

def task01():
    with open("input.txt", "r") as f:
        rulesets = f.read().split('\n\n')

    lines = rulesets[0].split('\n')
    seeds = [int(x.strip()) for x in lines[0].split(": ")[1].split(" ")]

    locations = []

    for seed in seeds:
        for ruleset in rulesets[1:]:
            rules = []
            for rule in ruleset.split('\n')[1:]:
                rules.append([int(x.strip()) for x in rule.split(" ")])
            rules = list(zip(*rules))   # transpose ruleset to match my almanac_map function input
            seed = almanac_map(seed, rules[0], rules[1], rules[2])
        locations.append(seed)

    return min(locations)


# Part 2
def task02():
    with open("example.txt", "r") as f:
        rulesets = f.read().split('\n\n')

    lines = rulesets[0].split('\n')
    seeds = [int(x.strip()) for x in lines[0].split(": ")[1].split(" ")]
    starts = seeds[0::2]
    lengths = seeds[1::2]

    seeds = []
    for i, start in enumerate(starts):
        seeds += list((start, start+lengths[i]))

    # Not working bc of stupidly large n of seeds that i treated as list rather than range

    for seed in seeds:
        for ruleset in rulesets[1:]:
            rules = []
            for rule in ruleset.split('\n')[1:]:
                rules.append([int(x.strip()) for x in rule.split(" ")])
            rules = list(zip(*rules))  # transpose ruleset to match my almanac_map function input
            seed = almanac_map(seed, rules[0], rules[1], rules[2])
        min_location = min(min_location, seed)

    return min_location

if __name__ == "__main__":
    #print(task01())
    print(task02())
