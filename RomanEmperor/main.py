mensaje_cifrado = "YXOXK TFNLXW EHULMXK YENLA"

for desplazamiento in range(1, 26):
    mensaje_descifrado = ""

    for caracter in mensaje_cifrado:
        if caracter == " ":
            mensaje_descifrado += " "
        else:
            ascii_code = ord(caracter)
            new_code = ascii_code - desplazamiento
            if new_code < 65:
                new_code += 26
            mensaje_descifrado += chr(new_code)
    
    print("Desplazamiento {}: {}".format(desplazamiento, mensaje_descifrado))
