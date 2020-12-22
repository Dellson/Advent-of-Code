import aoc


count = 0
temp = []

for line in aoc.input(6):
  if line == '\n':
    count += len(temp)
    temp = []
  
  for letter in line:
    if letter not in temp and letter != '\n':
      temp.append(letter)
      
print(f'part 1: {count}')

count = 0
group = []
answers = {}

for line in aoc.input(6):
  if line == '\n':
    count += sum([1 for key in answers if answers[key] == len(group)])
    group = []
    answers = {}
  else:
    group.append(line)
  
    for answer in line:
      if answer not in answers:
        answers[answer] = 0
      answers[answer] += 1
      
print(f'part 2: {count}')
