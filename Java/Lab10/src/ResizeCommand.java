/**
 * Created by Alex on 07/01/2016.
 */
public class ResizeCommand extends ImageCommand {
    @Override
    public void execute() {
        System.out.println("resize");
    }

    @Override
    public void execute(Image image) {
        System.out.println("resize");
        image.resize(50);
        image.show();
    }

    @Override
    public void undo(Image image) {
        image.undoResize(50);
    }
}
