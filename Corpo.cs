using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimGrav2D
{
    internal class Corpo
    {
        private String nome;
        private double massa;
        private double densidade;
        private double posX;
        private double posY;
        private double velX;
        private double velY;

        //Construtor
        public Corpo(string nome, double massa, double densidade, double posX, double posY, double velX, double velY)
        {
            this.nome = nome;
            this.massa = massa;
            this.densidade = densidade;
            this.posX = posX;
            this.posY = posY;
            this.velX = velX;
            this.velY = velY;
        }

        //Métodos GET e Set
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public double Massa
        {
            get { return massa; }
            set { massa = value; }
        }

        public double Densidade
        {
            get { return densidade; }
            set { densidade = value; }
        }

        public double PosX
        {
            get { return posX; }
            set { posX = value; }
        }

        public double PosY
        {
            get { return posY; }
            set { posY = value; }
        }

        public double VelX
        {
            get { return velX; }
            set { velX = value; }
        }

        public double VelY
        {
            get { return velY; }
            set { velY = value; }
        }




    }
}
