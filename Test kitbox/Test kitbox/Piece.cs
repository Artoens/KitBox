using System;

public abstract class Piece
{
    protected int price;

    public Piece(int price)
    {
        this.price = price;
    }

    public int Price
    {
        get { return price; }
    }

    //IMPLEMENTED WITH DATABASE
    //Je suppose que askedNumber est le Piece_ID

    public bool IsInStock(int askedNumber)
    {
        using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=C:\Users\15171\Desktop\Kitbox.db;Version=3;"))
        {
            fmd.CommandText = @"SELECT Amount FROM Stock where Piece_ID = askedNumber";
            SQLiteDataReader q = fmd.ExecuteReader();
            if(q.read())
            {
                return true;
            }
            return false;
        }
    }

    abstract public Piece Copy();

    abstract override public string ToString();
}
