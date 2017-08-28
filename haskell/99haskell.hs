{-# LANGUAGE MultiParamTypeClasses #-}
{-# LANGUAGE FlexibleInstances #-}
{-# LANGUAGE FlexibleContexts #-}
{-# LANGUAGE ScopedTypeVariables #-}


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


empty :: (Eq a) => [a] -> Bool
empty xs = xs == []


primes :: [Integer]
primes = sieve [2,3..] where sieve (h:t) = h:(sieve (filter (\x -> x`mod`h /= 0) t))


goldbach :: Integer -> [(Integer, Integer)]
goldbach x = take 1 [(a, x - a) | a <- primes, isPrime (x - a)]

-- if only it'd be this easy..
proveGoldbach :: Bool
proveGoldbach = not $ empty [pair == [] | pair <- map goldbach [4,5..]]


flatten :: [[a]] -> [a]
flatten [] = []
flatten (l:ls) = l ++ flatten ls


data MBool = MTrue | MFalse

class Bop a where
	-- minimal sufficient implementation
	not' :: a -> a
	equ' :: a -> a -> a
	and' :: a -> a -> a

	or'  :: a -> a -> a
	or' = (\x y -> not' $ (and' (not' x) (not' y)))

	nand' :: a -> a -> a
	nand' = (\x y -> not' $ (and' x y))

	nor' :: a -> a -> a
	nor' = (\x y -> not' $ (or' x y))

	xor' :: a -> a -> a
	xor' = (\x y -> or' (and' (not' x) y) (and' x (not' y)))


instance Bop MBool where
	not' MTrue = MFalse
	not' MFalse = MTrue

	equ' MTrue MTrue = MTrue
	equ' MFalse MFalse = MTrue
	equ' _ _ = MFalse

	and' MTrue MTrue = MTrue
	and' _ _ = MFalse

instance Show MBool where
	show MTrue = "True"
	show MFalse = "False"


table = \f -> [[p, q, f p q] | p <- [MTrue, MFalse], q <- [MTrue, MFalse]]
