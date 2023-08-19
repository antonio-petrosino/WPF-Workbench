using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    public class Application
    {
        private string name;
        private int ram;
        private int cpu;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Ram
        {
            get { return ram; }
            set { ram = value; }
        }

        public int Cpu
        {
            get { return cpu; }
            set { cpu = value; }
        }

        public Application(string name, int ram, int cpu)
        {
            this.name = name;
            this.ram = ram;
            this.cpu = cpu;
        }

        public override string ToString()
        {
            return $"APP - Name: {name}, RAM: {ram}, CPU: {cpu}";
        }

        public Application Clone()
        {
            return new Application(this.name, this.ram, this.cpu);
        }
    }
}
