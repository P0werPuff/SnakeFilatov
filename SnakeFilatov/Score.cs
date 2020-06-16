using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Media;
using WMPLib;
using System.IO;
using System.IO.Ports;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics.Eventing.Reader;

namespace SnakeFilatov
{
	class Score
	{
		public void ScoreInGame(int score)
		{

			int xOffset = 0;
			int yOffset = 25;
			Console.SetCursorPosition(xOffset, yOffset);
			WriteText("Очки: " + score, xOffset, yOffset);

		}

		public void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}

	}
}