using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstarct.Models
{
    public interface IEnstruman
    {

    }
    public abstract class  Enstruman:IEnstruman
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Aciqlama { get; set; }
        public decimal Fiyat {  get; set; }
        public string UretimYeri { get; set; }
        public Hammade Hammadde { get; set; }
        public abstract string Sound();
    }
    public enum Hammade
    {
        Agac,
        Metal,
        Plastik
    }
}
