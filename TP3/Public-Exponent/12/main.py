N = 110581795715958566206600392161360212579669637391437097703685154237017351570464767725324182051199901920318211290404777259728923614917211291562555864753005179326101890427669819834642007924406862482343614488768256951616086287044725034412802176312273081322195866046098595306261781788276570920467840172004530873767                                                                  
e = 1
CIPHER_TEXT = 44981230718212183604274785925793145442655465025264554046028251311164494127485

# Como el exponente es 1, el cifrado simplemente se reduce a:
# PLAIN_TEXT ^(1) mod N = PLAIN_TEXT mod N

# Para descifrar este mensaje, simplemente tenemos que:
# PLAIN_TEXT = CIPHER_TEXT % N

plain_text_int = pow(CIPHER_TEXT, e, N)

# Obtenemos la cantidad de bytes que representa este entero.
long_bytes = (plain_text_int.bit_length() + 7) // 8

# Convertimos el entero en bytes
plain_text_bytes = plain_text_int.to_bytes(long_bytes, 'big')

# Convertimos de bytes a texto plano
plain_text = plain_text_bytes.decode('utf-8', 'ignore')

print(plain_text)