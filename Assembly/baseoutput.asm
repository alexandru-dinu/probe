.model small

.stack 100h

.data
    nr dw 65535 
    base dw 2

.code
main:
    
    mov ax, @data
    mov ds, ax 
    
    ; init count
    mov cx, 0
    
    ; store the number
    mov ax, nr
      
    division:
        mov bx, base
        div bx
        
        push dx
        inc cx
        mov dx, 0
        cmp ax, 0
    jne division
    
    ready:
        pop ax
        mov dx, ax
        add dx, '0'
        mov ah, 02h
        int 21h
    loop ready
           
    mov ah, 4ch
    int 21h
    
end main