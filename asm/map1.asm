.model small
.data
	org 100h
	mesaj dw 0A0Dh, 'BA', 'AB', 0D0Ah, '$'
	lung_mes equ $-mesaj
	sir db '0123456789', '$'
	lung_sir dw $-sir
	config dw 5 dup(0AA55h)
	adr_sir dw sir
	v dq 2 dup (0AABBCCDDEEFF0h)
	vbcd dt 3 dup(5544332211)
	adr_vbcd dd vbcd
	vect db 0Ah dup(71h)
.stack
.code
end
