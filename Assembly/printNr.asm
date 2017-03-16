.model small

.stack 100h

.data
    number dw 5
    len equ $ - number
    endline db 10,13,'$'

.code
start:
    mov ax, @data
    mov ds, ax
    
    mov dx, number
    add dx, '0'
    mov ah, 02h
    int 21h
    
    lea dx, endline
    mov ah, 09h
    int 21h
    
    mov ax, 4ch
    int 21h
end start