public class Scripture
{
    private List<Word> _words = new List<Word>();


    private Reference reference;

    public Scripture(string text, Reference myReference)
    {
        this.reference = myReference;
        string[] wordsList = text.Split(" ");
        foreach(string word in wordsList)
        {
            Word newWord = new Word(word);
            _words.Add(newWord);
        }
        
    }
    
    public bool isFinished()
    {
        foreach(Word word in _words)
        {
            bool isShowing = word.isShowing();
            if(isShowing == true)
            {
                return false;
            }
        }
        return true;
    }
    
    public void hide()
    {
        Random random = new Random();
        
        for (int i = 0; i < 3; i++)
        {
            int index = random.Next(0, _words.Count() - 1);
            _words[index].hide();
        }
    }
    

    public void Display()
    {
        reference.Display();

        foreach(Word word in _words)
        {
           string text = word.Display();

           Console.Write(text + " ");
        }
    }
}

/*8 And it came to pass that he said unto them: Behold, here are the waters of Mormon (for thus were they called) and now, as ye are desirous to come into the fold of God, and to be called his people, and are willing to bear one another’s burdens, that they may be light;

9 Yea, and are willing to mourn with those that mourn; yea, and comfort those that stand in need of comfort, and to stand as witnesses of God at all times and in all things, and in all places that ye may be in, even until death, that ye may be redeemed of God, and be numbered with those of the first resurrection, that ye may have eternal life—

10 Now I say unto you, if this be the desire of your hearts, what have you against being baptized in the name of the Lord, as a witness before him that ye have entered into a covenant with him, that ye will serve him and keep his commandments, that he may pour out his Spirit more abundantly upon you?*/