.model small

.stack 100h

.data
    sir db 'ab'
    len equ $ - sir

.code 

print proc near
    push bp
    mov bp, sp
    
    cld
    
    push ds
    pop es
    
    mov cx, word ptr [bp + 4]
    mov si, word ptr [bp + 6]
    
    iter:
        mov ah, 02h
        mov dl, [si]       
        int 21h
        inc si
    loop iter
    
    pop bp
    ret 4
print endp

main:
    
    mov ax, @data
    mov ds, ax
    
    sub sp, 2
    
    push offset sir
    push len
    
    call print   
    
    mov ah, 4ch
    int 21h
    
end main