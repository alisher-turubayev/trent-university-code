# Assignment 4 Question 5
# Written by Alisher Turubayev,
# 		Trent University
#
# This code takes two predefined arrays and merges
# them into one. Duplicate values appear twice in
# the final array
.data
array1: .word 0, 1, 3, 4, 5, 8, 9
array2: .word 1, 2, 6, 7, 10, 11, 12, 13, 14, 15
answer: .word 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
size1: .word 28
size2: .word 40
size3: .word 68
space: .asciiz " "

.text
main:
# init values
la $a1, array1
la $a2, array2
la $a3, answer
lw $s1, size1
lw $s2, size2
lw $s3, size3
# start loop
jal merge
# start output
jal output
# end the program
li $v0, 10
syscall

merge:
# t1 - index of array1
# t2 - index of array2
# t3 - index of answer
li $t1, 0
li $t2, 0
li $t3, 0
# t4 - used to calculate address
# t5 - stores the number from array1
# t6 - stores the number from array2
loop1:
	# If the first value present
	bne $t1, $s1, ok1
	# If the second value is present, but first is not
	b yes2
ok1:
	# If the first value is present, but second is not
	beq $t2, $s2, yes1
	# If both values are present, do the comparison
	add $t4, $t1, $a1
	lw $t5, ($t4)
	add $t4, $t2, $a2
	lw $t6, ($t4)
	# If array1 value is smaller than array2
	blt $t5, $t6, yes1
	# Else
	b yes2
# This piece of - code gets the value from array1 and stores it in answer	
yes1:
	# Calculate the address from array1...
	add $t4, $t1, $a1
	lw $t5, ($t4)
	# and store the number into address in answer
	add $t4, $t3, $a3
	sw $t5, ($t4)
	# index1++
	addi $t1, $t1, 4
	b cont
# This amazing, state-of-the-art code gets the value from array2 and stores it in answer
yes2:
	# Calculate the address from array2...
	add $t4, $t2, $a2
	lw $t6, ($t4)
	# and store the number into address in answer
	add $t4, $t3, $a3
	sw $t6, ($t4)
	# index2++
	addi $t2, $t2, 4
	b cont
cont:
	addi $t3, $t3, 4
	bne $t3, $s3, loop1		
# Return back
jr $ra

output:
# $t0 - index
li $t0, 0
loop2: 
	# Get the address and output a number
	add $t1, $t0, $a3
	lw $a0, ($t1)
	li $v0, 1
	syscall
	# Output space
	la $a0, space
	li $v0, 4
	syscall
	# index++
	addi $t0, $t0, 4
	bne $t0, $s3, loop2
# Return back
jr $ra