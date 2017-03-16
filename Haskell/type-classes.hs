
data Natural = Zero | Succ Natural
data List a = Void | Cons a (List a)
data Tree a = Nil | Node (Tree a) a (Tree a)

-- task 1: we want to display each of the new objects:
showNatural :: Natural -> String
showNatural Zero = "$"
showNatural (Succ x) = "$"++(showNatural x)

{-
showList :: (List a) -> String
showList Void = "{}"
showList (Cons h t) = ":"++(showList t)
-}

{- 
    Problem 1: We already identified one problem. We do not know how to display h, since it may have any type.
    Any solution we may take leads us to a monomorphic list.
-}

-- task 2: we want to fold lists and trees:
foldList :: (a -> b -> b) -> b -> (List a) -> b
foldList op acc Void = acc
foldList op acc (Cons h t) = h `op` (foldList op acc t)

-- when folding a data-structure, we simply take into account a binary operation between
-- an initial value and a value of the data-structure. 
foldTree :: (a -> b -> b) -> b -> (Tree a) -> b
foldTree op acc Nil = acc
foldTree op acc (Node l k r) = 
    let lacc = foldTree op acc l in foldTree op (k `op` lacc) r

-- there is a discussion on this strategy, and other alternatives are possible; this strategy seems to
-- correspond to a DFS traversal of the tree. This discussion is interesting but irrelevant for our situation


-- task 3: we want to map lists and trees:
listMap :: (a -> b) -> List a -> List b
listMap f l = foldList (\h acc->Cons (f h) acc) Void l

-- treeMap :: (a -> b) -> Tree a -> Tree b
-- treeMap f t = 

{- Problem 2: for complex structures like trees, we see that fold breaks down the structure of the tree;
   We have several options here. 
      - change signature of foldTree by replacing op :: (a -> b -> b) by op :: (b -> a -> b -> b)
      - do not use fold to implement treeMap. For now, we take no decision.
-}

--------------------------------------------

-- Fixing task 1 & problem 1

--------------------------------------------

-- We need a mechanism for specifying showable types. We write the following ADT:

data Showable a = SNat Natural | SList (List a) -- actually - (SList (List (Showable a)))

--shou :: (Showable a) -> String
--shou (SNat n) = showNatural n
--shou (SList l) = showLista l

-- to solve problem 1, we modify the signature of showList, by saying that the parametrised type
-- of the list must be itself showable
--showLista :: (List (Showable a)) -> String
--showLista Void = "{}"
--showLista (Cons h t) = (shou h)++":"++(showLista t)

{- to extend this code, i.e. to define a new showable type, the programmer must:
     - add a new data constructor in Showable
     - if the new data is polymorphic, Showable itself must be modified (as in pairs)
     - in the latter case, the programmer must EXPLICITLY PACK values as showables. Example:

     one = Succ Zero
     Cons (SNat one) (Cons SNat Zero Void) 
     instead of:
     Cons one (Cons Zero Void)

     this particular aspect is quite annoying. Haskell provides a built-in alternative, which:
     * preserves the same principle as above
     * is much easier to use
-}

class Shouable a where
    shou :: a -> String

-- a type-class in Haskell models "a set" or a family of types, which share a common trait (common functions).
-- We may view this declaration as "for any type a which belongs to Shouable ", the function "shou :: a -> String"
-- is defined.
-- Note that this declaration does not say which are the members of "Shouable". It is an "empty set"

instance Shouable Natural where
    shou = showNatural

-- membership

instance (Shouable a) => Shouable (List a) where
    shou = showLista
showLista Void = "{}"
showLista (Cons h t) = (shou h)++":"++(showLista t)

-- constrained membership

-- discussion on the type of shou -> the type-class restriction

-- Conclusion: type-classes seem to solve Task 1 together with Problem 1 elegantly.


--------------------------------------------

-- Fixing task 2 

--------------------------------------------

-- Let us use classes to solve task 2.

{- Attempt 1:
class Fold a where 
    fold :: (a -> b -> b) -> b -> [a] -> b
                                   c

but this function is too general, as there is no relationship between a and c.
Our intention is to say that c must be a polymorphic type, parametrized w.r.t. a

   Attempt 2:
class Fold a where 
    fold :: (a -> b -> b) -> b -> T a -> b
                                   
The signature seems ok, however the class definition is not exactly correct, as it does not
contain families of types, but families of type constructors:

-}
class Fold t where 
    fold :: (a -> b -> b) -> b -> t a -> b
-- for now, we leave map aside. What can we do with fold?
    fsum :: (Num a) => t a -> a
    fsum = fold (+) 0

instance Fold List where
    fold op acc Void = acc
    fold op acc (Cons h t) = h `op` (fold op acc t)

-- fsum now comes for free !

instance Fold Tree where
    fold op acc Nil = acc
    fold op acc (Node l k r) = 
        let lacc = fold op acc l in fold op (k `op` lacc) r   

-- again, fsum comes for free !

-- >>>> Solving problem 2: how to implement map in a modular way?
{- Relying on our fold with the same signature doesn't seem to help. However: -}

class Mappable t where
    mmap :: (a->b) -> t a -> t b

instance Mappable List where
    mmap = listMap    

instance Mappable Tree where
    mmap f Nil = Nil
    mmap f (Node l k r) = Node (map f l) (f k) (map f r)

{- A few words about Haskell classes:

   Show: show
   Ord: > , >=, etc.
   Eq: ==
   Num: +  
   Foldable: foldr
   Functor: map (generalization of map)

-}




