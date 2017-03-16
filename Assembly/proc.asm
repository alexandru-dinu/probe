.model small

.stack 100h

.data
    str db 'ce nice e assembly'
    len equ $ - str
.code

; printing macro
macro print p
    mov dl, p
    mov ah, 02h
    int 21h
endm print
              
; iterate through array and print its contents    
proc printiter str, len
    lea si, str      
    mov cx, len
    
    iter:
        print [si]
        inc si
    loop iter
    ret
endp
                           
                  
; main entry point
main:
    
    mov ax, @data
    mov ds, ax    
    
    call printiter str, len
    
    exit:
        mov ah, 4ch
        int 21h
    

end main