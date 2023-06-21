# Rotations Left
def ROTL8(v,n):
    return (((v<<n)&0xff) | ((v>>(8-n))&0xff))

def ROTL16(v,n):
    return (((v<<n)&0xffff) | ((v>>(16-n))&0xffff))

def ROTL32(v,n):
    return (((v<<n)&0xffffffff) | ((v>>(32-n))&0xffffffff))

def ROTL64(v,n):
    return (((v<<n)&0xffffffffffffffff) | ((v>>(64-n))&0xffffffffffffffff))

# Rotations Right
def ROTR8(v,n):
    return ROTL(V,8-n)

def ROTR16(v,n):
    return ROTL(V,16-n)

def ROTR32(v,n):
    return ROTL(V,32-n)

def ROTR64(v,n):
    return ROTL(V,64-n)

# Swaps
def SWAP32(v):
    return ((ROTL32(v,8)&0x00ff00ff) | (ROTL32(v,24)&0xff00ff00))

class Rabbit_state(object):
    def __init__(self):
        self.x=[0]*8
        self.c=[0]*8
        self.carry=0

class Rabbit_ctx(object):
    def __init__(self):
        self.m=Rabbit_state()
        self.w=Rabbit_state()

class Rabbit:
    def __init__(self):
        self.context = Rabbit_ctx()
        self.HEX_CONST = [0x4D34D34D, 0xD34D34D3, 0x34D34D34]


    # Aux funcs
    def next_state(self):
        state = self.context.w
        self._calculate_new_counter_values(state)
        g_values = self._calculate_g_values(state)
        self._left_rotations(state, g_values)

    def encrypt(self, data: bytes, key: str, iv: str):
        plaintext = ""
        length_bytes = len(data)
        list_x = [0]*4
        start = 0
        while (True):
            self.next_state()
            
            for i in range(4):
                list_x[i]=self.context.w.x[i<<1]
            
            list_x[0]^=(self.context.w.x[5]>>16)^(self.context.w.x[3]<<16)
            list_x[1]^=(self.context.w.x[7]>>16)^(self.context.w.x[5]<<16)
            list_x[2]^=(self.context.w.x[1]>>16)^(self.context.w.x[7]<<16)
            list_x[3]^=(self.context.w.x[3]>>16)^(self.context.w.x[1]<<16)
            b=[0]*16
            
            for i,j in enumerate(x):
                for z in range(4):
                    b[z+4*i]=0xff&(j>>(8*z))
            
            for i in range(16):
                plain+=chr(ord(data[start])^b[i])
                start+=1
                if(start == length_bytes):
                  return plain

    def decrypt():
        d = 0

    # Private funcs
    def _calculate_new_counter_values(self, state):
        for i in range(8):
            tmp=self.context.w.c[i]
            state.c[i]=(state.c[i]+self.HEX_CONST[i%3]+state.carry)&0xffffffff
            state.carry=(state.c[i]<tmp)

    def _calculate_g_values(self, state):
        g_values = [0]*8
        for i in range(8):
            g_values[i]=self._g_func(state.x[i]+state.c[i])
        return g_values
    
    def _g_func(self,x):
        # TODO: No entiendo que hace esto...
        x=x&0xffffffff
        x=(x*x)&0xffffffffffffffff
        result=(x>>32)^(x&0xffffffff)
        return result
    
    def _left_rotations(self, state, g_values):
        j=7
        i=0
        while(i <8):
            # TODO: No entiendo que hace esto...
            state.x[i]=(g_values[i] + ROTL32(g_values[j], 16) + ROTL32(g_values[j-1], 16))&0xffffffff
            i+=1
            j+=1
            state.x[i]=(g_values[i] + ROTL32(g_values[j & 7], 8) + g_values[j-1])&0xffffffff
            i+=1
            j+=1
            j&=7