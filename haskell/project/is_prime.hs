isqrt :: Integer -> Integer
isqrt = ceiling . sqrt . fromIntegral

isPrime :: Integer -> Bool
isPrime n = case (mod n 2) of
  0 -> (n == 2)
  otherwise -> null [x | x <- [2..isqrt (abs n)], mod n x == 0]

main :: IO()
main = do
    n <- getLine
    putStrLn $ show $ isPrime (read n :: Integer)