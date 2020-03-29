using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileLabProject.Models
{
    [Table("Words")]
    public class Word
    {
        [PrimaryKey, AutoIncrement,Column("_id")]
        public int Id { get; set; }

        public string RussianWord { get; set; }
        public string EnglishWord { get; set; }

    }
}
