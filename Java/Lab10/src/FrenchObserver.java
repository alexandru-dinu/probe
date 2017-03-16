/**
 * Created by Alex on 17/12/2015.
 */
public class FrenchObserver extends Observer {
    public Dictionary d = new Dictionary();

    public FrenchObserver(MessageSet subject) {
        this.subject = subject;
        this.subject.attach(this);
    }

    public void update() {
        System.out.println("French: " + d.translateFrenchSentence(subject.getMessage()));
    }
}
