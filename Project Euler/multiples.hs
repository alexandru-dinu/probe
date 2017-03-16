gen x n = if (x < n) then (if (mod x 3 == 0 || mod x 5 == 0) then x:gen (x+1) n else gen (x+1) n) else []

res lim = sum $ gen 3 lim