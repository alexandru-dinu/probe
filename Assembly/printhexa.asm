.model small

.stack 100h

.data 
    nr dw 0ACBDh

.code
main:
    
    mov ax, @data
    mov ds, ax
    
    mov ax, nr 
    mov cx, 0
    
    division:
        mov bx, 16
        div bx
        push dx 
        inc cx
        mov dx, 0
        cmp ax, 0
    jne division
    
    aggregate: 
        pop ax
        cmp ax, 0ah
        je isa                            
        cmp ax, 0bh
        je isb
        cmp ax, 0ch
        je isc
        cmp ax, 0dh
        je isd
        cmp ax, 0eh
        je ise
        cmp ax, 0fh
        je isf
        
        mov dl, al
        add dl, '0'
        append:
        mov ah, 02h
        int 21h 
        dec cx
        cmp cx, 0
        jne aggregate 
        je done
    
    isa:
       mov dl, 'A'  
       jmp append
    isb:
       mov dl, 'B'
       jmp append
    isc:
       mov dl, 'C'
       jmp append
    isd:
       mov dl, 'D'
       jmp append
    ise:
       mov dl, 'E'
       jmp append
    isf:
       mov dl, 'F'
       jmp append
    
    done:
        mov ah, 4ch
        int 21h
    
end main