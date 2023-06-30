import tkinter
from tkinter import filedialog
import rabbit
from PIL import Image
from pwn import xor

Window = tkinter.Tk()
Window.geometry("720x200")

# Global Variables
PLAIN_IMG_PATH = None
CIPHER_IMG_PATH = None
SIZE = 16

# Handlers
def cipher_btn():
    global CIPHER_IMG_PATH
    CIPHER_IMG_PATH = filedialog.asksaveasfilename(defaultextension=".bmp")
    encrypt_img()
    CipherImgLabel.configure(text="Cipher complete!")

def search_img():
    global PLAIN_IMG_PATH
    PLAIN_IMG_PATH = filedialog.askopenfilename()
    PlainImgLabel.configure(text="Image selected: " + PLAIN_IMG_PATH)

def encrypt_img():
    original_image = Image.open(PLAIN_IMG_PATH)
    original_image_array = bytearray(original_image.tobytes())
    original_image_matrix = list(rabbit.split(original_image_array,SIZE))

    image_format = original_image.format.lower()

    if(image_format == 'png'):
        for i in range(SIZE//2):
            aux = original_image_matrix[i]
            original_image_matrix[i] = original_image_matrix[SIZE-1-i]
            original_image_matrix[SIZE-1-i] = aux

    Rabbit = rabbit.Rabbit(KeyEntry.get(), IVEntry.get())
    s = Rabbit.keystream(len(original_image_array)).encode('ISO-8859-1')

    result_image = b''.join(original_image_matrix)

    encripted_bytes = xor(result_image, s)

    result = Image.frombytes(original_image.mode, original_image.size, encripted_bytes)
        
    result.save(CIPHER_IMG_PATH)

# UI Components
SearchFileBtn = tkinter.Button(Window, text="Search your image", command=search_img)
PlainImgLabel = tkinter.Label(Window, image=None)
KeyLabel = tkinter.Label(Window, text="Insert the key")
KeyEntry = tkinter.Entry(Window, exportselection=False)
IVInput = tkinter.Label(Window, text="Insert the IV")
IVEntry = tkinter.Entry(Window, exportselection=False)
CipherBtn = tkinter.Button(Window, text="Cipher", command=cipher_btn)
CipherImgLabel = tkinter.Label(Window, text=None)

# Render Components
SearchFileBtn.pack()
PlainImgLabel.pack()
KeyLabel.pack()
KeyEntry.pack()
IVInput.pack()
IVEntry.pack()
CipherBtn.pack()
CipherImgLabel.pack()

# Show Window
Window.mainloop()




