module Randomness where


import System.Random (randomRIO)
import Data.Functor
import Control.Monad


uniform :: (Float, Float) -> IO Float
uniform (lo, hi) = randomRIO (lo, hi)

-- (<&>) :: Functor f => f a -> (a -> b) -> f b
bernoulli :: Float -> IO Int
bernoulli p = (uniform (0, 1) <&> (<= p)) <&> fromEnum

gen :: Int -> Float -> IO [Int]
gen n p = replicateM n (bernoulli p)
-- replicateM is sequence . replicate n


