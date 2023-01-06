import csv
import math
import random
import sys
from scipy.spatial import distance
import unittest

class Bee:
    def __init__(self, node_set):
        self.role = ''
        self.path = list(node_set)
        self.distance = 0
        self.cycle = 0

def get_distance_between_nodes(n1, n2):
    return distance.euclidean(n1, n2)

def make_distance_table(data_list):
    length = len(data_list)
    table = [[get_distance_between_nodes(
        (data_list[i][1],data_list[i][2]), (data_list[j][1],data_list[j][2]))
        for i in range(0, length)] for j in range(0, length)]
    return table

def get_total_distance_of_path(path, table):
    new_path = list(path)
    new_path.insert(len(path), path[0])
    new_path = new_path[1:len(new_path)]
    coordinates = zip(path, new_path)
    distance = sum([table[i[0]][i[1]] for i in coordinates])
    return round(distance, 3)

def initialize_hive(population, data):
    path = [x[0] for x in data]
    hive = [Bee(path) for i in range (0, population)]
    return hive

def assign_roles(hive, role_percentiles, table):
    population = len(hive)
    onlooker_count = math.floor(population * role_percentiles[0])
    forager_count = math.floor(population * role_percentiles[1])
    for i in range(0, onlooker_count):
        hive[i].role = 'O'
    for i in range(onlooker_count, (onlooker_count + forager_count)):
        hive[i].role = 'F'
        random.shuffle(hive[i].path)
        hive[i].distance = get_total_distance_of_path(hive[i].path, table)
    return hive

def mutate_path(path):
    random_idx = random.randint(0, len(path) - 2)
    new_path = list(path)
    new_path[random_idx], new_path[random_idx + 1] = new_path[random_idx + 1], new_path[random_idx]
    return new_path

def forage(bee, table, limit):
    new_path = mutate_path(bee.path)
    new_distance = get_total_distance_of_path(new_path, table)
    if new_distance < bee.distance:
        bee.path = new_path
        bee.distance = new_distance
        bee.cycle = 0
    else:
        bee.cycle += 1
    if bee.cycle >= limit:
        bee.role = 'S'
    return bee.distance

def scout(bee, table):
    new_path = list(bee.path)
    random.shuffle(new_path)
    bee.path = new_path
    bee.distance = get_total_distance_of_path(new_path, table)
    bee.role = 'F'
    bee.cycle = 0

def waggle(hive, best_distance, table, forager_limit, scout_count):
    best_path = []
    results = []
    for i in range(0, len(hive)):
        if hive[i].role == 'F':
            distance = forage(hive[i], table, forager_limit)
            if distance < best_distance:
                best_distance = distance
                best_path = list(hive[i].path)
            results.append((i, distance))
        elif hive[i].role == 'S':
            scout(hive[i], table)
    results.sort(reverse = True, key=lambda tup: tup[1])
    scouts = [ tup[0] for tup in results[0:int(scout_count)] ]
    for new_scout in scouts:
        hive[new_scout].role = 'S'
    return best_distance, best_path

def recruit(hive, best_distance, best_path, table):
    for i in range(0, len(hive)):
        if hive[i].role == 'O':
            new_path = mutate_path(best_path)
            new_distance = get_total_distance_of_path(new_path, table)
            if new_distance < best_distance:
                best_distance = new_distance
                best_path = new_path
    return best_distance, best_path

def print_details(cycle, distance):
    print("CYCLE: {}".format(cycle))
    print("DISTANCE: {}".format(distance))
    print("\n")

def generate_towns(min_len, max_len, count):
    return [[random.randint(min_len, max_len) for j in range(3)] for i in range(count)]

def start():
    best_path = []
    result = ()   
    cycle = 1
    best_distance = sys.maxsize
    while cycle < cycle_limit:
        waggle_distance, waggle_path = waggle(hive, best_distance, table, forager_limit, scout_count)
        if waggle_distance < best_distance:
            best_distance = waggle_distance
            best_path = list(waggle_path)
            print_details(cycle, best_distance)
            result = (cycle, best_distance)
        recruit_distance, recruit_path = recruit(hive, best_distance, best_path, table)
        if recruit_distance < best_distance:
            best_distance = recruit_distance
            best_path = list(recruit_path)
            print_details(cycle, best_distance)
            result = (cycle, best_distance)
        if cycle % 1000 == 0:
            print("CYCLE #: {}\n".format(cycle))
        cycle += 1
    print("Result: ")
    print("Best distance: ", result[1])
    print("Cycle: ", result[0])
        
def print_config():
    print("Configuration: ")
    print("The traveling salesman problem type: mixed")
    print("Population count: ", population)
    print("Count towns: ", count_towns)
    print("Min length between towns: ", min_len)
    print("Max length between towns: ", max_len)
    print("Forager count: ", population * forager_percent)
    print("Scout count: ", population * scout_percent)

def enter_new_config():
    print_config()
    pop_count = population
    forager_p = forager_percent
    scout_p = scout_percent
    is_new_config = False
    submit = input("To change config enter 'Y': ")
    if submit == 'Y':
        print("To use default config enter '2'")
        while True:
            try:
                pop_count = int(input("Enter population count (min 100): "))
                if pop_count < 100:
                    print("Invalid input!")
                    continue
                if pop_count == 2:
                    break
                forager_p = float(input("Enter forager percent in format 0.9 (90%): "))
                scout_p = float(input("Enter scout percent in format 0.1 (10%): "))
            except ValueError:
                print("Invalid input!")
                continue
            else:
                if forager_p == 2 or scout_p == 2:
                    break
                if  forager_p + scout_p != 1:
                    print("Forager percent + scout percent must = 1")
                    continue
                is_new_config = True
                break
    return [pop_count, forager_p, scout_p, is_new_config]

count_towns = 300
min_len = 5
max_len = 150
population = 1000
forager_percent = 0.9
scout_percent = 0.1
config = enter_new_config()
if config[3] == True:
    population = config[0]
    forager_percent = config[1]
    scout_percent = config[2]
    print("-----New config: -----")
    print_config()
    input("Enter something co continue...")
role_percent = [scout_percent, forager_percent]
scout_count = math.ceil(population * scout_percent)
forager_limit = math.ceil(population * forager_percent)
cycle_limit = 2000
data = generate_towns(min_len, max_len, count_towns)
table = make_distance_table(data)
hive = initialize_hive(population, data)
assign_roles(hive, role_percent, table)
start()
