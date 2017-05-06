.model small

.stack 100h

.data
    str db 'elevele' 
    len equ ($ - str)
    nl db 10,13,'$'
    
    nq db 'notpalindrome$'
    q db 'palindrome$'
    
.code
start:
    
    mov ax, @data
    mov ds, ax
    
    lea di, str
    mov si, di
    add si, len
    dec si
    
    mov cx, len
    shr cx, 1
    
    compare:
        mov al, [di]
        mov dl, [si]
        
        cmp al, dl
        
        jne notp
        
        inc di
        dec si
    loop compare 
    
    pal:
        lea dx, q
        mov ah, 09h
        int 21h 
        jmp stop 
                 
    notp:
        lea dx, nq
        mov ah, 09h
        int 21h    
        
    stop:
        mov ah, 4ch
        int 21h   

end start