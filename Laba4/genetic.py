import random
from typing import List
from unittest import TestCase, main




class Item:
    def __init__(self, name, weight, value):
        self.name = name
        self.weight = weight
        self.value = value


class Individual:
    def __init__(self, bits: List[int]):
        self.bits = bits
    
    def __str__(self):
        return repr(self.bits)

    def __hash__(self):
        return hash(str(self.bits))
    
    def fitness(self) -> float:
        total_value = sum([
            bit * item.value
            for item, bit in zip(items, self.bits)
        ])

        total_weight = sum([
            bit * item.weight
            for item, bit in zip(items, self.bits)
        ])
        
        if total_weight <= MAX_KNAPSACK_WEIGHT:
            return total_value
        
        return 0


MAX_KNAPSACK_WEIGHT = 250
CROSSOVER_RATE = 0.30
MUTATION_RATE = 0.05
REPRODUCTION_RATE = 0.70

items = []

for i in range(100):
    it = Item("Item" + str(i),random.randint(1, 25), random.randint(2, 30))
    print(it.name + " " + str(it.weight) + " " + str(it.value))
    items.append(it)


def generate_initial_population(count=100) -> List[Individual]:
    population = set()
    while len(population) != count: 
        bits = [
            random.choice([0, 0, 0, 0, 0, 1])
            for _ in items
        ]
        population.add(Individual(bits))

    return list(population)


def selection(population: List[Individual]) -> List[Individual]:
    parents = []
    random.shuffle(population)
    if population[0].fitness() > population[1].fitness():
        parents.append(population[0])
    else:
        parents.append(population[1])
    if population[2].fitness() > population[3].fitness():
        parents.append(population[2])
    else:
        parents.append(population[3])

    return parents


def crossover(parents: List[Individual]) -> List[Individual]:
    N = len(items)

    child1 = parents[0].bits[:N//2] + parents[1].bits[N//2:]
    child2 = parents[0].bits[N//2:] + parents[1].bits[:N//2]

    return [Individual(child1), Individual(child2)]


def mutate(individuals: List[Individual]) -> List[Individual]:
    for individual in individuals:
        for i in range(len(individual.bits)):
            if random.random() < MUTATION_RATE:
                individual.bits[i] = ~individual.bits[i]


def next_generation(population: List[Individual]) -> List[Individual]:
    next_gen = []
    while len(next_gen) < len(population):
        children = []
        parents = selection(population)
        if random.random() < REPRODUCTION_RATE:
            children = parents
        else:
            if random.random() < CROSSOVER_RATE:
                children = crossover(parents)
            if random.random() < MUTATION_RATE:
                mutate(children)

        next_gen.extend(children)

    return next_gen[:len(population)]


def print_generation(population: List[Individual]):
    for individual in population:
        print(individual.bits, individual.fitness())
    print()
    print("Average fitness", sum([x.fitness() for x in population])/len(population))
    print("-" * 32)


def average_fitness(population: List[Individual]) -> float:
    return sum([i.fitness() for i in population]) / len(population)


def solve_knapsack() -> Individual:
    population = generate_initial_population()

    avg_fitnesses = []

    for _ in range(500):
        avg_fitnesses.append(average_fitness(population))
        population = next_generation(population)

    population = sorted(population, key=lambda i: i.fitness(), reverse=True)
    return population[0]

def get_total_weigth(bits):
    weigth = 0
    for i in range(100):
        if bits[i] == 1:
            it = items[i]
            weigth += it.weight
    return weigth
    

def print_solution(solution):
    print("Pack: ")
    for i in range(100):
        if(solution.bits[i] == 1):
            it = items[i]
            print(it.name + " " + str(it.weight) + " " + str(it.value))
    print("Total price:" + str(solution.fitness()))
    print("Total weigth:" + str(get_total_weigth(solution.bits)))


def solve_problem():
    for _ in range(10):
            solution = solve_knapsack()
            if get_total_weigth(solution.bits) < 250 and get_total_weigth(solution.bits) > 240:
                print_solution(solution)
                return

if __name__ == '__main__':
    solve_problem()


#tests   

class HeneticTests(TestCase):
    def test_generate_100_people_in_population(self):
        count = 100
        length = len(generate_initial_population(count))
        self.assertEqual(length, count)

    def test_selection_return_2_persons(self):
        population = generate_initial_population(100)
        self.assertEqual(len(selection(population)), 2)

    def test_next_generation_return_100_persons(self):
        population = generate_initial_population(100)
        self.assertEqual(len(next_generation(population)), 100)

if __name__ == '__main__':
    main()