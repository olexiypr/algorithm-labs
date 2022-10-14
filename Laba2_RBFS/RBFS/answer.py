class Answer:
    def __init__(self, is_success, f_limit=None, result_chessboard=None):
        self.is_success = is_success
        self.f_limit = f_limit
        self.result_chessboard = result_chessboard

    def __str__(self):
        return ('is success: ' + str(self.is_success) + '\n'
                + 'result chessboard: ' + str(self.result_chessboard))
