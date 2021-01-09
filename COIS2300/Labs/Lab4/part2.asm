# Alisher Turubayev
# Lab 4 Part 2
.data
	theArray: .space 20

.text
	# Create values to store in array
	addi $s0, $zero, 1
	addi $s1, $zero, 3
	addi $s2, $zero, 5
	addi $s3, $zero, 7
	addi $s4, $zero, 9
	
	# Create an index at 0
	addi $t0, $zero, 0
	
	# Store values in array (store the value and move the index 4 bytes)
	sw $s0, theArray($t0)
	addi $t0, $t0, 4
	sw $s1, theArray($t0)
	addi $t0, $t0, 4
	sw $s2, theArray($t0)
	addi $t0, $t0, 4
	sw $s3, theArray($t0)
	addi $t0, $t0, 4
	sw $s4, theArray($t0)
	addi $t0, $t0, 4
	
	# Output the values
	addi $t0, $zero, 0
	lw $t6, theArray($t0)
	
	li $v0, 1
	addi $a0, $t6, 0
	syscall
	
	addi $t0, $t0, 4
	lw $t6, theArray($t0)
	
	li $v0, 1
	addi $a0, $t6, 0
	syscall
	
	addi $t0, $t0, 4
	lw $t6, theArray($t0)
	
	li $v0, 1
	addi $a0, $t6, 0
	syscall
	
	addi $t0, $t0, 4
	lw $t6, theArray($t0)
	
	li $v0, 1
	addi $a0, $t6, 0
	syscall
	
	addi $t0, $t0, 4
	lw $t6, theArray($t0)
	
	li $v0, 1
	addi $a0, $t6, 0
	syscall
	
	li $v0, 10
	syscall