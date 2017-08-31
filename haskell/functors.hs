{-# LANGUAGE FlexibleContexts #-}
{-# LANGUAGE FlexibleInstances #-}
{-# LANGUAGE InstanceSigs #-}

-- Applicative functors
import Control.Applicative

instance Show (a -> b) where
	show f = "unary_function"

-- fmap :: (a -> b) -> f a -> f b
-- class Functor f where
-- 	fmap :: (a -> b) -> f a -> f b

-- (<$>) :: (Functor f) => (a -> b) -> f a -> f b
-- f <$> x = fmap f x

data Something a = None | Valid a deriving Show

instance Functor Something where
	fmap f (Valid x) = Valid (f x)
	fmap f None = None


data Tree a = Nil | Leaf a | Node a (Tree a) (Tree a) deriving Show

instance Functor Tree where
	fmap f Nil = Nil
	fmap f (Leaf a) = Leaf (f a)
	fmap f (Node a l r) = Node (f a) (fmap f l) (fmap f r)


-- (<&) operator in Functor class ((<$) = fmap . const)
replaceAll :: (Functor f) => a -> f b -> f a
replaceAll value container = fmap (const value) container




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

-- pure "Hey" :: [String] yields ["Hey"]
-- pure "Hey" :: Maybe String yields Just "Hey"

--	Valid (*2) <*> Valid 50 yields (Valid 100)
-- [(+1), (+2)] <*> [10,12] yields [11, 13, 12, 14]
-- pure (+) <*> Just 3 <*> Just 5 yields Just 8

-- (+1) <$> Valid 10 yields Valid 11
-- Valid (+1) <*> Valid 10 yields Valid 11
-- (++) <$> Just "hey" <*> Just " you" yields Just "hey you"

-- instance Applicative [] where
--     pure x = [x]
--     fs <*> xs = [f x | f <- fs, x <- xs]

-- (*) <$> [2,3] <*> [1,2,3] yields [2,4,6,3,6,9]


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
-- getZipList $ f <$> ZipList l1 <*> ZipList l2

-- another example of an Applicative instance
-- instance Applicative ((->) r) where
-- 	-- pure :: a -> (r -> a)
-- 	pure x = (\_ -> x)

-- 	-- <*p> :: ((->) r) (a -> b) -> ((->) r) a -> ((->) r) b
-- 	f <*> g = \x -> f x (g x)


-- doing k <$> f <*> g creates a function that will call k with the eventual results from f and g

-- example
-- (+) <$> (+3) <*> (*100) $ 5 yields 508 (5+3, 5*100 -> 8 + 500)
-- (\x y z -> [x,y,z]) <$> (+3) <*> (*2) <*> (/2) $ 5 yields [8.0, 10.0, 2.5]



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

instance (Applicative f, Applicative g) => Applicative (Compose f g) where
	-- pure :: a -> Compose f g a
	pure = Compose . pure . pure

	Compose fx <*> Compose gx = Compose ((<*>) <$> fx <*> gx)


-- Give an example of a type of kind * -> *
-- which cannot be made an instance of Functor (without using undefined).
