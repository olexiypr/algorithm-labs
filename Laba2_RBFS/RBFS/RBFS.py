from RBFS.answer import Answer
from queue import PriorityQueue
import copy


class RBFS:

    def __init__(self, initial_chessboard):
        self.initial_chessboard = initial_chessboard
        self.answer = None
        self.__checked_states = []
        self.iterations = 0
        self.states_number = 0
        self.dead_ends = 0
        self.__queue = PriorityQueue()

    def recursive_best_first_search(self):
        self.answer = self.__rbfs(self.initial_chessboard, float("inf"))

    def __rbfs(self, current_state, f_limit):
        self.iterations += 1
        if RBFS.__chessboard_validation(current_state):
            return Answer(True, result_chessboard=current_state)
        successors = self.__get_successors(current_state)
        if len(successors) == 0:
            self.dead_ends += 1
            return Answer(False, f_limit=float("inf"))
        for successor in successors:
            self.__queue.put((RBFS.__heuristic_func(successor), successor))
        best = self.__queue.get()
        if best[0] > f_limit:
            return Answer(False, f_limit=best[0])
        alternative = self.__queue.get()
        self.__queue.empty()
        result = self.__rbfs(best[1], min(best, alternative)[0])
        if result is not None and result.is_success:
            return result
        else:
            self.dead_ends += 1
            return self.__rbfs(self.__queue.get()[1], float('inf'))

    def __get_successors(self, chessboard):
        result = []
        for i in range(8):
            for j in range(8):
                temp = copy.deepcopy(chessboard)
                temp[i][0] = j
                if not chessboard[i][0] == j and temp not in self.__checked_states:
                    result.append(copy.deepcopy(temp))
                    self.__checked_states.append(temp)
        self.states_number += len(result)
        return result

    def __heuristic_func(chessboard):
        result = 0
        for i in range(8):
            for j in range(i + 1, 8):
                if chessboard[i][0] == chessboard[j][0] or chessboard[i][1] == chessboard[j][1] \
                        or abs(chessboard[i][0] - chessboard[j][0]) == abs(chessboard[i][1] - chessboard[j][1]):
                    result += 1
        return result

    def __chessboard_validation(chessboard):
        for i in range(8):
            for j in range(i + 1, 8):
                if chessboard[i][0] == chessboard[j][0] or chessboard[i][1] == chessboard[j][1] \
                        or abs(chessboard[i][0] - chessboard[j][0]) == abs(chessboard[i][1] - chessboard[j][1]):
                    return False
        return True
