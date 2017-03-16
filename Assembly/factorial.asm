.model small

.stack 100h

.data
    n dw 10

.code
main:
    
    mov ax, @data
    mov ds, ax 
    
    ;code goes here  
    mov cx, n  
    mov ax, 1
    mov bx, 1
    
    iter:     
        mul bx
        inc bx
    loop iter
    
    mov bx, ax
   
    
    mov ah, 4ch
    int 21h
    
end main