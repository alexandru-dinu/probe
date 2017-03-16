import java.util.*;

/**
 * Created by Alex on 17/12/2015.
 */
public class Dictionary {

    TreeMap<String, ArrayList<String>> map = new TreeMap();

    public Dictionary() {
        map.put("mama", new ArrayList<>(Arrays.asList("mother", "maman")));
        map.put("tata", new ArrayList<>(Arrays.asList("father", "pere")));
        map.put("frate", new ArrayList<>(Arrays.asList("brother", "frere")));
        map.put("sora", new ArrayList<>(Arrays.asList("sister", "soeur")));

    }

    public String translateEnglishWord(String s) {
        Set set = map.entrySet();
        Iterator i = set.iterator();

        while (i.hasNext()) {
            Map.Entry mapEntry = (Map.Entry) i.next();

            if (mapEntry.getKey().equals(s)) {
                Object o = mapEntry.getValue();
                ArrayList<String> l = (ArrayList<String>) o;
                return l.get(0);
            }
        }

        return "DNE";
    }

    public String translateFrenchWord(String s) {
        Set set = map.entrySet();
        Iterator i = set.iterator();

        while (i.hasNext()) {
            Map.Entry M = (Map.Entry) i.next();

            if (M.getKey().equals(s)) {
                Object o = M.getValue();
                ArrayList<String> l = (ArrayList<String>) o;
                return l.get(1);
            }
        }
        return "DNE";
    }

    public String translateEnglishSentence(String sentence) {
        String translated = "";
        String[] words = sentence.split("[\\s]");

        for (String w : words) {
            translated += translateEnglishWord(w) + " ";
        }

        return translated;
    }

    public String translateFrenchSentence(String sentence) {
        String translated = "";
        String[] words = sentence.split("[\\s]");

        for (String w : words) {
            translated += translateFrenchWord(w) + " ";
        }

        return translated;
    }

}
