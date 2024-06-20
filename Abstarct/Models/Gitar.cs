using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstarct.Models
{
    public class Gitar:Enstruman
    {
        public bool Akustik { get; set; }
        public override string Sound()=>"tak tak tak";

        public override string ToString()
        {
            return $"Marka: {Marka}\n\tModel: {Model}\n\tAçıklama: {Aciqlama}\n\tFiyat: {Fiyat}\nÜretim Yeri: {UretimYeri}\n\tHammadde: {Hammadde}\n\tAkustik: {Akustik}\n";
        }
    }
}
