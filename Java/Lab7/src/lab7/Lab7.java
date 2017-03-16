/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab7;

import java.io.*;

/**
 *
 * @author Alex
 */
public class Lab7 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here

        /*
        if (args.length == 1 || args[0].length() == 1) {
            char c = args[0].charAt(0);
            int count = 0;

            FileInputStream FIS = null;
            BufferedReader reader = null;

            String[] words;
            int wordsCount = 0;

            try {
                FIS = new FileInputStream("in.txt");
                reader = new BufferedReader(new InputStreamReader(FIS));
                String line = null;

                while ((line = reader.readLine()) != null) {
                    for (int i = 0; i < line.length(); i++) {
                        if (line.charAt(i) == c) {
                            count++;
                        }
                    }
                    words = line.trim().split(" ");
                    wordsCount += words.length;
                }

                System.out.println("count = " + count);
                System.out.println("words = " + wordsCount);
            } catch (IOException e) {
                e.printStackTrace();
                System.out.println("file error");
            } finally {
                if (FIS != null) {
                    try {
                        FIS.close();
                    } catch (IOException e) {
                        System.out.println("file close error");
                    }
                }
            }
        } else {
            System.out.println("args error!");
            System.exit(-1);
        }
         */
 /*
        if (args[0].equals("java") && args[1].equals("grep")) {
            String fileName = args[2];
            String search = args[3];
            int lineNo = 1;

            String[] words;

            FileInputStream FIS = null;
            BufferedReader reader = null;

            try {
                FIS = new FileInputStream(fileName);
                reader = new BufferedReader(new InputStreamReader(FIS));
                String line = null;

                while ((line = reader.readLine()) != null) {
                    words = line.trim().split(" ");
                    for (String w : words) {
                        if (w.equals(search)) {
                            System.out.println(lineNo + ": " + line);
                            break;
                        }
                    }
                    lineNo++;
                }
            } catch (IOException e) {
                System.out.println("file error");
            } finally {
                if (FIS != null) {
                    try {
                        FIS.close();
                    } catch (IOException e) {
                        System.out.println("file close error");
                    }
                }
            }
        } else {
            System.out.println("args error!");
            System.exit(-1);
        }
         */
 /*
        InputStream in = null;
        OutputStream out = null;
        byte[] buffer = new byte[100];

        try {
            in = new FileInputStream("in.txt");
            out = new FileOutputStream("out.txt");

            in.read(buffer);

            for (byte b : buffer) {
                b++;
                out.write(b);
            }
        } catch (IOException e) {
            System.out.println("file error");
        } finally {
            if (in != null) {
                try {
                    in.close();
                } catch (IOException e) {
                    System.out.println("file close error");
                }
            }
        }
         */
        CircularList clS = new CircularList(5);
        CircularList clD;

        // Serializare
        ObjectOutputStream os = null;

        try {
            os = new ObjectOutputStream(new FileOutputStream("out.bin"));
            os.writeObject(clS);
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            if (os != null) {
                try {
                    os.close();
                } catch (IOException e) {
                }
            }
        }

        // Deserializare
        ObjectInputStream is = null;

        try {
            is = new ObjectInputStream(new FileInputStream("out.bin"));
            clD = (CircularList) is.readObject();
            System.out.println("Deserialized: " + clD);
        } catch (IOException e) {
            e.printStackTrace();
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        } finally {
            if (is != null) {
                try {
                    is.close();
                } catch (IOException e) {
                }
            }
        }
    }
}
