/*
 * COIS 3040 - Assignment #2
 * Trent University
 *
 * Question #2
 * Assignment Group: Alisher Turubayev & Vanshree Mathur
 */
package assignment2q2;

//ProxyReadWrite Class, implements IText Interface
public class ProxyReadWrite implements IText {
    private final IText text;
    
    //Creating an object from RealText class
    public ProxyReadWrite() {
        text = new Text();
    }

    //Overrides getContent() and setContent() from IText
    @Override
    public String getContent() {
        System.out.println("Current contents:");
        return text.getContent();
    }

    @Override
    public void setContent(String content) {
        text.setContent(content);
        System.out.println("Contents changed.");
    }
}
