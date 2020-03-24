f x y = x - y

instance Show (a->b) where
    show f = "Function!"

high f = f 5

dif x y = x - y

swap bin = \x y -> y `bin` x

lr = foldr f 0 (filter (\x -> if x >= 0 then True else False) (map (\x -> 2 * x) [1, 2, (-3)]))

f1 [] = []
f1 l = (head (reverse l)):[]

f2 [] = []
f2 l = (head (drop 1 (reverse l))):[]

f3 k [] = []
f3 k l = (head (drop (k-1) l)):[]

sz [] = 0
sz (_:l) = 1 + sz l

a = \x y z -> x + y + z
b = \x -> \y -> x + y

eq a b = a == b

l = [1, 2, 3]

l3 = zipWith eq l (reverse l)

getmax l = foldr (\x y -> if x > y then x else y) 0 l

mymax a b = if a > b then a else b
