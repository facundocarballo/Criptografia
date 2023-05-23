
from sympy import factorint

def mmi(e, M):
    return pow(e, -1, M)

N = 742449129124467073921545687640895127535705902454369756401331
e = 3
CIPHER_TEXT = 39207274348578481322317340648475596807303160111338236677373

# Estos numeros son los primos que al multiplicar obtienen N
p = 752708788837165590355094155871
q = 986369682585281993933185289261
# Los encontre gracias a la pagina web -> http://factordb.com/
# Que tiene como una especie de base de datos de numeros grandes factorizados.

# Esto habria que hacer para factorizar el numero grande de 1600 bits (N)
# Pero no lo hice pq tardaba mucho.
# factores = factorint(N)
# phi = 1
# for factor, potencia in factores.items():
#     phi *= (factor-1)


phi = (p-1)*(q-1)
private_key = mmi(e, phi)

# Aplicamos la formula para descifrar un texto cifrado con RSA
plain_text_int = pow(CIPHER_TEXT, private_key, N)
long_bytes = (plain_text_int.bit_length() + 7) // 8
plain_text_bytes = plain_text_int.to_bytes(long_bytes, 'big')
plain_text = plain_text_bytes.decode('utf-8', 'ignore')

print(plain_text)
