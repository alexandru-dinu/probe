.model small
.data
	org 100h ; starting point
	nr1 db 10 dup (30h)
	nr2 db 20 dup (0f7h)
lung equ $-nr2
lungw dw $-nr2
mesaj db 'ABCDE$'
sirb db 10 dup (7ah)
adr_sb dd sirb
vd dd 1234abcdh
vq dq 12345678abcd0000h
vbcd dt 123456789
.stack
.code
	mov ax,@data
	mov ds,ax
	mov ax, word ptr nr1
	mov ax,4c00h
	int 21h
end
