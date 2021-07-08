{-# LANGUAGE FlexibleContexts #-}
{-# LANGUAGE FlexibleInstances #-}
{-# LANGUAGE InstanceSigs #-}

import Data.Monoid
import qualified Data.Foldable as F

-- types with an associative binary operation that has an identity
-- A monoid is when you have an associative binary function and
-- a value which acts as an identity with respect to that function.

-- class Monoid m where
--     mempty :: m
--     mappend :: m -> m -> m
--     mconcat :: [m] -> m
--     mconcat = foldr mappend mempty
-- (<>): infix synonym for mappend

-- instance Monoid Ordering where
--     mempty = EQ
--     mappend LT _ = LT
--     mappend EQ x = x
--     mappend GT _ = GT


-- newtype Any = Any { getAny :: Bool}
--     deriving (Eq, Ord, Read, Show, Bounded)

-- newtype All = All { getAll :: Bool}
--     deriving (Eq, Ord, Read, Show, Bounded)


-- instance Monoid Any where
--     mempty = Any False
--     mappend (Any x) (Any y) = Any (x || y)

-- instance Monoid All where
--     mempty = All True
--     mappend (All x) (All y) = All (x && y)




-- Ordering Monoid is particularly useful for "appending" sorting criteria
-- most important -> least important
compareStrings :: String -> String -> Ordering
compareStrings s1 s2 = (length s1 `compare` length s2) <>
                       (vowels s1 `compare` vowels s2) <>
                       (s1 `compare` s2)
                    where vowels = length . filter (`elem` "aeiou")




-- Maybe, the Monoid
-- this comes in use when dealing with monoids as results of computations that may have failed.

-- instance (Monoid m) => Monoid (Maybe m) where
--     mempty = Nothing
--     Nothing `mappend` m = m
--     m `mappend` Nothing = m
--     Just m1 `mappend` Just m2 = Just (m1 `mappend` m2)


-- what if the type of the contents of the Maybe aren't an instance of Monoid?
-- First is useful when we have a bunch of Maybe values and we just want to know if any of them is a Just
-- newtype First a = First { getFirst :: Maybe a }
--     deriving (Eq, Ord, Read, Show)

-- instance Monoid (First a) where
--     mempty = First Nothing
--     First (Just x) `mappend` _ = First (Just x)
--     First Nothing `mappend` x = x

-- newtype Last a = Last { getLast :: Maybe a }
--     deriving (Eq, Ord, Read, Show)

-- instance Monoid (Last a) where
--     mempty = Last Nothing
--     Last Nothing `mappend` x = x
--     Last (Just x) `mappend` Last Nothing = Last (Just x)
--     Last (Just x) `mappend` Last (Just y) = Last (Just y)


e1 = getFirst . mconcat . map First $ [Nothing, Nothing, Just 10, Nothing] -- yields Just 10
e2 = getLast . mconcat . map Last $ [Nothing, Just 10, Nothing, Just 11, Nothing, Nothing] -- yields Just 11



-- One of the more interesting ways to put monoids to work
-- is to make them help us define folds over various data structures

data Tree a = Nil | Node a (Tree a) (Tree a)
    deriving (Show, Eq, Read)

testTree = Node 5
            (Node 3
                (Node 1 Nil Nil)
                (Node 6 Nil Nil)
            )
            (Node 9
                (Node 8 Nil Nil)
                (Node 10 Nil Nil)
            )

-- reduce the tree down to one single monoid value
instance F.Foldable Tree where
    -- foldMap :: (Monoid m, Foldable t) => (a -> m) -> t a -> m
    foldMap f Nil = mempty
    foldMap f (Node x l r) = F.foldMap f l <> f x <> F.foldMap f r


-- TODO
-- The monoid of endomorphisms under composition.
-- newtype Endo a = Endo { appEndo :: a -> a } deriving (Generic)
-- foldr f z t = appEndo (foldMap (Endo . f) t ) z
-- foldl f z t = appEndo (getDual (foldMap (Dual . Endo . flip f) t)) z


-- because Any and All are Monoid values,
-- we can use foldMap to extract info from our data structure
e3 = foldMap (\x -> Any $ x == 10) testTree
e4 = foldMap (\x -> All $ x > 0) testTree