import aoc
from copy import deepcopy


adapters = [int(adapter[:-1]) for adapter in aoc.input(10)]
adapters.sort()


ones = 0
threes = 1
prev = 0
for adapter in adapters:
  diff = adapter - prev
  if diff == 1:
    ones += 1
  if diff == 3:
    threes += 1
  prev = adapter
print(f'part 1: {ones * threes}')

count = []
count.append(0)

#print(adapters)

gn = 0
groups = {gn:[]}

for i in range(0, len(adapters)):
  if (adapters[i-1]+3 == adapters[i]):
    gn += 1
    groups[gn] = []
  groups[gn].append(adapters[i])

#print(groups)

def get_next(n, adpts):
  length = len(adpts)-1
  #print(adpts)
  for i in range(n+1,n+4):
    if i == length:
      count[0] += 1
      return
    elif i < length and adpts[i] <= adpts[n]+3:
      #print(str(n) + ' ' + str(i))
      get_next(i, adpts)
    else:
      break
  return

c = 1
count[0] = 0

for key in groups:
  if len(groups[key]) == 1:
    continue
  get_next(0, groups[key])
  #count[0] += 1
  #print(count[0])
  c *= count[0]
  #print(c)
  count[0] = 0

print(f'part 2: {c}')
