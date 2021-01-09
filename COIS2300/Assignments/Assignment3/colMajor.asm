# Assignment 3, Question 3
# Written by Alisher Turubayev,
#		Trent University
.data
array1:	.word 3,0,3,1
	.word 5,2,5,9
	.word 4,0,0,6
	.word 5,9,1,6
	
array2: .word 3,4,6,7
	.word 1,6,0,6
	.word 2,4,4,6
	.word 0,2,3,8

result: .word 0,0,0,0
	.word 0,0,0,0
	.word 0,0,0,0
	.word 0,0,0,0

space:  .asciiz " "

endln:	.asciiz "\n"

size:	.word 4

.eqv DATA_SIZE 4

.text
main:
	# Load base addresses for arrays
	la $a1, array1
	la $a2, array2
	la $a3, result
	# $s0 - size, $s1 - operation code: 1 for sum, 0 for multply
	lw $s0, size
	li $s1, 1
	# Start col-major addition and output the result
	jal colMajor
	jal output
	# Change opcode for multiplication
	li $s1, 0
	# Start col-major multiplication
	# Note that as function just overrides the values in result, we don't
	# need to
	jal colMajor
	jal output
	# End
	li $v0, 10
	syscall
	
colMajor:
	# $t0 is column index, $t1 is row 
	li $t0, 0
	loop1:
		li $t1, 0
		loop2:
			# Calculate the offset for an address
			mul $t2, $t1, $s0
			add $t2, $t0, $t2
			mul $t2, $t2, DATA_SIZE
			# Calculate the address of element in first array and save element in $t4
			add $t3, $a1, $t2
			lw $t4, ($t3)
			# Calculate the address of element in second array and save element in $t5
			add $t3, $a2, $t2
			lw $t5, ($t3)
			# Calculate the address of where to save the result
			add $t3, $a3, $t2
			# Add/multply two numbers and save it in result
			beq $s1, 1, numAdd
			mul $t6, $t4, $t5
		rtrn:   sw $t6, ($t3)
			# j = j + 1
			addi $t1, $t1, 1
			blt $t1, $s0, loop2
		# i = i + 1
		add $t0, $t0, 1
		blt $t0, $s0, loop1
	# Return
	jr $ra

numAdd:
	add $t6, $t4, $t5
	b rtrn
	
output:
	# $t0 is column index, $t1 is row 
	li $t1, 0
	loopOut1:
		li $t0, 0
		loopOut2:
			# Calculate the offset for an address
			mul $t2, $t1, $s0
			add $t2, $t0, $t2
			mul $t2, $t2, DATA_SIZE
			# Get and output the number
			add $t3, $a3, $t2
			lw $t4, ($t3)
			move $a0, $t4
			li $v0, 1
			syscall
			# Output space
			la $a0, space
			li $v0, 4
			syscall
			# i = i + 1
			addi $t0, $t0, 1
			blt $t0, $s0, loopOut2
		# Put end of line
		la $a0, endln
		li $v0, 4
		syscall
		# j = j + 1
		add $t1, $t1, 1
		blt $t1, $s0, loopOut1
	# Put end of line
	la $a0, endln
	li $v0, 4
	syscall
	# Return
	jr $ra
			
	
