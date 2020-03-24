solve :: [Int] -> Int
solve (k:xs) = sum [1 | (i, x) <- enum xs, (j, y) <- enum xs, i < j, (x+y) `mod` k == 0]
    where enum xs = zipWith (\x y -> (x, y)) [1..length xs] xs

main :: IO()
main = interact $ show . solve . map read . tail . words