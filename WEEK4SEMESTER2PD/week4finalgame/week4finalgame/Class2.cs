using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4finalgame
{
    public class Enemy
    {
        public int xaxis;
        public int yaxis;
        public string enemydirection;
        public static char enemy_body_part = (char)219;
        public static char enemy_mouth_part = '+';
        public static char enemy_tail = '~';
        public char[,] enemy = new char[,] { { enemy_mouth_part, enemy_mouth_part, enemy_body_part, enemy_body_part, enemy_tail } };
        public int i = 1;
        public int n = 1;

        public Enemy(int xaxis, int yaxis, string enemydirection)
        {
            this.xaxis = xaxis;
            this.yaxis = yaxis;
            this.enemydirection = enemydirection;
        }
        public void print_enemy(char[,] maze)
        {
            Console.SetCursorPosition(xaxis, yaxis);
            for (int i = 0; i < 1; i++)
            {
                for (int n = 0; n < 5; n++)
                {
                    maze[yaxis, xaxis + n] = enemy[i, n];
                    Console.Write(enemy[i, n]);
                }
            }
        }
        public void moveEnemy(char[,] maze)
        {
            if (enemydirection == "up")
            {

                char next = maze[yaxis - 1, xaxis];
                if (next == ' ')
                {
                    erase_enemy(maze);
                    yaxis--;
                    print_enemy(maze);
                }
                if (next == '#')
                {
                    enemydirection = "down";
                    verticalenemycoordinate(maze);
                    print_enemy(maze);
                }
            }
            if (enemydirection == "down")
            {
                char next = maze[yaxis + 1, xaxis];
                if (next == ' ')
                {
                    erase_enemy(maze);
                    yaxis++;
                    print_enemy(maze);
                }
                if (next == '#')
                {
                    enemydirection = "up";
                    erase_enemy(maze);
                    for (; i < 4; i++)
                    {
                        if (i >= 3)
                        {
                            i = 1;
                        }
                        if (!(xaxis + i + i * i > 113))
                        {
                            char nextch = maze[yaxis, xaxis + i + i * i];

                            if (nextch == ' ')
                            {
                                xaxis = xaxis + i + i * i;
                                break;
                            }
                        }
                        else
                        {
                            xaxis = 100;
                            int helper = xaxis;
                            char nextch = maze[yaxis, xaxis];

                            if (nextch == ' ')
                            {
                                char bata;
                                for (int n = 0; n < 5; n++)
                                {
                                    bata = maze[helper, yaxis];
                                    bata = maze[yaxis, xaxis];
                                    if (bata == ' ')
                                    {
                                        helper++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                            xaxis = 95;
                            break;
                        }
                    }
                    print_enemy(maze);
                }
            }
            if (enemydirection == "left")
            {
                char next = maze[yaxis, xaxis - 1];
                if (next == ' ')
                {
                    erase_enemy(maze);
                    xaxis--;
                    print_enemy(maze);
                }
                if (next == enemy_tail || next == enemy_mouth_part)
                {
                    erase_enemy(maze);
                    xaxis--;
                    yaxis--;
                    print_enemy(maze);
                }
                if (next == '#')
                {
                    enemydirection = "right";
                    horizontalenemycoordinate(maze);
                }
            }
            if (enemydirection == "right")
            {
                erase_enemy(maze);
                xaxis++;
                reverse_enemy(maze);
                char next = maze[yaxis, xaxis + 6];

                if (next == enemy_tail || next == enemy_mouth_part)
                {
                    erase_enemy(maze);
                    xaxis++;
                    yaxis++;
                    reverse_enemy(maze);
                }
                if (next == '#')
                {
                    enemydirection = "left";
                    erase_enemy(maze);

                    for (; i < 4; i++)
                    {
                        if (i >= 3)
                        {
                            i = 1;
                        }
                        if (!(yaxis + i + i * i > 14))
                        {
                            char nextch = maze[yaxis + i + i * i, xaxis];
                            if (nextch == ' ')
                            {
                                yaxis = yaxis + i + i * i;
                                break;
                            }
                        }
                        else
                        {
                            yaxis = 6;
                            break;
                        }
                    }

                    print_enemy(maze);
                }
            }
        }
        public void erase_enemy(char[,] maze)
        {
            Console.SetCursorPosition(xaxis, yaxis);
            for (int n = 0; n < 5; n++)
            {
                maze[yaxis, xaxis + n] = ' ';
                Console.Write(" ");
            }
        }
        public void verticalenemycoordinate(char[,] maze)
        {
            erase_enemy(maze);
            for (; n < 4; n++)
            {
                if (n >= 3)
                {
                    n = 1;
                }
                char next = maze[yaxis, xaxis - n - n];
                if (next == ' ')
                {
                    xaxis = xaxis - n - n;
                    break;
                }
            }
        }
        public void horizontalenemycoordinate(char[,] maze)
        {
            erase_enemy(maze);
            for (; n < 3; n++)
            {
                if (n >= 2)
                {
                    n = 1;
                }
                yaxis = yaxis - n - n;
                break;
            }
        }
        public void reverse_enemy(char[,] maze)
        {
            int m = 0;
            Console.SetCursorPosition(xaxis, yaxis);
            for (int i = 0; i < 1; i++)
            {
                for (int n = 4; n >= 0; n--)
                {
                    maze[yaxis, xaxis + m] = enemy[i, n];
                    Console.Write(enemy[i, n]);
                    m++;
                }
            }
        }
        public Bullet generateBullet(char[,] maze)
        {
            if (enemydirection == "left" || enemydirection == "up" || enemydirection == "down")
            {
                Bullet bullet = new Bullet(xaxis - 1, yaxis, enemydirection);
                Console.SetCursorPosition(xaxis - 1, yaxis);
                maze[yaxis, xaxis - 1] = '@';
                Console.Write("@");
                return bullet;
            }
            if (enemydirection == "right")
            {
                Bullet bullet = new Bullet(xaxis + 5, yaxis, enemydirection);
                Console.SetCursorPosition(xaxis + 5, yaxis);
                maze[yaxis, xaxis + 5] = '@';
                Console.Write("@");
                return bullet;
            }
            return null;
        }
    }
}
