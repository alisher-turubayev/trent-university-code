sstf: lab4_sstf.o sstf_queue.o
	gcc -o sstf lab4_sstf.o sstf_queue.o
	
lab4_sstf.o: lab4_sstf.c sstf_queue.h
	gcc -c lab4_sstf.c
	
sstf_queue.o: sstf_queue.c sstf_queue.h
	gcc -c sstf_queue.c
	
clean:
	rm lab4_sstf.o sstf_queue.o