import Data.Maybe (fromMaybe)
import Data.List (sort)

binarySearch :: Ord a => [a] -> a -> Maybe Int
binarySearch [] _ = Nothing
binarySearch [x] y = if x == y then Just 0 else Nothing
binarySearch xs x
    | x == midval = Just mid
    | x < midval = binarySearch (take mid xs) x
    | otherwise = (+) <$> Just mid <*> binarySearch (drop mid xs) x
    where
        mid = div (length xs) 2
        midval = xs !! mid

exists :: Ord a => [a] -> a -> Bool
exists xs x = binarySearch xs x /= Nothing

indexOf :: Ord a => [a] -> a -> Int
indexOf xs x = fromMaybe (-1) $ binarySearch (sort xs) x