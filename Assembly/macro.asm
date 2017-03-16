.model small

.stack 100h

.data
    w1 dw 02h
    nl db 10,13,'$'
.code
 
; represent p in binary, on 8 bits
macro printb p
    mov cx, 8
    print:
        mov ah, 02h
        mov dl, '0'
        test p, 10000000b
        jz zero
        mov dl, '1'
    zero:
        int 21h
        shl p, 1
    loop print
endm printb   

; return to os
macro exit
    mov ah, 4ch
    int 21h
endm exit  
   
; starting point   
start:

     mov ax, @data
     mov ds, ax  
     
     mov bx, w1
     
     mov cx, 3
        
     pow:
        shl bx, 1
     loop pow
     
     printb bx
     
     
     exit
         
end start