
class DimensionType
{
    Width;
    Height;

    constructor(width = null, height = null)
    {
        if(width && height)
        {
            this.Width = width;
            this.Height = height;
        }
        else if(width)
        {
            this.Width = width;
            this.Height = width;
        }
        else
        {
            this.Width = 300;
            this.Height = 300;
        }
    }
}