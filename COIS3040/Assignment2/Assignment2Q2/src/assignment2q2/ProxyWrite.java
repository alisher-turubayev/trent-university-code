/*
 * COIS 3040 - Assignment #2
 * Trent University
 *
 * Question #2
 * Assignment Group: Alisher Turubayev & Vanshree Mathur
 */
package assignment2q2;

//ProxyWrite Class, implements IText Interface
public class ProxyWrite implements IText {
    private final IText text;

    //Creating an object from RealText class
    public ProxyWrite() {
        text = new Text();
    }

    //Overrides getContent() and setContent() from IText
    @Override
    public String getContent() {
        //Does not display content, Write Access only
        System.out.println("Current contents:");
        return "Error: Cannot read content";
    }

    @Override
    public void setContent(String content) {
        text.setContent(content);
        System.out.println("Contents changed.");
    }
}
