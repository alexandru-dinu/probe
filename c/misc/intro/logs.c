#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <string.h>

#define MAX_CHR 100
#define MAX_SRC 10
#define NR_MSJ 2
#define MAX_MSJ 100

typedef struct {
    char *mesaj;
    char destinatar[256];
    unsigned long timestamp;
} TMesaj;

typedef struct {
    TMesaj *mesaje;
    char *sursa;
    int nrCrtMesaje;
    int nrMaxMesaje;
} TLog;

TLog *alocareLog(int nrMesaje)
{
    TLog *l = malloc(sizeof(TLog));
    if(!l) {
        perror("Malloc error!");
        exit(1);
    }

    l->sursa = malloc(MAX_SRC * sizeof(char));
    if(!l->sursa) {
        perror("Malloc error!");
        free(l);
        exit(1);
    }

    l->mesaje = malloc(nrMesaje * sizeof(TMesaj));
    if(!l->mesaje) {
        perror("Malloc error!");
        free(l->sursa);
        free(l);
        exit(1);
    }

    int i, j;
    for (i = 0; i < nrMesaje; i++) {
        l->mesaje[i].mesaj = malloc(MAX_CHR * sizeof(char));
        if(!l->mesaje[i].mesaj) {
            for(j = 0; j < i; j++) {
                perror("Malloc error!");
                free(l->mesaje[i].mesaj);
            }
            free(l->mesaje);
            free(l->sursa);
            free(l);
            exit(1);
        }
    }


    l->nrCrtMesaje = nrMesaje;
    l->nrMaxMesaje = MAX_MSJ;

    return l;
}

void eliberareMem(TLog *l)
{
    int i;
    int limit = l->nrCrtMesaje;

    for(i = 0; i < limit; i++) {
        free(l->mesaje[i].mesaj);
    }

    free(l->mesaje);
    free(l->sursa);
    free(l);
}

void writeToTextFile(FILE *f, TLog *l)
{
    int i;
    for(i = 0; i < NR_MSJ; i++) {
        fprintf(f, "MSJ#%d:\n", i + 1);
        fprintf(f, "Timestamp = %lu\n", l->mesaje[i].timestamp);
        fprintf(f, "Sursa = %s\n", l->sursa);
        fprintf(f, "Destinatar = %s\n", l->mesaje[i].destinatar);
        fprintf(f, "Mesaj = %s\n", l->mesaje[i].mesaj);
        fprintf(f, "----------\n");
    }
}

int sortDestCresc(const void *a, const void *b)
{
    return strcmp(
               ((const TMesaj *)a)->destinatar,
               ((const TMesaj *)b)->destinatar);
}

int sortTimeDesc(const void *a, const void *b)
{
    return
        ((const TMesaj *)b)->timestamp -
        ((const TMesaj *)a)->timestamp;
}

int main()
{
    TLog *l = alocareLog(NR_MSJ);

    printf("Sursa: ");
    scanf("%s", l->sursa);

    int i;
    for(i = 0; i < NR_MSJ; i++) {
        char buf[256];

        printf("MSJ#%d:\n", i + 1);

        printf("Timestamp: ");
        scanf("%lu", &l->mesaje[i].timestamp);

        printf("Destinatar: ");
        scanf("%s", buf);
        strcpy(l->mesaje[i].destinatar, buf);

        printf("Mesaj: ");
        scanf("%s", buf);
        strcpy(l->mesaje[i].mesaj, buf);
    }

    FILE *f = fopen("log", "wt");
    if(!f)
        exit(1);

    qsort(l->mesaje, NR_MSJ, sizeof(TMesaj), sortDestCresc);
    qsort(l->mesaje, NR_MSJ, sizeof(TMesaj), sortTimeDesc);

    writeToTextFile(f, l);

    fclose(f);
    eliberareMem(l);
    return 0;
}