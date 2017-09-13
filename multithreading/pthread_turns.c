#include <stdio.h>
#include <stdlib.h>
#include <pthread.h>

#define NUM_THREADS 10
#define NUM_ITERATIONS 5

pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
pthread_cond_t cond = PTHREAD_COND_INITIALIZER;

char const LETTERS[11] = "ABCDEFGHIJ";

/* to be used when an array of functions are needed

typedef void* (*thread_func_t)(void*);

void *printA(void* arg);
void *printB(void* arg);

thread_func_t thread_func[] = {printA, printB};

*/

void* thread_print(void*);

/* specifies whose turn is it */
/* can be changed to specify who goes first*/
int turn = 0;

int main(int argc, char const *argv[])
{
	// i is long so that sizeof(i) == sizeof(void*) = 8 (x64)
	long i;
	int j;

	pthread_t threads[NUM_THREADS];

	for (j = 0; j < NUM_ITERATIONS; j++) {
		for (i = 0; i < NUM_THREADS; i++)
			/* create threads and set as arguments the index (thread id) */
			pthread_create(&threads[i], NULL, thread_print, (void*)i);

		for (i = 0; i < NUM_THREADS; i++)
			pthread_join(threads[i], NULL);

		printf("\n");
	}


	pthread_exit(NULL);
}


void *thread_print(void* arg)
{
	int i;
	long tid = (long)(arg);

	pthread_mutex_lock(&mutex);

	/* wait if it's not my turn */
	if (turn % NUM_THREADS != tid)
		pthread_cond_wait(&cond, &mutex);

	/* do stuff */
	printf("%c", LETTERS[turn]);

	/* set the turn for the next thread */
	turn = (turn + 1) % NUM_THREADS;

	/* signal the other thread that it's his turn */
	pthread_cond_signal(&cond);

	pthread_mutex_unlock(&mutex);

	pthread_exit(NULL);
}
