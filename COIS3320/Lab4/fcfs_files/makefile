fcfs: lab4_fcfs.o fcfs_queue.o
	gcc -o fcfs lab4_fcfs.o fcfs_queue.o
	
lab4_fcfs.o: lab4_fcfs.c fcfs_queue.h
	gcc -c lab4_fcfs.c
	
fcfs_queue.o: fcfs_queue.c fcfs_queue.h
	gcc -c fcfs_queue.c
	
clean:
	rm lab4_fcfs.o fcfs_queue.o