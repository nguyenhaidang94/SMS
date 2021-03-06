﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace SMS.CORE.Data
{
    [Table("CT_LichGiangDay")]
    public partial class CT_LichGiangDay: BaseEntity
    {
        [Key, Column(Order = 0)]
        public int MaLichGiangDay { get; set; }

        [Key, Column(Order = 1)]
        public int MaGiaoVien { get; set; }

        [Required, Column(TypeName="date")]
        public DateTime NgayBatDau { get; set; }

        [Column(TypeName="date")]
        public DateTime? NgayKetThuc { get; set; }

        public virtual LichGiangDay LichGiangDay { get; set; }
        public virtual GiaoVien GiaoVien { get; set; }

        public CT_LichGiangDay()
        { }
    }
}
