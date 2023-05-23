e = 65537 # Exponente de la exponenciacion modular

p = 17 # Primer numero primo
q = 23 # Segundo numero primo

N = p*q # Modulo de la exponenciacion modular (producto de dos numeros primos)

plain_text = 12 # Numero a encriptar

res = pow(plain_text, e, N)

print(res)