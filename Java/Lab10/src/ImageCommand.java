/**
 * Created by Alex on 07/01/2016.
 */
public abstract class ImageCommand {
    public abstract void execute();

    public abstract void execute(Image image);

    public abstract void undo(Image image);

}
