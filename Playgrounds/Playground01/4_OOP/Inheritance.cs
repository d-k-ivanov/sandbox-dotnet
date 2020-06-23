using System;
using System.Collections.Generic;
using System.Text;

namespace _4_OOP
{
    public class PosTerminal
    {
        protected string Id;

        public PosTerminal(string id)
        {
            Id = id;
        }

        public virtual void Connect()
        {
            Console.WriteLine($"POSTerminal Base     {Id}: General connection protocol...");
        }
    }

    public class Ingenico : PosTerminal
    {
        public Ingenico(string id) : base(id)
        {

        }
        public override void Connect()
        {
            base.Connect();
            Console.WriteLine($"POSTerminal Ingenico {Id}: Additional connection actions for Ingenico...");
        }
    }

    public class Telco : PosTerminal
    {
        public Telco(string id) : base(id)
        {
        }

        public override void Connect()
        {
            Console.WriteLine($"POSTerminal Telco    {Id}: Telco connection protocol...");
            Console.WriteLine($"POSTerminal Telco    {Id}: Additional connection actions for Telco...");
        }
    }

    public class SZFP : PosTerminal
    {
        public SZFP(string id) : base(id)
        {
        }

        public override void Connect()
        {
            base.Connect();
            Console.WriteLine($"POSTerminal SZFP     {Id}: Additional connection actions for SZFP...");
            Console.WriteLine($"POSTerminal SZFP     {Id}: Finalizing...");
        }
    }
}
