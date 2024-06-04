namespace LadybugGame
{
    public class Position
    {
        private int _x; private int _y;
        public int X
        {
            get => _x;
            set
            {
                if (value >= 0 && value < 16)
                {
                    _x = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 1 and 14.");
                }



            }
        }

        public int Y
        {
            get => _y;
            set
            {
                if (value >= 0 && value < 16)
                {
                    _y = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 1 and 15.");
                }



            }
        }



        public void MoveDown() => Y = (Y - 1 >= 0) ? Y - 1 : Y;
        public void MoveUp() => Y = (Y + 1 <= 15) ? Y + 1 : Y;
        public void MoveLeft() => X = (X - 1 >= 0) ? X - 1 : X;
        public void MoveRight() => X = (X + 1 <= 15) ? X + 1 : X;

        public Position(int x, int y)
        {
            X = x; Y = y;
        }
    }
}