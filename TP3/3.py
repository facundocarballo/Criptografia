from decimal import Decimal

p = 857504083339712752489993810777 # Primer numero primo
q = 1029224947942998075080348647219 # Segundo numero primo

N = p*q # Modulo para encriptar.

# Como ya conozco los numeros primos que forma a N, puedo utilizarlo directamente en la formula del Euler Totient.
phi_n = N * (1 - (1/p)) * (1 - (1/q))
print("Resultado que obtuve inicialmente: ", Decimal(phi_n))

res_verdadero = 882564595536224140639625987657529300394956519977044270821168
res_obtenido  = 882564595536224182414387885994216905435011395268168590032896

"""
Para obtener el res_verdadero, mis companeros hicieron lo siguiente:
- phi(p) = p - 1. -> Por definicion.
Si un numero es primo (p), habra p-1 numeros enteros posibles coprimos con este numero p.
Partiendo de ahi, plantearon lo siguiente:
- phi(N) = phi(p) * phi(q)
- phi(p) = p-1
- phi(q) = q-1
- phi(N) = (p-1) * (q-1)
"""

res = (p-1)*(q-1)

print("Resultado verdadero: ", Decimal(res)) 