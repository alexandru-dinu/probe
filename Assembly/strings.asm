.model small
.data
 opr1 dw 008h
 opr2 dw 003h
 nl db 10,13,'$'
.code
        mov ax,@data
        mov ds,ax
        
        mov dx,opr1
        mov cx,opr2
       
        sub dx,cx
        add dx, '0'
        
        mov ah, 02h
        int 21h
        
        mov ah,4ch
        int 21h
end