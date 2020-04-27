CPPFLAGS=-Wall -Wextra -g -std=c++11
LIBS=

.PHONY: clean

main.out: main.o tags.o
	g++ $(LIBS) $^ -o $@
%.o: %.cpp
	g++ $(CPPFLAGS) -c $^ -o $@

clean:
	rm -f *.o *.out