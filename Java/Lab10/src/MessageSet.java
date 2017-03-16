import java.util.ArrayList;
import java.util.List;

/**
 * Created by Alex on 17/12/2015.
 */
public class MessageSet {
    public Observer observer;
    public List<String> MessageList = new ArrayList<>(100);

    public List<Observer> observers = new ArrayList<>();

    public String getMessage() {
        int index = MessageList.size() - 1;
        return MessageList.get(index);
    }

    public void setMessage(String message) {
        MessageList.add(message);
        // notifyObserver();
        notifyAllObservers();
    }

    public void attach(Observer observer) {
        // this.observer = observer;
        observers.add(observer);
    }

    public void notifyObserver() {
        observer.update();
    }

    public void notifyAllObservers() {
        for (Observer o : observers) {
            o.update();
        }
    }
}
