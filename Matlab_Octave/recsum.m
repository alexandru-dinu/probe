function [ sn ] = recsum( poly, n )
%RECSUM Summary of this function goes here
%   Detailed explanation goes here
    S = -poly(2)/poly(1);
    P = poly(3)/poly(1);
    
    s(1) = S;
    s(2) = S^2 - 2*P;
    
    for i = 3:n
        s(i) = S * s(i-1) - P * s(i-2);
    end
    
    sn = s(end);
end

