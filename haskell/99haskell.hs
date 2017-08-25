ins :: (Num a) => Integer -> a -> [a] -> [a]
ins 0 e xs = e:xs
ins p e [] = 0:(ins (p - 1) e [])
ins p e (x:xs) = x:(ins (p - 1) e xs)


primeFactors :: Integer -> [Integer]
primeFactors n = paux n 2 where
		paux 0 _ = []
		paux 1 _ = []
		paux n d
			| (mod n d == 0) = d:(paux (div n d) d)
			| otherwise		 = paux n (d + 1)


isPrime :: Integer -> Bool
isPrime n = length (primeFactors n) == 1

compress :: (Eq a) => [a] -> [(a, Int)]
compress [] = []
compress (x:xs) = let count = length (filter (== x) (x:xs)) in
	(x, count):(compress (filter (/= x) (x:xs)))


primes :: [Integer]
primes = sieve [2,3..] where sieve (h:t) = h:(sieve (filter (\x -> x`mod`h /= 0) t))


goldbach :: Integer -> [(Integer, Integer)]
goldbach x = take 1 [(a, x - a) | a <- primes, isPrime (x - a)]

empty :: (Eq a) => [a] -> Bool
empty xs = xs == []

-- if only it'd be this easy..
proveGoldbach = not $ empty [pair == [] | pair <- map goldbach [4,5..]]
