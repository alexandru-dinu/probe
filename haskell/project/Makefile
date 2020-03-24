.PHONY: clean

all: is_prime.out

%.out: %.hs
	ghc -dynamic $^ -o $@

clean:
	rm -rfv *.hi *.o *.out
