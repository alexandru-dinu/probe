--	tail-recursive fibonacci
f _ v 1 = v
f a b n = f b (a+b) (n-1)

trfib n = f 0 1 n

--	infinite-list fibonacci
inffib = 1:1:zipWith (+) inffib (tail inffib)
res up = sum $ filter even $ foldr (\e l -> if (e < up) then e:l else []) [] inffib