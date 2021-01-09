/*
 * fcfs_queue.h
 * Written by Alisher Turubayev
 * 
 * Header file for First-Come-First-Serve (FCFS) queue implementation.
 * 
 * Dependencies:
 *  None. 
 */

#define TRUE 1
#define FALSE 0

// Struct to accomodate the FCFS queue
struct queue {
	struct queue_node *head;
	struct queue_node *last;	
};

// Struct to contain individual nodes
struct queue_node {
	int item;
	struct queue_node *next;
};

struct queue * queue_init();
void queue_insert(struct queue *fcfs, int new_item);
int queue_remove(struct queue *fcfs);
int queue_empty(struct queue *fcfs);