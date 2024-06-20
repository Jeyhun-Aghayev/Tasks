using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstarct.Models
{
    public class Piano:Enstruman
    {
        public string TelTipi { get; set; }
        public string TusTakimi { get; set; }
        public override string Sound() => "tin tin ton tun";
        public override string ToString()
        {
            return $"Marka: {Marka}\n    Model: {Model}\n    Açıklama: {Aciqlama}\n    Fiyat: {Fiyat}\n    Üretim Yeri: {UretimYeri}\n    Hammadde: {Hammadde}\n    Tel Tipi: {TelTipi}\n    Tus Takimi: {TusTakimi}";
        }
    }
}
