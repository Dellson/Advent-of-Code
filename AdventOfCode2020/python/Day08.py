import aoc
import re
import copy


def RunInstructions(instructions):
  lines_visited = {inst:0 for inst in range(len(instructions))}
  i = 0
  acc = 0
  
  while i < len(instructions):
    lines_visited[i] += 1
    
    # exit looping code
    if 2 in lines_visited.values():
      return (-1, acc)
      
    it = instructions[i].split(' ')
    i += 1
    if it[0] == 'acc':
      acc += int(it[1])
    elif it[0] == 'jmp':
      i += int(it[1]) - 1
      
  return (0, acc)

def Day08():
  instructions = []
  
  for instruction in aoc.input(8):
    instructions.append(instruction[:-1])
    
  # part 1
  print(f'part 1: {RunInstructions(instructions)}')
  
  # part 2
  for i in range(len(instructions)):
    temp = copy.deepcopy(instructions)
    
    it = temp[i].split(' ')
    if it[0] == 'nop':
      it[0] = 'jmp'
    elif it[0] == 'jmp':
      it[0] = 'nop'
    else:
      continue
    temp[i] = f'{it[0]} {it[1]}'
    
    output = RunInstructions(temp)
    
    if output[0] == 0:
      print(f'part 2: {output}')
      break

Day08()
