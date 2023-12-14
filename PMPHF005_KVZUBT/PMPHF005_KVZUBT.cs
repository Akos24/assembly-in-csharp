using System;
using System.IO;
using static System.Formats.Asn1.AsnWriter;

namespace PMPHF005_KVZUBT
{
    class Program
    {
        static void Main()
        {
            string fname = "input.txt";
            int regA = int.Parse(RegisterReader(fname)[0]);
            int regB = int.Parse(RegisterReader(fname)[1]);
            int regC = int.Parse(RegisterReader(fname)[2]);
            int regD = int.Parse(RegisterReader(fname)[3]);

            int[] regsValue = { regA, regB, regC, regD };
            string[] regsName = { "A", "B", "C", "D" };

            string[] instructions = InstructionReader(fname);
            int instrLength = instructions.Length;

            int i = 0;
            while (i < instrLength)
            {
                string[] instruction = instructions[i].Split(" ");
                string command = instruction[0];
                string[] commandParams = CommandParamConstructor(instruction);

                switch (command)
                {
                    case "MOV":
                        string dest = commandParams[0];
                        string src = commandParams[1];
                        MOV(dest, src, regsValue, regsName);
                        i++;
                        break;
                    case "ADD":
                        dest = commandParams[0];
                        string srcOne = commandParams[1];
                        string srcTwo = commandParams[2];
                        ADD(dest, srcOne, srcTwo, regsValue, regsName);
                        i++;
                        break;
                    case "SUB":
                        dest = commandParams[0];
                        srcOne = commandParams[1];
                        srcTwo = commandParams[2];
                        SUB(dest, srcOne, srcTwo, regsValue, regsName);
                        i++;
                        break;
                    case "JNE":
                        int cnst = int.Parse(commandParams[0]);
                        srcOne = commandParams[1];
                        srcTwo = commandParams[2];
                        if (!JNE(srcOne, srcTwo, regsValue, regsName))
                        {
                            i = cnst;
                        } else
                        {
                            i++;
                        }
                        break;
                }
            }

            string outputFname = "output.txt";
            string[] register = new string[regsValue.Length];
            for (int j = 0; j < regsValue.Length; j++)
            {
                register[j] = regsValue[j].ToString();
            }
            RegisterOutput(outputFname, register);
        }
        static void RegisterWriter(int[] regsValue)
        {
            foreach (int reg in regsValue)
            {
                Console.Write(reg + " ");
            }
            Console.WriteLine();
        }
        static string[] RegisterReader(string fname)
        {
            string[] lines = File.ReadAllLines(fname);
            string[] regs = lines[0].Split(",");
            return regs;
        }
        static void RegisterOutput(string fname, string[] register)
        {
            if (File.Exists(fname))
            {
                File.Delete(fname);
            }

            for (int i = 0; i < register.Length - 1; i++)
            {
                File.AppendAllText(fname, register[i] + ",", System.Text.Encoding.UTF8);
            }
            File.AppendAllText(fname, register[register.Length - 1], System.Text.Encoding.UTF8);
        }
        static string[] InstructionReader(string fname)
        {
            string[] lines = File.ReadAllLines(fname);
            string[] instructions = new string[lines.Length - 1];
            for (int i = 1; i < lines.Length; i++)
            {
                instructions[i - 1] = lines[i];
            }
            return instructions;
        }
        static string[] CommandParamConstructor(string[] instruction)
        {
            string[] commandParams = new string[instruction.Length - 1];
            for (int j = 1; j < instruction.Length; j++)
            {
                commandParams[j - 1] = instruction[j];
            }
            return commandParams;
        }
        static bool IsRegister(string[] regsName, string value)
        {
            for (int i = 0; i < regsName.Length; i++)
            {
                if (regsName[i] == value)
                {
                    return true;
                }
            }
            return false;
        }
        static int RegisterIndex(string[] regsName, string value)
        {
            for (int i = 0; i < regsName.Length; i++)
            {
                if (regsName[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }
        static void MOV(string dest, string src, int[] regsValue, string[] regsName)
        {
            if (!IsRegister(regsName, src))
            {
                regsValue[RegisterIndex(regsName, dest)] = int.Parse(src);
            } else
            {
                int value = regsValue[RegisterIndex(regsName, src)];
                regsValue[RegisterIndex(regsName, dest)] = value;
            }
        }
        static void ADD(string dest, string srcOne, string srcTwo, int[] regsValue, string[] regsName)
        {
            if (!IsRegister(regsName, srcOne) && !IsRegister(regsName, srcTwo))
            {
                regsValue[RegisterIndex(regsName, dest)] = int.Parse(srcOne) + int.Parse(srcTwo);
            } else if (IsRegister(regsName, srcOne) && !IsRegister(regsName, srcTwo))
            {
                int valueOne = regsValue[RegisterIndex(regsName, srcOne)];
                regsValue[RegisterIndex(regsName, dest)] = valueOne + int.Parse(srcTwo);
            }
            else if (!IsRegister(regsName, srcOne) && IsRegister(regsName, srcTwo))
            {
                int valueTwo = regsValue[RegisterIndex(regsName, srcTwo)];
                regsValue[RegisterIndex(regsName, dest)] = int.Parse(srcOne) + valueTwo;

            } else
            {
                int valueOne = regsValue[RegisterIndex(regsName, srcOne)];
                int valueTwo = regsValue[RegisterIndex(regsName, srcTwo)];
                regsValue[RegisterIndex(regsName, dest)] = valueOne + valueTwo;
            }
        }
        static void SUB(string dest, string srcOne, string srcTwo, int[] regsValue, string[] regsName)
        {
            if (!IsRegister(regsName, srcOne) && !IsRegister(regsName, srcTwo))
            {
                regsValue[RegisterIndex(regsName, dest)] = int.Parse(srcOne) - int.Parse(srcTwo);
            }
            else if (IsRegister(regsName, srcOne) && !IsRegister(regsName, srcTwo))
            {
                int valueOne = regsValue[RegisterIndex(regsName, srcOne)];
                regsValue[RegisterIndex(regsName, dest)] = valueOne - int.Parse(srcTwo);
            }
            else if (!IsRegister(regsName, srcOne) && IsRegister(regsName, srcTwo))
            {
                int valueTwo = regsValue[RegisterIndex(regsName, srcTwo)];
                regsValue[RegisterIndex(regsName, dest)] = int.Parse(srcOne) - valueTwo;

            }
            else
            {
                int valueOne = regsValue[RegisterIndex(regsName, srcOne)];
                int valueTwo = regsValue[RegisterIndex(regsName, srcTwo)];
                regsValue[RegisterIndex(regsName, dest)] = valueOne - valueTwo;
            }
        }
        static bool JNE(string srcOne, string srcTwo, int[] regsValue, string[] regsName)
        {
            if (!IsRegister(regsName, srcOne) && !IsRegister(regsName, srcTwo))
            {
                return int.Parse(srcOne) == int.Parse(srcTwo);
            }
            else if (IsRegister(regsName, srcOne) && !IsRegister(regsName, srcTwo))
            {
                int valueOne = regsValue[RegisterIndex(regsName, srcOne)];
                return valueOne == int.Parse(srcTwo);
            }
            else if (!IsRegister(regsName, srcOne) && IsRegister(regsName, srcTwo))
            {
                int valueTwo = regsValue[RegisterIndex(regsName, srcTwo)];
                return int.Parse(srcOne) == valueTwo;
            } else
            {
                int valueOne = regsValue[RegisterIndex(regsName, srcOne)];
                int valueTwo = regsValue[RegisterIndex(regsName, srcTwo)];
                return valueOne == valueTwo;
            }
        }
    }
}