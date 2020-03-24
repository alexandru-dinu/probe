type Point = (Double, Double)
type Points = [Point]

merge :: [a] -> [a] -> [a] -> [(a,a,a)]
merge [] [] [] = []
merge (x:xs) (y:ys) (z:zs) = (x,y,z):(merge xs ys zs)

get :: [Double] -> Points
get [] = []
get (x:y:rest) = (x,y):(get rest)

dist :: Point -> Point -> Double
dist (x1, y1) (x2, y2) = sqrt ((x1-x2) ** 2 + (y1-y2) ** 2)

area :: (Point, Point, Point) -> Double
area (p1, p2, p3) = sqrt (s * (s - a) * (s - b) * (s - c))
    where
        s = 0.5 * (a + b + c)
        a = dist p1 p2
        b = dist p2 p3
        c = dist p3 p1

solve :: Points -> Double
solve ps = sum $ map area $ merge a b c
    where
        a = replicate (length ps - 2) (head ps)
        b = (tail . init) ps
        c = drop 2 ps

main :: IO()
main = interact $ show . solve . get . map read . concat . map words . tail . lines