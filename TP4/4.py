import jwt

# Create the token
econded = jwt.encode(
    {
        'username': 'facu',
        'admin': True
    },
    'secret', # This is de default key for jwt.
    algorithm='HS256'
)

print("JWT: ", econded)