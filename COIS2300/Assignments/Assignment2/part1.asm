# Alisher Turubayev
# 0630908
# Assignment 2 Question I part 1

# Data fields
.data
array: .word 2, 6, 0, 1, 10, -3, 4, 5, 9, 7
endline: .asciiz "\n"

# Instructions
.text
main:
	# Call range procedure
	jal range
	# Output the findLargest, findSmallest, range
	move $a0, $s2
	li $v0, 1
	syscall
	la $a0, endline
	li $v0, 4
	syscall
	
	move $a0, $s3
	li $v0, 1
	syscall
	la $a0, endline
	li $v0, 4
	syscall
	
	move $a0, $s4
	li $v0, 1
	syscall
	# Terminate the program
	li $v0, 10
	syscall
	
range:
	# Save the return address
	move $s0, $ra
	# Call the findLargest function (the result is saved in $s2)
	jal findLargest
	# Call the findSmallest function (the result is saved in $s3)
	jal findSmallest
	# Find range and store it in $s4
	sub $s4, $s2, $s3
	# Return back to main procedure
	jr $s0
	
# findLargest procedure
findLargest:
	# Save the return address in $s1
	move $s1, $ra
	# Store address of array in $t0
	la $t0, array
	# Equalize $t5 to the first number in array
	lw $t5, 0($t0)
	# Save upper bound as $t1 = 10*4
	addi $t1, $zero, 40
	# Equalize $t2 (index) to 0
	move $t2, $zero
loop1:
	# Load next integer address from array to $t3 and save it in $t4
	add $t3, $t0, $t2
	lw $t4, 0($t3)
	# Check if current max is smaller and if true, equalize
	bgt $t4, $t5, equalize1
back1:
	# Increase the index
	addi $t2, $t2, 4
	# If we did not reach the end of array, continue
	blt $t2, $t1, loop1 

	# Move the result from a temporary location to $s2
	move $s2, $t5
	# Return to calling procedure
	jr $s1

# Equalize $t5 to integer in $t4
equalize1:
	move $t5, $t4
	b back1
	
# findSmallest procedure
findSmallest:
	# Save the return address in $s1
	move $s1, $ra
	# Store address of array in $t0
	la $t0, array
	# Equalize $t5 to the first number in array
	lw $t5, 0($t0)
	# Save upper bound as $t1 = 10*4
	addi $t1, $zero, 40
	# Equalize $t2 (index) to 0
	move $t2, $zero
loop2:
	# Load next integer address from array to $t3 and save it in $t4
	add $t3, $t0, $t2
	lw $t4, 0($t3)
	# Check if current min is bigger and if true, equalize
	blt $t4, $t5, equalize2
back2:
	# Increase the index
	addi $t2, $t2, 4
	# If we did not reach the end of array, continue
	blt $t2, $t1, loop2
	
	# Move the result from a temporary location to $s2
	move $s3, $t5
	# Return to calling procedure
	jr $s1

# Equalize if branch
equalize2:
	# Equalize $t5 to integer in $t4
	move $t5, $t4
	b back2
