CPPFLAGS=-Wall -Wextra -g -std=c++17
LIBS=-pthread

.PHONY: clean

%.out: %.o
	g++ $(LIBS) $^ -o $@
%.o: %.cpp
	g++ $(CPPFLAGS) -c $^ -o $@

clean:
	rm -f *.o *.out
