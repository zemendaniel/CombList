using System;

namespace CombList
{
    internal class CombList
    {
        SpineNode head;
        int count; // amount of SpineNodes 

        public CombList()
        {
            head = null;
            count = 0;
        }
        
        public int Count
        {
            get { return count; }
        }

        public void AddSpineNodeLast(int newData)
        {
            count++;
            if (head == null)
            {
                head = new SpineNode(newData);
                return;
            }

            SpineNode spineNode = head;
            while (spineNode.Right != null)
            {
                spineNode = spineNode.Right;
            }

            spineNode.Right = new SpineNode(newData);
        }
        public void AddSpineNodeFirst(int newData)
        {
            count++;
            if (head == null) { AddSpineNodeLast(newData); return; }

            SpineNode newNode = new SpineNode(newData);
            newNode.Right = head;
            head = newNode;
        }


        public void RemoveSpineNodeByIndex(int index) 
        {
            VerifyXIndex(index);

            if (Count == 1)
            {
                head = null;
                count--;
                return;
            }
            
            if (index == 0)
            {
                head = head.Right;
                count--;
                return;
            }

            SpineNode spineNode = head;
            for (int i = 0; i != index - 1; spineNode = spineNode.Right, i++) ;


            spineNode.Right = spineNode.Right.Right;
            count--;

        }

        private SpineNode GetSpineNodeByIndex(int index)
        {
            SpineNode spineNode = head;
            for (int i = 0; i != index; spineNode = spineNode.Right, i++) ;
            return spineNode;
        }

        public bool IsSpineNodeElement(int value)
        {
            for (SpineNode spineNode = head; spineNode != null; spineNode = spineNode.Right)
                if (spineNode.Data == value)
                    return true;

            return false;
        }

        private void RemoveSingleSpineNodeByValue(int value)
        {
            count--;
            if (head.Data == value)
            {
                head = head.Right;
                return;
            }

            SpineNode spineNode = head;
            while (spineNode.Right.Data != value) { spineNode = spineNode.Right; }

            spineNode.Right = spineNode.Right.Right;
        }

        public void RemoveAllSpineNodesByValue(int value)
        {
            while(IsSpineNodeElement(value))
                RemoveSingleSpineNodeByValue(value);
        }

        public void AddToothNodeLast(int index, int value)
        {
            VerifyXIndex(index);
            SpineNode spineNode = GetSpineNodeByIndex(index);
            
            if (spineNode.Count == 0)
            {
                spineNode.Down = new ToothNode(value);
                spineNode.Count++;
            }
            else
            {
                ToothNode toothNode = spineNode.Down;
                while (toothNode.Down != null)
                {
                    toothNode = toothNode.Down;
                }
                toothNode.Down = new ToothNode(value);
                spineNode.Count++;
            }
        }
        public void AddToothNodeFirst(int index, int value)
        {
            SpineNode spineNode = GetSpineNodeByIndex(index);
            if (spineNode.Down == null) { AddToothNodeLast(index, value); return; }

            ToothNode newNode = new ToothNode(value);
            newNode.Down = spineNode.Down;
            spineNode.Down = newNode;
            spineNode.Count++;
        }
        public void RemoveEveryToothNodeByValue(int value)
        {
            for (int i = 0; i < Count; i++)
            {
                SpineNode spineNode = GetSpineNodeByIndex(i);
                ToothNode toothNode = spineNode.Down;
                if (toothNode == null) return;
                while (toothNode.Down != null)
                {
                    toothNode = toothNode.Down;
                    if (toothNode.Data == value)
                    {
                        toothNode.Down = toothNode.Down.Down;
                        spineNode.Count--;
                    }
                }
            }
        }
        public void RemoveEveryToothNodeByValueAndSpineIndex(int index, int value)
        {
            SpineNode spineNode = GetSpineNodeByIndex(index);
            ToothNode toothNode = spineNode.Down;

            if (toothNode == null) return;
            while (toothNode.Down != null)
            {
                toothNode = toothNode.Down;
                if (toothNode.Data == value)
                {
                    toothNode.Down = toothNode.Down.Down;
                    spineNode.Count--;
                }
            }
        }



        public void VerifyXIndex(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
        }
        public void VerifyYIndex(int index, SpineNode spineNode)
        {
            if (index < 0 || index >= spineNode.Count)
                throw new IndexOutOfRangeException();
        }

        // x means a SpineNode and y is a ToothNode, as if the list looked like a table
        public int this[int x, int y]
        {
            get
            {
                VerifyXIndex(x);
                SpineNode spineNode = GetSpineNodeByIndex(x);
                VerifyYIndex(y, spineNode);
                ToothNode toothNode = spineNode.Down;

                for (int i = 0; i != y; toothNode = toothNode.Down, i++) ;
                return toothNode.Data;
            }
            set
            {
                // test the validity of the index
                int tmp = this[x,y];

                SpineNode spineNode = GetSpineNodeByIndex(x);
                ToothNode toothNode = spineNode.Down;
                for (int i = 0; i != y; toothNode = toothNode.Down, i++) ;
                toothNode.Data = value;
            }
        }
        /*
            private int GetMaxYValue()
            {
                int max = GetSpineNodeByIndex(0).Count;

                for (int i = 1; i < Count; i++)
                {
                    int tmp = GetSpineNodeByIndex(i).Count;
                    if (tmp > max)
                    {
                        max = tmp;
                    }
                }
                return max;
            }

         public override string ToString()
         {
             if (head == null) return "null";

             string output = "  ";
             for (int i = 0; i < Count;i++)
             {
                 output += GetSpineNodeByIndex(i).Data.ToString() + "   ";
             }
             output += "\n";

             int maxYValue = GetMaxYValue();
             for (int y = 0; y < maxYValue; y++)
             {
                 for (int x = 0; x < Count; x++) 
                 {
                     string tmp;
                     try
                     {
                         tmp = "| " + this[x, y].ToString() + " ";
                     }
                     catch (IndexOutOfRangeException)
                     {
                         tmp = " | ";
                     }

                     output += tmp;
                 }
                 output += "|\n";
             }
             return output;
         }

         */


        public override string ToString()
        {
            if (head == null) return "null";

            string output = "";
            for (int x = 0; x < Count; x++)
            {
                SpineNode spineNode = GetSpineNodeByIndex(x);
                output += spineNode.Data.ToString() + ": ";
                if (spineNode.Count == 0)
                {
                    output += "null\n";
                }
                else
                {
                    for (int y = 0; y < spineNode.Count; y++)
                    {
                        output += this[x, y].ToString() + " ";
                    }
                    output += "\n";
                }
                
            }
            return output;
        }
        
        public CombList(CombList other)
        {
            for (int x = 0; x < other.Count; x++) 
            {
                SpineNode tmp = other.GetSpineNodeByIndex(x);
                this.AddSpineNodeLast(tmp.Data);
                for(int y = 0; y<tmp.Count; y++)
                {
                    this.AddToothNodeLast(x, other[x, y]);
                }
            }
        }

        
       
    }
}
