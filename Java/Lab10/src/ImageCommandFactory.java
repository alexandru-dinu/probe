/**
 * Created by Alex on 07/01/2016.
 */
public class ImageCommandFactory {
    public ImageCommand getCommand(String commandType) {
        if (commandType == null) {
            return null;
        }

        if (commandType.equalsIgnoreCase("resize")) {
            return new ResizeCommand();
        } else if (commandType.equalsIgnoreCase("blur")) {
            return new BlurFilterCommand();
        } else if (commandType.equalsIgnoreCase("crop")) {
            return new CropCommand();
        }

        return null;
    }
}
