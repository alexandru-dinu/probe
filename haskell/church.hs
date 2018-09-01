data B = T | F deriving Show

tru = \x -> \y -> x
fls = \x -> \y -> y

eval = \p -> p T F
enc True    = tru
enc False   = fls

gt x y  = enc $ (>) x y
lte x y = no $ gt x y 

both    = \p -> \q -> p q fls
just    = \p -> \q -> p tru q
no      = \p -> p fls tru
xor     = \p -> \q -> p (no q) q 
ifte    = \c -> \t -> \f -> c t f