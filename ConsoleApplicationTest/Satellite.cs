using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{

    public class Satellite
    {
        private string _name;
        private int _velocity;
        private int _altitude;
        private Application _app;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public int Altitude
        {
            get { return _altitude; }
            set { _altitude = value; }
        }

        public Application App
        {
            get { return _app; }
            set { _app = value; }
        }

        public Satellite(string name, int velocity, int altitude, Application app)
        {
            this._name = name;
            this._velocity = velocity;
            this._altitude = altitude;
            this._app = app;
        }

        public override string ToString()
        {
            return $"Name: {_name}, Velocity: {_velocity}, Altitude: {_altitude}, Application: {_app}";
        }

        public void Deconstruct(out string name, out int velocity, out int altitude, out Application app)
        {
            name = this._name;
            velocity = this._velocity;
            altitude = this._altitude;
            app = this._app;
        }

        static public Satellite operator + (Satellite s1, Satellite s2)
        {
            Console.WriteLine("Just a try of the Overload of the Operator +!!!!");
            return new Satellite(String.Concat(s1.Name,s2.Name), s1.Velocity+s2.Velocity, s1.Altitude+ s2.Altitude, s1.App);
        }

    }


}
