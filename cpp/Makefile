CPPFLAGS=-Wall -Wextra -g -std=c++17
LIBS=-pthread

.PHONY: clean

%.out: %.o
	g++ $(LIBS) $^ -o $@
%.o: %.cpp
	g++ $(CPPFLAGS) -c $^ -o $@
clean:
	find . -exec file {} \; | grep -i elf | cut -d":" -f1 | tee /dev/tty | xargs --no-run-if-empty rm
