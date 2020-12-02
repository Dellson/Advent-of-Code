def get_data():
    file = open('input_files/day_01.txt', 'r') 
    return file.readlines()

def part_1(mass):
    return (int(mass) // 3) - 2

def part_2(mass):
    fuel_mass = part_1(mass)
    return fuel_mass + part_2(fuel_mass) if fuel_mass > 0 else 0

data = get_data()
fuel = lambda func : sum([func(int(line)) for line in data])
print(fuel(part_1))
print(fuel(part_2))