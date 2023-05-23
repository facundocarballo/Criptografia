def mmi(e, M):
    return pow(e, -1, M)

p = 857504083339712752489993810777 # Numero primo 1
q = 1029224947942998075080348647219 # Numero primo 2
N = p*q # Modulo N de la exponenciacion modular (forma parte de la clave publica)
e = 65537 # Exponente

# Tengo que encontrar la clave privada asociada.
# pk = mmi(e, M)
# mmi -> modular multiplication inverse
# e -> exponente
# M -> Modulo utilizado

M = (p-1)*(q-1) # Totient de N
print(mmi(e, M))

