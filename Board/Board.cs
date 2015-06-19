using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Board
{
    public class Sudoku
    {
        internal class BoardItem
        {
            public List<int> PossibleValues { get; private set; }

            public bool Checked { get; set; }

            public BoardItem()
            {
                PossibleValues = Enumerable.Range(1, 9).ToList();
            }

            public void RemoveValue(int number)
            {
                PossibleValues.Remove(number);
            }

            public void SetValue(int number)
            {
                PossibleValues = new List<int>() { number };
            }

            public override string ToString()
            {
                return String.Join(",", PossibleValues);
            }
        }

        private BoardItem[,] Items { get; set; }

        public Sudoku()
        {
            Items = new BoardItem[9, 9];

            for (int x = Items.GetLowerBound(0); x <= Items.GetUpperBound(0); x++)
                for (int y = Items.GetLowerBound(1); y <= Items.GetUpperBound(1); y++)
                    Items[x, y] = new BoardItem();
        }

        public bool UnResolvable()
        {
            return Items.Cast<BoardItem>().Where(v => v.PossibleValues.Count() == 0).Count() > 0;
        }

        public int this[int x, int y]
        {
            set
            {
                System.Diagnostics.Debug.WriteLine("setting " + x + ", " + y + " to value " + value);
                Items[x, y].SetValue(value);
                Items[x, y].Checked = true;

                for (int rx = Items.GetLowerBound(0); rx <= Items.GetUpperBound(0); rx++)
                    if (x != rx)
                        Items[rx, y].RemoveValue(value);

                for (int ry = Items.GetLowerBound(1); ry <= Items.GetUpperBound(1); ry++)
                    if (y != ry)
                        Items[x, ry].RemoveValue(value);

                int sx = (x / 3) * 3;
                int sy = (y / 3) * 3;
                for (int rx = 0; rx < 3; rx++)
                    for (int ry = 0; ry < 3; ry++)
                        if (x != rx + sx && y != ry + sy)
                            Items[rx + sx, ry + sy].RemoveValue(value);

                Console.Write(this);
                System.Diagnostics.Debug.Write(this);
                System.Diagnostics.Debug.WriteLine(String.Join(",", Items[1, 6].PossibleValues));
                if (UnResolvable())
                    throw new Exception("UNRESOLVABLE!");
            }
            get
            {
                return Items[x, y].PossibleValues.FirstOrDefault();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=========");
            for (int x = Items.GetLowerBound(0); x <= Items.GetUpperBound(0); x++)
            {
                for (int y = Items.GetLowerBound(1); y <= Items.GetUpperBound(1); y++)
                {
                    if (Items[x, y].Checked)
                        sb.Append(Items[x, y]);
                    else if (Items[x, y].PossibleValues.Count() == 0)
                        sb.Append("X");
                    else
                        sb.Append(" ");
                }
                sb.AppendLine();
            }
            sb.AppendLine("=========");
            return sb.ToString();
        }

        public void Resolve()
        {
            while (Items.Cast<BoardItem>().Where(x => !x.Checked).Count() > 0)
            {
                if (UnResolvable())
                    throw new Exception("UNRESOLVABLE!");
                for (int x = Items.GetLowerBound(0); x <= Items.GetUpperBound(0); x++)
                    for (int y = Items.GetLowerBound(1); y <= Items.GetUpperBound(1); y++)
                    {
                        if (!Items[x, y].Checked && Items[x, y].PossibleValues.Count() == 1)
                            this[x, y] = Items[x, y].PossibleValues.FirstOrDefault();
                        if (!Items[x, y].Checked)
                            foreach (var value in Items[x, y].PossibleValues)
                            {
                                int found = 0;
                                for (int rx = Items.GetLowerBound(0); rx <= Items.GetUpperBound(0); rx++)
                                    if (Items[rx, y].PossibleValues.Contains(value))
                                        found++;
                                if (found == 1)
                                {
                                    this[x, y] = value;
                                    break;
                                }
                                //uniq in row
                                //uniq in colm
                                found = 0;
                                for (int ry = Items.GetLowerBound(1); ry <= Items.GetUpperBound(1); ry++)
                                    if (Items[x, ry].PossibleValues.Contains(value))
                                        found++;
                                if (found == 1)
                                {
                                    this[x, y] = value;
                                    break;
                                }
                                //uniq in quat

                                found = 0;
                                int sx = (x / 3) * 3;
                                int sy = (y / 3) * 3;
                                for (int rx = 0; rx < 3; rx++)
                                    for (int ry = 0; ry < 3; ry++)
                                        if (Items[rx + sx, ry + sy].PossibleValues.Contains(value))
                                            found++;
                                if (found == 1)
                                {
                                    this[x, y] = value;
                                    break;
                                }
                            }
                    }
            }
        }
    }
}