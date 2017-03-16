.model small

.stack 100h

.data 
    nr db 10
    str dw nr dup ('0') 

.code
main:
    
    mov ax, @data
    mov ds, ax
                   
    lea di, str          
    
    mov cx, 0          
    mov cl, nr
    
    iter:
        mov ah, 01h
        int 21h
        
        mov [di], al
        inc di
    loop iter 
             
    mov cl, nr
    
    rewind:
        dec di
    loop rewind 
    
    mov cl, nr  
    
    printf:
        mov dl, [di]
        mov ah, 02h
        int 21h
        inc di
    loop printf
    
       
    mov ah, 4ch
    int 21h
    
end main