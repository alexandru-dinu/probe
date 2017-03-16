/**
 * Created by Alex on 17/12/2015.
 */
public class Main {

    public static void main(String[] args) {

//        MessageSet subject = new MessageSet();
//        new EnglishObserver(subject);
//        new FrenchObserver(subject);
//
//        subject.setMessage("mama tata sora frate");

//        ImageCommandFactory imageFactory = new ImageCommandFactory();
//
//        ImageCommand c1 = imageFactory.getCommand("resize");
//        c1.execute();
//
//        ImageCommand c2 = imageFactory.getCommand("blur");
//        c2.execute();
//
//        ImageCommand c3 = imageFactory.getCommand("crop");
//        c3.execute();

        Image image = new Image(500, 500);
        System.out.println("before: ");
        image.show();
        System.out.println();

        System.out.println("commands: ");

        BlurFilterCommand b1 = new BlurFilterCommand();
        CropCommand c1 = new CropCommand();
        ResizeCommand r1 = new ResizeCommand();

        Invoker inv = new Invoker();

        inv.addCommand(r1);
        inv.addCommand(b1);
        inv.addCommand(c1);

        inv.executeCommands(image);
        inv.undoAll(image);

        System.out.println("\n" + "after: ");
        image.show();
    }
}
