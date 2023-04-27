import requests
import hashlib
from Crypto.Cipher import AES

POSSIBLE_KEYS = []
BASE_URL = "http://aes.cryptohack.org/passwords_as_keys/"

def encrypt_flag():
    cipher = AES.new(KEY, AES.MODE_ECB)
    encrypted = cipher.encrypt(FLAG.encode())

    return {"ciphertext": encrypted.hex()}

def decrypt(ciphertext, password_hash):
    ciphertext = bytes.fromhex(ciphertext)
    key = bytes.fromhex(password_hash)

    cipher = AES.new(key, AES.MODE_ECB)
    try:
        decrypted = cipher.decrypt(ciphertext)
    except ValueError as e:
        return str(e)

    return decrypted.hex()

def get_ciphertext():
    r = requests.get(f"{BASE_URL}/encrypt_flag")
    data = r.json()
    return data["ciphertext"]

def main():
    ciphertext = get_ciphertext()
    
    # Read all the possible keys
    with open("words.txt") as file:
        POSSIBLE_KEYS = file.readlines()

    for key_without_strip in POSSIBLE_KEYS:
        
        # Remove all the white spaces of this possible password.
        key = key_without_strip.strip()

        # Get the Hash of that possible password.
        hash_key = hashlib.md5(key.encode()).digest()
        
        # Convert the hash_key to Hex to pass it on the decrypt function.
        hash_hex = hash_key.hex()

        # Get the possible flag on hex.
        flag_hex = decrypt(ciphertext, hash_hex)
        
        # Convert the possible hex flag that the function decrypt returns to plain text.
        flag = bytearray.fromhex(str(flag_hex)).decode('utf-8', errors='ignore')
        
        if (flag.startswith('crypto')):
            print(flag)
            break

# main()
with open("words.txt") as file:
    POSSIBLE_KEYS = file.readline()
    print(POSSIBLE_KEYS)