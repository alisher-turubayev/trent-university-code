# Alisher Turubayev 0630908
# Lab 4 Part 1
.data
out_underflow: .asciiz "No overflow detected"
out_overflow: .asciiz "Overflow detected"
a: .float 15.50

.text 
main:
	# Get the first number and store it in $f0
	li $v0, 6
	syscall
	# Load the hardcoded value into $f1
	l.s $f1, a
	
	# Multiply and print the result
	mul.s $f2, $f0, $f1
	mov.s $f12, $f2
	li $v0, 2
	syscall
	
	# Populate $t1 and $t2 with numbers for multiplication
	li $t1, 10
	li $t2, 15
	
	# Use mult to get HI/LO of multiplication
	mult $t1, $t2
	# Check HI/LO for overflow
	mfhi $t3
	mflo $t4
	
	beqz $t3 underflow
	la $a0, out_overflow
	li $v0, 4
	syscall

underflow:
	la $a0, out_underflow
	li $v0, 4
	syscall

	# Terminate the program
	li $v0, 10
	syscall	