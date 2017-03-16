function [ M ] = mersenne( n )
%MERSENNE Summary of this function goes here
%   Detailed explanation goes here

    M = zeros(1, n);
    k = 1;
    i = 1;
    
    while n > 0
        if (isprime(2^k-1) == 1)
            M(i) = 2^k - 1;
            i = i + 1;
            n = n - 1;
        end
        
        k = k + 1;
        
    end

end

