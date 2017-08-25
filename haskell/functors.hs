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
