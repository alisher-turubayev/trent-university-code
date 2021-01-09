# Alisher Turubayev
# 0630908
# Assignment 2 Question I part 2

# Data fields
.data
array: .float 2.3, 6.1, 0.9, 1.2, 10.6, -3.8, 4.4, 5.5, 9.7, 7.0
endline: .asciiz "\n"

# Instructions
.text
main:
	# Call range procedure
	jal range
	# Output the findLargest, findSmallest, range
	mov.s $f12, $f20
	li $v0, 2
	syscall
	la $a0, endline
	li $v0, 4
	syscall
	
	mov.s $f12, $f21
	li $v0, 2
	syscall
	la $a0, endline
	li $v0, 4
	syscall
	
	mov.s $f12, $f22
	li $v0, 2
	syscall
	# Terminate the program
	li $v0, 10
	syscall
range:
	# Save the return address
	move $s0, $ra
	# Call the findLargest function (the result is saved in $f20)
	jal findLargest
	# Call the findSmallest function (the result is saved in $f21)
	jal findSmallest
	# Find range and store it in $f22
	sub.s $f22, $f20, $f21
	# Return back to main procedure
	jr $s0
	
# findLargest procedure
findLargest:
	# Save the return address in $s1
	move $s1, $ra
	# Store address of array in $t0
	la $t0, array
	# Equalize $t5 to the first number in array
	l.s $f5, 0($t0)
	# Save upper bound as $t1 (10-1)*4
	addi $t1, $zero, 40
	# Equalize $t2 (index) to 0
	move $t2, $zero
loop1:
	# Load next float address from array to $t3 and save it in $t4
	add $t3, $t0, $t2
	l.s $f4, 0($t3)
	# Check if current max is smaller and if true, equalize
	c.lt.s $f5, $f4
	bc1t equalize1
back1:
	# Increase the index
	addi $t2, $t2, 4
	# If we did not reach the end of array, continue
	blt $t2, $t1, loop1 

	# Move the result from a temporary location to $s2
	mov.s $f20, $f5
	# Return to calling procedure
	jr $s1

# Equalize $t5 to integer in $t4
equalize1:
	mov.s $f5, $f4
	b back1
	
# findSmallest procedure
findSmallest:
	# Save the return address in $s1
	move $s1, $ra
	# Store address of array in $t0
	la $t0, array
	# Equalize $t5 to the first number in array
	l.s $f5, 0($t0)
	# Save upper bound as $t1 (10-1)*4
	addi $t1, $zero, 40
	# Equalize $t2 (index) to 0
	move $t2, $zero
loop2:
	# Load next integer address from array to $t3 and save it in $t4
	add $t3, $t0, $t2
	l.s $f4, 0($t3)
	# Check if current min is bigger and if true, equalize
	c.lt.s $f5, $f4
	bc1f equalize2
back2:
	# Increase the index
	addi $t2, $t2, 4
	# If we did not reach the end of array, continue
	blt $t2, $t1, loop2
	
	# Move the result from a temporary location to $s2
	mov.s $f21, $f5
	# Return to calling procedure
	jr $s1

# Equalize if branch
equalize2:
	# Equalize $t5 to integer in $t4
	mov.s $f5, $f4
	b back2
