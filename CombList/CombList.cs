using System;
using System.Diagnostics;
using System.Reflection;

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
            if (head == null) { AddSpineNodeLast(newData); return; }

            count++;
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
            VerifyXIndex(index);
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
        
        
        public bool IsToothNodeElement(int index, int value)
        {
            SpineNode spineNode = GetSpineNodeByIndex(index);
            ToothNode toothNode = spineNode.Down;
            if (spineNode.Count == 1)
                if(toothNode.Data == value) 
                    return true;
                else
                    return false;
            else if (spineNode.Count == 0) return false;

            for (toothNode = toothNode.Down; toothNode.Down != null; toothNode = toothNode.Down)
                if (toothNode.Data == value)
                    return true;

            return false;
        }
        
        
        
        
        

        public void RemoveAllToothNodeByValue(int value)
        {
            for (int x = 0; x < Count; x++)
            {
                SpineNode spineNode = GetSpineNodeByIndex(x);
                for (int y = 0; y < spineNode.Count; y++)
                {
                    if (this[x, y] == value)
                    {
                        RemoveToothNodeByIndex(x, y);
                    }
                }
            }

        }
        public void RemoveEveryToothNodeByValueAndSpineIndex(int index, int value)
        {
            for (int x = 0; x < Count; x++)
            {
                if (x == index)
                {
                    SpineNode spineNode = GetSpineNodeByIndex(x);
                    for (int y = 0; y < spineNode.Count; y++)
                    {
                        if (this[x, y] == value)
                        {
                            RemoveToothNodeByIndex(x, y);
                        }
                    }
                }
            }

        }



        public void RemoveToothNodeByIndex(int x, int y)
        {
            VerifyXIndex(x);
            SpineNode spineNode = GetSpineNodeByIndex(x);
            VerifyYIndex(y, spineNode);
            ToothNode toothNode = spineNode.Down;
            for (int i = 0; i != y - 1; toothNode = toothNode.Down, i++) ;

            toothNode.Down = toothNode.Down.Down;
            spineNode.Count--;
        }

        private void VerifyXIndex(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
        }
        private void VerifyYIndex(int index, SpineNode spineNode)
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
                VerifyXIndex(x);

                SpineNode spineNode = GetSpineNodeByIndex(x);
                VerifyYIndex(y, spineNode);

                ToothNode toothNode = spineNode.Down;
                for (int i = 0; i != y; toothNode = toothNode.Down, i++) ;
                toothNode.Data = value;
            }
        }

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
