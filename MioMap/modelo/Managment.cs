﻿using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    class Managment
    {
        // aqui hay que pasar todo lo de leer y eso para hacerlo con buenas practicas 
        // para eso de cargar esa cantidad de datos estoy pensando en filtrar los datos por partes 
        // ejemplo coger de los mil y pico unos 100 y de ahi aplicarle los metodos para reducir y 
        // que queden los menos posibles y asi con todo, por ahora voy a guardar la porcion en un arreglo de 100 y trabajar
        // sobre eso y ya luego meter eso a una hash.

        private Hashtable StopsHash;
        
        public void readStops()
        {
            StreamReader reader = new StreamReader("C:/Users/DH/Desktop/datos integra/stops.csv");
            string line = reader.ReadLine();

            string las;
            string lons;

            double la;
            double lon;

            StopsHash = new Hashtable();
       
            int countInvalidEntries = 0;
            int markers = 0;

            while (line != null)
            {
                string[] datos = line.Split(',');
                las = datos[6];
                las.Replace(',', '.');
                lons = datos[7];
                lons.Replace(',', '.');
                la = 0;
                lon = 0;
                try
                {
                    la = double.Parse(las, CultureInfo.InvariantCulture);
                    lon = double.Parse(lons, CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    countInvalidEntries++;
                }
                try
                {

                    //hashCode() returns an integer value, generated by a hashing algorithm. Objects that are equal must return the same hash code. 
                    Stop a = new Stop(int.Parse(datos[0]), int.Parse(datos[1]), datos[2], datos[3], datos[6], datos[7]);
                    StopsHash.Add(a.Gps_X.GetHashCode(),a);
                    
                }
                catch (Exception)
                {
                    countInvalidEntries++;
                }

                line = reader.ReadLine();
                markers++;
            }
            Console.WriteLine("number of invalid coordenate entries: " + countInvalidEntries);
            reader.Close();
        }

        

    }
            

        


    
}
