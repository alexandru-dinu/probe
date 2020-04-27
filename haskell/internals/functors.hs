{-# LANGUAGE FlexibleContexts #-}
{-# LANGUAGE FlexibleInstances #-}
{-# LANGUAGE InstanceSigs #-}

-- Applicative functors
import Control.Applicative


-- helpful for understanding partial application
instance Show (a -> b) where
	show f = "<unary_function>"

-- class Functor f where
-- 	fmap :: (a -> b) -> f a -> f b

-- (<$>) :: (Functor f) => (a -> b) -> f a -> f b
-- f <$> x = fmap f x

-- (<&) operator in Functor class ((<$) = fmap . const)
replaceAll :: (Functor f) => a -> f b -> f a
replaceAll value container = fmap (const value) container


-- example 1 - Maybe-like data type
data Something a = None | Valid a deriving Show

instance Functor Something where
	fmap f (Valid x) = Valid (f x)
	fmap f None = None

-- example 2 - Tree
data Tree a = Nil | Leaf a | Node a (Tree a) (Tree a) deriving Show

instance Functor Tree where
	fmap f Nil = Nil
	fmap f (Leaf a) = Leaf (f a)
	fmap f (Node a l r) = Node (f a) (fmap f l) (fmap f r)





-- Applicative functors

-- class (Functor f) => Applicative f where
--     pure :: a -> f a
--     (<*>) :: f (a -> b) -> f a -> f b

-- returns a list containing functions (x * b, for each x in list)
times lst = fmap (*) lst

instance Applicative Something where
	-- pure takes a value and puts it in some sort of default (or pure) context
	pure = Valid

	-- <*> takes a functor that has a function in it and another functor
	None <*> _ = None
	(Valid f) <*> x = fmap f x



-- examples
-- doing k <$> f <*> g creates a function
-- that will call k with the eventual results from f and g

e1 = pure "Hey" :: [String] -- yields ["Hey"]
e2 = pure "Hey" :: Maybe String -- yields Just "Hey"

e3 = Valid (*2) <*> Valid 50 -- yields (Valid 100)
e4 = [(+1), (+2)] <*> [10,12] -- yields [11, 13, 12, 14]
e5 = pure (+) <*> Just 3 <*> Just 5 --  yields Just 8

e6 = (+1) <$> Valid 10 -- yields Valid 11
e7 = Valid (+1) <*> Valid 10 -- yields Valid 11
e8 = (++) <$> Just "hey" <*> Just " you" -- yields Just "hey you"

-- do notation
action :: IO String
action = do
	a <- getLine
	b <- getLine
	return $ a ++ b
-- equivalent expression
action' :: IO String
action' = (++) <$> getLine <*> getLine



-- exercises

-- 1. insert an element into a list
consF :: (Functor f) => t -> f [t] -> f [t]
consF x lst = ((:) x) <$> lst

consA :: (Applicative a) => t -> a [t] -> a [t]
consA x lst = pure ((:) x) <*> lst

-- 2. reverse a list
revF :: (Functor f) => f [t] -> f [t]
revF lst = (foldl (\acc x -> x:acc) []) <$> lst

revA :: (Applicative a) => a [t] -> a [t]
revA lst = pure (foldl (\acc x -> x:acc) []) <*> lst

-- 3. append two lists
appendA :: (Applicative f) => f [t] -> f [t] -> f [t]
appendA l1 l2 = (++) <$> l1 <*> l2


-- zipping lists is done with ZipLists type
e9 = \f l1 l2 -> getZipList $ f <$> ZipList l1 <*> ZipList l2



-- another example of an Applicative instance
-- instance Applicative ((->) r) where
-- 	-- pure :: a -> (r -> a)
-- 	pure x = (\_ -> x)

-- 	-- <*> :: ((->) r) (a -> b) -> ((->) r) a -> ((->) r) b
-- 	-- <*> :: (r -> a -> b) -> (r -> a) -> (r -> b)
-- 	f <*> g = \x -> f x (g x)


-- examples
e10 = (-) <*> (+1) $ 5 -- yields -1 because of (-) 5 ((+1) 5)
e11 = (+) <$> (+3) <*> (*100) $ 5 -- yields 508 (5+3, 5*100 -> 8 + 500)
e12 = (\x y z -> [x,y,z]) <$> (+3) <*> (*2) <*> (/2) $ 5 -- yields [8.0, 10.0, 2.5]


-- liftA2 :: (Applicative f) => (a -> b -> c) -> f a -> f b -> f c
-- liftA2 f a b = f <$> a <*> b


data Choose b a = Good a | Bad b deriving Show

instance Functor (Choose a) where
	-- fmap :: (b -> c) -> Choose a b -> Choose a c
	fmap f (Good x) = Good (f x)
	fmap f (Bad x) = Bad x

instance Applicative (Choose a) where
	pure = Good

	(Bad x) <*> _ = (Bad x)
	(Good f) <*> x = fmap f x



data Pair a = Pair a a

instance (Show a) => Show (Pair a) where
	show (Pair x y) = "(" ++ show x ++ ", " ++ show y ++ ")"

instance Functor Pair where
	fmap f (Pair x y) = Pair (f x) (f y)

instance Applicative Pair where
	pure = \x -> Pair x x
	(Pair f1 f2) <*> (Pair x y) = Pair (f1 x) (f2 y)



-- Is the composition of two Functors also a Functor?

data Compose f g a = Compose { getCompose :: f (g a)} deriving Show

instance (Functor f, Functor g) => Functor (Compose f g) where
	fmap :: (a -> b) -> Compose f g a -> Compose f g b
	-- func :: a -> b
	-- (fmap (fmap func)) :: (Functor f, Functor g) => f (g a) -> f (g b)
	-- Compose :: f (g a) -> Compose f g a
	fmap func (Compose x) = Compose (fmap (fmap func) x)

	-- applying fmap wraps the value into the first context (g)
	-- applying fmap fmap wraps the value into the second context (f)

instance (Applicative f, Applicative g) => Applicative (Compose f g) where
	-- pure :: a -> Compose f g a
	pure = Compose . pure . pure
	Compose fx <*> Compose gx = Compose (liftA2 (<*>) fx gx)



-- Give an example of a type of kind * -> *
-- which cannot be made an instance of Functor (without using undefined).

data F a = F { getFunc :: (a -> Int)} deriving Show

-- if we write "deriving Functor":
-- Can't make a derived instance of ‘Functor F’:
-- Constructor ‘F’ must not use the type variable in a function argument

-- The problem is that the standard Functor class actually represents
-- covariant functors (fmap lifts its argument to f a -> f b),
-- but there is no way you can compose a -> b and a -> Int to get a function of type b -> Int

-- solution: Contravariant Functors
class ContravariantFunctor k where
	contramap :: (a -> b) -> k b -> k a

	(<^$>) :: (ContravariantFunctor k) => (a -> b) -> k b -> k a
	f <^$> x = contramap f x


instance ContravariantFunctor F where
	-- func :: b -> Int
	-- f :: a -> b
	contramap f (F func) = F (func . f)

-- example
e13 = (getFunc $ contramap (*2) (F (\x -> x + 5))) 101 -- yields ((+5) ((*2) 101)) = 207


-- another example
-- we define a data type that abstracts sets (a set is defined by a boolean predicate)
data Set a = Set { getPred :: (a -> Bool)} deriving Show

-- for example, the set of all even numbers is Set even
-- the set of all numbers larger than 1337 is Set (> 1337)

-- membership of a value x in the set can be established by applying the predicate to x
memberOf :: (Set a) -> a -> Bool
memberOf (Set pred) x = pred x

reu :: (Set a) -> (Set a) -> (Set a)
reu (Set p1) (Set p2) = Set (\x -> (||) (p1 x) (p2 x)) 

inter :: (Set a) -> (Set a) -> (Set a)
inter (Set p1) (Set p2) = Set (\x -> (&&) (p1 x) (p2 x))

-- we notice that Set a is similar to F a, so it can't derive Functor class
-- we must make an instance of a ContravariantFunctor

instance ContravariantFunctor Set where
	contramap :: (a -> b) -> Set b -> Set a
	contramap f (Set pred) = Set (pred . f)

-- now, based on this instance, we can create a new Set that alters the input in some way (applying f) 
-- before calling the original Set's predicate

-- we can construct Set even like this: contramap (+1) (Set even)
-- the set of all natural numbers: reu (Set even) ((+1) <^$> (Set even))


