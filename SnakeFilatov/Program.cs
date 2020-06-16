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
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Напиши свое имя: ");
			string name = Console.ReadLine();

			Console.SetWindowSize(80, 27);

			Walls walls = new Walls(80, 25);
			walls.draw();

			// Отрисовка точек			
			point p = new point(4, 5, '*');
			Snake snake = new Snake(p, 4, Direction.RIGHT);
			snake.Drow();

			FoodCreator foodCreator = new FoodCreator(80, 25, '@');
			point food = foodCreator.CreateFood();
			food.draw();

			Params settings = new Params();
			Sounds sound = new Sounds(settings.GetResourceFolder());
			sound.Play();



			Sounds sound1 = new Sounds(settings.GetResourceFolder());
			while (true)
			{
				if (walls.IsHit(snake) || snake.IsHitTail())
				{
					break;
				}
				if (snake.Eat(food))
				{
					Score ScoreGame = new Score();
					ScoreGame.ScoreInGame(snake.score);
					food = foodCreator.CreateFood();
					food.draw();
					sound1.PlayEat();

				}
				else
				{
					snake.Move();
				}

				Thread.Sleep(100);
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HandleKey(key.Key);
				}
			}
			sound.Stop();
			GameOverSnake GameOver = new GameOverSnake();
			GameOver.WriteGameOver(name, snake.score);
			Console.ReadLine();

		}
	}
}