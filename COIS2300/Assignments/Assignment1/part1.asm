# Alisher Turubayev
# 0630908
# Program to add or multiply two numbers, depending on input

# Data declaration
.data
string_number1: .asciiz "Input first number\n"
string_number2: .asciiz "Input second number\n"
string_operations: .asciiz "Input operation code (0 for addition, any other number - for multiplication)\n"

# Instructions
.text
main:
	# Output first string and get first number (the number is saved in $t1)
	la $a0, string_number1
	li $v0, 4
	syscall
	
	li $v0, 5
	syscall
	move $t1, $v0
	# Output second string and get second number (the number is saved in $t2)
	la $a0, string_number2
	li $v0, 4
	syscall
	
	li $v0, 5
	syscall
	move $t2, $v0
	# Output operation codes and get a code of desired operation (the operation code is saved in $t3)
	la $a0, string_operations
	li $v0, 4
	syscall
	
	li $v0, 5
	syscall
	move $t3, $v0
	# Calculate result
	beq $t3, $zero, addition	# Branches to addition if 
	mulo $t0, $t1, $t2
	j endif
	
addition: # Adds two numbers ($t1 and $t2) together and stores the result in $t0
	add $t0, $t1, $t2
	j endif
	
endif:
	# Output the result
	move $a0, $t0
	li $v0, 1
	syscall
	
	li $v0, 10
	syscall