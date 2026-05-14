using metjelentes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metjelentes
{
    internal class Program
    {
        static List<Jelentes> jelentesek=new List<Jelentes>();
        static void Main(string[] args)
        {
            Beolvas("tavirathu13.txt");
            // //Válogassuk le az összes, olyan jelentést, amiben szélcsend volt
            // List<Jelentes> szelcsend = jelentesek.Where(j => j.SzelSebesseg() == 0).ToList();
            // //kérjük le a budapesti átlaghőmérsékletet
            // //1. Budapesti adatok
            // //2. Azokból a hőmérsékleter
            // //3. Azok átlaga
            // double bpAtlagHom = jelentesek.Where(j => j.Telepules == "BP").Select(j=>(int)j.Homerseklet).Average();

            // //keressük az első kecskeméti Jelenést
            // Jelentes elsoKE = jelentesek.FirstOrDefault(j => j.Telepules == "KE");

            // //Keressük a hőmésékleti maximumot
            // double LegnagyobbHo = jelentesek.Max(j => j.Homerseklet);




            // //Hol mérték a hőmérsékleti maximumot
            //string Telepules= jelentesek.FirstOrDefault(j=>j.Homerseklet==LegnagyobbHo).Telepules;


            // //Válogassuk le a szélcsendes napok számát
            // jelentesek.Where(j => j.Szel == "00000").
            //     GroupBy(j=>j.Telepules).
            //     ToList().
            //     ForEach(e=>Console.WriteLine(e.Key+" "+e.Count()));


            // //Óránként hány esetben volt változó szélirány vrb
            // jelentesek.Where(j => j.SzelIrany() == "VRB").GroupBy(j=>j.Ora()).ToList().ForEach(e=>Console.WriteLine(e.Key+" "+e.Count()));

            // //Hány olyan  óra volt, amiben előfordult változó szélirány valahol
            // Console.WriteLine(jelentesek.Where(j=>j.SzelIrany()=="VRB").GroupBy(e=>e.Ora()).Count());



            //HF rész

            //2. feladat
            Console.WriteLine("2. feladat");
            Console.Write("Adja meg egy település kódját! Település:");
            string asd = Console.ReadLine();
            Jelentes q = jelentesek.Where(j => j.Telepules == asd).Last();
            Console.WriteLine($"Az utolsó mérési adat a megadott településről {q.Ido.Substring(0, 2)}:{q.Ido.Substring(2)}-kor érkezett.");


            //3. feladat
            Console.WriteLine("3. feladat");
            Jelentes min = jelentesek.OrderBy(j => j.Homerseklet).FirstOrDefault();

            Console.WriteLine($"A legalacsonyabb hőmérséklet: {min.Telepules} {min.Ido.Substring(0, 2)}:{min.Ido.Substring(2)} {min.Homerseklet} fok");

            Jelentes max = jelentesek.OrderBy(j => j.Homerseklet).Last();

            Console.WriteLine($"A legmagasabb hőmérséklet: {max.Telepules} {max.Ido.Substring(0, 2)}:{max.Ido.Substring(2)} {max.Homerseklet} fok");

            //4. fewladat
            bool van = false;

            jelentesek.Where(j => j.Szel == "00000").ToList().ForEach(e =>
            {
                Console.WriteLine($"{e.Telepules} {e.Ido.Substring(0, 2)}:{e.Ido.Substring(2)}");
                van = true;
            });

            if (!van)
            {
                Console.WriteLine("Nem volt szélcsend a mérések idején.");
            }




            //5. feladat

            Console.WriteLine("5. feladat");
            List<int> szamok = new List<int> { 1, 7, 13, 19 };

            foreach(int i in szamok ) 
            {
                jelentesek.Where(j => int.Parse(j.Ido.Substring(0, 2)) == i);
            }



            //Console.WriteLine("6. feladat");
            //jelentesek.GroupBy(j => j.Telepules).ToList().ForEach(t =>
            //{
            //    Console.WriteLine(t.Key);
            //using (StreamWriter sw = new StreamWriter($"{t.Key}.txt", true))
            //{
            //        sw.WriteLine(t.Key);
            //    }
            //    jelentesek.Where(qw => qw.Telepules == t.Key).ToList().ForEach(yx =>
            //    {
            //        using (StreamWriter sw = new StreamWriter($"{t.Key}.txt", true))
            //        {
            //            sw.WriteLine($"{yx.Ido.Substring(0, 2)}:{yx.Ido.Substring(2)} " +new string('#', yx.SzelSebesseg()));
            //        }
            //        Console.WriteLine(new string( '#', yx.SzelSebesseg()));
            //    });
            //});



        }

        static void Beolvas(string filename)
        {
            StreamReader sr=new StreamReader(filename);
            string sor;
            while ((sor = sr.ReadLine())!=null) 
            { 
               jelentesek.Add(new Jelentes(sor));
            }
        }
    }
}
