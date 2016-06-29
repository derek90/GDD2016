using System;

namespace WindowsFormsApplication1.ABM_Rol
{
    class Functionality : IEquatable<Functionality>
    {
        public int code { get; }
        public string description { get; }

        public Functionality(int code, string description)
        {
            this.code = code;
            this.description = description;
        }

        public bool Equals (Functionality other)
        {
            return this.code == other.code;
        }

        public override string ToString()
        {
            return this.description;
        }
    }
}
