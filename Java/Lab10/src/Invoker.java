import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

/**
 * Created by Alex on 07/01/2016.
 */
public class Invoker {
    public List<ImageCommand> commandList = new ArrayList<ImageCommand>();

    public void addCommand(ImageCommand command) {
        this.commandList.add(command);
    }

    public void executeCommands(Image image) {
        for (ImageCommand command : commandList) {
            command.execute(image);
        }
    }

    public void redo(Image image) {
        ImageCommand command = commandList.get(commandList.size() - 1);
        command.execute(image);
    }

    public void undo(Image image) {
        ImageCommand command = commandList.get(commandList.size() - 1);
        command.undo(image);

        commandList.remove(commandList.size() - 1);
    }

    public void undoAll(Image image) {
        int n = commandList.size() - 1;

        while (n >= 0) {
            ImageCommand command = commandList.get(n--);
            command.undo(image);
        }
    }
}
