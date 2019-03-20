using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
        }
        public struct eci
        {
            public int step;
            public int age;
            public int hunger;
            public string Kind;
            public int time_of_death;
            public int budding_time;
        };
        public eci[,] klet = new eci[100, 100];
        public eci pureKlet;
        public eci born_fish;
        public eci born_Shark;
        int cd = 0;

        Random rand = new Random();
        int stepg=0;// Переменная счетчик хода.
        int[] ranmas = new int[8];// массив для выбора куда ходить вода.
        int[] ranmasak = new int[8];// массив для выбора куда ходить рыбка.
       // int Pprmas;
        int m = 50; // граница
        int sum = 1;
        int t,x,y;
        //int time_of_death_random;
        int temp;// Переменная для результатов рандома хода.
        int inival;
       // int inival1;
        private void Form1_Load(object sender, EventArgs e)
        {

            pureKlet.time_of_death = 0;
            pureKlet.budding_time = 0;
            pureKlet.age = 0;
            pureKlet.hunger = 0;
            pureKlet.step = 0;
            pureKlet.Kind = "Water";

            born_fish.age = 0;
            born_fish.hunger = 0;

            born_fish.Kind = "fish";
            born_fish.step = 0;

            born_Shark.age = 0;
            born_Shark.hunger = 0;

			
            born_Shark.Kind = "Shark";
            born_Shark.step = 0;

            for (int u = 0; u < 100; u++)
            {
                for (int k = 0; k < 100; k++)
                {
                    inival = rand.Next(99);              

                     if ((inival>= 98))
                       {
                        born_Shark.time_of_death = rand.Next(100,220 );
                        born_Shark.budding_time = rand.Next(50, 200);
                        klet[u, k] = born_Shark;
                       }
                       else
                       if ((inival>=20)&&(inival<98))
                       {
                        born_fish.time_of_death = rand.Next(50, 80);
                        born_fish.budding_time = rand.Next(10, 20);
                        klet[u, k] = born_fish;
                       }
                       else
                       {
                           klet[u,k] = pureKlet;
                       }
                }
            }



            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int c = 0;
            int c1 = 0;
             for (int u = 0; u < 100; u++)
            {
                for (int k = 0; k < 100; k++)
                {
                    

                    if (klet[u, k].Kind == born_fish.Kind)
                        c1 = c1 + 1;
                    if (klet[u, k].Kind == born_Shark.Kind)
                        c = c + 1;
                      

                }
     
            string file111111 = @"C:\\labamat\\laba2\\labatest1.txt";
            StreamWriter writer111111 = new StreamWriter(file111111, true, System.Text.Encoding.Default);
            writer111111.Write(cd.ToString() + " ");
            writer111111.Close();

            string file1111 = @"C:\\labamat\\laba2\\labatest1.txt";
            StreamWriter writer1111 = new StreamWriter(file1111, true, System.Text.Encoding.Default);
            writer1111.Write(c.ToString() + " ");
            writer1111.Close();

            string file1115 = @"C:\\labamat\\laba2\\labatest1.txt";
            StreamWriter writer1115 = new StreamWriter(file1115, true, System.Text.Encoding.Default);
            writer1115.Write(c1.ToString() + " ");
            writer1115.Close();
            cd = cd + 1;

            string file11111 = @"C:\\labamat\\laba2\\labatest1.txt";
            StreamWriter writer11111 = new StreamWriter(file11111, true, System.Text.Encoding.Default);
            writer11111.WriteLine();
            writer11111.Close();

          

            for (int u = 0; u < 100; u++)//1 u<2
            {
                for (int k = 0; k < 100; k++)
                {
                   /* for (int mi = 0; mi < 8; mi++)
                    {
                        ranmas[mi] = 0;
                    }
                    for (int mi = 0; mi < 8; mi++)
                    {
                        ranmasak[mi] = 0;
                    }*/
                    if ((klet[u, k].Kind == born_fish.Kind) && (klet[u, k].step == stepg))
                    {
                        if (klet[u, k].time_of_death == klet[u, k].age)
                        {
                            klet[u, k] = pureKlet;
                        }
                        else
                        {

                            klet[u, k].step = klet[u, k].step + 1;// Переменная для определения шага в данный момент.
                            klet[u, k].age = klet[u, k].age + 1;
                            int a = 0;
                            temp = 0;
                            
                            if (klet[(u - 1 + m) % m, (k + 1 + m) % m].Kind == pureKlet.Kind)
                            {
                                ranmas[a] = 0;
                                a++;
                            }
                            if (klet[(u + m) % m, (k + 1 + m) % m].Kind == pureKlet.Kind)
                            {
                                ranmas[a] = 1;
                                a++;
                            }
                            if (klet[(u + 1 + m) % m, (k + 1 + m) % m].Kind == pureKlet.Kind)//
                            {
                                ranmas[a] = 2;
                                a++;
                            }
                            if (klet[(u - 1 + m) % m, (k + m) % m].Kind == pureKlet.Kind)
                            {
                                ranmas[a] = 3;
                                a++;
                            }
                            if (klet[(u + 1 + m) % m, (k + m) % m].Kind == pureKlet.Kind)
                            {
                                ranmas[a] = 4;
                                a++;
                            }
                            if (klet[(u - 1 + m) % m, (k - 1 + m) % m].Kind == pureKlet.Kind)
                            {
                                ranmas[a] = 5;
                                a++;
                            }
                            if (klet[(u + m) % m, (k - 1 + m) % m].Kind == pureKlet.Kind)
                            {
                                ranmas[a] = 6;
                                a++;
                            }
                            if (klet[(u + 1 + m) % m, (k- 1 + m) % m].Kind == pureKlet.Kind)//
                            {
                                ranmas[a] = 7;
                                a++;
                            }
                           

                            if (a > 0)
                            {
                                temp = ranmas[rand.Next(a)];// Рандомим значение элементов массива, в массиве содержатся номера ечеек с морем.
                                switch (temp)
                                {
                                    case 0: // 1-ая клетка слева снизу

                                        klet[(u - 1 + m) % m, (k + 1 + m) % m] = klet[u, k];
                                        if (klet[u, k].budding_time == klet[u, k].age)
                                        {
                                            born_fish.time_of_death = rand.Next(50, 80);
                                            born_fish.budding_time = rand.Next(10, 20);
                                            klet[u, k] = born_fish;
                                            klet[(u - 1 + m) % m, (k + 1 + m) % m].budding_time= rand.Next(klet[(u - 1 + m) % m, (k + 1 + m) % m].age, 50);
                                        }
                                        else
                                        {
                                            klet[u, k] = pureKlet;
                                        }
                                        break;

                                    case 1: // клетка по середине снизу 

                                        klet[(u + m) % m, (k + 1 + m) % m] = klet[u, k];
                                        if (klet[u, k].budding_time == klet[u, k].age)
                                        {
                                            born_fish.time_of_death = rand.Next(50, 80);
                                            born_fish.budding_time = rand.Next(10, 20);
                                            klet[u, k] = born_fish;
                                            klet[(u + m) % m, (k + 1 + m) % m].budding_time = rand.Next(klet[(u + m) % m, (k + 1 + m) % m].age, 50);
                                        }
                                        else
                                        {
                                            klet[u, k] = pureKlet;
                                        }
                                        break;

                                    case 2:


                                        klet[(u + 1 + m) % m, (k + 1+m)%m] = klet[u, k];
                                        if (klet[u, k].budding_time == klet[u, k].age)
                                        {
                                            born_fish.time_of_death = rand.Next(50, 80);
                                            born_fish.budding_time = rand.Next(10, 20);
                                            klet[u, k] = born_fish;
                                            klet[(u + 1 + m) % m, (k + 1 + m) % m].budding_time = rand.Next(klet[(u + 1 + m) % m, (k + 1 + m) % m].age, 50);
                                        }
                                        else
                                        {
                                            klet[u, k] = pureKlet;
                                        }
                                        break;

                                    case 3:

                                        klet[(u - 1 + m) % m, (k + m) % m] = klet[u, k];
                                        if (klet[u, k].budding_time == klet[u, k].age)
                                        {
                                            born_fish.time_of_death = rand.Next(50, 80);
                                            born_fish.budding_time = rand.Next(10, 20);
                                            klet[u, k] = born_fish;
                                            klet[(u - 1 + m) % m, (k + m) % m].budding_time = rand.Next(klet[(u - 1 + m) % m, (k + m) % m].age, 50);
                                        }
                                        else
                                        {
                                            klet[u, k] = pureKlet;
                                        }
                                        break;

                                    case 4:


                                        klet[(u + 1 + m) % m, (k+ m)%m] = klet[u, k];
                                        if (klet[u, k].budding_time == klet[u, k].age)
                                        {
                                            born_fish.time_of_death = rand.Next(50, 80);
                                            born_fish.budding_time = rand.Next(10, 20);
                                            klet[u, k] = born_fish;
                                            klet[(u + 1 + m) % m, (k +m) % m].budding_time = rand.Next(klet[(u + 1 + m) % m, (k +m) % m].age, 50);
                                        }
                                        else
                                        {
                                            klet[u, k] = pureKlet;
                                        }
                                        break;

                                    case 5:

                                        klet[(u - 1 + m) % m, (k - 1 + m) % m] = klet[u, k];
                                        if (klet[u, k].budding_time == klet[u, k].age)
                                        {
                                            born_fish.time_of_death = rand.Next(50, 80);
                                            born_fish.budding_time = rand.Next(10, 20);
                                            klet[u, k] = born_fish;
                                            klet[(u - 1 + m) % m, (k - 1 + m) % m].budding_time = rand.Next(klet[(u - 1 + m) % m, (k - 1 + m) % m].age, 50);
                                        }
                                        else
                                        {
                                            klet[u, k] = pureKlet;
                                        }
                                        break;

                                    case 6:

                                        klet[(u + m)%m, (k - 1 + m) % m] = klet[u, k];
                                        if (klet[u, k].budding_time == klet[u, k].age)
                                        {
                                            born_fish.time_of_death = rand.Next(50, 80);
                                            born_fish.budding_time = rand.Next(10, 20);
                                            klet[u, k] = born_fish;
                                            klet[(u + m) % m, (k - 1 + m) % m].budding_time = rand.Next(klet[(u  + m) % m, (k - 1 + m) % m].age, 50);
                                        }
                                        else
                                        {
                                            klet[u, k] = pureKlet;
                                        }
                                        break;

                                    case 7:

                                        klet[(u + 1 + m) % m, (k - 1 + m) % m] = klet[u, k];
                                        if (klet[u, k].budding_time == klet[u, k].age)
                                        {
                                            born_fish.time_of_death = rand.Next(50, 80);
                                            born_fish.budding_time = rand.Next(10, 20);
                                            klet[u, k] = born_fish;
                                            klet[(u + 1 + m) % m, (k - 1 + m) % m].budding_time = rand.Next(klet[(u + 1 + m) % m, (k - 1 + m) % m].age, 50);
                                        }
                                        else
                                        {
                                            klet[u, k] = pureKlet;
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                klet[u, k] = klet[u, k];
                            }
                          
                        }
                    }
                    else
                   if ((klet[u, k].Kind == born_Shark.Kind) && (klet[u, k].step == stepg))
                    {
                        if ((klet[u, k].time_of_death == klet[u, k].age) || (klet[u, k].hunger >= 50))
                        {
                            klet[u, k] = pureKlet;
                        }
                        else
                        {

                            klet[u, k].hunger = klet[u, k].hunger + 1;
                            klet[u, k].step = klet[u, k].step + 1;// Переменная для определения шага в данный момент.
                            klet[u, k].age = klet[u, k].age + 1;
                            int a = 0;
                            int b=0;
                            temp = 0;

                            if (klet[(u - 1 + m) % m, (k + 1 + m) % m].Kind == pureKlet.Kind)
                            {
                                ranmas[a] = 0;
                                a++;
                            }
                            if (klet[(u + m) % m, (k + 1 + m) % m].Kind == pureKlet.Kind)
                            {
                                ranmas[a] = 1;
                                a++;
                            }
                            if (klet[(u + 1 + m) % m, (k + 1 + m) % m].Kind == pureKlet.Kind)
                            {
                                ranmas[a] = 2;
                                a++;
                            }
                            if (klet[(u - 1 + m) % m, (k + m) % m].Kind == pureKlet.Kind)
                            {
                                ranmas[a] = 3;
                                a++;
                            }
                            if (klet[(u + 1 + m) % m, (k + m) % m].Kind == pureKlet.Kind)
                            {
                                ranmas[a] = 4;
                                a++;
                            }
                            if (klet[(u - 1 + m) % m, (k - 1 + m) % m].Kind == pureKlet.Kind)
                            {
                                ranmas[a] = 5;
                                a++;
                            }
                            if (klet[(u + m) % m, (k - 1 + m) % m].Kind == pureKlet.Kind)
                            {
                                ranmas[a] = 6;
                                a++;
                            }
                            if (klet[(u + 1 + m) % m, (k - 1 + m) % m].Kind == pureKlet.Kind)
                            {
                                ranmas[a] = 7;
                                a++;
                            }

                            //if (klet[u, k].hunger >=5)
                            //{
                                if (klet[(u - 1 + m) % m, (k + 1 + m) % m].Kind == born_fish.Kind)
                                {
                                    ranmasak[b] = 0;
                                    b++;
                                }
                                if (klet[(u + m) % m, (k + 1 + m) % m].Kind == born_fish.Kind)
                                {
                                    ranmasak[b] = 1;
                                    b++;
                                }
                                if (klet[(u + 1 + m) % m, (k + 1 + m) % m].Kind == born_fish.Kind)
                                {
                                    ranmasak[b] = 2;
                                    b++;

                                }
                                if (klet[(u - 1 + m) % m, (k + m) % m].Kind == born_fish.Kind)
                                {
                                    ranmasak[b] = 3;
                                    b++;
                                }
                                if (klet[(u + 1 + m) % m, (k + m) % m].Kind == born_fish.Kind)
                                {
                                    ranmasak[b] = 4;
                                    b++;
                                }
                                if (klet[(u - 1 + m) % m, (k - 1 + m) % m].Kind == born_fish.Kind)
                                {
                                    ranmasak[b] = 5;
                                    b++;
                                }
                                if (klet[(u + m) % m, (k - 1 + m) % m].Kind == born_fish.Kind)
                                {
                                    ranmasak[b] = 6;
                                    b++;
                                }
                                if (klet[(u + 1 + m) % m, (k - 1 + m) % m].Kind == born_fish.Kind)
                                {
                                    ranmasak[b] = 7;
                                    b++;
                                }

                           // }

                            if(b>0)
                            {

                               
                                temp = ranmasak[rand.Next(b)];
                              //
                                switch (temp)
                                {
                                    case 0: // 1-ая клетка слева снизу
                                        klet[u, k].hunger = klet[u, k].hunger - 1;
                                        klet[(u - 1 + m)%m , (k + 1 + m) % m] = klet[u, k];
                                        if (klet[u, k].budding_time == klet[u, k].age)
                                        {
                                            born_Shark.time_of_death = rand.Next(100,220 );
                                            born_Shark.budding_time = rand.Next(50, 200);
                                            klet[u, k] = born_Shark;
                                            klet[(u - 1 + m) % m, (k + 1 + m) % m].budding_time = rand.Next(klet[(u - 1 + m) % m, (k + 1 + m) % m].age, 220);
                                        }
                                        else
                                        {
                                            klet[u, k] = pureKlet;
                                        }
                                        break;

                                    case 1: // клетка по середине снизу 
                                        klet[u, k].hunger = klet[u, k].hunger - 1;
                                        klet[(u + m) % m, (k + 1 + m) % m] = klet[u, k];
                                        if (klet[u, k].budding_time == klet[u, k].age)
                                        {
                                            born_Shark.time_of_death = rand.Next(100,220 );
                                            born_Shark.budding_time = rand.Next(50, 200);
                                            klet[u, k] = born_Shark;
                                            klet[(u + m) % m, (k + 1 + m) % m].budding_time = rand.Next(klet[(u + m) % m, (k + 1 + m) % m].age, 220);
                                        }
                                        else
                                        {
                                            klet[u, k] = pureKlet;
                                        }
                                        break;

                                    case 2:

                                        klet[u, k].hunger = klet[u, k].hunger - 1;
                                        klet[(u + 1 + m) % m, (k + 1+m)%m] = klet[u, k];
                                        if (klet[u, k].budding_time == klet[u, k].age)
                                        {
                                            born_Shark.time_of_death = rand.Next(100,220 );
                                            born_Shark.budding_time = rand.Next(50, 200);
                                            klet[u, k] = born_Shark;
                                            klet[(u + 1 + m) % m, (k + 1 + m) % m].budding_time = rand.Next(klet[(u + 1 + m) % m, (k + 1 + m) % m].age, 220);
                                        }
                                        else
                                        {
                                            klet[u, k] = pureKlet;
                                        }
                                        break;

                                    case 3:
                                        klet[u, k].hunger = klet[u, k].hunger - 1;
                                        klet[(u - 1 + m) % m, (k + m) % m] = klet[u, k];
                                        if (klet[u, k].budding_time == klet[u, k].age)
                                        {
                                            born_Shark.time_of_death = rand.Next(100,220 );
                                            born_Shark.budding_time = rand.Next(50, 200);
                                            klet[u, k] = born_Shark;
                                            klet[(u - 1 + m) % m, (k + m) % m].budding_time = rand.Next(klet[(u - 1 + m) % m, (k + m) % m].age, 220);
                                        }
                                        else
                                        {
                                            klet[u, k] = pureKlet;
                                        }
                                        break;

                                    case 4:

                                        klet[u, k].hunger = klet[u, k].hunger - 1;
                                        klet[(u + 1 + m) % m, (k+ m)%m] = klet[u, k];
                                        if (klet[u, k].budding_time == klet[u, k].age)
                                        {
                                            born_Shark.time_of_death = rand.Next(100,220 );
                                            born_Shark.budding_time = rand.Next(50, 200);
                                            klet[u, k] = born_Shark;
                                            klet[(u + 1 + m) % m, (k + m) % m].budding_time = rand.Next(klet[(u + 1 + m) % m, (k + m) % m].age, 220);

                                        }
                                        else
                                        {
                                            klet[u, k] = pureKlet;
                                        }
                                        break;

                                    case 5:

                                        klet[u, k].hunger = klet[u, k].hunger - 1;
                                        klet[(u - 1 + m) % m, (k - 1 + m) % m] = klet[u, k];
                                        if (klet[u, k].budding_time == klet[u, k].age)
                                        {
                                            born_Shark.time_of_death = rand.Next(100,220 );
                                            born_Shark.budding_time = rand.Next(50, 200);
                                            klet[u, k] = born_Shark;
                                            klet[(u - 1 + m) % m, (k - 1 + m) % m].budding_time = rand.Next(klet[(u - 1 + m) % m, (k - 1 + m) % m].age, 220);
                                        }
                                        else
                                        {
                                            klet[u, k] = pureKlet;
                                        }
                                        break;

                                    case 6:

                                        klet[u, k].hunger = klet[u, k].hunger - 1;
                                        klet[(u + m)%m, (k - 1 + m) % m] = klet[u, k];
                                        if (klet[u, k].budding_time == klet[u, k].age)
                                        {
                                            born_Shark.time_of_death = rand.Next(100,220 );
                                            born_Shark.budding_time = rand.Next(50, 200);
                                            klet[u, k] = born_Shark;
                                            klet[(u + m) % m, (k - 1 + m) % m].budding_time = rand.Next(klet[(u + m) % m, (k - 1 + m) % m].age, 220);
                                        }
                                        else
                                        {
                                            klet[u, k] = pureKlet;
                                        }
                                        break;

                                    case 7:

                                        klet[u, k].hunger = klet[u, k].hunger - 1;
                                        klet[(u + 1 + m) % m, (k - 1 + m) % m] = klet[u, k];
                                        if (klet[u, k].budding_time == klet[u, k].age)
                                        {
                                            born_Shark.time_of_death = rand.Next(100,220 );
                                            born_Shark.budding_time = rand.Next(50, 200);
                                            klet[u, k] = born_Shark;
                                            klet[(u + 1 + m) % m, (k - 1 + m) % m].budding_time = rand.Next(klet[(u + 1 + m) % m, (k - 1 + m) % m].age, 220);
                                        }
                                        else
                                        {
                                            klet[u, k] = pureKlet;
                                        }
                                        break;
                                }

                            }
                            else
                            if(a>0)
                            {
                                
                                temp = ranmas[rand.Next(a)];
                                switch (temp)
                                {
                                    case 0: // 1-ая клетка слева снизу

                                        klet[(u - 1 + m) % m, (k + 1 + m) % m] = klet[u, k];
                                        if (klet[u, k].budding_time == klet[u, k].age)
                                        {
                                            born_Shark.time_of_death = rand.Next(100,220 );
                                            born_Shark.budding_time = rand.Next(50, 200);
                                            klet[u, k] = born_Shark;
                                            klet[(u - 1 + m) % m, (k + 1 + m) % m].budding_time = rand.Next(klet[(u - 1 + m) % m, (k + 1 + m) % m].age, 220);

                                        }
                                        else
                                        {
                                            klet[u, k] = pureKlet;
                                        }
                                        break;

                                    case 1: // клетка по середине снизу 

                                        klet[(u + m) % m, (k + 1 + m) % m] = klet[u, k];
                                        if (klet[u, k].budding_time == klet[u, k].age)
                                        {
                                            born_Shark.time_of_death = rand.Next(100,220 );
                                            born_Shark.budding_time = rand.Next(50, 200);
                                            klet[u, k] = born_Shark;
                                            klet[(u + m) % m, (k + 1 + m) % m].budding_time = rand.Next(klet[(u + m) % m, (k + 1 + m) % m].age, 220);
                                        }
                                        else
                                        {
                                            klet[u, k] = pureKlet;
                                        }
                                        break;

                                    case 2:


                                        klet[(u + 1 + m) % m, (k + 1+m)%m] = klet[u, k];
                                        if (klet[u, k].budding_time == klet[u, k].age)
                                        {
                                            born_Shark.time_of_death = rand.Next(100,220 );
                                            born_Shark.budding_time = rand.Next(50, 200);
                                            klet[u, k] = born_Shark;
                                            klet[(u + 1 + m) % m, (k + 1 + m) % m].budding_time = rand.Next(klet[(u + 1 + m) % m, (k + 1 + m) % m].age, 220);
                                        }
                                        else
                                        {
                                            klet[u, k] = pureKlet;
                                        }
                                        break;

                                    case 3:

                                        klet[(u - 1 + m) % m, (k + m) % m] = klet[u, k];
                                        if (klet[u, k].budding_time == klet[u, k].age)
                                        {
                                            born_Shark.time_of_death = rand.Next(100,220 );
                                            born_Shark.budding_time = rand.Next(50, 200);
                                            klet[u, k] = born_Shark;
                                            klet[(u - 1 + m) % m, (k + m) % m].budding_time = rand.Next(klet[(u - 1 + m) % m, (k + m) % m].age, 220);
                                        }
                                        else
                                        {
                                            klet[u, k] = pureKlet;
                                        }
                                        break;

                                    case 4:


                                        klet[(u + 1 + m) % m, (k+ m)%m] = klet[u, k];
                                        if (klet[u, k].budding_time == klet[u, k].age)
                                        {
                                            born_Shark.time_of_death = rand.Next(100,220 );
                                            born_Shark.budding_time = rand.Next(50, 200);
                                            klet[u, k] = born_Shark;
                                            klet[(u + 1 + m) % m, (k + m) % m].budding_time = rand.Next(klet[(u + 1 + m) % m, (k + m) % m].age, 220);
                                        }
                                        else
                                        {
                                            klet[u, k] = pureKlet;
                                        }
                                        break;

                                    case 5:

                                        klet[(u - 1 + m) % m, (k - 1 + m) % m] = klet[u, k];
                                        if (klet[u, k].budding_time == klet[u, k].age)
                                        {
                                            born_Shark.time_of_death = rand.Next(100,220 );
                                            born_Shark.budding_time = rand.Next(50, 200);
                                            klet[u, k] = born_Shark;
                                            klet[(u - 1 + m) % m, (k - 1 + m) % m].budding_time = rand.Next(klet[(u - 1 + m) % m, (k + 1 + m) % m].age, 220);
                                        }
                                        else
                                        {
                                            klet[u, k] = pureKlet;
                                        }
                                        break;

                                    case 6:

                                        klet[(u + m)%m, (k - 1 + m) % m] = klet[u, k];
                                        if (klet[u, k].budding_time == klet[u, k].age)
                                        {
                                            born_Shark.time_of_death = rand.Next(100,220 );
                                            born_Shark.budding_time = rand.Next(50, 200);
                                            klet[u, k] = born_Shark;
                                            klet[(u + m) % m, (k - 1 + m) % m].budding_time = rand.Next(klet[(u + m) % m, (k - 1 + m) % m].age, 220);
                                        }
                                        else
                                        {
                                            klet[u, k] = pureKlet;
                                        }
                                        break;

                                    case 7:

                                        klet[(u + 1 + m) % m, (k - 1 + m) % m] = klet[u, k];
                                        if (klet[u, k].budding_time == klet[u, k].age)
                                        {
                                            born_Shark.time_of_death = rand.Next(100,220 );
                                            born_Shark.budding_time = rand.Next(50, 200);
                                            klet[u, k] = born_Shark;
                                            klet[(u + 1 + m) % m, (k - 1 + m) % m].budding_time = rand.Next(klet[(u + 1 + m) % m, (k - 1 + m) % m].age, 220);
                                        }
                                        else
                                        {
                                            klet[u, k] = pureKlet;
                                        }
                                        break;
                                }
                            }
                        }
                    }
                    
                }
            }
            stepg++;
            born_fish.step = stepg+1;
            born_Shark.step = stepg+1;
            pureKlet.step = stepg + 1;
        }

    }
}
