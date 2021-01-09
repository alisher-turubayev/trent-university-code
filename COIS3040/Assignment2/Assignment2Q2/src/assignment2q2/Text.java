/*
 * COIS 3040 - Assignment #2
 * Trent University
 *
 * Question #2
 * Assignment Group: Alisher Turubayev & Vanshree Mathur
 */
package assignment2q2;

//RealText Class, implements IText Interface
public class Text implements IText{
    private String content;

    public Text() {
        content = "Empty.";
    }
    
    //Getter and Setter for RealText content
    @Override
    public void setContent(String content) {
        this.content = content;
    }

    @Override
    public String getContent() {
        return content;
    }
}
