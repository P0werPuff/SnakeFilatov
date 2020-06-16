﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SnakeFilatov
{
	class Snake : Figure
	{
		Direction direction;
		public int score;

		public Snake(point tail, int length, Direction _direction)
		{
			direction = _direction;
			pList = new List<point>();
			for (int i = 0; i < length; i++)
			{
				point p = new point(tail);
				p.Move(i, direction);
				pList.Add(p);
			}
			score = 0;
		}

		public void Move()
		{
			point tail = pList.First();
			pList.Remove(tail);
			point head = GetNextPoint();
			pList.Add(head);

			tail.Clear();
			head.draw();
		}

		public point GetNextPoint()
		{
			point head = pList.Last();
			point nextPoint = new point(head);
			nextPoint.Move(1, direction);
			return nextPoint;
		}

		public bool IsHitTail()
		{
			var head = pList.Last();
			for (int i = 0; i < pList.Count - 2; i++)
			{
				if (head.IsHit(pList[i]))
					return true;
			}
			return false;
		}

		public void HandleKey(ConsoleKey key)
		{
			if (key == ConsoleKey.LeftArrow)
				direction = Direction.LEFT;
			else if (key == ConsoleKey.RightArrow)
				direction = Direction.RIGHT;
			else if (key == ConsoleKey.DownArrow)
				direction = Direction.DOWN;
			else if (key == ConsoleKey.UpArrow)
				direction = Direction.UP;
		}

		public bool Eat(point food)
		{
			point head = GetNextPoint();
			if (head.IsHit(food))
			{
				food.sym = head.sym;
				pList.Add(food);
				score++;
				return true;
			}
			else
				return false;
		}
	}
}