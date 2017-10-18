% A este matricea extinsa de dimensiune nx(n+1)
% TODO

function [ X ] = gauss(A, n)
X = zeros(1, n);
for i = 1:n
    max = abs(A(i,i));
    maxRow = i;
    
    for k = (i+1):n
        if abs(A(k,i)) > max
            max = A(k,i);
            maxRow = k;
        end
    end
    
    for k = i:n
        tmp = A(maxRow,k);
        A(maxRow,k) = A(i,k);
        A(i,k) = tmp;
    end
    
    for k = (i+1):n
        c = -A(k,i)/A(i,i);
        for j = i:n;
            if i == j
                A(k,j) = 0;
            else
                A(k,j) = A(k,j) + c * A(i,j);
            end
        end
    end
end

disp(A);

for i = n:-1:1
    X(i) = A(i,n+1) / A(i,i);
    
    for k = (i-1):-1:1
        A(k,n+1) = A(k,n+1) - A(k,i) * X(i);
    end
end

end