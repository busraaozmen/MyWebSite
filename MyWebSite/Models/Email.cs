using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebSite.Models
{
    public class Email
    {

        [Required(ErrorMessage = "Doldurulması zorunlu alandır!")]
        public string konu { get; set; }

        [Required(ErrorMessage = "Doldurulması zorunlu alandır!")]
        public string mesaj { get; set; }

        [Required(ErrorMessage = "Doldurulması zorunlu alandır!")]
        public string isim { get; set; }

        [Required(ErrorMessage = "Doldurulması zorunlu alandır!")]
        public string soyisim { get; set; }

        [Required(ErrorMessage = "Doldurulması zorunlu alandır!")]
        public string email { get; set; }
        public override string ToString()
        {
            return "Konu: " + konu + "\nMesaj: " + mesaj + "\nAd: " + isim + "\nSoyisim: " + soyisim + "\nMail: " + email + "\nGönderim Zamanı: " + DateTime.Now;
        }

    }
}
