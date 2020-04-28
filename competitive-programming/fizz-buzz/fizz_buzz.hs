import Data.Bool (bool)

tags :: [(Int, String)]
tags = [(3, "Fizz"), (5, "Buzz"), (7, "Bazz")]

desc :: Int -> String
desc i = concat [label | (q, label) <- tags, mod i q == 0]

fizzBuzz :: Int -> String
fizzBuzz i = bool str (show i) (null str) where str = desc i

example :: [String]
example = map fizzBuzz [1..120]