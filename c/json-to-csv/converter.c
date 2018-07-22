#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

#include <sys/types.h>
#include <sys/stat.h>
#include <unistd.h>
#include <fcntl.h>

#include "utils.h"

off_t get_file_size(int fd)
{
	off_t size;

	size = lseek(fd, 0L, SEEK_END);
	DIE(size == (off_t)-1, "lseek");

	DIE(lseek(fd, 0L, SEEK_SET) == (off_t)-1, "lseek");

	return size;
}


void free_matrix(void **mat, size_t n)
{
	size_t i;

	for (i = 0; i < n; i++) {
		free(mat[i]);
		mat[i] = NULL;
	}

	free(mat);
	mat = NULL;
}

char *read_file_into_string(int fd, size_t size)
{
	size_t offset = 0, ret = 0;

	char *str = malloc((size + 1) * sizeof(char));
	DIE(str == NULL, "malloc");

	while (offset < size) {
		ret = read(fd, str + offset, size - offset);
		DIE(ret < 0, "read");

		offset += ret;
	}

	str[offset] = '\0';

	return str;
}

void remove_whitespace(char *str)
{
	int qt = 0;
	char *pr, *pw;
	bool_t skip;

	pr = pw = str;

	while(*pr != '\0')
	{
		if (*pr == '"')
			qt++;

		skip = !(qt & 1) && isblank(*pr);

		*pw = *pr++;
		pw += !skip;
	}

	*pw = '\0';
}

bool_t is_sep(char c, char* separators)
{
	int i;
	int len = strlen(separators);

	for (i = 0; i < len; i++) {
		if (c == separators[i])
			return TRUE;
	}

	return FALSE;
}

void remove_separators(char *str, char* separators)
{
	char *pr, *pw;
	bool_t skip;

	pr = pw = str;

	while(*pr != '\0') {
		skip = is_sep(*pr, separators) || !isprint(*pr);

		*pw = *pr++;
		pw += !skip;
	}

	*pw = '\0';
}

int main(int argc, char const *argv[])
{
	char *str, **arr;
	size_t file_size;

	int num_entries = 0, num_fields = 0, count = 0;

	if (argc != 3) {
		fprintf(stderr, "usage: ./cvt input output\n");
		exit(EXIT_FAILURE);
	}

	int input_fd = open(argv[1], O_RDONLY);
	DIE(input_fd < 0, "invalid input file");

	int output_fd = open(argv[2], O_RDWR | O_CREAT | O_TRUNC);
	DIE(output_fd < 0, "invalid output file");


	file_size = get_file_size(input_fd);

	str = read_file_into_string(input_fd, file_size);

	/* preprocessing */
	remove_separators(str, "{}[]:,\n");
	remove_whitespace(str);

	arr = malloc((file_size + 1) * sizeof(char*));
	DIE(arr == NULL, "malloc");

	char *p = strtok(str, "\"");
	char *first_field = strdup(p);

	while(p) {
		arr[count++] = strdup(p);

		// this is not right
		if((count & 1) && !strcmp(first_field, p))
			num_entries++;

		p = strtok(NULL, "\"");
	}

	int dist = count / num_entries;
	num_fields = dist / 2;

	int j, k;

	//insert first line / fields names
	for(j = 0; j < num_fields; j++)
		dprintf(output_fd, "%s,", arr[2 * j]);
	dprintf(output_fd, "\n");

	//insert corresponding values
	for(j = 0; j < num_entries; j++) {
		for(k = 0; k < num_fields; k++)
			dprintf(output_fd, "%s,", arr[j * dist + 2 * k + 1]);

		if (j != num_entries - 1)
			dprintf(output_fd, "\n");
	}

	dprintf(output_fd, "\n");

	/* clean-up */
	free(str);

	free_matrix((void**)arr, count);

	free(first_field);

	close(input_fd);
	close(output_fd);

	return 0;
}
