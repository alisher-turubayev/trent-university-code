# Alisher Turubayev
# 0630908
# Program to output Hello World

.data # Data declaration section
out_string: 
	.byte 0x48	# ASCII for H 
	.byte 0x65	# ASCII for e
	.byte 0x6C	# ASCII for l
	.byte 0x6C	# ASCII for l
	.byte 0x6F	# ASCII for o
	.byte 0xA	# ASCII for newline
	.byte 0x0	# NULL

.text # Assembly language instructions
main: # Start of code section
	li $v0, 4		# system call code for printing string (4)
	la $a0, out_string	# load address of string to print into $a0
	syscall			# syscall to output string
	li $v0, 10		# system call code for program termination
	syscall			# syscall to terminate program
	
	