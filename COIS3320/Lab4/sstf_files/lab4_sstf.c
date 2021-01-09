/* 
 * Lab 4 - COIS 3320
 * Written by Alisher Turubayev
 * 
 * Purpose:
 *  This assignment is to simulate the disk scheduling for a disk with 800 tracks
 *  with Shortest-Seek-Time-First (SSTF)
 * 
 * Coding style recommendations used:
 *  https://www.doc.ic.ac.uk/lab/cplus/cstyle.html
 * 
 * Assumptions:
 *. None.
 * 
 * Dependencies:
 *  sstf_queue.h - for implementation of SSTF queue.
 */

#include <math.h>
#include <stdio.h>
#include <ctype.h>
#include <stdlib.h>
#include <limits.h>

#include "sstf_queue.h"

// Simulation constraints
const int MAX_TRACK_REQUESTS = 5;
const int MAX_TRACKS = 800;

/* 
 * genFileRequest - void
 * 
 * Purpose: 
 *  Function generates new file requests using the random seed and puts
 *  them in the SSTF queue
 *
 * Arguments:
 *  *seed - int. Random seed for number generator
 *  *sstf - struct queue. 
 */
void gen_file_request(struct queue *sstf, int curr_pos) {
	// Add 1 to make between 1 and 5
	int num_tracks = rand() % MAX_TRACK_REQUESTS + 1;
	// Will save the new track position; declared here so to avoid continuous allocation
	int track_pos = 0;
	
	for (int i = 0; i < num_tracks; i++) 
	{
		track_pos = rand() % MAX_TRACKS + 1;
		queue_insert(sstf, track_pos, curr_pos);	
	}
	
	return;
} 

/*
 * get_input - void.
 *
 * Purpose:
 *  Gets the number of requests (length of simulation) and random seed 
 *  for the number generator from the user.
 *
 * Arguments:
 *  *num_requests - int. To pass the number of requests back to calling function
 */
void get_input(int *num_requests) 
{
	int seed = 0;
	
	printf("Please input a positive number as a number of requests (length of simulation):\n");
	scanf("%d", num_requests);
	
	// Must be positive or 0
	if (*num_requests < 0)
		*num_requests = 0;	
	
	printf("Please input a positive number as seed for the random number generator:\n");
	scanf("%d", &seed);
	
	// Must be positive or 0
	if (seed < 0)
		seed = 0;
	
	srand(seed);
	return;
} 

int main() 
{
	int num_requests = 0;
	get_input(&num_requests);	
	
	struct queue *sstf = queue_init();
	if (sstf == NULL) 
	{
		printf("Error occured, closing the application\n");
		return -1;	
	}
	
	// At beginning, head is on track 0
	int curr_track = 0;
	// Total head moves
	int total_moves = 0;
	
	for (int i = 0; i < num_requests; i++) 
	{
		gen_file_request(sstf, curr_track);
		
		while (queue_empty(sstf) == FALSE) 
		{
			int new_track = queue_remove(sstf);
			if (new_track == INT_MIN) 
			{
				printf("Error occured, closing the application\n");
				return -1;
			}
			
			total_moves += abs(curr_track - new_track);
			curr_track = new_track;
		}
	}	
	
	// Print the average head movement
	printf("Average head movement: %f\n", 
			total_moves / (float)num_requests);
	
	return 0;
}