public class Word
{
    private string word;

    private bool show = true;

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