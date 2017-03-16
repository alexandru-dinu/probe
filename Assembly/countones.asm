.model small

.stack 100h

.data
    nr db 0001b
    n db 04h
.code

macro count p
    test p, 1000b
endm count 

macro printb p
    mov cx, 8
    print:
        mov ah, 02h
        mov dl, '0'
        test p, 10000000b
        jz ifzero
        mov dl, '1'
    ifzero:
        int 21h
        shl p, 1
    loop print
endm printb  

main proc
    
    mov ax, @data
    mov ds, ax
    
    mov dl, nr
    mov bl, 0
    mov cx, 8    
    
    iter:
        count dl
        jz zero
        inc bl
    zero:
        shl dl, 1
    loop iter
        
      
    printb bl        
    
    mov ah, 4ch
    int 21h
    
endp
end main