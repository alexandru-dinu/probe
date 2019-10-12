module Graph  where

import Data.Bool (bool)

type Node  = String
type Cost  = Double
data Edge  = Edge { from :: Node, to :: Node, cost :: Cost }
type Graph = [Edge]

instance Show Edge where
    show (Edge n1 n2 c) = "(" ++ n1 ++ "->" ++ n2 ++ ", " ++ (show c) ++ ")"

parseLine :: String -> Edge
parseLine s = let [n1, n2, c] = words s in Edge n1 n2 (read c :: Double)

parseGraph :: String -> Graph
parseGraph text = map parseLine $ lines text

-- | graph utils

neighboursOf :: Node -> Graph -> [Node]
neighboursOf n g = foldr (\x a -> bool a ((to x):a) (from x == n)) [] g

nextEdgesFrom :: Node -> Graph -> [Edge]
nextEdgesFrom n g = filter (\x -> from x == n) g

-- | test data

g = parseGraph "a b 1\nb c 2\na c 1.5"

-- | algorithm

-- dijkstra from to graph -> shortest path
dijkstra :: Node -> Node -> Graph -> [Edge]
dijkstra = undefined
