// See https://aka.ms/new-console-template for more information
using Elements;
using Universes;

IElementImplementation implementation = new DefaultElementImplementation();
Factory F = Factory.GetInstance();

Element e1 = F.CreateAtom("Carbon") ;
Element e2 = F.CreateAtom("Hydrogen");
Element e3 = F.CreateAtom("Lithium");

e1.DisplayInfo();
e2.DisplayInfo();
e3.DisplayInfo();

Console.WriteLine("\n-----------------------------------------------------------\n");

IUniverseImplementation Iuniv = new DefaultUniverseImplementation();
TwoDimensionalUniverse univ = new(Iuniv, 50, 50);
univ.AddElement(e1, 0, 0);
univ.AddElement(e2, 1, 1);
univ.AddElement(e3, 2, 2);
univ.AddElement(F, "Lithium", 1, 11);

List<Element> elements = univ.GetElement();
univ.DisplayInfo();


