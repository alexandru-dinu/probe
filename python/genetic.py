from functools import reduce
import random
from operator import itemgetter
import numpy as np

alphabet = [chr(i) for i in range(48, 123)]




def fitness(password, guess):
	if len(password) != len(guess):
		return

	z = zip(password, guess)
	guessed = reduce(lambda acc, el : 1+acc if el[0] == el[1] else acc, z, 0)

	return guessed * 100.0 / len(password)


def gen_word(length):
	word = ''.join(random.choice(alphabet) for x in range(length))

	return word


def gen_population(size, length):
	population = [gen_word(length) for _ in range(size)]

	return population


def population_sorted(population, password):
	good = {p : fitness(password, p) for p in population}

	return sorted(good.items(), key=itemgetter(1), reverse=True)


def select_from_population(population, best, lucky):
	best_next = [population[i][0] for i in range(best)]
	lucky_next = [random.choice(population)[0] for i in range(lucky)]

	next_gen = best_next + lucky_next
	random.shuffle(next_gen)

	return next_gen


def create_child(i1, i2):
	inds = [i1, i2]

	child = "".join([inds[random.randint(0,1)][i] for i in range(len(i1))])

	return child


def create_children(breeders, num):
	b = len(breeders)

	next_pop = [
		create_child(breeders[i], breeders[b-1-i]) for _ in range(num) for i in range(b//2)
	]

	return next_pop


def mutate_word(word):
	index = random.randint(0, len(word) - 1)
	r = random.choice(alphabet)

	new_word = word[:index] + r + word[index+1:]

	return new_word


def mutate_population(population, chance):
	for i in range(len(population)):
		r = random.random() * 100
		if r < chance:
			population[i] = mutate_word(population[i])


	return population


def next_generation(first_gen, password, best, lucky, num, chance):
	pop_sorted = population_sorted(first_gen, password)
	next_breeders = select_from_population(pop_sorted, best, lucky)
	next_pop = create_children(next_breeders, num)
	next_gen = mutate_population(next_pop, chance)

	return next_gen



def main():
	password = "S0m3R4ndOmS7r1nG"
	pop_size = 100
	best = 20
	lucky = 10
	num = 5
	chance = 50

	first_gen = gen_population(pop_size, len(password))

	idx = 1

	while True:
		ng = next_generation(first_gen, password, best, lucky, num, chance)
		idx += 1
		if password in ng:
			index = ng.index(password)
			print("FOUND @ pop {}, index {}".format(idx, index))

			for (i, p) in enumerate(ng):
				print(i, "\t", p)

			return
		else:
			first_gen = ng



if __name__ == '__main__':
	main()
