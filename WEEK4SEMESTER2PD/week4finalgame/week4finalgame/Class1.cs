using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4finalgame
{
    public class Player
    {
        public int xaxis;
        public int yaxis;
        public string direction = "";
        public static char enemy_body_part = (char)219;
        public static char leg = ')';
        public static char playermouth = '>';
        public char[,] player = new char[,] { { leg, enemy_body_part, enemy_body_part, '-', playermouth } };
        public Player(int xaxis, int yaxis)
        {
            this.xaxis = xaxis;
            this.yaxis = yaxis;
        }
        public void produce_player(char[,] maze)
        {
            Console.SetCursorPosition(xaxis, yaxis);
            for (int i = 0; i < 1; i++)
            {
                for (int n = 0; n < 5; n++)
                {
                    maze[yaxis, xaxis + n] = player[i, n];
                    Console.Write(player[i, n]);
                }
            }
        }
        public void eraseplayer(char[,] maze)
        {
            Console.SetCursorPosition(xaxis, yaxis);
            for (int n = 0; n < 5; n++)
            {
                maze[yaxis, xaxis + n] = ' ';
                Console.Write(' ');
            }
        }
        public void movePlayerUp(char[,] maze)
        {
            char next = maze[yaxis - 1, xaxis];
            if (next == ' ')
            {
                eraseplayer(maze);
                yaxis = yaxis - 1;
                produce_player(maze);
            }
        }
        public void movePlayerLeft(char[,] maze)
        {
            char next = maze[yaxis, xaxis - 1];
            if (next == ' ')
            {
                eraseplayer(maze);
                xaxis = xaxis - 1;
                produce_player(maze);
            }
        }
        public void movePlayerRight(char[,] maze)
        {
            char next = maze[yaxis, xaxis + 5];
            if (next == ' ')
            {
                eraseplayer(maze);
                xaxis = xaxis + 1;
                produce_player(maze);

            }
        }
        public void movePlayerDown(char[,] maze)
        {
            char next = maze[yaxis + 1, xaxis];
            if (next == ' ')
            {
                eraseplayer(maze);
                yaxis = yaxis + 1;
                produce_player(maze);
            }

        }
        public Bullet generateBullet()
        {
            Bullet bullet = new Bullet(xaxis + 5, yaxis, direction);
            return bullet;
        }
        public void printBullet(char[,] maze)
        {
            Console.SetCursorPosition(xaxis + 5, yaxis);
            maze[yaxis, xaxis + 5] = '*';
            Console.Write("*");
        }
    }

}
