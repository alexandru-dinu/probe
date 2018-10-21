import System.Environment (getArgs)

main :: IO ()
main = getArgs >>= (\a -> readFile $ head a) >>= putStrLn