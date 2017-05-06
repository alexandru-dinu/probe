function [ p ] = clsappn(f, a, b, grade)
%CLSAPP Canonic least squares approximation
%p = c_i * u_i = polynomial / canonic base

    % no. of terms
    n = grade + 1;
    steps = 2*n - 1;
    % base scalar products
    sp = zeros(steps, 1);
    % function scalar products
    Fsp = zeros(n, 1);
    % array of sp
    A = []; 
    % array of Fsp
    B = []; 
    
    %   compute scalar products
    for i = 1:steps
        sp(i) = (1/i) * (b^i - a^i);
    end
    
    %   compute function scalar products
    for i = 1:n
        Fsp(i) = integral(@(x)x.^(i-1).*f(x), a, b);
    end
    
    %   fill arrays
    for i = 1:n
        temp = zeros(1, n);
        for j = 1:n
            temp(j) = sp(i+j-1);
        end
        
        A = [A ; temp];
        B = [B ; Fsp(i)];
    end

    %   compute coefficients
    C = A\B;
    %   return the polynomial
    p = fliplr(C');
end

