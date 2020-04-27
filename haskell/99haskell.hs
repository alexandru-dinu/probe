ins :: (Num a) => Integer -> a -> [a] -> [a]
ins 0 e xs = e:xs
ins p e [] = 0 : ins (p - 1) e []
ins p e (x:xs) = x : ins (p - 1) e xs


compress :: (Eq a) => [a] -> [(a, Int)]
compress [] = []
compress (x:xs) = let count = length (filter (== x) (x:xs)) in
	(x, count) : compress (filter (/= x) (x:xs))


primes :: [Integer]
primes = sieve [2,3..] where sieve (h:t) = h : sieve (filter (\x -> x`mod`h /= 0) t)


primeFactors :: Integer -> [Integer]
primeFactors n = paux n 2 where
		paux 0 _ = []
		paux 1 _ = []
		paux n d
			| mod n d == 0 = d : paux (div n d) d
			| otherwise		 = paux n (d + 1)


isPrime :: Integer -> Bool
isPrime n = length (primeFactors n) == 1


isPrime2 :: Integer -> Bool
isPrime2 x = isPrime' x 0
	where
		isPrime' :: Integer -> Int -> Bool
		isPrime' x i = case compare (primes !! i) x of
			GT -> False
			EQ -> True
			LT -> isPrime' x (i + 1)


lucas :: [Integer]
lucas = map lucas' [1..]
	where
		lucas' :: Integer -> Integer
		lucas' 1 = 1
		lucas' 2 = 3
		lucas' n = f 1 3 (n-2)
			where f a b n = if n == 0 then b  else f b (a+b) (n-1)


isPrime3 :: Integer -> Bool
isPrime3 x = mod p x == 0 where p = last (take (fromIntegral x) lucas) - 1


goldbach :: Integer -> [(Integer, Integer)]
goldbach x = take 1 [(a, x - a) | a <- primes, isPrime (x - a)]