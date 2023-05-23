def mmi(e, M):
    return pow(e, -1, M)


N = 171731371218065444125482536302245915415603318380280392385291836472299752747934607246477508507827284075763910264995326010251268493630501989810855418416643352631102434317900028697993224868629935657273062472544675693365930943308086634291936846505861203914449338007760990051788980485462592823446469606824421932591                                                                  
e = 65537
CIPHER_TEXT = 161367550346730604451454756189028938964941280347662098798775466019463375610700074840105776873791605070092554650190486030367121011578171525759600774739890458414593857709994072516290998135846956596662071379067305011746842247628316996977338024343628757374524136260758515864509435302781735938531030576289086798942

# La clave del ejercicio esta aca.
phi = N-1
# Sabiendo que la N es de por si un numero primo, su phi sera N-1.
# Ya que el phi de un numero primo es siempre N-1

# Obtenemos la clave privada
private_key = mmi(e, phi)

# Desciframos el texto cifrado
plain_text_int = pow(CIPHER_TEXT, private_key, N)

# Obtenemos la cantidad de bytes que requiere nuestro texto claro.
long_bytes = (plain_text_int.bit_length() + 7) // 8

# Convertimos el numero obtenido en bytes
plain_text_bytes = plain_text_int.to_bytes(long_bytes, 'big')

# Convertimos los bytes en texto claro.
plain_text = plain_text_bytes.decode('utf-8', 'ignore')

print(plain_text)

