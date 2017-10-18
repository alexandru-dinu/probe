bool iseq(string expression) { 
    if(expression[0] == '}' || expression[0] == ']' || expression[0] == ')')
        return false;
          
    stack<char> st;
    int len = expression.length();
    
    st.push(expression[0]);
    
    
    for(int i = 1; i < len; i++) {
        char c = expression[i];
        
        if(!st.empty()) {
            if(c == '}' && st.top() == '{') {
                st.pop();
            }
            else if(c == ']' && st.top() == '[') {
                st.pop();
            }
            else if(c == ')' && st.top() == '(') {
                st.pop();
            }
        }
        
        else {
            if(c == '}' || c == ']' || c == ')')
                return false;
        }
        
        if(c == '{' || c == '[' || c == '(')
            st.push(c);
         
    }
    
    return st.empty();
}