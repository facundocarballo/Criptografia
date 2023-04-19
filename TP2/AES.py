def bytes2matrix(text):
    """ Converts a 16-byte array into a 4x4 matrix.  """
    return [list(text[i:i+4]) for i in range(0, len(text), 4)]

def matrix2bytes(matrix):
    cadena = ""
    for row in matrix:
        for elem in row:
            cadena += chr(elem)
    return cadena

matrix = [
    [99, 114, 121, 112],
    [116, 111, 123, 105],
    [110, 109, 97, 116],
    [114, 105, 120, 125],
]

state = [
    [206, 243, 61, 34],
    [171, 11, 93, 31],
    [16, 200, 91, 108],
    [150, 3, 194, 51],
]

round_key = [
    [173, 129, 68, 82],
    [223, 100, 38, 109],
    [32, 189, 53, 8],
    [253, 48, 187, 78],
]

def print_matrix(matrix):
    for row in matrix:
        for elem in row:
            print(elem)

def add_round_key(s, k):
    i = 0
    j = 0
    for row_s, row_k in zip(s, k):
        for elem_s, elem_k  in zip(row_s, row_k):
           s[i][j] = elem_s ^ elem_k
           j += 1
        j = 0
        i += 1

    
# 3- Structure of AES
print(matrix2bytes(matrix))

# 4- Round Keys
add_round_key(state, round_key)
print(matrix2bytes(state))