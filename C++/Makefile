CPPFLAGS=-g -std=c++11 
LIBS=-pthread

.PHONY: clean

%.out: %.o
	g++ $(LIBS) $^ -o $@
%.o: %.cpp
	g++ $(CPPFLAGS) -c $^ -o $@

clean:
	rm -f *.o *.out
