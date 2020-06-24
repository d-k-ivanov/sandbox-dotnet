using System;
using System.Collections.Generic;
using System.Text;

namespace _4_OOP
{
    public enum TrafficLight
    {
        Red,
        Yellow,
        Green
    }

    public enum Race : int
    {
        Elf,
        Orc,
        Human,
        Halfling,
        Dwarf
    }

    public enum BTwos : byte
    {
        One = 2,
        Two = 4,
        Three = 8,
        Four = 16,
        Five = 32,
        Six = 64,
        Seven = 128,
        Eight = 255 // MAX
    }

    public enum USTwos : ushort
    {
        One = 2,
        Two = 4,
        Three = 8,
        Four = 16,
        Five = 32,
        Six = 64,
        Seven = 128,
        Eight = 256,
        Nine = 512,
        Ten = 1024,
        Eleven = 2048,
        Twelve = 4096,
        Thirteen = 8192,
        Fourteen = 16384,
        Fifteen = 32768,
        Sixteen = 65535  // MAX

    }
}
