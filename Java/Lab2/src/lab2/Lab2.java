/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab2;


/**
 *
 * @author alex
 */
public class Lab2 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        /*
        MyArrayList v = new MyArrayList(2);
        
        System.out.println(v.tostring());
        
        Random r = new Random();
        
        for (int i = 0; i < 10; i++) {
            v.add(r.nextFloat());
        }
        
         System.out.println(v.tostring());
        
        for (int i = 0; i < 5; i++) {
            int x = r.nextInt(v.dim);
            
            v.remove(x);
        }
        
        System.out.println(v.tostring());
        
        Test t = new Test();
        System.out.println(t.check());
        */
        
        /*
        Singleton.getInstance(); // outputs 'Hello, world!'
        Singleton.getInstance(); // doesn't output anything
        */
        
        /*
        Profesor prof = new Profesor("POO");
        prof.name = "Mihai";
        
        Student stud = new Student(10);
        stud.name = "Alex";
        
        Student stud_copy = new Student(10);
        stud.name = "Alex";
        
        System.out.println(stud.equals(stud_copy));
        
        System.out.println(prof.toString());
        System.out.println(stud.toString());
        */
        
        /*
        Persoana[] pers = new Persoana[2];
        
        pers[0] = new Profesor("Mihai", "POO");
        pers[1] = new Student("Alex", 10);
        
        // se apeleaza metoda toString corespunzatoare clasei aferente
        for(Persoana p : pers) {
            System.out.println(p.toString());
            
            // downcasting
            if(p instanceof Profesor) {
                ((Profesor)p).preda();
            }
            
            if(p instanceof Student) {
                ((Student)p).invata();
            }
        }
        */
    }
    
}
