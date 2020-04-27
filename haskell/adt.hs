data T t = A | B Integer | C String t deriving Show


data Tree a = Null | Leaf a | Node a (Tree a) (Tree a)


data UnaryFunction x y = UnaryFunction (x -> y)

instance (Show x, Show y) => Show (UnaryFunction x y) where
    show f = "Function {x -> y}"

-- f1 == f2 <=> f1(2) == f2(2)
instance (Num x, Num y, Eq y) => Eq (UnaryFunction x y) where
    (==) (UnaryFunction f1) (UnaryFunction f2) = f1 2 == f2 2


data MBool = MTrue | MFalse

class Bop a where
	-- minimal sufficient implementation
	not' :: a -> a
	equ' :: a -> a -> a
	and' :: a -> a -> a

	or'  :: a -> a -> a
	or' x y = not' (and' (not' x) (not' y))

	nand' :: a -> a -> a
	nand' x y = not' (and' x y)

	nor' :: a -> a -> a
	nor' x y = not' (or' x y)

	xor' :: a -> a -> a
	xor' x y = or' (and' (not' x) y) (and' x (not' y))

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

table f = [[p, q, f p q] | p <- [MTrue, MFalse], q <- [MTrue, MFalse]]



-- sets described by a predicate function
data Set a = Set (a -> Bool)

member :: a -> Set a -> Bool
member x (Set f) = f x

union :: Set a -> Set a -> Set a
union (Set f1) (Set f2) = Set (\x -> f1 x || f2 x)

intersection :: Set a -> Set a -> Set a
intersection (Set f1) (Set f2) = Set (\x -> f1 x && f2 x)

difference :: Set a -> Set a -> Set a
difference (Set f1) (Set f2) = Set (\x -> f1 x && not (f2 x))
