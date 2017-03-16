lucas 1 = 1
lucas 2 = 3
lucas n = let 
			f a b n = if (n == 0) then b  else f b (a+b) (n-1)
			in f 1 3 (n-2)

gen n = map lucas [1..n]

prime x = let p = (last (gen x)) - 1 in isInt $ (p / x)

isInt x = x == fromInteger (round x)
