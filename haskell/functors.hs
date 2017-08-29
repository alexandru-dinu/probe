{-# LANGUAGE FlexibleContexts #-}
{-# LANGUAGE FlexibleInstances #-}

-- Applicative functors
import Control.Applicative

-- fmap :: (a -> b) -> f a -> f b

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


-- (fmap (binary_op :: a -> b) collection) means
-- for each x in collection, a function x -> b is returned,
-- as a member of that collection

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


-- (<$>) :: (Functor f) => (a -> b) -> f a -> f b
-- f <$> x = fmap f x

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
