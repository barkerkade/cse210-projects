public class Word
{
    private string word;

    private bool show = true;

    public Word(string text)
    {
        this.word = text;
    }

    public void hide()
    {
        show = false;
    }

    public bool isShowing()
    {
        return show;
    }
    public string Display()
    {
        if (show)
        {
            return word;
        }
        else
        {
            string hidden = "";

            foreach (char letter in word)
            {
                hidden += "_";
            }
            return hidden;
        }
    }
}