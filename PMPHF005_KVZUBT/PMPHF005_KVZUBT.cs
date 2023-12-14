using System;
using System.IO;

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
            
            for (int i = 0; i < instructions.Length; i++)
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
                        break;
                    case "ADD":
                        break;
                    case "SUB":
                        break;
                    case "JNE":
                        break;
                }
            }

        }
        static string[] RegisterReader(string fname)
        {
            string[] lines = File.ReadAllLines(fname);
            string[] regs = lines[0].Split(",");
            return regs;
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
        static int[] MOV(string dest, string src, int[] regsValue, string[] regsName)
        {
            if (!IsRegister(regsName, src))
            {
                regsValue[RegisterIndex(regsName, dest)] = int.Parse(src);
            } else
            {
                int value = regsValue[RegisterIndex(regsName, src)];
                regsValue[RegisterIndex(regsName, dest)] = value;
            }
            return regsValue;
        }
    }
}