/**
 * Created by Alex on 07/01/2016.
 */
public class BlurFilterCommand extends ImageCommand {
    @Override
    public void execute() {
        System.out.println("blur filter");
    }

    @Override
    public void execute(Image image) {
        System.out.println("blur filter");
        image.blur();
        image.show();
    }

    @Override
    public void undo(Image image) {
        image.undoBlur();
    }
}
