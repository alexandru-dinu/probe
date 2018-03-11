CC=gcc
FLAGS=-Wall -g

build: converter

converter.o: converter.c utils.h
	$(CC) $(FLAGS) -c $< -o $@

converter: converter.c
	$(CC) $(FLAGS) $^ -o $@

clean:
	rm -r converter
