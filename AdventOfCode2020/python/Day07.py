import aoc
import re


rules = {}

for line in aoc.input(7):
  r_eval = lambda r, s: re.search(r, s).group(0)
  
  conditions = re.findall('\d+ \w+ \w+', line)
  current = r_eval('^\w+ \w+', line)
  rules[current] = {r_eval('\w+ \w+$', c):r_eval('^\d+', c) for c in conditions}
  
valid = []
get_iter_sum = lambda color: sum([i for i in get_containers(color)])

def get_containers(bag_color):
  for rule in rules:
    if bag_color in rules[rule] and rule not in valid:
      valid.append(rule)
      yield get_iter_sum(rule) + 1

def get_bag_count(bag_color):
  count = 0
  if len(rules[bag_color]) > 0:
    for key in rules[bag_color]:
      count += (get_bag_count(key) * int(rules[bag_color][key])) + int(rules[bag_color][key])     
  return count

print(f'part 1: {get_iter_sum("shiny gold")}')
print(f'part 2: {get_bag_count("shiny gold")}')
