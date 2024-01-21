namespace CombList
{
    internal class ToothNode
    {
        int data;
        ToothNode down;

        public ToothNode(int data)
        {
            this.data = data;
            down = null;
        }

        public int Data
        {
            get { return data; }
            set { data = value; }
        }

        public ToothNode Down
        {
            get { return down; }
            set { down = value; }
        }

    }
}
