.model small

.stack 100h

.data
    nr db 0Ah
    oddmsg db 'odd$'
    evenmsg db 'even$'
    
.code 

; macro for checking parity
; sets zero flag accordingly
macro check p
    test p, 00000001b
endm check

main proc
    
    mov ax, @data
    mov ds, ax
    
    ; read a char from stdin
    ; store it (ascii) in al
    mov ah, 01h
    int 21h
    
    mov dl, al
    
    check dl
    mov ah, 09h 
    jz even 
     
    odd:
       lea dx, oddmsg
       int 21h
       jmp done 
     
    even:
       lea dx, evenmsg
       int 21h    
   
    
    done:
        mov ah, 4ch
        int 21h
    
endp
end main