import aoc


instructions = [int(instruction[:-1]) for instruction in aoc.input(9)]
invalid_num = 0
pre_start = 0
pre_end = 25

def preamble_sum_exists(number):
  for i in range(pre_start,pre_end):
    for j in range(pre_start,pre_end):
      if i != j and instructions[i] + instructions[j] == number:
        return (0, number)
  return (-1, number)
  
for i in range(pre_end, len(instructions)):
  x = preamble_sum_exists(instructions[i])
  if x[0] == -1:
    invalid_num = x[1]
    break
  pre_start += 1
  pre_end += 1

def get_weakness(invalid):
  max_index = instructions.index(invalid)
  for i in range(0, max_index):
    temp = instructions[i]
    for j in range(i+1, max_index):
      temp += instructions[j]
      
      if temp == invalid:
        selected = instructions[i:j]
        return min(selected)+max(selected)
      if temp > invalid:
        break
      
weakness = get_weakness(invalid_num)
print(f'Error. No match for {invalid_num}.')
print(f'Encryption weakness: {weakness}.')
