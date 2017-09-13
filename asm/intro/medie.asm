.model small

.stack 100h

.data
    v db 1, 2
    len equ ($ - v)
    s db 0
    
.code
main proc
    mov ax, @data
    mov ds, ax
    
    ; code goes here 
    lea di, v ; di points to the beginning of v
    mov cx, len 
    mov bx, 0
    
    iter:
        mov al, [di]
        add bl, al
        
        inc di
    loop iter                         
    
    ; the sum of the elements
    mov s, bl
    
    ; store the sum            
    mov ax, bx 
     
    mov bl, len 
    div bl
    
    mov dl, al         
               
    mov ah, 4ch
    int 21h   
       
endp
end main