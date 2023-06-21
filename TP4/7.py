import jwt

with open('rsa-or-hmac-2-public.pem', 'rb') as f:
   PUBLIC_KEY = f.read()

# Create the token with HS256
encoded = jwt.encode(
    {
        'username': 'facu',
        'admin': True
    },
    PUBLIC_KEY,
    algorithm="HS256"
)

print("JWT: ", encoded)

# Facu:
    # Header: eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9
    # Payload: eyJ1c2VybmFtZSI6ImZhY3UiLCJhZG1pbiI6dHJ1ZX0
    # Signatura: 2Q6chWPWYq2oU7Inuq1kW0AUgyGy9Zev6EIhrgx0Z38

# CryptoHack
    # Header: eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9
    # Payload: eyJ1c2VybmFtZSI6ImZhY3UiLCJhZG1pbiI6ZmFsc2V9
    # Signature: oqXAXwG8Ju9bTM3RhKJP-tZddcuMk8Mo5FqVz270TGx8h4Kj45k152aMvk3FIwh3w-RPe0KgJjMJc5dZYOkk7LknSa0ch6Y8ha9cHOnlEMwlzxZAbNzA3iG705XKR7Jeuu2_V1ZggR1BUxFt2HTbdSNvnoY_i3dxWzs_ZBaNV0Dw-qcgtiiwVteQECqGjNA23_WFqJXcdAVIvW49W0cqVXh5q93gRDRvMETTuxuPFBWrgP0YHVDzDunNtnp0EeFHGPc2rJt2NQRSrcLamI8uq3bKYWg8uvu8Ra1fs82aDlh6XdVsfaDqYHaPHG5vCX21o7sLNyIkxMGq4lZXcpTOxg