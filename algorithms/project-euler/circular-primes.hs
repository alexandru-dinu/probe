build :: (a -> a) -> a -> [a]
build next init = init:(build next (next init))

naturals = build (\x -> x + 1) 0

sieve (h:t) = h:(sieve (filter (\x -> (mod x h) /= 0) t))
primes = sieve $ drop 2 naturals

f 0 = []
f n = (mod n 10):f (div n 10)

digs n = reverse $ f n

chk number = all (\d -> if (even d || d == 5) then False else True) $ digs number
