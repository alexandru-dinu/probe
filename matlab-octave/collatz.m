function [ c ] = collatz( values )
    len = length(values);
    c = zeros(1, len);
    
    for i = 1:len
        c(i) = collatzCount(values(i));
    end
    
    scatter(values, c, 'x');
    grid on;
end

