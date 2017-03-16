/**
 * Created by Alex on 07/01/2016.
 */
public class CropCommand extends ImageCommand {
    @Override
    public void execute() {
        System.out.println("crop");
    }

    @Override
    public void execute(Image image) {
        System.out.println("crop");
        image.crop(20, 20);
        image.show();
    }

    @Override
    public void undo(Image image) {
        image.undoCrop(20, 20);
    }
}
