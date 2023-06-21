import jwt

PUBLIC_KEY = "-----BEGIN RSA PUBLIC KEY-----\nMIIBCgKCAQEAvoOtsfF5Gtkr2Swy0xzuUp5J3w8bJY5oF7TgDrkAhg1sFUEaCMlR\nYltE8jobFTyPo5cciBHD7huZVHLtRqdhkmPD4FSlKaaX2DfzqyiZaPhZZT62w7Hi\ngJlwG7M0xTUljQ6WBiIFW9By3amqYxyR2rOq8Y68ewN000VSFXy7FZjQ/CDA3wSl\nQ4KI40YEHBNeCl6QWXWxBb8AvHo4lkJ5zZyNje+uxq8St1WlZ8/5v55eavshcfD1\n0NSHaYIIilh9yic/xK4t20qvyZKe6Gpdw6vTyefw4+Hhp1gROwOrIa0X0alVepg9\nJddv6V/d/qjDRzpJIop9DSB8qcF1X23pkQIDAQAB\n-----END RSA PUBLIC KEY-----\n"

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