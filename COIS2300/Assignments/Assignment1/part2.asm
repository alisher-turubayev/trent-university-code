# Alisher Turubayev
# 0630908
# Outputs the factorial of inputted positive integer (< 15)

# Data declaration
.data
out_ask_input: .asciiz "Input a positive integer\n"
out_error: .asciiz "ERROR: The number is not positive\n"
out_result: .asciiz "The result is "

# Instructions
.text
main:
	# Propmt the user to input a number N and save it in $t1
	la $a0, out_ask_input
	li $v0, 4
	syscall
	
	li $v0, 5
	syscall
	move $t1, $v0
	# Check if the N is positive. If not, throw an error
	blez $t1, error
	# Else, initiate $t0 and $t2 (counter) to 1, start a loop and calculate the factorial (stored in $t0)
	li $t0, 1
	li $t2, 1
	j loop
	
error:	# Throws error
	la $a0, out_error
	li $v0, 4
	syscall
	break
	
loop:	# Calculates the factorial
	mul $t0, $t0, $t2	# Multiply without overflow expection handling - we assume that the N is less than 15
	beq $t2, $t1, endloop	# If the counter is equal to N - stop the loop
	addi $t2, $t2, 1
	j loop
	
endloop:
	# Output the result
	la $a0, out_result
	li $v0, 4
	syscall
	
	move $a0, $t0
	li $v0, 1
	syscall
	
	li $v0, 10
	syscall
