.model small

.stack 100h

.data
    sir1 db "First string " 
    lung1 equ ($-sir1) 

    sir2 db "Second string." 
    lung2 equ ($-sir2) 

    sir3 db (lung1+lung2+1) dup (?)

.code 

; procedure to concat 2 strings
concat proc near
    
    push bp
    mov bp, sp
    
    cld
    
    push ds
    pop es
      
    mov di, word ptr [bp+4]  
      
    ; put in s3 the contents of s1
    mov si, word ptr [bp+12]
    mov cx, word ptr [bp+10]  
    rep movsb
    
    ; put in s3 the contents of s2
    mov si, word ptr [bp+8]
    mov cx, word ptr [bp+6]
    rep movsb
    
    ; compute the length of s3
    mov ax, word ptr [bp+10]  
    add ax, word ptr [bp+6]
    
    ; store s3's length in the stack
    mov word ptr [bp + 14], ax
    
    pop bp
    ret 10 
    
concat endp

; procedure to print a string
print proc near
    
    push bp
    mov bp, sp
    
    mov cx, word ptr [bp + 6]
    mov si, word ptr [bp + 4]
    
    iter:
        mov dl, byte ptr ds:[si] 
        
        mov ah, 2h
        int 21h 
        
        inc si
    loop iter
    
        pop bp
        ret 4
        
print endp

                              

main:
    
    mov ax, @data
    mov ds, ax
    
    sub sp, 2
    
    push offset sir1
    push lung1
    
    push offset sir2
    push lung2
    
    push offset sir3
    
    call concat 
    
    push offset sir3
    
    call print
    
    mov ah, 4ch
    int 21h
    
end main