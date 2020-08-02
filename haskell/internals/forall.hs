{-# LANGUAGE RankNTypes #-}
{-# LANGUAGE GADTs #-}

-- we cannot have heterogeneous lists by default:
-- xs = ["test", 3.14, True]

-- but we can define an ADT which wraps over any Showable value:
data ShowBox = forall s. Show s => SB s

instance Show ShowBox where
    show (SB s) = show s

xs :: [ShowBox]
xs = [SB "test", SB 3.14, SB True]

main = (putStrLn . show) xs

