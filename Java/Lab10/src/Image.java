/**
 * Created by Alex on 07/01/2016.
 */
public class Image {
    int width, height, blurLevel;

    public Image(int width, int height) {
        this.width = width;
        this.height = height;
        blurLevel = 0;
    }

    void resize(int percent) {
        this.width = (int) (this.width + ((float) percent / 100) * this.width);
        this.height = (int) (this.height + ((float) percent / 100) * this.height);
    }

    void blur() {
        this.blurLevel++;
    }

    void crop(int w, int h) {
        this.width = this.width - w;
        this.height = this.height - h;
    }

    void undoResize(int percent) {
        this.width = ((100 * this.width) / (100 + percent));
        this.height = ((100 * this.height) / (100 + percent));

    }

    void undoBlur() {
        this.blurLevel--;
    }

    void undoCrop(int w, int h) {
        this.width = this.width + w;
        this.height = this.height + h;
    }

    void show() {
        System.out.println(width + " x " + height + " : " + blurLevel);
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof Image)) return false;

        Image image = (Image) o;

        if (width != image.width) return false;
        if (height != image.height) return false;
        return blurLevel == image.blurLevel;

    }

    @Override
    public int hashCode() {
        int result = width;
        result = 31 * result + height;
        result = 31 * result + blurLevel;
        return result;
    }
}
