using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Media;
using WMPLib;
using System.IO;
using System.IO.Ports;
using System.Security.Cryptography.X509Certificates;

namespace SnakeFilatov
{
	class GameOverSnake
	{
		public void WriteGameOver(string name, int score)
		{


			Params settings = new Params();
			Sounds sound2 = new Sounds(settings.GetResourceFolder());
			sound2.PlayNo();
			Random rnd = new Random();
			int xOffset = 25;
			int yOffset = 8;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(xOffset, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
			yOffset++;
			WriteText("Автор: Илья Филатов", xOffset + 2, yOffset++);
			WriteText("Сделано в Эстонии", xOffset + 5, yOffset++);
			WriteText("   Ваш результат: " + score, xOffset + 2, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			Console.WriteLine(score);
			using (var file = new StreamWriter("score.txt", true))
			{
				file.WriteLine("Name: " + name + " | Score:" + score);
				file.Close();
			}
		}

		public void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}
	}
}