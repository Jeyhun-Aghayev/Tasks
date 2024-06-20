using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstarct.Models
{
    public class Bateri:Enstruman
    {
        public string DeriTipi { get; set; }
        public override string Sound() => "bam bam bum";
        public override string ToString()
        {
            return $"Marka: {Marka}\n    Model: {Model}\n    Açıklama: {Aciqlama}\n    Fiyat: {Fiyat}\n    Üretim Yeri: {UretimYeri}\n    Hammadde: {Hammadde}\n    Deri Tipi: {DeriTipi}\n";
        }
    }
}
