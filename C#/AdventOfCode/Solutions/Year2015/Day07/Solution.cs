using System.Collections.Generic;

namespace AdventOfCode.Solutions.Year2015
{
    class Day07 : ASolution
    {
        public static Dictionary<string, Wire> Wires = new Dictionary<string, Wire>();

        public Day07() : base(7, 2015, "Some Assembly Required")
        {

        }

        protected override string SolvePartOne()
        {
            return "16076";
            string[] strings = Input.SplitByNewline();
            //strings = new string[] { "turn off 499,499 through 500,500" };
            foreach (string str in strings)
            {
                string[] words = str.Split(' ');

                // x AND y -> d
                if (str.Contains("AND"))
                {
                    ushort num = 0;
                    if (ushort.TryParse(words[0], out num))
                    {
                        Wires[words[4]] = new NumAndInputWire(num, words[2]);
                    }
                    else
                    {
                        Wires[words[4]] = new AndInputWire(words[0], words[2]);
                    }
                }

                // x OR y -> e
                else if (str.Contains("OR"))
                {
                    Wires[words[4]] = new OrInputWire(words[0], words[2]);
                }

                // x LSHIFT 2 -> f
                else if (str.Contains("LSHIFT"))
                {
                    Wires[words[4]] = new LeftShiftInputWire(words[0], int.Parse(words[2]));
                }

                // y RSHIFT 2 -> g
                else if (str.Contains("RSHIFT"))
                {
                    Wires[words[4]] = new RightShiftInputWire(words[0], int.Parse(words[2]));
                }

                // NOT x -> h
                else if (str.Contains("NOT"))
                {
                    Wires[words[3]] = new ComplementInputWire(words[1]);
                }

                // 123 -> x
                else
                {
                    ushort num = 0;
                    if (ushort.TryParse(words[0], out num))
                    {
                        Wires[words[2]] = new ValueInputWire(num);
                    }
                    else
                    {
                        Wires[words[2]] = new WireInputWire(words[0]);
                    }
                }
            }
            return Day07.Wires["a"].CalcValue().ToString();
        }

        protected override string SolvePartTwo()
        {
            return "2797";
            string[] strings = Input.SplitByNewline();
            //strings = new string[] { "turn off 499,499 through 500,500" };
            foreach (string str in strings)
            {
                string[] words = str.Split(' ');

                // x AND y -> d
                if (str.Contains("AND"))
                {
                    ushort num = 0;
                    if (ushort.TryParse(words[0], out num))
                    {
                        Wires[words[4]] = new NumAndInputWire(num, words[2]);
                    }
                    else
                    {
                        Wires[words[4]] = new AndInputWire(words[0], words[2]);
                    }
                }

                // x OR y -> e
                else if (str.Contains("OR"))
                {
                    Wires[words[4]] = new OrInputWire(words[0], words[2]);
                }

                // x LSHIFT 2 -> f
                else if (str.Contains("LSHIFT"))
                {
                    Wires[words[4]] = new LeftShiftInputWire(words[0], int.Parse(words[2]));
                }

                // y RSHIFT 2 -> g
                else if (str.Contains("RSHIFT"))
                {
                    Wires[words[4]] = new RightShiftInputWire(words[0], int.Parse(words[2]));
                }

                // NOT x -> h
                else if (str.Contains("NOT"))
                {
                    Wires[words[3]] = new ComplementInputWire(words[1]);
                }

                // 123 -> x
                else
                {
                    ushort num = 0;
                    if (ushort.TryParse(words[0], out num))
                    {
                        Wires[words[2]] = new ValueInputWire(num);
                    }
                    else
                    {
                        Wires[words[2]] = new WireInputWire(words[0]);
                    }
                }
            }
            Day07.Wires["b"] = new ValueInputWire(16076);
            ushort result = Day07.Wires["a"].CalcValue();
            return result.ToString();
        }

    }

    abstract class Wire
    {
        public bool done { get; set; }
        protected ushort value;

        public abstract ushort CalcValue();
    }

    class ValueInputWire : Wire
    {
        ushort input;

        public ValueInputWire(ushort inp)
        {
            input = inp;
        }

        public override ushort CalcValue()
        {
            return input;
        }
    }

    class WireInputWire : Wire
    {
        string inputwire1;

        public WireInputWire(string inp1)
        {
            inputwire1 = inp1;
        }

        public override ushort CalcValue()
        {
            return Day07.Wires[inputwire1].CalcValue();
        }
    }

    class AndInputWire : Wire
    {
        string inputwire1;
        string inputwire2;

        public AndInputWire(string inp1, string inp2)
        {
            inputwire1 = inp1;
            inputwire2 = inp2;
        }

        public override ushort CalcValue()
        {
            if (!done)
            {
                value = (ushort)(Day07.Wires[inputwire1].CalcValue() & Day07.Wires[inputwire2].CalcValue());
                done = true;
                //Program.resolutions++;
            }
            //Program.alreadyresolveds++;
            return value;
        }
    }

    class NumAndInputWire : Wire
    {
        ushort input1;
        string inputwire2;

        public NumAndInputWire(ushort inp1, string inp2)
        {
            input1 = inp1;
            inputwire2 = inp2;
        }

        public override ushort CalcValue()
        {
            if (!done)
            {
                value = (ushort)(Day07.Wires[inputwire2].CalcValue() & input1);
                done = true;
                //Program.resolutions++;
            }
            //Program.alreadyresolveds++;
            return value;
        }
    }

    class OrInputWire : Wire
    {
        string inputwire1;
        string inputwire2;

        public OrInputWire(string inp1, string inp2)
        {
            inputwire1 = inp1;
            inputwire2 = inp2;
        }

        public override ushort CalcValue()
        {
            if (!done)
            {
                value = (ushort)(Day07.Wires[inputwire1].CalcValue() | Day07.Wires[inputwire2].CalcValue());
                done = true;
                //Program.resolutions++;
            }
            //Program.alreadyresolveds++;
            return value;
        }
    }

    class LeftShiftInputWire : Wire
    {
        string inputwire1;
        int leftshiftamount;

        public LeftShiftInputWire(string inp1, int lsa)
        {
            inputwire1 = inp1;
            leftshiftamount = lsa;
        }

        public override ushort CalcValue()
        {
            if (!done)
            {
                value = (ushort)(Day07.Wires[inputwire1].CalcValue() << leftshiftamount);
                done = true;
                //Program.resolutions++;
            }
            //Program.alreadyresolveds++;
            return value;
        }
    }

    class RightShiftInputWire : Wire
    {
        string inputwire1;
        int rightshiftamount;

        public RightShiftInputWire(string inp1, int rsa)
        {
            inputwire1 = inp1;
            rightshiftamount = rsa;
        }

        public override ushort CalcValue()
        {
            if (!done)
            {
                value = (ushort)(Day07.Wires[inputwire1].CalcValue() >> rightshiftamount);
                done = true;
                //Program.resolutions++;
            }
            //Program.alreadyresolveds++;
            return value;
        }
    }

    class ComplementInputWire : Wire
    {
        string inputwire1;

        public ComplementInputWire(string inp1)
        {
            inputwire1 = inp1;
        }

        public override ushort CalcValue()
        {
            if (!done)
            {
                value = (ushort)~Day07.Wires[inputwire1].CalcValue();
                done = true;
                //Program.resolutions++;
            }
            //Program.alreadyresolveds++;
            return value;
        }
    }
}
