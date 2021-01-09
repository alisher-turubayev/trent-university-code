# Alisher Turubayev
# 0630908
# Basic recursion

# Data declaration
.data
out_number1: .asciiz "Input first number:\n"
out_number2: .asciiz "Input second number:\n"
out_result: .asciiz "Sum is:\n"

# Instructions
.text
main:
	# Input first number
	li $v0, 4
	la $a0, out_number1
	syscall
	
	li $v0, 5
	syscall
	move $t1, $v0
	
	# Input second number
	li $v0, 4
	la $a0, out_number2
	syscall
	
	li $v0, 5
	syscall
	move $t2, $v0
	
	# Move the numbers into $a0 and $a1
	move $a0, $t1
	move $a1, $t2
	
	# Start the recursion
	jal ms_recurse
	
	# Write output
	move $t0, $v0
	
	li $v0, 4
	la $a0, out_result
	syscall
	
	li $v0, 1
	move $a0, $t0
	syscall
	
	# Exit the program
	li $v0, 10
	syscall
	
mysum:
	bne $a0, $a1, ms_recurse
	move $v0, $a1
	jr $ra
	
ms_recurse:
	sub $sp, $sp, 8
	sw $ra, 0($sp)
	sw $a0, 4($sp)
	addi $a0, $a0, 1
	jal mysum
	lw $a0, 4($sp)
	add $v0, $v0, $a0
	lw $ra, 0($sp)
	addi $sp, $sp, 8
	jr $ra