#include <stdio.h>
#include <stdlib.h>

typedef struct Graph {
	int** m;
	int nodes;
} *Graph;

Graph init(int n) {
	Graph g = calloc(1, sizeof(struct Graph));
	g->m = calloc(n, sizeof(int*));
	g->nodes = n;


	int i;
	for(i = 0; i < n; i++) {
		g->m[i] = calloc(n, sizeof(int));
	} 

	return g;
}

void visit(Graph g, int from, int* visited) {
	printf("visited: %d\n", from);
	visited[from] = 1;
	
	int i;
	for(i = 0; i < g->nodes; i++) {
		if(g->m[from][i] == 1 && visited[i] == 0) {
			visit(g, i, visited);
		}
	}
}

void explore(Graph g, int from) {
	int* visited = calloc(g->nodes, sizeof(int));
	visit(g, from, visited);
	free(visited);
}

void deleteGraph(Graph g) {
	int i;
	for(i = 0; i < g->nodes; free(g->m[i++]));
	free(g->m);
	free(g);
}

int main(int argc, char const *argv[])
{
	Graph g = init(3);

	g->m[0][0] = 0;
	g->m[0][1] = 1;
	g->m[0][2] = 0;

	g->m[1][0] = 1;
	g->m[1][1] = 0;
	g->m[1][2] = 1;

	g->m[2][0] = 0;
	g->m[2][1] = 0;
	g->m[2][2] = 0;

	explore(g, 1);

	deleteGraph(g);

	return 0;
}