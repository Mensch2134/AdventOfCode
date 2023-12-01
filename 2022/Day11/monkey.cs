using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Day11
{
    internal class Monkey
    {
        Queue<long> itemWorries;
        int worryModifier;
        OperationType modifyType;
        int throwDivisor;
        int trueMonkeyIndex;
        int falseMonkeyIndex;
        bool squareWorry = false;

        int inspectedItems = 0;

        public Monkey(string items, int worryModifier, OperationType modifyType, int throwDivisor, int trueMonkeyIndex, int falseMonkeyIndex)
        {
            this.itemWorries = new Queue<long>();
            var its = items.Split(", ");
            foreach (var num in its)
                itemWorries.Enqueue(int.Parse(num));
            if (worryModifier == -1)
                squareWorry = true;
            this.worryModifier = worryModifier;
            this.modifyType = modifyType;
            this.throwDivisor = throwDivisor;
            this.trueMonkeyIndex = trueMonkeyIndex;
            this.falseMonkeyIndex = falseMonkeyIndex;
        }

        public ThrowResult throwItem()
        {
            inspectedItems++;
            var item = itemWorries.Dequeue();
            item = squareWorry ? (item * item) / 3 : modifyType == OperationType.MULTIPLY ? (item * worryModifier) / 3 : (item + worryModifier) / 3;
            if (item % throwDivisor == 0)
                return new ThrowResult(item, trueMonkeyIndex);
            return new ThrowResult(item, falseMonkeyIndex);
        }

        public ThrowResult throwItemSecond()
        {
            inspectedItems++;
            var item = itemWorries.Dequeue();
            item = squareWorry ? (item * item) : modifyType == OperationType.MULTIPLY ? (item * worryModifier) : (item + worryModifier);
            if (item % throwDivisor == 0)
                return new ThrowResult(item, trueMonkeyIndex);
            return new ThrowResult(item, falseMonkeyIndex);
        }

        public void addItem(long i)
        {
            itemWorries.Enqueue(i);
        }

        public void print()
        {
            Queue<long> items = new Queue<long>(itemWorries);
            var count = items.Count;
            for (int i = 0; i < count; i++)
            {
                Console.Write(items.Dequeue() + ", ");
            }
            Console.WriteLine(" | interacted with " + inspectedItems + " items.");
        }

        public int getItemCount() { return itemWorries.Count; }

        public int getInspectedItems() { return inspectedItems; }
    }

    internal struct ThrowResult
    {
        public long worry;
        public int recipient;

        public ThrowResult(long w, int r)
        {
            worry = w; recipient = r;
        }
    }

    public enum OperationType{
        MULTIPLY, 
        ADD
    }
}
