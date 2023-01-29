using System;
using System.IO;

namespace Girrafe 

public class madlibs
{
	public madlibs()
	{
		

	}
	static void Main(string[] args)
    {
		// We need three variable to store
		string color, pluralNoun, Celebrity;
		Console.Write("Enter a color");
		color = Console.Readline();
		Console.Write("Enter a Plural Noun");
		pluralNoun = Console.Readline();
		Console.Write("Enter a Celebrity");
		Celebrity = Console.Readline();



		// the project lets the user puts 3 wrods a build a poem
		Console.WriteLine("Roses are"+color)// lets user select a colour 
		Console.WriteLine(pluralNoun+" are blue ");
		Console.WriteLine("I love"+Celebrity);
	}
}
