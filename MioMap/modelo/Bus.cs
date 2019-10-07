﻿using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;

namespace modelo
{
    public class Bus
    {
        private String busId;
        private Hashtable ubicationTime;

        public Bus(string busId)
        {
            this.BusId = busId;
            UbicationTime = new Hashtable();
        }


        public void addTime(String posX, String posY, String time)
        {
       //     Console.WriteLine(time);
            String[] date = time.Split(' ');
            String[] hour = date[1].Split('.');
            String[] date2 = date[0].Split('-');
            String key = Int32.Parse(date2[0]) +"-"+date2[1] + "-" +Int32.Parse(date2[2]) + " " + Int32.Parse(hour[0]) + "." + Int32.Parse(hour[1]) + "."  + Int32.Parse(hour[2]) + " " + date[2];

            if (!UbicationTime.ContainsKey(key))
            {
                UbicationTime.Add(key, new Ubication(posX, posY));
            }
        }


        public string BusId { get => busId; set => busId = value; }
        public Hashtable UbicationTime { get => ubicationTime; set => ubicationTime = value; }

        //      public void trmove()
        //        {

        // this.PosX = Convert.ToDouble(((Ubication)UbicationTime[realTime]).Posx);
        //  this.PosY = Convert.ToDouble(((Ubication)UbicationTime[realTime]).Posy);

        //}

        //    public void move()
        //   {
        //      sincro = new Thread(new ThreadStart(trmove));
        //     sincro.Start();
        //}


    }
}
