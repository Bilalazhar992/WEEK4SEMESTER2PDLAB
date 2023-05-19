using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EZInput;
using System.Threading;

namespace week4finalgame
{
    class Program
    {
        static char[,] maze = new char[,] {
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
        { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
            };

        // FOR PRODUCTING VARIATION IN SPEED OF TWO DIFFERENT ENEMIES
        static int helper = 20;
        static int helper1 = 10;
        static int timer1 = 1;

        // HEALTH RELEVENT

        static int life = 3;
        static char heart = '*';

        // INTERESTING USE
        static int timer = 0;
        static int verticalx=0;
        static int verticaly = 0;
        static int horizontalx = 0;
        static int horizontaly = 0;


        // SCORE RELEVANT FUCTIONS
        static int score = 0;
        static void Main(string[] args)
        {
            List<Enemy> enemies = new List<Enemy>();
            List<Bullet> bullets = new List<Bullet>();
            int no_of_horizontal_enemies = 2;
            int no_of_vertical_enemies = 1;
            Player player = PlayerCoordinates();
            for (int i = 0; i < no_of_horizontal_enemies; i++)
            {
                enemies.Add(HorizontalEnemyCoordinates());
                if (horizontaly >= 5)
                {
                    horizontaly = -8;
                }
                if (horizontalx >= 30)
                {
                    horizontalx = -10;
                }
            }
            for (int i = 0; i < no_of_vertical_enemies; i++)
            {
                enemies.Add(VerticalEnemyCoordinates());
                if (verticaly >= 12)
                {
                    verticaly = 0;
                }
                if (verticalx >= 12)
                {
                    verticalx = -10;
                }
            }
            string enter_option;
           logo();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("                                      LOADING");
            for (int x = 0; x < 5; x++)
            {
                Console.Write(".");
                Thread.Sleep(500);
            }
            string madad = "B";
            while (madad != "EXIT")
            {
                setUp();
                string madad1 = "B";
                enter_option = main_menu();
                if (enter_option == "1")
                {
                    break;
                }
                if (enter_option == "2")
                {
                    string enter_option2;
                    while (madad1 != "Exit")
                    {
                        setUp();
                        enter_option2 = option();
                        if (enter_option2 == "1")
                        {
                            keys();
                        }
                        if (enter_option2 == "2")
                        {
                            instruction();
                        }
                        if (enter_option2 == "3")
                        {
                            madad1 = "Exit";
                        }
                    }
                }
            }
            Console.Clear();
            print_maze();
            player.produce_player(maze);
            foreach (Enemy enemy in enemies)
            {
                enemy.print_enemy(maze);
            }
            while (true)
            {
                printscore();
                life_status();
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    player.movePlayerUp(maze);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    player.movePlayerLeft(maze);
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    player.movePlayerRight(maze);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    player.movePlayerDown(maze);
                }
                if (Keyboard.IsKeyPressed(Key.Space))
                {
                    bullets.Add(player.generateBullet());
                    player.printBullet(maze);
                }
                if (timer == 2)
                {
                    for (int i = 1; i < enemies.Count; i++)
                    {
                        enemies[i].moveEnemy(maze);
                    }
                    timer = 0;
                }
                
                if (timer1 == 1)
                {
                       
                 enemies[0].moveEnemy(maze);
                  timer1 = 0;
                }
                
                if (helper == 20)
                {
                    foreach (Enemy enemy in enemies)
                    {
                        bullets.Add(enemy.generateBullet(maze));
                    }
              
                    helper = 0;
                }

                if (helper1 == 5)
                {
                    bullets.Add(enemies[0].generateBullet(maze));

                    helper1 = 0;
                }
                foreach (Bullet bullet in bullets)
                {
                    if(bullet.direction=="")
                    {
                        bullet.movebullet(maze);
                        score = 5 * bullet.bulletColosionWithEnemy(enemies, maze);
                    }
                    else
                    {
                       
                        if ( bullet.bullety == enemies[0].yaxis)
                        {
                            
                            bullet.bulletCollisionWithplayerbyfastenemy(maze, ref life);

                            for (int i = 0; i < 2; i++)
                            {
                                bullet.movebullet(maze);
                                
                            }

                        }
                        else
                        {
                            bullet.bulletCollisionWithplayerbyenemy(maze, ref life);
                            bullet.movebullet(maze);
                        }
                        

                    }
                }
                helper++;
                helper1++;
                timer++;
                timer1++;
                
                Thread.Sleep(5);
                if (life <= 0)
                {
                    break;
                }

            }
            Console.SetCursorPosition(21, 21);
            Console.Write("0");
            Console.SetCursorPosition(15, 25);
            Console.WriteLine("GAME OVER ");
        }
        static Player PlayerCoordinates()
        {
            int xaxis = 15;
            int yaxis = 5;
            Player player = new Player(xaxis, yaxis);
            return player;
        }
        static Enemy VerticalEnemyCoordinates()
        {
            int xaxis = 100+verticalx;
            int yaxis = 3+verticaly;
            string enemy1direction = "up";
            Enemy enemy = new Enemy(xaxis, yaxis, enemy1direction);
            verticaly = verticaly + 1;
            verticalx = verticalx + 3;
            return enemy;
        }
        static Enemy HorizontalEnemyCoordinates()
        {
            int xaxis = 80+horizontalx;
            int yaxis = 12+horizontaly;
            string enemy2direction = "left";
            Enemy enemy = new Enemy(xaxis, yaxis, enemy2direction);
            horizontaly = horizontaly + 1;
            horizontalx = horizontalx + 3;
            return enemy;
        }
        static void logo()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                                  :--       ");
            Console.WriteLine("                                                .=+*###%    ");
            Console.WriteLine("                                              -*#****##*    ");
            Console.WriteLine("                                            -#*=-=+*#%%=    ");
            Console.WriteLine("                                          :##=.:++**#%%=    ");
            Console.WriteLine("                                         -##+-=*****#%%#     ");
            Console.WriteLine("                                        -%#*+*******#%%%-    ");
            Console.WriteLine("                              .:--===+++#############%%%#    ");
            Console.WriteLine("                           :+#%#*+=---=++**#####%%###%%%%.   ");
            Console.WriteLine("                        :+%%*-..:-*****+++*****###%%%%%%%+   ");
            Console.WriteLine("                     .=####* .+*+::##**************##%%%%%+:  ");
            Console.WriteLine("                  -+*##***#-.=%@@%:*######****#%##****##%%%%#=:      ..............       ");
            Console.WriteLine("               :+#+==+++***#-=#@#=:.    .:+##**%%%@%%****##%%%#=.:....        .....::::   ");
            Console.WriteLine("            .=*+-:-=+*****##%*-          ...=##%%#@%%%****+=:.              ..::::::..    ");
            Console.WriteLine("          -**+===****######*#.             ...=#%#@%%%#+:...             .::---:..        ");
            Console.WriteLine("        -******++==--:..... :              .....:+*#%*:....          ..:----:.            ");
            Console.WriteLine("      :###*+-.. ...  .......            .-::%.. ....-:....        ..:--=--:               ");
            Console.WriteLine("     =%#=:...                       ..=-:%%##.     ..:....     ..::--==-:                 ");
            Console.WriteLine("    :%-...                       .:=+-*@@@@*::      ...........::--==:=.                  ");
            Console.WriteLine("    *=. .                     .:--::#@@@@@#*=:           .....::::::=#@:                  ");
            Console.WriteLine("    #..                    ...: :+@@@@@@@%+#*-            ......:**#%%%+                  ");
            Console.WriteLine("    ::.::......       .....-.---+#@@@@@##%##=:.              ... +**#%##                  ");
            Console.WriteLine("      .:::::-------------::-:: :=%%%#@#+#%#*+=:              .....**#%##                  ");
            Console.WriteLine("           ....................::....-###%#*-:. .              .. **#%%*                  ");
            Console.WriteLine("                             ..     .::#+++:.:  :..             . +##%%=                  ");
            Console.WriteLine("                           .:. ..:-----:-.--: :::.              . *#%%%                   ");
            Console.WriteLine("                          :..:----:....:::.::-:-..              ..##%%.                   ");
            Console.WriteLine("                         .:::..           :+*+*#:.               =#%%-                    ");
            Console.WriteLine("                                            ****+               .#%%+                     ");
            Console.WriteLine("                                            :#***               +%@+                      ");
            Console.WriteLine("                                             #**+              :%%-                       ");
            Console.WriteLine("                                            .#**:             :#*.                        ");
            Console.WriteLine("           =*#%%%###*+=-:                   =**+            .-%=                          ");
            Console.WriteLine("          =**%%####***+++**++-:            :#*+.          ..:-                            ");
            Console.WriteLine("              :=*%%##**++=:::=###=.       -#*=.          .::                              ");
            Console.WriteLine("                 .+%%%#***+++==**###+.  .+##=..        ...                                ");
            Console.WriteLine("                    =%%%#*********###%*%###:..     ..:.                                   ");
            Console.WriteLine("                     :*%%%##******########:..  .....                                      ");
            Console.WriteLine("                       -#%%%###********##=..:...                                          ");
            Console.WriteLine("                         -+*#####**++**##*                                                ");
            Console.WriteLine("                             *%##*+==*#%+                                                 ");
            Console.WriteLine("                            -%%#**=-=#*:                                                  ");
            Console.WriteLine("                            #%##*+-=**                                                    ");
            Console.WriteLine("                           +%%#*****-                                                     ");
            Console.WriteLine("                          -%%##*##-                                                       ");
            Console.WriteLine("                          #%%#%#+                                                         ");
            Console.WriteLine("                         :=+=-.                                                           ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        static void header()
        {
            Console.WriteLine("      _____ _____ _____ _____ _____ _____ _____ __       _____ _____    _ _ _ _____ _____ _____ _____   ");
            Console.WriteLine("     |   __|  |  | __  |  |  |     |  |  |  _  |  |     |     |   | |  | | | |  _  |_   _|   __| __  |   ");
            Console.WriteLine("     |__   |  |  |    -|  |  |-   -|  |  |     |  |__   |-   -| | | |  | | | |     | | | |   __|    -|        ");
            Console.WriteLine("     |_____|_____|__|__|\\___/|_____|\\___/|__|__|_____|  |_____|_|___|  |_____|__|__| |_| |_____|__|__|    ");
        }
        static string option()
        {
            string choice;
            Console.WriteLine("-------------------------------------------OPTIONS--------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("1-KEY");
            Console.WriteLine("2-INSTRUCTIONS");
            Console.WriteLine("3-EXIT");
            Console.WriteLine("Enter your choice here:  ");
            choice = Console.ReadLine();
            return choice;
        }
        static void keys()
        {
            Console.WriteLine("---------------------------------------------------------------KEYS-------------------------------------------------");
            Console.WriteLine("1-UP                                GO UP");
            Console.WriteLine("1-DOWN                              GO DOWN");
            Console.WriteLine("1-RIGHT                             GO RIGHT");
            Console.WriteLine("1-LEFT                              GO LEFT");
            Console.WriteLine("1-SPACE                             FIRE FROM PLAYER");
            Console.WriteLine("PRESS ANY KEY TO CONTINUE ");
            Console.ReadKey();
        }
        static void instruction()
        {
            Console.WriteLine("OUR GOAL IS TO MAKE AS ALIVE IN THAT TROUBLE AND FOR THIS WE HAVE TO KILL ALL THESE SHARKS ");
            Console.WriteLine("PRESS ANY KEY TO CONTINUE ");
            Console.ReadKey();
        }
        static void setUp()
        {
            Console.Clear();
            header();
            Console.WriteLine();
            Console.WriteLine();
        }
        static string main_menu()
        {
            string choice;
            Console.WriteLine("-------------------------------------------MAIN MENU--------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("1-START");
            Console.WriteLine("2-OPTIONS");
            Console.Write("Enter your choice here:  ");
            choice = Console.ReadLine();
            return choice;
        }
        static void print_maze()
        {
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 115; j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void printscore()
        {
            Console.SetCursorPosition(5, 20);
            Console.WriteLine("Score: " + score);
        }
        static void life_status()
        {
            Console.SetCursorPosition(5, 21);
            Console.Write("Lives Remaining: ");
            for (int i = 1; i >= 1; i--)
            {
                Console.Write(life + " " + heart);
            }
        }
    }
}
