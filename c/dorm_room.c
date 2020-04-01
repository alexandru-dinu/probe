#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <time.h>

#include <pthread.h>

#define num_students 25
#define wild_party_count 7

#define TID pthread_self()

pthread_t thr_stud[num_students];
pthread_t thr_dean;

pthread_mutex_t stud_mutex = PTHREAD_MUTEX_INITIALIZER;
pthread_mutex_t dean_mutex = PTHREAD_MUTEX_INITIALIZER;

int students_at_party;
int dean_in_room;

void test1(void);
void test2(void);

void break_party(void);
void enter_room(void);

void dbg_student(const char* message)
{
    printf("Student %ld %s - dir=%d sap=%d\n",
           TID, message,
           dean_in_room, students_at_party);
}

void dbg_dean(const char* message)
{
    printf(">> Dean %s - dir=%d sap=%d\n", message,
           dean_in_room, students_at_party);
}

void *stud_func(void *arg)
{
    enter_room();
    pthread_exit(NULL);
}

void *dean_func(void *arg)
{
    break_party();
    pthread_exit(NULL);
}

void start_student(int idx)
{
    int rc;

    rc = pthread_create(&thr_stud[idx], NULL, stud_func, NULL);

    if (rc != 0)
        exit(1);
}


void start_dean(void)
{
    int rc;

    rc = pthread_create(&thr_dean, NULL, dean_func, NULL);

    if (rc != 0)
        exit(1);
}

/*  code executed by student thread whe */
void party(void)
{
    while (1) {
        /* TODO - continue to party while the dean
         * is _not_ in the room
         */

        pthread_mutex_lock(&stud_mutex);

        //dbg_student("partying...");

        if (dean_in_room == 1) {
            dbg_student("will stop partying");

            students_at_party--;

            pthread_mutex_unlock(&stud_mutex);

            return;
        }

        pthread_mutex_unlock(&stud_mutex);
    }
}

void enter_room(void)
{
    /* TODO - this code is executed by the students at first
     * 1. if the dean is not in the room -> party (call party()
     * function :P )
     * 2. if the dean is in the room, silently run away
     */

    pthread_mutex_lock(&stud_mutex);

    dbg_student("trying to...");

    if (dean_in_room == 0) {

        dbg_student("no dean => party");

        students_at_party++;

        pthread_mutex_unlock(&stud_mutex);

        party();
    }
    else {

        dbg_student("silently run away");

        pthread_mutex_unlock(&stud_mutex);
    }

}

void break_party(void)
{
    /* this code is executed by the dean */

    while (1) {

        /* TODO - wait for
         * 1. the party to get wild
         * or
         * 2. no students are in the room
         */

        sleep(1);

        pthread_mutex_lock(&dean_mutex);

        dbg_dean("wild_party || no students_at_party");

        dbg_dean("in mutex 1");


        if (students_at_party >= wild_party_count || students_at_party == 0) {

            dean_in_room = 1;
            dbg_dean("entered the room");

            pthread_mutex_unlock(&dean_mutex);

            break;
        }

        pthread_mutex_unlock(&dean_mutex);
    }


    while (1) {
        /* TODO - wait for everyone to leave the party */

        sleep(1);

        dbg_dean("wait for everyone to leave the party");

        pthread_mutex_lock(&dean_mutex);

        dbg_dean("in mutex 2");

        if (students_at_party == 0) {

            dbg_dean("everyone left the party, exiting...");

            dean_in_room = 0;

            pthread_mutex_unlock(&dean_mutex);

            return;

        }

        pthread_mutex_unlock(&dean_mutex);
    }
}

void wait_all(void)
{
    int i;
    for (i = 0; i < num_students; i++)
        pthread_join(thr_stud[i], NULL);

    pthread_join(thr_dean, NULL);
}


int main(int argc, char const *argv[])
{
    srand(time(NULL));

    test1();
    test2();

    return 0;
}



void test1(void)
{
    printf("=== TEST 1 === \n");

    int i;

    start_dean();

    sleep(1);

    for (i = 0; i < num_students; i++)
        start_student(i);

    wait_all();

    printf("=== TEST 1 DONE === \n");
}




void test2(void)
{
    printf("=== TEST 2 === \n");

    int i;

    for (i = 0; i < num_students; i++) {
        start_student(i);

        if((rand() % (num_students - i)) < 5) {
            start_dean();
            break;
        }
    }

    for(; i < num_students; i++)
        start_student(i);

    wait_all();

    printf("=== TEST 2 DONE === \n");
}