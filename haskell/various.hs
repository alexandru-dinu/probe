data Set a = Set (a -> Bool)

member :: (Set a) -> a -> Bool
member (Set f) x = f x


reunion :: (Set a) -> (Set a) -> (Set a)
reunion (Set f1) (Set f2) = Set (\x -> f1 x || f2 x)

intersection :: (Set a) -> (Set a) -> (Set a)
intersection (Set f1) (Set f2) = Set (\x -> f1 x && f2 x)

difference :: (Set a) -> (Set a) -> (Set a)
difference (Set f1) (Set f2) = Set (\x -> f1 x && not (f2 x))


primes = sieve [2,3..] where sieve (h:t) = h:(filter (\x -> mod x h /= 0) (sieve t))

isprime' x i = let p = primes !! i in
                if p > x then False else 
                    if p == x then True
                        else isprime' x (i+1)

isprime x = isprime' x 0

data UnaryFunction x y = UnaryFunction (x -> y)

-- placeholder
instance (Num x, Num y, Eq y) => Eq (UnaryFunction x y) where
    (==) (UnaryFunction f1) (UnaryFunction f2) = f1 2 == f2 2
