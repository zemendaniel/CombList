using System.Runtime.CompilerServices;

namespace CombList
{
    internal class SpineNode
    {
        int data;
        SpineNode right;
        ToothNode down;
        int count; // amount of ToothNodes

        public SpineNode(int data) 
        {
            this.data = data;
            right = null;
            down = null;
        }
        
        public int Data
        {
            get { return data; }
            set { data = value; }
        }

        public SpineNode Right 
        {
            get { return right; }
            set { right = value; }
        }
        
        public ToothNode Down 
        {
            get { return down; }
            set { down = value; }
        }

        public int Count 
        {
            get { return count; }
            set
            {
                if (value >= 0) count = value;
            }
            
        }

    }
}
