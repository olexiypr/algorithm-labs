from RBFS.RBFS import RBFS
import random
import time

def generate_chessboards(number):
    result = []
    for _ in range(number):
        board = []
        for j in range(8):
            is_added = False
            while not is_added:
                queen = [random.randint(0, 7), j]
                if queen not in board:
                    board.append(queen)
                    is_added = True
        result.append(board)
    return result

def print_chessboard (chessboard):
    l = ""
    for i in range(8):
        for j in range(8):
            queen = [i,j]
            if queen in chessboard:
                  l += '_ '
            else:
                l += ". "
        l += "\n"
    return l

chessboards = [
    [[4, 0], [0, 1], [7, 2], [5, 3], [2, 4], [6, 5], [1, 6], [3, 7]],
    [[0, 0], [0, 1], [0, 2], [0, 3], [0, 4], [0, 5], [0, 6], [0, 7]],
    [[1, 0], [0, 1], [7, 2], [5, 3], [2, 4], [6, 5], [1, 6], [3, 7]],
    [[3, 0], [0, 1], [7, 2], [5, 3], [2, 4], [6, 5], [1, 6], [3, 7]],
    [[4, 0], [0, 1], [7, 2], [5, 3], [2, 4], [5, 5], [1, 6], [3, 7]],
    [[4, 0], [0, 1], [7, 2], [5, 3], [2, 4], [6, 5], [1, 6], [9, 7]],
    [[4, 0], [0, 1], [7, 2], [3, 3], [2, 4], [6, 5], [1, 6], [3, 7]],
    [[4, 0], [0, 1], [7, 2], [5, 3], [2, 4], [6, 5], [2, 6], [3, 7]],
    [[4, 0], [0, 1], [7, 2], [5, 3], [2, 4], [6, 5], [1, 6], [0, 7]],
    [[4, 0], [0, 1], [0, 2], [5, 3], [2, 4], [6, 5], [1, 6], [3, 7]],
    [[4, 0], [0, 1], [7, 2], [5, 3], [2, 4], [6, 5], [1, 6], [6, 7]],
    [[4, 0], [0, 1], [7, 2], [5, 3], [0, 4], [6, 5], [1, 6], [3, 7]],
    [[4, 0], [0, 1], [5, 2], [5, 3], [2, 4], [6, 5], [1, 6], [3, 7]],
    [[4, 0], [0, 1], [7, 2], [5, 3], [2, 4], [6, 5], [6, 6], [3, 7]],
    [[4, 0], [0, 1], [7, 2], [8, 3], [2, 4], [6, 5], [1, 6], [3, 7]],
    [[4, 0], [0, 1], [7, 2], [5, 3], [2, 4], [6, 5], [1, 6], [5, 7]],
    [[4, 0], [6, 1], [7, 2], [5, 3], [2, 4], [6, 5], [1, 6], [3, 7]],
    [[4, 0], [0, 1], [7, 2], [5, 3], [2, 4], [9, 5], [1, 6], [3, 7]],
    [[4, 0], [0, 1], [7, 2], [5, 3], [2, 4], [6, 5], [1, 6], [9, 7]],
    [[4, 0], [0, 1], [3, 2], [5, 3], [2, 4], [6, 5], [1, 6], [3, 7]]
]

print('------RBFS------')
for chessboard in generate_chessboards(20):
    rbfs = RBFS(chessboard)
    print('Input chessboard: \n' + print_chessboard(chessboard))
    rbfs.recursive_best_first_search()
    print('Result chessboard: \n' + print_chessboard(rbfs.answer.result_chessboard))
    print('iterations = ' + str(rbfs.iterations))
    print('states number = ' + str(rbfs.states_number))
    print('dead ends = ' + str(rbfs.dead_ends))
    print()
