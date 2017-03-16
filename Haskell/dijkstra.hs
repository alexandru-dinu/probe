type Node = Integer
type Cost = Integer
type Edge = ((Node, Node), Cost)
type Nodes = [Node]
type Edges = [Edge]

type Graph = (Nodes, Edges)

g = ([1,2,3], [((1, 2), 2), ((2, 3), 3), ((1, 3), 7)])

getNodes :: Graph -> Nodes
getNodes g = fst g

getEdges :: Graph -> Edges
getEdges g = snd g

existsEdge :: Node -> Node -> Graph -> Bool
existsEdge src dst graph = let aux = foldr (\x y -> (fst x):y) [] (getEdges graph) 
						   in elem (src, dst) aux

--	TODO
dijkstra :: Node -> Node -> Edges
dijkstra src dst = [] 	