enumerate :: [a] -> [(Int, a)]
enumerate xs = zip [1..length xs] xs

solve :: [Int] -> Int
solve (k:xs) = sum [1 | (i, x) <- enumerate xs,
                        (j, y) <- enumerate xs,
                        i < j, (x+y) `mod` k == 0]

main :: IO()
main = interact $ show . solve . map read . tail . words