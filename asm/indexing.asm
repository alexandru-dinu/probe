.model small

.stack 100h

.data
    str db 48,49,50
    len equ ($ - str)
    
.code
main proc
    mov ax, @data
    mov ds, ax
    
    ;code goes here
    lea di, str ; load the beginning of the string
    mov cx, len ; load the size of the string
    
    ; point to the end of the string
    mov si, di
    add si, len
    dec si
      
    
    print:
        mov dl, [si]
        dec si 
        
        mov ah, 02h
        int 21h
    loop print
    
    
    
    mov ah, 4ch
    int 21h
endp
end main