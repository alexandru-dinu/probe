.model small

.stack 100h

.data 
    nr dw 0Bh 
    nl db 10,13,'$'
    
.code
start:
    
    mov ax, @data
    mov ds, ax
    
    mov bx, nr 
    
    mov cx, 8
    
    print:
        mov ah, 02h
        mov dl, '0'
       
        test bx, 10000000b
        jz zero  
        mov dl, '1'
        
    zero:
        int 21h
        shl bx, 1 
    
    loop print 
    
    mov ah, 4ch
    int 21h 
end start

