function [ c ] = collatzCount( n )
%COLLATZCOUNT Summary of this function goes here
%   Detailed explanation goes here

    if (n == 1)
        c = 0;
        return;
    end

    if (floor(log2(n)) == log2(n))
        c = log2(n);
        return;
    end
    
    if (mod(n, 2) == 0)
        c = 1 + collatzCount(n/2);
    else
        c = 1 + collatzCount(3*n+1);
    end
end

