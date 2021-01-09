# Assignment 3 Question 4
# Written by Alisher Turubayev,
#		Trent University

.data
float1: .float 0.1
float2: .float 0.2
float3: .float 0.33
space:  .asciiz " "

.text
main:
	l.s $f1, float1
	l.s $f2, float2
	l.s $f3, float3
	
	add.s $f4, $f1, $f2
	add.s $f4, $f4, $f3
	
	mov.s $f12, $f4
	li $v0, 2
	syscall
	
	la $a0, space
	li $v0, 4
	syscall
	
	add.s $f4, $f2, $f3
	add.s $f4, $f4, $f1
	
	mov.s $f12, $f4
	li $v0, 2
	syscall
	
	li $v0, 10
	syscall 
