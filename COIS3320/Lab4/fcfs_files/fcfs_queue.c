/*
 * First-Come-First-Serve (FCFS) queue 
 * Written by Alisher Turubayev
 *
 * Purpose:
 *  Provides an implementation for the FCFS queue in C
 *  FCFS queue is implementation using a circular linked list
 * 
 * Dependencies:
 *  fcfs_queue.h
 */

#include <stdio.h>
#include <ctype.h>
#include <stdlib.h>
#include <limits.h>

#include "fcfs_queue.h"

/*
 * queue_init - struct queue *
 * 
 * Purpose:
 *  Initializes the queue and returns a pointer to memory location
 *
 * Returns:
 *  Pointer to memory location or NULL if allocation failed
 */
struct queue * queue_init() 
{
	struct queue *fcfs = (struct queue *) malloc(sizeof(struct queue));
	
	if (fcfs == NULL) 
		fprintf(stderr, "* Error in queue_init: allocation failed. *\n");
	else 
	{
		fcfs->head = NULL;
		fcfs->last = NULL;
	}
	
	return fcfs;
}

/* 
 * queue_insert - void
 *
 * Purpose:
 *  Function inserts the number into the FCFS queue
 * 
 * Arguments:
 *  *fcfs - struct queue.
 *  new_item - int. Item to be inserted
 */
void queue_insert(struct queue *fcfs, int new_item) 
{
	struct queue_node *new_node;
	new_node = (struct queue_node *) malloc(sizeof(struct queue_node));
	
	new_node->item = new_item;
	new_node->next = NULL;
	
	// If nothing in queue, place at beginning
	if (fcfs->last == NULL) 
	{
		fcfs->head = new_node;
		fcfs->last = new_node; 
	}
	else 
	{
		(fcfs->last)->next = new_node;
		fcfs->last = new_node; 
	}
	
	return;
}

/*
 * queue_remove - int
 *
 * Purpose: 
 *  remove the first item from FCFS queue
 *
 * Arguments:
 *  *fcfs - struct queue.
 */
int queue_remove(struct queue *fcfs) 
{
	// If the queue is empty, issue overflow and return NULL
	if (fcfs->head == NULL) 
	{
		fprintf(stderr, "* Error in queue_remove: queue underflow *\n");
		return INT_MIN;	
	}
	
	struct queue_node *node = fcfs->head;
	int first = node->item;
	
	// If the last item, connect the ends
	if (fcfs->head == fcfs->last) 
	{
		fcfs->head = NULL;
		fcfs->last = NULL;
	}
	else
		fcfs->head = node->next;
	
	free(node);
	return first;	
}

/*
 * queue_empty - int
 *
 * Purpose:
 *  Returns TRUE if queue is empty and FALSE otherwise
 *
 * Arguments:
 *  *fcfs - struct queue. 
 */
int queue_empty(struct queue *fcfs) 
{
	if (fcfs->head == NULL)
		return TRUE;
		
	return FALSE;
}
