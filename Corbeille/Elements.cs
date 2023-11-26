using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements
{
    public interface IElementImplementation
    {
        void DisplayInfo(Element element);
    }

    public class DefaultElementImplementation : IElementImplementation
    {
        public void DisplayInfo(Element element)
        {
            Console.WriteLine($"Name: {element.Name}, Symbol: {element.Symbol}, Mass : {element.Mass}");
        }
    }
    public class Element
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Mass { get; set; }

        public int PositionX { get; set; } = 0;
        public int PositionY { get; set; } = 0;

        protected IElementImplementation elementImplementation;

        public Element(IElementImplementation implementation)
        {
            elementImplementation = implementation;
        }

        public void DisplayInfo()
        {
            elementImplementation.DisplayInfo(this);
        }
    }

    public class Carbon : Element
    {
        public Carbon(IElementImplementation implementation) : base(implementation)
        {
            Name = "Carbon";
            Symbol = "C";
            Mass = 12.01074;
        }
    }

    public class Hydrogen : Element
    {
        public Hydrogen(IElementImplementation implementation) : base(implementation)
        {
            Name = "Hydrogen";
            Symbol = "H";
            Mass = 1.00794;
        }
    }

    public class Lithium : Element
    {
        public Lithium(IElementImplementation implementation) : base(implementation)
        {
            Name = "Lithium";
            Symbol = "Li";
            Mass = 6.941;
        }
    }
    /*
     * class Factory fait en DP Singleton
     */
    public abstract class Factory
    {
        public abstract Element CreateAtom(String Atom);

        private static Factory instance;
        public static Factory GetInstance()
        {
            if (instance == null)
            {
                // Choisissez ici quelle sous-classe de fabrique vous souhaitez utiliser
                instance = new AFactory();
            }
            return instance;
        }

    }

    /*
     * DP Factory pour crée les instances des atoms de maniere centralisé
     */
    public class AFactory : Factory
    {
        public override Element CreateAtom(string AtomType)
        {
            switch (AtomType.ToLower())
            {
                case "carbon":
                    return new Carbon(new DefaultElementImplementation());
                case "hydrogen":
                    return new Hydrogen(new DefaultElementImplementation());
                case "lithium":
                    return new Lithium(new DefaultElementImplementation());
                // Ajoutez d'autres types d'atomes au besoin
                default:
                    throw new ArgumentException("Type d'atome non pris en charge");
            }
        }
    }
}

