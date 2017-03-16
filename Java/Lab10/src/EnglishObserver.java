/**
 * Created by Alex on 17/12/2015.
 */
public class EnglishObserver extends Observer {
    public Dictionary d = new Dictionary();

    public EnglishObserver(MessageSet subject) {
        this.subject = subject;
        this.subject.attach(this);
    }

    public void update() {
        System.out.println("English: " + d.translateEnglishSentence(subject.getMessage()));
    }
}
