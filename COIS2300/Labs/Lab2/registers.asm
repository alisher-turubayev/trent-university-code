# Alisher Turubayev
# 0630908
# Program to investigate basic registers and addition

.data

.text

.macro done
	li $v0, 10		# System call for program termination (10)
	syscall			# syscall for program termination
.end_macro

main:
	# Addition
	li $t1, 1		# Load value of 1 into $t1
	li $t2, 2		# Load value of 2 into $t2
	add $t0, $t1, $t2	# Add $t1 and $t2 and store result in $t0
	
	# Input of integer from keyboard
	li $v0, 5		# System call for inputting an integer (5)
	syscall			# syscall
	move $t0, $v0		# Move the value to $t0
	
	# Print of output
	move $a0, $t0		# Move the value that we want to print to $a0
	li $v0, 1		# System call for printing an integer (1)
	syscall			# syscall
	
	# Small if/else statement: outputs a larger number inputted from keyboard
	li $v0, 5		# Input a first number and store it in $t1
	syscall
	move $t1, $v0
	
	li $v0, 5		# Input a second number and store it in $t2
	syscall
	move $t2, $v0
	
	bgt $t2, $t1, t2_bigger # If $t2 is bigger than $t1, branch to t2_bigger
	move $t0, $t1		# Else, move 
	b endif			# Branch to endif
		
t2_bigger: 			# Branch for if in main
	move $t0, $t2
	b endif
	
endif:
	move $a0, $t0		# Output the bigger value
	li $v0, 1
	syscall
	
	# Loop
	move $t0, $zero		# Equalize $t0 to zero, it will be a counter for loop
	li $t1, 5		# The upper boundary, 5, for the loop
loop:	
	beq $t0, $t1, endloop	# If the counter is bigger than the upper boundary, end loop
	
	addi $t0, $t0, 1
	
	move $a0, $t0
	li $v0, 1
	syscall

	j loop

endloop:
	done