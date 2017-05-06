function [] = wilson( p )
%WILSON Summary of this function goes here
%   Detailed explanation goes here

    q = (factorial(p - 1) + 1) / p^2;
    
    if (q == round(q))
        disp('true');
    else
        disp('false');
    end

end

