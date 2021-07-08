.PHONY: clean

%.out: %.hs
	ghc -dynamic $^ -o $@

clean:
	rm -rfv *.hi *.o *.out
