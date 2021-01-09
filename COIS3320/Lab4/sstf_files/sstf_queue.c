/*
 * Shortest-Seek-Time-First (SSTF) queue 
 * Written by Alisher Turubayev
 *
 * Purpose:
 *  Provides an implementation for the SSTF queue in C
 *  SSTF queue is implementation using a circular linked list
 * 
 * Dependencies:
 *  sstf_queue.h
 */

#include <stdio.h>
#include <ctype.h>
#include <stdlib.h>
#include <limits.h>

#include "sstf_queue.h"

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
	struct queue *sstf = (struct queue *) malloc(sizeof(struct queue));
	
	if (sstf == NULL) 
		fprintf(stderr, "* Error in queue_init: allocation failed. *\n");
	else 
	{
		sstf->head = NULL;
		sstf->last = NULL;
	}
	
	return sstf;
}

/* 
 * queue_insert - void
 *
 * Purpose:
 *  Function inserts the number into the SSTF queue
 * 
 * Arguments:
 *  *sstf - struct queue.
 *  new_item - int. Item to be inserted
 */
void queue_insert(struct queue *sstf, int new_item, int curr_pos) 
{
	struct queue_node *new_node;
	new_node = (struct queue_node *) malloc(sizeof(struct queue_node));
	
	new_node->item = new_item;
	new_node->distance = abs(new_item - curr_pos);
	new_node->next = NULL;
	
	// If nothing in queue or new item has bigger priority, place at beginning. Else, seek new position
	if (sstf->last == NULL) 
	{
		sstf->head = new_node;
		sstf->last = new_node; 
	}
	else if ((sstf->head)->distance >= new_node->distance) 
	{
		new_node->next = sstf->head;
		sstf->head = new_node;
	}
	else 
	{
		struct queue_node *prev = sstf->head;
		struct queue_node *curr = (sstf->head)->next;
		
		while (curr != NULL) 
		{
			if (curr->distance >= new_node->distance) 
			{
				new_node->next = curr;
				prev->next = new_node;
				break;
			}	
			prev = curr;
			curr = curr->next;
		}
		
		// If no place is found, put it at the end
		if (curr == NULL) 
		{
			(sstf->last)->next = new_node;
			sstf->last = new_node;
		}
	}
	
	return;
}

/*
 * queue_remove - int
 *
 * Purpose: 
 *  remove the first item from queue
 *
 * Arguments:
 *  *sstf - struct queue.
 */
int queue_remove(struct queue *sstf) 
{
	// If the queue is empty, issue overflow and return NULL
	if (sstf->head == NULL) 
	{
		fprintf(stderr, "* Error in queue_remove: queue underflow *\n");
		return INT_MIN;	
	}
	
	struct queue_node *node = sstf->head;
	int first = node->item;
	
	// If the last item, connect the ends
	if (sstf->head == sstf->last) 
	{
		sstf->head = NULL;
		sstf->last = NULL;
	}
	else
		sstf->head = node->next;
	
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
 *  *sstf - struct queue. 
 */
int queue_empty(struct queue *sstf) 
{
	if (sstf->head == NULL)
		return TRUE;
		
	return FALSE;
}
