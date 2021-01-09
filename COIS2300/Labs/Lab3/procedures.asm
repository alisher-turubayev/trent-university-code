# Alisher Turubayev
# 0630908
# Adding two numbers by using a procedure call

# Data declaration
.data
out_number1:	.asciiz "Input first number:\n"
out_number2:	.asciiz "Input second number:\n"
out_result: 	.asciiz "Result:\n"
out_stack: 	.asciiz "Stack value:\n"

# Instructions
.text
main:
	# Call the procedure add_numbers
	jal add_numbers
	
	# Load the values from the stack
	lw $s0, 0($sp)
	addi $sp, $sp, 4
	lw $s1, 0($sp)
	addi $sp, $sp, 4
	lw $s2, 0($sp)
	addi $sp, $sp, 4
	
	# Check if values pushed to stack were retrieved correctly
	li $v0, 4
	la $a0, out_stack
	syscall
	
	li $v0, 1
	move $a0, $s0
	syscall
	
	# Exit the program
	li $v0, 10
	syscall
	
add_numbers:
	# Get first number
	li $v0, 4
	la $a0, out_number1
	syscall
	
	li $v0, 5
	syscall
	move $s1, $v0
	
	# Get second number
	li $v0, 4
	la $a0, out_number2
	syscall
	
	li $v0, 5
	syscall
	move $s2, $v0
	
	# Add two numbers
	add $s0, $s1, $s2
	
	# Push the values onto stack
	addi $sp, $sp, -4
	sw $s2, 0($sp)
	addi $sp, $sp, -4
	sw $s1, 0($sp)
	addi $sp, $sp, -4
	sw $s0, 0($sp)
	
	# Output the number
	li $v0, 4
	la $a0, out_result
	syscall
	
	li $v0, 1
	move $a0, $s0
	syscall
	
	jr $ra