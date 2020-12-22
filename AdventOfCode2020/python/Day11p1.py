import aoc
from copy import deepcopy


input = ['.' + i[:-1] + '.' for i in aoc.input(11)]
input.insert(0, '.' * len(input[0]))
input.append('.' * len(input[0]))

  
def update_seating(temp, lst, row, col):
  if lst[row][col] == '.':
    return temp
    
  occupied = 0
  for r in range(row-1,row+2):
    for c in range(col-1,col+2):
      if r == row and c == col:
        continue
      elif lst[r][c] == '#':
        occupied += 1
  if occupied >= 4 and lst[row][col] == '#':
    r = list(temp[row])
    r[col] = 'L'
    temp[row] = ''.join(r)
  elif occupied == 0 and lst[row][col] == 'L':
    r = list(temp[row])
    r[col] = '#'
    temp[row] = ''.join(r)

def run_round(lst):
  temp = deepcopy(lst)
  
  for row in range(1,len(lst)-1):
    for col in range(1,len(lst[row])-1):
      update_seating(temp,lst,row,col)
  return temp

def count_occupied(lst):
  return sum([r.count('#') for r in lst])

prev_count = 0
while True:
  input = run_round(input)
  count = count_occupied(input)
  if prev_count == count:
    break
  else:
    prev_count = count

print(f'part 1: {count}')
