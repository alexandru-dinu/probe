.model small

.stack 100h

.data 
    nr dw 49+
    fib db (nr+2) dup (1) 
                    
.code
main:
    
    mov ax, @data
    mov ds, ax
                   
    lea di, fib
    mov si, di
    inc si        
    
    mov cx, nr          
    
    iter:        
        mov al, [di]
        mov bl, [si]
        
        add al, bl
        
        mov [si+1], al
        
        inc di  
        inc si
    loop iter 
    
     
             
    mov cx, nr
    
    rewind:
        dec di
    loop rewind
    
                                                     
    
    mov cx, nr
    inc cx
    inc cx
    
    print:
        mov dl, [di]
        add dl, '0'
        
        mov ah, 02h
        int 21h
        inc di
    loop print
    
    
       
    mov ah, 4ch
    int 21h
    
end main