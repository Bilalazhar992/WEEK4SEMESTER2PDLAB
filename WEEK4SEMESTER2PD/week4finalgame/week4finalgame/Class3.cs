using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4finalgame
{
    public class Bullet
    {
        public int m = 0;
        public static int score = 0;
        public bool isBulletActive = true;
        public int bulletx;
        public int bullety;
        public string direction;
        public Bullet(int bulletx, int bullety, string direction)
        {
            this.bulletx = bulletx;
            this.bullety = bullety;
            this.direction = direction;
        }
        public void movebullet(char[,] maze)
        {
            if (isBulletActive == true)
            {
                if (direction == "left" || direction=="up" || direction=="down")
                {
                    if (bulletx > 0)
                    {
                        char next = maze[bullety, bulletx - 1];

                        if (next == ' ')
                        {
                            eraseBullet(maze);
                            bulletx = bulletx - 1;
                            printBullet(maze);
                            
                        }
                        else
                        {
                            eraseBullet(maze);
                            makeBulletInactive();

                        }
                    }

                }
                if (direction == "right"  || direction == "")
                {
                    if (bulletx < 114)
                    {
                        char next = maze[bullety, bulletx + 1];

                        if (next == ' ')
                        {
                            eraseBullet(maze);
                            bulletx = bulletx + 1;
                            if(direction=="right")
                            {
                                printBullet(maze);
                            }
                            else if (direction == "")
                            {
                                printPlayerBullet(maze);
                            }


                        }
                        else
                        {
                            eraseBullet(maze);
                            makeBulletInactive();
                        }
                    }

                }
            }
        }
        public void eraseBullet(char[,] maze)
        {
            Console.SetCursorPosition(bulletx, bullety);
            maze[bullety, bulletx] = ' ';
            Console.Write(" ");
        }
        public void printPlayerBullet(char[,] maze)
        {
            Console.SetCursorPosition(bulletx, bullety);
            maze[bullety, bulletx] = '*';
            Console.Write("*");
        }
        public void printBullet(char[,] maze)
        {
            Console.SetCursorPosition(bulletx, bullety);
            maze[bullety, bulletx] = '*';
            Console.Write("@");
        }
        public void makeBulletInactive()
        {
            isBulletActive = false;
        }
        public int bulletColosionWithEnemy(List<Enemy>enemies, char[,] maze)
        {
            if (isBulletActive == true)
            {
                foreach(Enemy enemy in enemies)
                {
                    if(bulletx+1==enemy.xaxis&& bullety+1 == enemy.yaxis)
                    {
                        score++;
                        enemy.erase_enemy(maze);
                        enemy.xaxis = 80;
                        enemy.yaxis = 15 - m;
                        enemy.print_enemy(maze);
                    }
                    m++;
                    if (m > 5)
                    {
                        m = 0;
                    }
                }
                
                
            }
            return score;
        }
        public void bulletCollisionWithplayerbyenemy(char[,] maze, ref int life)
        {
            if (isBulletActive == true)
            {
                if (direction == "left" || direction == "up" ||  direction == "down")
                {
                    if (bulletx > 0)
                    {
                        char next = maze[bullety, bulletx - 1];

                        if (next == '>')
                        {
                            life--;
                            
                        }
                    }

                }
                if (bulletx < 114)
                {
                    if (direction == "right")
                    {
                        char next = maze[bullety, bulletx + 1];

                        if (next == ')')
                        {
                            life--;
                            
                        }
                    }
                }

            }
        }
        public void bulletCollisionWithplayerbyfastenemy(char[,] maze, ref int life)
        {
            if (isBulletActive == true)
            {
                if (direction == "left")
                {
                    if (bulletx > 1)
                    {
                        char next = maze[bullety, bulletx - 1];
                        char next1 = maze[bullety, bulletx - 2];
                        if ((next == '>' || next1 == '>'))
                        {
                            life--;
                        }
                    }

                }
                if (direction == "right")
                {
                    if (bulletx <= 113)
                    {
                        char next = maze[bullety, bulletx + 1];
                        char next1 = maze[bullety, bulletx + 2];
                        if ((next == ')' || next1 == ')'))
                        {
                            life--;
                        }
                    }

                }
            }
        }

    }

}
