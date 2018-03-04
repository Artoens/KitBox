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
    /*public bool IsInStock(int askedNumber)
    {

    }*/

    abstract public Piece Copy();

    abstract override public string ToString();
}
